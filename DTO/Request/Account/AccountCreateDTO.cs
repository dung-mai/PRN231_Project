namespace DTO.Request.Account
{
    public class AccountCreateDTO
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int Roleid { get; set; }
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
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsDelete { get; set; } = false;
    }
}
