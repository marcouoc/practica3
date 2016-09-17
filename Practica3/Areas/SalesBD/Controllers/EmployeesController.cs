using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practica3.Model;
namespace Practica3.Areas.SalesBD.Controllers
{
    public class EmployeesController : SalesBaseController<Employees>
    {
        public ActionResult Index()
        {
            //return View();
            return View(_repository.PaginatedListByLastName((x => x.LastName), 1, 30));

        }
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Employees employee)
        {
            if (!ModelState.IsValid) return View(employee);

          //  int i = _repository.GetList().Count();
            //employee.EmployeeID = i++;
            _repository.Add(employee);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(_repository.GetById(x => x.EmployeeID == id));
        }

        public ActionResult Details(int id)
        {
            return View(_repository.GetById(x => x.EmployeeID == id));
        }

        [HttpPost]
        public ActionResult Edit(Employees employee)
        {
            if (!ModelState.IsValid) return View(employee);


            _repository.Update(employee);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            return View(_repository.GetById(x => x.EmployeeID == id));
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue) return RedirectToAction("Index");

            var employee = _repository.GetById(x => x.EmployeeID == id);
            if (employee == null) return RedirectToAction("Index");

            _repository.Delete(employee);
            return RedirectToAction("Index");
        }

    }
}