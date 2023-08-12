using NominalBackend.Domain.Images.Models;
using NominalBackend.Domain.Items.Models;

namespace NominalBackend.DataTransferObjects
{
    public class GetAndFilterItemsDTO
    {
        public Item Item { get; set; }
        public List<Color> AvailableColors { get; set; }
    }
}
