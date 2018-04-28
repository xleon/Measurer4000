using System;
using AppKit;
using Foundation;

namespace Measurer4000.mac
{
    public partial class MainWindow : NSWindow
    {
        public MainWindow(IntPtr handle) : base(handle)
        {
        }

        [Export("initWithCoder:")]
        public MainWindow(NSCoder coder) : base(coder)
        {
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
        }
    }
}
