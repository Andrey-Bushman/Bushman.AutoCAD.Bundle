using Bushman.AutoCAD.Bundle.Abstraction.Models;

namespace Bushman.AutoCAD.Bundle.Implementation.Models {
    internal sealed class RegistryEntry : IRegistryEntry {
        public string Name { get; set; }
        public string Value { get; set; }
        public RegistryEntryFlags Flags { get; set; }
        public RegistryEntryType Type { get; set; }
    }
}
