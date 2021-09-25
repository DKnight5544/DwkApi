using System;
using System.Linq;
using System.Web.Http;
using DwkApi.TT2.Models;

namespace DwkApi.Controllers
{
    public class TT2Controller : ApiController
    {


        [Route("api/TT2/AddRootTimer")]
        [HttpGet]
        public TimerModel AddRootTimer()
        {
            string connStr = Environment.GetEnvironmentVariable("DWKDBConnectionString");
            using (TT2DataContext tt2 = new TT2DataContext())
            {
                return tt2.AddRootTimer().SingleOrDefault();
            }
        }

        [Route("api/TT2/AddTimer/{id}")]
        [HttpGet]
        public TimerModel AddTimer(string id)
        {
            string connStr = Environment.GetEnvironmentVariable("DWKDBConnectionString");
            using (TT2DataContext tt2 = new TT2DataContext())
            {
                return tt2.AddTimer(id).SingleOrDefault();
            }
        }

        [Route("api/TT2/GetTimer/{id}")]
        [HttpGet]
        public TimerModel GetTimer(string id)
        {
            string connStr = Environment.GetEnvironmentVariable("DWKDBConnectionString");
            using (TT2DataContext tt2 = new TT2DataContext())
            {
                return tt2.GetTimer(id).SingleOrDefault();
            }
        }

        [Route("api/TT2/GetChildren/{id}")]
        [HttpGet]
        public TimerModel[] GetChildren(string id)
        {
            string connStr = Environment.GetEnvironmentVariable("DWKDBConnectionString");
            using (TT2DataContext tt2 = new TT2DataContext())
            {
                return tt2.GetChildren(id).ToArray();
            }
        }


        [Route("api/TT2/ToggleTimer/{id}")]
        [HttpGet]
        public TimerModel ToggleTimer(string id)
        {
            string connStr = Environment.GetEnvironmentVariable("DWKDBConnectionString");
            using (TT2DataContext tt2 = new TT2DataContext())
            {
                return tt2.ToggleTimer(id).SingleOrDefault();
            }
        }

        [Route("api/TT2/AdjustTimer/{id}")]
        [HttpPost]
        public TimerModel AdjustTimer(AdjustParms parms)
        {
            string connStr = Environment.GetEnvironmentVariable("DWKDBConnectionString");
            using (TT2DataContext tt2 = new TT2DataContext())
            {
                return tt2.AdjustTimer(parms.TimerKey, parms.SecondsOffset).SingleOrDefault();
            }
        }

        //[Route("api/TT2/DeleteTimer/{id}")]
        //[HttpGet]
        //public void AdjustTimer(AdjustParms parms)
        //{
        //    string connStr = Environment.GetEnvironmentVariable("DWKDBConnectionString");
        //    using (TT2DataContext tt2 = new TT2DataContext())
        //    {
        //        return tt2.AdjustTimer(parms.TimerKey, parms.SecondsOffset).SingleOrDefault();
        //    }
        //}





    }
}
