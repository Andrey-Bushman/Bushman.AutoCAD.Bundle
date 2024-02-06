using Bushman.AutoCAD.Bundle.Abstraction.Models.Attributes;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Bushman.AutoCAD.Bundle.Abstraction.Models {
    /// <summary>
    /// Each PackageContents.xml file must contain an ApplicationPackage element.
    /// The ApplicationPackage element, in the form of XML attributes, contains
    /// general information about the plug-in. It also encapsulates other element
    /// types that help to define the contents of the plug-in.
    /// </summary>
    public interface IApplicationPackage: IXmlSerializable {
        /// <summary>
        /// PackageContents.xml format version number. The value should always be 1.0
        /// until a newer version of the schema is introduced.
        /// </summary>
        [NamingConvention(BundleXmlType.Attribute, nameof(SchemaVersion))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Required)]
        [RequiringConvention(DeploymentTarget.Local, Status.Required)]
        Version SchemaVersion { get; set; }
        /// <summary>
        /// Application version number. AutoCAD-based products use this value
        /// to determine if the installed version is the latest version.
        /// If an updated version is available, the user is informed and able
        /// to download and install the latest version. It is recommended to use
        /// an application version that includes major and minor values,
        /// such as “1.0.0.0”.
        /// </summary>
        [NamingConvention(BundleXmlType.Attribute, nameof(AppVersion))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Required)]
        [RequiringConvention(DeploymentTarget.Local, Status.Required)]
        Version AppVersion { get; set; }
        /// <summary>
        /// Name of the plug-in author.
        /// </summary>
        [NamingConvention(BundleXmlType.Attribute, nameof(Author))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Required)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        string Author { get; set; }
        /// <summary>
        /// Plug-in name. A localized plug-in name can be specified
        /// by combining Name with a locale code.See Supported Locale Codes
        /// Reference for a full list of supported locale codes.
        /// </summary>
        [NamingConvention(BundleXmlType.Attribute, nameof(Name))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Required)]
        [RequiringConvention(DeploymentTarget.Local, Status.Recommended)]
        IDictionary<LocaleCode, string> Name { get; }
        /// <summary>
        /// Short description of the plug-in. Localized descriptions
        /// can be specified by combining Description with a locale code.
        /// See Supported Locale Codes Reference for a full list of supported
        /// locale codes.
        /// </summary> 
        [NamingConvention(BundleXmlType.Attribute, nameof(Description))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Required)]
        [RequiringConvention(DeploymentTarget.Local, Status.Recommended)]
        IDictionary<LocaleCode, string> Description { get; }
        /// <summary>
        /// Icon for the plug-in; used in the installer and the Autodesk App Store
        /// website. The icon should be 32x32 pixels in size and support
        /// 32-bit (Truecolor) color depth. Recommend using a BMP or ICO file format.
        /// Note: All path specifiers are '/' and not '\', and paths are relative
        /// to the root .bundle folder.
        /// </summary>
        [NamingConvention(BundleXmlType.Attribute, nameof(Icon))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Required)]
        [RequiringConvention(DeploymentTarget.Local, Status.Recommended)]
        string Icon { get; set; }
        /// <summary>
        /// Help file that explains how to use the plug-in and provides additional
        /// information about the plug-in. It is recommended to create a
        /// How To section that explains how to use the plug-in. The file can be
        /// an ASCII text, a HTML document, or PDF file that contains the full
        /// documentation for the plug-in or contains a set of redirects to where
        /// the content might be located online. Localized help files can be specified
        /// by combining HelpFile with a locale code. See Supported Locale
        /// Codes Reference for a full list of supported locale codes.
        /// Note: All path specifiers are '/' and not '\', and paths are relative
        /// to the root .bundle folder.
        /// </summary>
        [NamingConvention(BundleXmlType.Attribute, nameof(Helpfile))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Required)]
        [RequiringConvention(DeploymentTarget.Local, Status.Recommended)]
        IDictionary<LocaleCode, string> Helpfile { get; }
        /// <summary>
        /// Unique GUID for the plug-in. A GUID must be generated for each unique
        /// plug-in, and is used for first run notifications and as the installer
        /// ID for Add/Remove Programs in Windows when installed from the Autodesk
        /// App Store website. ProductCode should be updated if the AppVersion is
        /// changed.This is so upgrade installs work properly and a notification
        /// is displayed for the upgrade when loaded into an AutoCAD-based product.
        /// On Windows, you can use the MSI installer ProductCode or generate a GUID
        /// using an application such as GuidGen.exe.There are also websites that
        /// allow you to generate a GUID.
        /// </summary>
        [NamingConvention(BundleXmlType.Attribute, nameof(ProductCode))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Required)]
        [RequiringConvention(DeploymentTarget.Local, Status.Required)]
        Guid ProductCode { get; set; }
        /// <summary>
        /// Unique GUID for the plug-in that must never be changed. The GUID is used
        /// by the Autodesk App Store website to allow for upgrading from an old
        /// version to a newer version of a plug-in without the need to uninstall
        /// the plug-in first. Note: You must increment AppVersion in order to allow
        /// for proper upgrading of a plug-in.
        /// </summary>
        [NamingConvention(BundleXmlType.Attribute, nameof(UpgradeCode))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Required)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        Guid UpgradeCode { get; set; }

        /// <summary>
        /// The CompanyDetails element is used to specify information about the company
        /// that created the plug-in.
        /// </summary>
        [NamingConvention(BundleXmlType.Element, nameof(CompanyDetails))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Optional)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        ICompanyDetails CompanyDetails { get; }

        /// <summary>
        /// The Components element is used to specify the components that make
        /// up one version of the plug-in.
        /// More than one Components element can be used to identify the components
        /// for a plug-in; each Components element can identify one or more components.
        /// Platform and product information for a Components element is defined with
        /// the RuntimeRequirements element. If all the components defined within
        /// a Components element apply to the same platform, you do not need to add a
        /// RuntimeRequirements element to each individual ComponentEntry element.
        /// </summary>
        [NamingConvention(BundleXmlType.Element, nameof(Components))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Optional)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        IComponents Components { get; }

        /// <summary>
        /// The DependentBundles element is used to specify which plug-in bundles must
        /// be available in order for another plug-in bundle to load. There are times
        /// when one plug-in bundle might depend on the files of another plug-in bundle
        /// to run correctly.Using a DependentBundles element, you can instruct AutoCAD
        /// to only load a plug-in bundle when a bundle with a specific upgrade code
        /// or version is installed and loaded. The DependentBundles element is optional,
        /// and can contain one or more DependentBundle elements. DependentBundle
        /// elements are used to identify which plug-in bundles must be installed and
        /// loaded before your plug-in bundle can be loaded.
        /// </summary>
        [NamingConvention(BundleXmlType.Element, nameof(DependentBundles))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Optional)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        IList<IDependentBundle> DependentBundles { get; }
    }
}
