using ChalkboardChat.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChalkboardChat.UI.Pages.Member
{
    public class PostsModel : PageModel
    {

        public List<MessageModel> Messages { get; set; }

        [BindProperty]
        public string NewMessage { get; set; }

        public void OnGet()
        {
            // Fetch existing messages from database or any other data source

            Messages = new List<MessageModel>
            {
                new MessageModel { Username = "John Doe", Message = "Hello, world!",  Date = DateTime.Now.AddDays(-1) },
                new MessageModel { Username = "Jane Smith", Message = "This is a sample message.", Date = DateTime.Now }
            };
        }

        public IActionResult OnPost()
        {
            // Process the new message submission (save to database, etc.)

            Messages.Insert(0, new MessageModel { Username = "Current User", Message = NewMessage, Date = DateTime.Now });
            return RedirectToPage("/MessageBoard");
        }



    }
}

