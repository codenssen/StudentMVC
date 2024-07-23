using StudentMVC.Interface;
using StudentMVC.Models;
using StudentMVC.Models.ViewModels;


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
                Birthdate = new DateTime(2022,10,10),
                Email = "test@gmail.com"
            },
            new Student()
            {
                Id = 2,
                Name = "test2",
                LastName = "test2",
                Birthdate = new DateTime(2022,04,12),
                Email = "test2@gmail.com"
            },
            new Student()
            {
                Id = 3,
                Name = "test3",
                LastName = "test3",
                Birthdate = new DateTime(2012,01,10),
                Email = "test3@gmail.com"
            },
            new Student()
            {
                Id = 4,
                Name = "test4",
                LastName = "test4",
                Birthdate = new DateTime(1999,06,22),
                Email = "test4@gmail.com"
            },
            new Student()
            {
                Id = 5,
                Name = "test5",
                LastName = "test5",
                Birthdate = new DateTime(1982,02,12),
                Email = "test@gmail.com"
            }
        };

        public Task<List<Student>> GetStudentsAsync()
        {
            return Task.FromResult(_students);
        }

        public Task AddStudentAsync(AddStudent student)
        {
            var idNewStudent = _students.Max(x => x.Id) + 1;
            var newStudent = new Student()
            {
                Id = idNewStudent,
                Name = student.Name,
                LastName = student.LastName,
                Birthdate = student.Birthdate,
                Email = student.Email
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
                existingStudent.Birthdate = student.Birthdate;
                existingStudent.Email = student.Email;
            }
            return Task.CompletedTask;
        }

        public Task<bool> DeleteStudentAsync(int idStudent)
        {
            var removedStudent = _students.Find(s => s.Id == idStudent);
            if (removedStudent is null) return Task.FromResult(false);
            _students.Remove(removedStudent);
            return Task.FromResult(true);
        }
    }
}
