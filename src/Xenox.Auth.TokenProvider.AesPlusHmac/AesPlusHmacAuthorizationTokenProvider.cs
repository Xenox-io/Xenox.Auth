using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xenox.Auth.Models;
using Xenox.Encryption;
using Xenox.Serialization;

namespace Xenox.Auth.TokenProvider.AesPlusHmac {
	public class AesPlusHmacAuthorizationTokenProvider : IAuthorizationTokenProvider {
		private readonly IEncryptThenMacService _encryptThenMacService;
		private readonly ISerializationService _serializationService;
		private readonly AesPlusHmacAuthorizationTokenProviderOptions _options;

		public AesPlusHmacAuthorizationTokenProvider(
			IEncryptThenMacService encryptThenMacService,
			ISerializationService serializationService,
			AesPlusHmacAuthorizationTokenProviderOptions options
		) {
			_encryptThenMacService = encryptThenMacService;
			_serializationService = serializationService;
			_options = options;
		}

		public async Task<SerializedAuthorizationToken> GenerateAuthorizationToken(User user, IEnumerable<Permission> permissions) {
			return new SerializedAuthorizationToken(
				Convert.ToBase64String(
					_serializationService.SerializeToBytes(
						await _encryptThenMacService.EncryptThenMac(
							_serializationService.SerializeToBytes(new AuthorizationToken() {
								User = user,
								Permissions = permissions.ToList(),
								AuthorizationValidForMinutes = _options.AuthorizationValidForMinutes,
								RefreshValidForMinutes = _options.RefreshValidForMinutes
							})
						)
					)
				)
			);
		}
	}

	public class AesPlusHmacAuthorizationTokenProviderOptions {
		public int AuthorizationValidForMinutes { get; set; }
		public int RefreshValidForMinutes { get; set; }
	}
}
