using System.Windows;
using System.Windows.Controls;
using BikeRental.ViewModels;


namespace BikeRental.Views
{
    /// <summary>
    /// Interação lógica para ReportsView.xaml
    /// </summary>
    public partial class ReportsView : UserControl
    {
        public ReportsView()
        {
            InitializeComponent();
            DataContext = new ReportsViewModel();
        }
    }
}

