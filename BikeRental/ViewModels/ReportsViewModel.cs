using System.ComponentModel;

namespace BikeRentalDashboard.ViewModels
{
    public class ReportsViewModel : INotifyPropertyChanged
    {
        // Deixe preparado para futuras implementações

        private string _reportStatus;

        public string ReportStatus
        {
            get => _reportStatus;
            set { _reportStatus = value; OnPropertyChanged(nameof(ReportStatus)); }
        }

        public ReportsViewModel()
        {
            ReportStatus = "Em desenvolvimento...";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
