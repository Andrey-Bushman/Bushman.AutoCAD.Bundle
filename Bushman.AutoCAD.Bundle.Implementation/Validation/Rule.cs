using System;
using Bushman.AutoCAD.Bundle.Abstraction.Models;
using Bushman.AutoCAD.Bundle.Abstraction.Validation;

namespace Bushman.AutoCAD.Bundle.Implementation.Validation {
    internal sealed class Rule : IRule {

        public Rule(Func<IApplicationPackage, IRuleValidationResult> func, string name, string description, string url) {
            Name = name;
            Description = description;
            Url = url;
            _func = func;
        }

        private readonly Func<IApplicationPackage, IRuleValidationResult> _func;

        public string Name { get; }

        public string Description { get; }

        public string Url { get; }

        public IRuleValidationResult Validate(IApplicationPackage package) => _func(package);
    }
}
