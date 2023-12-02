using AutoMapper;
using CoreApiResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Vissoft.Core.DTOs.Constants;
using Vissoft.Core.DTOs.Requests.Lesson;
using Vissoft.Core.Interfaces;
using Vissoft.Infrastracture.Data;
using Vissoft.Infrastracture.Repository;

namespace Vissoft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : BaseController
    {
        private readonly LessonRepository _lessonRepository;
        public LessonController(VissoftDbContext dbContext, IMapper mapper) { 
            _lessonRepository = new LessonRepository(dbContext, mapper);
        }
        [HttpGet("Admin")]
        [Authorize(Roles = RoleConst.ADMIN_PERMISSION)]
        public async Task<IActionResult> ReadByAdmin()
        {
            try
            {
                var data = await _lessonRepository.readByAdmin();
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
                var data = await _lessonRepository.readByUser();
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

        [HttpGet("Thematic/{thematic_id}")]
        public async Task<IActionResult> ReadByThematic(int thematic_id)
        {
            try
            {
                var data = await _lessonRepository.readByThematic(thematic_id);
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
                var data = await _lessonRepository.readOne(id);
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
        [Authorize(Roles = RoleConst.ADMIN_PERMISSION)]
        public async Task<IActionResult> Create([FromForm] LessonRequest obj)
        {
            try
            {
                var data = await _lessonRepository.create(obj);
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
        [Authorize(Roles = RoleConst.ADMIN_PERMISSION)]
        public async Task<IActionResult> Update(int id, LessonRequest obj)
        {
            try
            {
                var data = await _lessonRepository.update(id, obj);
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
        [Authorize(Roles = RoleConst.ADMIN_PERMISSION)]
        public async Task<IActionResult> UpdateStatus(int id)
        {
            try
            {
                var data = await _lessonRepository.updateStatus(id);
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
