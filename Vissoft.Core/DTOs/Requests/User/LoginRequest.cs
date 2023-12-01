using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vissoft.Core.DTOs.Requests.User
{
    public class LoginRequest
    {
        public string username { get; set; } = null!;
        public string? password { get; set; }
    }
}
