using Bushman.AutoCAD.Bundle.Abstraction.Models.Attributes;
using System;
using System.Collections.Generic;

namespace Bushman.AutoCAD.Bundle.Abstraction.Models {
    // Required, if a DependentBundles element is present
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
    public interface IDependentBundle {
        /// <summary>
        /// Must be identical to the UpgradeCode attribute in the ApplicationPackage
        /// element of the dependent plug-in bundle.
        /// </summary>
        [NamingConvention(BundleXmlType.Attribute, nameof(UpgradeCode))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Optional)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        Guid UpgradeCode { get; set; }
        /// <summary>
        /// Optional; defines the minimum version of the plug-in bundle in which
        /// this plug-in bundle has a dependency on. The value is compared against
        /// the AppVersion attribute in the ApplicationPackage element of the
        /// dependent plug-in bundle.
        /// </summary>
        [NamingConvention(BundleXmlType.Attribute, nameof(VersionMin))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Optional)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        Version VersionMin { get; set; }
        /// <summary>
        /// Optional; defines the maximum version of the plug-in bundle in which this
        /// plug-in bundle has a dependency on. The value is compared against the
        /// AppVersion attribute in the ApplicationPackage element of the dependent
        /// plug-in bundle.
        /// </summary>
        [NamingConvention(BundleXmlType.Attribute, nameof(VersionMax))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Optional)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        Version VersionMax { get; set; }

        /// <summary>
        /// A DependentBundle element can contain, or encapsulate, a Component element.
        /// Adding a Component element allows you to define a dependency on a specific
        /// component entry within a plug-in bundle. The Name attribute of the Component
        /// element must match that of the AppName attribute of the ComponentEntry in
        /// which this plug-in bundle has a dependency on.
        /// </summary>
        [NamingConvention(BundleXmlType.Items, nameof(Components))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Optional)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        IList<IComponent> Components { get; }
    }
}
