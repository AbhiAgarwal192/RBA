using System;
using System.Collections.Generic;
using System.Text;

namespace RBA.Data.Entities
{
    public partial class UserRolesMapping
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public virtual Roles Role { get; set; }
        public virtual User User { get; set; }
    }
}
