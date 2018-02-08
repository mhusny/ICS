using ICS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ICS.Controllers
{
    public class SeasonController : Controller
    {
        //
        // GET: /Season/

        public ActionResult Index()
        {
            ICSContext db = new ICSContext();
            List<SEASON> season = db.SEASONS.ToList();
            return View(season);
        }

        //
        // GET: /Season/Details/5

        public ActionResult Details(int id)
        {
            ICSContext db = new ICSContext();
            SEASON season = db.SEASONS.Single(s => s.iSeasonID == id);
            return View(season);
        }

        //
        // GET: /Season/Create
        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_get()
        {
            return View();
        }

        //
        // POST: /Season/Create

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_post()
        {
            try
            {
                // TODO: Add insert logic here
                SEASON season = new SEASON();
                TryUpdateModel(season);

                ICSContext db = new ICSContext();
                db.SEASONS.Add(season);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Season/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ICSContext db = new ICSContext();
            SEASON season = db.SEASONS.Single(s => s.iSeasonID == id);

            return View(season);
        }

        //
        // POST: /Season/Edit/5

        [HttpPost]
        public ActionResult Edit(SEASON season)
        {
            try
            {
                // TODO: Add update logic here
                ICSContext db = new ICSContext();

                db.Entry(season).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Season/Delete/5

        public ActionResult Delete(int id)
        {
            ICSContext db = new ICSContext();
            SEASON season = db.SEASONS.Single(s => s.iSeasonID == id);
            return View(season);
        }

        //
        // POST: /Season/Delete/5

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_post(int id)
        {
            try
            {
                // TODO: Add delete logic here
                ICSContext db = new ICSContext();
                SEASON season = db.SEASONS.Single(s => s.iSeasonID == id);
                db.SEASONS.Remove(season);
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
