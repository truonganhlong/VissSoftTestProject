using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vissoft.Core.Entities
{
    public partial class Lesson
    {
        public int id { get; set; }
        public string name { get; set; } = null!;
        public string overview { get; set; } = null!;
        public string link { get; set; } = null!;
        public bool status { get; set; }
        public List<Thematic> Thematics { get; set; } = null!;
    }
}
