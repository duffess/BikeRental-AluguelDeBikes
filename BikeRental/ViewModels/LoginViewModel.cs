// importa interfaces e funcionalidades do wpf
using System.Windows.Input;
using System.ComponentModel;
using System;

// importa a classe base da viewmodel
using BikeRentalDashboard.ViewModels;

// importa recursos visuais
using System.Windows;

namespace BikeRental.ViewModels
{
    // viewmodel responsavel pela logica da tela de login
    public class LoginViewModel : BaseViewModel
    {
        // propriedades que armazenam o email e senha digitados
        public string Email { get; set; }
        public string Password { get; set; }

        // metodo que valida o login
        public bool ValidateLogin()
        {
            // retorna verdadeiro se o email e a senha forem preenchidos
            // e se forem iguais a "admin" e "1234" (login fixo de exemplo)
            return !string.IsNullOrEmpty(Email) &&
                   !string.IsNullOrEmpty(Password) &&
                   Email == "admin" && Password == "1234";
        }
    }
}
