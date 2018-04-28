using System.Windows;
using Measurer4000.Core.Services;
using Measurer4000.Core.Services.Interfaces;
using Measurer4000.Services;

namespace Measurer4000
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            ServiceLocator.Register<IDialogService>(new FileDialogService());
            ServiceLocator.Register<IMeasurerService>(new MeasureService(new FileManagerService()));
            ServiceLocator.Register<IWebBrowserTaskService>(new WebBrowserWpfTaskService());
        }
        
    }
}
