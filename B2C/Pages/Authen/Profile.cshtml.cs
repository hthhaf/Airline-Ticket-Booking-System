using B2C.ApiHelper.Model;
using B2C.Data;
using B2C.Pages.Flight;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;
using System.Text.Encodings.Web;
#nullable disable

namespace B2C.Pages.Authen
{
    [Authorize]
    public class ProfileModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<ProfileModel> _logger;
        [BindProperty]
        public List<Booking> Bookings { get; set; }
      
        [BindProperty]
        public IdentityUser UserLogin { get; set; }
        public UserInfo UserLoginInfo { get; set; }
        public ProfileModel(ILogger<ProfileModel> logger, ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
            _dbContext = dbContext;
        }

        public async Task<IActionResult> OnGet()
        {
            if (string.IsNullOrEmpty(User.Identity.Name))
                return RedirectToPage("./Login");
            else
            {
                UserLogin = await _userManager.FindByNameAsync(User.Identity.Name);
                UserLoginInfo = _dbContext.UserInfo.FirstOrDefault(x => x.CreatedBy.Contains(User.Identity.Name));
                Bookings = _dbContext.Bookings.Where(x => x.CreatedBy.Contains(User.Identity.Name)).ToList();
                return Page();
            }
        }


        public async Task<IActionResult> OnPost()
        {
            if (string.IsNullOrEmpty(User.Identity.Name))
            {
                return RedirectToPage("./Login");
            }
            else
            {
                var existingInfo = _dbContext.UserInfo.FirstOrDefault(x => x.CreatedBy.Contains(User.Identity.Name));

                if (existingInfo != null)
                {
                    // Use model binding instead of manually retrieving form values
                    if (await TryUpdateModelAsync(existingInfo, "UserLoginInfo"))
                    {
                        // Save changes to the database
                        _dbContext.UserInfo.Update(existingInfo);
                        await _dbContext.SaveChangesAsync();

                        TempData["ShowSweetAlert"] = true;
                    }
                }
                else
                {
                    // Create a new instance of UserInfo
                    var userInfo = new UserInfo();

                    // Use model binding to populate the properties
                    if (await TryUpdateModelAsync(userInfo, "UserLoginInfo"))
                    {
                        userInfo.CreatedBy = User.Identity.Name;
                        _dbContext.UserInfo.Add(userInfo);
                        await _dbContext.SaveChangesAsync();

                        TempData["ShowSweetAlert"] = true;
                    }
                }

                return RedirectToPage("./Profile");
            }
        }



    }
}
