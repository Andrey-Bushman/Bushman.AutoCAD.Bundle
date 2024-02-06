using Bushman.AutoCAD.Bundle.Abstraction.Models;

namespace Bushman.AutoCAD.Bundle.Abstraction.Validation {
    public interface IPackageValidator {
        IPackageValidationResult Validate(IRule[] rules, IApplicationPackage package);
    }
}
