namespace IsTakip.Core.DTOs.SpecifiedDTOs
{
    public class UserWithCustomerDTO : UserDTO
    {
        public CustomerDTO Customer { get; set; }
    }
}
