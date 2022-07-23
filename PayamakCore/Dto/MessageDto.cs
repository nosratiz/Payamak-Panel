namespace PayamakCore.Dto;

public class MessageDto : AccountDto
{
    public string To { get; set; }

    public string From { get; set; }

    public string Text { get; set; }

    public bool IsFlash { get; set; }
}