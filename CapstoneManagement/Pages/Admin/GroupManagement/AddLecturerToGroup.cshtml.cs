using CapstoneRegistration.Repository.Models;
using CapstoneRegistration.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CapstoneManagement.Pages.Admin.GroupManagement
{
    public class AddLecturerToGroupModel : PageModel
    {
        ILecturerService lecturerService;
        IGroupService groupService;

        public AddLecturerToGroupModel(ILecturerService lecturerService, IGroupService groupService)
        {
            this.lecturerService = lecturerService;
            this.groupService = groupService;
        }

        public IList<Lecturer> Lecturers { get; set; }
        public Group Group { get; set; }
        public async Task OnGetAsync(int? id)
        {
            if (id != null)
            {
                Lecturers = lecturerService.GetAllLecturer();
                Group = groupService.GetGroupById(id.Value);
                if (Group == null || Lecturers == null)
                {
                    RedirectToPage("/Admin/Error");
                }
            }
        }

        public IActionResult OnPost(int lecturerSelected, int mainLecturerSelected, int groupId)
        {
            var group = groupService.GetGroupById(groupId);

            if (group == null)
            {
                return NotFound();
            }

            var lecturerInGroup = new LecturerInGroup
            {
                GroupId = groupId,
                LecturerId = lecturerSelected,
                InMainLecturer = mainLecturerSelected
            };

            lecturerService.AddLecturerToGroup(lecturerInGroup);

            return RedirectToPage("/Admin/GroupManagement/Index");
        }
    }
}
