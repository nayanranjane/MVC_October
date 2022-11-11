namespace NorthWindDatabase.Models
{
    public class ResponseObject
    {
        public List<Customer>? Customers { get; set; }
        public List<Order>? Orders { get; set; }
        public List<Product>? products { get; set; }

        public Customer? Customer { get; set; }

        public int? StatusCode { get; set; }
    }
}
