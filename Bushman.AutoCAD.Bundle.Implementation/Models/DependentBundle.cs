using System;
using System.Collections.Generic;
using Bushman.AutoCAD.Bundle.Abstraction.Models;

namespace Bushman.AutoCAD.Bundle.Implementation.Models {
    internal sealed class DependentBundle : IDependentBundle {
        public Guid UpgradeCode { get; set; } = Guid.Empty;
        public Version VersionMin { get; set; } = new Version(0, 0);
        public Version VersionMax { get; set; } = new Version(0, 0);
        public IList<IComponent> Components { get; } = new List<IComponent>();
    }
}