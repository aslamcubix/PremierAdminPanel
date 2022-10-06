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
    public class Statements : ControllerBase
    {
        Database Con = new Database();

        [HttpGet]

     //   public ActionResult<IEnumerable<string>> GetEMP(string Username)
        public ActionResult<IEnumerable<string>> Get()
        {
            Dictionary<string, string> parameter = new Dictionary<string, string>();
            parameter.Add("@mode", "Customer");
            parameter.Add("@p", "");
            parameter.Add("@p1", "");
            DataTable dt = Con.getTableDictionary("[sp_HrDashboard]", true, parameter);

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(dt);
            var jsonA = new JavaScriptSerializer().DeserializeObject(json);

            // return Ok(new { jsonA });

            return Ok(jsonA);
        }

        [Route("{OutStandingAccounts}")]
        [HttpGet]
        public ActionResult<IEnumerable<string>> getempdetails(string Cust, DateTime dateStart, DateTime dateEnd)
        {
            var date_stringFront = dateStart.ToString("MM/dd/yyyy");
            var date_stringEnd = dateEnd.ToString("MM/dd/yyyy");
            Dictionary<string, string> parameter = new Dictionary<string, string>();

            parameter.Add("@mod", "OUT_ACC1");
            parameter.Add("@account", Cust);
            parameter.Add("@grp", "");
            parameter.Add("@dfrm", date_stringFront);
            parameter.Add("@dto", date_stringEnd);
            parameter.Add("@sperson", "");

            DataTable dt = Con.getTableDictionary("[sp_Outstanding]", true, parameter);

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(dt);
            var jsona = new JavaScriptSerializer().DeserializeObject(json);


            return Ok(jsona);
        }

    }
}
