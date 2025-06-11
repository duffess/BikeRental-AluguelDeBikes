using System.ComponentModel;

public class User : INotifyPropertyChanged
{
    private string _username;
    private string _email;
    private string _profile;

    public int Id { get; set; }

    public string Username
    {
        get => _username;
        set
        {
            _username = value;
            OnPropertyChanged(nameof(Username));
        }
    }

    public string Email
    {
        get => _email;
        set
        {
            _email = value;
            OnPropertyChanged(nameof(Email));
        }
    }

    public string Profile
    {
        get => _profile;
        set
        {
            _profile = value;
            OnPropertyChanged(nameof(Profile));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
