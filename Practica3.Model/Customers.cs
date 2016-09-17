
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Practica3.Model
{
    [Table("Customers")]
    public partial class Customers
    {
      
        public Customers()
        {
            Sales = new HashSet<Sales>();
        }

        [Key]
        public int CustomerID { get; set; }

        [Required]
        [StringLength(40)]
        public string FirstName { get; set; }

        [StringLength(40)]
        public string MiddleInitial { get; set; }

        [Required]
        [StringLength(40)]
        public string LastName { get; set; }

      
        public virtual ICollection<Sales> Sales { get; set; }
    }
}
