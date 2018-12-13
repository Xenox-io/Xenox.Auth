namespace Xenox.Auth.Models {
	public class SerializedAuthorizationToken {
		public string AuthorizationToken { get; }

		public SerializedAuthorizationToken(string authorizationToken) {
			AuthorizationToken = authorizationToken;
		}
	}
}
