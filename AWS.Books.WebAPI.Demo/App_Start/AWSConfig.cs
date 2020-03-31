using Amazon.DynamoDBv2;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AWS.Books.WebAPI.Demo
{
    public partial class Startup
    {
        public void ConfigureAWS(IServiceCollection services)
        {
            if (HostingEnvironment.IsDevelopment())
            {
                Environment.SetEnvironmentVariable("AWS_ACCESS_KEY_ID", Configuration["AWS:AccessKey"]);
                Environment.SetEnvironmentVariable("AWS_SECRET_ACCESS_KEY", Configuration["AWS:SecretKey"]);
                Environment.SetEnvironmentVariable("AWS_REGION", Configuration["AWS:Region"]);
            }
            
            services.AddDefaultAWSOptions(Configuration.GetAWSOptions());

            services.AddAWSService<IAmazonDynamoDB>();
        }
    }
}
