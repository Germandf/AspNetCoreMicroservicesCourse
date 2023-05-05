using Ordering.Domain.Common;

namespace Ordering.Domain.Entities;

public class Order : EntityBase
{
    public required string UserName { get; set; }
    public required decimal TotalPrice { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string EmailAddress { get; set; }
    public required string AddressLine { get; set; }
    public required string Country { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public string CardName { get; set; }
    public string CardNumber { get; set; }
    public string Expiration { get; set; }
    public string CVV { get; set; }
    public int PaymentMethod { get; set; }
}
