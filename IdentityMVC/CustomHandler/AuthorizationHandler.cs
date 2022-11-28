using Microsoft.AspNetCore.Authorization;

namespace IdentityMVC.CustomHandler
{
    public class AuthorizationHandler
    {
        public class RoleRequirement : IAuthorizationRequirement
        {
            public string Role { get; set; }
            public RoleRequirement(string role)
            {
                Role = role;
            }
        }

        /// <summary>
        ///  The Custom Handle for Authozation
        /// </summary>
        //public class AgeRequirementHandler : AuthorizationHandler<Rolere>
        //{
        //    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AgeRequirement requirement)
        //    {
        //        DateTime userDateOfBirth = DateTime.Parse(context.User.FindFirst(c => c.Type == ClaimTypes.DateOfBirth).Value);

        //        // Get Age
        //        int age = DateTime.Today.Year - userDateOfBirth.Year;
        //        if (age >= requirement.Age)
        //        {
        //            // Provide Access or USe this Success on View
        //            context.Succeed(requirement);
        //        }

        //        return Task.CompletedTask;
        //    }
        //}

        public class RoleRequiremetHandler : AuthorizationHandler<RoleRequirement>
        {
            protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleRequirement requirement)
            {
                throw new NotImplementedException();
            }
        }
    }
}
