using SQLite;
using StudentList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentList.Services
{
    public class StudentService : IStudentService
    {
        private SQLiteAsyncConnection _dbConnection;

        private async Task SetUpDB()
        {
            if (_dbConnection is null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Student.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<StudentModel>();
            }
        }

        public async Task<int> AddStudent(StudentModel studentModel)
        {
            await SetUpDB();
            return await _dbConnection.InsertAsync(studentModel);
        }

        public async Task<int> DeleteStudent(StudentModel studentModel)
        {
            await SetUpDB();
            return await _dbConnection.DeleteAsync(studentModel);
        }

        public async Task<List<StudentModel>> GetStudentList()
        {
            await SetUpDB();
            var studentList = await _dbConnection.Table<StudentModel>().ToListAsync();
            return studentList;
        }

        public async Task<int> UpdateStudent(StudentModel studentModel)
        {
            await SetUpDB();
            return await _dbConnection.UpdateAsync(studentModel);
        }
    }
}
