using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class DonViController : ApiController
    {
        QLLuong2Entities db = new QLLuong2Entities();
        [HttpGet]
        public List<DonVi> LayDV()
        {
            return db.DonVis.ToList();
        }
    }
}
