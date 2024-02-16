using ChalkboardChat.Data.Database;
using ChalkboardChat.Data.Models;
using ChalkboardChat.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChalkboardChat.UI.Pages.Member
{
    public class PostsModel : PageModel
    {
        private readonly AppDbContext _Context;

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public PostsModel(AppDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _Context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public List<MessageModel> Messages { get; set; }

        [BindProperty]
        public string? Message { get; set; }

        [BindProperty]
        public string? Username { get; set; }


        public async Task OnGet()

        {
            var currentUser = await _userManager.GetUserAsync(User);

            Username = currentUser?.UserName;

            MessageRepository message = new(_Context);

            Messages = await message.GetAllMessages();
        }

        public async Task<IActionResult> OnPostAsync(string action)
        {
            if (action == "submit")
            {
                MessageModel model = new MessageModel
                {
                    Date = DateTime.Now,
                    Message = Message,
                    Username = Username,
                };

                MessageRepository message = new(_Context);

                await message.AddMessage(model);
                await message.SaveChange();

                return RedirectToPage("/member/posts");
            }
            else if (action == "logout")
            {
                await _signInManager.SignOutAsync();
                return RedirectToPage("/Index");
            }
            return Page();
        }
    }
}
//public class PostsModel : PageModel
//{
//    private readonly AppDbContext _context;
//    private readonly MessageRepository _messageRepository;

//    public PostsModel(AppDbContext context, MessageRepository messageRepository)
//    {
//        _context = context;
//        _messageRepository = messageRepository;
//    }

//    public List<MessageModel> Messages { get; set; }

//    [BindProperty]
//    public string Message { get; set; }

//    [BindProperty]
//    public string Username { get; set; }

//    public async Task OnGetAsync()
//    {
//        Messages = await _messageRepository.GetAllMessages();
//    }

//    public async Task<IActionResult> OnPostAsync()
//    {


//        var model = new MessageModel
//        {
//            Username = Username,
//            Message = Message,
//            Date = DateTime.Now
//        };

//        await _messageRepository.AddMessage(model);
//        await _context.SaveChangesAsync();

//        return RedirectToPage("/members/posts");
//    }
//}

