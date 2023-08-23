using CapstoneRegistration.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CapstoneManagement.Pages.Admin.LecturerManagement
{
	public class DetailsModel : PageModel
	{
		private readonly CapstoneRegistration.Repository.Models.CapstoneRigistrationContext _context;

		public DetailsModel(CapstoneRegistration.Repository.Models.CapstoneRigistrationContext context)
		{
			_context = context;
		}

		public Lecturer Lecturer { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.Lecturers == null)
			{
				return NotFound();
			}

			var lecturer = await _context.Lecturers.FirstOrDefaultAsync(m => m.Id == id);
			if (lecturer == null)
			{
				return NotFound();
			}
			else
			{
				Lecturer = lecturer;
			}
			return Page();
		}
	}
}
