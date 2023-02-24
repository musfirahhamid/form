using form.Helper;
using form.Models;
using form.tblClass;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace form.Controllers.backend
    {
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
        {

        FormContext formContext;
        IConfiguration _config;
        public RegisterController(FormContext formContextObj, IConfiguration config)
            {
            this.formContext = formContextObj;
            _config = config;
            }


        // GET: api/<RegisterController>
        [HttpGet]
        [Route("GetAllData")]
        public List<Registration> GetAllData()
            {
            return formContext.registration.Where(row=>row.Status==true).ToList();
            }

        [HttpGet]
        [Route("GetLoginInfo")]
        public string GetLoginInfo()
            {
            string data = GetToken.GetTokenValue(User, "UserEmail");
            data += " id : " + GetToken.GetTokenValue(User, "UserId");
            return data;
            }

        //Generate JSON web token using JWT
        private string GenerateJSONWebToken(Registration loginInfo)
            {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
        new Claim("UserEmail", loginInfo.UserEmail),
       new Claim("UserId", loginInfo.UserId.ToString()),
     
        //new Claim("Password", userInfo.Password)
    };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
            }

        //Get Login Info token Data
        [AllowAnonymous]
        [HttpPost]
        [Route("GetLoginToken")]
        public ResponseClass GetLoginToken(Login loginInfo)
            {
            ResponseClass response = new ResponseClass();
            Registration regInfo= formContext.registration.Where(row=>row.UserEmail==loginInfo.UserEmail && row.UserPassword==loginInfo.UserPassword).FirstOrDefault();
            
            if(regInfo != null)
                {
                response.Result = "Logged In Successfully";
                response.ObjectData = GenerateJSONWebToken(regInfo);
                return response;
                }
            else
                {
                response.Result = "Invalid Credentials";
                return response;
                }
            }

        // POST api/<RegisterController>
        [AllowAnonymous]
        [HttpPost]
        [Route("SignUpData")]
        public ResponseClass SignUpData(SignUpInsertion dataInsertionobj)
            {
            ResponseClass response=new ResponseClass();
            Registration reg=formContext.registration.Where(row=>row.UserEmail==dataInsertionobj.UserEmail).FirstOrDefault();
            if(reg == null)
                {
                Registration regObj = new Registration();

                regObj.UserName = dataInsertionobj.UserName;
                regObj.UserEmail = dataInsertionobj.UserEmail;
                regObj.UserContact = dataInsertionobj.UserContact;
                regObj.UserPassword = dataInsertionobj.UserPassword;
                regObj.Status = true;

                formContext.Add(regObj);
                formContext.SaveChanges();
                response.Result = "Added Successfully";
                response.ObjectData=regObj;
                return response;
                }
            else
                {
                response.Result = "Invalid";
                return response;
                }
            }

        // PUT api/<RegisterController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
            {
            }

        // DELETE api/<RegisterController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
            {
            }
        }
    }
