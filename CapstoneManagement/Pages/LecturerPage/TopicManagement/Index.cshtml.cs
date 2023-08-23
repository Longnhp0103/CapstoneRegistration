using CapstoneRegistration.Repository.Models;
using CapstoneRegistration.Service;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CapstoneManagement.Pages.LecturerPage.TopicManagement
{
	public class IndexModel : PageModel
	{
		ITopicService topicService;

		public IndexModel(ITopicService topicService)
		{
			this.topicService = topicService;
		}

		public IList<Topic> Topic { get; set; } = default!;

		public async Task OnGetAsync(int? id)
		{
			int? semesterId = HttpContext.Session.GetInt32("SemesterId");

			if (semesterId.HasValue)
			{
				Topic = topicService.GetTopicInSemester(semesterId.Value);

				if (Topic == null || Topic.Count == 0)
				{
					NotFound();
				}
			}
			else
			{
				NotFound();
			}
		}
	}
}
