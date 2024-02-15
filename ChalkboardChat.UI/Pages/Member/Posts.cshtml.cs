using ChalkboardChat.Data.Database;
using ChalkboardChat.Data.Models;
using ChalkboardChat.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChalkboardChat.UI.Pages.Member
{
    public class PostsModel : PageModel
    {
        private readonly AppDbContext _Context;
        public PostsModel(AppDbContext context)
        {
            _Context = context;


        }
        public List<MessageModel> Messages { get; set; }

        [BindProperty]
        public string? Message { get; set; }

        [BindProperty]
        public string? Username { get; set; }


        public async Task OnGet()

        {
            MessageRepository message = new(_Context);

            Messages = await message.GetAllMessages();



        }

        public IActionResult OnPost()
        {

            MessageModel model = new MessageModel
            {
                Username = Username,
                Message = Message,
                Date = DateTime.Now

            };

            MessageRepository message = new(_Context);

            message.AddMessage(model);
            message.SaveChange();

            return RedirectToPage("/members/posts");
        }



    }
}

