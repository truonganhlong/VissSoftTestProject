using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vissoft.Core.DTOs.Requests.Grade;
using Vissoft.Core.DTOs.Responses.Grade;
using Vissoft.Core.Entities;
using Vissoft.Core.Interfaces;
using Vissoft.Infrastracture.Data;

namespace Vissoft.Infrastracture.Repository
{
    public class GradeRepository : IGradeRepository
    {
        private readonly VissoftDbContext _dbContext;
        private readonly IMapper _mapper;
        public GradeRepository(VissoftDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<GradeNotifyDTO> create(GradeRequest request)
        {
            try
            {
                if (await _dbContext.Grades.AnyAsync(x => x.name == request.name)) { 
                    return new GradeNotifyDTO()
                    {
                        id = null,
                        name = null,
                        notify = "Đã có khối này, không thể thêm!"
                    };
                } else
                {
                    Grade grade = new Grade()
                    {
                        name = request.name,
                    };
                    await _dbContext.Grades.AddAsync(grade);
                    await _dbContext.SaveChangesAsync();
                    return _mapper.Map<GradeNotifyDTO>((grade));
                }
            }
            catch (Exception)
            {

                return new GradeNotifyDTO()
                {
                    id = null,
                    name = null,
                    notify = "Kết nối không ổn định!"
                };
            }
        }

        public async Task<bool> delete(int id)
        {
            try
            {
                if(await _dbContext.Grades.FindAsync(id) == null)
                {
                    return false;
                } else
                {
                    Grade grade = await _dbContext.Grades.Where(x => x.id == id).FirstAsync();
                    _dbContext.Remove(grade);
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<List<GradeDTO>?> readAll()
        {
            try
            {
                List<Grade> list = await _dbContext.Grades.ToListAsync();
                if(list == null)
                {
                    return null;
                } else
                {
                    return _mapper.Map<List<GradeDTO>>(list);
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<GradeDTO?> readOne(int id)
        {
            try
            {
                var grade = await _dbContext.Grades.FindAsync(id);
                if (grade == null)
                {
                    return null;
                } else
                {
                    return _mapper.Map<GradeDTO>(grade);
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<GradeNotifyDTO> update(int id, GradeRequest request)
        {
            try
            {
                var grade = await _dbContext.Grades.FindAsync(id);
                if(grade == null)
                {
                    return new GradeNotifyDTO()
                    {
                        id = null,
                        name = null,
                        notify = "Không tìm thấy khối trên!"
                    };
                }
                if (grade.name == request.name)
                {
                    return new GradeNotifyDTO()
                    {
                        id = null,
                        name = null,
                        notify = "Không có gì thay đổi!"
                    };
                }
                grade.name = request.name;
                _dbContext.Grades.Update(grade);
                await _dbContext.SaveChangesAsync();
                return _mapper.Map<GradeNotifyDTO>(grade);
            }
            catch (Exception)
            {

                return new GradeNotifyDTO()
                {
                    id = null,
                    name = null,
                    notify = "Kết nối không ổn định!"
                };
            }
        }
    }
}
