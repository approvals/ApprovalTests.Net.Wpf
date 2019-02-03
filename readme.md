# <img src="https://avatars3.githubusercontent.com/u/36907" height="30px"> ApprovalTests.Wpf

Extends [ApprovalTests](https://github.com/approvals/ApprovalTests.Net) for approval of WPF through screenshot verification.


## The NuGet package [![NuGet Status](http://img.shields.io/nuget/v/ApprovalTests.Wpf.svg?style=flat)](https://www.nuget.org/packages/ApprovalTests.Wpf/)

https://nuget.org/packages/ApprovalTests.Wpf/

```ps
PM> Install-Package ApprovalTests.Wpf
```

## Usage

<!-- snippet: model -->
```cs
public class ViewModel : INotifyPropertyChanged
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
```
<sup>[snippet source](/src/ApprovalTests.Wpf.Tests/ViewModel.cs#L4-L27)</sup>
<!-- endsnippet -->


### BindsWithoutError

<!-- snippet: BindsWithoutError -->
```cs
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
```
<sup>[snippet source](/src/ApprovalTests.Wpf.Tests/WpfBindingTests - Copy.cs#L15-L32)</sup>
<!-- endsnippet -->


## Links

 * NuGet: https://nuget.org/packages/ApprovalTests.Wpf/
 * Build: [![Build Status](https://dev.azure.com/approvals/ApprovalTests.Net.Wpf/_apis/build/status/approvals.ApprovalTests.Net.Wpf?branchName=master)](https://dev.azure.com/approvals/ApprovalTests.Net.Wpf/_build/latest?definitionId=3&branchName=master)
