using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xenox.Auth.AuthenticationProvider;
using Xenox.Auth.AuthenticationProvider.ActiveDirectory;
using Xenox.Auth.AuthorizationProvider;
using Xenox.Auth.AuthorizationProvider.TestAppService;
using Xenox.Auth.TokenProvider;
using Xenox.Auth.TokenProvider.AesPlusHmac;
using Xenox.DependencyInjection.Configuration;
using Xenox.Encryption.DependencyInjection;
using Xenox.Encryption.SuperBasicEncryption;
using Xenox.Serialization.JsonNet.DependencyInjection;

namespace Xenox.Auth.Host.DependencyInjection {
	public static class NosServiceCollectionExtensions {
		public static IServiceCollection AddAuthenticationNosActiveDirectory(this IServiceCollection serviceCollection, IConfiguration configuration) {
			if (serviceCollection == null) {
				throw new ArgumentNullException(nameof(serviceCollection));
			}
			return serviceCollection
				.AddAuthenticationNos()
				.AddActiveDirectoryUsernamePasswordAuthenticationProvider(configuration)
				.AddNosPermissionAuthorizationProvider(configuration)
				.AddAesPlusHmacAuthorizationTokenProviderOptions(configuration)
			;
		}

		private static IServiceCollection AddAuthenticationNos(this IServiceCollection serviceCollection) {
			return serviceCollection
				.AddSingleton<IUsernamePasswordAuthenticationService, UsernamePasswordAuthenticationService>()
			;
		}

		private static IServiceCollection AddActiveDirectoryUsernamePasswordAuthenticationProvider(this IServiceCollection serviceCollection, IConfiguration configuration) {
			return serviceCollection
				.AddSingleton<IUsernamePasswordAuthenticationProvider, ActiveDirectoryUsernamePasswordAuthenticationProvider>()
				.ConfigureWithOptionsObject<ActiveDirectoryUsernamePasswordAuthenticationProviderOptions>(configuration)
			;
		}

		private static IServiceCollection AddNosPermissionAuthorizationProvider(this IServiceCollection serviceCollection, IConfiguration configuration) {
			return serviceCollection
				.AddSingleton<IPermissionAuthorizationProvider, TestAppServicePermissionAuthorizationProvider>()
			;
		}

		private static IServiceCollection AddAesPlusHmacAuthorizationTokenProviderOptions(this IServiceCollection serviceCollection, IConfiguration configuration) {
			return serviceCollection
				.AddJsonNetSerialization()
				.AddEncryption()
				.AddSuperBasicEncryption()
				.AddSingleton<IAuthorizationTokenProvider, AesPlusHmacAuthorizationTokenProvider>()
				.ConfigureWithOptionsObject<AesPlusHmacAuthorizationTokenProviderOptions>(configuration)
			;
		}
	}
}
