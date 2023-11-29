using AutoMapper;
using CoreApiResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Vissoft.Core.DTOs.Requests.Thematic;
using Vissoft.Core.Interfaces;
using Vissoft.Infrastracture.Data;
using Vissoft.Infrastracture.Repository;

namespace Vissoft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThematicController : BaseController
    {
        private readonly ThematicRepository _thematicRepository;
        public ThematicController(VissoftDbContext dbContext, IMapper mapper)
        {
            _thematicRepository = new ThematicRepository(dbContext, mapper);
        }

        [HttpGet("Admin")]
        public async Task<IActionResult> ReadByAdmin()
        {
            try
            {
                var data = await _thematicRepository.readByAdmin();
                if (data == null)
                {
                    return CustomResult("Không tìm thấy dữ liệu!", HttpStatusCode.NotFound);
                }
                return CustomResult("Dữ liệu tải thành công!", data);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("User")]
        public async Task<IActionResult> ReadByUser()
        {
            try
            {
                var data = await _thematicRepository.readByUser();
                if (data == null)
                {
                    return CustomResult("Không tìm thấy dữ liệu!", HttpStatusCode.NotFound);
                }
                return CustomResult("Dữ liệu tải thành công!", data);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Course/{course_id}")]
        public async Task<IActionResult> ReadByCourse(int course_id)
        {
            try
            {
                var data = await _thematicRepository.readByCourse(course_id);
                if (data == null)
                {
                    return CustomResult("Không tìm thấy dữ liệu!", HttpStatusCode.NotFound);
                }
                return CustomResult("Dữ liệu tải thành công!", data);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> ReadById(int id)
        {
            try
            {
                var data = await _thematicRepository.readOne(id);
                if (data == null)
                {
                    return CustomResult("Không tìm thấy dữ liệu!", HttpStatusCode.NotFound);
                }
                return CustomResult("Dữ liệu tải thành công!", data);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ThematicRequest obj)
        {
            try
            {
                var data = await _thematicRepository.create(obj);
                if (data.id == null)
                {
                    return CustomResult(data.notify, HttpStatusCode.BadRequest);
                }
                return CustomResult("Thêm thành công!", data);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, ThematicRequest obj)
        {
            try
            {
                var data = await _thematicRepository.update(id, obj);
                if (data.id == null)
                {
                    return CustomResult(data.notify, HttpStatusCode.BadRequest);
                }
                return CustomResult("Sửa thành công", data);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateStatus/{id}")]
        public async Task<IActionResult> UpdateStatus(int id)
        {
            try
            {
                var data = await _thematicRepository.updateStatus(id);
                if (data == false)
                {
                    return CustomResult("Sửa thất bại", HttpStatusCode.BadRequest);
                }
                return CustomResult("Sửa thành công", data);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
