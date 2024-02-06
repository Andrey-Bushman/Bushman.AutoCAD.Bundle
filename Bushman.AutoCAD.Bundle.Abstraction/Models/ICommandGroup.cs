using Bushman.AutoCAD.Bundle.Abstraction.Models.Attributes;
using System.Collections.Generic;

namespace Bushman.AutoCAD.Bundle.Abstraction.Models {
    /// <summary>
    /// The Commands element is optional unless the LoadOnCommandInvocation
    /// parameter is enabled for the LoadReasons attribute. Used to specify
    /// which commands to register for LoadOnCommandInvocation. You can specify
    /// more than one Command element as needed.
    /// </summary>
    public interface ICommandGroup {
        /// <summary>
        /// Name used to organize related commands.
        /// </summary>
        [NamingConvention(BundleXmlType.Attribute, nameof(GroupName))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Optional)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        string GroupName { get; set; }
        /// <summary>
        /// The Commands element is optional unless the LoadOnCommandInvocation
        /// parameter is enabled for the LoadReasons attribute. Used to specify
        /// which commands to register for LoadOnCommandInvocation.
        /// </summary>
        [NamingConvention(BundleXmlType.Items)]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Optional)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        IList<ICommand> Commands { get; set; }
    }
}
