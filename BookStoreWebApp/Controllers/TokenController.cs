using Microsoft.AspNetCore.Mvc;
using BookStoreWebApp.Integration.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStoreWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        private IApiTokenService _apiTokenService;
        public TokenController(IApiTokenService apiTokenService, IConfiguration configuration) 
        {
            _apiTokenService = apiTokenService;
            _configuration = configuration;
        }
        // GET: api/<TokenController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TokenController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TokenController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TokenController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TokenController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
