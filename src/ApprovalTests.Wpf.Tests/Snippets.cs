using System;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Data;
using ApprovalTests;
using ApprovalTests.Reporters;
using ApprovalTests.Wpf;
using ApprovalUtilities.Utilities;
using Xunit;

class Snippets
{
    void TestFailedBindings()
    {
        #region BindsWithoutError

        var viewModel = new ViewModel();
        var myBinding = new Binding(ViewModel.MyPropertyPropertyName + "BOGUS")
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
        Approvals.Verify(exception.Message, s => Regex.Replace(s, @"\(HashCode=\d+\)", "(Hashcode)"));

        #endregion
    }
}