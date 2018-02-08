using ICS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ICS.Controllers
{
    public class GRNController : Controller
    {

        public ActionResult Index()
        {
            ICSContext db = new ICSContext();

            var grn = db.GRN_HEADERS.Include(g => g.grndetails);

            //ORDER_HEADER order = new ORDER_HEADER();
            //ViewBag.iPOID = new SelectList(db.ORDER_HEADERS.OrderBy(o => o.iPOID), "iPOID", "cReference");

            return View(grn);
        }

        
        public ActionResult CreateFromPO(int id)
        {
            ICSContext db = new ICSContext();
            
            //ViewBag.DefaultVAT = System.Configuration.ConfigurationManager.AppSettings["DefaultVAT"];
            //ViewBag.Orderid = new SelectList(db.GRN_HEADERS, "iPOID", "cReference");
            //ORDER_HEADER order = null;
            //ORDER_DETAIL o = new ORDER_DETAIL();

            ViewBag.iFactoryID = new SelectList(db.FACTORIES.OrderBy(f => f.iFactoryID), "iFactoryID", "cFactoryCode");

            ORDER_HEADER order = new ORDER_HEADER();
            //ORDER_DETAIL orderdetail = new ORDER_DETAIL();


            GRN_HEADER grn = new GRN_HEADER();
            GRN_DETAIL grndetail = new GRN_DETAIL();


            //saving header
            order = (from ii in db.ORDER_HEADERS
                     where ii.iPOID == id
                     select ii).FirstOrDefault();


            if (order != null)
            {
                grn.dDate = order.dDate;
                grn.cReference = order.cReference;
                grn.iPOID = id;
                grn.iFactoryID = order.iFactoryID;
                grn.bReceived = order.bRecieved;

                db.GRN_HEADERS.Add(grn);
                db.SaveChanges();

            }

            int lastgrn = (from inv in db.GRN_HEADERS
                                orderby inv.iGRNID descending
                                select inv.iGRNID).FirstOrDefault();



            //saving detail
            IEnumerable<ORDER_DETAIL> poid = (from i in db.ORDER_DETAILS where i.iPOID == id select i);

            
            //if (poid != null)
            //{
            foreach (var orderdetail in poid)
            {
                grndetail.iGRNID = lastgrn;
                grndetail.iPOID = orderdetail.iPOID;
                grndetail.idPOLine = orderdetail.idPOLine;
                grndetail.iArticleID = orderdetail.iArticleID;
                grndetail.cArticleDescription2 = orderdetail.cArticleDescription2;
                grndetail.dQuantityOrder = orderdetail.dOrderQuantity;
                grndetail.bQuantityReceived = orderdetail.dRecievedQuantity;
                grndetail.dQuantity = 0;
                grndetail.dUnitPrice = 0;
                grndetail.dNetValue = 0;
                grndetail.dTaxRate = 0;
                grndetail.dTaxValue = 0;
                grndetail.dGrossValue = 0;
                grndetail.dValue = 0;

                db.GRN_DETAILS.Add(grndetail);
                db.SaveChanges();
            }
            

            //}
                return View("Edit", grn);
            
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ICSContext db = new ICSContext(); ;
            GRN_HEADER grn = db.GRN_HEADERS.Find(id);
            //ViewBag.iSupplierID = new SelectList(db.SUPPLIERS.OrderBy(s => s.cSupplierCode), "iSupplierID", "cSupplierCode", grn.iSupplierID);
            ViewBag.iFactoryID = new SelectList(db.FACTORIES.OrderBy(f => f.cFactoryCode), "iFactoryID", "cFactoryCode", grn.iFactoryID);


            return View(grn);
        }

        [HttpPost]
        public ActionResult Edit(GRN_HEADER grn)
        {
            ICSContext db = new ICSContext();
            try
            {
                //ViewBag.supplierid = new SelectList(db.SUPPLIERS.OrderBy(s => s.cSupplierCode), "iSupplierID", "cSupplierCode", order.iSupplierID);
                ViewBag.factoryid = new SelectList(db.FACTORIES.OrderBy(f => f.cFactoryCode), "iFactoryID", "cFactoryCode", grn.iFactoryID);

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

                    db.Entry(grn).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", "order");
                }
                return View(grn);
            }
            catch
            {
                return View();
            }
        }

    }
}
