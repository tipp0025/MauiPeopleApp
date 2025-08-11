using MauiPeopleApp.Models;

namespace MauiPeopleApp.Views;

[QueryProperty(nameof(Person), "Person")]
public partial class PersonDetailPage : ContentPage
{
    private Person? person;

    public Person? Person
    {
        get => person;
        set
        {
            person = value;
            BindingContext = person;
        }
    }

    public PersonDetailPage()
    {
        InitializeComponent();
    }
}