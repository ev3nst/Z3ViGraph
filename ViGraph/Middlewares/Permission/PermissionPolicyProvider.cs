using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace ViGraph.Middlewares.Permission
{
	internal class PermissionPolicyProvider : IAuthorizationPolicyProvider
	{
		const string POLICY_PREFIX = "Permission";

		public DefaultAuthorizationPolicyProvider FallbackPolicyProvider { get; }

		public PermissionPolicyProvider(IOptions<AuthorizationOptions> options)
		{
			FallbackPolicyProvider = new DefaultAuthorizationPolicyProvider(options);
		}

		public Task<AuthorizationPolicy> GetDefaultPolicyAsync() => FallbackPolicyProvider.GetDefaultPolicyAsync();

		public Task<AuthorizationPolicy> GetFallbackPolicyAsync() => FallbackPolicyProvider.GetFallbackPolicyAsync();

		public Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
		{
			if (policyName.StartsWith(POLICY_PREFIX, StringComparison.OrdinalIgnoreCase)) {
				var policy = new AuthorizationPolicyBuilder();
				policy.AddRequirements(new PermissionRequirement(policyName));
				return Task.FromResult(policy.Build());
			}

			return FallbackPolicyProvider.GetPolicyAsync(policyName);
		}

	}
}
