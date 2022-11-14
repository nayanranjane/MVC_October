using ClientNs;
namespace MVC_CoreClient.Models
{
    public class CategorySearchModel
    {
        public int CategoryId { get; set; }
        public List<ClientNs.Category>? CatList { get; set; } = new List<ClientNs.Category>();
    }
}
