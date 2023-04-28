using IsTakip.Core.Classes.BaseClass;

namespace IsTakip.Core.Classes.BuinessClasses
{
    public class ProductionLead : BaseEntity
    {



        public Enum.Enums.ProductionOrder productionOrder { get; set; }



        public int LeadTime { get; set; }

        public Enum.Enums.ProductionLeadType productionLeadType { get; set; }


    }
}
