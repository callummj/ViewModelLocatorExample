using MAUI.MVVM;
using MAUI.Resources;

namespace MAUI;

public partial class App : Application
{
	private readonly DependencyInjectionContainer m_container = new DependencyInjectionContainer();
	private readonly ViewModelLocator m_viewModelLocator;

    public App()
	{
		InitializeComponent();

		const string viewModelLocatorKey = "ViewModelLocator"; // This is what we called the key in the static resouces

        // In application or main window, get the reference to the viewmodelLocator, which will be called implicity.
        //object viewmModelLocatorObj;
        //if (!this.Resources.TryGetValue(viewModelLocatorKey, out viewmModelLocatorObj))
        //{
        //	throw new InvalidProgramException("Could not find view model locator key in Application resource");
        //	return;
        //}

        //m_viewModelLocator = (ViewModelLocator)viewmModelLocatorObj;

        m_viewModelLocator = new ViewModelLocator(m_container);

        //var viewModelLocator = new ViewModelLocator();
		this.Resources.Add(viewModelLocatorKey, m_viewModelLocator);

        MainPage = new AppShell();
	}
}
