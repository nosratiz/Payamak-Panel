using System;

namespace FarapayamakApi.Models
{
    public class MessageResult
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
}