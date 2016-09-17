using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practica3.Model;
namespace Practica3.Areas.SalesBD.Controllers
{
    public class ProductsController : SalesBaseController<Products>
    {
        // GET: Sales/Products
        public ActionResult Index()
        {
            //return View();
            return View(_repository.PaginatedListByLastName((x => x.Name), 1, 30));

        }
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Products product)
        {
            if (!ModelState.IsValid) return View(product);


            //product.CustomerID = Guid.NewGuid();
            _repository.Add(product);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(_repository.GetById(x => x.ProductID == id));
        }

        public ActionResult Details(int id)
        {
            return View(_repository.GetById(x => x.ProductID == id));
        }

        [HttpPost]
        public ActionResult Edit(Products product)
        {
            if (!ModelState.IsValid) return View(product);


            _repository.Update(product);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            return View(_repository.GetById(x => x.ProductID == id));
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue) return RedirectToAction("Index");

            var product = _repository.GetById(x => x.ProductID == id);
            if (product == null) return RedirectToAction("Index");

            _repository.Delete(product);
            return RedirectToAction("Index");
        }

    }
}