namespace FarapayamakApi.Models
{
    public class BaseService : Account
    {
        public string Text { get; set; }

        public string To { get; set; }

        public int BodyId { get; set; }
    }
}