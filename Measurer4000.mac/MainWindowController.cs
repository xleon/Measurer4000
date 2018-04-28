using System;
using System.ComponentModel;
using System.Globalization;
using AppKit;
using Foundation;
using Measurer4000.Core.ViewModel;

namespace Measurer4000.mac
{
	public partial class MainWindowController : NSWindowController
    {
        private MainViewModel _dataContext;

        
        public MainWindowController(IntPtr handle) : base(handle)
        {            
        }

        [Export("initWithCoder:")]
        public MainWindowController(NSCoder coder) : base(coder)
        {
        }

        public MainWindowController() : base("MainWindow")
        {
            _dataContext = new MainViewModel();
            _dataContext.PropertyChanged -= DataContextPropertyChanged;
            _dataContext.PropertyChanged += DataContextPropertyChanged;            
        }

        private void DataContextPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "IsBusy")
            {
                ButtonOpenFile.Enabled = !_dataContext.IsBusy;
                ButtonShareLink.Enabled = !_dataContext.IsBusy;
                if(_dataContext.IsBusy)
                {
                    ProgressBar.StartAnimation(this);
                    
                }
                else
                {
                    ProgressBar.StopAnimation(this);
                    GatherValuesFromSolution();
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            _dataContext.PropertyChanged -= DataContextPropertyChanged;
            base.Dispose(disposing);
        }

        public override void WindowDidLoad()
        {
            ButtonShareLink.Enabled = true;
            base.WindowDidLoad();
        }
        
        public new MainWindow Window => (MainWindow)base.Window;

        partial void ButtonOpenFileClick(NSObject sender)
        {
            _dataContext.CommandSelectFile.Execute(null);
        }

        partial void ButtonShareLinkClick(NSObject sender)
        {
            _dataContext.CommandShareLink.Execute(null);
        }
                
        private void GatherValuesFromSolution()
        {                                    
            AmountOfFiles.StringValue = _dataContext.Stats.AmountOfFiles.ToString();
			CodeFiles.StringValue = _dataContext.Stats.CodeFiles.ToString();
			TotalLOC.StringValue = _dataContext.Stats.TotalLinesOfCode.ToString();
            TotalUILines.StringValue = _dataContext.Stats.TotalLinesOfUi.ToString();
            UIFiles.StringValue = _dataContext.Stats.UiFiles.ToString();                     

			CoreLOC.StringValue = _dataContext.Stats.TotalLinesCore.ToString();

			AndroidFiles.StringValue = _dataContext.Stats.AndroidFiles.ToString();
            AndroidLOC.StringValue = _dataContext.Stats.TotalLinesInAndroid.ToString();
			ShareCodeInAndroid.StringValue = _dataContext.Stats.ShareCodeInAndroid.ToString("F2", CultureInfo.InvariantCulture);
			AndroidSpecificCode.StringValue = _dataContext.Stats.AndroidSpecificCode.ToString("F2", CultureInfo.InvariantCulture);         
            
            iOSFiles.StringValue = _dataContext.Stats.IOsFiles.ToString();
            iOSLOC.StringValue = _dataContext.Stats.TotalLinesIniOs.ToString();
			ShareCodeIniOS.StringValue = _dataContext.Stats.ShareCodeIniOs.ToString("F2", CultureInfo.InvariantCulture);
			iOSSpecificCode.StringValue = _dataContext.Stats.IOsSpecificCode.ToString("F2", CultureInfo.InvariantCulture);

			UWPFiles.StringValue = _dataContext.Stats.UwpFiles.ToString();
			UWPLOC.StringValue = _dataContext.Stats.TotalLinesInUwp.ToString();
			ShareCodeInUWP.StringValue = _dataContext.Stats.ShareCodeInUwp.ToString("F2", CultureInfo.InvariantCulture);
			UWPSpecificCode.StringValue = _dataContext.Stats.UwpSpecificCode.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
