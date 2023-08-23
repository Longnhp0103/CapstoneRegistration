using CapstoneRegistration.Repository.Models;
using CapstoneRegistration.Service;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CapstoneManagement.Pages.Admin
{
    public class StudentManagementModel : PageModel
    {
        IStudentService studentService;
        public StudentManagementModel(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        public IList<Student> Student { get; set; }

        public int GroupId { get; set; }
        public async Task OnGetAsync(int? id)
        {
            if (id == null)
            {
                int? semesterId = HttpContext.Session.GetInt32("SemesterId");

                if (semesterId.HasValue)
                {
                    Student = studentService.GetStudentInSemester(semesterId.Value);

                    if (Student == null || Student.Count == 0)
                    {
                        NotFound();
                    }
                }
                else
                {
                    NotFound();
                }
            }
            else
            {
                GroupId = id.Value;
                Student = studentService.GetStudentInGroup(id.Value);
            }
        }

    }
}
