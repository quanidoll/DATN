using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus.DataSets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VicemMVCIdentity.Data;
using VicemMVCIdentity.Models.Graduation;
using VicemMVCIdentity.Models.Process;

namespace VicemMVCIdentity.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private ExcelProcess _excelProcess = new ExcelProcess();
        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Upload()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null)
            {
                string fileExtension = Path.GetExtension(file.FileName);
                if (fileExtension != ".xls" && fileExtension    != ".xls")
                {
                    ModelState.AddModelError("", "Please choose excel file to upload");
                }
                else
                {
                    //rename file when upload to sever
                    var fileName = DateTime.Now.ToShortDateString() + fileExtension;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory() + "Uploas/Excels", fileName);
                    var fileLocation = new FileInfo(filePath).ToString();
                    using (var  stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                        //read data from excel file fill DataTable
                        var dt = _excelProcess.ReadExcelToDataTable(stream);
                        for(int i = 0; i < dt.Rows.Count; i++)
                        {
                            //create new Student object 
                            var ps = new Student();
                            //set value to attributes
                            if (int.TryParse(dt.Rows[i][0].ToString(), out int studentIdValue))
                            {
                                ps.StudentID = studentIdValue;
                            }
                            else
                            {
                                // Xử lý nếu giá trị không thể chuyển đổi (gán giá trị mặc định hoặc báo lỗi)
                                ps.StudentID = 0; // Giá trị mặc định, có thể thay đổi theo nhu cầu
                            }
                            ps.FullName = dt.Rows[i][1].ToString();
                            if (DateTime.TryParse(dt.Rows[i][2].ToString(), out DateTime dobValue))
                            {
                                ps.DateOfBirth = dobValue;
                            }
                            else
                            {
                                ps.DateOfBirth = DateTime.MinValue; // Giá trị mặc định hoặc xử lý lỗi
                            }
                            ps.PhoneNumber = dt.Rows[i][1].ToString();
                            ps.Email = dt.Rows[i][1].ToString();
                            ps.Major = dt.Rows[i][1].ToString();
                            ps.Faculty = dt.Rows[i][1].ToString();
                            ps.Course = dt.Rows[i][1].ToString();
                            //add object to context
                            _context.Add(ps);
                        }
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }
                
            }
            return View();
        }

        // GET: Student
        public async Task<IActionResult> Index()
        {
            return View(await _context.Student.ToListAsync());
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .FirstOrDefaultAsync(m => m.StudentID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentID,FullName,DateOfBirth,PhoneNumber,Email,Major,Faculty,Course")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentID,FullName,DateOfBirth,PhoneNumber,Email,Major,Faculty,Course")] Student student)
        {
            if (id != student.StudentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.StudentID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .FirstOrDefaultAsync(m => m.StudentID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Student.FindAsync(id);
            if (student != null)
            {
                _context.Student.Remove(student);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.StudentID == id);
        }
    }
}
