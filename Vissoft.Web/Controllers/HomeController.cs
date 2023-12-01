using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Vissoft.Web.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Vissoft.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(IFormCollection collection)
        {
            User user = new User()
            {
                username = collection["username"]!,
                password = collection["password"]!,
            };
            RestClient restClient = new RestClient(_configuration);
            restClient.endPoint = "User/LoginViaForm";
            int kq = restClient.InsertData(user);
            if(kq == 1)
            {
                return RedirectToAction("Index", "Home");
            } else
            {
                return View();
            }
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(IFormCollection collection) {
            User user = new User()
            {
                name = collection["name"]!,
                username = collection["username"]!,
                password = collection["password"]!,
                email = collection["email"]!,
                phone = collection["phone"]!
            };
            RestClient restClient = new RestClient(_configuration);
            restClient.endPoint = "User/Register";
            int kq = restClient.InsertData(user);
            if (kq == 1)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View();
            }
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        public async Task LoginViaGoogle()
        {
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, new AuthenticationProperties()
            {
                RedirectUri = Url.Action("GoogleResponse")
            });
        }
        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var claim = result.Principal!.Identities.FirstOrDefault()!.Claims.Select(claim => new
            {
                claim.Issuer,
                claim.OriginalIssuer,
                claim.Type,
                claim.Value
            });
            List<string> list = new List<string>();
            string json = JsonConvert.SerializeObject(claim);
            JArray jsonArray = JArray.Parse(json);
            foreach (JObject obj in jsonArray)
            {
                string value = obj.GetValue("Value")!.ToString();
                list.Add(value);
            }
            User user = new User
            {
                name = list[1],
                username = list[4],
                password = null,
                email = list[4],
                phone = null
            };
            RestClient restClient = new RestClient(_configuration);
            restClient.endPoint = "User/LoginViaGoogle";
            int kq = restClient.InsertData(user);
            if (kq == 1)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Privacy");
        }
    }
}
