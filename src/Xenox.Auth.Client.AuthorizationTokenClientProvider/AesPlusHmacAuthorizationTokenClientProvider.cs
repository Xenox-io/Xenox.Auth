using System;
using System.Threading.Tasks;
using Xenox.Auth.Models;
using Xenox.Encryption;
using Xenox.Encryption.Models;
using Xenox.Serialization;

namespace Xenox.Auth.Client.AuthorizationTokenClientProvider {
	public class AesPlusHmacAuthorizationTokenClientProvider : IAuthorizationTokenClientProvider {
		private readonly IEncryptThenMacService _encryptThenMacService;
		private readonly ISerializationService _serializationService;

		public AesPlusHmacAuthorizationTokenClientProvider(
			IEncryptThenMacService encryptThenMacService,
			ISerializationService serializationService
		) {
			_encryptThenMacService = encryptThenMacService;
			_serializationService = serializationService;
		}

		public async Task<AuthorizationToken> ParseAuthorizationToken(SerializedAuthorizationToken serializedAuthorizationToken) {
			return _serializationService.DeserializeFromBytes<AuthorizationToken>(
				await _encryptThenMacService.ValidateAndDecrypt(
					_serializationService.DeserializeFromBytes<EncryptThenMacData>(
						Convert.FromBase64String(serializedAuthorizationToken.AuthorizationToken)
					)
				)
			);
		}
	}
}
