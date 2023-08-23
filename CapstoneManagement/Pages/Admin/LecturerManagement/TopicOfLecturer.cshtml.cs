using CapstoneRegistration.Repository.Models;
using CapstoneRegistration.Service;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CapstoneManagement.Pages.Admin.LecturerManagement
{
	public class TopicOfLecturerModel : PageModel
	{
		ITopicService topicService;
		public TopicOfLecturerModel(ITopicService topicService)
		{
			this.topicService = topicService;
		}

		public IList<Topic> Topics { get; set; }

		public async Task OnGetAsync(int? id)
		{
			Topics = topicService.GetTopicByLecturer(id.Value);
			if (Topics == null)
			{
				NotFound();
			}
		}


	}
}
