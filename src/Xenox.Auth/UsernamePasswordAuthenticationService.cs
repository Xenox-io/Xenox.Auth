using System.Collections.Generic;
using System.Threading.Tasks;
using Xenox.Auth.AuthenticationProvider;
using Xenox.Auth.AuthorizationProvider;
using Xenox.Auth.Models;
using Xenox.Auth.TokenProvider;

namespace Xenox.Auth {
	public class UsernamePasswordAuthenticationService : IUsernamePasswordAuthenticationService {
		private readonly IUsernamePasswordAuthenticationProvider _usernamePasswordAuthenticationProvider;
		private readonly IPermissionAuthorizationProvider _permissionAuthorizationProvider;
		private readonly IAuthorizationTokenProvider _authorizationTokenProvider;

		public UsernamePasswordAuthenticationService(
			IUsernamePasswordAuthenticationProvider usernamePasswordAuthenticationProvider,
			IPermissionAuthorizationProvider permissionAuthorizationProvider,
			IAuthorizationTokenProvider authorizationTokenProvider
		) {
			_usernamePasswordAuthenticationProvider = usernamePasswordAuthenticationProvider;
			_permissionAuthorizationProvider = permissionAuthorizationProvider;
			_authorizationTokenProvider = authorizationTokenProvider;
		}

		public async Task<SerializedAuthorizationToken> Authenticate(string username, string password) {
			User user = await _usernamePasswordAuthenticationProvider.Authenticate(username, password);
			IEnumerable<Permission> permissions = await _permissionAuthorizationProvider.GetAuthorizationForUser(user);
			SerializedAuthorizationToken serializedAuthorizationToken = await _authorizationTokenProvider.GenerateAuthorizationToken(user, permissions);
			return serializedAuthorizationToken;
		}
	}
}
