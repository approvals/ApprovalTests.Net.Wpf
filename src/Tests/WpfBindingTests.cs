using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Data;
using ApprovalTests;
using ApprovalTests.Wpf;
using ApprovalUtilities.Utilities;
using Xunit;

public class WpfBindingTests
{
    [StaFact]
    public void TestFailedBindings()
    {
        var viewModel = new ViewModel();
        var myBinding = new Binding(ViewModel.MyPropertyPropertyName + "BOGUS")
        {
            Source = viewModel
        };
        var e = ExceptionUtilities.GetException(
            () => WpfBindingsAssert.BindsWithoutError(viewModel,
                () =>
                {
                    var textBox = new TextBox();
                    textBox.SetBinding(TextBox.TextProperty, myBinding);
                    return textBox;
                }));
        Approvals.Verify(e.Message, s => Regex.Replace(s, @"\(HashCode=\d+\)", "(Hashcode)"));
    }

    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public const string MyPropertyPropertyName = "MyProperty";
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
}