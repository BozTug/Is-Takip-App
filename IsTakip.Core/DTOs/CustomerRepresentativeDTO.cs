namespace IsTakip.Core.DTOs
{
    public class CustomerRepresentativeDTO : BaseDTO
    {

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public int CustomerId { get; set; }
    }
}
