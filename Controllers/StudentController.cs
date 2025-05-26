using Microsoft.AspNetCore.Mvc;
using StudentCrudApp.Models;
using StudentCrudApp.Data;
using System.Linq;

namespace StudentCrudApp.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View(StudentRepository.Students);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                student.Id = StudentRepository.Students.Count > 0 ? StudentRepository.Students.Max(s => s.Id) + 1 : 1;
                StudentRepository.Students.Add(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public IActionResult Edit(int id)
        {
            var student = StudentRepository.Students.FirstOrDefault(s => s.Id == id);
            return student == null ? NotFound() : View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student updatedStudent)
        {
            var student = StudentRepository.Students.FirstOrDefault(s => s.Id == updatedStudent.Id);
            if (student != null)
            {
                student.Name = updatedStudent.Name;
                student.School = updatedStudent.School;
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        public IActionResult Delete(int id)
        {
            var student = StudentRepository.Students.FirstOrDefault(s => s.Id == id);
            return student == null ? NotFound() : View(student);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = StudentRepository.Students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                StudentRepository.Students.Remove(student);
            }
            return RedirectToAction("Index");
        }
    }
}
