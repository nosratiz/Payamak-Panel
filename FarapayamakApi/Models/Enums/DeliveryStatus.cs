namespace PayamakPanel.Models.Enums
{
    public enum DeliveryStatus
    {
        PostedToTelecommunications=0,
        Delivered=1,
        NotReachingToThePhone=2,
        CommunicationException=3,
        UnknownException=5,
        ReceiveToTelecommunications=8,
        NotReachingToTelecommunications=16,
        BlackList=35,
        Unknown=100,
        Posted=200,
        Filtered=300,
        OnHoldList=400,
        ServerError=500
    }
}