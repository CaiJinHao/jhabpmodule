using System;
using System.IO;
using System.Threading.Tasks;
using Jh.Abp.QuickComponents;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace Jh.Abp.JhIdentity;

public class Program
{
    public async static Task<int> Main(string[] args)
    {
        /*Log.Logger = new LoggerConfiguration()
#if DEBUG
    .MinimumLevel.Debug()
#else
            .MinimumLevel.Information()
#endif
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
    .Enrich.FromLogContext()
     .WriteTo.Async(c => c.File("Logs/logs.txt",
        outputTemplate: Jh.Abp.Common.AbpConsts.SerilogOutputTemplate,
        restrictedToMinimumLevel: LogEventLevel.Error,
        fileSizeLimitBytes: 1024000,
        rollingInterval: RollingInterval.Day,
        retainedFileCountLimit: 90))
#if DEBUG
    .WriteTo.Async(c => c.Console())
#endif
    .CreateLogger();*/
        //获取配置文件
        Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(AppUtils.GetLogBuildConfiguration("logconfig.json")).CreateLogger();
        try
        {
            Log.Information("Starting web host.");
            var builder = WebApplication.CreateBuilder(args);
            builder.Host.AddAppSettingsSecretsJson()
                .UseAutofac()
                .UseSerilog();
            await builder.AddApplicationAsync<JhIdentityIdentityServerModule>();
            var app = builder.Build();
            await app.InitializeApplicationAsync();
            await app.RunAsync();
            return 0;
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Host terminated unexpectedly!");
            return 1;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}
