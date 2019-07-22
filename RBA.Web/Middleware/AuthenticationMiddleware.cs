using Microsoft.AspNetCore.Http;
using RBA.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RBA.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IUserRolesMappingRepository _userRolesMappingRepository;
        public AuthenticationMiddleware(RequestDelegate next, IUserRolesMappingRepository userRolesMappingRepository)
        {
            _next = next;
            _userRolesMappingRepository = userRolesMappingRepository;
        }

        public async Task Invoke(HttpContext context)
        {
            var roles = await _userRolesMappingRepository.GetUserRoles(1);

            var claimsIdentity = new ClaimsIdentity();
            claimsIdentity.AddClaim(new Claim(Constants.Claim.Id, "1"));
            claimsIdentity.AddClaim(new Claim(Constants.Claim.Name,"Abhi Agarwal"));
            claimsIdentity.AddClaim(new Claim(Constants.Claim.Email,"sampleemail@gmail.com"));
            claimsIdentity.AddClaim(new Claim(Constants.Claim.Roles,roles));

            context.User = new ClaimsPrincipal(claimsIdentity);

            context.Items.Add("ActionType","READ");

            await _next.Invoke(context);
        }
    }
}
