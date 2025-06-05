using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using BikeRental.Models;
using BikeRentalDashboard.Models;
using BikeRentalDashboard.ViewModels;

namespace BikeRental.ViewModels
{
    public class UserManagementViewModel : BaseViewModel
    {
        public ObservableCollection<User> Users { get; set; }
        public User SelectedUser { get; set; }

        public RelayCommand AddUserCommand { get; }
        public RelayCommand EditUserCommand { get; }
        public RelayCommand DeleteUserCommand { get; }
        public User NewUser { get; set; }

        public UserManagementViewModel()
        {
            Users = new ObservableCollection<User>();

            AddUserCommand = new RelayCommand(param => AddUser());
            EditUserCommand = new RelayCommand(param => EditUser(), param => SelectedUser != null);
            DeleteUserCommand = new RelayCommand(param => DeleteUser(), param => SelectedUser != null);
        }

        private void AddUser()
        {
            Users.Add(new User
            {
                Id = Users.Count + 1,
                Username = NewUser.Username,
                Email = NewUser.Email,
                Profile = NewUser.Profile
            });

            // Limpa o form
            NewUser = new User();
        }

        private void EditUser()
        {
            if (SelectedUser != null)
            {
                SelectedUser.Username += " (Editado)";
                OnPropertyChanged(nameof(Users));
            }
        }

        private void DeleteUser()
        {
            if (SelectedUser != null)
                Users.Remove(SelectedUser);
        }
    }

}
