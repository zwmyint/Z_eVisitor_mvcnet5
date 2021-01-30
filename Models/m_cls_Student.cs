namespace eVisitor_mvcnet5.Models
{
    public class m_cls_Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public Gender StudentGender { get; set; }
    }

    public enum Gender
    {
        Male = 1,
        Female = 0    
    }
}