using CapstoneRegistration.Repository.Models;
using CapstoneRegistration.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CapstoneManagement.Pages.LecturerPage.TopicManagement
{
    public class DeleteModel : PageModel
    {
        ITopicService topicService;

        public DeleteModel(ITopicService topicService)
        {
            this.topicService = topicService;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            topicService.DeleteTopic(id.Value);
            return RedirectToPage("./Index");
        }
    }
}
