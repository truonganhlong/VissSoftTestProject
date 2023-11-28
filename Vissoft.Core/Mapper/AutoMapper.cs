using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vissoft.Core.DTOs.Responses.Grade;
using Vissoft.Core.Entities;

namespace Vissoft.Core.Mapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Grade, GradeDTO>();
            CreateMap<Grade, GradeNotifyDTO>();
        }
    }
}
