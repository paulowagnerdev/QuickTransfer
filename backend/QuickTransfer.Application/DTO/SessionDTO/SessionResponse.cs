public class SessionResponse()
{
    public Guid Id { get; set; }
    public DateTime CreateAt { get; set; } = DateTime.UtcNow;
    public DateTime ExpiresAt { get; set; }
}