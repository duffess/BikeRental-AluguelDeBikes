﻿using System.Windows;
using BikeRental.Models;
using BikeRental.Services;
using BikeRental.Models;

namespace BikeRental.Views
{
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void Registrar_Click(object sender, RoutedEventArgs e)
        {
            string nome = NomeBox.Text;
            string email = EmailBox.Text;
            string senha = SenhaBox.Password;

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show("Todos os campos são obrigatórios.");
                return;
            }

            if (UserService.EmailExiste(email))
            {
                MessageBox.Show("Email já registrado.");
                return;
            }

           

            MessageBox.Show("Usuário registrado com sucesso!");

            var login = new LoginWindow();
            login.Show();
            this.Close();
        }
    }
}
