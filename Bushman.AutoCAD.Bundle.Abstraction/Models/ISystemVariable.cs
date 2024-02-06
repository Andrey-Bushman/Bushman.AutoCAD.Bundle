using Bushman.AutoCAD.Bundle.Abstraction.Models.Attributes;

namespace Bushman.AutoCAD.Bundle.Abstraction.Models {

    // Required, if a SystemVariables element is present
    /// <summary>
    /// A SystemVariable element contains the definition
    /// of a system variable that the plug-in should create or modify.
    /// </summary>
    public interface ISystemVariable {
        /// <summary>
        /// Name of the system variable to create or modify.
        /// </summary>
        [NamingConvention(BundleXmlType.Attribute, nameof(Name))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Optional)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        string Name { get; set; }
        /// <summary>
        /// Value to assign to the variable. The value can include one of
        /// the optional operator prefixes: +, -, &, and |.
        /// See the "Variable Value Operator Prefixes" section for more information.
        /// Note: The operator prefix is not retained when the value is applied
        /// to the variable.
        /// </summary>
        [NamingConvention(BundleXmlType.Attribute, nameof(Value))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Optional)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        string Value { get; set; }
        /// <summary>
        /// Data type to assign to the variable. Optional when modifying an existing
        /// system variable.
        /// If an operator prefix is used as part of the variable's value, the appropriate
        /// data type must be specified. If the appropriate data type is not used,
        /// the operation will be treated as a string operation.
        /// </summary>
        [NamingConvention(BundleXmlType.Attribute, nameof(PrimaryType))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Optional)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        VariableType PrimaryType { get; set; }
        /// <summary>
        /// Storage location for the variable's value; when persisted.
        /// Optional when modifying an existing system variable.
        /// </summary>
        [NamingConvention(BundleXmlType.Attribute, nameof(StorageType))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Optional)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        StorageType StorageType { get; set; }
        /// <summary>
        /// Optional, AcRX service name. Used to make a system variable read-only
        /// and only modifiable by the application that registers the service
        /// name using acrxRegisterService().
        /// </summary>
        [NamingConvention(BundleXmlType.Attribute, nameof(Owner))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Optional)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        string Owner { get; set; }
        /// <summary>
        /// Optional, creation and modification flags. Multiple flags can be specified;
        /// use a pipe symbol to separate each flag.
        /// </summary>
        [NamingConvention(BundleXmlType.Attribute, nameof(Flags))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Optional)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        SystemVariableFlags Flags { get; set; }
    }
}
