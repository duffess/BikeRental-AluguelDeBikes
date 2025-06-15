// importa o modelo de bike
using BikeRental.Models;

// importa funcionalidades gerais e de interface
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace BikeRental.ViewModels
{
    // viewmodel responsavel pelo gerenciamento das bicicletas
    public class BikeManagementViewModel : INotifyPropertyChanged
    {
        // colecao de bicicletas exibida na interface
        public ObservableCollection<Bike> Bikes { get; set; }

        // objeto usado para cadastro ou edicao de uma bike
        public Bike NewBike { get; set; }

        // bike selecionada pelo usuario na interface
        private Bike _selectedBike;
        public Bike SelectedBike
        {
            get => _selectedBike;
            set
            {
                _selectedBike = value;
                OnPropertyChanged();

                // se uma bike for selecionada, copia os dados dela para o newbike
                if (_selectedBike != null)
                {
                    NewBike.Model = _selectedBike.Model;
                    NewBike.Brand = _selectedBike.Brand;
                    NewBike.Year = _selectedBike.Year;
                    NewBike.IsAvailable = _selectedBike.IsAvailable;
                    NewBike.PricePerHour = _selectedBike.PricePerHour;
                    OnPropertyChanged(nameof(NewBike));
                }

                // atualiza os comandos, ativando ou desativando conforme a selecao
                EditBikeCommand.RaiseCanExecuteChanged();
                DeleteBikeCommand.RaiseCanExecuteChanged();
                AlterarStatusCommand.RaiseCanExecuteChanged();
            }
        }

        // comandos que a interface pode usar (botões, por exemplo)
        public RelayCommand AddBikeCommand { get; }
        public RelayCommand EditBikeCommand { get; }
        public RelayCommand DeleteBikeCommand { get; }
        public RelayCommand AlterarStatusCommand { get; }

        // construtor da viewmodel
        public BikeManagementViewModel()
        {
            Bikes = new ObservableCollection<Bike>();
            NewBike = new Bike();

            // inicializa os comandos, associando cada um com sua acao
            AddBikeCommand = new RelayCommand(param => AddBike());
            EditBikeCommand = new RelayCommand(param => EditBike(), param => SelectedBike != null);
            DeleteBikeCommand = new RelayCommand(param => DeleteBike(), param => SelectedBike != null);
            AlterarStatusCommand = new RelayCommand(param => AlterarStatus(), param => SelectedBike != null);
        }

        // metodo para adicionar uma nova bike
        private void AddBike()
        {
            try
            {
                Bikes.Add(new Bike
                {
                    Id = Bikes.Count + 1, // id simples, baseado na quantidade
                    Model = NewBike.Model,
                    Brand = NewBike.Brand,
                    Year = NewBike.Year,
                    IsAvailable = true,
                    PricePerHour = NewBike.PricePerHour
                });

                // limpa o objeto newbike depois de adicionar
                NewBike = new Bike();
                OnPropertyChanged(nameof(NewBike));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"erro ao adicionar bike: {ex.Message}");
            }
        }

        // metodo para editar a bike selecionada
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

        // metodo para deletar a bike selecionada
        private void DeleteBike()
        {
            if (SelectedBike != null)
                Bikes.Remove(SelectedBike);
        }

        // metodo para alternar o status de disponibilidade da bike
        private void AlterarStatus()
        {
            if (SelectedBike != null)
            {
                SelectedBike.IsAvailable = !SelectedBike.IsAvailable;
            }
        }

        // implementacao da interface de notificacao
        public event PropertyChangedEventHandler PropertyChanged;

        // dispara o evento quando uma propriedade muda
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
