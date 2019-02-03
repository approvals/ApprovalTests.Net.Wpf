using System.ComponentModel;
using System.Runtime.CompilerServices;

#region Model
public class ViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged = delegate { };

    public const string MyPropertyPropertyName = "MyProperty";
    string myProperty;

    public string MyProperty
    {
        get => myProperty;
        set
        {
            myProperty = value;
            RaisePropertyChanged();
        }
    }

    void RaisePropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
}
#endregion