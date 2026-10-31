namespace CashFlow.Domain.Reports.PaymentTypes
{
    using System;

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ResourcePaymentTypeMessages
    {

        private static global::System.Resources.ResourceManager resourceMan;

        private static global::System.Globalization.CultureInfo resourceCulture;

        public ResourcePaymentTypeMessages()
        {
        }
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    var temp = new global::System.Resources.ResourceManager("CashFlow.Domain.Reports.PaymentTypes.ResourcePaymentTypeMessages", typeof(ResourcePaymentTypeMessages).Assembly);
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

        public static string CASH => ResourceManager.GetString("CASH", resourceCulture);
        public static string CREDIT_CARD => ResourceManager.GetString("CREDIT_CARD", resourceCulture);
        public static string DEBIT_CARD => ResourceManager.GetString("DEBIT_CARD", resourceCulture);
        public static string ELECTRONIC_TRANSFER => ResourceManager.GetString("ELECTRONIC_TRANSFER", resourceCulture);

    }
}