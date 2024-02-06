using System.Collections.Generic;
using System.Linq;
using Bushman.AutoCAD.Bundle.Abstraction.Validation;

namespace Bushman.AutoCAD.Bundle.Implementation.Validation {
    internal sealed class RulesProvider : IRulesProvider {

        private readonly IList<IRule> _rules = new List<IRule>();

        public RulesProvider() {
            // TODO: Нужно сформировать набор правил на основе официальной документации и реализовать их в _rules.
        }

        public IRule[] GetRules() => _rules.ToArray();
    }
}
