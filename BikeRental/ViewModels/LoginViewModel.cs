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

        public RelayCommand LoginCommand { get; }
        public Action<object, EventArgs> LoginSucceeded { get; internal set; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(param => AutenticarLogin());
        }

        private void AutenticarLogin()
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show("Preencha todos os campos.");
                return;
            }

            if (Email == "admin@admin.com" && Password == "1234")
            {
                LoginSucceeded?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show("E-mail ou senha inválidos.");
            }
        }
    }

}
