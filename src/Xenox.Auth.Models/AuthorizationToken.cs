using System.Collections.Generic;

namespace Xenox.Auth.Models {
	public class AuthorizationToken {
		public User User { get; set; }
		public List<Permission> Permissions { get; set; }
		public int AuthorizationValidForMinutes { get; set; }
		public int RefreshValidForMinutes { get; set; }
	}
}
