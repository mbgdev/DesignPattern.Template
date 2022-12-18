using System.Text;

namespace DesignPattern.Template.TemplateDesignPattern
{
    public class PrimeUserCardTemplate : UserCardTemplate
    {
        protected override string SetFooter()
        {
            var sb = new StringBuilder();
            sb.Append("<a href='#' class='btn btn-sm btn-warning '>Profili Gör</a>");
            sb.Append("<a href='#' class='btn btn-sm btn-danger ms-2'>Mesaj Gönder</a>");
           
            return sb.ToString();
        }

        protected override string SetImage()
        {
            return $"<img class='car-img-top' src='{AppUser.Image}'  style='width:150px; height:150px;'>";
        }
    }
}
