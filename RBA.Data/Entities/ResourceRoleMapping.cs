using System;
using System.Collections.Generic;
using System.Text;

namespace RBA.Data.Entities
{
    public partial class ResourceRoleMapping
    {
        public int ResourceId { get; set; }
        public int RoleId { get; set; }

        public virtual Resource Resource { get; set; }
        public virtual Roles Role { get; set; }
    }
}
