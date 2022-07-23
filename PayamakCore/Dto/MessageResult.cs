using System;
using System.Collections.Generic;

namespace PayamakCore.Dto;

public class MessageResultDto
{
    public int MsgID { get; set; }

    public string Body { get; set; }

    public DateTime SendDate { get; set; }

    public string Sender { get; set; }

    public string Receiver { get; set; }

    public int FirstLocation { get; set; }

    public int CurrentLocation { get; set; }

    public int Parts { get; set; }

    public int RecCount { get; set; }

    public int RecFailed { get; set; }

    public int RecSuccess { get; set; }

    public bool IsUnicode { get; set; }
}

public class MessageListDto
{
    public ResultDto MyBase { get; set; }

    public List<MessageResultDto> Data { get; set; }
}

public class GetUserNumberList
{
    public ResultDto MyBase { get; set; }

    public List<UserNumberDto> Data { get; set; }
}