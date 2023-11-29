using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vissoft.Core.DTOs.Responses.Course
{
    public class CourseNotifyDTO
    {
        public int? id { get; set; }
        public int? grade_id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public string? info { get; set; }
        public string notify { get; set; } = null!; 
    }
}
