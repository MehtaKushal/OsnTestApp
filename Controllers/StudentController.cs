using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OsnTestApp.Data;
using OsnTestApp.Models;
using System.ComponentModel.DataAnnotations;

namespace OsnTestApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly OsnTestAppDbContext dbContext;

        public StudentController(OsnTestAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var students = await dbContext.Student
                           .Include(s => s.Parent)
                           .Include(s => s.Marks)
                           .ToListAsync();
            return View(students);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Student addStudentRequest)
        {
            for (int i = 0; i < addStudentRequest.Marks.Count; i++)
            {
                bool isAbsent = false;
                if (Request.Form[$"Marks[{i}].IsAbsent"].FirstOrDefault() == "on")
                    isAbsent = true;
                addStudentRequest.Marks[i].IsAbsent = isAbsent;
            }
            await dbContext.Student.AddAsync(addStudentRequest);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var student = await dbContext.Student
                           .Include(s => s.Parent)
                           .Include(s => s.Marks)
                           .FirstOrDefaultAsync(x => x.Id == id);
            if(student == null)
            {
                //validation
                return RedirectToAction("Index");
            }
            return await Task.Run(()=>View("View",student));
        }

        [HttpPost]
        public async Task<IActionResult> View(Student editStudent)
        {
            var student = await dbContext.Student
                           .Include(s => s.Parent)
                           .Include(s => s.Marks)
                           .FirstOrDefaultAsync(x => x.Id == editStudent.Id);
            if (student!= null)
            {
                student.Name = editStudent.Name;
                student.DateOfBirth = editStudent.DateOfBirth;
                student.Address = editStudent.Address;
                student.Phone = editStudent.Phone;
                student.Email = editStudent.Email;
                student.Parent = editStudent.Parent;
                student.Marks = editStudent.Marks;
                dbContext.Student.Update(student);
                await dbContext.SaveChangesAsync();

            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Student delStudent)
        {
            var student = await dbContext.Student
                           .Include(s => s.Parent)
                           .Include(s => s.Marks)
                           .FirstOrDefaultAsync(x => x.Id == delStudent.Id);
            if (student != null)
            {
                dbContext.Student.Remove(student);
                await dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}
