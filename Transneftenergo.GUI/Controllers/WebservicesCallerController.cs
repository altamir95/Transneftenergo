using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;


namespace Transneftenergo.GUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebservicesCallerController : ControllerBase
    {
        private HttpClient _client { get; set; }
        private string _url { get; set; }

        public WebservicesCallerController(HttpClient client)
        {
            _client = client;
            _url = "https://localhost:8050/";
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(string path)
        {
            HttpResponseMessage response = await _client.GetAsync(_url + path);
            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }
            return new ObjectResult(response.Content);
        }
    }
}
