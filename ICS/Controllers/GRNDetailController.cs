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
    public class GRNDetailController : Controller
    {

        public PartialViewResult IndexByOrder(int id)
        {
            ICSContext db = new ICSContext();

            ViewBag.Orderid = id;
            var invoice = db.GRN_HEADERS.Where(i => i.iGRNID == id).FirstOrDefault();
            ViewBag.Invoice = invoice;

            var orderdetails = db.GRN_DETAILS.Include(i => i.grn).Where(i => i.iGRNID == id);
            return PartialView("Index", orderdetails.ToList());
        }


        public ActionResult Index()
        {
            ICSContext db = new ICSContext();

            var orderdetails = db.GRN_DETAILS.Include(o => o.grn);
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
            ViewBag.grnid = new SelectList(db.GRN_HEADERS, "iGRNID", "cReference", id.Value);
            GRN_HEADER grn = null;
            GRN_DETAIL o = new GRN_DETAIL();

            ViewBag.iArticleID = new SelectList(db.ARTICLES.OrderBy(a => a.iArticleID), "iArticleID", "cArticleCode", o.iArticleID);
            if (id.HasValue)
            {
                grn = (from ii in db.GRN_HEADERS
                         where ii.iGRNID == id
                         select ii).FirstOrDefault();

                if (o != null)
                {
                    o = new GRN_DETAIL();
                    o.iGRNID = id.Value;
                    o.iPOID = grn.iPOID;
                    o.grn = grn;
                    //o.dOrderQuantity = 1;
                    o.dUnitPrice = Convert.ToDecimal(System.Configuration.ConfigurationManager.AppSettings["DefaultVAT"]);

                    ViewBag.iArticleID = new SelectList(db.ARTICLES.OrderBy(a => a.iArticleID), "iArticleID", "cArticleCode", o.iArticleID);
                    //if (order.details.Count == 0)
                    //{ //if this is the first line, we may want to name it as the invoice.
                    //    o.iArticleID = order.cReference;
                    //}
                    ViewBag.InvoiceID = new SelectList(db.GRN_HEADERS, "iGRNID", "cReference", id.Value);
                }
            }


            return View("Create", o);
        }



        [HttpPost]
        public ActionResult Create(GRN_DETAIL grndetail)
        {
            ICSContext db = new ICSContext();
            try
            {
                if (ModelState.IsValid)
                {
                    db.GRN_DETAILS.Add(grndetail);
                    db.SaveChanges();

                    var invoice = (from i in db.GRN_HEADERS where i.iPOID == grndetail.iGRNID select i).FirstOrDefault();
                    ViewBag.Invoice = invoice;
                    //ViewBag.IsProposal = invoice.IsProposal;

                    return PartialView("Index", db.GRN_DETAILS.Where(i => i.iGRNID == grndetail.iGRNID));
                }

                //ViewBag.InvoiceID = new SelectList(db.ORDER_HEADERS, "InvoiceID", "Notes", invoicedetails.InvoiceID);
                //this.Response.StatusCode = 400;
                return PartialView("Create", grndetail);
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

            GRN_DETAIL grndetails = db.GRN_DETAILS.Find(id);

            ViewBag.InvoiceID = new SelectList(db.GRN_HEADERS, "iGRNID", "cReference", grndetails.iGRNID);
            ViewBag.iArticleID = new SelectList(db.ARTICLES.OrderBy(a => a.iArticleID), "iArticleID", "cArticleCode", grndetails.iArticleID);


            return PartialView(grndetails);
        }

        


        [HttpPost]
        public ActionResult Edit(GRN_DETAIL grndetail)
        {
            ICSContext db = new ICSContext();
            try
            {
                ViewBag.iArticleID = new SelectList(db.ARTICLES.OrderBy(a => a.iArticleID), "iArticleID", "cArticleCode", grndetail.iArticleID);

                if (ModelState.IsValid)
                {

                    db.Entry(grndetail).State = EntityState.Modified;
                    db.SaveChanges();
                    //get the details for selected order
                    var grn = (from i in db.GRN_HEADERS where i.iGRNID == grndetail.iGRNID select i).FirstOrDefault();
                    ViewBag.order = grn;
                    //ViewBag.IsProposal = invoice.IsProposal;
                    return PartialView("Index", db.GRN_DETAILS.Where(i => i.iGRNID == grndetail.iGRNID));
                }   
                ViewBag.InvoiceID = new SelectList(db.GRN_HEADERS, "iGRNID", "cReference", grndetail.iGRNID);
                this.Response.StatusCode = 400;
                return PartialView("Edit", grndetail);
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /GRNDetail/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /GRNDetail/Delete/5

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
