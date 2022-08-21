namespace Email.SDK.Models
{
    public class EmailSDKModel
    {
        public int Id { get; set; }
        public string Recipient { get; set; } = null!;
        public bool Sent { get; set; }
    }
}
