using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vissoft.Core.Entities
{
    public partial class Grade
    {
        public int id { get; set; }
        public string name { get; set; } = null!;
        public List<Course> Courses { get; set; } = null!;
    }
}
