using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using horse_riding_school.Models;
using horse_riding_school.Services;
using horse_riding_school.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace horse_riding_school.ViewModels
{
    public partial class LoginPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _email;

        [ObservableProperty]
        private string _password;

        readonly IUserService _userService = new UserService();

        [RelayCommand]
        public async void Login()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(Email) || !string.IsNullOrWhiteSpace(Password))
                {
                    User user = await _userService.Login(Email, Password);
                    if (user != null)
                    {
                        Preferences.Set(nameof(App._user), user.Name);
                        App._user = user;
                        await Shell.Current.GoToAsync(nameof(HomePage));
                    }
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
                throw;
            }
        
        }
    }
}
