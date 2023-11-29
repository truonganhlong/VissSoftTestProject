using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vissoft.Core.DTOs.Requests.Thematic;
using Vissoft.Core.DTOs.Responses.Thematic;

namespace Vissoft.Core.Interfaces
{
    public interface IThematicRepository
    {
        Task<List<ThematicDTO>?> readByAdmin();
        Task<List<ThematicDTO>?> readByUser();
        Task<List<ThematicDTO>?> readByCourse(int course_id);
        Task<ThematicDTO?> readOne(int id);
        Task<ThematicNotifyDTO> create(ThematicRequest request);
        Task<ThematicNotifyDTO> update(int id, ThematicRequest request);
        Task<bool> updateStatus(int id);
    }
}
