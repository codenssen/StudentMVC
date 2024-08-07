﻿using Microsoft.EntityFrameworkCore;
using StudentMVC.Data;
using StudentMVC.Interface;
using StudentMVC.Models;
using StudentMVC.Models.ViewModels;
using System.Reflection.Metadata.Ecma335;

namespace StudentMVC.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDBContext _context;

        public StudentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task AddStudentAsync(AddStudent student)
        {
            Student newStudent = new Student { Name = student.Name, LastName = student.LastName, Birthdate = student.Birthdate, Email = student.Email };
            await _context.Students.AddAsync(newStudent);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteStudentAsync(int idStudent)
        {
            var removedStudent = await _context.Students.FirstOrDefaultAsync(s => s.Id == idStudent);
            if (removedStudent == null)
            {
                return false;
            }
            _context.Students.Remove(removedStudent);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task EditStudentAsync(Student student)
        {
            var existingStudent = await _context.Students.FindAsync(student.Id);
            if (existingStudent != null)
            {
                existingStudent.Name = student.Name;
                existingStudent.LastName = student.LastName;
                existingStudent.Birthdate = student.Birthdate;
                existingStudent.Email = student.Email;
            }
            await _context.SaveChangesAsync();

        }


        public Task<Student?> GetStudentByIdAsync(int idStudent)
        {
            return _context.Students.FirstOrDefaultAsync(student => student.Id == idStudent);
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            return await _context.Students.ToListAsync();
        }
    }
}
