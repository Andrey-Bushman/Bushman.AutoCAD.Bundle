using Bushman.AutoCAD.Bundle.Abstraction.Models;
using System.Collections.Generic;

namespace Bushman.AutoCAD.Bundle.Implementation.Models {
    internal sealed class CommandGroup : ICommandGroup {
        public string GroupName { get; set; }
        public IList<ICommand> Commands { get; set; } = new List<ICommand>();
    }
}
