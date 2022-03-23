﻿using BuildInfoGenerator;
using LoggingHandler;
using Serilog;

namespace Notifications.Grpc
{
	public class Program
	{
        const string APP_NAME = "Notifications.Grpc";

        public static int Main(string[] args)
        {
            AppVersionInfo.InitialiseBuildInfoGivenPath(Directory.GetCurrentDirectory());
            SeriLogger.SetupLoggerConfiguration(APP_NAME, AppVersionInfo.GetBuildInfo());

            try
            {
                Log.Information("Starting notifications service");
                CreateHostBuilder(args).Build().Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Service terminated unexpectedly");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog((hostBuilderContext, services, loggerConfiguration) => SeriLogger.Configure(APP_NAME, hostBuilderContext, services, loggerConfiguration))
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}