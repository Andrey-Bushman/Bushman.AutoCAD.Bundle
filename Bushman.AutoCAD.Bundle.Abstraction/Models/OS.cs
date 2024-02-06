using System;

namespace Bushman.AutoCAD.Bundle.Abstraction.Models {
    /// <summary>
    /// Target operating system.
    /// If omitted, it is assumed the plug-in supports all operating systems.
    /// Multiple operating systems can be specified by separating the values with
    /// the '|' symbol. (e.g. OS="Win32|Win64").
    /// Note: AutoLISP applications, .NET applications, and CUIx files can be used
    /// across multiple operating systems.
    /// </summary>
    [Flags]
    public enum OS {
        Win32 = 1,
        Win64 = 2,
        Mac = 4,
    }
}
