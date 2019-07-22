using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RBA.Data.Entities
{
    public partial class ActionTypes
    {
        public ActionTypes()
        {
            ActionTypeRoleMapping = new HashSet<ActionTypeRoleMapping>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ActionTypeRoleMapping> ActionTypeRoleMapping { get; set; }
    }
}
