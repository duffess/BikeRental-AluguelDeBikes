using BikeRental.ViewModels;
using BikeRentalDashboard.ViewModels;
using System.ComponentModel;

namespace BikeRental.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private object currentViewModel;

        public MainViewModel()
        {
            ShowLogin();
        }

        public object CurrentViewModel
        {
            get => currentViewModel;
            set
            {
                if (currentViewModel != value)
                {
                    currentViewModel = value;
                    OnPropertyChanged(nameof(CurrentViewModel));
                }
            }
        }

        public void ShowLogin()
        {
            CurrentViewModel = new LoginViewModel(OnLoginSuccess);
        }

        public void ShowDashboard()
        {
            CurrentViewModel = new DashboardViewModel(OnLogout);
        }

        private void OnLoginSuccess()
        {
            ShowDashboard();
        }

        private void OnLogout()
        {
            ShowLogin();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
