using CapstoneRegistration.Repository.Models;
using CapstoneRegistration.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CapstoneManagement.Pages.LecturerPage.TopicManagement
{
    public class DetailsModel : PageModel
    {
        ITopicService topicService;

        public DetailsModel(ITopicService topicService)
        {
            this.topicService = topicService;
        }

        public Topic Topic { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Topic = topicService.GetTopicById(id.Value);
            return Page();
        }
    }
}
