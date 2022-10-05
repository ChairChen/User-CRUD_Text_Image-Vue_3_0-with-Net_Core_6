using System;
using System.Collections.Generic;

namespace CRUD.Models
{
    public partial class User
    {
        public byte UserId { get; set; }
        public string Account { get; set; } = null!;
        public string Password { get; set; } = null!;
        public byte PermissionId { get; set; }
        public string? Token { get; set; }

        public virtual UserPermission Permission { get; set; } = null!;
    }
}
