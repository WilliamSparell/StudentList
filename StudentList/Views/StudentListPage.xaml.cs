using StudentList.ViewModels;

namespace StudentList.Views;

public partial class StudentListPage : ContentPage
{
	public StudentListPage(StudentListPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}