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
    public class ComplainController : ControllerBase
        {
        FormContext formContext;
        IConfiguration _config;
        public ComplainController(FormContext formContextObj, IConfiguration config)
            {
            this.formContext = formContextObj;
            _config = config;
            }

        // GET: api/<ComplainController>
        [HttpGet]
        [Route("GetAllComplain")]
        public List<Complain> GetAllComplain()
            {
            return formContext.complains.ToList() ;
            }


        // POST api/<ComplainController>
        [HttpPost]
        [Route("InsertComplain")]
        public ResponseClass InsertComplain(ComplainInsertion objInsert)
            {
            ResponseClass response = new ResponseClass();
            Complain comp = formContext.complains.Where(row => row.ComplainTitle == objInsert.ComplainTitle).FirstOrDefault();
            
            if(comp == null)
                {
                Complain compObj=new Complain();
                compObj.ComplainTitle = objInsert.ComplainTitle;
                compObj.ComplainDescription = objInsert.ComplainDescription;

                formContext.Add(compObj);
                formContext.SaveChanges();
                response.Result= "Added Successfully";
                response.ObjectData = compObj;
                return response;
                }
            else
                {
                response.Result= "Invalid";
                return response;
                }
            }

        // PUT api/<ComplainController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
            {
            }

        // DELETE api/<ComplainController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
            {
            }
        }
    }
