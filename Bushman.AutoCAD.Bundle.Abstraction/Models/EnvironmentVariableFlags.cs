namespace Bushman.AutoCAD.Bundle.Abstraction.Models {
    /// <summary>
    /// Optional, creation and modification flags. Multiple flags can be specified;
    /// use a pipe symbol to separate each flag.
    /// </summary>
    public enum EnvironmentVariableFlags {
        /// <summary>
        /// Variable is created if it does not exist. (Default behavior)
        /// </summary>
        Create,
        /// <summary>
        /// Modifies the value of the variable each time the plug-in is loaded,
        /// and only when the variable exists.
        /// Note: The Open or OpenOnce flag must be used to modify the value
        /// of a variable.
        /// </summary>
        Open,
        /// <summary>
        /// Modifies the value of the variable upon the very first time the plug-in
        /// is loaded, and only when the variable exists. Uninstalling and reinstalling
        /// the plug-in causes the value of the variable to be changed again.
        /// Note: The Open or OpenOnce flag must be used to modify the value
        /// of a variable.
        /// </summary>
        OpenOnce,
    }
}
