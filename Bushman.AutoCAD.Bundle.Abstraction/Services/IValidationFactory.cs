using Bushman.AutoCAD.Bundle.Abstraction.Validation;

namespace Bushman.AutoCAD.Bundle.Abstraction.Services {
    public interface IValidationFactory {
        IRulesProvider CreateRulesProvider();
        IPackageValidator CreatePackageValidator();
    }
}
