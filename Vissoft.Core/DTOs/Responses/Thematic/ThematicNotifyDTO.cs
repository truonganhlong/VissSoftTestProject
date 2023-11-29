using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vissoft.Core.DTOs.Responses.Thematic
{
    public class ThematicNotifyDTO
    {
        public int? id { get; set; }
        public int? course_id { get; set; }
        public string? name { get; set; }
        public string notify { get; set; } = null!;
    }
}
