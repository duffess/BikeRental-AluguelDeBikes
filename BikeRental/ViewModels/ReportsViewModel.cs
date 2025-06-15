using System;  // importa funcionalidades basicas do sistema, como DateTime
using System.Collections.ObjectModel;  // importa ObservableCollection que eh uma lista observavel usada para databinding
using System.ComponentModel;  // importa interfaces para notificacao de mudancas, como INotifyPropertyChanged
using BikeRental.Models;  // importa as classes modelo User e Bike que representam dados do sistema

namespace BikeRental.ViewModels  // namespace para separar as classes de viewmodel da aplicacao de aluguel de bicicletas
{
    public class ReportsViewModel : INotifyPropertyChanged  // classe viewmodel que implementa notificacao de mudancas para a view
    {

        private string _reportData;  // campo privado para armazenar o texto do relatorio gerado
        public string ReportData  // propriedade publica para acessar o texto do relatorio
        {
            get => _reportData;  // retorna o valor armazenado
            set { _reportData = value; OnPropertyChanged(nameof(ReportData)); }  // atribui novo valor e notifica a view que mudou
        }

        public ObservableCollection<User> Users { get; set; }  // colecao observavel de usuarios para ser exibida na interface
        public ObservableCollection<Bike> Bikes { get; set; }  // colecao observavel de bicicletas para exibicao e selecao

