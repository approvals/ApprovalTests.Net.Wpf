﻿using System.Threading;
using System.Windows;
using System.Windows.Controls;
using ApprovalTests.Reporters;
using ApprovalTests.Wpf;
using Xunit;

public class ApprovalsTest
{
    [StaFact]
    public void TestFormApproval()
    {
        var button = new Button {Content = "Hello"};
        var window = new Window {Content = button, Width = 200, Height = 200};
        WpfApprovals.Verify(window);
    }

    [StaFact]
    public void TestWindowFunc()
    {
        WpfApprovals.Verify(() => new Window {Content = new Button {Content = "Hello from Lambdas"}, Width = 200, Height = 200});
    }


    [StaFact]
    public void TestContextMenu()
    {
        var menu = new ContextMenu();
        menu.Items.Add(new MenuItem {Header = "Add Element"});
        menu.Items.Add(new MenuItem {Header = "Delete"});
        menu.Items.Add(new MenuItem {Header = "Edit"});
        menu.IsOpen = true;
        WpfApprovals.Verify(menu);
    }

    [StaFact]
    public void TestButton()
    {
        WpfApprovals.Verify(new Button {Content = "Hello"});
    }

    [StaFact]
    public void TestButtonFunc()
    {
        WpfApprovals.Verify(() => new Button {Content = "Hello From Lambdas"});
    }
}