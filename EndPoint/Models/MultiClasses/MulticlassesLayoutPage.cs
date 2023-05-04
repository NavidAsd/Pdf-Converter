using Common;

namespace EndPoint.Models.MultiClasses
{
    public class MulticlassesLayoutPage
    {
        public string Controller { set; get; }
        public string Action { set; get; }

    }
    public static class UseMultiLayoutPage
    {
        public static MulticlassesLayoutPage Use( string controller, string action)
        {
            MulticlassesLayoutPage multiclass = new MulticlassesLayoutPage();
            multiclass.Controller = controller;
            multiclass.Action = action;
            return multiclass;
        }
        public static MulticlassesLayoutPage LayoutData(string Controller, string Action)
        {
            return UseMultiLayoutPage.Use(Controller, Action);
        }
    }
    

}
