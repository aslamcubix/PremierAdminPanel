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
    public class Loginuser : ControllerBase
    {
        Database Con = new Database();

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get(string user, string pass)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@mod", "Log");
            parameters.Add("@Username", user);
            parameters.Add("@password", pass);
            DataTable dt = Con.getTableDictionary("[Sp_Userlogin]", true, parameters);
            // var result = new ObjectResult(dt); 

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(dt);
           // var result = new ObjectResult(json);
            var jsonA = new JavaScriptSerializer().DeserializeObject(json);
            // return result;



            Dictionary<string, string> parameters1 = new Dictionary<string, string>();
            parameters1.Add("@opmod", "Department");
            parameters1.Add("@dfrm", "");
            parameters1.Add("@dto", "");
            DataTable dt1 = Con.getTableDictionary("[sp_Sales_Department]", true, parameters1);


            var json1 = Newtonsoft.Json.JsonConvert.SerializeObject(dt1);
            //var result = new ObjectResult(json);
            var jsonw = new JavaScriptSerializer().DeserializeObject(json1);

            Dictionary<string, string> parameters2 = new Dictionary<string, string>();
            parameters2.Add("@opmod", "Allowdept");
            parameters2.Add("@dfrm", "");
            parameters2.Add("@dto", "");
            DataTable dt2 = Con.getTableDictionary("[sp_Sales_Department]", true, parameters2);


            var json2 = Newtonsoft.Json.JsonConvert.SerializeObject(dt2);
            //var result = new ObjectResult(json);
            var jsony = new JavaScriptSerializer().DeserializeObject(json2);


            return Ok(new { jsonA, jsonw, jsony });






        }



    }
}
