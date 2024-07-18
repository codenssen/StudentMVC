using StudentMVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentMVC.Interface
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudentsAsync();
        Task AddStudentAsync(string name, string lastname);
        Task<Student?> GetStudentByIdAsync(int idStudent);
        Task EditStudentAsync(Student student);
        Task DeleteStudentAsync(int idStudent);
    }
}
