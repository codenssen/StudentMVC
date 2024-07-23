using Microsoft.EntityFrameworkCore;
using StudentMVC.Data;
using StudentMVC.Interface;
using StudentMVC.Models;
using StudentMVC.Models.ViewModels;


namespace StudentMVC.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDBContext _context;

        public CourseRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task AddCourseAsync(AddCourse course)
        {
            Course newCourse = new Course { Name = course.Name };
            await _context.Courses.AddAsync(newCourse);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteCourseAsync(int idCourse)
        {
            var removedCourse = await _context.Courses.FirstOrDefaultAsync(s => s.Id == idCourse);
            if (removedCourse == null)
            {
                return false;
            }
            _context.Courses.Remove(removedCourse);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task EditCourseAsync(Course course)
        {
            var existingCourse = await _context.Courses.FindAsync(course.Id);
            if (existingCourse != null)
            {
                existingCourse.Name = course.Name;
            }
            await _context.SaveChangesAsync();

        }


        public Task<Course?> GetCourseByIdAsync(int idCourse)
        {
            return _context.Courses.FirstOrDefaultAsync(c => c.Id == idCourse);
        }

        public async Task<List<Course>> GetCoursesAsync()
        {
            return await _context.Courses.ToListAsync();
        }
    }
}
