using System;
using System.Collections.Generic;
using System.Text;

namespace RBA.Data.Entities
{
    public partial class ActionTypeRoleMapping
    {
        public int RoleId { get; set; }
        public int ActionTypeId { get; set; }

        public virtual ActionTypes ActionType { get; set; }
        public virtual Roles Role { get; set; }
    }
}
