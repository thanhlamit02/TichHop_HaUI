using Bai1_TX2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bai1_TX2.Controllers
{
    public class DonViController : ApiController
    {
        QLLuongEntities db = new QLLuongEntities();
        [HttpGet]
        public List<DonVi> LayDSDV ()
        {
            return db.DonVis.ToList();
        }
    }
}
