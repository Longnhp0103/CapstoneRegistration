using CapstoneRegistration.Repository.Models;
using CapstoneRegistration.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CapstoneManagement.Pages.Admin.GroupManagement
{
    public class AddStudentToGroupModel : PageModel
    {
        IStudentService studentService;
        IGroupService groupService;

        public AddStudentToGroupModel(IStudentService studentService, IGroupService groupService)
        {
            this.studentService = studentService;
            this.groupService = groupService;
        }

        public IList<Student> Students { get; set; }
        public Group Group { get; set; }
        public async Task OnGetAsync(int? id)
        {
            if (id != null)
            {
                int? semesterId = HttpContext.Session.GetInt32("SemesterId");

                if (semesterId.HasValue)
                {
                    Students = studentService.GetStudentInSemester(semesterId.Value);
                    Group = groupService.GetGroupById(id.Value);
                    if (Students == null || Students.Count == 0 || Group == null)
                    {
                        RedirectToPage("/Admin/Error");
                    }

                    var existingStudentIds = studentService.GetStudentsExist();
                    Students = Students.Where(student => !existingStudentIds.Contains(student.Id)).ToList();
                    RedirectToPage("./Index");
                }
                else
                {
                    RedirectToPage("/Admin/Error");
                }
            }
        }

        public IActionResult OnPost(int id, List<int> selectedStudents)
        {
            if (selectedStudents != null && selectedStudents.Count > 0)
            {
                var groupId = id;

                groupService.AddStudentToGroup(selectedStudents, groupId);

                return RedirectToPage("/Admin/GroupManagement/Index");
            }
            return RedirectToPage("/Admin/Error");

        }
    }
}