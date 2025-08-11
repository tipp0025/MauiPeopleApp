using MauiPeopleApp.Views;

namespace MauiPeopleApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(PersonDetailPage), typeof(PersonDetailPage));
    }
}