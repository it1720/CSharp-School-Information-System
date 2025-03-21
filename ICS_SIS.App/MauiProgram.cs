﻿using CommunityToolkit.Maui;
using ICS_SIS.App.Services;
using ICS_SIS.BL;
using ICS_SIS.DAL;
using ICS_SIS.DAL.Migrator;
using ICS_SIS.DAL.Options;
using Microsoft.Extensions.Configuration;
using System.Reflection;


[assembly: System.Resources.NeutralResourcesLanguage("en")]
namespace ICS_SIS.App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("fa-solid-900.ttf", "FontAwsome");
                });

            ConfigureAppSettings(builder);

            builder.Services
                .AddDALServices(GetDALOptions(builder.Configuration))
                .AddAppServices()
                .AddBLServices();

            var app = builder.Build();

            MigrateDb(app.Services.GetRequiredService<IDbMigrator>());
            RegisterRouting(app.Services.GetRequiredService<INavigationService>());

            return app;
        }

        private static void ConfigureAppSettings(MauiAppBuilder builder)
        {
            var configurationBuilder = new ConfigurationBuilder();

            var assembly = Assembly.GetExecutingAssembly();
            const string appSettingsFilePath = "ICS_SIS.App.appsettings.json";
            using var appSettingsStream = assembly.GetManifestResourceStream(appSettingsFilePath);
            if (appSettingsStream is not null)
            {
                configurationBuilder.AddJsonStream(appSettingsStream);
            }

            var configuration = configurationBuilder.Build();
            builder.Configuration.AddConfiguration(configuration);
        }

        private static void RegisterRouting(INavigationService navigationService)
        {
            foreach (var route in navigationService.Routes)
            {
                Routing.RegisterRoute(route.Route, route.ViewType);
            }
        }

        private static DALOptions GetDALOptions(IConfiguration configuration)
        {
            DALOptions dalOptions = new()
            {
                DatabaseDirectory = FileSystem.AppDataDirectory
            };
            configuration.GetSection("ICS_SIS:DAL").Bind(dalOptions);
            return dalOptions;
        }

        private static void MigrateDb(IDbMigrator migrator) => migrator.Migrate();
    }
}
