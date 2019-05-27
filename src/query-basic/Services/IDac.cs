using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using query_basic.Models;

namespace query_basic.Services
{
    public interface IDac
    {
        Task<Student> GetStudent(Func<Student, bool> fn = null);
        Task<IEnumerable<Student>> GetStudents(Func<Student, bool> fn = null);

        Task<Teacher> GetTeacher(Func<Teacher, bool> fn = null);
        Task<IEnumerable<Teacher>> GetTeachers(Func<Teacher, bool> fn = null);

        Task<Subject> GetSubject(Func<Subject, bool> fn = null);
        Task<IEnumerable<Subject>> GetSubjects(Func<Subject, bool> fn = null);
        
        Task<IEnumerable<Registration>> GetRegistrations(Func<Registration, bool> fn = null);
    }
}