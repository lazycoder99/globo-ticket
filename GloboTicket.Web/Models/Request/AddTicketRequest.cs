namespace GloboTicket.Web.Models.Request
{
    // Request model have exact required fields from endpoint, it might be less or more
    public class AddTicketRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int ClientId { get; set; }
    }
}
