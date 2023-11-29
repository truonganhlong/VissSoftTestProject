using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vissoft.Core.DTOs.Requests.Lesson;
using Vissoft.Core.DTOs.Responses.Lesson;
using Vissoft.Core.Entities;
using Vissoft.Core.Interfaces;
using Vissoft.Infrastracture.Data;

namespace Vissoft.Infrastracture.Repository
{
    public class LessonRepository : ILessonRepository
    {
        private readonly VissoftDbContext _dbContext;
        private readonly IMapper _mapper;
        public LessonRepository(VissoftDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<LessonNotifyDTO> create(LessonRequest request)
        {
            try
            {
                Lesson lesson = new Lesson()
                {
                    thematic_id = request.thematic_id,
                    name = request.name,
                    overview = request.overview,
                    link = request.link,
                    status = true
                };
                await _dbContext.Lessons.AddAsync(lesson);
                await _dbContext.SaveChangesAsync();
                return _mapper.Map<LessonNotifyDTO>((lesson));
            }
            catch (Exception)
            {

                return new LessonNotifyDTO()
                {
                    id = null,
                    thematic_id = null,
                    name = null,
                    overview = null,
                    link = null,
                    notify = "Kết nối không ổn định!"
                };
            }
        }

        public async Task<List<LessonDTO>?> readByAdmin()
        {
            try
            {
                List<Lesson> list = await _dbContext.Lessons.ToListAsync();
                if (list == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<List<LessonDTO>>(list);
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<List<LessonDTO>?> readByThematic(int thematic_id)
        {
            try
            {
                List<Lesson> list = await _dbContext.Lessons.Where(x => x.thematic_id == thematic_id).ToListAsync();
                if (list == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<List<LessonDTO>>(list);
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<List<LessonDTO>?> readByUser()
        {
            try
            {
                List<Lesson> list = await _dbContext.Lessons.Where(x => x.status == true).ToListAsync();
                if (list == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<List<LessonDTO>>(list);
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<LessonDTO?> readOne(int id)
        {
            try
            {
                var lesson = await _dbContext.Lessons.FindAsync(id);
                if (lesson == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<LessonDTO>(lesson);
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<LessonNotifyDTO> update(int id, LessonRequest request)
        {
            try
            {
                var lesson = await _dbContext.Lessons.FindAsync(id);
                if (lesson == null)
                {
                    return new LessonNotifyDTO()
                    {
                        id = null,
                        thematic_id = null,
                        name = null,
                        overview = null,
                        link = null,
                        notify = "Không tìm thấy bài học trên!"
                    };
                }
                if (lesson.name == request.name && lesson.overview == request.overview && lesson.link == request.link && lesson.thematic_id == request.thematic_id)
                {
                    return new LessonNotifyDTO()
                    {
                        id = null,
                        thematic_id = null,
                        name = null,
                        overview = null,
                        link = null,
                        notify = "Không có gì thay đổi!"
                    };
                }
                lesson.name = request.name;
                lesson.overview = request.overview;
                lesson.link = request.link;
                lesson.thematic_id = request.thematic_id;
                _dbContext.Lessons.Update(lesson);
                await _dbContext.SaveChangesAsync();
                return _mapper.Map<LessonNotifyDTO>(lesson);
            }
            catch (Exception)
            {

                return new LessonNotifyDTO()
                {
                    id = null,
                    thematic_id = null,
                    name = null,
                    overview = null,
                    link = null,
                    notify = "Kết nối không ổn định!"
                };
            }
        }

        public async Task<bool> updateStatus(int id)
        {
            try
            {
                var lesson = await _dbContext.Lessons.FindAsync(id);
                if (lesson == null)
                {
                    return false;
                } else
                {
                    lesson.status = !lesson.status;
                    _dbContext.Lessons.Update(lesson);
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
