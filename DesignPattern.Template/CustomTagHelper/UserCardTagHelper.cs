using DesignPattern.Template.DAL.Entities;
using DesignPattern.Template.TemplateDesignPattern;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DesignPattern.Template.CustomTagHelper
{
    public class UserCardTagHelper : TagHelper
    {
        private readonly UserManager<AppUser> _userManager;
        public AppUser AppUser { get; set; }

        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserCardTagHelper(IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            UserCardTemplate userCardTemplate;


            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                if (_userManager.IsEmailConfirmedAsync(AppUser).Result)
                {
                    userCardTemplate = new GoldUserCardTemplate();
                }
                else
                userCardTemplate = new PrimeUserCardTemplate();
            }

            else
            {
                userCardTemplate = new DefaultUserCardTemplate();
            }

            userCardTemplate.SetUser(AppUser);

            output.Content.SetHtmlContent(userCardTemplate.Build());
        }
    }
}
