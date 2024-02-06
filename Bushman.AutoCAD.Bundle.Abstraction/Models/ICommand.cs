using Bushman.AutoCAD.Bundle.Abstraction.Models.Attributes;
using System.Collections.Generic;

namespace Bushman.AutoCAD.Bundle.Abstraction.Models {
    // Required, if a Commands element is present. AutoCAD 2013-based products and later
    /// <summary>
    /// Specifies the global and local names for each command.
    /// </summary>
    [BundleXmlItem("Command")]
    public interface ICommand {
        /// <summary>
        /// Global command name.
        /// </summary>
        [NamingConvention(BundleXmlType.Attribute, nameof(Global))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Required)]
        [RequiringConvention(DeploymentTarget.Local, Status.Required)]
        string Global { get; set; }
        /// <summary>
        /// Local command name.
        /// </summary>
        [NamingConvention(BundleXmlType.Attribute, nameof(Local))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Required)]
        [RequiringConvention(DeploymentTarget.Local, Status.Required)]
        IDictionary<LocaleCode, string> Local { get; }
        /// <summary>
        /// Help topic to open when the command is active and F1 is pressed.
        /// Note: To display the help topic, a help file must be assigned to
        /// the plug-in. The help file location for the plug-in is specified
        /// with the HelpFile attribute under the ApplicationPackage element.
        /// </summary>
        [NamingConvention(BundleXmlType.Attribute, nameof(HelpTopic))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Optional)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        string HelpTopic { get; set; }
        /// <summary>
        /// Executes the command at startup when True.
        /// </summary>
        [NamingConvention(BundleXmlType.Attribute, nameof(StartupCommand))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Optional)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        bool StartupCommand { get; set; }
    }
}
