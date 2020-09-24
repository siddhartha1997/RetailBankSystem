using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AuthenticateMicroservices.Model;
using AuthenticateMicroservices.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AuthenticateMicroservices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        /*public static List<User> userList = new List<User>
        {
            new User{UserId=1,Password="1234",Roles="Employee"},
            new User{UserId=2,Password="12345",Roles="Customer"}
        };*/
        private IConfiguration _config;
        readonly log4net.ILog _log4net;
        public TokenController(IConfiguration config)
        {
            _config = config;
            _log4net = log4net.LogManager.GetLogger(typeof(TokenController));
        }
        [HttpPost]
        public IActionResult Post([FromBody] User u)
        {
            _log4net.Info("Login method generated");
            IActionResult response = Unauthorized();
            var au = AuthenticateUser(u);
            /*UserListRep uL = new UserListRep();
            var userList = uL.getUserList();*/
            /*foreach (var v in userList)
            {
                if (u.UserId ==  v.UserId && u.Password == v.Password)
                {*/
            if (au != null)
            {
                string role = "";
                if (au.Roles == "Employee")
                    role = "Employee";
                else
                    role = "Customer";
                string tokenString = GenerateJSONWebToken(au.UserId, role);
                response = Ok(new { token = tokenString });
                _log4net.Info("Token Generated");
            }
            return response;
        }
        private string GenerateJSONWebToken(int userId, string userRole)
        {
            _log4net.Info("Token Generation Initiated");
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mysuperdupersecret"));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {

                new Claim(ClaimTypes.Role, userRole),

                new Claim("UserId", userId.ToString())

            };

            var token = new JwtSecurityToken(

            issuer: "mySystem",

            audience: "myUsers",

            claims: claims,

            expires: DateTime.Now.AddMinutes(10),

            signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
        public User AuthenticateUser(User login)
        {
            User user = null;
            UserListRep uL = new UserListRep();
            var userList = uL.getUserList();
            foreach (var v in userList)
            {
                if (login.UserId == v.UserId && login.Password == v.Password)
                {
                    user = new User { UserId = login.UserId, Password = login.Password, Roles = login.Roles };
                }
            }
            return user;
        }
    }
}
