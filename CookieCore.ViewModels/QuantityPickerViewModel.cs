using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CookieCore.ViewModels;

public partial class QuantityPickerViewModel : ObservableObject
{
    [ObservableProperty] private int _amount;

}