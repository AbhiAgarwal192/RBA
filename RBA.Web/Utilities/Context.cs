using Microsoft.AspNetCore.Http;

namespace RBA.Web.Utilities
{
    public static class Context
    {
        public static string GetUserActionType(this HttpContext context)
        {
            string actionType = string.Empty;

            switch (context.Request.Method.ToLower())
            {
                case "post":
                    actionType = "CREATE";
                    break;
                case "delete":
                    actionType = "DELETE";
                    break;
                case "patch":
                case "put":
                    actionType = "UPDATE";
                    break;
                default:
                    actionType = "READ";
                    break;
            }

            return actionType;
        }
    }
}
