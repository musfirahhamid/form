using form.Models;
using form.Models.viewModel;
using form.tblClass;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace form.Controllers.backend
    {
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleAssignmentController : ControllerBase
        {

        FormContext formContext;
        IConfiguration _config;
        public RoleAssignmentController(FormContext formContextObj, IConfiguration config)
            {
            this.formContext = formContextObj;
            _config = config;
            }

        // GET: api/<RoleAssignmentController>
        [HttpGet]
        [Route("GetAllRoleAssignment")]
        public List<RoleAssignment> GetAllRoleAssignment()
            {
            return formContext.roleAssignments.ToList();
            }

        // GET api/<RoleAssignmentController>/5
        [HttpGet]
        [Route("GetAllRole")]
        public List<AssignmentData> GetAllRole()
            {
            List<AssignmentData> assignmentData = (from RoleAssignment in formContext.roleAssignments
                                                   join UserRole in formContext.userRoles
                                                   on RoleAssignment.idUser equals UserRole.UserId
                                                   join Permission in formContext.permissions
                                                   on RoleAssignment.idPermission equals Permission.Id
                                                   
                                                   select new AssignmentData
                                                       {
                                                       AssignmentId = RoleAssignment.AssignmentId,
                                                       idUser = UserRole.UserId,
                                                       UserTitle = UserRole.UserTitle,
                                                       idPermission = Permission.Id,
                                                       Title = Permission.Title,
                                                       URL = Permission.URL,
                                                       status = RoleAssignment.status,
                                                       }).Where(row => row.status == true).ToList();
            return assignmentData;
            }

        // POST api/<RoleAssignmentController>
        [HttpPost]
        [Route("InsertUserRole")]
        public ResponseClass InsertUserRole(AssignmentInsertion userObject)
            {

            ResponseClass response = new ResponseClass();

            RoleAssignment userrole = formContext.roleAssignments.Where(row => row.idUser == userObject.idUser && row.idPermission == userObject.idPermission && row.status==true).FirstOrDefault();
            if(userrole == null)
                {
                RoleAssignment role = new RoleAssignment();
                role.idUser = userObject.idUser;
                role.idPermission = userObject.idPermission;

                role.status = true;

                formContext.Add(role);
                formContext.SaveChanges();
                response.Result = "Inserted Successfully";
                response.ObjectData = role;
                return response;
                }
            else
                {
                response.Result = "Already Found";
                return response;
                }

            }

        // PUT api/<RoleAssignmentController>/5
        [HttpPut]
        [Route("UpdateUserRole")]
        public ResponseClass UpdateUserRole(AssignmentUpdation userUpdateObject)
            {

            ResponseClass response = new ResponseClass();


            RoleAssignment userrole = formContext.roleAssignments.Where(row => row.AssignmentId== userUpdateObject.AssignmentId ).FirstOrDefault();
            if(userrole == null)
                {
                response.Result = "Not Found";
                return response;
                }
            else
                {
                userrole.idUser = userUpdateObject.idUser;
                userrole.idPermission = userUpdateObject.idPermission;

                userrole.status = true;

                formContext.roleAssignments.Update(userrole);
                formContext.SaveChanges();
                response.Result = "Updated Successfully";
                response.ObjectData = userrole;
                return response;
                }

            }

        // DELETE api/<RoleAssignmentController>/5
        [HttpDelete]
        [Route("DeleteUserRole")]
        public ResponseClass DeleteUserRole(AssignmentUpdation userUpdateObject)
            {

            ResponseClass response = new ResponseClass();


            RoleAssignment userrole = formContext.roleAssignments.Where(row => row.AssignmentId == userUpdateObject.AssignmentId).FirstOrDefault();
            if(userrole == null)
                {
                response.Result = "Not Found";
                return response;
                }
            else
                {
               

                userrole.status = false;

                formContext.roleAssignments.Update(userrole);
                formContext.SaveChanges();
                response.Result = "Deleted Successfully";
                response.ObjectData = userrole;
                return response;
                }

            }
        }
    }
