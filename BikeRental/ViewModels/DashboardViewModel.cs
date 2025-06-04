using System;
using System.ComponentModel;

namespace BikeRentalDashboard.ViewModels
{
    public class DashboardViewModel : INotifyPropertyChanged
    {
        private int _activeUsers;
        private int _totalBikes;
        private decimal _totalRevenue;
        private Action onLogout;

        public DashboardViewModel(Action onLogout)
        {
            this.onLogout = onLogout;
        }

        public int ActiveUsers
        {
            get => _activeUsers;
            set { _activeUsers = value; OnPropertyChanged(nameof(ActiveUsers)); }
        }

        public int TotalBikes
        {
            get => _totalBikes;
            set { _totalBikes = value; OnPropertyChanged(nameof(TotalBikes)); }
        }

        public decimal TotalRevenue
        {
            get => _totalRevenue;
            set { _totalRevenue = value; OnPropertyChanged(nameof(TotalRevenue)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
