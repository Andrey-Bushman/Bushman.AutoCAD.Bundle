using System;

namespace Bushman.AutoCAD.Bundle.Abstraction.Models {
    /// <summary>
    /// Multiple values can be specified - Defines the load behavior parameters
    /// for the component with LoadReasons and the exception of the
    /// LoadOnCommandInvocation parameter. By default, LoadOnAutoCADStartup,
    /// LoadOnAppearance, and LoadOnProxy are enabled(set to True) if LoadReasons
    /// is not specified.If parameters need to be disabled (set to False), the
    /// LoadReasons element must be specified along with the parameters set to False.
    /// By default, LoadOnCommandInvocation is disabled, enabling it will disable
    /// LoadOnAutoCADStartup and LoadOnAppearance unless they are explicitly
    /// enabled. If one or more Command elements is defined as part of the Components
    /// element, LoadOnCommandInvocation is implicitly enabled.
    /// </summary>
    [Flags]
    public enum LoadReasons {
        /// <summary>
        /// Load only when a custom commands is invoked. When using this parameter,
        /// a ‘Commands’ element must be included. If LoadOnCommandInvocation is
        /// enabled, LoadOnAutoCADStartup and LoadOnAppearance are assumed to be
        /// disabled unless explicitly enabled. Only applies to AutoLISP, ObjectARX,
        /// and .NET files. Note: For startup performance reasons, it is very important
        /// to use this option when your components define commands.
        /// </summary>
        LoadOnCommandInvocation = 1,
        /// <summary>
        /// Load when the AutoCAD-based product starts up. When specified, this
        /// parameter has precedence over all other parameters. It is recommended only
        /// to use LoadOnAutoCADStartup when none of the other parameters are suitable,
        /// disable it (set it to False) whenever possible. If the LoadOnAutoCADStartup
        /// parameter is omitted, then it defaults to enabled (set to True) unless
        /// LoadOnCommandInvocation is enabled, in which case LoadOnAutoCADStartup
        /// defaults to False. Only applies to VBA Project, ObjectARX, and .NET files.
        /// </summary>
        LoadOnAutoCADStartup = 2,
        /// <summary>
        /// Load when a proxy for a custom entity is detected. By default, this parameter
        /// is enabled unless explicitly disabled (set to False). When enabled (set to
        /// True), LoadOnAutoCADStartup should be disabled. Only applies to ObjectDBX
        /// files.
        /// </summary>
        LoadOnProxy = 4,
        /// <summary>
        /// Load when the product detects the application bundle in one of the
        /// ApplicationPlugins folders, thereby supporting instant load on installation
        /// with no need to restart the AutoCAD-based product. The parameter behaves
        /// the same way as LoadOnAutoCADStartup except the load context is relevant
        /// to when an application is installed while the product is running, for
        /// instance if installed via the Autodesk App Store website.
        /// </summary>
        LoadOnAppearance = 8,
    }
}
