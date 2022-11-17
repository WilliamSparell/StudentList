using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentList.Views;

namespace StudentList.ViewModels
{
    public partial class StudentListPageViewModel : ObservableObject
    {
        [RelayCommand]
        public async void AddUpdateStudent()
        {
            await AppShell.Current.GoToAsync(nameof(AddUpdateStudentDetail));
        }
    }
}
