using ICS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ICS.Controllers
{
    public class FactoryController : Controller
    {
        //
        // GET: /Factory/

        public ActionResult Index()
        {
            ICSContext db = new ICSContext();
            List<FACTORY> factory = db.FACTORIES.ToList();
            return View(factory);
        }

        //
        // GET: /Factory/Details/5

        public ActionResult Details(int id)
        {
            ICSContext db = new ICSContext();
            FACTORY factory = db.FACTORIES.Single(s => s.iFactoryID == id);
            return View(factory);
        }

        //
        // GET: /Factory/Create
        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_get()
        {
            return View();
        }

        //
        // POST: /Factory/Create

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_post()
        {
            try
            {
                // TODO: Add insert logic here
                FACTORY factory = new FACTORY();
                TryUpdateModel(factory);

                ICSContext db = new ICSContext();
                db.FACTORIES.Add(factory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Factory/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ICSContext db = new ICSContext();
            FACTORY factory = db.FACTORIES.Single(s => s.iFactoryID == id);

            return View(factory);
        }

        //
        // POST: /Factory/Edit/5

        [HttpPost]
        public ActionResult Edit(FACTORY factory)
        {
            try
            {
                // TODO: Add update logic here
                ICSContext db = new ICSContext();

                db.Entry(factory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Factory/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            ICSContext db = new ICSContext();
            FACTORY factory = db.FACTORIES.Single(s => s.iFactoryID == id);
            return View(factory);
        }

        //
        // POST: /Factory/Delete/5

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_post(int id)
        {
            try
            {
                // TODO: Add delete logic here
                ICSContext db = new ICSContext();
                FACTORY factory = db.FACTORIES.Single(s => s.iFactoryID == id);
                db.FACTORIES.Remove(factory);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

       
    }
}
