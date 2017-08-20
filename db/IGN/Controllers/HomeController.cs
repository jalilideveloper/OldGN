using IGN.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IGN.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult CategorySelected(string id)
        {
            using (greenopt_IgNewsEntities db = new greenopt_IgNewsEntities())
            {

                id = id.Replace('-', ' ');

                List<tblMagazine> q = (from i in db.tblMagazines
                         where i.tblMenu.MenuName.Contains(id)
                         select i).ToList();
                ViewData["CategorySelected"] = q;
            }
            return View("Index");
        }

        

        public ActionResult MagazineSelected(string id)
        {
            using (greenopt_IgNewsEntities db = new greenopt_IgNewsEntities())
            {

                id = id.Replace('-', ' ');
                List<tblNew> q = (from i in db.tblNews
                                       where i.tblMagazine.MagazineName.Contains(id)
                                       select i).ToList();
                ViewData["MagazineSelected"] = q;
                ViewBag.MagazineName = q.FirstOrDefault().tblMagazine.MagazineName;
              
            }
            return View("Index");
        }

        public ActionResult Details(string id)
        {



            using (greenopt_IgNewsEntities db = new greenopt_IgNewsEntities())
            {

                id = id.Replace('-', ' ');

                var q = (from i in db.tblNews
                         where i.Title.Contains(id)
                         select i).FirstOrDefault();
                ViewData["DetailsView"] = q;
            }
            return View();
        }

        public ActionResult Sports()
        {
            return View();
        }


    }
}