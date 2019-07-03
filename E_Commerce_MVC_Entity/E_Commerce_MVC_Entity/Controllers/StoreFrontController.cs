using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using E_Commerce_MVC_Entity.DAL;
using E_Commerce_MVC_Entity.Models;

namespace E_Commerce_MVC_Entity.Controllers
{
    public class StoreFrontController : Controller
    {

        private Commerce_context db = new Commerce_context();
        // GET: StoreFront
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Categoria category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
    }
}