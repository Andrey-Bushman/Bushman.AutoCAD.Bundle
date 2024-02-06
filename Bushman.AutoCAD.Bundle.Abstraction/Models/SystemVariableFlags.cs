using System;

namespace Bushman.AutoCAD.Bundle.Abstraction.Models {
    /// <summary>
    /// Optional, creation and modification flags. Multiple flags can be specified;
    /// use a pipe symbol to separate each flag.
    /// </summary>
    [Flags]
    public enum SystemVariableFlags {
        /// <summary>
        /// Variable is created if it does not exist. (Default behavior)
        /// </summary>
        Create = 1,
        /// <summary>
        /// Modifies the value of the variable each time the plug-in is loaded,
        /// and only when the variable exists.
        /// Note: The Open or OpenOnce flag must be used to modify the value
        /// of a variable.
        /// </summary>
        Open = 2,
        /// <summary>
        /// Modifies the value of the variable upon the very first time the
        /// plug-in is loaded, and only when the variable exists. Uninstalling
        /// and reinstalling the plug-in causes the value of the variable to be
        /// changed again.
        /// Note: The Open or OpenOnce flag must be used to modify the value of
        /// a variable.
        /// </summary>
        OpenOnce = 4,
        /// <summary>
        /// Allows for the pressing of the Spacebar at the Command prompt.
        /// If not specified, pressing the Spacebar is the same as pressing Enter.
        /// Note: Use only with the Create flag and when the PrimaryType attribute
        /// is set to String.
        /// </summary>
        SpacesAllowed = 8,
        /// <summary>
        /// Allows for the clearing of a variable's value by entering a "." (period)
        /// for the value of the variable.
        /// Note: Use only with the Create flag and when the PrimaryType attribute
        /// is set to String.
        /// </summary>
        DotIsEmpty = 16,
        /// <summary>
        /// Changes to the variable are not recorded and cannot be undone with the U
        /// or UNDO commands.
        /// Note: Use only with the Create flag.
        /// </summary>
        NoUndo = 32,
        /// <summary>
        /// Triggers a reactor notification even when the value of the variable is
        /// set to its current value.
        /// Note: Use only with the Create flag.
        /// </summary>
        Chatty = 64,
    }
}
