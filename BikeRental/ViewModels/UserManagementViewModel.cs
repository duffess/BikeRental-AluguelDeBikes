using System.Collections.ObjectModel; // importa a classe para colecoes observaveis, que notificam a interface quando mudam
using System.ComponentModel; // importa interface para notificar mudancas nas propriedades (inotifypropertychanged)
using System.Windows.Input; // importa interface de comando para ligacao com botoes e controles
using BikeRental.Models; // importa modelo de dados user
using BikeRentalDashboard.ViewModels; // importa base viewmodel para heranca

namespace BikeRental.ViewModels
{
    // classe viewmodel para gerenciar usuarios, herda base que implementa notificacao de propriedade
    public class UserManagementViewModel : BaseViewModel
    {
        // colecao observavel de usuarios, vinculada na interface para exibir lista
        public ObservableCollection<User> Users { get; set; }

        // usuario selecionado na lista
        private User _selectedUser;
        public User SelectedUser
        {
            get => _selectedUser;
            set
            {
                // se usuario selecionado mudou
                if (_selectedUser != value)
                {
                    _selectedUser = value; // atualiza campo privado
                    OnPropertyChanged(nameof(SelectedUser)); // notifica interface que mudou selecteduser

                    // atualiza o estado dos comandos editar e excluir para habilitar ou desabilitar botoes
                    EditUserCommand.RaiseCanExecuteChanged();
                    DeleteUserCommand.RaiseCanExecuteChanged();

                    // se usuario selecionado nao for nulo, copia os dados para newuser para preencher formulario
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

        // comando para adicionar usuario
        public RelayCommand AddUserCommand { get; }

        // comando para editar usuario selecionado
        public RelayCommand EditUserCommand { get; }

        // comando para deletar usuario selecionado
        public RelayCommand DeleteUserCommand { get; }

        // objeto que representa o usuario novo ou editado no formulario
        private User _newUser;
        public User NewUser
        {
            get => _newUser;
            set
            {
                _newUser = value; // atualiza campo privado
                OnPropertyChanged(nameof(NewUser)); // notifica interface para atualizar bindings do formulario
            }
        }

        // construtor da classe viewmodel
        public UserManagementViewModel()
        {
            Users = new ObservableCollection<User>(); // inicializa colecao vazia de usuarios
            NewUser = new User(); // inicializa objeto usuario vazio para formulario

            // cria comandos e associa metodos, com condicoes para ativar/desativar
            AddUserCommand = new RelayCommand(param => AddUser());
            EditUserCommand = new RelayCommand(param => EditUser(), param => SelectedUser != null);
            DeleteUserCommand = new RelayCommand(param => DeleteUser(), param => SelectedUser != null);
        }

        // metodo para adicionar usuario novo na lista
        private void AddUser()
        {
            // adiciona novo usuario na colecao com id gerado como tamanho da lista + 1
            Users.Add(new User
            {
                Id = Users.Count + 1,
                Username = NewUser.Username,
                Email = NewUser.Email,
                Profile = NewUser.Profile
            });

            NewUser = new User(); // limpa o formulario criando um novo objeto vazio
        }

        // metodo para editar usuario selecionado com dados do formulario
        private void EditUser()
        {
            if (SelectedUser != null) // se existe usuario selecionado
            {
                // atualiza propriedades do usuario selecionado com dados do formulario
                SelectedUser.Username = NewUser.Username;
                SelectedUser.Email = NewUser.Email;
                SelectedUser.Profile = NewUser.Profile;

                OnPropertyChanged(nameof(Users)); // notifica que a lista mudou (para atualizar interface)

                NewUser = new User(); // limpa formulario apos editar
                OnPropertyChanged(nameof(NewUser)); // notifica interface sobre nova instancia
            }
        }

        // metodo para deletar usuario selecionado da lista
        private void DeleteUser()
        {
            if (SelectedUser != null) // se existe usuario selecionado
            {
                Users.Remove(SelectedUser); // remove da colecao
                SelectedUser = null; // limpa selecao
                NewUser = new User(); // limpa formulario
                OnPropertyChanged(nameof(NewUser)); // notifica interface para atualizar formulario
            }
        }
    }
}
