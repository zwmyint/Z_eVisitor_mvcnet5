using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eVisitor_mvcnet5.Models
{
    [Table("Employees")]
    public class m_cls_Employee
    {
        [Column("EmployeeID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Employee ID is required")]
        [Display(Name = "Employee ID")]
        public int EmployeeID { get; set; }

        [Column("FirstName")]
        [Display(Name = "First Name")]
        [StringLength(20, ErrorMessage = ("First name must be less than 20 characters"))]
        [Required(ErrorMessage = "Employee First Name is required")]
        public string FirstName { get; set; }

        [Column("LastName")]
        [Display(Name = "Last Name")]
        [StringLength(30, ErrorMessage = ("Last name must be less than 30 characters"))]
        [Required(ErrorMessage = "Employee Last Name is required")]
        public string LastName { get; set; }

        [Column("Title")]
        [Display(Name = "Title")]
        [StringLength(30, ErrorMessage = ("Title must be less than 30 characters"))]
        [Required(ErrorMessage = "Employee Title is required")]
        public string Title { get; set; }

/*         [Column("TitleOfCourtesy")]
        [Display(Name = "Title Of Courtesy")]
        [Required(ErrorMessage = "Title Of Courtesy is required")]
        public Enum_TitleOfCourtesy TitleOfCourtesy { get; set; } */


        [Column("BirthDate")]
        [Display(Name = "Birth Date")]
        [Required(ErrorMessage = "Employee Birth Date is required")]
        public DateTime BirthDate { get; set; }

        [Column("HireDate")]
        [Display(Name = "Hire Date")]
        [Required(ErrorMessage = "Hire Date is required")]
        public DateTime HireDate { get; set; }

        [Column("Country")]
        [Display(Name = "Country")]
        [StringLength(30, ErrorMessage = ("Country must be less than 30 characters"))]
        [Required(ErrorMessage = "Employee Country is required")]
        public string Country { get; set; }

        [Column("Notes")]
        [Display(Name = "Notes")]
        [StringLength(500, ErrorMessage = ("Notes must be less than 500 characters"))]
        public string Notes { get; set; }
    }

/* 
    public enum Enum_TitleOfCourtesy
    {
        Mr,
        Ms,
        Mrs,
        Dr
    } */

}

