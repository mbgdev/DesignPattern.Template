using System.Text;

namespace DesignPattern.Template.TemplateDesignPattern
{
    public class GoldUserCardTemplate : UserCardTemplate
    {
        protected override string SetFooter()
        {

            var sb = new StringBuilder();
            sb.Append("<a href='#' class='btn btn-sm btn-warning '>Profili Gör</a>");
            sb.Append("<a href='#' class='btn btn-sm btn-danger ms-2'>Mesaj Gönder</a>");
            sb.Append("<a href='#' class='btn btn-sm btn-success  ms-2'>Bağış Yap</a>");
            return sb.ToString();


        }

        protected override string SetImage()
        {
            return $"<img class='car-img-top' src='{AppUser.Image}'  style='width:355.99px; height:350.8px;'>";
        }
    }
}
