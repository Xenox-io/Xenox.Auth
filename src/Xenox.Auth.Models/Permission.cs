namespace Xenox.Auth.Models {
	public class Permission {
		public string RoutingKey { get; }
		public string CommandName { get; }

		public Permission(string routingKey, string commandName) {
			RoutingKey = routingKey;
			CommandName = commandName;
		}
	}
}
