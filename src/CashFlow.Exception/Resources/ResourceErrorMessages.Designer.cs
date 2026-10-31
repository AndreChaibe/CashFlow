namespace CashFlow.Exception.Resources {
    using System;
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ResourceErrorMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        public ResourceErrorMessages() {
        }
 
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    var temp = new global::System.Resources.ResourceManager("CashFlow.Exception.Resources.ResourceErrorMessages", typeof(ResourceErrorMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }

        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }

		public static string AMOUNT_MUST_BE_GREATER_THAN_ZERO => ResourceManager.GetString("AMOUNT_MUST_BE_GREATER_THAN_ZERO", resourceCulture);
		public static string EXPENSE_NOT_FOUND => ResourceManager.GetString("EXPENSE_NOT_FOUND", resourceCulture);
		public static string EXPENSES_CANNOT_FOR_THE_FUTURE => ResourceManager.GetString("EXPENSES_CANNOT_FOR_THE_FUTURE", resourceCulture);
		public static string PAYMENT_TYPE_INVALID => ResourceManager.GetString("PAYMENT_TYPE_INVALID", resourceCulture);
		public static string TITLE_REQUIRED => ResourceManager.GetString("TITLE_REQUIRED", resourceCulture);
		public static string UNKNOW_ERROR => ResourceManager.GetString("UNKNOW_ERROR", resourceCulture);

	}
}