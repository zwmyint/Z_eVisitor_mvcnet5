using System.ComponentModel.DataAnnotations;

namespace eVisitor_mvcnet5.Models
{
    public class m_cls_Status
    {
        [Key]
        public string StatusId { get; set; }
        public string Name { get; set; }
    }
}