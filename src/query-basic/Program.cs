using System;
using System.Linq;
using System.Threading.Tasks;
using query_basic.Models;
using query_basic.Services;

namespace query_basic
{
    class Program
    {
        static async Task Main(string[] args)
        {
            LinQ();
            await ShowRegistrations_Bad(new QuickDac());
            await ShowRegistrations_Bad(new SlowDac());
            await ShowRegistrations_Good(new QuickDac());
            await ShowRegistrations_Good(new SlowDac());
        }

        static void LinQ()
        {
            var students = Enumerable.Range(1, 5)
                .Select(it => new Student
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = $"Student{it:00}"
                });

            Console.WriteLine("[ROUND-1]");
            foreach (var item in students)
            {
                System.Console.WriteLine($"{item.Id}, {item.Name}");
            }

            Console.WriteLine("[ROUND-2]");
            foreach (var item in students)
            {
                System.Console.WriteLine($"{item.Id}, {item.Name}");
            }
        }

        static async Task ShowRegistrations_Bad(IDac dac)
        {
            var regs = await dac.GetRegistrations(it => true);
            foreach (var reg in regs)
            {
                var student = await dac.GetStudent(it => it.Id == reg.StudentId);
                var subject = await dac.GetSubject(it => it.Id == reg.SubjectId);
                var teacher = await dac.GetTeacher(it => it.Id == subject.TeacherId);
                Console.WriteLine($"{subject.Name}, {student.Name}, {teacher.Name}");
            }
        }

        static async Task ShowRegistrations_Good(IDac dac)
        {
            // Registrations
            var regs = await dac.GetRegistrations(it => true);
            // Students
            var relatedStudentIdQry = regs.Select(it => it.StudentId).Distinct();
            var students = await dac.GetStudents(it => relatedStudentIdQry.Contains(it.Id));
            // Subjects
            var relatedSubjectIdQry = regs.Select(it => it.SubjectId).Distinct();
            var subjects = await dac.GetSubjects(it => relatedSubjectIdQry.Contains(it.Id));
            // Teachers
            var relatedTeacherIdQry = subjects.Select(it => it.TeacherId).Distinct();
            var teachers = await dac.GetTeachers(it => relatedTeacherIdQry.Contains(it.Id));
            foreach (var reg in regs)
            {
                var student = students.FirstOrDefault(it => it.Id == reg.StudentId);
                var subject = subjects.FirstOrDefault(it => it.Id == reg.SubjectId);
                var teacher = teachers.FirstOrDefault(it => it.Id == subject.TeacherId);
                Console.WriteLine($"{subject.Name}, {student.Name}, {teacher.Name}");
            }
        }
    }
}
