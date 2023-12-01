using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vissoft.Core.DTOs.Responses.Course;
using Vissoft.Core.DTOs.Responses.Grade;
using Vissoft.Core.DTOs.Responses.Lesson;
using Vissoft.Core.DTOs.Responses.Thematic;
using Vissoft.Core.DTOs.Responses.User;
using Vissoft.Core.Entities;

namespace Vissoft.Core.Mapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Grade, GradeDTO>();
            CreateMap<Grade, GradeNotifyDTO>();
            CreateMap<Lesson, LessonDTO>();
            CreateMap<Lesson, LessonNotifyDTO>();
            CreateMap<Course, CourseDTO>();
            CreateMap<Course, CourseNotifyDTO>();
            CreateMap<Thematic, ThematicDTO>();
            CreateMap<Thematic, ThematicNotifyDTO>();
            CreateMap<User, UserDTO>();
            CreateMap<User,UserNotifyDTO>();
        }
    }
}
