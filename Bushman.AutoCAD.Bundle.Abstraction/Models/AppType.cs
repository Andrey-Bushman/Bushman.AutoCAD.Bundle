namespace Bushman.AutoCAD.Bundle.Abstraction.Models {
    /// <summary>
    /// Component type; overrides the type derived from the file extension provided
    /// in the ModuleName attribute.
    /// </summary>
    public enum AppType {
        /// <summary>
        /// Managed or Mixed .NET assembly
        /// </summary>
        Net,
        /// <summary>
        /// ObjectARX.
        /// Required to load an ARX file from a bundle into AutoCAD for Mac.
        /// </summary>
        Arx,
        /// <summary>
        /// Tool palette
        /// </summary>
        Atc,
        /// <summary>
        /// Bundle package
        /// </summary>
        Bundle,
        /// <summary>
        /// Partial customization
        /// </summary>
        Cui,
        /// <summary>
        /// Partial customization
        /// </summary>
        CuiX,
        /// <summary>
        /// ObjectDBX
        /// </summary>
        Dbx,
        /// <summary>
        /// Resource DLL (not to be loaded into the AutoCAD-based product)
        /// </summary>
        Dependency,
        /// <summary>
        /// JavaScript
        /// </summary>
        JavaScript,
        /// <summary>
        /// AutoLISP/Visual LISP
        /// </summary>
        Lisp,
        /// <summary>
        /// AutoLISP/Visual LISP
        /// </summary>
        CompiledLisp,
        /// <summary>
        /// Menu customization
        /// </summary>
        Mnu,
        /// <summary>
        /// VBA Project
        /// </summary>
        VBA,
        /// <summary>
        /// XAML file used to implement a contextual ribbon tab
        /// </summary>
        Xaml,
    }
}
