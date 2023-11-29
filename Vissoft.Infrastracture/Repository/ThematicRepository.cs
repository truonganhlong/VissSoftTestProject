using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vissoft.Core.DTOs.Requests.Thematic;
using Vissoft.Core.DTOs.Responses.Lesson;
using Vissoft.Core.DTOs.Responses.Thematic;
using Vissoft.Core.Entities;
using Vissoft.Core.Interfaces;
using Vissoft.Infrastracture.Data;

namespace Vissoft.Infrastracture.Repository
{
    public class ThematicRepository : IThematicRepository
    {
        private readonly VissoftDbContext _dbContext;
        private readonly IMapper _mapper;
        public ThematicRepository(VissoftDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ThematicNotifyDTO> create(ThematicRequest request)
        {
            try
            {
                Thematic thematic = new Thematic()
                {
                    course_id = request.course_id,
                    name = request.name,
                    status = true
                };
                await _dbContext.Thematics.AddAsync(thematic);
                await _dbContext.SaveChangesAsync();
                return _mapper.Map<ThematicNotifyDTO>((thematic));
            }
            catch (Exception)
            {

                return new ThematicNotifyDTO()
                {
                    id = null,
                    course_id = null,
                    name = null,
                    notify = "Kết nối không ổn định!"
                };
            }
        }

        public async Task<List<ThematicDTO>?> readByAdmin()
        {
            try
            {
                List<Thematic> list = await _dbContext.Thematics.ToListAsync();
                if (list == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<List<ThematicDTO>>(list);
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<List<ThematicDTO>?> readByCourse(int course_id)
        {
            try
            {
                List<Thematic> list = await _dbContext.Thematics.Where(x => x.course_id == course_id).ToListAsync();
                if (list == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<List<ThematicDTO>>(list);
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<List<ThematicDTO>?> readByUser()
        {
            try
            {
                List<Thematic> list = await _dbContext.Thematics.Where(x => x.status == true).ToListAsync();
                if (list == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<List<ThematicDTO>>(list);
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<ThematicDTO?> readOne(int id)
        {
            try
            {
                var thematic = await _dbContext.Thematics.FindAsync(id);
                if (thematic == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<ThematicDTO>(thematic);
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<ThematicNotifyDTO> update(int id, ThematicRequest request)
        {
            try
            {
                var thematic = await _dbContext.Thematics.FindAsync(id);
                if (thematic == null)
                {
                    return new ThematicNotifyDTO()
                    {
                        id = null,
                        course_id = null,
                        name = null,
                        notify = "Không tìm thấy khóa học trên!"
                    };
                }
                if (thematic.name == request.name && thematic.course_id == request.course_id)
                {
                    return new ThematicNotifyDTO()
                    {

                        id = null,
                        course_id = null,
                        name = null,
                        notify = "Không có gì thay đổi!"
                    };
                }
                thematic.name = request.name;
                thematic.course_id = request.course_id;
                _dbContext.Thematics.Update(thematic);
                await _dbContext.SaveChangesAsync();
                return _mapper.Map<ThematicNotifyDTO>(thematic);
            }
            catch (Exception)
            {

                return new ThematicNotifyDTO()
                {
                    id = null,
                    course_id = null,
                    name = null,
                    notify = "Kết nối không ổn định!"
                };
            }
        }

        public async Task<bool> updateStatus(int id)
        {
            try
            {
                var thematic = await _dbContext.Thematics.FindAsync(id);
                if (thematic == null)
                {
                    return false;
                }
                else
                {
                    thematic.status = !thematic.status;
                    _dbContext.Thematics.Update(thematic);
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
