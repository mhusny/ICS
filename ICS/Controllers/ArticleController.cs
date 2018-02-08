using ICS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ICS.Controllers
{
    public class ArticleController : Controller
    {
        //
        // GET: /Article/

        public ActionResult Index()
        {
            ICSContext db = new ICSContext();
            List<ARTICLE> articles = db.ARTICLES.ToList();
            return View(articles);
        }

        //
        // GET: /Article/Details/5

        public ActionResult Details(int id)
        {
            ICSContext db = new ICSContext();
            ARTICLE article = db.ARTICLES.Single(s => s.iArticleID == id);
            return View(article);
        }

        //
        // GET: /Article/Create
        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_get()
        {
            PopulateSeasonDropDownList();
            return View();
        }

        //
        // POST: /Article/Create

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_post()
        {
            try
            {
                // TODO: Add insert logic here
                ARTICLE article = new ARTICLE();
                TryUpdateModel(article);

                ICSContext db = new ICSContext();
                db.ARTICLES.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Article/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ICSContext db = new ICSContext();
            ARTICLE article = db.ARTICLES.Single(s => s.iArticleID == id);
            //ARTICLE article = db.ARTICLES.Find(id);
            ViewBag.iSeasonID = new SelectList(db.ARTICLES.OrderBy(a => a.cArticleCode), "iArticleID", "cArticleCode", article.iArticleID);
            //PopulateSeasonDropDownList(id);

            return View(article);
        }

        //
        // POST: /Article/Edit/5

        [HttpPost]
        public ActionResult Edit(ARTICLE article)
        {
            try
            {
                // TODO: Add update logic here
                ICSContext db = new ICSContext();

                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Article/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            ICSContext db = new ICSContext();
            ARTICLE article = db.ARTICLES.Single(s => s.iArticleID == id);
            return View(article);
        }

        //
        // POST: /Article/Delete/5

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_post(int id)
        {
            try
            {
                // TODO: Add delete logic here
                ICSContext db = new ICSContext();
                ARTICLE article = db.ARTICLES.Single(s => s.iArticleID == id);
                db.ARTICLES.Remove(article);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //#Custom properties
        private void PopulateSeasonDropDownList(object selectedSeason = null)
        {
            ICSContext db = new ICSContext();
            var seasonsQuery = from d in db.SEASONS
                               orderby d.iSeasonID
                               select d;
            ViewBag.iSeasonID = new SelectList(seasonsQuery, "iSeasonID", "cSeasonCode", selectedSeason);
        }
    }
}
