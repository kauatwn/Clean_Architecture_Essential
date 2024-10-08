﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Application.Shared.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ResourceExceptionMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public ResourceExceptionMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Application.Shared.Resources.ResourceExceptionMessages", typeof(ResourceExceptionMessages).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Description must be between {0} and {1} characters long.
        /// </summary>
        public static string DescriptionLengthMessage {
            get {
                return ResourceManager.GetString("DescriptionLengthMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The description must not be empty.
        /// </summary>
        public static string EmptyDescriptionMessage {
            get {
                return ResourceManager.GetString("EmptyDescriptionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The provided ID is invalid.
        /// </summary>
        public static string InvalidIdMessage {
            get {
                return ResourceManager.GetString("InvalidIdMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The image URL is invalid.
        /// </summary>
        public static string InvalidImageUrlMessage {
            get {
                return ResourceManager.GetString("InvalidImageUrlMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The price must be a positive value.
        /// </summary>
        public static string InvalidPriceMessage {
            get {
                return ResourceManager.GetString("InvalidPriceMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A resource with this name already exists.
        /// </summary>
        public static string NameAlreadyExistsMessage {
            get {
                return ResourceManager.GetString("NameAlreadyExistsMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Name must be between {0} and {1} characters long.
        /// </summary>
        public static string NameLengthMessage {
            get {
                return ResourceManager.GetString("NameLengthMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The description must not be null or empty.
        /// </summary>
        public static string NullOrEmptyDescriptionMessage {
            get {
                return ResourceManager.GetString("NullOrEmptyDescriptionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The name must not be null or empty.
        /// </summary>
        public static string NullOrEmptyNameMessage {
            get {
                return ResourceManager.GetString("NullOrEmptyNameMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Resource not found.
        /// </summary>
        public static string ResourceNotFoundTitle {
            get {
                return ResourceManager.GetString("ResourceNotFoundTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An unexpected error occurred. Please try again later.
        /// </summary>
        public static string UnknownErrorMessage {
            get {
                return ResourceManager.GetString("UnknownErrorMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unknown error.
        /// </summary>
        public static string UnknownErrorTitle {
            get {
                return ResourceManager.GetString("UnknownErrorTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Validation error.
        /// </summary>
        public static string ValidationErrorTitle {
            get {
                return ResourceManager.GetString("ValidationErrorTitle", resourceCulture);
            }
        }
    }
}
