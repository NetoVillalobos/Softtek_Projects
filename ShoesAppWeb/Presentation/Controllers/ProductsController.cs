using Business;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            var data = ProductsBL.ProductsList();
            return View(data);
        } 

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Products prod)
        {
            try
            {
                ProductsBL.Add(prod);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(prod);
            }
        }


        public ActionResult Details(int id)
        {
            var data = ProductsBL.Details(id);
            return View(data);
        }


        public ActionResult Edit(int id)
        {
            var data = ProductsBL.Details(id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(Products prod)
        {
            try
            {
                ProductsBL.Edit(prod);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(prod);
            }
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var data = ProductsBL.Details(id.Value);
            return View(data);
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                ProductsBL.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }
    }
}