using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bai1.Models;
namespace Bai1.Controllers
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
