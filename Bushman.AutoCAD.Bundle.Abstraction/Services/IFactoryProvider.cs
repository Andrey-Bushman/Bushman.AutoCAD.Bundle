namespace Bushman.AutoCAD.Bundle.Abstraction.Services {
    public interface IFactoryProvider {
        IBundleFactory CreateBundleFactory();
        IValidationFactory CreateValidationFactory();
    }
}
