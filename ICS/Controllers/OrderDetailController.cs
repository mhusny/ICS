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
    public class OrderDetailController : Controller
    {
        


        public PartialViewResult IndexByOrder(int id)
        {
            ICSContext db = new ICSContext();

            ViewBag.Orderid = id;
            var invoice = db.ORDER_HEADERS.Where(i => i.iPOID == id).FirstOrDefault();
            ViewBag.Invoice = invoice;

            var orderdetails = db.ORDER_DETAILS.Include(i => i.order).Where(i => i.iPOID == id);
            return PartialView("Index", orderdetails.ToList());
        }


        public ActionResult Index()
        {
            ICSContext db = new ICSContext();

            var orderdetails = db.ORDER_DETAILS.Include(o=>o.order);
            return View(orderdetails.ToList());
        }

        


        public ActionResult Details(int id)
        {
            return View();
        }

        

        [HttpGet]
        public ActionResult Create(int? id)
        {
            ICSContext db = new ICSContext();

            //ViewBag.DefaultVAT = System.Configuration.ConfigurationManager.AppSettings["DefaultVAT"];
            ViewBag.Orderid = new SelectList(db.ORDER_HEADERS, "iPOID", "cReference", id.Value);
            ORDER_HEADER order = null;
            ORDER_DETAIL o = new ORDER_DETAIL();

            ViewBag.iArticleID = new SelectList(db.ARTICLES.OrderBy(a => a.iArticleID), "iArticleID", "cArticleCode", o.iArticleID);
            if (id.HasValue)
            {
                order = (from ii in db.ORDER_HEADERS
                         where ii.iPOID == id
                         select ii).FirstOrDefault();

                if (o != null)
                {
                    o = new ORDER_DETAIL();
                    o.iPOID = id.Value;
                    o.order = order;
                    o.dOrderQuantity = 1;
                    o.dUnitPrice = Convert.ToDecimal(System.Configuration.ConfigurationManager.AppSettings["DefaultVAT"]);

                    ViewBag.iArticleID = new SelectList(db.ARTICLES.OrderBy(a => a.iArticleID), "iArticleID", "cArticleCode", o.iArticleID);
                    //if (order.details.Count == 0)
                    //{ //if this is the first line, we may want to name it as the invoice.
                    //    o.iArticleID = order.cReference;
                    //}
                    ViewBag.InvoiceID = new SelectList(db.ORDER_HEADERS, "iPOID", "cReference", id.Value);
                }
            }

            
                return View("Create", o);
           
        }



        [HttpPost]
        public ActionResult Create(ORDER_DETAIL detail)
        {
            ICSContext db = new ICSContext();
            try
            {
                if (ModelState.IsValid)
                {
                    db.ORDER_DETAILS.Add(detail);
                    db.SaveChanges();

                    var invoice = (from i in db.ORDER_HEADERS where i.iPOID == detail.iPOID select i).FirstOrDefault();
                    ViewBag.Invoice = invoice;
                    //ViewBag.IsProposal = invoice.IsProposal;

                    return PartialView("Index", db.ORDER_DETAILS.Where(i => i.iPOID == detail.iPOID));
                }

                //ViewBag.InvoiceID = new SelectList(db.ORDER_HEADERS, "InvoiceID", "Notes", invoicedetails.InvoiceID);
                //this.Response.StatusCode = 400;
                return PartialView("Create", detail);
            }
            catch
            {
                return View();
            }
        }

        

        [HttpGet]
        public ActionResult Edit(int id)
        {
                ICSContext db = new ICSContext();

                ORDER_DETAIL orderdetails = db.ORDER_DETAILS.Find(id);

                ViewBag.InvoiceID = new SelectList(db.ORDER_HEADERS, "iPOID", "cReference", orderdetails.iPOID);
                ViewBag.iArticleID = new SelectList(db.ARTICLES.OrderBy(a => a.iArticleID), "iArticleID", "cArticleCode", orderdetails.iArticleID);


                return PartialView(orderdetails);
        }

        


        [HttpPost]
        public ActionResult Edit(ORDER_DETAIL orderdetail)
        {
                    ICSContext db = new ICSContext();
            try
            {
                ViewBag.iArticleID = new SelectList(db.ARTICLES.OrderBy(a => a.iArticleID), "iArticleID", "cArticleCode", orderdetail.iArticleID);

                if (ModelState.IsValid)
                {

                    db.Entry(orderdetail).State = EntityState.Modified;
                    db.SaveChanges();
                    //get the details for selected order
                    var order = (from i in db.ORDER_HEADERS where i.iPOID == orderdetail.iPOID select i).FirstOrDefault();
                    ViewBag.order = order;
                    //ViewBag.IsProposal = invoice.IsProposal;
                    return PartialView("Index", db.ORDER_DETAILS.Where(i => i.iPOID == orderdetail.iPOID));
                }
                ViewBag.InvoiceID = new SelectList(db.ORDER_HEADERS, "iPOID", "cReference", orderdetail.iPOID);
                this.Response.StatusCode = 400;
                return PartialView("Edit", orderdetail);
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /OrderDetail/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /OrderDetail/Delete/5

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
