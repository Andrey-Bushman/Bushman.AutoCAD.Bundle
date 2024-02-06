using Bushman.AutoCAD.Bundle.Abstraction.Models.Attributes;

namespace Bushman.AutoCAD.Bundle.Abstraction.Models {

    // Required, if an EnvironmentVariables element is present
    /// <summary>
    /// A EnvironmentVariable element contains 
    /// the definition of an environment variable that the plug-in should create
    /// or modify. Environment variables are stored in the Windows Registry or in
    /// a property list (PLIST) file on Mac OS.
    /// Note: The value of an environment variable is always stored as a string,
    /// and the name of an environment variable is case sensitive.
    /// </summary>
    public interface IEnvironmentVariable {
        /// <summary>
        /// Name of the environment variable to create or modify.
        /// </summary>
        [NamingConvention(BundleXmlType.Attribute, nameof(Name))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Optional)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        string Name { get; set; }
        /// <summary>
        /// Value to assign to the variable. The value can include one of the optional
        /// operator prefixes: +, -, &, and |. See the "Variable Value Operator Prefixes"
        /// section for more information.
        /// Note: The operator prefix is not retained when the value is applied to
        /// the variable.
        /// </summary>
        [NamingConvention(BundleXmlType.Attribute, nameof(Value))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Optional)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        string Value { get; set; }
        /// <summary>
        /// Optional, data type that Value represents.
        /// If an operator prefix is used as part of the variable's value,
        /// the appropriate data type must be specified. If the appropriate data type
        /// is not used, the operation will be treated as a string operation.
        /// </summary>
        [NamingConvention(BundleXmlType.Attribute, nameof(Type))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Optional)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        VariableType Type { get; set; }
        /// <summary>
        /// Optional, creation and modification flags. Multiple flags can be specified;
        /// use a pipe symbol to separate each flag.
        /// </summary>
        [NamingConvention(BundleXmlType.Attribute, nameof(Flags))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Optional)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        EnvironmentVariableFlags Flags { get; set; }
    }
}