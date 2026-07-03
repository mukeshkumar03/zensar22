namespace OrderManagement.Domain.Entities;

public class Order
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid CustomerId { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public decimal Total { get; private set; }
    public string Status { get; private set; } = "PENDING";

    public List<OrderItem> Items { get; private set; } = new();

    public Order(Guid customerId, IEnumerable<OrderItem> items)
    {
        CustomerId = customerId;
        Items = items.ToList();
        Total = Items.Sum(i => i.UnitPrice * i.Quantity);
    }

    private Order() { }
}

public class OrderItem
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }

    public OrderItem(Guid productId, int quantity, decimal unitPrice)
    {
        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }

    private OrderItem() { }
}