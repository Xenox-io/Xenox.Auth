using System.Threading.Tasks;
using Xenox.Auth.Models;

namespace Xenox.Auth {
	public interface IUsernamePasswordAuthenticationService {
		Task<SerializedAuthorizationToken> Authenticate(string username, string password);
	}
}
