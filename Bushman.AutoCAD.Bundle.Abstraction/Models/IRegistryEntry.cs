using Bushman.AutoCAD.Bundle.Abstraction.Models.Attributes;

namespace Bushman.AutoCAD.Bundle.Abstraction.Models {

    // Required, if a RegistryEntries element is present
    /// <summary>
    /// A RegistryEntry element contains the definition
    /// of a registry entry that the plug-in should create or modify. Registry
    /// entries are stored in the Windows Registry or in a property list (PLIST)
    /// file on Mac OS. Note: On Windows, registry entries are created under
    /// HKEY_CURRENT_USER\Software\Autodesk\AutoCAD\&lt;release&gt;\ACAD-&lt;product&gt;:&lt;language&gt;.
    /// It is not possible to create registry entries in other locations. The equivalent
    /// location is used in the PLIST files on Mac OS.
    /// </summary>
    public interface IRegistryEntry {
        /// <summary>
        /// Name of the registry entry to create or modify.
        /// </summary>
        [NamingConvention(BundleXmlType.Attribute, nameof(Name))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Optional)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        string Name { get; set; }
        /// <summary>
        /// Value to assign to the registry entry. The value can include one of the
        /// optional operator prefixes: +, -, &, and |. See the 
        /// "Variable Value Operator Prefixes" section for more information.
        /// Note: The operator prefix is not retained when the value is applied to
        /// the registry entry.
        /// </summary>
        [NamingConvention(BundleXmlType.Attribute, nameof(Value))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Optional)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        string Value { get; set; }
        /// <summary>
        /// Optional, creation and modification flags. Multiple flags can be specified;
        /// use a pipe symbol to separate each flag.
        /// </summary>
        [NamingConvention(BundleXmlType.Attribute, nameof(Flags))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Optional)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        RegistryEntryFlags Flags { get; set; }
        /// <summary>
        /// Data type to assign to the registry entry. Optional when modifying an
        /// existing registry entry.
        /// </summary>
        [NamingConvention(BundleXmlType.Attribute, nameof(Type))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Optional)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        RegistryEntryType Type { get; set; }
    }
}
