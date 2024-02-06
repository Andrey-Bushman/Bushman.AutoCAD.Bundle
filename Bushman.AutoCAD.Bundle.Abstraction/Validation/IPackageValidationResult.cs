namespace Bushman.AutoCAD.Bundle.Abstraction.Validation {
    public interface IPackageValidationResult {
        ValidationStatus Status { get; }
        IRuleValidationResult[] Results { get; }
    }
}
