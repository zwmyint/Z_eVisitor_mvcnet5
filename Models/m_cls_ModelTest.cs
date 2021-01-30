namespace eVisitor_mvcnet5.Models
{
    public class m_cls_ModelTest
    {
        public EnumTest EnumTest { get; set; }
    }

    public enum EnumTest
    {
        Test1,
        Test2,
        Test3
    }

    /* 
    @model eVisitor_mvcnet5.Models.m_cls_ModelTest

    <div>
        @Html.EnumDropDownListFor(model => model.EnumTest, new { @class = "form-control" })
    </div> 
    
    // GET: Home
    public ActionResult Index()
    {
        ModelTest model = new ModelTest {EnumTest = EnumTest.Test2};
        return View("View",model);
    }
    */

}