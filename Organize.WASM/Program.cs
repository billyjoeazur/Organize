using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Organize.Shared.Contracts;
using Organize.Business;
using Organize.TestFake;

namespace Organize.WASM
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("app");

			builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

			//builder.Services.AddSingleton<IUserManager, UserManager>();
			builder.Services.AddScoped<IUserManager, UserManagerFake>();

			builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();

			await builder.Build().RunAsync();
		}
	}
}
