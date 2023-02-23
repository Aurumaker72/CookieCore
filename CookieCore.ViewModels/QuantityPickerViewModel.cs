using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CookieCore.ViewModels.Messages;

namespace CookieCore.ViewModels;

public partial class QuantityPickerViewModel : ObservableObject
{
    private int _amount = 1;

    [ObservableProperty] private bool _isBuying = true;

    public int Amount
    {
        get => _amount;
        set
        {
            SetProperty(ref _amount, Math.Max(1, value));
            WeakReferenceMessenger.Default.Send(new BuyAmountChangedMessage(Amount));
        }
    }
}