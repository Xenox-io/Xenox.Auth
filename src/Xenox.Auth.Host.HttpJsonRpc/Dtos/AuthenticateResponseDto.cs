using Xenox.Auth.Models;

namespace Xenox.Auth.Host.HttpJsonRpc.Dtos {
	public class AuthenticateResponseDto {
		public string AuthorizationToken { get; set; }

		public AuthenticateResponseDto(string token) {
			AuthorizationToken = token;
		}

		public AuthenticateResponseDto(SerializedAuthorizationToken authorizationToken) {
			AuthorizationToken = authorizationToken.AuthorizationToken;
		}
	}
}
