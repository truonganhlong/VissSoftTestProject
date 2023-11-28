using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vissoft.Core.DTOs.Responses.Grade
{
    public class GradeNotifyDTO
    {
        public int? id { get; set; }
        public string? name { get; set; }
        public string notify { get; set; } = null!;
    }
}
