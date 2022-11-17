using StudentList.Services;
using StudentList.ViewModels;
using StudentList.Views;

namespace StudentList;

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

        builder.Services.AddSingleton<IStudentService, StudentService>();

        builder.Services.AddSingleton<StudentListPage>();
        builder.Services.AddSingleton<AddUpdateStudentDetail>();

        builder.Services.AddSingleton<StudentListPageViewModel>();
        builder.Services.AddSingleton<AddUpdateStudentDetailViewModel>();

        return builder.Build();
	}
}
