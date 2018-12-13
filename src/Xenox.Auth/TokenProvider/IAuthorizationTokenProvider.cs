using System.Collections.Generic;
using System.Threading.Tasks;
using Xenox.Auth.Models;

namespace Xenox.Auth.TokenProvider {
	public interface IAuthorizationTokenProvider {
		Task<SerializedAuthorizationToken> GenerateAuthorizationToken(User user, IEnumerable<Permission> permissions);
	}
}
