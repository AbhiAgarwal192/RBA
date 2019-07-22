using RBA.Data;

namespace RBA
{
    public class DatabaseContext
    {
        public static void Initialize(RolesDbContext context)
        {
                context.ActionTypes.AddRange(new RBA.Data.Entities.ActionTypes
                {
                    Id = 1,
                    Name = "READ"
                },
                new RBA.Data.Entities.ActionTypes
                {
                    Id = 2,
                    Name = "WRITE"
                },
                new RBA.Data.Entities.ActionTypes
                {
                    Id = 3,
                    Name = "DELETE"
                });

                context.Roles.Add(new RBA.Data.Entities.Roles {
                    Id = 1,
                    Name = "Reader"
                });

                context.ActionTypeRoleMapping.Add(new RBA.Data.Entities.ActionTypeRoleMapping {
                    ActionTypeId = 1,
                    RoleId = 1
                });

                context.Resource.Add(new RBA.Data.Entities.Resource {
                    Id = 1,
                    Name = "/api/values"
                });

                context.ResourceRoleMapping.Add(new RBA.Data.Entities.ResourceRoleMapping {
                    RoleId = 1,
                    ResourceId = 1
                });

                context.User.Add(new RBA.Data.Entities.User {
                    Id = 1,
                    Name = "Abhi"
                });

                context.UserRolesMapping.Add(new RBA.Data.Entities.UserRolesMapping {
                    UserId = 1,
                    RoleId = 1
                });

                context.SaveChanges();
        }
    }
}
