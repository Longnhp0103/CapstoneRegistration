using CapstoneRegistration.Repository.Models;
using CapstoneRegistration.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CapstoneManagement.Pages.Admin.LecturerManagement
{
	public class EditModel : PageModel
	{
		private ILecturerService lecturerService;

		public EditModel(ILecturerService lecturerService)
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

		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see https://aka.ms/RazorPagesCRUD.
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}
			if (LecturerExists(Lecturer.Id))
			{
				lecturerService.UpdateLecturer(Lecturer);
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
