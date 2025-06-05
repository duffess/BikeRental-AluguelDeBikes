using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using BikeRental.Models;
using BikeRentalDashboard.ViewModels;

namespace BikeRental.ViewModels
{
    public class BikeManagementViewModel : BaseViewModel
    {
        public ObservableCollection<Bike> Bikes { get; set; }
        public Bike SelectedBike { get; set; }

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
            Bikes.Add(new Bike
            {
                Id = Bikes.Count + 1,
                Model = NewBike.Model,
                PricePerHour = NewBike.PricePerHour,
                IsAvailable = NewBike.IsAvailable
            });

            // Limpa o form
            NewBike = new Bike();
        }

        private void EditBike()
        {
            if (SelectedBike != null)
            {
                SelectedBike.Model += " (Editado)";
                OnPropertyChanged(nameof(Bikes));
            }
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
                OnPropertyChanged(nameof(SelectedBike));
                OnPropertyChanged(nameof(SelectedBike.Status));
            }
        }
    }

}
