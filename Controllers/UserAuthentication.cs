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
    public class UserAuthentication : ControllerBase
    {

        Database Con = new Database();
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get(string Publickey, string privatekey)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@mod", "Authen");
            parameters.Add("@Username", Publickey);
            parameters.Add("@password", privatekey);
            DataTable dt = Con.getTableDictionary("[Sp_Userlogin]", true, parameters);

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(dt);
            
            var jsonA = new JavaScriptSerializer().DeserializeObject(json);
            
            return Ok(new { jsonA });

        }


        [Route("{Publickey}/{privatekey}")]
        [HttpGet]
        public ActionResult<IEnumerable<string>> Getvalid(string Publickey, string privatekey)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@mod", "ValidUpd");
            parameters.Add("@Username", Publickey);
            parameters.Add("@password", privatekey);
            DataTable dt = Con.getTableDictionary("[Sp_Userlogin]", true, parameters);

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(dt);

            var jsonA = new JavaScriptSerializer().DeserializeObject(json);

            return Ok(new { jsonA });

        }


    }
}
