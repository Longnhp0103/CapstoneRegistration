using CapstoneRegistration.Repository.Models;
using CapstoneRegistration.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CapstoneManagement.Pages.Admin.LecturerManagement
{
	public class CreateModel : PageModel
	{
		ILecturerService lecturerService;

		public CreateModel(ILecturerService lecturerService)
		{
			this.lecturerService = lecturerService;
		}

		public IActionResult OnGet()
		{
			return Page();
		}

		[BindProperty]
		public Lecturer Lecturer { get; set; } = default!;


		// To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid || Lecturer == null)
			{
				return Page();
			}
			if (checkCode(Lecturer.Code))
			{
				ModelState.AddModelError("", "Code is already exist");
				return Page();
			}
			else
			{
				lecturerService.InsertLecturer(Lecturer);

				return RedirectToPage("./Index");
			}
		}

		public bool checkCode(string code)
		{
			return lecturerService.CheckCode(code);
		}
	}
}
