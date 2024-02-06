using System;

namespace Bushman.AutoCAD.Bundle.Abstraction.Models.Attributes {
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class NamingConventionAttribute : Attribute {
        public NamingConventionAttribute(BundleXmlType xmlType, string name = null) : base() {
            XmlType = xmlType;
            Name = name;
        }

        public BundleXmlType XmlType { get; }
        public string Name { get; }
    }
}
