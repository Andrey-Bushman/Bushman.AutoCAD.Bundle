namespace Bushman.AutoCAD.Bundle.Abstraction.Models {
    /// <summary>
    /// Data type to assign to the variable. Optional when modifying an existing
    /// system variable.
    /// If an operator prefix is used as part of the variable's value, the appropriate
    /// data type must be specified. If the appropriate data type is not used,
    /// the operation will be treated as a string operation.
    /// </summary>
    public enum VariableType {
        /// <summary>
        /// 16-bit signed integer
        /// </summary>
        Int16,
        /// <summary>
        /// 32-bit integer
        /// </summary>
        Int32,
        /// <summary>
        /// Float or double numeric value
        /// </summary>
        Real,
        /// <summary>
        /// Single or multiple character value
        /// </summary>
        String,
    }
}
