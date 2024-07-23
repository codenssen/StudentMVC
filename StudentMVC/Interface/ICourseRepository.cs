using StudentMVC.Models;
using StudentMVC.Models.ViewModels;

namespace StudentMVC.Interface
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetCoursesAsync();
        Task AddCourseAsync(AddCourse course);
        Task<Course?> GetCourseByIdAsync(int idCourse);
        Task EditCourseAsync(Course course);
        Task<bool> DeleteCourseAsync(int idCourse);
    }
}
