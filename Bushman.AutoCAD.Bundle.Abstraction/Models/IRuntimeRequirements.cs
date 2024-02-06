using Bushman.AutoCAD.Bundle.Abstraction.Models.Attributes;
using System;
using System.Collections.Generic;

namespace Bushman.AutoCAD.Bundle.Abstraction.Models {

    //  Required, if a Components element is present
    /// <summary>
    /// The RuntimeRequirements element is recommended and is used to control which
    /// operating systems, platforms, releases, and languages the ApplicationPackage,
    /// Components, and ComponentEntry elements apply to.
    /// If the element is not included, it is assumed that all components are
    /// compatible with all AutoCAD and AutoCAD-based products, releases, and
    /// operating systems.
    /// Note: Although this element is optional, it is possible that the plug-in
    /// might be installed on Mac OS or another platform that the plug-in was not
    /// originally tested on. Therefore, it is recommended that the element is used
    /// to control when the plug-in can be loaded.
    /// </summary>
    public interface IRuntimeRequirements {
        /// <summary>
        /// Target operating system.
        /// If omitted, it is assumed the plug-in supports all operating systems.
        /// Multiple operating systems can be specified by separating the values with
        /// the '|' symbol. (e.g. OS="Win32|Win64").
        /// Note: AutoLISP applications, .NET applications, and CUIx files can be used
        /// across multiple operating systems.
        /// </summary>
        [NamingConvention(BundleXmlType.Attribute, nameof(OS))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Optional)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        OS OS { get; set; }
        /// <summary>
        /// Target AutoCAD or AutoCAD-based products.
        /// Should be used when using APIs specific to one of the AutoCAD-based products
        /// that might not available in AutoCAD or other AutoCAD-based products.
        /// Multiple AutoCAD platforms can be specified by separating the values with
        /// the '|' symbol.
        /// </summary>
        [NamingConvention(BundleXmlType.Attribute, nameof(Platform))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Optional)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        Platform Platform { get; set; }
        /// <summary>
        /// Defines the minimum AutoCAD release number the set of components supports.
        /// The value can be a major version number(R24) or a specific version(R24.1).
        /// The AutoCAD version number can be found in the Windows Registry or obtained
        /// with the ACADVER system variable.
        /// If this attribute and SeriesMax are not specified, it is assumed all
        /// components are compatible with all AutoCAD releases. If you omit this value,
        /// any version before that specified by the SeriesMax attribute is allowed.
        /// </summary>
        [NamingConvention(BundleXmlType.Attribute, nameof(SeriesMin))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Optional)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        Version SeriesMin { get; set; }
        /// <summary>
        /// Defines the maximum AutoCAD release number the set of components supports.
        /// If you omit this value, any version after that specified by the SeriesMin attribute
        /// is allowed.
        /// </summary>
        [NamingConvention(BundleXmlType.Attribute, nameof(SeriesMax))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Optional)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        Version SeriesMax { get; set; }
        /// <summary>
        /// List of support paths used by this set of components separated by
        /// a semicolon. The support paths should be relative to the plug-in bundle.
        /// Localized support paths can be specified by combining SupportPath with
        /// a locale code.
        /// </summary>
        [NamingConvention(BundleXmlType.Attribute, nameof(SupportPath))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Optional)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        IDictionary<LocaleCode, string> SupportPath { get; }
        /// <summary>
        /// List of tool palette paths used by this set of components separated by
        /// a semicolon. The tool palette paths should be relative to the plug-in bundle.
        /// Localized tool palette paths can be specified by combining ToolPalettePath
        /// with a locale code.
        /// </summary>
        [NamingConvention(BundleXmlType.Attribute, nameof(ToolPalettePath))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Optional)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        IDictionary<LocaleCode, string> ToolPalettePath { get; }
    }
}
