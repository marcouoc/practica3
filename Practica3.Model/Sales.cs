


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Practica3.Model
{
   

    public partial class Sales
    {
        public int SalesID { get; set; }

        public int SalesPersonID { get; set; }

        public int CustomerID { get; set; }

        public int ProductID { get; set; }

        public int Quantity { get; set; }

        public virtual Customers Customers { get; set; }

        public virtual Employees Employees { get; set; }

        public virtual Products Products { get; set; }
    }
}
