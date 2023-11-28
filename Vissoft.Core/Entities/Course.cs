using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vissoft.Core.Entities
{
    public partial class Course
    {
        public int id { get; set; }
        public int grade_id { get; set; }
        public string name { get; set; } = null!;
        public string description { get; set; } = null!;
        public string info { get; set; } = null!;
        public DateTime createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public int? createdBy { get; set; }
        public int? updatedBy { get; set; }
        public bool status { get; set; }
        public Grade Grade { get; set; } = null!;
        public List<Thematic> Thematics { get; set; } = null!;
    }
}
