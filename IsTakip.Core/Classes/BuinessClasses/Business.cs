using IsTakip.Core.Classes.BaseClass;
using IsTakip.Core.Classes.CustomerClasses;
using IsTakip.Core.Classes.SupplierClass;

using static IsTakip.Core.Classes.Enum.Enums;
using MaterialType = IsTakip.Core.Classes.Enum.Enums.MaterialType;

namespace IsTakip.Core.Classes.BuinessClasses
{
    public class Business : BaseEntity
    {


        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public OfferType OfferType { get; set; }

        public int OfferNo { get; set; }

        public decimal Price { get; set; }

        public EndNoticeSituation EndNoticeSituation { get; set; }



        public BusinessPriority BusinessPriority { get; set; }

        public int CustomerOrderNo { get; set; }

        public string BusinessNote { get; set; }

        public MaterialType materialType { get; set; }

        public Enum.Enums.Thickness thickness { get; set; }


        public Workmanship Workmanship { get; set; }

        public string MaterialNote { get; set; }

        public Jobfile Jobfile { get; set; }

        public ProductionOrder ProductionOrder { get; set; }

        public int SupplierId { get; set; }

        public Supplier Supplier { get; set; }
    }
}
