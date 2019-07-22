using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RBA.Data.Entities
{
    public partial class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual UserRolesMapping UserRolesMapping { get; set; }
    }
}
