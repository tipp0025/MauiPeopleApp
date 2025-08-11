using MauiPeopleApp.Models;
using MauiPeopleApp.ViewModels;

namespace MauiPeopleApp.Views;

public partial class PersonListPage : ContentPage
{
    private PersonListViewModel ViewModel => (PersonListViewModel)BindingContext;

    public PersonListPage()
    {
        InitializeComponent();
        BindingContext = new PersonListViewModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (ViewModel.People.Count == 0)
            ViewModel.LoadPeopleCommand.Execute(null);
    }

    
    private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection?.FirstOrDefault() is not Person selected)
            return;

        if (sender is CollectionView cv) cv.SelectedItem = null;

        await Shell.Current.GoToAsync(nameof(PersonDetailPage),
            new Dictionary<string, object> { ["Person"] = selected });
    }
}