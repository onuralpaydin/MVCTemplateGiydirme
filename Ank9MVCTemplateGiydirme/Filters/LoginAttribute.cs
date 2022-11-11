using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Ank9MVCTemplateGiydirme.Filters
{
    public class LoginAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var email = context.HttpContext.Session.GetString("KullaniciEmail");
            if (string.IsNullOrEmpty(email))
            {
                context.Result = new RedirectToActionResult("Index","Login",new {area="Admin"});
            }
        }
    }
}
