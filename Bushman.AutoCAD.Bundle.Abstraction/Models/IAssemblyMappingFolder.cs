using Bushman.AutoCAD.Bundle.Abstraction.Models.Attributes;
using System.Xml.Linq;

namespace Bushman.AutoCAD.Bundle.Abstraction.Models {
    // Optional, but is required if an AssemblyMappings element
    // is present and it doesn't contain an AssemblyMapping element
    /// <summary>
    /// AssemblyMappingFolder elements are used to add assembly files and folder
    /// paths to internal lists that are used by AutoCAD to resolve assemblies not
    /// found in the product installation folder.
    /// </summary>
    public interface IAssemblyMappingFolder {
        /// <summary>
        /// Relative path to the assembly within the bundle.
        /// </summary>
        [NamingConvention(BundleXmlType.Attribute, nameof(Path))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Optional)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        string Path { get; set; }
    }
}
