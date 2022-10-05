using System;
using System.Collections.Generic;

namespace CRUD.Models
{
    public partial class UserPermission
    {
        public UserPermission()
        {
            Users = new HashSet<User>();
        }

        public byte PermissionId { get; set; }
        public bool PostPerm { get; set; }
        public bool PutPerm { get; set; }
        public bool DeletePerm { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
