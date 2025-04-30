namespace Dependecy_injection.Models.Domain
{
    public class Notification
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
        public string Message { get; set; }
        public DateTime SentTimestamp { get; set; }
    }
}
