using BikeRental.Models;
using BikeRentalDashboard.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace BikeRentalDashboard.ViewModels
{
    public class UserManagementViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<User> _users;
        private User _selectedUser;

        public ObservableCollection<User> Users
        {
            get => _users;
            set { _users = value; OnPropertyChanged(nameof(Users)); }
        }

        public User SelectedUser
        {
            get => _selectedUser;
            set { _selectedUser = value; OnPropertyChanged(nameof(SelectedUser)); }
        }

        public UserManagementViewModel()
        {
            Users = new ObservableCollection<User>();
            // Aqui você pode adicionar código para carregar os usuários do banco.
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
