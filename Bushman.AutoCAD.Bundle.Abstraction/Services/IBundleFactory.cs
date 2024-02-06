namespace Bushman.AutoCAD.Bundle.Abstraction.Services {
    /// <summary>
    /// Интерфейс для создания экземпляров интерфейсов,
    /// определённых в пространстве Bushman.AutoCAD.Bundle.Abstraction.Models.
    /// </summary>
    public interface IBundleFactory {
        /// <summary>
        /// Создать экземпляр указанного типа.
        /// </summary>
        /// <typeparam name="T">Тип, экземпляр которого необходимо создать.</typeparam>
        /// <returns>Возвращается экземпляр класса, реализующего указанный интерфейс.</returns>
        T CreateInstance<T>() where T : class;
    }
}
