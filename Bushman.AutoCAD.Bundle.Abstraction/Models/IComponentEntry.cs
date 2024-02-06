using Bushman.AutoCAD.Bundle.Abstraction.Models.Attributes;
using System.Collections.Generic;

namespace Bushman.AutoCAD.Bundle.Abstraction.Models {

    // Required, if a Components element is present
    /// <summary>
    /// The ComponentEntry element is required and is used to specify details about
    /// each individual component in the Components element.
    /// </summary>
    public interface IComponentEntry {
        /// <summary>
        /// Optional for AutoLISP; Required for ObjectARX and .NET - Component name;
        /// same as AppName in the ObjectARX API AcadAppInfo class.
        /// </summary>
        [NamingConvention(BundleXmlType.Attribute, nameof(AppName))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Required)]
        [RequiringConvention(DeploymentTarget.Local, Status.Required)]
        string AppName { get; set; }
        /// <summary>
        /// Component description; same as AppDescription in the ObjectARX API
        /// AcadAppInfo class.
        /// </summary>
        [NamingConvention(BundleXmlType.Attribute, nameof(AppDescription))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Optional)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        string AppDescription { get; set; }
        /// <summary>
        /// Component type; overrides the type derived from the file extension
        /// provided in the ModuleName attribute.
        /// </summary>
        [NamingConvention(BundleXmlType.Attribute, nameof(AppType))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Optional)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        AppType AppType { get; set; }
        /// <summary>
        /// Relative path to the component within the bundle; same as ModuleName
        /// in the ObjectARX API AcadAppInfo class. The component type is determined
        /// from the file extension. All path specifiers are '/' and not '\', and
        /// paths are relative to the root .bundle folder.
        /// </summary>
        [NamingConvention(BundleXmlType.Attribute, nameof(ModuleName))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Required)]
        [RequiringConvention(DeploymentTarget.Local, Status.Required)]
        IDictionary<LocaleCode, string> ModuleName { get; }
        /// <summary>
        /// AutoLISP only - When True, the AutoLISP file is loaded once per document.
        /// Default is True.
        /// </summary>
        [NamingConvention(BundleXmlType.Attribute, nameof(PerDocument))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Optional)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        bool PerDocument { get; set; }
        /// <summary>
        /// Multiple values can be specified - Defines the load behavior parameters
        /// for the component with LoadReasons and the exception of the
        /// LoadOnCommandInvocation parameter.
        /// </summary>
        [NamingConvention(BundleXmlType.Attribute, nameof(LoadReasons))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Optional)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        LoadReasons LoadReasons { get; set; }
        /// <summary>
        /// XAML type; currently the only supported value is "ContextualTabRule" and
        /// it is required when a XAML file is assigned to the ModuleName attribute.
        /// The application file that uses the XAML file should be listed after the
        /// ComponentEntry element that contains the XAML file.
        /// </summary>
        [NamingConvention(BundleXmlType.Attribute, nameof(XamlType))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Optional)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        XamlType XamlType { get; set; }
        /// <summary>
        /// A ComponentEntry element may contain a Commands element if the LoadReasons
        /// attribute is set to LoadOnCommandInvocation. The Commands element is
        /// optional unless the LoadOnCommandInvocation parameter is enabled for the
        /// LoadReasons attribute. Used to specify which commands to register for
        /// LoadOnCommandInvocation. You can specify more than one Command element as
        /// needed.
        /// </summary>
        [NamingConvention(BundleXmlType.Element, nameof(Commands))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Optional)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        ICommandGroup Commands { get; set; }

        [NamingConvention(BundleXmlType.Element, nameof(AssemblyMappings))]
        [RequiringConvention(DeploymentTarget.AutodeskAppStore, Status.Optional)]
        [RequiringConvention(DeploymentTarget.Local, Status.Optional)]
        IAssemblyMappings AssemblyMappings { get; set; }
    }
}
