using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vissoft.Core.DTOs.Requests.Course;
using Vissoft.Core.DTOs.Responses.Course;
using Vissoft.Core.DTOs.Responses.Thematic;
using Vissoft.Core.Entities;
using Vissoft.Core.Interfaces;
using Vissoft.Infrastracture.Data;

namespace Vissoft.Infrastracture.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly VissoftDbContext _dbContext;
        private readonly IMapper _mapper;
        public CourseRepository(VissoftDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<CourseNotifyDTO> create(CourseRequest request)
        {
            try
            {
                Course course = new Course()
                {
                    grade_id = request.grade_id,
                    name = request.name,
                    description = request.description,
                    info = request.info,
                    status = true
                };
                await _dbContext.Courses.AddAsync(course);
                await _dbContext.SaveChangesAsync();
                return _mapper.Map<CourseNotifyDTO>((course));
            }
            catch (Exception)
            {

                return new CourseNotifyDTO()
                {
                    id = null,
                    grade_id = null,
                    name = null,
                    description = null,
                    info = null,
                    notify = "Kết nối không ổn định!"
                };
            }
        }

        public async Task<List<CourseDTO>?> readByAdmin()
        {
            try
            {
                List<Course> list = await _dbContext.Courses.ToListAsync();
                if (list == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<List<CourseDTO>>(list);
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<List<CourseDTO>?> readByGrade(int grade_id)
        {
            try
            {
                List<Course> list = await _dbContext.Courses.Where(x => x.grade_id == grade_id).ToListAsync();
                if (list == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<List<CourseDTO>>(list);
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<List<CourseDTO>?> readByUser()
        {
            try
            {
                List<Course> list = await _dbContext.Courses.Where(x => x.status == true).ToListAsync();
                if (list == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<List<CourseDTO>>(list);
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<CourseDTO?> readOne(int id)
        {
            try
            {
                var course = await _dbContext.Courses.FindAsync(id);
                if (course == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<CourseDTO>(course);
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<CourseNotifyDTO> update(int id, CourseRequest request)
        {
            try
            {
                var course = await _dbContext.Courses.FindAsync(id);
                if (course == null)
                {
                    return new CourseNotifyDTO()
                    {
                        id = null,
                        grade_id = null,
                        name = null,
                        description = null,
                        info = null,
                        notify = "Không tìm thấy khóa học trên!"
                    };
                }
                if (course.name == request.name && course.grade_id == request.grade_id && course.description == request.description && course.info == request.info)
                {
                    return new CourseNotifyDTO()
                    {

                        id = null,
                        grade_id = null,
                        name = null,
                        description = null,
                        info = null,
                        notify = "Không có gì thay đổi!"
                    };
                }
                course.name = request.name;
                course.grade_id = request.grade_id;
                course.description = request.description;
                course.info = request.info;
                _dbContext.Courses.Update(course);
                await _dbContext.SaveChangesAsync();
                return _mapper.Map<CourseNotifyDTO>(course);
            }
            catch (Exception)
            {

                return new CourseNotifyDTO()
                {
                    id = null,
                    grade_id = null,
                    name = null,
                    description = null,
                    info = null,
                    notify = "Kết nối không ổn định!"
                };
            }
        }

        public async Task<bool> updateStatus(int id)
        {
            try
            {
                var course = await _dbContext.Courses.FindAsync(id);
                if (course == null)
                {
                    return false;
                }
                else
                {
                    course.status = !course.status;
                    _dbContext.Courses.Update(course);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
