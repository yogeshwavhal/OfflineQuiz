


namespace Laxsan
{
    using Laxsan.DataAccess;
    using Unity;
    using Unity.Lifetime;

    public static class ContainerHelper
    {
        #region Private Fields

        private static IUnityContainer _container;

        #endregion Private Fields

        #region Constructor
        static ContainerHelper()
        {
            _container = new UnityContainer();
            _container.RegisterType<IUnitOfWork , UnitOfWork>(
                new ContainerControlledLifetimeManager());
        }
        #endregion

        #region Public Properties

        public static IUnityContainer Container
        {
            get { return _container; }
        }

        #endregion
    }
}
