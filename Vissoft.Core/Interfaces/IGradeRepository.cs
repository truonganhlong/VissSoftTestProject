using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vissoft.Core.DTOs.Requests.Grade;
using Vissoft.Core.DTOs.Responses.Grade;
using Vissoft.Core.Entities;

namespace Vissoft.Core.Interfaces
{
    public interface IGradeRepository
    {
        Task<List<GradeDTO>?> readAll();
        Task<GradeDTO?> readOne(int id);
        Task<GradeNotifyDTO> create(GradeRequest request);
        Task<GradeNotifyDTO> update(int id, GradeRequest request);
        Task<bool> delete(int id);
    }
}
