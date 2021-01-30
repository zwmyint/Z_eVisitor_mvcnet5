using System.ComponentModel.DataAnnotations;

namespace eVisitor_mvcnet5.Models
{
    public class m_cls_Category
    {
        [Key]
        public string CategoryId { get; set; }
        public string Name { get; set; }
    }
}