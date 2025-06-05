using System.ComponentModel;

namespace BikeRental.ViewModels
{
    public class ReportsViewModel : INotifyPropertyChanged
    {
        private string _reportData;
        public string ReportData
        {
            get => _reportData;
            set { _reportData = value; OnPropertyChanged(nameof(ReportData)); }
        }

        public ReportsViewModel()
        {
            ReportData = "Relatório de uso: 10 locações hoje.";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
