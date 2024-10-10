using cqrs.Domains;
using cqrs.Events;

namespace cqrs.Models;

public class Order
{
    public Guid OrderId { get; private set; }
    public List<OrderItem> Items { get; private set; } = new List<OrderItem>();
    public decimal TotalPrice { get; private set; }

    public Order(Guid orderId)
    {
        OrderId = orderId;
    }

    public void AddItem(string product, int quantity, decimal pricePerUnit)
    {
        if (quantity <= 0 || pricePerUnit <= 0)
            throw new ArgumentException("Invalid item details.");

        var item = new OrderItem(product, quantity, pricePerUnit, OrderId);
        Items.Add(item);
        TotalPrice += item.PricePerUnit* item.Quantity;

        // Raise an event
        DomainEvents.Raise(new ItemAddedToOrder(OrderId, product, quantity, pricePerUnit));
    }
}

public class OrderItem
{
    public Guid OrderId { get;set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal PricePerUnit { get; set; }
    public string? ProductName { get; set; }

    public OrderItem(string? productName, int quantity, decimal pricePerUnit, Guid orderId)
    {
        this.Quantity = quantity;
        this.PricePerUnit = pricePerUnit;
        this.ProductName = productName;
        OrderId = orderId;  
    }
}