namespace KadelDemo.Models;

/// <summary>
/// Represents an order in the system.
/// </summary>
public class Order
{
    /// <summary>
    /// Gets or sets the unique identifier for the order.
    /// </summary>
    public int? Id { get; set; }

    /// <summary>
    /// Gets or sets the order number.
    /// </summary>
    public string? OrderNumber { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the order was placed.
    /// </summary>
    public DateTime? OrderDate { get; set; }

    /// <summary>
    /// Gets or sets the customer name.
    /// </summary>
    public string? CustomerName { get; set; }

    /// <summary>
    /// Gets or sets the customer email address.
    /// </summary>
    public string? CustomerEmail { get; set; }

    /// <summary>
    /// Gets or sets the shipping address.
    /// </summary>
    public string? ShippingAddress { get; set; }

    /// <summary>
    /// Gets or sets the order status (e.g., "Pending", "Processing", "Shipped", "Delivered", "Cancelled").
    /// </summary>
    public string? Status { get; set; }

    /// <summary>
    /// Gets or sets the total amount of the order.
    /// </summary>
    public string? TotalAmount { get; set; }

    /// <summary>
    /// Gets or sets additional notes or comments for the order.
    /// </summary>
    public string? Notes { get; set; }
}

