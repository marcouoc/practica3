using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practica3.Model;

namespace Practica3.Areas.SalesBD.Controllers
{
    public class SalesController : SalesBaseController<Sales>
    {
        // GET: Sales/Sales
        public ActionResult Index()
        {


            return View(_repository.PaginatedListByLastName((x => x.Employees.FirstName), 1, 30));

        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Sales sale)
        {
            if (!ModelState.IsValid) return View(sale);


            //sale.CustomerID = Guid.NewGuid();
           // _repository.Add(sale);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(_repository.GetById(x => x.SalesID == id));
        }

        public ActionResult Details(int id)
        {
            return View(_repository.GetById(x => x.SalesID == id));
        }

        [HttpPost]
        public ActionResult Edit(Sales sale)
        {
            if (!ModelState.IsValid) return View(sale);


           // _repository.Update(sale);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            return View(_repository.GetById(x => x.SalesID == id));
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue) return RedirectToAction("Index");

            var sale = _repository.GetById(x => x.SalesID == id);
            if (sale == null) return RedirectToAction("Index");

            _repository.Delete(sale);
            return RedirectToAction("Index");
        }

    }
}