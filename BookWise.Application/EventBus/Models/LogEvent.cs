namespace Application.EventBus.Models
{
    public class LogEvent
    {
        public string TransactionType { get; set; } = string.Empty;
        public string TransID { get; set; } = string.Empty;
        public string TransTime { get; set; } = string.Empty;
        public string TransAmount { get; set; } = string.Empty;
    }
}
