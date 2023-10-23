namespace DTO.Request.Role
{
    public class RoleUpdateDTO
    {
        public int Roleid { get; set; }
        public string? RoleName { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsDelete { get; set; } = false;
    }
}
