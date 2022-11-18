using StudentList.ViewModels;

namespace StudentList.Views;

public partial class StudentListPage : ContentPage
{
	protected StudentListPageViewModel _viewMode;
	public StudentListPage(StudentListPageViewModel viewModel)
	{
		InitializeComponent();
		_viewMode = viewModel;
		this.BindingContext = viewModel;
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		_viewMode.GetStudentListCommand.Execute(null);
	}
}