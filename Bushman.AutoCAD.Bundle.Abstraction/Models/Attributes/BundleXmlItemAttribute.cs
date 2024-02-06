using System;

namespace Bushman.AutoCAD.Bundle.Abstraction.Models.Attributes {

    [AttributeUsage(AttributeTargets.Interface, AllowMultiple = false)]
    public sealed class BundleXmlItemAttribute : Attribute {

        public BundleXmlItemAttribute(string name) : base() {
            Name = name;
        }

        public string Name { get; }
    }
}
