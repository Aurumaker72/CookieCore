using CommunityToolkit.Mvvm.ComponentModel;

namespace CookieCore.ViewModels;

public partial class QuantityPickerViewModel : ObservableObject
{
    [ObservableProperty] private int _amount;
}