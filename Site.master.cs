using System;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.DynamicData;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace DynamicDataTest
{
    public partial class Site : System.Web.UI.MasterPage
    {

        protected void btn_logout_Click(object sender, System.EventArgs e)
        {
            //FormsAuthentication.SignOut();
            //foreach (var cookie in Request.Cookies.AllKeys)
            //{
            //    Request.Cookies.Remove(cookie);
            //}
            //foreach (var cookie in Response.Cookies.AllKeys)
            //{
            //    Response.Cookies.Remove(cookie);
            //}
            Session.Abandon();
            FormsAuthentication.SignOut();
            // clear authentication cookie
            HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie1.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie1);

            FormsAuthentication.RedirectToLoginPage();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.User.Identity.IsAuthenticated)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
        }
    }
}
