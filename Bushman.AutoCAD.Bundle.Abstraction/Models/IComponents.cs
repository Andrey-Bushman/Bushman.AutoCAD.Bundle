using Bushman.AutoCAD.Bundle.Abstraction.Models.Attributes;
using System.Collections;
using System.Collections.Generic;

namespace Bushman.AutoCAD.Bundle.Abstraction.Models {
    /// <summary>
    /// The Components element is used to specify the components that make
    /// up one version of the plug-in.
    /// </summary>
    public interface IComponents {
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
        [NamingConvention(BundleXmlType.Element, nameof(RuntimeRequirements))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Required)]
        [RequiringConvention(DeploymentTarget.Local, Status.Required)]
        IRuntimeRequirements RuntimeRequirements { get; set; }
        /// <summary>
        /// The RegistryEntries element is optional, and can contain one or more
        /// RegistryEntry elements. A RegistryEntry element contains the definition
        /// of a registry entry that the plug-in should create or modify. Registry
        /// entries are stored in the Windows Registry or in a property list (PLIST)
        /// file on Mac OS. Note: On Windows, registry entries are created under
        /// HKEY_CURRENT_USER\Software\Autodesk\AutoCAD\&lt;release&gt;\ACAD-&lt;product&gt;:&lt;language&gt;.
        /// It is not possible to create registry entries in other locations. The equivalent
        /// location is used in the PLIST files on Mac OS.
        /// </summary>
        [NamingConvention(BundleXmlType.Element, nameof(RegistryEntries))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Optional)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        IList<IRegistryEntry> RegistryEntries { get; }
        /// <summary>
        /// The SystemVariables element is optional, and can contain one or more
        /// SystemVariables elements. A SystemVariable element contains the definition
        /// of a system variable that the plug-in should create or modify.
        /// </summary>
        [NamingConvention(BundleXmlType.Element, nameof(SystemVariables))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Optional)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        IList<ISystemVariable> SystemVariables { get; }
        /// <summary>
        /// The EnvironmentVariables element is optional, and can contain one or more
        /// EnvironmentVariable elements. A EnvironmentVariable element contains 
        /// the definition of an environment variable that the plug-in should create
        /// or modify. Environment variables are stored in the Windows Registry or in
        /// a property list (PLIST) file on Mac OS.
        /// Note: The value of an environment variable is always stored as a string,
        /// and the name of an environment variable is case sensitive.
        /// </summary>
        [NamingConvention(BundleXmlType.Element, nameof(EnvironmentVariables))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Optional)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        IList<IEnvironmentVariable> EnvironmentVariables { get; }
        /// <summary>
        /// ComponentEntry elements are loaded in the order they are listed,
        /// but from the bottom up. Therefore, any files that other components are
        /// dependent on must be lower down the list. For example, if an ObjectARX
        /// module is dependent on an ObjectDBX module, then the ObjectARX module
        /// will need to appear above the ObjectDBX module in the list.
        /// </summary>
        [NamingConvention(BundleXmlType.Items, nameof(ComponentEntries))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Optional)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        IList<IComponentEntry> ComponentEntries { get; }
    }
}
