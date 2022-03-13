using Microsoft.AspNetCore.Mvc.Filters;

namespace PortfolioApp.Data;

public class BasicAuthenticationAttribute : ActionFilterAttribute
{
    public string BasicRealm { get; set; }
    protected string Password { get; set; }

    public BasicAuthenticationAttribute(string password)
    {
        Password = password;
    }

    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        var req = filterContext.HttpContext.Request;
        var auth = req.Headers["Authorization"];
        if (!string.IsNullOrEmpty(auth))
        {
            var cred = auth.ToArray();
            var user = new { Pass = cred[1] };
            if (user.Pass == Password) return;
        }
        var res = filterContext.HttpContext.Response;
        res.StatusCode = 401;
        res.Headers.Add("WWW-Authenticate", $"Basic realm=\"{BasicRealm}\"");
    }
}