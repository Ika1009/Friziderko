using CommunityToolkit.Maui;
using Friziderko.View;
using Friziderko.ViewModel;

namespace Friziderko;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiCommunityToolkit()
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		//string dbPath = System.IO.Path.Combine(FileSystem.AppDataDirectory, "BazaPodataka.db3");//FileAccessHelper.GetLocalFilePath("people.db3");
		//builder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<DodajUBazu>(s, dbPath));

		builder.Services.AddSingleton<NamirnicePopupViewModel>();

		builder.Services.AddSingleton<NamirnicePopup>();

		builder.Services.AddSingleton<BazaPristupServis>();

		builder.Services.AddSingleton<FriziderPageViewModel>();

		builder.Services.AddSingleton<FriziderPage>();

        return builder.Build();
	}
}
