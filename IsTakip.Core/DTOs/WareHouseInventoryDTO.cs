using static IsTakip.Core.Classes.Enum.Enums;

namespace IsTakip.Core.DTOs
{
    public class WareHouseInventoryDTO : BaseDTO
    {


        public int? WareHouseId { get; set; }

        public int? WareHouseShelfId { get; set; }

        public MaterialType materialType { get; set; }

        public Thickness thickness { get; set; }

        public float Width { get; set; }

        public float Length { get; set; }

        public float Amount { get; set; }

        public float Weight { get; set; }

        public string Explanation { get; set; }
        public int? CustomerId { get; set; }
        public int? SupplierId { get; set; }
    }
}
