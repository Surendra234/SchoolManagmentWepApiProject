using System;
using Amazon.Lambda.AspNetCoreServer;

namespace SchoolManagmentSystem
{
	public class LambdaEntryPoint: APIGatewayHttpApiV2ProxyFunction
	{
        protected override void Init(IWebHostBuilder builder)
        {
            builder.UseStartup<Program>();
        }
    }
}

