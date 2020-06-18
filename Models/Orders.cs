using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManager.Mvc.Models
{
    [Table("Orders")]
    public class Orders
    {
        #nullable enable

        [Column("OrderID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage="Order ID is required")]
        [Display(Name = "Order ID")]
        public int OrderID { get; set; }

        [Column("CustomerID")]
        [ForeignKey("CustomerID")]
        [Display(Name = "Customer ID")]
        [StringLength(5,ErrorMessage ="Customer ID must not be more than 5 characters")]
        public string? CustomerID { get; set; }

        [Column("EmployeeID")]
        [ForeignKey("EmployeeID")]
        [Display(Name = "Employee ID")]
        public int EmployeeID { get; set; }

        [Column("OrderDate")]
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        [Column("RequiredDate")]
        [Display(Name = "Required Date")]
        public DateTime RequiredDate { get; set; }

        [Column("ShippedDate")]
        [Display(Name = "Shipped Date")]
        public DateTime? ShippedDate { get; set; }

        [Column("ShipVia")]
        [ForeignKey("ShipperID")]
        [Display(Name = "Ship Via")]
        public int ShipVia { get; set; }

        [Column("Freight")]
        [Display(Name = "Freight")]
        public decimal Freight { get; set; }

        [Column("ShipName")]
        [Display(Name = "Ship Name")]
        [StringLength(40,ErrorMessage ="Ship Name must not be more than 40 characters")]
        public string? ShipName { get; set; }

        [Column("ShipAddress")]
        [Display(Name = "Ship Address")]
        [StringLength(60,ErrorMessage ="Ship Address must not be more than 60 characters")]
        public string? ShipAddress { get; set; }

        [Column("ShipCity")]
        [Display(Name = "Ship City")]
        [StringLength(15,ErrorMessage ="Ship City must not be more than 15 characters")]
        public string? ShipCity { get; set; }

        [Column("ShipRegion")]
        [Display(Name = "Ship Region")]
        [StringLength(15,ErrorMessage ="Ship Region must not be more than 15 characters")]
        public string? ShipRegion { get; set; }

        [Column("ShipPostalCode")]
        [Display(Name = "Ship Postal Code")]
        [StringLength(10,ErrorMessage ="Ship Postal Code must not be more than 10 characters")]
        public string? ShipPostalCode { get; set; }

        [Column("ShipCountry")]
        [Display(Name = "Ship Country")]
        [StringLength(15,ErrorMessage ="Ship Country must not be more than 15 characters")]
        public string? ShipCountry { get; set; }
    }
}