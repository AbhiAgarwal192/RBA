using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RBA.Data.Repository.Interfaces;
using RBA.Web.Utilities;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RBA
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IResourceRoleMappingRepository _resourceRoleMappingRepository;
        private readonly IActionTypeRoleRepository _actionTypeRoleRepository;
        private readonly ILogger<AuthorizationMiddleware> _logger;

        public AuthorizationMiddleware(RequestDelegate next, IResourceRoleMappingRepository resourceRoleMappingRepository,
                                                             IActionTypeRoleRepository actionTypeRoleRepository,
                                                             ILogger<AuthorizationMiddleware> logger)
        {
            _next = next;
            _resourceRoleMappingRepository = resourceRoleMappingRepository;
            _actionTypeRoleRepository = actionTypeRoleRepository;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            bool userHasAccess = false;

            //Find out which roles has access to the resource
            var resourceRoles = await _resourceRoleMappingRepository.GetRoles(context.Request.Path.Value);

            //Find out user roles
            var userRoles = context.User.Claims.FirstOrDefault(_claim => string.Equals(_claim.Type, Constants.Claim.Roles)).Value.Split(';');

            string actionType = context.GetUserActionType();

            foreach (var role in resourceRoles)
            {
                if (userRoles.Contains(role.ToString()))
                {
                    var allowedActionType = await _actionTypeRoleRepository.GetActionTypes(role);

                    if (allowedActionType.Contains(actionType))
                    {
                        userHasAccess = true;
                    }
                    break;
                }
            }

            string userName = context.User.Claims.FirstOrDefault(_claim => string.Equals(_claim.Type, Constants.Claim.Name)).Value;
            if (userHasAccess)
            {
                _logger.LogInformation($"User {userName} has access to the resource.");
                await _next(context);
            }
            else
            {
                _logger.LogInformation($"User {userName} does not have access to the resource.");
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            }
        }
    }
}
