namespace BidConReport.Client.Messages;

public class AuthenticationChangedMessage : CommunityToolkit.Mvvm.Messaging.Messages.ValueChangedMessage<bool>
{
    public AuthenticationChangedMessage(bool value) : base(value)
    {

    }

}
