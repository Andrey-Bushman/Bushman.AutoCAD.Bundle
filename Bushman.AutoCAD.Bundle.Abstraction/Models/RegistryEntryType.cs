namespace Bushman.AutoCAD.Bundle.Abstraction.Models {
    /// <summary>
    /// Data type to assign to the registry entry. Optional when modifying an
    /// existing registry entry.
    /// </summary>
    public enum RegistryEntryType {
        /// <summary>
        /// String; null terminated
        /// </summary>
        REG_SZ,
        /// <summary>
        /// String containing an unexpanded environment variable,
        /// such as %APPDATA%; null terminated
        /// </summary>
        REG_EXPAND_SZ,
        /// <summary>
        /// 32-bit unsigned integer
        /// </summary>
        REG_DWORD,
        /// <summary>
        /// 64-bit signed integer
        /// </summary>
        REG_QWORD,
    }
}
