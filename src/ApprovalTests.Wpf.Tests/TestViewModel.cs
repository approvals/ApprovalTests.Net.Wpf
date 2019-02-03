using System.ComponentModel;
using System.Runtime.CompilerServices;

class TestViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged = delegate { };

    public const string MyPropertyPropertyName = "MyProperty";
    string _myProperty;

    public string MyProperty
    {
        get => _myProperty;
        set
        {
            _myProperty = value;
            RaisePropertyChanged();
        }
    }

    void RaisePropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
}