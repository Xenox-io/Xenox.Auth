using System.Threading.Tasks;
using Xenox.Auth.Models;

namespace Xenox.Auth.Client.AuthorizationTokenClientProvider {
	public interface IAuthorizationTokenClientProvider {
		Task<AuthorizationToken> ParseAuthorizationToken(SerializedAuthorizationToken serializedAuthorizationToken);
	}
}
