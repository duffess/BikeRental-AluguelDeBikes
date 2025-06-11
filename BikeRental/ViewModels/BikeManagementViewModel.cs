using BikeRental.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace BikeRental.ViewModels
{
    public class BikeManagementViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Bike> Bikes { get; set; }
        public Bike NewBike { get; set; }
        private Bike _selectedBike;
        public Bike SelectedBike
        {
            get => _selectedBike;
            set
            {
                _selectedBike = value;
                OnPropertyChanged();

                if (_selectedBike != null)
                {
                    NewBike.Model = _selectedBike.Model;
                    NewBike.Brand = _selectedBike.Brand;
                    NewBike.Year = _selectedBike.Year;
                    NewBike.IsAvailable = _selectedBike.IsAvailable;
                    NewBike.PricePerHour = _selectedBike.PricePerHour;
                    OnPropertyChanged(nameof(NewBike));
                }

                EditBikeCommand.RaiseCanExecuteChanged();
                DeleteBikeCommand.RaiseCanExecuteChanged();
                AlterarStatusCommand.RaiseCanExecuteChanged();
            }
        }

        public RelayCommand AddBikeCommand { get; }
        public RelayCommand EditBikeCommand { get; }
        public RelayCommand DeleteBikeCommand { get; }
        public RelayCommand AlterarStatusCommand { get; }

        public BikeManagementViewModel()
        {
            Bikes = new ObservableCollection<Bike>();
            NewBike = new Bike();

            AddBikeCommand = new RelayCommand(param => AddBike());
            EditBikeCommand = new RelayCommand(param => EditBike(), param => SelectedBike != null);
            DeleteBikeCommand = new RelayCommand(param => DeleteBike(), param => SelectedBike != null);
            AlterarStatusCommand = new RelayCommand(param => AlterarStatus(), param => SelectedBike != null);
        }

        private void AddBike()
        {
            try
            {
                Bikes.Add(new Bike
                {
                    Id = Bikes.Count + 1,
                    Model = NewBike.Model,
                    Brand = NewBike.Brand,
                    Year = NewBike.Year,
                    IsAvailable = true,
                    PricePerHour = NewBike.PricePerHour
                });

                NewBike = new Bike();
                OnPropertyChanged(nameof(NewBike));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar bike: {ex.Message}");
            }
        }

        private void EditBike()
        {
            if (SelectedBike == null) return;

            SelectedBike.Model = NewBike.Model;
            SelectedBike.Brand = NewBike.Brand;
            SelectedBike.Year = NewBike.Year;
            SelectedBike.IsAvailable = NewBike.IsAvailable;
            SelectedBike.PricePerHour = NewBike.PricePerHour;

            OnPropertyChanged(nameof(Bikes));
        }

        private void DeleteBike()
        {
            if (SelectedBike != null)
                Bikes.Remove(SelectedBike);
        }

        private void AlterarStatus()
        {
            if (SelectedBike != null)
            {
                SelectedBike.IsAvailable = !SelectedBike.IsAvailable;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
