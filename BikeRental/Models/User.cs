// importa recursos para notificacao de mudanca de propriedades
using System.ComponentModel;

// classe user representa um usuario e notifica a interface quando os dados mudam
public class User : INotifyPropertyChanged
{
    // campos privados usados pelas propriedades
    private string _username;
    private string _email;
    private string _profile;

    // id publico, nao dispara evento de alteracao
    public int Id { get; set; }

    // propriedade username com notificacao
    public string Username
    {
        get => _username;
        set
        {
            _username = value;
            OnPropertyChanged(nameof(Username)); // avisa que username foi alterado
        }
    }

    // propriedade email com notificacao
    public string Email
    {
        get => _email;
        set
        {
            _email = value;
            OnPropertyChanged(nameof(Email));
        }
    }

    // propriedade profile com notificacao
    public string Profile
    {
        get => _profile;
        set
        {
            _profile = value;
            OnPropertyChanged(nameof(Profile));
        }
    }

    // evento chamado sempre que uma propriedade for alterada
    public event PropertyChangedEventHandler PropertyChanged;

    // metodo que dispara o evento passando o nome da propriedade alterada
    protected void OnPropertyChanged(string propertyName)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
