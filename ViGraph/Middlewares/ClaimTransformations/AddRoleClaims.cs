using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using ViGraph.Repository.IRepository;

namespace ViGraph.Middlewares.ClaimTransformations
{
	public class AddRoleClaims : IClaimsTransformation
	{
		private readonly IAppUserRepository _appUserRepo;

		public AddRoleClaims(IAppUserRepository appUserRepo)
		{
			_appUserRepo = appUserRepo;
		}

		public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
		{
			var clone = principal.Clone();
			var newIdentity = (ClaimsIdentity)clone.Identity;
			var claimType = "Permission";

			if (!principal.HasClaim(claim => claim.Type == claimType)) {
				var userId = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier || c.Type == ClaimTypes.Name);
				if (userId == null) {
					return principal;
				}

				int userIdParsed;
				if (int.TryParse(userId.Value, out userIdParsed)) {
					var user = await _appUserRepo.GetUserByIdWithRoles(userIdParsed);
					if (user == null) {
						return principal;
					}

					foreach (var roleClaim in user.UserRole.Role.RoleClaims) {
						newIdentity.AddClaim(new Claim(claimType, roleClaim.ClaimValue));
					}
				} else {
					return principal;
				}

			}

			return clone;
		}
	}
}