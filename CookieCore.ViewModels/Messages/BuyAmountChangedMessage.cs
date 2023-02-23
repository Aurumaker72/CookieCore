using CommunityToolkit.Mvvm.Messaging.Messages;

namespace CookieCore.ViewModels.Messages;

internal class BuyAmountChangedMessage : ValueChangedMessage<int>
{
    public BuyAmountChangedMessage(int value) : base(value)
    {
    }
}