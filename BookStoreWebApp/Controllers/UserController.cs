using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BookStoreWebApp.Data.Models;
using BookStoreWebApp.Integration.IServices;
using BookStoreWebApp.Models;
using BookStoreWebApp.Shared.Helpers;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStoreWebApp.Controllers
{
    
    [Route("api/user")]
    [ApiController]
   
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private IApiUserService _apiUserService;
        private IUserLoginService _userLoginService;
        public IConfiguration _configuration;
        private IApiTokenService _apiTokenService;
        public UserController(IUserService userService, IApiUserService apiUserService, IUserLoginService userLoginService,IConfiguration configuration, IApiTokenService apiTokenService) 
        {
            _userService = userService;
            _apiUserService = apiUserService;
            _userLoginService = userLoginService;
            _configuration = configuration;
            _apiTokenService = apiTokenService;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>

        [Route("~/api/user/RegisterUser")]
        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterModel registerModel)
        {
            string token = "";
            User user = new User();
            user.EmailAddress = registerModel.EmailAddress;
            user.FirstName = registerModel.FirstName;
            user.LastName = registerModel.LastName;
            user.DateCreated = DateTime.Now;
            user.DateModified = DateTime.Now;
            user.Password = EncryptionHash.EncodePasswordToBase64(registerModel.Password);
            _userService.InsertUser(user);
         
            return Ok();
        }
        [Route("~/api/user/RegisterApiUser")]
        [HttpPost]
        public async Task<IActionResult> RegisterApiUser([FromBody] ApiRegistrationModel apiRegistrationModel)
        {
            string token = "";
            ApiUser apiUser = new ApiUser();
            // apiUser.DateCreated = DateTime.Now.;
            apiUser.DateModified = DateTime.Now;
            apiUser.EmailAddress = apiRegistrationModel.EmailAddress;
            apiUser.Password = EncryptionHash.EncodePasswordToBase64(apiRegistrationModel.Password);
            _apiUserService.InsertApiUser(apiUser);
            ApiUser existingUser = _apiUserService.GetApiUserByEmail(apiUser.EmailAddress);
            GenerateToken generateToken = new GenerateToken();
            token = generateToken.GenerateJSONWebToken(existingUser.Id.ToString(), existingUser.EmailAddress);
            return Ok(new TokenResponse
            {
                Token = token
            });
            //create claims details based on the user information

        }
     
        [Route("~/api/user/Login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            string token = "";
          User existingUser =   _userService.GetUserByEmail(loginModel.EmailAddress);
            if(existingUser != null)
            {
                if(EncryptionHash.EncodePasswordToBase64(loginModel.Password) == existingUser.Password)
                {
                    GenerateToken generateToken= new GenerateToken();
                    UserLogin userLogin = new UserLogin();
                    userLogin.UserId = existingUser.Id;
                    userLogin.DateCreated = DateTime.Now;
                    userLogin.DateModified = DateTime.Now;
                    _userLoginService.InsertUserLogin(userLogin);
                    HttpContext.Session.SetInt32("userId", (int)existingUser.Id);
                    token = generateToken.GenerateJSONWebToken(existingUser.Id.ToString(), existingUser.EmailAddress);
                    return Ok(new TokenResponse
                    {
                        Token = token
                    });
                }
                return BadRequest("Password does not match");
            }
            else
            {
                return BadRequest("Invalid User Request");
            }
         
        }
      
        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
