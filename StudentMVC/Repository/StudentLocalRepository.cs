using StudentMVC.Interface;
using StudentMVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace StudentMVC.Repository
{
    public class StudentLocalRepository : IStudentRepository
    {
        private static List<Student> _students = new List<Student>()
        {
            new Student()
            {
                Id = 1,
                Name = "test",
                LastName = "test",
            },
            new Student()
            {
                Id = 2,
                Name = "test2",
                LastName = "test2",
            },
            new Student()
            {
                Id = 3,
                Name = "test3",
                LastName = "test3",
            },
            new Student()
            {
                Id = 4,
                Name = "test4",
                LastName = "test4",
            },
            new Student()
            {
                Id = 5,
                Name = "test5",
                LastName = "test5",
            }
        };

        public Task<List<Student>> GetStudentsAsync()
        {
            return Task.FromResult(_students);
        }

        public Task AddStudentAsync(string name, string lastname)
        {
            var idNewStudent = _students.Max(x => x.Id) + 1;
            var newStudent = new Student()
            {
                Id = idNewStudent,
                Name = name,
                LastName = lastname,
            };
            _students.Add(newStudent);
            return Task.CompletedTask;
        }

        public Task<Student?> GetStudentByIdAsync(int idStudent)
        {
            var student = _students.Find(s => s.Id == idStudent);
            return Task.FromResult(student);
        }

        public Task EditStudentAsync(Student student)
        {
            var existingStudent = _students.FirstOrDefault(s => s.Id == student.Id);
            if (existingStudent != null)
            {
                existingStudent.Name = student.Name;
                existingStudent.LastName = student.LastName;
            }
            return Task.CompletedTask;
        }

        public Task DeleteStudentAsync(int idStudent)
        {
            var removed = _students.RemoveAll(s => s.Id == idStudent);
            return Task.CompletedTask;
        }
    }
}
