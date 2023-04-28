namespace IsTakip.Core.DTOs
{
    public class ProductionLeadDTO : BaseDTO
    {


        public int ProductionOrderId { get; set; }

        public int LeadTime { get; set; }

        public int ProductionLeadTypeId { get; set; }
    }
}
