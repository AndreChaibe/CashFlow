namespace CashFlow.Domain.Reports.ReportGeneration
{
    using System;

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ResourceReportGenerationMessages
    {

        private static global::System.Resources.ResourceManager resourceMan;

        private static global::System.Globalization.CultureInfo resourceCulture;

        public ResourceReportGenerationMessages()
        {
        }

        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    var temp = new global::System.Resources.ResourceManager("CashFlow.Domain.Reports.ReportGeneration.ResourceReportGenerationMessages", typeof(ResourceReportGenerationMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }

        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture
        {
            get
            {
                return resourceCulture;
            }
            set
            {
                resourceCulture = value;
            }
        }
        public static string AMOUNT => ResourceManager.GetString("AMOUNT", resourceCulture);
        public static string DATE => ResourceManager.GetString("DATE", resourceCulture);
        public static string DESCRIPTION => ResourceManager.GetString("DESCRIPTION", resourceCulture);
        public static string PAYMENT_TYPE => ResourceManager.GetString("PAYMENT_TYPE", resourceCulture);
        public static string TITLE => ResourceManager.GetString("TITLE", resourceCulture);
    }
}