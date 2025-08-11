namespace MauiPeopleApp.ViewModels;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;

public partial class LoginViewModel : ObservableObject
{
    [RelayCommand]
    public async Task LoginWithFingerprint()
    {
        bool isAvailable;
        try
        {
            isAvailable = await CrossFingerprint.Current.IsAvailableAsync(allowAlternativeAuthentication: true);
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            return;
        }

        if (!isAvailable)
        {
            await Shell.Current.DisplayAlert("Unavailable", "Biometric authentication not available on this device.", "OK");
            return;
        }

        var request = new AuthenticationRequestConfiguration(
            "Authentication",
            "Authenticate to continue"
        )
        {
            CancelTitle = "Cancel",
            FallbackTitle = "Use PIN",           
            AllowAlternativeAuthentication = true 
        };

        var result = await CrossFingerprint.Current.AuthenticateAsync(request);

        if (result.Authenticated)
        {
            await Shell.Current.GoToAsync("//People");
        }
        else
        {
            await Shell.Current.DisplayAlert("Failed", "Authentication failed or was canceled.", "OK");
        }
    }
}