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
                MessageBox.Show("Email e senha são obrigatórios.");
                return;
            }

            // MOCK: aceita qualquer email com senha "1234"
            if (Password == "1234")
                MessageBox.Show("Login realizado com sucesso!");
            else
                MessageBox.Show("Email ou senha inválidos.");
        }
    }

}
