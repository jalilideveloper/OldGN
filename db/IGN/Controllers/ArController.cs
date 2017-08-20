using IGN.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IGN.Controllers
{
    public class ArController : Controller
    {
        // GET: Ar
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexDetails(int id)
        {
            using (greenopt_IgNewsEntities db = new greenopt_IgNewsEntities())
            {
                List<tblMagazine> q = (from i in db.tblMagazines
                                       where i.MenuID == id
                                       select i).ToList();
                ViewData["MagazineSelected"] = q;
            }


            return View("Index");
        }


        public ActionResult Detail(int id)
        {

            return View();
        }

        public ActionResult Sports()
        {
            return View();
        }
    }
}