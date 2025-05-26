using StudentCrudApp.Models;
using System.Collections.Generic;

namespace StudentCrudApp.Data
{
    public static class StudentRepository
    {
        public static List<Student> Students { get; set; } = new List<Student>();
    }
}
