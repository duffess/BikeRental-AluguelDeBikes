using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using BikeRental.Models;
using BikeRentalDashboard.ViewModels;

namespace BikeRental.ViewModels
{
    public class UserManagementViewModel : BaseViewModel
    {
        public ObservableCollection<User> Users { get; set; }

        private User _selectedUser;
        public User SelectedUser
        {
            get => _selectedUser;
            set
            {
                if (_selectedUser != value)
                {
                    _selectedUser = value;
                    OnPropertyChanged(nameof(SelectedUser));
                    EditUserCommand.RaiseCanExecuteChanged();
                    DeleteUserCommand.RaiseCanExecuteChanged();

                    // Preenche os campos com os dados do usuário selecionado
                    if (_selectedUser != null)
                    {
                        NewUser = new User
                        {
                            Id = _selectedUser.Id,
                            Username = _selectedUser.Username,
                            Email = _selectedUser.Email,
                            Profile = _selectedUser.Profile
                        };
                    }
                }
            }
        }

        public RelayCommand AddUserCommand { get; }
        public RelayCommand EditUserCommand { get; }
        public RelayCommand DeleteUserCommand { get; }

        private User _newUser;
        public User NewUser
        {
            get => _newUser;
            set
            {
                _newUser = value;
                OnPropertyChanged(nameof(NewUser));
            }
        }

        public UserManagementViewModel()
        {
            Users = new ObservableCollection<User>();
            NewUser = new User();

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

            NewUser = new User();
        }

        private void EditUser()
        {
            if (SelectedUser != null)
            {
                SelectedUser.Username = NewUser.Username;
                SelectedUser.Email = NewUser.Email;
                SelectedUser.Profile = NewUser.Profile;

                OnPropertyChanged(nameof(Users));
                NewUser = new User();
                OnPropertyChanged(nameof(NewUser));
            }
        }

        private void DeleteUser()
        {
            if (SelectedUser != null)
            {
                Users.Remove(SelectedUser);
                SelectedUser = null;
                NewUser = new User();
                OnPropertyChanged(nameof(NewUser));
            }
        }
    }
}
