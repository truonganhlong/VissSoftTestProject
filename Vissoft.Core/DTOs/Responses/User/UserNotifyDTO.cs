using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vissoft.Core.DTOs.Responses.User
{
    public class UserNotifyDTO
    {
        public int? id { get; set; }
        public string? name { get; set; } = null!;
        public string? username { get; set; } = null!;
        public string? password { get; set; }
        public string? email { get; set; } = null!;
        public string? phone { get; set; }
        public string notify { get; set; } = null!;
        public string? permission {  get; set; }
    }
}
