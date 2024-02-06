using Bushman.AutoCAD.Bundle.Abstraction.Models;

namespace Bushman.AutoCAD.Bundle.Implementation.Models {
    internal sealed class AssemblyMapping : IAssemblyMapping {
        public string Name { get; set; }
        public string Path { get; set; }
    }
}
