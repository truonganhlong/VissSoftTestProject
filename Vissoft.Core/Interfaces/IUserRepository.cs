using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vissoft.Core.DTOs.Requests.User;
using Vissoft.Core.DTOs.Responses.User;

namespace Vissoft.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> Register(RegisterRequest request);
        UserNotifyDTO LoginViaForm(LoginRequest request);
        Task<UserNotifyDTO> LoginViaGoogle(LoginViaGoogleRequest request);
    }
}
