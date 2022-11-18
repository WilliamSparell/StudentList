
namespace StudentList.ViewModels
{
    [QueryProperty(nameof(StudentDetail), "StudentDetail")]
    public partial class AddUpdateStudentDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        private StudentModel _studentDetail = new StudentModel();

        private readonly IStudentService _studentService;
        public AddUpdateStudentDetailViewModel(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [RelayCommand]
        public async void AddUpdateStudent()
        {
            int response = -1;
            if (StudentDetail.StudentID > 0)
            {
                response = await _studentService.UpdateStudent(StudentDetail);
            }
            else
            {
                response = _studentService.AddStudent(new StudentModel
                {
                    Email = StudentDetail.Email,
                    FirstName = StudentDetail.FirstName,
                    LastName = StudentDetail.LastName
                });
            }

            if(response != null)
            {
                await Shell.Current.DisplayAlert("Student info Saved", "Record Added to Student Table", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error!", "Something went wrong while recording", "OK");
            }
        }
    }
}
