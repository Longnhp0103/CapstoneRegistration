using CapstoneRegistration.Repository.Models;
using CapstoneRegistration.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CapstoneManagement.Pages.LecturerPage.TopicManagement
{
	public class LecturerModel : PageModel
	{
		private ILecturerService lecturerService;
		private ITopicService topicService;
		public LecturerModel(ILecturerService lecturerService, ITopicService topicService)
		{
			this.lecturerService = lecturerService;
			this.topicService = topicService;
		}

		public IList<Lecturer> Lecturer { get; set; } = default!;

		[BindProperty]
		public int LecturerId { get; set; }

		public List<SelectListItem> LecturerOptions { get; set; }

		public List<Lecturer> Lecturers { get; set; }

		public async Task OnGetAsync(int? id)
		{

			if (id != null)
			{
				HttpContext.Session.SetInt32("TopicId", id.Value);
				Lecturer = lecturerService.GetLecturersByTopic(id.Value);
				Lecturers = lecturerService.GetAllLecturer();
			}
			else
			{
				NotFound();
			}
		}
		public IActionResult OnPost()
		{
			if (ModelState.IsValid)
			{
				int? topicId = HttpContext.Session.GetInt32("TopicId");
				topicService.AddLecturerToTopic(LecturerId, topicId.Value);
			}

			return RedirectToPage("./Index");
		}
	}
}
