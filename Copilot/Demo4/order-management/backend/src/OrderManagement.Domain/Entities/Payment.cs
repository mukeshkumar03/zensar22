namespace OrderManagement.Domain.Entities;

public class Payment
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid OrderId { get; private set; }
    public decimal Amount { get; private set; }
    public string Currency { get; private set; } = "USD";
    public string Status { get; private set; } = "PENDING";
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    public Payment(Guid orderId, decimal amount, string currency)
    {
        OrderId = orderId;
        Amount = amount;
        Currency = currency;
    }

    private Payment() { }
}