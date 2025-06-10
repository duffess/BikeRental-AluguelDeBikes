using System.Windows;
using BikeRental.ViewModels;

namespace BikeRental.Views
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (LoginViewModel)DataContext;
            viewModel.Password = PasswordBox.Password;

            if (viewModel.ValidateLogin())
            {
                MainWindow main = new MainWindow
                {
                    DataContext = new MainViewModel() 
                };
                main.Show();

                Close();
            }
            else
            {
                MessageBox.Show("Email ou senha inválidos.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AbrirRegistro_Click(object sender, RoutedEventArgs e)
        {
            var register = new MainWindow
            {
                DataContext = new MainViewModel()
            };
            register.Show();

            this.Close();
        }

    }
}
