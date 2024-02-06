using Bushman.AutoCAD.Bundle.Abstraction.Models;
using Bushman.AutoCAD.Bundle.Abstraction.Models.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Schema;

namespace Bushman.AutoCAD.Bundle.Implementation.Models {
    internal sealed class ApplicationPackage : IApplicationPackage {
        public Version SchemaVersion { get; set; } = new Version(1, 0);
        public Version AppVersion { get; set; } = new Version(1, 0);
        public string Author { get; set; }
        public IDictionary<LocaleCode, string> Name { get; } = new Dictionary<LocaleCode, string>();
        public IDictionary<LocaleCode, string> Description { get; } = new Dictionary<LocaleCode, string>();
        public string Icon { get; set; }
        public IDictionary<LocaleCode, string> Helpfile { get; } = new Dictionary<LocaleCode, string>();
        public Guid ProductCode { get; set; } = Guid.Empty;
        public Guid UpgradeCode { get; set; } = Guid.Empty;
        public ICompanyDetails CompanyDetails { get; } = new CompanyDetails();
        public IComponents Components { get; } = new Components();
        public IList<IDependentBundle> DependentBundles { get; } = new List<IDependentBundle>();

        public XmlSchema GetSchema() => null;

        public void ReadXml(XmlReader reader) {
            throw new NotImplementedException();
        }

        public void WriteXml(XmlWriter writer) {

            if (writer == null) throw new ArgumentNullException(nameof(writer));

            var asm = typeof(IApplicationPackage).Assembly;
            var interfaces = asm.GetTypes().Where(n => n.IsInterface).ToArray();

            writer.WriteStartElement(typeof(IApplicationPackage).Name.Substring(1));
            FillElement(interfaces, writer, this);
            writer.WriteEndElement();
        }

        private void FillElement(Type[] asmInterfaces, XmlWriter writer, object instance) {

            if (asmInterfaces == null) throw new ArgumentNullException(nameof(asmInterfaces));
            if (writer == null) throw new ArgumentNullException(nameof(writer));
            if (instance == null) throw new ArgumentNullException(nameof(instance));

            var instanceInterface = instance.GetType().GetInterfaces().FirstOrDefault(n => asmInterfaces.Contains(n));

            if (instanceInterface != null) {
                var interfaceProps = instanceInterface.GetProperties();
                var instanceProps = instance.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

                foreach (var interfaceProp in interfaceProps.Where(n => n.GetCustomAttribute<NamingConventionAttribute>()
                    .XmlType == BundleXmlType.Attribute)) {

                    var instanceProp = instanceProps.First(n => n.Name == interfaceProp.Name);

                    if (instanceProp.PropertyType == typeof(string)
                        || instanceProp.PropertyType == typeof(Guid)
                        || instanceProp.PropertyType == typeof(Version)
                        || instanceProp.PropertyType == typeof(bool)
                        || instanceProp.PropertyType == typeof(object)
                        || instanceProp.PropertyType.IsEnum) {

                        if (instanceProp.PropertyType.IsEnum) {

                            string value = null;

                            if (instanceProp.PropertyType == typeof(AppType) && (AppType)instanceProp.GetValue(instance) == AppType.Net) {
                                value = ".NET";
                            }
                            else if (instanceProp.PropertyType == typeof(Platform) && (Platform)instanceProp.GetValue(instance) == Platform.All) {
                                value = "AutoCAD*";
                            }
                            else {
                                value = instanceProp.GetValue(instance)?.ToString();
                            }
                            value = value?.Replace(", ", "|");
                            writer.WriteAttributeString(interfaceProp.Name, value);
                        }
                        else {
                            writer.WriteAttributeString(interfaceProp.Name, instanceProp.GetValue(instance).ToString());
                        }

                    }
                    else if (instanceProp.PropertyType == typeof(IDictionary<LocaleCode, string>)) {
                        var dict = instanceProp.GetValue(instance) as IDictionary<LocaleCode, string>;
                        foreach (var kvp in dict) {
                            writer.WriteAttributeString($"{interfaceProp.Name}{kvp.Key}", kvp.Value);
                        }
                    }
                    else {
                        throw new Exception("Непредвиденный тип значения атрибута!");
                    }
                }

                foreach (var interfaceProp in interfaceProps.Where(n => n.GetCustomAttribute<NamingConventionAttribute>()
                    .XmlType == BundleXmlType.Element)) {

                    var instanceProp = instanceProps.First(n => n.Name == interfaceProp.Name);

                    var value = instanceProp.GetValue(instance);

                    if ((value is IList && (value as IList).Count > 0) || !(value is IList)) {
                        writer.WriteStartElement(interfaceProp.Name);
                        FillElement(asmInterfaces, writer, value);
                        writer.WriteEndElement();
                    }
                }

                foreach (var interfaceProp in interfaceProps.Where(n => n.GetCustomAttribute<NamingConventionAttribute>()
                    .XmlType == BundleXmlType.Items)) {

                    var instanceProp = instanceProps.First(n => n.Name == interfaceProp.Name);
                    FillElement(asmInterfaces, writer, instanceProp.GetValue(instance));
                }
            }
            else if (instance is IList) {
                foreach (var item in instance as IList) {
                    var itemInterface = item.GetType().GetInterfaces().FirstOrDefault(n => asmInterfaces.Contains(n));
                    writer.WriteStartElement(itemInterface.Name.Substring(1));
                    FillElement(asmInterfaces, writer, item);
                    writer.WriteEndElement();
                }
            }
        }
    }
}
