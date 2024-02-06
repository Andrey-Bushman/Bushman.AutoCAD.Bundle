using Bushman.AutoCAD.Bundle.Abstraction.Services;
using Bushman.AutoCAD.Bundle.Implementation.Models;

namespace Bushman.AutoCAD.Bundle.Implementation.Services {
    public sealed class FactoryProvider : IFactoryProvider {
        public IBundleFactory CreateBundleFactory() => new BundleFactory();

        public IValidationFactory CreateValidationFactory() => new ValidationFactory();
    }
}
