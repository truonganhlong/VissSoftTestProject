using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vissoft.Core.DTOs.Responses.Lesson
{
    public class LessonNotifyDTO
    {
        public int? id { get; set; }
        public int? thematic_id { get; set; }
        public string? name { get; set; }
        public string? overview { get; set; }
        public string? link { get; set; }
        public string notify { get; set; } = null!;
    }
}
