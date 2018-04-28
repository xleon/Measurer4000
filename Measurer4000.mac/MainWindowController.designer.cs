// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//

using AppKit;
using Foundation;

namespace Measurer4000.mac
{
	[Register ("MainWindowController")]
	partial class MainWindowController
	{
		[Outlet]
		NSTextField AmountOfFiles { get; set; }

		[Outlet]
		NSTextField AndroidFiles { get; set; }

		[Outlet]
		NSTextField AndroidLOC { get; set; }

		[Outlet]
		NSButton ButtonOpenFile { get; set; }

		[Outlet]
		NSButton ButtonShareLink { get; set; }

		[Outlet]
		NSTextField CodeFiles { get; set; }

		[Outlet]
		NSTextField CoreLOC { get; set; }

		[Outlet]
		NSTextField iOSFiles { get; set; }

		[Outlet]
		NSTextField iOSLOC { get; set; }
              
		[Outlet]
        NSTextField UWPFiles { get; set; }

        [Outlet]
        NSTextField UWPLOC { get; set; }            

		[Outlet]
		NSProgressIndicator ProgressBar { get; set; }

		[Outlet]
		NSTextField ShareCodeInAndroid { get; set; }

		[Outlet]
		NSTextField ShareCodeIniOS { get; set; }

		[Outlet]
		NSTextField ShareCodeInUWP { get; set; }

		[Outlet]
		NSTextField ShareLink { get; set; }

		[Outlet]
		NSTextField AndroidSpecificCode { get; set; }

		[Outlet]
		NSTextField iOSSpecificCode { get; set; }

		[Outlet]
        NSTextField UWPSpecificCode { get; set; }

		[Outlet]
		NSTextField TotalLOC { get; set; }

		[Outlet]
		NSTextField TotalUILines { get; set; }

		[Outlet]
		NSTextField UIFiles { get; set; }

		[Action ("ButtonOpenFileClick:")]
		partial void ButtonOpenFileClick (NSObject sender);

		[Action ("ButtonShareLinkClick:")]
		partial void ButtonShareLinkClick (NSObject sender);

		[Action ("ShareLinkClick:")]
		partial void ShareLinkClick (NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (AmountOfFiles != null) {
				AmountOfFiles.Dispose ();
				AmountOfFiles = null;
			}

			if (AndroidFiles != null) {
				AndroidFiles.Dispose ();
				AndroidFiles = null;
			}

			if (AndroidLOC != null) {
				AndroidLOC.Dispose ();
				AndroidLOC = null;
			}

			if (ButtonOpenFile != null) {
				ButtonOpenFile.Dispose ();
				ButtonOpenFile = null;
			}

			if (ButtonShareLink != null) {
				ButtonShareLink.Dispose ();
				ButtonShareLink = null;
			}

			if (CodeFiles != null) {
				CodeFiles.Dispose ();
				CodeFiles = null;
			}

			if (CoreLOC != null) {
				CoreLOC.Dispose ();
				CoreLOC = null;
			}

			if (iOSFiles != null) {
				iOSFiles.Dispose ();
				iOSFiles = null;
			}

			if (iOSLOC != null) {
				iOSLOC.Dispose ();
				iOSLOC = null;
			}

                     
			if (UWPFiles != null)
            {
				UWPFiles.Dispose();
				UWPFiles = null;
            }

			if (UWPLOC != null)
            {
				UWPLOC.Dispose();
				UWPLOC = null;
            }

			if (ProgressBar != null) {
				ProgressBar.Dispose ();
				ProgressBar = null;
			}

			if (ShareCodeInAndroid != null) {
				ShareCodeInAndroid.Dispose ();
				ShareCodeInAndroid = null;
			}

			if (ShareCodeIniOS != null) {
				ShareCodeIniOS.Dispose ();
				ShareCodeIniOS = null;
			}
                     
			if (ShareCodeInUWP != null)
            {
				ShareCodeInUWP.Dispose();
				ShareCodeInUWP = null;
            }

			if (ShareLink != null) {
				ShareLink.Dispose ();
				ShareLink = null;
			}

			if (AndroidSpecificCode != null) {
				AndroidSpecificCode.Dispose ();
				AndroidSpecificCode = null;
			}

			if (iOSSpecificCode != null) {
				iOSSpecificCode.Dispose ();
				iOSSpecificCode = null;
			}

			if (UWPSpecificCode != null)
            {
				UWPSpecificCode.Dispose();
				UWPSpecificCode = null;
            }

			if (TotalLOC != null) {
				TotalLOC.Dispose ();
				TotalLOC = null;
			}

			if (TotalUILines != null) {
				TotalUILines.Dispose ();
				TotalUILines = null;
			}

			if (UIFiles != null) {
				UIFiles.Dispose ();
				UIFiles = null;
			}
		}
	}
}
