using ICS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;

namespace ICS.Controllers
{
    public class OrderController : Controller
    {
        


        public ActionResult Index()
        {
            ICSContext db = new ICSContext();

            var orders = db.ORDER_HEADERS.Include(s => s.details).Include(s => s.supplier);


            return View(orders);
        }

        


        public ActionResult Print(int id)
        {
            ICSContext db = new ICSContext();

            ORDER_HEADER order = db.ORDER_HEADERS.Find(id);

            ViewBag.CompanyNanme = "EAM MAliban";
            ViewBag.Address = "Boralla;Colombo 08";
            ViewBag.Phone = "011234567";
            
            return View(order);
        }

        

        public ActionResult Create()
        {
            ICSContext db = new ICSContext();
            ORDER_HEADER order = new ORDER_HEADER();

            //generate next invoice number
            var next_order = (from ord in db.ORDER_HEADERS
                                orderby ord.iPOID descending
                                select ord).FirstOrDefault();
            if (next_order != null)
                order.iPOID = next_order.iPOID + 1;

            order.dDate = DateTime.Now;
            ViewBag.iFactoryID = new SelectList(db.FACTORIES.OrderBy(f => f.iFactoryID), "iFactoryID", "cFactoryCode");
            ViewBag.iSupplierID = new SelectList(db.SUPPLIERS.OrderBy(s => s.iSupplierID), "iSupplierID", "cSupplierCode");

            return View(order);
        }

       


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(ORDER_HEADER order)
        {
            ICSContext db = new ICSContext();
            try
            {
                ViewBag.iSupplierID = new SelectList(db.SUPPLIERS.OrderBy(s => s.cSupplierCode), "iSupplierID", "cSupplierCode", order.iSupplierID);
                ViewBag.iFactoryID = new SelectList(db.FACTORIES.OrderBy(f => f.cFactoryCode), "iFactoryID", "cFactoryCode", order.iFactoryID);

                if (ModelState.IsValid)
                {
                    
                        //var order_exists = (from ord in db.ORDER_HEADERS where ord.iPOID == order.iPOID select ord).FirstOrDefault();
                        //if (order_exists != null)
                        //{
                        //    ModelState.AddModelError("OrderNumber", "Order with that number already exists");
                        //    return View(order);
                        //}
                   
                    db.ORDER_HEADERS.Add(order);
                    db.SaveChanges();
                    return RedirectToAction("Edit", "Order", new { id = order.iPOID });
                }
                return View(order);
            }
            catch
            {
                return View();
            }
        }

        

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ICSContext db = new ICSContext(); ;
            ORDER_HEADER order = db.ORDER_HEADERS.Find(id);
            ViewBag.iSupplierID = new SelectList(db.SUPPLIERS.OrderBy(s => s.cSupplierCode), "iSupplierID", "cSupplierCode", order.iSupplierID);
            ViewBag.iFactoryID = new SelectList(db.FACTORIES.OrderBy(f => f.cFactoryCode), "iFactoryID", "cFactoryCode", order.iFactoryID);


            return View(order);
        }

       


        [HttpPost]
        public ActionResult Edit(ORDER_HEADER order)
        {
            ICSContext db = new ICSContext();
            try
            {
                ViewBag.iSupplierID = new SelectList(db.SUPPLIERS.OrderBy(s => s.cSupplierCode), "iSupplierID", "cSupplierCode", order.iSupplierID);
                ViewBag.iFactoryID = new SelectList(db.FACTORIES.OrderBy(f => f.cFactoryCode), "iFactoryID", "cFactoryCode", order.iFactoryID);
               
                if (ModelState.IsValid)
                {
                    
                        ////make sure invoice number doesn't exist
                        //var invoice_exists = (from inv in db.Invoices
                        //                      where inv.InvoiceNumber == invoice.InvoiceNumber
                        //                      && inv.InvoiceID != invoice.InvoiceID
                        //                      select inv).Count();

                        //if (invoice_exists > 0)
                        //{
                        //    ModelState.AddModelError("InvoiceNumber", "Invoice with that number already exists");
                        //    return View(invoice);
                        //}

                    db.Entry(order).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", "order");
                }
                return View(order);
            }
            catch
            {
                return View();
            }
        }

        

        public ActionResult Delete(int id)
        {
            return View();
        }

        

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
