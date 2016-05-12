using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json.Linq;

namespace TaskTopTfsMapper.WebApp.Controllers
{
    [RoutePrefix("")]
    public class TaskTopController : ApiController
    {
        [HttpPost]
        [Route("")]
        public async Task<HttpResponseMessage> Post()
        {
            var jsonString = await Request.Content.ReadAsStringAsync();
            var token = JObject.Parse(jsonString);
            var uri = "http://louwebwts388:8080/api/v1/artifacts/";

            var stringContent = new StringContent(
                @"{""subscriptionid"" : ""String""}");
            var httpClient = new HttpClient();
            var response = await httpClient.PostAsync(uri, stringContent);

            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}