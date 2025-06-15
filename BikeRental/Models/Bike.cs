// importa recursos para notificacao de alteracoes em propriedades
using System.ComponentModel;

// permite pegar automaticamente o nome da propriedade que chamou um metodo
using System.Runtime.CompilerServices;

// classe bike representa uma bicicleta e notifica a interface quando alguma propriedade muda
public class Bike : INotifyPropertyChanged
{
    // propriedade id publica, sem notificacao
    public int Id { get; set; }

    // campos privados para as propriedades que serao monitoradas
    private string _model;
    private string _brand;
    private int _year;
    private bool _isAvailable;
    private double _pricePerHour;

    // propriedade com get e set. chama onpropertychanged quando alterada
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
        set
        {
            _isAvailable = value;
            OnPropertyChanged(); // atualiza o valor da propriedade
            OnPropertyChanged(nameof(Status)); // atualiza tambem a propriedade calculada status
        }
    }

    public double PricePerHour
    {
        get => _pricePerHour;
        set { _pricePerHour = value; OnPropertyChanged(); }
    }

    // propriedade somente leitura baseada em outra propriedade
    // retorna uma string dependendo se a bike esta disponivel
    public string Status => IsAvailable ? "Disponível" : "Indisponível";

    // evento que e disparado quando uma propriedade muda
    public event PropertyChangedEventHandler PropertyChanged;

    // metodo que dispara o evento, avisando que uma propriedade foi alterada
    protected void OnPropertyChanged([CallerMemberName] string name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
