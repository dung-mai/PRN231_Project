using System;
using System.Collections.Generic;

namespace Bussiness.DTO
{
    public class AccountDTO
    {
        public int Id { get; set; }
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
        public string? Fullname { 
            get { 
                return $"{Firstname} {Middlename} {Lastname}";
            }
        }

        public virtual RoleDTO Role { get; set; } = null!;
    }
}
