using System;
using System.ComponentModel;
using System.Windows.Input;

namespace BikeRental.ViewModels
{
    // viewmodel principal que gerencia as views exibidas na aplicacao
    public class MainViewModel : INotifyPropertyChanged
    {
        // view atual exibida na interface
        private object _currentView;
        public object CurrentView
        {
            get => _currentView;
            set { _currentView = value; OnPropertyChanged(nameof(CurrentView)); }
        }

        // instancias dos viewmodels das diferentes telas
        public LoginViewModel LoginVM { get; }
        public DashboardViewModel DashboardVM { get; }
        public UserManagementViewModel UserManagementVM { get; }
        public BikeManagementViewModel BikeManagementVM { get; }
        public ReportsViewModel ReportsVM { get; }

        // comandos para trocar a view atual, usados pela interface
        public ICommand ShowDashboardCommand { get; }
        public ICommand ShowUsersCommand { get; }
        public ICommand ShowBikesCommand { get; }
        public ICommand ShowReportsCommand { get; }

        // construtor inicializa todos os viewmodels e comandos
        public MainViewModel()
        {
            LoginVM = new LoginViewModel();
            DashboardVM = new DashboardViewModel();
            UserManagementVM = new UserManagementViewModel();
            BikeManagementVM = new BikeManagementViewModel();
            ReportsVM = new ReportsViewModel();

            // comandos que alteram a view atual para a correspondente
            ShowDashboardCommand = new RelayCommand(o => CurrentView = DashboardVM);
            ShowUsersCommand = new RelayCommand(o => CurrentView = UserManagementVM);
            ShowBikesCommand = new RelayCommand(o => CurrentView = BikeManagementVM);
            ShowReportsCommand = new RelayCommand(o => CurrentView = ReportsVM);

            // inicia exibindo a dashboard
            CurrentView = DashboardVM;
        }

        // metodo chamado apos login bem-sucedido (pode ser usado para trocar a view)
        private void OnLoginSucceeded(object sender, EventArgs e)
        {
            CurrentView = DashboardVM;
        }

        // evento para notificar a interface sobre alteracoes em propriedades
        public event PropertyChangedEventHandler PropertyChanged;

        // dispara o evento de alteracao de propriedade para atualizar interface
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
