using Bushman.AutoCAD.Bundle.Abstraction.Models.Attributes;

namespace Bushman.AutoCAD.Bundle.Abstraction.Models {
    /// <summary>
    /// a Component element allows you to define a dependency on a specific
    /// component entry within a plug-in bundle.
    /// </summary>
    public interface IComponent {
        /// <summary>
        /// TODO: так Name или AppName?
        /// The Name attribute of the Component element must match that of
        /// the AppName attribute of the ComponentEntry in which this plug-in bundle
        /// has a dependency on.
        /// </summary>
        [NamingConvention(BundleXmlType.Attribute, nameof(AppName))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Required)]
        [RequiringConvention(DeploymentTarget.Local, Status.Required)]
        string AppName { get; set; }
    }
}
