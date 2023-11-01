namespace DTO.Request.Account
{
    public class AccountCreateStudentDTO
    {
        public string? Phonenumber { get; set; }
        public bool? Gender { get; set; }
        public string IdCard { get; set; } = null!;
        public DateTime? Dob { get; set; }
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string Middlename { get; set; } = null!;
        public string? Address { get; set; }
        public string? Image { get; set; }
        public short Status { get; set; }
    }
}
