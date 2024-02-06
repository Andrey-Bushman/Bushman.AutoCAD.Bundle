using System;

namespace Bushman.AutoCAD.Bundle.Abstraction.Models {
    /// <summary>
    /// Optional, creation and modification flags. Multiple flags can be specified;
    /// use a pipe symbol to separate each flag.
    /// Note: The Open or OpenOnce flag must be used to modify the value
    /// of a registry entry.
    /// </summary>
    [Flags]
    public enum RegistryEntryFlags {
        /// <summary>
        /// Registry entry is created if it does not exist. (Default behavior)
        /// </summary>
        Create = 1,
        /// <summary>
        /// Modifies the value of the registry entry each time the plug-in is
        /// loaded, and only when the registry entry exists.
        /// </summary>
        Open = 2,
        /// <summary>
        /// Modifies the value of the registry entry upon the very first time
        /// the plug-in is loaded, and only when the registry entry exists.
        /// Uninstalling and reinstalling the plug-in causes the value of the registry
        /// entry to be changed again.
        /// </summary>
        OpenOnce = 4,
    }
}
