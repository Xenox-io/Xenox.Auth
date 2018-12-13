using System.Threading.Tasks;
using Xenox.Auth.Models;

namespace Xenox.Auth.AuthenticationProvider {
	public interface IUsernamePasswordAuthenticationProvider {
		Task<User> Authenticate(string username, string password);
	}
}
