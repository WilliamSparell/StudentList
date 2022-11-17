using StudentList.ViewModels;

namespace StudentList.Views;

public partial class AddUpdateStudentDetail : ContentPage
{
	public AddUpdateStudentDetail(AddUpdateStudentDetailViewModel addUpdateStudentDetailViewModel)
	{
		InitializeComponent();
		this.BindingContext = addUpdateStudentDetailViewModel;
	}
}