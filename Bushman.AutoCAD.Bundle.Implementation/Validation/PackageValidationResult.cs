using System;
using System.Linq;
using Bushman.AutoCAD.Bundle.Abstraction.Validation;

namespace Bushman.AutoCAD.Bundle.Implementation.Validation {
    internal sealed class PackageValidationResult : IPackageValidationResult {

        public PackageValidationResult(IRuleValidationResult[] results) {
            Results = results;
        }

        public ValidationStatus Status {
            get {
                if (Results.Any(n => n.Status == ValidationStatus.Fail)) return ValidationStatus.Fail;
                else if (Results.Any(n => n.Status == ValidationStatus.Warning)) return ValidationStatus.Warning;
                else if (Results.All(n => n.Status == ValidationStatus.Success)) return ValidationStatus.Success;
                else throw new Exception("Не удалось вычислить общий статус валидации пакета.");
            }
        }

        public IRuleValidationResult[] Results { get; }
    }
}
