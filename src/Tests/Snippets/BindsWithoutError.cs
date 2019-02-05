using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Data;
using ApprovalTests.Wpf;
using ApprovalUtilities.Utilities;
using Xunit;

class BindsWithoutError
{
    void TestFailedBindings()
    {
        #region BindsWithoutError

        var viewModel = new ViewModel();
        var myBinding = new Binding(nameof(ViewModel.MyProperty))
        {
            Source = viewModel
        };
        var exception = ExceptionUtilities.GetException(
            () => WpfBindingsAssert.BindsWithoutError(viewModel,
                () =>
                {
                    var textBox = new TextBox();
                    textBox.SetBinding(TextBox.TextProperty, myBinding);
                    return textBox;
                }));
        Assert.Null(exception);

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