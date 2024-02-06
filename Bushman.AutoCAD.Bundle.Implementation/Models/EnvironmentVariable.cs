using Bushman.AutoCAD.Bundle.Abstraction.Models;

namespace Bushman.AutoCAD.Bundle.Implementation.Models {
    internal sealed class EnvironmentVariable : IEnvironmentVariable {
        public string Name { get; set; }
        public string Value { get; set; }
        public VariableType Type { get; set; }
        public EnvironmentVariableFlags Flags { get; set; }
    }
}
