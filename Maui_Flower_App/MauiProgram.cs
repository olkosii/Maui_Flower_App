﻿using Maui_Flower_App.Helpers;
using Maui_Flower_App.Repositories;
using Maui_Flower_App.Repositories.DI;

namespace Maui_Flower_App;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddSingleton<IOrderRepository, SQLOrderRepository>();
        builder.Services.AddSingleton<IClientRepository, SQLClientRepository>();
		builder.Services.AddSingleton<IFlowerRepository, SQLFlowerRepository>();

        var app = builder.Build();

		ServiceHelper.Initialize(app.Services);

		return app;
	}
}
