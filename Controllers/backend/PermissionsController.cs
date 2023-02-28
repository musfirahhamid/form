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
    public class PermissionsController : ControllerBase
        {

        FormContext formContext;
        IConfiguration _config;
        public PermissionsController(FormContext formContextObj, IConfiguration config)
            {
            this.formContext = formContextObj;
            _config = config;
            }

        // GET: api/<PermissionsController>
        [HttpGet]
        [Route("GetAllData")]
        public List<Permissions> GetAllData()
            {
            return formContext.permissions.Where(row=>row.status==true).ToList();
            }


        // POST api/<PermissionsController> URL
        //[HttpPost]
        //[Route("AddUrl")]
        //public string AddURL(string url)
        //    {
        //    //var context = new ContextClass();
        //    var websiteURL = new Permissions { URL = url };
        //    websiteURL.Title = "hello";
        //    classContext.permissions.Add(websiteURL);
        //    classContext.SaveChanges();
        //    return "ADDed";

        //    }


        [HttpPost]
        [Route("InsertPermission")]
        public ResponseClass InsertPermission(PermissionInsertion permissionObject)
            {

            ResponseClass response = new ResponseClass();

            Permissions permission = formContext.permissions.Where(row => row.URL == permissionObject.URL  && row.status == true).FirstOrDefault();
            if(permission == null)
                {
                Permissions permissionObj = new Permissions();
                permissionObj.Title = permissionObject.Title;
                permissionObj.URL = permissionObject.URL;
                permissionObj.status = true;
                formContext.Add(permissionObj);
                formContext.SaveChanges();
                response.Result = "Inserted Successfully";
                response.ObjectData = permissionObj;
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
        [Route("UpdatePermission")]
        public ResponseClass UpdatePermission(PermissionUpdation updationObject)
            {

            ResponseClass response = new ResponseClass();

            Permissions permission = formContext.permissions.Where(row => row.Id == updationObject.Id).FirstOrDefault();
            if(permission == null)
                {
                response.Result = "Invalid";
                return response;
                }
            else
                {

                permission.Title = updationObject.Title;
                permission.URL = updationObject.URL;
                permission.status = true;
                formContext.permissions.Update(permission);
                formContext.SaveChanges();
                response.Result = "Updated Successfully";
                response.ObjectData = permission;
                return response;
                }

            }


        // DELETE api/<PermissionsController>/5
        [HttpDelete]
        [Route("DeletePermission")]
        public ResponseClass DeletePermission(PermissionDeletion deletionObject)
            {

            ResponseClass response = new ResponseClass();

            Permissions permission = formContext.permissions.Where(row => row.Id == deletionObject.Id).FirstOrDefault();
            if(permission == null)
                {
                response.Result = "Invalid";
                return response;
                }
            else
                {
                permission.status = false;
                formContext.permissions.Update(permission);
                formContext.SaveChanges();
                response.Result = "Deleted Successfully";
                response.ObjectData = permission;
                return response;
                }

            }

        }
    }
