using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vissoft.Core.DTOs.Requests.Course;
using Vissoft.Core.DTOs.Responses.Course;

namespace Vissoft.Core.Interfaces
{
    public interface ICourseRepository
    {
        Task<List<CourseDTO>?> readByAdmin();
        Task<List<CourseDTO>?> readByUser();
        Task<List<CourseDTO>?> readByGrade(int grade_id);
        Task<CourseDTO?> readOne(int id);
        Task<CourseNotifyDTO> create(CourseRequest request);
        Task<CourseNotifyDTO> update(int id, CourseRequest request);
        Task<bool> updateStatus(int id);
    }
}
