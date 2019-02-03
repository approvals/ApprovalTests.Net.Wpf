using System;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Data;
using ApprovalTests;
using ApprovalTests.Reporters;
using ApprovalTests.Wpf;
using ApprovalUtilities.Utilities;
using Xunit;

[UseReporter(typeof(DiffReporter))]
public class WpfBindingTests
{
    [Fact]
    public void TestFailedBindings()
    {
        Exception e = null;
        StaRunner.Start(() =>
        {
            var viewModel = new TestViewModel();
            var myBinding = new Binding(TestViewModel.MyPropertyPropertyName + "BOGUS")
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