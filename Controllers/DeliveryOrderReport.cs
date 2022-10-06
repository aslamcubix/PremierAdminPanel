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
    public class DeliveryOrderReport : ControllerBase
    {
        Database Con = new Database();
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetFavourite(DateTime dateStart, DateTime dateEnd)
        {
            //DateTime date = DateTime.ParseExact(dateStart, "dd/MM/yyyy", null);
            var date_stringFront = dateStart.ToString("MM/dd/yyyy");
            var date_stringEnd = dateEnd.ToString("MM/dd/yyyy");

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@opmod", "DELIVERYLIST");
            parameters.Add("@p1", "");
            parameters.Add("@p2", "");
            parameters.Add("@dfrm", date_stringFront); //DateTime.Parse(dateInput);
            parameters.Add("@dto", date_stringEnd);
            parameters.Add("@p3", "");
            parameters.Add("@categ", "");
            parameters.Add("@grp", "");
            parameters.Add("@deptno", "");// Branch);

            DataTable dt = Con.getTableDictionary("[sp_DeliveryOrder_analysis]", true, parameters);
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(dt);
            var result = new ObjectResult(json);
            return result;
        }

        [Route("{DOINVOICED}")]
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetDOinv(DateTime dateStart, DateTime dateEnd)
        {
            //DateTime date = DateTime.ParseExact(dateStart, "dd/MM/yyyy", null);
            var date_stringFront = dateStart.ToString("MM/dd/yyyy");
            var date_stringEnd = dateEnd.ToString("MM/dd/yyyy");

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@opmod", "DOINVOICED");
            parameters.Add("@p1", "");
            parameters.Add("@p2", "");
            parameters.Add("@dfrm", date_stringFront); //DateTime.Parse(dateInput);
            parameters.Add("@dto", date_stringEnd);
            parameters.Add("@p3", "");
            parameters.Add("@categ", "");
            parameters.Add("@grp", "");
            parameters.Add("@deptno", "");// Branch);

            DataTable dt = Con.getTableDictionary("[sp_DeliveryOrder_analysis]", true, parameters);
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(dt);
            var result = new ObjectResult(json);
            return result;
        }

        [Route("{DOReport}/{DOPENDING}")]
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get(DateTime dateStart, DateTime dateEnd)
        {
            //DateTime date = DateTime.ParseExact(dateStart, "dd/MM/yyyy", null);
            var date_stringFront = dateStart.ToString("MM/dd/yyyy");
            var date_stringEnd = dateEnd.ToString("MM/dd/yyyy");

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@opmod", "DOPENDING");
            parameters.Add("@p1", "");
            parameters.Add("@p2", "");
            parameters.Add("@dfrm", date_stringFront); //DateTime.Parse(dateInput);
            parameters.Add("@dto", date_stringEnd);
            parameters.Add("@p3", "");
            parameters.Add("@categ", "");
            parameters.Add("@grp", "");
            parameters.Add("@deptno", "");// Branch);

            DataTable dt = Con.getTableDictionary("[sp_DeliveryOrder_analysis]", true, parameters);
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(dt);
            var result = new ObjectResult(json);
            return result;
        }


        [Route("{DOReport}/{DOPENDING}/{ITEM}")]
        [HttpGet]
        public ActionResult<IEnumerable<string>> Getpending(DateTime dateStart, DateTime dateEnd)
        {
            //DateTime date = DateTime.ParseExact(dateStart, "dd/MM/yyyy", null);
            var date_stringFront = dateStart.ToString("MM/dd/yyyy");
            var date_stringEnd = dateEnd.ToString("MM/dd/yyyy");

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@opmod", "DOPENDINGITEM");
            parameters.Add("@p1", "");
            parameters.Add("@p2", "");
            parameters.Add("@dfrm", date_stringFront); //DateTime.Parse(dateInput);
            parameters.Add("@dto", date_stringEnd);
            parameters.Add("@p3", "");
            parameters.Add("@categ", "");
            parameters.Add("@grp", "");
            parameters.Add("@deptno", "");// Branch);

            DataTable dt = Con.getTableDictionary("[sp_DeliveryOrder_analysis]", true, parameters);
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(dt);
            var result = new ObjectResult(json);
            return result;
        }
        [Route("{DO}/{DOREPORT}/{ITEM}/{Group}")]
        [HttpGet]
        public ActionResult<IEnumerable<string>> Getmastergrp()
        {
            //DateTime date = DateTime.ParseExact(dateStart, "dd/MM/yyyy", null);
            

            Dictionary<string, string> parameter = new Dictionary<string, string>();
            parameter.Add("@mode", "GroupDropDown");
            parameter.Add("@p", "");
            parameter.Add("@p1", "");
            DataTable dt = Con.getTableDictionary("[sp_HrDashboard]", true, parameter);

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(dt);
            var jsonA = new JavaScriptSerializer().DeserializeObject(json);

            // return Ok(new { jsonA });

            return Ok(jsonA);

            
        }
    }
}
