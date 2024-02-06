using Bushman.AutoCAD.Bundle.Abstraction.Models;
using System.Collections.Generic;

namespace Bushman.AutoCAD.Bundle.Implementation.Models {
    internal sealed class Command : ICommand {
        public string Global { get; set; }
        public IDictionary<LocaleCode, string> Local { get; } = new Dictionary<LocaleCode, string>();
        public string HelpTopic { get; set; }
        public bool StartupCommand { get; set; }
    }
}
