namespace Email.DataAccess
{
    public partial class Email
    {
        public int Id { get; set; }
        public string Recipient { get; set; } = null!;
        public bool Sent { get; set; }
    }
}
