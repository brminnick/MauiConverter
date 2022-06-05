using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace XamConverter;

[INotifyPropertyChanged]
abstract partial class BaseViewModel
{
    protected bool SetProperty<T>(ref T field, in T newValue, in Action? onChanged = null, [CallerMemberName] in string? propertyName = null)
    {
        var didPropertyChange = SetProperty(ref field, newValue, propertyName);

        if (didPropertyChange)
            onChanged?.Invoke();

        return didPropertyChange;
    }
}