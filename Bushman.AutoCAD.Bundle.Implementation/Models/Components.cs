using Bushman.AutoCAD.Bundle.Abstraction.Models;
using System.Collections.Generic;

namespace Bushman.AutoCAD.Bundle.Implementation.Models {
    internal sealed class Components : IComponents {
        public IRuntimeRequirements RuntimeRequirements { get; set; } = new RuntimeRequirements();
        public IList<IRegistryEntry> RegistryEntries { get; } = new List<IRegistryEntry>();
        public IList<ISystemVariable> SystemVariables { get; } = new List<ISystemVariable>();
        public IList<IEnvironmentVariable> EnvironmentVariables { get; } = new List<IEnvironmentVariable>();
        public IList<IComponentEntry> ComponentEntries { get; } = new List<IComponentEntry>();
    }
}
