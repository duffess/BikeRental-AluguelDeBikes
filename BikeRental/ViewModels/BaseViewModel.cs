// importa suporte para notificacao de mudancas em propriedades
using System.ComponentModel;

namespace BikeRentalDashboard.ViewModels
{
    // classe base para todas as viewmodels
    // fornece suporte a notificacao de mudanca de propriedade
    public class BaseViewModel : INotifyPropertyChanged
    {
        // evento que e disparado quando alguma propriedade muda
        public event PropertyChangedEventHandler PropertyChanged;

        // metodo que dispara o evento passando o nome da propriedade alterada
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
