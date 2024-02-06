using Bushman.AutoCAD.Bundle.Abstraction.Models;
using System.Collections.Generic;

namespace Bushman.AutoCAD.Bundle.Implementation.Models {
    internal sealed class ComponentEntry : IComponentEntry {
        public string AppName { get; set; }
        public string AppDescription { get; set; }
        public AppType AppType { get; set; }
        public IDictionary<LocaleCode, string> ModuleName { get; } = new Dictionary<LocaleCode, string>();
        public bool PerDocument { get; set; } = true;
        public LoadReasons LoadReasons { get; set; }
        public XamlType XamlType { get; set; } = XamlType.ContextualTabRule;
        public ICommandGroup Commands { get; set; } = new CommandGroup();
        public IAssemblyMappings AssemblyMappings { get; set; } =  new AssemblyMappingItems();
    }
}
