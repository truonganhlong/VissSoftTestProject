using AutoMapper;
using CoreApiResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Net;
using Vissoft.Core.DTOs.Requests.Grade;
using Vissoft.Infrastracture.Data;
using Vissoft.Infrastracture.Repository;

namespace Vissoft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : BaseController
    {
        private readonly GradeRepository _gradeRepository;
        public GradeController(VissoftDbContext dbContext, IMapper mapper)
        {
            _gradeRepository = new GradeRepository(dbContext, mapper);
        }

        [HttpGet]
        public async Task<IActionResult> ReadAll()
        {
            try
            {
                var data = await _gradeRepository.readAll();
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
                var data = await _gradeRepository.readOne(id);
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
        public async Task<IActionResult> Create([FromForm] GradeRequest obj)
        {
            try
            {
                var data = await _gradeRepository.create(obj);
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, GradeRequest obj)
        {
            try
            {
                var data = await _gradeRepository.update(id, obj);
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var data = await _gradeRepository.delete(id);
                if (data == false)
                {
                    return CustomResult("Không tìm thấy dữ liệu để xóa", HttpStatusCode.NotFound);
                }
                return CustomResult("Xóa thành công", data);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
