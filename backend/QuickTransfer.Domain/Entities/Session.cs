namespace QuickTransfer.Entities.Domain;

public class Session
{
    public int Id { get; private set; }
    public Guid PublicId { get; set; } = Guid.NewGuid();
    public string Token { get; private set; } = string.Empty;
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime ExpiresAt { get; private set; }
    public ICollection<Message> Messages { get; private set; } = new List<Message>();

    protected Session() { }

    public Session(string token, DateTime expiresAt)
    {
        if (string.IsNullOrWhiteSpace(token))
            throw new ArgumentException("O token não pode ser vazio.", nameof(token));

        if (expiresAt <= DateTime.UtcNow)
            throw new ArgumentException("A data de expiração deve ser futura.", nameof(expiresAt));

        Token = token;
        CreatedAt = DateTime.UtcNow;
        ExpiresAt = expiresAt;
    }
}