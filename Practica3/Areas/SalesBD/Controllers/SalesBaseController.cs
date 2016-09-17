using Practica3.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practica3.Areas.SalesBD.Controllers
{
    [Authorize]
    //[ExceptionControl]
    public class SalesBaseController<T> : Controller where T : class
    {
        protected IRepository<T> _repository;
        public SalesBaseController()
        {
            _repository = new BaseRepository<T>();
        }

    }
}