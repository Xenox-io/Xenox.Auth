using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xenox.Auth.Models;

namespace Xenox.Auth.AuthorizationProvider.TestAppService {
	public class TestAppServicePermissionAuthorizationProvider : IPermissionAuthorizationProvider {
		public Task<IEnumerable<Permission>> GetAuthorizationForUser(User user) {
			return Task.FromResult(new List<Permission>() {
				new Permission("Xenox", "TestCommand")
			}.AsEnumerable());
		}
	}
}
