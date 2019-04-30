namespace PayamakPanel.Models.Enums
{
    public enum BaseServiceStatus
    {
        SenderError=-7,
        InternalError=-6,
        TextParameterError=-5,
        AdminNotApproved=-4,
        SubmittedLineError=-3,
        LimitedSendMessage=-2,
        WebServiceIsOutOfReach=-1,
        UserNameOrPasswordWrong=0,
        CreditError=2,
        WebServiceIsUpdating=6,
        NotAppropriateText=7,
        UserIsNotActive=10,
        FailedOnSendMessage=11,
        DocumentIsNotCompleted=12

    }
}