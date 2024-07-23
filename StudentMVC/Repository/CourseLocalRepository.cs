using Microsoft.AspNetCore.Mvc;
using StudentMVC.Interface;
using StudentMVC.Models;
using StudentMVC.Models.ViewModels;

namespace StudentMVC.Repository
{
    public class CourseLocalRepository : ICourseRepository
    {
        private static readonly List<Course> _courses = new List<Course>()
        {
            new Course()
            {
                Id = 1,
                Name = "Français"
            },
            new Course()
            {
                Id = 2,
                Name = "Mathématique"
            },
            new Course()
            {
                Id= 3,
                Name = "Anglais"
            }
        };

        public Task<List<Course>> GetCoursesAsync()
        {
            return Task.FromResult(_courses);
        }

        
        public Task AddCourseAsync(AddCourse course)
        {
            var idNewCourse = _courses.Max(c => c.Id) + 1;
            var newCourse = new Course()
            {
                Id = idNewCourse,
                Name = course.Name,
            };
            _courses.Add(newCourse);
            return Task.CompletedTask;
        }
        public Task<Course?> GetCourseByIdAsync(int idCourse)
        {
            var course = _courses.Find(s => s.Id == idCourse);
            return Task.FromResult(course);
        }
        public Task EditCourseAsync(Course course)
        {
            var existingCourse = _courses.FirstOrDefault(s => s.Id == course.Id);
            if (existingCourse != null)
            {
                existingCourse.Name = course.Name;
            
            }
            return Task.CompletedTask;
        }

        public Task<bool> DeleteCourseAsync(int idCourse)
        {
            var removedCourse = _courses.Find(s => s.Id == idCourse);
            if (removedCourse is null) return Task.FromResult(false);
            _courses.Remove(removedCourse);
            return Task.FromResult(true);
        }


    }
}
