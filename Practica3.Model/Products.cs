
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Practica3.Model
{
  
    public partial class Products
    {
      
        public Products()
        {
            Sales = new HashSet<Sales>();
        }

        [Key]
        public int ProductID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

      
        public virtual ICollection<Sales> Sales { get; set; }
    }
}
