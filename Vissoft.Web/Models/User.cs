namespace Vissoft.Web.Models
{
    public class User
    {
        public string name { get; set; } = null!;
        public string username { get; set; } = null!;
        public string? password { get; set; }
        public string email { get; set; } = null!;
        public string? phone { get; set; }
    }
}
