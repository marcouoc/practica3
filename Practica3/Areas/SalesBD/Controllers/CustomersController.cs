using Practica3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practica3.Areas.SalesBD.Controllers
{
    public class CustomersController : SalesBaseController<Customers>
    {
        // GET: Sales/Customers
        public ActionResult Index()
        {
            //return View();
            return View(_repository.PaginatedListByLastName((x => x.LastName), 1, 30));

        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult List(int? page, int? size)
        {
            if (!page.HasValue || !size.HasValue)
            {
                page = 1;
                size = 15;
            }
            return PartialView("_List", _repository.PaginatedListByLastName((x => x.LastName),
                page.Value,
                size.Value));
        }

        public int PageTotal(int rows)
        {
            if (rows <= 0) return 0;
            var count = _repository.GetList().Count;
            return count % rows > 0 ? (count / rows) + 1 : count / rows;
        }

        [HttpPost]
        public ActionResult Create(Customers customer)
        {
            if (!ModelState.IsValid) return View(customer);


            //customer.CustomerID = Guid.NewGuid();
            _repository.Add(customer);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(_repository.GetById(x => x.CustomerID == id));
        }

        public ActionResult Details(int id)
        {
            return View(_repository.GetById(x => x.CustomerID == id));
        }

        [HttpPost]
        public ActionResult Edit(Customers customer)
        {
            if (!ModelState.IsValid) return View(customer);

           
            _repository.Update(customer);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            return View(_repository.GetById(x => x.CustomerID == id));
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue) return RedirectToAction("Index");

            var address = _repository.GetById(x => x.CustomerID == id);
            if (address == null) return RedirectToAction("Index");

            _repository.Delete(address);
            return RedirectToAction("Index");
        }

      
    }
}