using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Data;
using ApprovalTests.Wpf;
using ApprovalUtilities.Utilities;
using Xunit;

public class VerifyControl
{
    [Fact]
   public  void TestFailedBindings()
    {
        #region VerifyControls
        WpfApprovals.Verify(new Button());

        #endregion
    }

    #region Model

    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        string myProperty;

        public string MyProperty
        {
            get => myProperty;
            set
            {
                myProperty = value;
                RaisePropertyChanged();
            }
        }

        void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    #endregion
}