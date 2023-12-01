using Newtonsoft.Json;
using System.Text;

namespace Vissoft.Web.Models
{
    public class RestClient
    {
        public string BaseUrl { get; set; }
        public string? endPoint { get; set; }
        public RestClient(IConfiguration configuration)
        {
            BaseUrl = configuration.GetSection("BaseUrl").Value!;
        }
        public string? RestRequestAll()
        {
            string? strRespoineValue;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);
            HttpResponseMessage response = client.GetAsync(endPoint).Result;
            if (response.IsSuccessStatusCode)
            {
                strRespoineValue = response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                strRespoineValue = null;
            }
            return strRespoineValue;
        }

        public string? InsertData()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);
            HttpContent c = new StringContent("", Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(endPoint, c).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result; ;
            }
            else { return null; }
        }

        public int InsertData(Object obj)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);
            string postBody = JsonConvert.SerializeObject(obj);
            HttpContent c = new StringContent(postBody, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(endPoint, c).Result;
            if (response.IsSuccessStatusCode)
            {
                return 1;
            }
            else { return 0; }
        }
        public int UpdateData()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);
            HttpContent c = new StringContent("", Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(endPoint, c).Result;
            if (response.IsSuccessStatusCode)
            {
                return 1;
            }
            else { return 0; }
        }

        public int UpdateData(Object obj)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);
            string postBody = JsonConvert.SerializeObject(obj);
            HttpContent c = new StringContent(postBody, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(endPoint, c).Result;
            if (response.IsSuccessStatusCode)
            {
                return 1;
            }
            else { return 0; }
        }
        public int DeleteData()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);
            HttpResponseMessage response = client.DeleteAsync(endPoint).Result;
            if (response.IsSuccessStatusCode)
            {
                return 1;
            }
            else { return 0; }
        }

        public int DeleteData(Object obj)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);
            string postBody = JsonConvert.SerializeObject(obj);
            HttpResponseMessage response = client.DeleteAsync(endPoint).Result;
            if (response.IsSuccessStatusCode)
            {
                return 1;
            }
            else { return 0; }
        }
    }
}
