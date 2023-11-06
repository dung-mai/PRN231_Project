namespace DTO.Request.Account
{
    public class AccountUpdateStudentDTO
    {
        public int Id { get; set; }
        public string? Phonenumber { get; set; }
        public bool? Gender { get; set; }
        public string? Address { get; set; }
        public string? Image { get; set; }
    }
}
