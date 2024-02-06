using Bushman.AutoCAD.Bundle.Abstraction.Models.Attributes;
using System.Collections.Generic;

namespace Bushman.AutoCAD.Bundle.Abstraction.Models {
    public interface IAssemblyMappings {
        /// <summary>
        /// AssemblyMapping and AssemblyMappingFolder elements are used to add assembly
        /// files and folder paths to internal lists that are used by AutoCAD to resolve
        /// assemblies not found in the product installation folder.
        /// </summary>
        [NamingConvention(BundleXmlType.Items)]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Optional)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        IList<IAssemblyMapping> AssemblyMappings { get; }

        /// <summary>
        /// AssemblyMapping and AssemblyMappingFolder elements are used to add assembly
        /// files and folder paths to internal lists that are used by AutoCAD to resolve
        /// assemblies not found in the product installation folder.
        /// </summary>
        [NamingConvention(BundleXmlType.Items)]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Optional)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        IList<IAssemblyMappingFolder> AssemblyMappingFolders { get; }
    }
}
