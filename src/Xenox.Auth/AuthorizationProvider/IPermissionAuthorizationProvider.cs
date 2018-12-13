using System.Collections.Generic;
using System.Threading.Tasks;
using Xenox.Auth.Models;

namespace Xenox.Auth.AuthorizationProvider {
	public interface IPermissionAuthorizationProvider {
		Task<IEnumerable<Permission>> GetAuthorizationForUser(User user);
	}
}
