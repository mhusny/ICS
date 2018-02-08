using ICS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ICS.Controllers
{
    public class SupplierController : Controller
    {
        //
        // GET: /Supplier/

        public ActionResult Index()
        {
            ICSContext db = new ICSContext();
            List<SUPPLIER> Suppliers = db.SUPPLIERS.ToList();
            return View(Suppliers);
        }

        //
        // GET: /Supplier/Details/5

        public ActionResult Details(int id)
        {
            ICSContext db = new ICSContext();
            SUPPLIER supplier = db.SUPPLIERS.Single(s => s.iSupplierID == id);
            return View(supplier);
        }

        //
        // GET: /Supplier/Create
        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_get()
        {

            return View();
        }

        //
        // POST: /Supplier/Create

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_post()
        {
            try
            {
                // TODO: Add insert logic here
                SUPPLIER supplier = new SUPPLIER();
                TryUpdateModel(supplier);

                ICSContext db = new ICSContext();
                db.SUPPLIERS.Add(supplier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Supplier/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ICSContext db = new ICSContext();
            SUPPLIER supplier = db.SUPPLIERS.Single(s => s.iSupplierID == id);

            return View(supplier);
        }

        //
        // POST: /Supplier/Edit/5

        [HttpPost]
        public ActionResult Edit(SUPPLIER supplier)
        {
            try
            {
                // TODO: Add update logic here
                ICSContext db = new ICSContext();

                db.Entry(supplier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Supplier/Delete/5

        public ActionResult Delete(int id)
        {
            ICSContext db = new ICSContext();
            SUPPLIER suplier = db.SUPPLIERS.Single(s => s.iSupplierID == id);
            return View(suplier);
        }

        //
        // POST: /Supplier/Delete/5

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_post(int id)
        {
            try
            {
                // TODO: Add delete logic here
                ICSContext db = new ICSContext();
                SUPPLIER suplier = db.SUPPLIERS.Single(s => s.iSupplierID == id);
                db.SUPPLIERS.Remove(suplier);
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
