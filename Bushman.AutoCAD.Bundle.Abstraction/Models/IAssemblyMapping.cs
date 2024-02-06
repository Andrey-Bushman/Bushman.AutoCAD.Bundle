using Bushman.AutoCAD.Bundle.Abstraction.Models.Attributes;

namespace Bushman.AutoCAD.Bundle.Abstraction.Models {

    // Optional, but is required if an AssemblyMappings element
    // is present and it doesn't contain an AssemblyMappingFolder element
    /// <summary>
    /// AssemblyMapping elements are used to add assembly files and folder paths to
    /// internal lists that are used by AutoCAD to resolve assemblies not found
    /// in the product installation folder.
    /// </summary>
    public interface IAssemblyMapping {
        /// <summary>
        /// Name of the ComponentEntry for which the assembly is associated and
        /// with which should be loaded.
        /// </summary>
        [NamingConvention(BundleXmlType.Attribute, nameof(Name))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Optional)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        string Name { get; set; }
        /// <summary>
        /// Relative path to the assembly within the bundle.
        /// </summary>
        [NamingConvention(BundleXmlType.Attribute, nameof(Path))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Optional)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        string Path { get; set; }
    }
}
