using System.ComponentModel.DataAnnotations;

namespace eVisitor_mvcnet5.Models
{
    public class m_cls_Person
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string firstName { get; set; }

        [Display(Name = "Last Name")]
        public string lastName { get; set; }

        [Display(Name = "S Amount")]
        public double s_Amount { get; set; }
    }
}