namespace QuickTransfer.Entities.Domain;

public class Message
{
    public int Id { get; private set; }
    public int SessionId { get; private set; }
    public string Content { get; private set; } = string.Empty;
    public DateTime CreatedAt { get; private set; }
    public string Sender { get; private set; } = string.Empty;

    public Session Session { get; private set; } = null!;

    protected Message() { }

    public Message(int sessionId, string content, string sender)
    {
        if (sessionId <= 0)
            throw new ArgumentException("O SessionId deve ser maior que zero.", nameof(sessionId));

        if (string.IsNullOrWhiteSpace(content))
            throw new ArgumentException("O conteúdo da mensagem não pode ser vazio.", nameof(content));

        if (string.IsNullOrWhiteSpace(sender))
            throw new ArgumentException("O remetente não pode ser vazio.", nameof(sender));

        SessionId = sessionId;
        Content = content.Trim();
        Sender = sender.Trim();
        CreatedAt = DateTime.UtcNow;
    }
}