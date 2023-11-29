using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vissoft.Core.DTOs.Requests.Lesson;
using Vissoft.Core.DTOs.Responses.Lesson;

namespace Vissoft.Core.Interfaces
{
    public interface ILessonRepository
    {
        Task<List<LessonDTO>?> readByAdmin();
        Task<List<LessonDTO>?> readByUser();
        Task<List<LessonDTO>?> readByThematic(int thematic_id);
        Task<LessonDTO?> readOne(int id);
        Task<LessonNotifyDTO> create(LessonRequest request);
        Task<LessonNotifyDTO> update(int id, LessonRequest request);
        Task<bool> updateStatus(int id);
    }
}
