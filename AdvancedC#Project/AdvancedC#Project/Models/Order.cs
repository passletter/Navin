namespace ErpOrderProcessing.Models
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Source { get; set; } = "Web";
        public decimal Amount { get; set; } = new Random().Next(100, 1000);
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}