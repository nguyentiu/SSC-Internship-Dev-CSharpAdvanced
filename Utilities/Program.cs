using Microsoft.Extensions.DependencyInjection;
using AdvancedExercises.Model;
using AdvancedExercises.Repositories;
using AdvancedExercises.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedExercises.Utilities
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Setup Dependency Injection
            var services = new ServiceCollection();
            services.AddSingleton<GenericRepository<Student>>();
            services.AddSingleton<StudentService>();
            var serviceProvider = services.BuildServiceProvider();

            // Resolve services
            var studentService = serviceProvider.GetService<StudentService>();

            // Add students
            studentService.AddStudent(new Student { Id = 1, Name = "John Doe", Age = 20, Grade = "A" });
            studentService.AddStudent(new Student { Id = 2, Name = "Jane Smith", Age = 22, Grade = "B" });

            // Display all students
            var students = studentService.GetStudents();
            Console.WriteLine("All Students:");
            students.ForEach(s => Console.WriteLine($"{s.Name}, {s.Age}, {s.Grade}"));

            // Asynchronous retrieval
            var asyncStudents = await studentService.GetStudentsAsync();
            Console.WriteLine("Async Students:");
            asyncStudents.ForEach(s => Console.WriteLine($"{s.Name}, {s.Age}, {s.Grade}"));

            Console.ReadKey();
        }
    }
}
