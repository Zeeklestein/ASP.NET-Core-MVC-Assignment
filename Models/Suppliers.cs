using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManager.Mvc.Models
{
    [Table("Suppliers")]
    public class Suppliers
    {
        #nullable enable

        [Column("SupplierID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage="Supplier ID is required")]
        [Display(Name = "Supplier ID")]
        public int SupplierID { get; set; }

        [Column("CompanyName")]
        [Display(Name = "Company Name")]
        [Required(ErrorMessage ="Company Name is required")]
        [StringLength(40,ErrorMessage ="Company Name must not be more than 40 characters")]
        public string? CompanyName { get; set; }

        [Column("ContactName")]
        [Display(Name = "Contact Name")]
        [StringLength(30,ErrorMessage ="Contact Name must not be more than 30 characters")]
        public string? ContactName { get; set; }

        [Column("ContactTitle")]
        [Display(Name = "Contact Title")]
        [StringLength(30,ErrorMessage ="Contact Title must not be more than 30 characters")]
        public string? ContactTitle { get; set; }

        [Column("Address")]
        [Display(Name = "Address")]
        [StringLength(60,ErrorMessage ="Address must not be more than 60 characters")]
        public string? Address { get; set; }

        [Column("City")]
        [Display(Name = "City")]
        [StringLength(15,ErrorMessage ="City must not be more than 15 characters")]
        public string? City { get; set; }

        [Column("Region")]
        [Display(Name = "Region")]
        [StringLength(15,ErrorMessage ="Region must not be more than 15 characters")]
        public string? Region { get; set; }

        [Column("PostalCode")]
        [Display(Name = "Postal Code")]
        [StringLength(10,ErrorMessage ="Postal Code must not be more than 10 characters")]
        public string? PostalCode { get; set; }

        [Column("Country")]
        [Display(Name = "Country")]
        [StringLength(15,ErrorMessage ="Country must not be more than 15 characters")]
        public string? Country { get; set; }

        [Column("Phone")]
        [Display(Name = "Phone")]
        [StringLength(24,ErrorMessage ="Phone must not be more than 24 characters")]
        public string? Phone { get; set; }

        [Column("Fax")]
        [Display(Name = "Fax")]
        [StringLength(24,ErrorMessage ="Fax must not be more than 24 characters")]
        public string? Fax { get; set; }
    }
}