using BikeRental.Models;
using System.Collections.ObjectModel;

namespace BikeRentalDashboard.ViewModels
{
    public class BikeManagementViewModel : BaseViewModel
    {
        public ObservableCollection<Bike> Bikes { get; set; }

        public BikeManagementViewModel()
        {
            Bikes = new ObservableCollection<Bike>();
            LoadBikes();
        }

        private void LoadBikes()
        {
        }
    }
}
