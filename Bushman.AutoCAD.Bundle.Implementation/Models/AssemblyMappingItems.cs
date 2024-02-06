using Bushman.AutoCAD.Bundle.Abstraction.Models;
using System.Collections.Generic;

namespace Bushman.AutoCAD.Bundle.Implementation.Models {
    internal sealed class AssemblyMappingItems : IAssemblyMappings {
        public IList<IAssemblyMappingFolder> AssemblyMappingFolders { get; } = new List<IAssemblyMappingFolder>();

        public IList<IAssemblyMapping> AssemblyMappings { get; } = new List<IAssemblyMapping>();
    }
}
