using Microsoft.Extensions.DependencyInjection;
using Xenox.Auth.Client.AuthorizationTokenClientProvider;

namespace Xenox.Auth.Client.DependencyInjection {
	public static class AesPlusHmacAuthorizationTokenClientProviderServiceCollectionExtensions {
		public static IServiceCollection AddAesPlusHmacAuthorizationTokenClient(this IServiceCollection serviceCollection) {
			return serviceCollection.AddSingleton<IAuthorizationTokenClientProvider, AesPlusHmacAuthorizationTokenClientProvider>();
		}
	}
}
