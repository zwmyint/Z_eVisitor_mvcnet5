using System;
using System.ComponentModel.DataAnnotations;

namespace eVisitor_mvcnet5.Models
{
    public class m_cls_ToDo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter description")]
        public string Description { get; set; }

        [Required(ErrorMessage ="Please enter a due date")]
        public DateTime? DueDate { get; set; }

        [Required(ErrorMessage ="Please select a category")]
        public string CategoryId { get; set; }
        public m_cls_Category Category { get; set; }

        [Required(ErrorMessage ="Please select a status")]
        public string StatusId { get; set; }
        public m_cls_Status Status { get; set; }

        public bool Overdue => StatusId == "open" && DueDate < DateTime.Today;
    }
}