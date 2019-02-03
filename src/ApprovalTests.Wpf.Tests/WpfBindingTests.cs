using System;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Data;
using ApprovalTests;
using ApprovalTests.Wpf;
using ApprovalUtilities.Utilities;
using Xunit;

public class WpfBindingTests
{
    [Fact]
    public void TestFailedBindings()
    {
        Exception e = null;
        StaRunner.Start(() =>
        {
            var viewModel = new ViewModel();
            var myBinding = new Binding(ViewModel.MyPropertyPropertyName + "BOGUS")
            {
                Source = viewModel
            };
            e = ExceptionUtilities.GetException(
                () => WpfBindingsAssert.BindsWithoutError(viewModel,
                    () =>
                    {
                        var textBox = new TextBox();
                        textBox.SetBinding(TextBox.TextProperty, myBinding);
                        return textBox;
                    }));
        });
        Approvals.Verify(e.Message, s => Regex.Replace(s, @"\(HashCode=\d+\)", "(Hashcode)"));
    }
}