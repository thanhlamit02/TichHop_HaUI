using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Models;
namespace API.Controllers
{
    public class DonViController : ApiController
    {
        QLLuongEntities db = new QLLuongEntities();
        [HttpGet]
        public List<DonVi> LayDV()
        {
            return db.DonVis.ToList();
        }
    }
}
