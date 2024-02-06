using Bushman.AutoCAD.Bundle.Abstraction.Models;

namespace Bushman.AutoCAD.Bundle.Implementation.Models {
    internal sealed class SystemVariable : ISystemVariable {
        public string Name { get; set; }
        public string Value { get; set; }
        public VariableType PrimaryType { get; set; }
        public StorageType StorageType { get; set; }
        public string Owner { get; set; }
        public SystemVariableFlags Flags { get; set; }
    }
}
