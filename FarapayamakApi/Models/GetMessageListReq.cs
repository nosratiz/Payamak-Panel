namespace FarapayamakApi.Models
{
    public class GetMessageListReq : Account
    {
        public int Location { get; set; }

        public string Form { get; set; }

        public int Index { get; set; }

        public int Count { get; set; }
    }
}