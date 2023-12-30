using MAUI.Resources;
using MAUI.ViewModel;

namespace MAUI.MVVM
{
    public class ViewModelLocator
    {
        private readonly DependencyInjectionContainer m_dependencyInjectionContainer;

        public ViewModelLocator(DependencyInjectionContainer dependencyInjectionContainer)
        {
            m_dependencyInjectionContainer = dependencyInjectionContainer;
        }

        IViewModel MainViewModel => m_dependencyInjectionContainer.Resolve<IMainViewModel>();
    }
}
