using System.ComponentModel;
using System.Runtime.CompilerServices;

public class Bike : INotifyPropertyChanged
{
    public int Id { get; set; }
    private string _model;
    private string _brand;
    private int _year;
    private bool _isAvailable;
    private double _pricePerHour;

    public string Model
    {
        get => _model;
        set { _model = value; OnPropertyChanged(); }
    }

    public string Brand
    {
        get => _brand;
        set { _brand = value; OnPropertyChanged(); }
    }

    public int Year
    {
        get => _year;
        set { _year = value; OnPropertyChanged(); }
    }

    public bool IsAvailable
    {
        get => _isAvailable;
        set { _isAvailable = value; OnPropertyChanged(); OnPropertyChanged(nameof(Status)); }
    }

    public double PricePerHour
    {
        get => _pricePerHour;
        set { _pricePerHour = value; OnPropertyChanged(); }
    }

    public string Status => IsAvailable ? "Disponível" : "Indisponível";

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
