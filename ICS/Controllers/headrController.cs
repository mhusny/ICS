using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ICS.Controllers
{
    public class headrController : Controller
    {
        //
        // GET: /headr/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /headr/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /headr/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /headr/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /headr/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /headr/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /headr/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /headr/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
