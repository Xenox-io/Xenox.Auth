using System;
using System.DirectoryServices.AccountManagement;
using System.Threading.Tasks;
using Xenox.Auth.Models;

namespace Xenox.Auth.AuthenticationProvider.ActiveDirectory {
	public class ActiveDirectoryUsernamePasswordAuthenticationProvider : IUsernamePasswordAuthenticationProvider {
		private readonly ActiveDirectoryUsernamePasswordAuthenticationProviderOptions _options;

		public ActiveDirectoryUsernamePasswordAuthenticationProvider(ActiveDirectoryUsernamePasswordAuthenticationProviderOptions options) {
			_options = options;
		}

		public Task<User> Authenticate(string username, string password) {
			using (PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, _options.ActiveDirectoryDomain)) {
				if (!principalContext.ValidateCredentials(username, password)) {
					throw new Exception("Invalid username or password.");
				}
			}
			return Task.FromResult(new User(username));
		}
	}

	public class ActiveDirectoryUsernamePasswordAuthenticationProviderOptions {
		public string ActiveDirectoryDomain { get; set; }
	}
}
