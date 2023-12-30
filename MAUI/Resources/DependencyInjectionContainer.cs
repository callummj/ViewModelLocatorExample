using Microsoft.Extensions.DependencyInjection;

namespace MAUI.Resources
{
    public class DependencyInjectionContainerException : Exception
    {
        public DependencyInjectionContainerException(string message) : base(message) { }
    }

    public class DependencyInjectionContainer
    {
        private volatile bool m_isBuilt = false;
        private IServiceCollection m_serviceCollection = new ServiceCollection();
        private IServiceProvider m_serviceProvider = null;

        public DependencyInjectionContainer()
        {

        }


        #region Registering dependencies

        public void RegisterScopedDependency<TInterface, TImplementation>()
        {
            try
            {
                m_serviceCollection.AddScoped(typeof(TInterface), typeof(TImplementation));
                m_isBuilt = false;
            }
            catch (Exception ex)
            {
                throw new DependencyInjectionContainerException($"Could not add scoped dependency for interface type {typeof(TInterface)} as implementation type: {typeof(TImplementation)}. Reason: {ex.Message}");
            }
        }

        public void RegisterTransientDependency<TInterface, TImplementation>()
        {
            try
            {
                m_serviceCollection.AddTransient(typeof(TInterface), typeof(TImplementation));
                m_isBuilt = false;
            }
            catch (Exception ex)
            {
                throw new DependencyInjectionContainerException($"Could not add transient dependency for interface type {typeof(TInterface)} as implementation type: {typeof(TImplementation)}. Reason: {ex.Message}");
            }
        }

        public void RegisterSingletonDependency<TInterface, TImplementation>()
        {
            try
            {
                m_serviceCollection.AddSingleton(typeof(TInterface), typeof(TImplementation));
                m_isBuilt = false;
            }
            catch (Exception ex)
            {
                throw new DependencyInjectionContainerException($"Could not add singleton dependency for interface type {typeof(TInterface)} as implementation type: {typeof(TImplementation)}. Reason: {ex.Message}");
            }
        }

        #endregion

        public TImplementation Resolve<TImplementation>()
        {
            if (!m_isBuilt)
            {
                throw new DependencyInjectionContainerException("Attempted to resolve dependency before collection was built.");
            }

            TImplementation result = m_serviceProvider.GetService<TImplementation>();
            if (result == null)
            {
                throw new DependencyInjectionContainerException($"Could not resolve dependency: {nameof(TImplementation)}");
            }

            return result;
        }
    }
}
