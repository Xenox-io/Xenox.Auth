using System;
using System.Threading.Tasks;
using EdjCase.JsonRpc.Core;
using EdjCase.JsonRpc.Router;
using EdjCase.JsonRpc.Router.Abstractions;
using EdjCase.JsonRpc.Router.Defaults;
using Xenox.Auth.Host.HttpJsonRpc.Dtos;
using Xenox.Auth.Models;

namespace Xenox.Auth.Host.HttpJsonRpc.Controllers {
	[RpcRoute("api/rpc.json")]
	public class JsonRpcAuthenticationController : RpcController {
		private readonly IUsernamePasswordAuthenticationService _usernamePasswordAuthenticationService;

		public JsonRpcAuthenticationController(IUsernamePasswordAuthenticationService usernamePasswordAuthenticationService) {
			_usernamePasswordAuthenticationService = usernamePasswordAuthenticationService;
		}

		public async Task<IRpcMethodResult> Authenticate(
			string username,
			string password
		) {
			if (string.IsNullOrWhiteSpace(username)) {
				return new RpcMethodErrorResult((int)RpcErrorCode.InvalidParams, "Username must be provided.");
			}
			if (string.IsNullOrWhiteSpace(password)) {
				return new RpcMethodErrorResult((int)RpcErrorCode.InvalidParams, "Password must be provided.");
			}
			SerializedAuthorizationToken serializedAuthorizationToken;
			try {
				serializedAuthorizationToken = await _usernamePasswordAuthenticationService.Authenticate(username, password);
			} catch (Exception exception) {
				return new RpcMethodErrorResult((int)RpcErrorCode.InternalError, exception.Message);
			}
			return new RpcMethodSuccessResult(new AuthenticateResponseDto(serializedAuthorizationToken));
		}
	}
}
