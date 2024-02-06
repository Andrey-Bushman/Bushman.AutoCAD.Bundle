using System;

namespace Bushman.AutoCAD.Bundle.Abstraction.Models {
    /// <summary>
    /// Target AutoCAD or AutoCAD-based products.
    /// Should be used when using APIs specific to one of the AutoCAD-based products
    /// that might not available in AutoCAD or other AutoCAD-based products.
    /// Multiple AutoCAD platforms can be specified by separating the values with
    /// the '|' symbol.
    /// </summary>
    [Flags]
    public enum Platform {
        /// <summary>
        /// AutoCAD Electrical
        /// </summary>
        ACADE = 1,
        /// <summary>
        /// AutoCAD Mechanical
        /// </summary>
        ACADM = 2,
        /// <summary>
        /// AutoCAD LT
        /// </summary>
        ACLT = 4,
        /// <summary>
        /// Architectural Desktop
        /// </summary>
        ADT = 8,
        /// <summary>
        /// Inventor Professional
        /// </summary>
        AIP = 16,
        /// <summary>
        /// Inventor Professional for Routed Systems
        /// </summary>
        AIPRS = 32,
        /// <summary>
        /// Inventor Professional for Simulation
        /// </summary>
        AIPSIM = 64,
        /// <summary>
        /// Inventor Series
        /// </summary>
        AIS = 128,
        /// <summary>
        /// AutoCAD OEM
        /// </summary>
        AOEM = 256,
        /// <summary>
        /// AutoCAD
        /// </summary>
        AutoCAD = 512,
        /// <summary>
        /// AutoCAD* - All AutoCAD-based products
        /// </summary>
        All = 1_024,
        /// <summary>
        /// Autodesk Civil
        /// </summary>
        Civil = 2_048,
        /// <summary>
        /// Autodesk Civil 3D
        /// </summary>
        Civil3D = 4_096,
        /// <summary>
        /// Land Desktop
        /// </summary>
        LDT = 8_192,
        /// <summary>
        /// AutoCAD Map 3D
        /// </summary>
        Map = 16_384,
        /// <summary>
        /// AutoCAD MEP
        /// </summary>
        MEP = 32_768,
        /// <summary>
        /// AutoCAD Plant 3D
        /// </summary>
        Plant3D = 65_536,
        /// <summary>
        /// AutoCAD P & ID - 2D
        /// </summary>
        PNID = 131_072,
    }
}
