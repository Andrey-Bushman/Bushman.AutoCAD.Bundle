using System;
using System.Collections.Generic;
using Bushman.AutoCAD.Bundle.Abstraction.Models;
using Bushman.AutoCAD.Bundle.Abstraction.Validation;

namespace Bushman.AutoCAD.Bundle.Implementation.Validation {
    internal sealed class PackageValidator : IPackageValidator {
        public IPackageValidationResult Validate(IRule[] rules, IApplicationPackage package) {

            if (rules == null) throw new ArgumentNullException(nameof(rules));
            if (package == null) throw new ArgumentNullException(nameof(package));

            var results = new List<IRuleValidationResult>();

            foreach (var rule in rules) {
                var result = rule.Validate(package);
                results.Add(result);
            }

            var pkgValidationResult = new PackageValidationResult(results.ToArray());
            return pkgValidationResult;
        }
    }
}
