namespace IsTakip.Core.DTOs
{
    public class CustomerDTO : BaseDTO
    {


        public string Description { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string TaxAdministration { get; set; }
        public int TaxNumber { get; set; }

        public string? Explanation { get; set; }

        public int? CustomerClassId { get; set; }

        public int? CustomerRestrictionId { get; set; }
        public int? CustomerRepresentativeId { get; set; }

        public int? UserId { get; set; }

    }
}
