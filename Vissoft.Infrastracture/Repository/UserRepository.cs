using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Vissoft.Core.DTOs.Constants;
using Vissoft.Core.DTOs.Requests.User;
using Vissoft.Core.DTOs.Responses.User;
using Vissoft.Core.Entities;
using Vissoft.Core.Interfaces;
using Vissoft.Infrastracture.Data;

namespace Vissoft.Infrastracture.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly VissoftDbContext _dbContext;
        private readonly IMapper _mapper;
        public UserRepository(VissoftDbContext dbContext, IMapper mapper) { 
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public UserNotifyDTO LoginViaForm(LoginRequest request)
        {
            try
            {
                if (_dbContext.Users.Any(x => x.username == request.username || x.email == request.username || x.phone == request.username) == false) { 
                    return new UserNotifyDTO() { 
                        id = null, 
                        name = null,
                        username = null, 
                        password = null, 
                        email = null,
                        phone = null,
                        permission = null,
                        notify = "Không có tài khoản nào có tên đăng nhập này!" 
                    }; 
                }
                else
                {
                    User user = _dbContext.Users.Where(x => x.username == request.username || x.email == request.username || x.phone == request.username).First();
                    if (user.password == null || !BCrypt.Net.BCrypt.Verify(request.password, user.password)) {
                        return new UserNotifyDTO()
                        {
                            id = null,
                            name = null,
                            username = null,
                            password = null,
                            email = null,
                            phone = null,
                            permission = null,
                            notify = "Sai mật khẩu!"
                        };
                    }
                    else
                    {
                        UserNotifyDTO obj = _mapper.Map<UserNotifyDTO>(user);
                        obj.notify = "Đăng nhập thành công!";
                        obj.permission = RoleConst.USER_PERMISSION;
                        return obj;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UserNotifyDTO> LoginViaGoogle(LoginViaGoogleRequest request)
        {
            try
            {
                if(!_dbContext.Users.Any(x => x.username == request.username)) { 
                    RegisterRequest registerRequest = new RegisterRequest()
                    {
                        name = request.name,
                        username = request.username,
                        password = request.password,
                        email = request.email,
                        phone = request.phone,
                    };
                    await Register(registerRequest);
                }
                User user = _dbContext.Users.Where(x => x.email == request.email).First();
                UserNotifyDTO obj = _mapper.Map<UserNotifyDTO>(user);
                obj.notify = "Đăng nhập thành công!";
                obj.permission = RoleConst.USER_PERMISSION;
                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Register(RegisterRequest request)
        {
            try
            {
                if (_dbContext.Users.Any(x => x.username != null && x.email != null && x.phone !=null && (x.username == request.username || x.email == request.email || x.phone == request.phone))) { return false; }
                else
                {
                    User user = new User();
                    if(request.password == null || request.phone == null)
                    {
                        user.name = request.username;
                        user.username = request.username;
                        user.password = null;
                        user.email = request.email;
                        user.phone = null;
                    } else
                    {
                        user.name = request.username;
                        user.username = request.username;
                        user.password = HashPassword(request.password);
                        user.email = request.email;
                        user.phone = request.phone;
                    }
                    await _dbContext.Users.AddAsync(user);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        private String HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
