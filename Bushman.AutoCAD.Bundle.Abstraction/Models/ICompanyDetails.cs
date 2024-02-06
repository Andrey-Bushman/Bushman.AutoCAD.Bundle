using Bushman.AutoCAD.Bundle.Abstraction.Models.Attributes;
using System.Collections.Generic;

namespace Bushman.AutoCAD.Bundle.Abstraction.Models {
    /// <summary>
    /// The CompanyDetails element is used to specify information about the company
    /// that created the plug-in. The CompanyDetails element is required when
    /// releasing a plug-in through the Autodesk App Store website. You must also
    /// populate each of the attributes for the CompanyDetails element.
    /// </summary>
    public interface ICompanyDetails {
        /// <summary>
        /// Name of the developer or company that authored the plug-in.
        /// </summary>
        [NamingConvention(BundleXmlType.Attribute, nameof(Name))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Required)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        string Name { get; set; }
        /// <summary>
        /// Phone number of the developer or company of the plug-in.
        /// International phone numbers can be specified by combining Phone with
        /// a locale code.See Supported Locale Codes Reference for a full list
        /// of supported locale codes.
        /// </summary>
        [NamingConvention(BundleXmlType.Attribute, nameof(Phone))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Optional)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        IDictionary<LocaleCode, string> Phone { get; }
        /// <summary>
        /// Web site for the developer or company of the plug-in. Localized Web site
        /// can be specified by combining URL with a locale code.See Supported Locale
        /// Codes Reference for a full list of supported locale codes.
        /// </summary>
        [NamingConvention(BundleXmlType.Attribute, nameof(URL))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Optional)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        IDictionary<LocaleCode, string> URL { get; }
        /// <summary>
        /// Developer or company contact email address for the plug-in.
        /// An international contact email address can be specified by combining
        /// Email with a locale code.See Supported Locale Codes Reference for a full
        /// list of supported locale codes.
        /// </summary>
        [NamingConvention(BundleXmlType.Attribute, nameof(Email))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Required)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        IDictionary<LocaleCode, string> Email { get; }
    }
}
