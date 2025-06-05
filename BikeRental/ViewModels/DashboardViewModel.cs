using System.ComponentModel;

namespace BikeRental.ViewModels
{
    public class DashboardViewModel : INotifyPropertyChanged
    {
        private string _welcomeMessage = "Bem-vindo ao Sistema de Aluguel de Bicicletas!";
        public string WelcomeMessage
        {
            get => _welcomeMessage;
            set { _welcomeMessage = value; OnPropertyChanged(nameof(WelcomeMessage)); }
        }

        public DashboardViewModel() { }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
