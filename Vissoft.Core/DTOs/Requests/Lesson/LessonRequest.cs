using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vissoft.Core.DTOs.Requests.Lesson
{
    public class LessonRequest
    {
        public int thematic_id { get; set; }
        public string name { get; set; } = null!;
        public string overview { get; set; } = null!;
        public string link { get; set; } = null!;
    }
}
