using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class SalesAnalysis : ControllerBase
    {
        Database db = new Database();

        [HttpGet]
        public ActionResult<IEnumerable<string>> GetFavourite( DateTime dateStart, DateTime dateEnd)
        {
            //DateTime date = DateTime.ParseExact(dateStart, "dd/MM/yyyy", null);
            var date_stringFront = dateStart.ToString("MM/dd/yyyy");
            var date_stringEnd = dateEnd.ToString("MM/dd/yyyy");

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@opmod", "SALES_DEPT");
            parameters.Add("@p1", "");
            parameters.Add("@p2", "");
            parameters.Add("@dfrm", date_stringFront); //DateTime.Parse(dateInput);
            parameters.Add("@dto", date_stringEnd);
            parameters.Add("@p3", "");
            parameters.Add("@categ", "");
            parameters.Add("@grp", "");
            parameters.Add("@deptno","");// Branch);
            parameters.Add("@accno", "");
            parameters.Add("@sgrp", "");
            parameters.Add("@cntry", "");
            parameters.Add("@area", "");
            parameters.Add("@columnname1", "");
            parameters.Add("@columnname2", "");
            parameters.Add("@Salesman", "");
            parameters.Add("@item", "");
            DataTable dt = db.getTableDictionary("[sp_Sales_analysis]", true, parameters);
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(dt);
            var result = new ObjectResult(json);
            return result;
        }

        [Route("{SalesGroup}")]
        [HttpGet]
        public ActionResult<IEnumerable<string>> Getgroupwise(DateTime dateStart, DateTime dateEnd)
        {
            //DateTime date = DateTime.ParseExact(dateStart, "dd/MM/yyyy", null);
            var date_stringFront = dateStart.ToString("MM/dd/yyyy");
            var date_stringEnd = dateEnd.ToString("MM/dd/yyyy");

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@opmod", "SALES_DEPT_GROUP");
            parameters.Add("@p1", "");
            parameters.Add("@p2", "");
            parameters.Add("@dfrm", date_stringFront); //DateTime.Parse(dateInput);
            parameters.Add("@dto", date_stringEnd);
            parameters.Add("@p3", "");
            parameters.Add("@categ", "");
            parameters.Add("@grp", "");
            parameters.Add("@deptno", "");// Branch);
            parameters.Add("@accno", "");
            parameters.Add("@sgrp", "");
            parameters.Add("@cntry", "");
            parameters.Add("@area", "");
            parameters.Add("@columnname1", "");
            parameters.Add("@columnname2", "");
            parameters.Add("@Salesman", "");
            parameters.Add("@item", "");
            DataTable dt = db.getTableDictionary("[sp_Sales_analysis]", true, parameters);
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(dt);
            var result = new ObjectResult(json);
            return result;
        }

        [Route("{Sales}/{Salesman}")]
        [HttpGet]
        public ActionResult<IEnumerable<string>> Getsalesman(DateTime dateStart, DateTime dateEnd)
        {
            //DateTime date = DateTime.ParseExact(dateStart, "dd/MM/yyyy", null);
            var date_stringFront = dateStart.ToString("MM/dd/yyyy");
            var date_stringEnd = dateEnd.ToString("MM/dd/yyyy");

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@opmod", "SALES_SALESMAN");
            parameters.Add("@p1", "");
            parameters.Add("@p2", "");
            parameters.Add("@dfrm", date_stringFront); //DateTime.Parse(dateInput);
            parameters.Add("@dto", date_stringEnd);
            parameters.Add("@p3", "");
            parameters.Add("@categ", "");
            parameters.Add("@grp", "");
            parameters.Add("@deptno", "");// Branch);
            parameters.Add("@accno", "");
            parameters.Add("@sgrp", "");
            parameters.Add("@cntry", "");
            parameters.Add("@area", "");
            parameters.Add("@columnname1", "");
            parameters.Add("@columnname2", "");
            parameters.Add("@Salesman", "");
            parameters.Add("@item", "");
            DataTable dt = db.getTableDictionary("[sp_Sales_analysis]", true, parameters);
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(dt);
            var result = new ObjectResult(json);
            return result;
        }

    }
}
