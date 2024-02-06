using System;

namespace Bushman.AutoCAD.Bundle.Abstraction.Validation {
    public interface IRuleValidationResult {
        IRule Rule { get; }
        string Message { get; }
        ValidationStatus Status { get; }
        DateTime StartedOn { get; }
        DateTime FinishedOn { get; }
    }
}
