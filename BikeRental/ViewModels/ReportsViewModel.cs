using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using BikeRental.Models;

namespace BikeRental.ViewModels
{
    public class ReportsViewModel : INotifyPropertyChanged
    {
        private User _selectedUser;
        private Bike _selectedBike;
        private DateTime? _selectedDate;
        private string _reportData;

        public ObservableCollection<User> Users { get; set; } 
        public ObservableCollection<Bike> Bikes { get; set; }



        public User SelectedUser
        {
            get => _selectedUser;
            set { _selectedUser = value; OnPropertyChanged(nameof(SelectedUser)); }
        }

        public Bike SelectedBike
        {
            get => _selectedBike;
            set { _selectedBike = value; OnPropertyChanged(nameof(SelectedBike)); }
        }

        public DateTime? SelectedDate
        {
            get => _selectedDate;
            set { _selectedDate = value; OnPropertyChanged(nameof(SelectedDate)); }
        }

        public string ReportData
        {
            get => _reportData;
            set { _reportData = value; OnPropertyChanged(nameof(ReportData)); }
        }

        public ICommand GenerateReportCommand { get; }

        public ReportsViewModel()
        {

            Users = new ObservableCollection<User>();
            Bikes = new ObservableCollection<Bike>();

            Users.Add(new User { Id = 1, Username = "Guilherme Duffes" });
            Users.Add(new User { Id = 2, Username = "Lucas Barbosa" });
            Bikes.Add(new Bike { Id = 1, Model = "Absolute TestModel" });
            Bikes.Add(new Bike { Id = 2, Model = "Oggi TestModel" });

            GenerateReportCommand = new RelayCommand(GenerateReport);
        }

        private void GenerateReport()
        {
            ReportData = $"Relatório gerado para {SelectedUser?.Username ?? "Todos os usuários"}, bicicleta: {SelectedBike?.Model ?? "Todas"}, data: {SelectedDate?.ToShortDateString() ?? "Todas"}";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
