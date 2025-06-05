using System;
using System.ComponentModel;

namespace BikeRental.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private object _currentView;

        public object CurrentView
        {
            get => _currentView;
            set { _currentView = value; OnPropertyChanged(nameof(CurrentView)); }
        }

        public LoginViewModel LoginVM { get; }
        public DashboardViewModel DashboardVM { get; }
        public UserManagementViewModel UserManagementVM { get; }
        public BikeManagementViewModel BikeManagementVM { get; }
        public ReportsViewModel ReportsVM { get; }

        public MainViewModel()
        {
            LoginVM = new LoginViewModel();
            DashboardVM = new DashboardViewModel();
            UserManagementVM = new UserManagementViewModel();
            BikeManagementVM = new BikeManagementViewModel();
            ReportsVM = new ReportsViewModel();
            CurrentView = LoginVM;
            LoginVM.LoginSucceeded += OnLoginSucceeded;
        }

        private void OnLoginSucceeded(object sender, EventArgs e)
        {
            CurrentView = DashboardVM;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