        private User _selectedUser;  // usuario selecionado no relatorio
        public User SelectedUser  // propriedade para acessar/alterar usuario selecionado
        {
            get => _selectedUser;
            set
            {
                _selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));  // notifica que usuario selecionado mudou
            }
        }

        private Bike _selectedBike;  // bicicleta selecionada no relatorio
        public Bike SelectedBike  // propriedade para acessar/alterar bicicleta selecionada
        {
            get => _selectedBike;
            set
            {
                _selectedBike = value;
                OnPropertyChanged(nameof(SelectedBike));  // notifica mudanca para view
            }
        }

        private DateTime? _rentalDate;  // data do aluguel, pode ser nula (por isso o DateTime?)
        public DateTime? RentalDate  // propriedade para data de aluguel selecionada
        {
            get => _rentalDate;
            set
            {
                _rentalDate = value;
                OnPropertyChanged(nameof(RentalDate));  // notifica que a data mudou
            }
        }

        private DateTime? _returnDate;  // data de devolucao, pode ser nula tambem
        public DateTime? ReturnDate  // propriedade para data de devolucao selecionada
        {
            get => _returnDate;
            set
            {
                _returnDate = value;
                OnPropertyChanged(nameof(ReturnDate));  // notifica mudanca para a view
            }
        }

        public RelayCommand GenerateReportCommand { get; }  // comando que sera vinculado a botao para gerar relatorio

        public ReportsViewModel()  // construtor da classe
        {
            // inicializa lista de usuarios com alguns dados fixos para teste
            Users = new ObservableCollection<User>
            {
                new User { Id = 1, Username = "João Silva", Email = "joao@email.com", Profile = "Cliente" },
                new User { Id = 2, Username = "Maria Oliveira", Email = "maria@email.com", Profile = "Admin" },
                new User { Id = 3, Username = "Carlos Souza", Email = "carlos@email.com", Profile = "Cliente" },
                new User { Id = 4, Username = "Ana Martins", Email = "ana@email.com", Profile = "Cliente" },
                new User { Id = 5, Username = "Fernanda Lima", Email = "fernanda@email.com", Profile = "Admin" }
            };

            // inicializa lista de bicicletas com varios modelos e suas informacoes
            Bikes = new ObservableCollection<Bike>
            {
                new Bike { Id = 1, Model = "Domane SL 6", Brand = "Trek", Year = 2023, IsAvailable = true, PricePerHour = 20.0 },
                new Bike { Id = 2, Model = "Émonda ALR 5", Brand = "Trek", Year = 2022, IsAvailable = true, PricePerHour = 18.0 },
                new Bike { Id = 3, Model = "Topstone 1", Brand = "Cannondale", Year = 2024, IsAvailable = true, PricePerHour = 22.5 },
                new Bike { Id = 4, Model = "CAAD13 Disc 105", Brand = "Cannondale", Year = 2023, IsAvailable = false, PricePerHour = 21.0 },
                new Bike { Id = 5, Model = "Synapse Carbon", Brand = "Cannondale", Year = 2024, IsAvailable = true, PricePerHour = 23.5 },
                new Bike { Id = 6, Model = "Tarmac SL7", Brand = "Specialized", Year = 2023, IsAvailable = true, PricePerHour = 25.0 },
                new Bike { Id = 7, Model = "Roubaix Sport", Brand = "Specialized", Year = 2022, IsAvailable = false, PricePerHour = 19.0 },
                new Bike { Id = 8, Model = "Diverge Comp Carbon", Brand = "Specialized", Year = 2024, IsAvailable = true, PricePerHour = 24.5 },
                new Bike { Id = 9, Model = "Addict RC 30", Brand = "Scott", Year = 2023, IsAvailable = true, PricePerHour = 21.0 },
                new Bike { Id = 10, Model = "Speedster 20", Brand = "Scott", Year = 2022, IsAvailable = true, PricePerHour = 17.5 },
                new Bike { Id = 11, Model = "Giant Propel Advanced 2", Brand = "Giant", Year = 2023, IsAvailable = false, PricePerHour = 22.0 },
                new Bike { Id = 12, Model = "Defy Advanced 1", Brand = "Giant", Year = 2024, IsAvailable = true, PricePerHour = 24.0 },
                new Bike { Id = 13, Model = "Canyon Endurace CF SL 8", Brand = "Canyon", Year = 2023, IsAvailable = true, PricePerHour = 23.0 },
                new Bike { Id = 14, Model = "Aeroad CF SLX", Brand = "Canyon", Year = 2024, IsAvailable = true, PricePerHour = 26.0 },
                new Bike { Id = 15, Model = "Felt AR Advanced", Brand = "Felt", Year = 2022, IsAvailable = false, PricePerHour = 20.5 },
                new Bike { Id = 16, Model = "Orbea Orca M30", Brand = "Orbea", Year = 2023, IsAvailable = true, PricePerHour = 21.5 },
                new Bike { Id = 17, Model = "BMC Teammachine ALR", Brand = "BMC", Year = 2023, IsAvailable = true, PricePerHour = 22.0 },
                new Bike { Id = 18, Model = "Pinarello Paris 105", Brand = "Pinarello", Year = 2024, IsAvailable = true, PricePerHour = 27.0 },
                new Bike { Id = 19, Model = "Merida Scultura Endurance", Brand = "Merida", Year = 2023, IsAvailable = false, PricePerHour = 20.0 },
                new Bike { Id = 20, Model = "Wilier GTR Team", Brand = "Wilier", Year = 2023, IsAvailable = true, PricePerHour = 22.5 },
                new Bike { Id = 21, Model = "Liv Avail Advanced 2", Brand = "Liv", Year = 2022, IsAvailable = true, PricePerHour = 19.5 },
                new Bike { Id = 22, Model = "Lapierre Xelius SL 6", Brand = "Lapierre", Year = 2023, IsAvailable = false, PricePerHour = 23.0 },
                new Bike { Id = 23, Model = "Cube Agree C:62", Brand = "Cube", Year = 2024, IsAvailable = true, PricePerHour = 24.0 },
                new Bike { Id = 24, Model = "Colnago V3", Brand = "Colnago", Year = 2023, IsAvailable = true, PricePerHour = 25.5 },
                new Bike { Id = 25, Model = "Santa Cruz Stigmata", Brand = "Santa Cruz", Year = 2024, IsAvailable = true, PricePerHour = 26.5 }
            };

            // inicializa comando para gerar relatorio, executando o metodo GerarRelatorio quando acionado
            GenerateReportCommand = new RelayCommand(_ => GerarRelatorio());
        }

        // metodo para verificar se e possivel gerar o relatorio, retorna true se usuario, bicicleta e data do aluguel foram selecionados
        private bool CanGenerateReport()
        {
            return SelectedUser != null && SelectedBike != null && RentalDate != null;
        }

        // metodo que monta o texto do relatorio adicionando informacoes selecionadas e atualiza a propriedade ReportData
        private void GerarRelatorio()
        {
            ReportData += $"Relatório gerado:\n" +  // texto do relatorio, pode ser acumulativo
                          $"- Usuário: {SelectedUser?.Username}\n" +  // nome do usuario selecionado, pode ser nulo
                          $"- Bicicleta: {SelectedBike?.Model}\n" +  // modelo da bicicleta selecionada, pode ser nulo
                          $"- Data do aluguel: {RentalDate?.ToShortDateString()}\n" +  // data formatada do aluguel, pode ser nula
                          $"- Data de devolução: {ReturnDate?.ToShortDateString()}\n\n";  // data formatada da devolucao, pode ser nula
        }

        // evento que e disparado quando uma propriedade muda para avisar a interface que deve atualizar bindings
        public event PropertyChangedEventHandler PropertyChanged;

        // metodo que dispara o evento PropertyChanged passando o nome da propriedade alterada
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
