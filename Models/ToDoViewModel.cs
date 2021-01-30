using System.Collections.Generic;

namespace eVisitor_mvcnet5.Models
{
    public class ToDoViewModel
    {
        // ctor
        public ToDoViewModel()
        {
            CurrentTask = new m_cls_ToDo();
        }

        public m_cls_Filters Filters { get; set; }
        public List<m_cls_Status> Statuses { get; set; }
        public List<m_cls_Category> Categories { get; set; }

        public Dictionary<string,string> DueFilters { get; set; }
        public List<m_cls_ToDo> Tasks { get; set; }

        public m_cls_ToDo CurrentTask { get; set; } 
    }
}