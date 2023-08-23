using CapstoneRegistration.Repository.Models;
using CapstoneRegistration.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CapstoneManagement.Pages.Admin.LecturerManagement
{
	public class DeleteModel : PageModel
	{
		private ILecturerService lecturerService;
		public DeleteModel(ILecturerService lecturerService)
		{
			this.lecturerService = lecturerService;
		}

		[BindProperty]
		public Lecturer Lecturer { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var lecturer = lecturerService.GetLecturerId(id.Value);

			if (lecturer == null)
			{
				return NotFound();
			}
			Lecturer = lecturer;
			return Page();
		}

		public async Task<IActionResult> OnPostAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			if (LecturerExists(Lecturer.Id))
			{
				lecturerService.UpdateLecturerStatus(Lecturer.Id, false);
				return RedirectToPage("./Index");
			}
			else
			{
				ModelState.AddModelError("", "Not found");
				return Page();
			}
		}

		private bool LecturerExists(int id)
		{
			var lecturer = lecturerService.GetLecturerId(id);
			return lecturer != null;
		}
	}
}
