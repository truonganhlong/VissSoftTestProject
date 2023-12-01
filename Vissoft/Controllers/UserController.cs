using AutoMapper;
using Azure.Core;
using CoreApiResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using Vissoft.Core.DTOs.Requests.User;
using Vissoft.Core.DTOs.Responses.User;
using Vissoft.Infrastracture.Data;
using Vissoft.Infrastracture.Repository;

namespace Vissoft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly UserRepository _userRepository;
        private readonly IConfiguration _configuration;
        public UserController(VissoftDbContext dbContext, IMapper mapper, IConfiguration configuration)
        {
            _userRepository = new UserRepository(dbContext, mapper);
            _configuration = configuration;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            try
            {
                var data = await _userRepository.Register(request);
                if (data == false)
                {
                    return CustomResult("Đăng kí thất bại do đã có tài khoản trên. Thay đổi thông tin của bạn!", HttpStatusCode.BadRequest);
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("LoginViaForm")]
        public IActionResult Login(LoginRequest request)
        {
            if (string.IsNullOrEmpty(request.username) || string.IsNullOrEmpty(request.password)) return CustomResult("Thông tin nhập vào sai!", HttpStatusCode.BadRequest);
            try
            {
                var user = _userRepository.LoginViaForm(request);
                if (user.id == null)
                {
                    return CustomResult(user.notify, HttpStatusCode.NotFound);
                }
                else
                {
                    string token = CreateToken(user);
                    return Ok(token);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("LoginViaGoogle")]
        public async Task<IActionResult> LoginViaGoogle(LoginViaGoogleRequest request)
        {
            try
            {
                var user = await _userRepository.LoginViaGoogle(request);
                if (user == null)
                {
                    return CustomResult("Đăng nhập thất bại", HttpStatusCode.NotFound);
                }
                else
                {
                    string token = CreateToken(user);
                    return Ok(token);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        private string CreateToken(UserNotifyDTO user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.username!),
                new Claim(ClaimTypes.Role, user.permission!),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value!));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                    _configuration.GetSection("AppSettings:Issuer").Value,
                    _configuration.GetSection("AppSettings:Audience").Value,
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: cred
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
