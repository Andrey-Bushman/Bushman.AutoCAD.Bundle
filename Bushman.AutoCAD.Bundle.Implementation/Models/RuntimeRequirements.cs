using Bushman.AutoCAD.Bundle.Abstraction.Models;
using System;
using System.Collections.Generic;

namespace Bushman.AutoCAD.Bundle.Implementation.Models {
    internal sealed class RuntimeRequirements : IRuntimeRequirements {
        public OS OS { get; set; } = OS.Win64;
        public Platform Platform { get; set; } = Platform.All;
        public Version SeriesMin { get; set; } = new Version(0, 0);
        public Version SeriesMax { get; set; } = new Version(0, 0);
        public IDictionary<LocaleCode, string> SupportPath { get; } = new Dictionary<LocaleCode, string>();
        public IDictionary<LocaleCode, string> ToolPalettePath { get; } = new Dictionary<LocaleCode, string>();
    }
}
