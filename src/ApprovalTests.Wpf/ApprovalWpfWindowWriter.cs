using System.Windows;
using ApprovalTests.Core;
using ApprovalUtilities.Wpf;

namespace ApprovalTests.Wpf
{
    public class ApprovalWpfWindowWriter : IApprovalWriter
    {
        Window window;

        public ApprovalWpfWindowWriter(Window window)
        {
            this.window = window;
        }

        public virtual string GetApprovalFilename(string basename)
        {
            return $"{basename}.approved.png";
        }

        public virtual string GetReceivedFilename(string basename)
        {
            return $"{basename}.received.png";
        }

        public virtual string WriteReceivedFile(string received)
        {
            WpfUtils.ScreenCapture(window, received);
            return received;
        }
    }
}