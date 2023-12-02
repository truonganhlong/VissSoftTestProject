using AutoMapper;
using CoreApiResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Vissoft.Core.DTOs.Constants;
using Vissoft.Core.DTOs.Requests.Course;
using Vissoft.Core.Interfaces;
using Vissoft.Infrastracture.Data;
using Vissoft.Infrastracture.Repository;

namespace Vissoft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : BaseController
    {
        private readonly CourseRepository _courseRepository;
        public CourseController(VissoftDbContext dbContext, IMapper mapper) { 
            _courseRepository = new CourseRepository(dbContext, mapper);
        }
        [HttpGet("Admin")]
        [Authorize(Roles = RoleConst.ADMIN_PERMISSION)]
        public async Task<IActionResult> ReadByAdmin()
        {
            try
            {
                var data = await _courseRepository.readByAdmin();
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
                var data = await _courseRepository.readByUser();
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

        [HttpGet("Grade/{grade_id}")]
        public async Task<IActionResult> ReadByGrade(int grade_id)
        {
            try
            {
                var data = await _courseRepository.readByGrade(grade_id);
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
                var data = await _courseRepository.readOne(id);
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
        public async Task<IActionResult> Create([FromForm] CourseRequest obj)
        {
            try
            {
                var data = await _courseRepository.create(obj);
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
        public async Task<IActionResult> Update(int id, CourseRequest obj)
        {
            try
            {
                var data = await _courseRepository.update(id, obj);
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
                var data = await _courseRepository.updateStatus(id);
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
