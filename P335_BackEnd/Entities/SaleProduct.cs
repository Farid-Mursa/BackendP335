namespace P335_BackEnd.Entities
{
    public class SaleProduct
    {
        public int Id { get; set; }
        public sbyte Discount { get; set; }
        public List<Product>? Products { get; set; }
    }
}
