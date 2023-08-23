using CapstoneRegistration.Repository.Models;
using CapstoneRegistration.Service;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CapstoneManagement.Pages.Admin.LecturerManagement
{
	public class IndexModel : PageModel
	{
		private ILecturerService lecturerService { get; set; }

		public IndexModel(ILecturerService lecturerService)
		{
			this.lecturerService = lecturerService;
		}

		public IList<Lecturer> Lecturer { get; set; } = default!;

		public async Task OnGetAsync(int? id)
		{
			if (id == null)
			{
				Lecturer = lecturerService.GetAllLecturer();
			}
			else
			{
				Lecturer = lecturerService.GetLecturerByGroup(id.Value);
			}
		}
	}
}
