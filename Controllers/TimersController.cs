using System;
using System.Linq;
using System.Web.Http;
using TimerToysShared.Model;

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


        [Route("api/timers/UpdatePageName")]
        [HttpPost]
        public void UpdatePageName(Timer tmr)
        {
            string connStr = Environment.GetEnvironmentVariable("DWKDBConnectionString");
            using (DWKDBDataContext db = new DWKDBDataContext(connStr))
            {
                db.UpdatePageName(tmr.PageKey, tmr.PageName);
            }
        }


        [Route("api/timers/UpdateTimerName")]
        [HttpPost]
        public void UpdateTimerName(Timer tmr)
        {
            string connStr = Environment.GetEnvironmentVariable("DWKDBConnectionString");
            using (DWKDBDataContext db = new DWKDBDataContext(connStr))
            {
                var result = db.UpdateTimerName(tmr.TimerKey, tmr.TimerDescription);
            }
        }


        [Route("api/timers/ToggleTimer/{id}")]
        [HttpGet]
        public TimerPage ToggleTimer(string id)
        {
            string connStr = Environment.GetEnvironmentVariable("DWKDBConnectionString");
            using (DWKDBDataContext db = new DWKDBDataContext(connStr))
            {
                return db.ToggleTimer(id).SingleOrDefault();
            }
        }


        [Route("api/timers/AdjustTimer")]
        [HttpPost]
        public TimerPage AdjustTimer(Timer tmr)
        {
            string connStr = Environment.GetEnvironmentVariable("DWKDBConnectionString");
            using (DWKDBDataContext db = new DWKDBDataContext(connStr))
            {
                var result = db.AdjustTimer(tmr.TimerKey, tmr.ElapsedTime).SingleOrDefault();
                return result;
            }
        }

        [Route("api/timers/AddTimer")]
        [HttpPost]
        public TimerPage AddTimer(Timer tmr)
        {
            string connStr = Environment.GetEnvironmentVariable("DWKDBConnectionString");
            using (DWKDBDataContext db = new DWKDBDataContext(connStr))
            {
                var result = db.InsertNewTimer(tmr.PageKey).SingleOrDefault();
                return result;
            }
        }

    }
}
