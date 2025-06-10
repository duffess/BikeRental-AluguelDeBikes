using System;
using System.ComponentModel;
using System.Windows.Input;

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

        public ICommand ShowDashboardCommand { get; }
        public ICommand ShowUsersCommand { get; }
        public ICommand ShowBikesCommand { get; }
        public ICommand ShowReportsCommand { get; }

        public MainViewModel()
        {
            LoginVM = new LoginViewModel();
            DashboardVM = new DashboardViewModel();
            UserManagementVM = new UserManagementViewModel();
            BikeManagementVM = new BikeManagementViewModel();
            ReportsVM = new ReportsViewModel();
            CurrentView = LoginVM;
            LoginVM.LoginSucceeded += OnLoginSucceeded;

            CurrentView = LoginVM;

            LoginVM.LoginSucceeded += OnLoginSucceeded;

            ShowDashboardCommand = new RelayCommand(o => CurrentView = DashboardVM);
            ShowUsersCommand = new RelayCommand(o => CurrentView = UserManagementVM);
            ShowBikesCommand = new RelayCommand(o => CurrentView = BikeManagementVM);
            ShowReportsCommand = new RelayCommand(o => CurrentView = ReportsVM);

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
