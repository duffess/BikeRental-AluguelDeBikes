using BikeRental.Models;
using BikeRentalDashboard.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace BikeRental.ViewModels
{
    public class BikeManagementViewModel : BaseViewModel
    {
        private Bike _selectedBike;

        public ObservableCollection<Bike> Bikes { get; set; }
        public Bike SelectedBike
        {
            get => _selectedBike;
            set
            {
                _selectedBike = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CanChangeStatus));
                EditBikeCommand.RaiseCanExecuteChanged();
                DeleteBikeCommand.RaiseCanExecuteChanged();
                AlterarStatusCommand.RaiseCanExecuteChanged();
            }
        }

        private void OnPropertyChanged()
        {
            throw new NotImplementedException();
        }

        public RelayCommand AddBikeCommand { get; }
        public RelayCommand EditBikeCommand { get; }
        public RelayCommand DeleteBikeCommand { get; }
        public RelayCommand AlterarStatusCommand { get; }
        public Bike NewBike { get; set; }

        public bool CanChangeStatus => SelectedBike != null;

        public BikeManagementViewModel()
        {
            Bikes = new ObservableCollection<Bike>();
            NewBike = new Bike();

            AddBikeCommand = new RelayCommand(param => AddBike());
            EditBikeCommand = new RelayCommand(param => EditBike(), param => SelectedBike != null);
            DeleteBikeCommand = new RelayCommand(param => DeleteBike(), param => SelectedBike != null);
            AlterarStatusCommand = new RelayCommand(param => AlterarStatus(), param => CanChangeStatus);
        }

        private void AddBike()
        {
            try
            {
                Bikes.Add(new Bike
                {
                    Id = Bikes.Count + 1,
                    Model = NewBike.Model,
                    PricePerHour = NewBike.PricePerHour,
                    IsAvailable = NewBike.IsAvailable
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
            try
            {
                if (SelectedBike != null)
                {
                    SelectedBike.Model += " (Editado)";
                    OnPropertyChanged(nameof(Bikes));
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao editar bicicleta: {ex.Message}");
            }
        }

        private void DeleteBike()
        {
            try
            {
                if (SelectedBike != null)
                    Bikes.Remove(SelectedBike);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao deletar bicicleta: {ex.Message}");
            }
        }

        private void AlterarStatus()
        {
            try
            {
                if (SelectedBike != null)
                {
                    SelectedBike.IsAvailable = !SelectedBike.IsAvailable;
                    OnPropertyChanged(nameof(SelectedBike));
                    OnPropertyChanged(nameof(SelectedBike.Status));
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao alterar status da bicicleta: {ex.Message}");
            }
        }



    }

}
