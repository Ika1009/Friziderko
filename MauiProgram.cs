using Friziderko.ViewModel;

namespace Friziderko;

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

        //string dbPath = System.IO.Path.Combine(FileSystem.AppDataDirectory, "BazaPodataka3");//FileAccessHelper.GetLocalFilePath("people.db3");
        //builder.Services.AddSingleton<DodajUBazu>(s => ActivatorUtilities.CreateInstance<DodajUBazu>(s, dbPath));

        return builder.Build();
	}
}
