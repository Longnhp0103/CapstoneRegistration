using CapstoneRegistration.Repository.Models;
using CapstoneRegistration.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CapstoneManagement.Pages.Admin.GroupManagement
{
	public class CreateModel : PageModel
	{
		IGroupService groupService;
		IStudentService studentService;

		public CreateModel(IGroupService groupService, IStudentService studentService)
		{
			this.groupService = groupService;
			this.studentService = studentService;
		}

		public async Task<IActionResult> OnGetAsync()
		{
			int? semesterId = HttpContext.Session.GetInt32("SemesterId");
			if (semesterId.HasValue)
			{
				Students = studentService.GetStudentInSemester(semesterId.Value);
				if (Students == null)
				{
					RedirectToPage("/Admin/Error");
				}
				var existingStudentIds = studentService.GetStudentsExist();
				Students = Students.Where(student => !existingStudentIds.Contains(student.Id) && student.Status == true).ToList();
				ViewData["Leader"] = new SelectList(Students, "Id", "Code");
			}

			ViewData["SemesterId"] = new SelectList(await groupService.GetAllSemester(), "Id", "Name");
			ViewData["TopicId"] = new SelectList(await groupService.GetAllTopicExist(), "Id", "Name");
			return Page();
		}
		public IList<Student> Students { get; set; }
		[BindProperty]
		public Group Group { get; set; } = default!;


		// To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
		public async Task<IActionResult> OnPostAsync()
		{
			groupService.InsertGroup(Group);
			groupService.AddLeaderToGroup(Group.Leader, Group.Id);
			return RedirectToPage("./Index");
		}
	}
}
