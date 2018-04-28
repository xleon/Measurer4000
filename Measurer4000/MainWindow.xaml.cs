using System.Windows;
using Measurer4000.Core.ViewModel;

namespace Measurer4000
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainViewModel();
        }        
    }
}