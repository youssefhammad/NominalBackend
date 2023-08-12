using NominalBackend.Domain.Items.Models;

namespace NominalBackend.DataTransferObjects
{
    public class WishlistDto
    {
        public int Id { get; set; }
        public List<Item> Items { get; set; }
        public int WishlisId { get; set; }
    }
}
