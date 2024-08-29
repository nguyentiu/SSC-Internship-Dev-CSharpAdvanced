using AdvancedExercises.Model;
using AdvancedExercises.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedExercises.Services
{
    public class StudentService
    {
        private readonly GenericRepository<Student> _repository;

        public StudentService(GenericRepository<Student> repository)
        {
            _repository = repository;
        }

        public void AddStudent(Student student)
        {
            _repository.Add(student);
        }

        public List<Student> GetStudents() => _repository.GetAll();

        public async Task<List<Student>> GetStudentsAsync() => await _repository.GetAllAsync();
    }
}
