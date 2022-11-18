﻿
using System.Collections.ObjectModel;

namespace StudentList.ViewModels
{
    public partial class StudentListPageViewModel : ObservableObject
    {
        public ObservableCollection<StudentModel> Students { get; set; } = new ObservableCollection<StudentModel>();
        private readonly IStudentService _studentService;
        public StudentListPageViewModel(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [RelayCommand]
        private async void GetStudentList()
        {
            var studentList = await _studentService.GetStudentList();
            if (studentList?.Count > 0)
            {
                Students.Clear();
                foreach (var student in studentList)
                {
                    Students.Add(student);
                }
            }
        }

        [RelayCommand]
        public async void AddUpdateStudent()
        {
            await AppShell.Current.GoToAsync(nameof(AddUpdateStudentDetail));
        }

        [RelayCommand]
        public async void DisplayAction(StudentModel studentModel)
        {
            var response = await AppShell.Current.DisplayActionSheet("Select Options", "OK", null, "Edit", "Delete");

            if (response is "Edit")
            {
                var navParam = new Dictionary<string, object>();
                navParam.Add("StudentDetail", studentModel);

                await AppShell.Current.GoToAsync(nameof(AddUpdateStudentDetail));
            }
            else if (response is "Delete")
            {
                var delResponse = await _studentService.DeleteStudent(studentModel);
                if (delResponse > 0)
                {
                    GetStudentList();
                }
            }
        }
    }
}
