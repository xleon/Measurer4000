using System.Diagnostics;
using Measurer4000.Core.Services.Interfaces;

namespace Measurer4000.Services
{
    public class WebBrowserWpfTaskService : IWebBrowserTaskService
    {
        public void Navigate(string url)
        {
            Process.Start(new ProcessStartInfo(url));
        }
    }
}
