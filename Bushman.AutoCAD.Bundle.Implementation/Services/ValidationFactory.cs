using Bushman.AutoCAD.Bundle.Abstraction.Services;
using Bushman.AutoCAD.Bundle.Abstraction.Validation;
using Bushman.AutoCAD.Bundle.Implementation.Validation;

namespace Bushman.AutoCAD.Bundle.Implementation.Services {
    internal sealed class ValidationFactory : IValidationFactory {
        public IRulesProvider CreateRulesProvider() => new RulesProvider();
        public IPackageValidator CreatePackageValidator() => new PackageValidator();
    }
}
