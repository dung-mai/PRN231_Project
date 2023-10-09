using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public class Role
    {
        public Role()
        {
            Accounts = new HashSet<Account>();
        }

        public int Roleid { get; set; }
        public string? RoleName { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
