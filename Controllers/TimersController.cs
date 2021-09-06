using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DwkApi.Controllers
{
    public class TimersController : ApiController
    {


        [Route("api/timers/GetNewPage")]
        [HttpGet]
        public TimerPage[] GetNewPage()
        {
            string connStr = Environment.GetEnvironmentVariable("DWKDBConnectionString");
            using (DWKDBDataContext db = new DWKDBDataContext(connStr))
            {
                return db.InsertNewPage().ToArray();
            }
        }


        [Route("api/timers/GetAllByPage/{id}")]
        [HttpGet]
        public TimerPage[] GetAllByPage(string id)
        {
            string connStr = Environment.GetEnvironmentVariable("DWKDBConnectionString");
            using (DWKDBDataContext db = new DWKDBDataContext(connStr))
            {
                return db.SelectAllByPage(id).ToArray();
            }
        }

    }
}
