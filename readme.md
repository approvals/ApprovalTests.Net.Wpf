<!--
This file was generate by the CaptureSnippets.
Source File: \readme.source.md
To change this file edit the source file and then re-run the generation using either the dotnet global tool (https://github.com/SimonCropp/CaptureSnippets#githubmarkdownsnippets) or using the api (https://github.com/SimonCropp/CaptureSnippets#running-as-a-unit-test).
-->

# <img src="https://avatars3.githubusercontent.com/u/36907" height="30px"> ApprovalTests.Wpf

Extends [ApprovalTests](https://github.com/approvals/ApprovalTests.Net) for approval of WPF through screenshot verification.


## The NuGet package [![NuGet Status](http://img.shields.io/nuget/v/ApprovalTests.Wpf.svg?style=flat)](https://www.nuget.org/packages/ApprovalTests.Wpf/)

https://nuget.org/packages/ApprovalTests.Wpf/

```ps
PM> Install-Package ApprovalTests.Wpf
```

## Usage

Given the following binding model:

<!-- snippet: model -->
```cs
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
```
<sup>[snippet source](/src/Tests/Snippets/BindsWithoutError.cs#L33-L57)</sup>
<!-- endsnippet -->


### BindsWithoutError

The bindings can be verified using the following:

<!-- snippet: BindsWithoutError -->
```cs
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
```
<sup>[snippet source](/src/Tests/Snippets/BindsWithoutError.cs#L13-L30)</sup>
<!-- endsnippet -->


## Links

 * NuGet: https://nuget.org/packages/ApprovalTests.Wpf/
 * Build: [![Build Status](https://dev.azure.com/approvals/ApprovalTests.Net.Wpf/_apis/build/status/approvals.ApprovalTests.Net.Wpf?branchName=master)](https://dev.azure.com/approvals/ApprovalTests.Net.Wpf/_build/latest?definitionId=3&branchName=master)
