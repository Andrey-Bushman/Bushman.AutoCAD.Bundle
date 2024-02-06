using System;
using Bushman.AutoCAD.Bundle.Abstraction.Validation;

namespace Bushman.AutoCAD.Bundle.Implementation.Validation {
    internal sealed class RuleValidationResult : IRuleValidationResult {

        public IRule Rule { get; internal set; }

        public string Message { get; internal set; }

        public ValidationStatus Status { get; internal set; }

        public DateTime StartedOn { get; internal set; }

        public DateTime FinishedOn { get; internal set; }
    }
}
