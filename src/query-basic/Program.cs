using System;
using System.Collections.Generic;
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

            // await ShowRegistrations_Bad(new QuickDac());
            // await ShowRegistrations_Bad(new SlowDac());

            // await ShowRegistrations_Good(new QuickDac());
            // await ShowRegistrations_Good(new SlowDac());

            // await ShowRegistrationsWithCondition_Bad(new QuickDac());
            // await ShowRegistrationsWithCondition_Good(new QuickDac());

            // await FilterRegistrations_Bad(new QuickDac());
            // await FilterRegistrations_Bad(new SlowDac());

            // await FilterRegistrations_Good(new QuickDac());
            // await FilterRegistrations_Good(new SlowDac());

            // Make it Work
            // Make it Right
            // Make it Fast
        }

        static void LinQ()
        {
            var students = Enumerable.Range(1, 5)
                .Select(it => new Student
                {
                    Id = $"{Guid.NewGuid()}",
                    Name = $"Student{it:00}",
                });

            Console.WriteLine("[ROUND-1]");
            foreach (var item in students)
            {
                Console.WriteLine($"{item.Id}, {item.Name}");
            }

            Console.WriteLine("[ROUND-2]");
            foreach (var item in students)
            {
                Console.WriteLine($"{item.Id}, {item.Name}");
            }

            Console.WriteLine($"Are they equal? {students == students}");
        }

        static async Task ShowRegistrations_Bad(IDac dac)
        {
            var regs = await dac.GetRegistrations(it => true);
            foreach (var reg in regs)
            {
                var student = await dac.GetStudent(it => it.Id == reg.StudentId);
                var subject = await dac.GetSubject(it => it.Id == reg.SubjectId);
                var teacher = await dac.GetTeacher(it => it.Id == subject.TeacherId);
                Console.WriteLine($"{reg.Id:00}|{subject.Name}, {student.Name}, {teacher.Name}, {reg.Semester}, {reg.Grade}");
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
                Console.WriteLine($"{reg.Id:00}|{subject.Name}, {student.Name}, {teacher.Name}, {reg.Semester}, {reg.Grade}");
            }
        }

        static async Task ShowRegistrationsWithCondition_Bad(IDac dac)
        {
            var regs = await dac.GetRegistrations(it => true);
            var evenRegs = new List<Registration>();
            foreach (var item in regs)
            {
                if (item.Id % 2 == 0)
                {
                    evenRegs.Add(item);
                }
            }
            Console.WriteLine($"Any event Id in the registrations? {evenRegs.Count() > 0}");
        }

        static async Task ShowRegistrationsWithCondition_Good(IDac dac)
        {
            var regs = await dac.GetRegistrations(it => true);
            var evenRegs = regs.Where(it => it.Id % 2 == 0);
            Console.WriteLine($"Any event Id in the registrations? {evenRegs.Any()}");
        }

        static async Task FilterRegistrations_Bad(IDac dac)
        {
            var firstSemesters = await dac.GetRegistrations(it => it.Semester == "1st" && it.Grade == 0);
            var secondSemester = await dac.GetRegistrations(it => it.Semester == "2nd" && it.Grade == 0);

            Console.WriteLine("Fail students in the 1st semester");
            foreach (var item in firstSemesters)
            {
                var student = await dac.GetStudent(it => it.Id == item.StudentId);
                Console.WriteLine(student.Name);
            }

            Console.WriteLine("Fail students in the 2nd semester");
            foreach (var item in secondSemester)
            {
                var student = await dac.GetStudent(it => it.Id == item.StudentId);
                Console.WriteLine(student.Name);
            }
        }

        static async Task FilterRegistrations_Good(IDac dac)
        {
            var fails = await dac.GetRegistrations(it => it.Grade == 0);
            var firstSemesters = fails.Where(it => it.Semester == "1st");
            var secondSemester = fails.Where(it => it.Semester == "2nd");

            var studentIdQry = fails.Select(it => it.StudentId).Distinct();
            var students = await dac.GetStudents(it => studentIdQry.Contains(it.Id));

            Console.WriteLine("Fail students in the 1st semester");
            foreach (var item in firstSemesters)
            {
                var student = students.FirstOrDefault(it => it.Id == item.StudentId);
                Console.WriteLine(student.Name);
            }

            Console.WriteLine("Fail students in the 2nd semester");
            foreach (var item in secondSemester)
            {
                var student = students.FirstOrDefault(it => it.Id == item.StudentId);
                Console.WriteLine(student.Name);
            }
        }
    }
}
