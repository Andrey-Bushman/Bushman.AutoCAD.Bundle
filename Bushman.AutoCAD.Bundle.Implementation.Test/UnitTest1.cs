using System;
using System.Xml;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bushman.AutoCAD.Bundle.Abstraction.Services;
using Bushman.AutoCAD.Bundle.Abstraction.Models;
using Bushman.AutoCAD.Bundle.Implementation.Services;

namespace Bushman.AutoCAD.Bundle.Implementations.Default.Test {

    [TestClass]
    public class UnitTest1 {

        /// <summary>
        /// TODO: Это не настоящий тест. Это просто черновик для проверки генерации XML на основе объектной модели.
        /// После написания настоящих тестов этот метод будет удалён.
        /// </summary>
        [TestMethod]
        public void TestMethod1() {

            IFactoryProvider factoryProvider = new FactoryProvider();

            var appName = "SomePackage";

            IBundleFactory factory = factoryProvider.CreateBundleFactory();

            var package = factory.CreateInstance<IApplicationPackage>();

            package.Author = "Some developer";

            package.Name.Add(LocaleCode.Enu, appName);
            package.Name.Add(LocaleCode.Rus, appName);

            package.Description.Add(LocaleCode.Enu, "Some AutoCAD extension...");
            package.Description.Add(LocaleCode.Rus, "Некоторое расширение для AutoCAD...");

            package.ProductCode = Guid.NewGuid();
            package.UpgradeCode = Guid.NewGuid();

            package.AppVersion = new Version(1, 0);

            package.Icon = $"/Resources/Images/{appName}.ico";

            package.CompanyDetails.Name = "GPSM";

            foreach (var locale in new[] { LocaleCode.Enu, LocaleCode.Rus }) {

                var lang = locale.ToString().ToUpper();
                package.Helpfile.Add(locale, $"/Help/{lang}/{appName}.{locale.ToString().ToUpper()}.html");

                package.CompanyDetails.Phone.Add(locale, "+7-111-222-33-44");
                package.CompanyDetails.Email.Add(locale, "some.site@yandex.ru");
                package.CompanyDetails.URL.Add(locale, "https://some.site.ru");
            }

            var minCount = 2;
            var maxCount = 5;

            var dependentBundlesCount = new Random().Next(minCount, maxCount);

            for (int i = 1; i <= dependentBundlesCount; i++) {

                var dependentBundle = factory.CreateInstance<IDependentBundle>();

                dependentBundle.UpgradeCode = Guid.NewGuid();
                dependentBundle.VersionMax = new Version(2, 0);
                dependentBundle.VersionMin = new Version(1, 0);

                var componentsCount = new Random().Next(minCount, maxCount);

                for (int j = 1; j <= componentsCount; j++) {
                    var component = factory.CreateInstance<IComponent>();
                    component.AppName = $"Some.Other.Dependent.Bundle_{j}.Name";

                    dependentBundle.Components.Add(component);
                }
                package.DependentBundles.Add(dependentBundle);
            }

            var components = package.Components;

            components.RuntimeRequirements.OS = OS.Win64;
            components.RuntimeRequirements.Platform = Platform.AutoCAD | Platform.Civil3D | Platform.Civil;
            components.RuntimeRequirements.SeriesMax = new Version(2, 0);
            components.RuntimeRequirements.SeriesMin = new Version(1, 0);

            var registryEntriesCount = new Random().Next(minCount, maxCount);

            foreach (var item in new[] {
                new { Name = "SomeRegistryName_1", Type = RegistryEntryType.REG_DWORD, Value = 123.ToString(), Flags = RegistryEntryFlags.Create | RegistryEntryFlags.Open },
                new { Name = "SomeRegistryName_2", Type = RegistryEntryType.REG_QWORD, Value = 456L.ToString(), Flags = RegistryEntryFlags.Create },
                new { Name = "SomeRegistryName_3", Type = RegistryEntryType.REG_EXPAND_SZ, Value = @"%AppData%\SomeDir\SomeFile.json", Flags = RegistryEntryFlags.OpenOnce },
                new { Name = "SomeRegistryName_4", Type = RegistryEntryType.REG_SZ, Value = @"C:\SomeDir2\SomeFile2.json", Flags = RegistryEntryFlags.Open },
            }) {

                var registryEntry = factory.CreateInstance<IRegistryEntry>();

                registryEntry.Name = item.Name;
                registryEntry.Type = item.Type;
                registryEntry.Value = item.Value;
                registryEntry.Flags = item.Flags;

                components.RegistryEntries.Add(registryEntry);
            }

            var systemVariablesCount = new Random().Next(minCount, maxCount);

            foreach (var item in new[] {
                new { Name = "SomeSystemVariableName_1",
                    Owner = "SomeAcRXservice",
                    PrimaryType = VariableType.Int16,
                    StorageType = StorageType.User,
                    Value = $"{123}",
                    Flags = SystemVariableFlags.NoUndo,
                },
                new { Name = "SomeSystemVariableName_11",
                    Owner = "SomeAcRXservice",
                    PrimaryType = VariableType.Int16,
                    StorageType = StorageType.User,
                    Value = $"+{234}",
                    Flags = SystemVariableFlags.SpacesAllowed,
                },
                new { Name = "SomeSystemVariableName_12",
                    Owner = "SomeAcRXservice",
                    PrimaryType = VariableType.Int16,
                    StorageType = StorageType.User,
                    Value = $"-{345}",
                    Flags = SystemVariableFlags.OpenOnce,
                },
                new { Name = "SomeSystemVariableName_13",
                    Owner = "SomeAcRXservice",
                    PrimaryType = VariableType.Int16,
                    StorageType = StorageType.User,
                    Value = $"&{456}",
                    Flags = SystemVariableFlags.Create | SystemVariableFlags.Open,
                },
                new { Name = "SomeSystemVariableName_14",
                    Owner = "SomeAcRXservice",
                    PrimaryType = VariableType.Int16,
                    StorageType = StorageType.User,
                    Value = $"|{567}",
                    Flags = SystemVariableFlags.Create,
                },
                new { Name = "SomeSystemVariableName_2",
                    Owner = "SomeAcRXservice",
                    PrimaryType = VariableType.Int32,
                    StorageType = StorageType.Database,
                    Value = $"{300}",
                    Flags = SystemVariableFlags.DotIsEmpty,
                },
                new { Name = "SomeSystemVariableName_3",
                    Owner = "SomeAcRXservice",
                    PrimaryType = VariableType.Real,
                    StorageType = StorageType.Profile,
                    Value = $"{357.88}",
                    Flags = SystemVariableFlags.Chatty | SystemVariableFlags.Create,
                },
                new { Name = "SomeSystemVariableName_4",
                    Owner = "SomeAcRXservice",
                    PrimaryType = VariableType.String,
                    StorageType = StorageType.Session,
                    Value = $"Bingo",
                    Flags = SystemVariableFlags.SpacesAllowed,
                },
            }) {
                var systemVariable = factory.CreateInstance<ISystemVariable>();

                systemVariable.Name = item.Name;
                systemVariable.Owner = item.Owner;
                systemVariable.PrimaryType = item.PrimaryType;
                systemVariable.StorageType = item.StorageType;
                systemVariable.Value = item.Value;
                systemVariable.Flags = item.Flags;

                components.SystemVariables.Add(systemVariable);
            }

            var environmentVariablesCount = new Random().Next(minCount, maxCount);

            for (int i = 1; i <= environmentVariablesCount; i++) {
                var environmentVariable = factory.CreateInstance<IEnvironmentVariable>();

                environmentVariable.Name = $"SomeEnvironmentVariableName_{i}";
                environmentVariable.Type = VariableType.String;
                environmentVariable.Value = $"SomeEnvironmentVariableValue_{i}";
                environmentVariable.Flags = EnvironmentVariableFlags.Create | EnvironmentVariableFlags.Open;

                components.EnvironmentVariables.Add(environmentVariable);
            }

            foreach (var locale in new[] { LocaleCode.Enu, LocaleCode.Rus }) {

                var lang = locale.ToString().ToUpper();
                components.RuntimeRequirements.SupportPath.Add(locale, $"/{lang}/Resources/Fonts;/{lang}/Resources/Hatches");
                components.RuntimeRequirements.ToolPalettePath.Add(locale, $"/{lang}/Resources/ToolPalettes/Old;/{lang}/Resources/ToolPalettes/New");
            }

            var componentEntriesCount = new Random().Next(minCount, maxCount);

            for (int i = 1; i <= componentEntriesCount; i++) {

                var componentEntry = factory.CreateInstance<IComponentEntry>();
                componentEntry.AppName = $"SomeAppName_{i}";
                componentEntry.AppDescription = $"SomeAppName_{i} description.";
                componentEntry.AppType = AppType.Net;
                componentEntry.PerDocument = i == 1;
                componentEntry.LoadReasons = LoadReasons.LoadOnCommandInvocation | LoadReasons.LoadOnProxy;
                componentEntry.ModuleName.Add(LocaleCode.Enu, $"My.MyAppName.Module_{i}");
                componentEntry.ModuleName.Add(LocaleCode.Rus, $"Мой.Модуль.MyAppName_{i}");

                components.ComponentEntries.Add(componentEntry);

                var asmMapsCount1 = new Random().Next(minCount, maxCount);

                for (int k = 1; k <= asmMapsCount1; k++) {
                    var asmMap = factory.CreateInstance<IAssemblyMapping>();
                    asmMap.Path = $"./bin/win64/SomeAppName_{k}.dll";
                    asmMap.Name = $"SomeAppName_{k}";
                    componentEntry.AssemblyMappings.AssemblyMappings.Add(asmMap);
                }

                var asmMapsCount2 = new Random().Next(minCount, maxCount);

                for (int k = 1; k <= asmMapsCount2; k++) {
                    var asmMapFolder = factory.CreateInstance<IAssemblyMappingFolder>();
                    asmMapFolder.Path = $"./bin/win64/SomeAppName_{k}.dll";
                    componentEntry.AssemblyMappings.AssemblyMappingFolders.Add(asmMapFolder);
                }

                componentEntry.Commands.GroupName = "SomeGroupName";

                var commandsCount = new Random().Next(minCount, maxCount);

                for (int k = 1; k <= commandsCount; k++) {
                    var command = factory.CreateInstance<ICommand>();
                    command.StartupCommand = k == 1;
                    command.Global = $"globName_{k}";
                    command.HelpTopic = $"helpTopic_{k}";
                    command.Local.Add(LocaleCode.Enu, $"test_{k}");
                    command.Local.Add(LocaleCode.Rus, $"тест_{k}");
                    componentEntry.Commands.Commands.Add(command);
                }
            }

            using (var stream = new MemoryStream()) {
                var settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.CloseOutput = false;
                using (var writer = XmlWriter.Create(stream, settings)) {
                    package.WriteXml(writer);
                }
                stream.Flush();
                stream.Seek(0, SeekOrigin.Begin);
                using (var reader = new StreamReader(stream)) {
                    var xml = reader.ReadToEnd(); // TODO: Пока я просто проверил в отладке сформированный XML.
                }
            }
        }
    }
}
