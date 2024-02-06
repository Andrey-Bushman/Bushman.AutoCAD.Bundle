using Bushman.AutoCAD.Bundle.Abstraction.Models;

namespace Bushman.AutoCAD.Bundle.Abstraction.Validation {
    public interface IRule {
        string Name { get; }
        string Description { get; }
        string Url { get; }
        IRuleValidationResult Validate(IApplicationPackage package);
    }
}
