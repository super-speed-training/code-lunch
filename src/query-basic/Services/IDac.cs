using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using query_basic.Models;

namespace query_basic.Services
{
    public interface IDac
    {
        Task<Student> GetStudent(Func<Student, bool> fn);
        Task<IEnumerable<Student>> GetStudents(Func<Student, bool> fn);

        Task<Teacher> GetTeacher(Func<Teacher, bool> fn);
        Task<IEnumerable<Teacher>> GetTeachers(Func<Teacher, bool> fn);

        Task<Subject> GetSubject(Func<Subject, bool> fn);
        Task<IEnumerable<Subject>> GetSubjects(Func<Subject, bool> fn);
        
        Task<IEnumerable<Registration>> GetRegistrations(Func<Registration, bool> fn);
    }
}