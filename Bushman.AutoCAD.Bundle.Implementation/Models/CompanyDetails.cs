using System.Collections.Generic;
using Bushman.AutoCAD.Bundle.Abstraction.Models;

namespace Bushman.AutoCAD.Bundle.Implementation.Models {

    internal sealed class CompanyDetails : ICompanyDetails {

        public string Name { get; set; }

        public IDictionary<LocaleCode, string> Phone { get; } = new Dictionary<LocaleCode, string>();

        public IDictionary<LocaleCode, string> URL { get; } = new Dictionary<LocaleCode, string>();

        public IDictionary<LocaleCode, string> Email { get; } = new Dictionary<LocaleCode, string>();
    }
}
