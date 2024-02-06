using Bushman.AutoCAD.Bundle.Abstraction.Models;
using Bushman.AutoCAD.Bundle.Abstraction.Services;
using System;

namespace Bushman.AutoCAD.Bundle.Implementation.Models {
    internal sealed class BundleFactory : IBundleFactory {
        public T CreateInstance<T>() where T : class {

            object instance = null;

            switch (typeof(T).Name) {
                case nameof(IApplicationPackage): {
                        instance = new ApplicationPackage();
                        break;
                    }
                case nameof(ICompanyDetails): {
                        instance = new CompanyDetails();
                        break;
                    }
                case nameof(IDependentBundle): {
                        instance = new DependentBundle();
                        break;
                    }
                case nameof(IComponent): {
                        instance = new Component();
                        break;
                    }
                case nameof(IComponents): {
                        instance = new Components();
                        break;
                    }
                case nameof(IRuntimeRequirements): {
                        instance = new RuntimeRequirements();
                        break;
                    }
                case nameof(IRegistryEntry): {
                        instance = new RegistryEntry();
                        break;
                    }
                case nameof(ISystemVariable): {
                        instance = new SystemVariable();
                        break;
                    }
                case nameof(IEnvironmentVariable): {
                        instance = new EnvironmentVariable();
                        break;
                    }
                case nameof(IComponentEntry): {
                        instance = new ComponentEntry();
                        break;
                    }
                case nameof(IAssemblyMappingFolder): {
                        instance = new AssemblyMappingFolder();
                        break;
                    }
                case nameof(IAssemblyMapping): {
                        instance = new AssemblyMapping();
                        break;
                    }
                case nameof(ICommandGroup): {
                        instance = new CommandGroup();
                        break;
                    }
                case nameof(ICommand): {
                        instance = new Command();
                        break;
                    }
                default: throw new ArgumentException($"Недопустимый тип {typeof(T).FullName}.");
            }
            return instance as T;
        }
    }
}
