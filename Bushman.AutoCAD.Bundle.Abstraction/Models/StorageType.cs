namespace Bushman.AutoCAD.Bundle.Abstraction.Models {
    /// <summary>
    /// Storage location for the variable's value; when persisted.
    /// Optional when modifying an existing system variable.
    /// </summary>
    public enum StorageType {
        /// <summary>
        /// Persisted in the drawing file the variable is created
        /// </summary>
        Database,
        /// <summary>
        /// Persisted as part of the current AutoCAD profile
        /// </summary>
        Profile,
        /// <summary>
        /// Not retained between sessions or in the drawing it is created
        /// </summary>
        Session,
        /// <summary>
        /// Persisted as part of the FixedProfile for AutoCAD
        /// </summary>
        User,
    }
}
