namespace FarapayamakApi.Models
{
    public class GetMessageListReq : Account
    {
        public int location { get; set; }

        public string from { get; set; }

        public int index { get; set; }

        public int count { get; set; }
    }
}