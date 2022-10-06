using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using Premier_AdminPanel.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Premier_AdminPanel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDetails : ControllerBase
    {
        Database Con = new Database();

        [HttpGet]
         public ActionResult<IEnumerable<string>> GetEMP(string Username)
         {
            Dictionary<string, string> parameter = new Dictionary<string, string>();
            parameter.Add("@mode", "Emp");
            parameter.Add("@p", Username);
            parameter.Add("@p1","");
            DataTable dt = Con.getTableDictionary("[sp_HrDashboard]", true,parameter);

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(dt);
            var jsonA = new JavaScriptSerializer().DeserializeObject(json);

           // return Ok(new { jsonA });

            return Ok(jsonA); 
         }

        [Route("{LeaveDetails}")]
        [HttpGet]
        public ActionResult<IEnumerable<string>> getempdetails(string Username)
        {
            Dictionary<string, string> parameter = new Dictionary<string, string>();
            
            parameter.Add("@mode", "Leave");
            parameter.Add("@p", Username);
            parameter.Add("@p1", "");
            DataTable dt = Con.getTableDictionary("[sp_HrDashboard]", true, parameter);

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(dt);
            var jsona = new JavaScriptSerializer().DeserializeObject(json);


            return Ok(jsona);
        }

    }
}
