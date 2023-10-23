namespace DTO.Request.Role
{
    public class RoleAddDTO
    {
        public string? RoleName { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsDelete { get; set; } = false;
    }
}
