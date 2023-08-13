namespace IAB_Data.DatabaseEntities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderPlaced { get; set; }
        public DateTime OrderFulFilled { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public ICollection<OrderDetails> OrderDetails { get; set; } = null!;
    }
}