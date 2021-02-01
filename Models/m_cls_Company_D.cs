using System.ComponentModel.DataAnnotations;

namespace eVisitor_mvcnet5.Models
{
    public class m_cls_Company_D
    {
        [Key]
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public int Status {get; set;}
    }
}