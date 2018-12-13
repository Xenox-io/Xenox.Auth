using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xenox.AspNetCore.WebSockets.HttpJsonRpc;
using Xenox.Auth.Host.DependencyInjection;
using Xenox.DependencyInjection.Configuration;

namespace Xenox.Auth.Host.HttpJsonRpc {
	public class Startup {
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services) {
			IConfiguration configuration = ConfigurationService.GetConfigurationJson("appsettings.json");
			services.AddJsonRpcWithWebSocketsSupport(config => {
				config.ShowServerExceptions = true;
			});
			services.AddAuthenticationNosActiveDirectory(configuration);
		}

		public void Configure(IApplicationBuilder application, IHostingEnvironment environment) {
			application.UseJsonRpcWithWebSocketsSupport();
		}
	}
}
