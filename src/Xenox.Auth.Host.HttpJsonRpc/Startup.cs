﻿using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xenox.AspNetCore.WebSockets.HttpJsonRpc;
using Xenox.Auth.Host.DependencyInjection;

namespace Xenox.Auth.Host.HttpJsonRpc {
	public class Startup {
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services) {
			IConfiguration configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.Build()
			;
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
