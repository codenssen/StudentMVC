using StudentMVC.Models;
using StudentMVC.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentMVC.Interface
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudentsAsync();
        Task AddStudentAsync(AddStudent student);
        Task<Student?> GetStudentByIdAsync(int idStudent);
        Task EditStudentAsync(Student student);
        Task<bool> DeleteStudentAsync(int idStudent);
    }
}
