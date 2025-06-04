using System;
using System.ComponentModel;
using System.Windows.Input;

namespace BikeRental.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string email;
        private string password;
        private string errorMessage;
        private Action onLoginSuccess;

        public LoginViewModel(Action onLoginSuccessCallback)
        {
            onLoginSuccess = onLoginSuccessCallback;
            LoginCommand = new RelayCommand(Login, CanLogin);
        }

        public string Email
        {
            get => email;
            set
            {
                if (email != value)
                {
                    email = value;
                    OnPropertyChanged(nameof(Email));
                    ((RelayCommand)LoginCommand).RaiseCanExecuteChanged();
                }
            }
        }

        public string Password
        {
            get => password;
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged(nameof(Password));
                    ((RelayCommand)LoginCommand).RaiseCanExecuteChanged();
                }
            }
        }

        public string ErrorMessage
        {
            get => errorMessage;
            set
            {
                if (errorMessage != value)
                {
                    errorMessage = value;
                    OnPropertyChanged(nameof(ErrorMessage));
                }
            }
        }

        public ICommand LoginCommand { get; }

        private bool CanLogin(object obj)
        {
            return !string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password);
        }

        private void Login(object obj)
        {
            if (Email == "admin" && Password == "1234")
            {
                ErrorMessage = "";
                onLoginSuccess?.Invoke();
            }
            else
            {
                ErrorMessage = "Login inválido. Tente novamente.";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
