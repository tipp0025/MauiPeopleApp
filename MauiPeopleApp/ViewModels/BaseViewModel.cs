using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiPeopleApp.ViewModels;

public class BaseViewModel : INotifyPropertyChanged
{
    private bool isBusy;

    public bool IsBusy
    {
        get => isBusy;
        set => SetProperty(ref isBusy, value);
    }

    // Nullable because there may be no subscribers yet.
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    protected bool SetProperty<T>(
        ref T backingStore,
        T value,
        [CallerMemberName] string? propertyName = null,
        Action? onChanged = null)
    {
        if (EqualityComparer<T>.Default.Equals(backingStore, value))
            return false;

        backingStore = value;
        onChanged?.Invoke();
        OnPropertyChanged(propertyName);
        return true;
    }
}