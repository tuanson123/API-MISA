﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MISA.AplicationCore.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MISA.AplicationCore.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Nữ.
        /// </summary>
        internal static string Enum_Gender_Female {
            get {
                return ResourceManager.GetString("Enum_Gender_Female", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Nam.
        /// </summary>
        internal static string Enum_Gender_Male {
            get {
                return ResourceManager.GetString("Enum_Gender_Male", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Khác.
        /// </summary>
        internal static string Enum_Gender_Other {
            get {
                return ResourceManager.GetString("Enum_Gender_Other", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Đã nghỉ việc.
        /// </summary>
        internal static string Enum_WorkStatus_Resign {
            get {
                return ResourceManager.GetString("Enum_WorkStatus_Resign", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Đã nghỉ hưu.
        /// </summary>
        internal static string Enum_WorkStatus_Retired {
            get {
                return ResourceManager.GetString("Enum_WorkStatus_Retired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Đang thử việc.
        /// </summary>
        internal static string Enum_WorkStatus_TrailWork {
            get {
                return ResourceManager.GetString("Enum_WorkStatus_TrailWork", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Đang làm việc.
        /// </summary>
        internal static string Enum_WorkStatus_Working {
            get {
                return ResourceManager.GetString("Enum_WorkStatus_Working", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Thông tin {0} đã có trên hệ thống.&quot;.
        /// </summary>
        internal static string Msg_Duplicate {
            get {
                return ResourceManager.GetString("Msg_Duplicate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Dữ liệu không hợp lệ.
        /// </summary>
        internal static string Msg_IsNotValid {
            get {
                return ResourceManager.GetString("Msg_IsNotValid", resourceCulture);
            }
        }
    }
}