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
		public int GroupId { get; set; }
		public async Task OnGetAsync(int? id)
		{
			if (id == null)
			{
				Lecturer = lecturerService.GetAllLecturer();
			}
			else
			{
				GroupId = id.Value;
				Lecturer = lecturerService.GetLecturerByGroup(id.Value);
				Lecturer inMainLecturer = lecturerService.GetInMainLecturerByGroup(id.Value);
				if (inMainLecturer != null)
				{
					Lecturer.Add(inMainLecturer);
				}
			}
		}
	}
}
