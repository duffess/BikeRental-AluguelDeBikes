using System;
using System.ComponentModel;

namespace BikeRental.ViewModels
{
    // viewmodel para a tela principal (dashboard)
    public class DashboardViewModel : INotifyPropertyChanged
    {
        // mensagem de boas-vindas que aparece na tela
        private string _welcomeMessage = "bem-vindo ao sistema de aluguel de bicicletas!";
        public string WelcomeMessage
        {
            get => _welcomeMessage;
            set { _welcomeMessage = value; OnPropertyChanged(nameof(WelcomeMessage)); }
        }

        // total de bicicletas disponiveis para aluguel
        private int _totalAvailableBikes;
        public int TotalAvailableBikes
        {
            get => _totalAvailableBikes;
            set { _totalAvailableBikes = value; OnPropertyChanged(nameof(TotalAvailableBikes)); }
        }

        // total de usuarios ativos no sistema
        private int _totalActiveUsers;
        public int TotalActiveUsers
        {
            get => _totalActiveUsers;
            set { _totalActiveUsers = value; OnPropertyChanged(nameof(TotalActiveUsers)); }
        }

        // receita total gerada (exemplo em reais)
        private double _totalRevenue;
        public double TotalRevenue
        {
            get => _totalRevenue;
            set { _totalRevenue = value; OnPropertyChanged(nameof(TotalRevenue)); }
        }

        // construtor que inicializa os dados com valores aleatorios para demo
        public DashboardViewModel()
        {
            var rand = new Random();

            // gera um numero aleatorio de bikes disponiveis entre 10 e 25
            TotalAvailableBikes = rand.Next(10, 26);

            // gera um numero aleatorio de usuarios ativos entre 3 e 10
            TotalActiveUsers = rand.Next(3, 11);

            // gera uma receita aleatoria entre 1000 e 11000, com duas casas decimais
            TotalRevenue = Math.Round(rand.NextDouble() * 10000 + 1000, 2);
        }

        // evento para avisar a interface quando uma propriedade muda
        public event PropertyChangedEventHandler PropertyChanged;

        // dispara o evento de mudança para atualizar a interface
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
