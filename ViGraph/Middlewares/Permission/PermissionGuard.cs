using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace ViGraph.Middlewares.Permission
{
	internal class PermissionGuard : AuthorizationHandler<PermissionRequirement>
	{
		public PermissionGuard() { }

		protected override Task HandleRequirementAsync(
			AuthorizationHandlerContext context,
			PermissionRequirement requirement
		)
		{
			if (context.User == null) {
				return Task.CompletedTask;
			}

			var permissionss = context.User.Claims.Where(
				x => x.Type == "Permission" &&
				x.Value == requirement.Permission
			);

			if (permissionss.Any()) {
				context.Succeed(requirement);
				return Task.CompletedTask;
			}

			return Task.CompletedTask;
		}
	}
}
