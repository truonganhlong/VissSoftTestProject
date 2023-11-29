using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vissoft.Core.DTOs.Requests.Course
{
    public class CourseRequest
    {
        public int grade_id { get; set; }
        public string name { get; set; } = null!;
        public string description { get; set; } = null!;
        public string info { get; set; } = null!;
    }
}
