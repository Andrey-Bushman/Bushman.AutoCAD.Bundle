namespace Bushman.AutoCAD.Bundle.Abstraction.Models {
    /// <summary>
    /// XAML type; currently the only supported value is "ContextualTabRule" and it
    /// is required when a XAML file is assigned to the ModuleName attribute.
    /// The application file that uses the XAML file should be listed after
    /// the ComponentEntry element that contains the XAML file.
    /// </summary>
    public enum XamlType {
        ContextualTabRule,
    }
}
