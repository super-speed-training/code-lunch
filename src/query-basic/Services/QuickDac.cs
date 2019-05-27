using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using query_basic.Models;

namespace query_basic.Services
{
    public class QuickDac : IDac
    {
        protected IEnumerable<Teacher> Teachers;
        protected IEnumerable<Student> Students;
        protected IEnumerable<Subject> Subjects;
        protected IEnumerable<Registration> Registrations;

        public QuickDac(int totalStudent = 99, int totalTeacher = 3, int totalSubject = 5)
        {
            var random = new Random();
            Teachers = Enumerable.Range(1, totalTeacher).Select(it => new Teacher($"tc{it}", $"Teacher{it}")).ToList();
            Students = Enumerable.Range(1, totalStudent).Select(it => new Student($"sd{it}", $"Student{it}")).ToList();
            Subjects = Enumerable.Range(1, totalSubject).Select(it => new Subject($"sj{it}", $"Subject{it}", $"tc{random.Next(totalTeacher) + 1}")).ToList();
            Registrations = Students.Select(it => new Registration(Guid.NewGuid().ToString(), it.Id, $"sj{random.Next(totalSubject) + 1}")).ToList();
        }

        public async Task<Student> GetStudent(Func<Student, bool> fn)
        {
            await PreProcessing();
            return Students.FirstOrDefault(it => fn(it));
        }
        public async Task<IEnumerable<Student>> GetStudents(Func<Student, bool> fn)
        {
            await PreProcessing();
            return Students.Where(it => fn(it));
        }

        public async Task<Teacher> GetTeacher(Func<Teacher, bool> fn)
        {
            await PreProcessing();
            return Teachers.FirstOrDefault(it => fn(it));
        }
        public async Task<IEnumerable<Teacher>> GetTeachers(Func<Teacher, bool> fn)
        {
            await PreProcessing();
            return Teachers.Where(it => fn(it));
        }

        public async Task<Subject> GetSubject(Func<Subject, bool> fn)
        {
            await PreProcessing();
            return Subjects.FirstOrDefault(it => fn(it));
        }
        public async Task<IEnumerable<Subject>> GetSubjects(Func<Subject, bool> fn)
        {
            await PreProcessing();
            return Subjects.Where(it => fn(it));
        }

        public async Task<IEnumerable<Registration>> GetRegistrations(Func<Registration, bool> fn)
        {
            await PreProcessing();
            return Registrations.Where(it => fn(it));
        }

        protected virtual Task PreProcessing()
            => Task.CompletedTask;
    }
}