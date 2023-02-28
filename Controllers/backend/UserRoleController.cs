using form.Models;
using form.tblClass;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace form.Controllers.backend
    {
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
        {

        FormContext formContext;
        IConfiguration _config;
        public UserRoleController(FormContext formContextObj, IConfiguration config)
            {
            this.formContext = formContextObj;
            _config = config;
            }

        // GET: api/<UserRoleController>
        [HttpGet]
        [Route("GetAllUser")]
        public List<UserRole> GetAllUser()
            {
            return formContext.userRoles.Where(row=>row.status==true).ToList();
            }

        

        // POST api/<UserRoleController>
        [HttpPost]
        [Route("InsertUserRole")]
        public ResponseClass InsertUserRole(UserInsertion userObject)
            {

            ResponseClass response = new ResponseClass();

            UserRole userrole = formContext.userRoles.Where(row => row.UserTitle == userObject.UserTitle && row.status == true).FirstOrDefault();
            if(userrole == null)
                {
                UserRole user = new UserRole();
                user.UserTitle = userObject.UserTitle;
                user.status = true;

                formContext.Add(user);
                formContext.SaveChanges();
                response.Result = "Inserted Successfully";
                response.ObjectData = user;
                return response;
                }
            else
                {
                response.Result = "Invalid";
                return response;
                }

            }

        // PUT api/<PermissionsController>/5
        [HttpPut]
        [Route("UpdateUserRole")]
        public ResponseClass UpdateUserRole(UserUpdation updationObject)
            {

            ResponseClass response = new ResponseClass();

            UserRole userObj = formContext.userRoles.Where(row => row.UserId == updationObject.UserId ).FirstOrDefault();
            if(userObj == null)
                {
                response.Result = "User Already Exist";
                return response;

                }
            else
                {
               
                userObj.UserTitle = updationObject.UserTitle;
                userObj.status = true;

                formContext.userRoles.Update(userObj);
                formContext.SaveChanges();
                response.Result = "Updated Successfully";
                response.ObjectData = userObj;
                return response;
                }

            }

        // DELETE api/<PermissionsController>/5
        [HttpDelete]
        [Route("DeleteUserRole")]
        public ResponseClass DeleteUserRole(UserDeletion deletionObject)
            {

            ResponseClass response = new ResponseClass();

            UserRole userObj = formContext.userRoles.Where(row => row.UserId == deletionObject.UserId).FirstOrDefault();
            if(userObj == null)
                {
                response.Result = "Invalid";
                return response;
                }
            else
                {
                userObj.status = false;

                formContext.userRoles.Update(userObj);
                formContext.SaveChanges();
                response.Result = "Deleted Successfully";
                response.ObjectData = userObj;
                return response;
                }

            }
        }
    }
