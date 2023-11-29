using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vissoft.Core.Entities
{
    public partial class Thematic
    {
        public int id { get; set; }
        public int course_id { get; set; }
        public string name { get; set; } = null!;
        public bool status { get; set; }
        public Course Course { get; set; } = null!;
        public List<Lesson> Lessons { get; set; } = null!;
    }
}
