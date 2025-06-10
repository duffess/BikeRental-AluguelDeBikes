using System.Windows.Input;
using System.ComponentModel;
using System;
using BikeRentalDashboard.ViewModels;
using System.Windows;

namespace BikeRental.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public bool ValidateLogin()
        {
            return !string.IsNullOrEmpty(Email) &&
                   !string.IsNullOrEmpty(Password) &&
                   Email == "admin" && Password == "1234";
        }
    }

}
