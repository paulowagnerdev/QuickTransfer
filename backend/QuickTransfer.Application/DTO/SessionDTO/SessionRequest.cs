namespace Application.DTO;

public record SessionRequest(
    Guid Id,
    string Token,
    DateTime CreatedAt
);

