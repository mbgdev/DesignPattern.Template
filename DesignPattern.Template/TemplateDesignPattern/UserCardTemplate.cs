using DesignPattern.Template.DAL.Entities;
using System.Text;

namespace DesignPattern.Template.TemplateDesignPattern
{
    public abstract class UserCardTemplate
    {
        public AppUser AppUser { get; set; }

        public void SetUser(AppUser appUser)
        {
            AppUser = appUser;
        }

        public string Build()
        {
            var sb = new StringBuilder();
            sb.Append("<div class='card'>");
            sb.Append(SetImage());
            sb.Append($@"<div class='card-body'>
                       <h4>{AppUser.Name}</h4>
                        <p>{AppUser.Description}</p>");

            sb.Append(SetFooter());
            sb.Append("</div>");
            sb.Append("</div>");

            return sb.ToString();

        }


        protected abstract string SetImage();

        protected abstract string SetFooter();

    }
}
