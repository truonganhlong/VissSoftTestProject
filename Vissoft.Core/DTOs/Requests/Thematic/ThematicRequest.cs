using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vissoft.Core.DTOs.Requests.Thematic
{
    public class ThematicRequest
    {
        public int course_id { get; set; }
        public string name { get; set; } = null!;
    }
}
