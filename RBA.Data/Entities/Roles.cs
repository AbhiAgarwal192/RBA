using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RBA.Data.Entities
{
    public partial class Roles
    {
        public Roles()
        {
            ResourceRoleMapping = new HashSet<ResourceRoleMapping>();
            UserRolesMapping = new HashSet<UserRolesMapping>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ActionTypeRoleMapping ActionTypeRoleMapping { get; set; }
        public virtual ICollection<ResourceRoleMapping> ResourceRoleMapping { get; set; }
        public virtual ICollection<UserRolesMapping> UserRolesMapping { get; set; }
    }
}
