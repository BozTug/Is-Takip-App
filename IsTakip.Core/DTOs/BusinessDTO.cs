using static IsTakip.Core.Classes.Enum.Enums;

namespace IsTakip.Core.DTOs
{
    public class BusinessDTO : BaseDTO
    {



        public int CustomerId { get; set; }

        public OfferType OfferType { get; set; }

        public int OfferNo { get; set; }

        public decimal Price { get; set; }

        public EndNoticeSituation EndNoticeSituation { get; set; }

        public BusinessPriority BusinessPriority { get; set; }

        public int CustomerOrderNo { get; set; }

        public string BusinessNote { get; set; }

        public Workmanship Workmanship { get; set; }
        public int SupplierId { get; set; }

        public string MaterialNote { get; set; }

    }
}
