using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManager.Mvc.Models
{
    [Table("Products")]
    public class Products
    {
        #nullable enable
        
        [Column("ProductID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage ="Product ID is required")]
        [Display(Name = "Product ID")]
        public int ProductID { get; set; }

        [Column("ProductName")]
        [Display(Name = "Product Name")]
        [Required(ErrorMessage ="Product Name is required")]
        [StringLength(40,ErrorMessage ="Product Name must not be more than 40 characters")]
        public string? ProductName { get; set; }

        [Column("SupplierID")]
        [ForeignKey("SupplierID")]
        [Display(Name = "Supplier ID")]
        public int? SupplierID { get; set; }

        [Column("UnitPrice")]
        [Display(Name = "Unit Price")]
        public decimal? UnitPrice { get; set; }

        [Column("UnitsInStock")]
        [Display(Name = "Units In Stock")]
        public Int16? UnitsInStock { get; set; }
        
        [Column("UnitsOnOrder")]
        [Display(Name = "Units On Order")]
        public Int16? UnitsOnOrder { get; set; }

        [Column("Discontinued")]
        [Display(Name = "Discontinued")]
        public Boolean Discontinued { get; set; }
    }
}