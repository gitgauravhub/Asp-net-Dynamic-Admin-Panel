using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DynamicDataTest
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtuserName.Text == "admin@admin.com" && txtpassword.Text == "admin")
            {
                FormsAuthentication.SetAuthCookie(
                 this.txtuserName.Text.Trim(), false);

                FormsAuthenticationTicket ticket1 =
                   new FormsAuthenticationTicket(
                        1,                                   // version
                        this.txtuserName.Text.Trim(),   // get username  from the form
                        DateTime.Now,                        // issue time is now
                        DateTime.Now.AddMinutes(10),         // expires in 10 minutes
                        false,      // cookie is not persistent
                        "Admin"                              // role assignment is stored
                    // in userData
                        );
                HttpCookie cookie1 = new HttpCookie(
                  FormsAuthentication.FormsCookieName,
                  FormsAuthentication.Encrypt(ticket1));
                Response.Cookies.Add(cookie1);

                // 4. Do the redirect. 
                String returnUrl1;
                // the login is successful
                if (Request.QueryString["ReturnUrl"] == null)
                {
                    returnUrl1 = "Default.aspx";
                }

                //login not unsuccessful 
                else
                {
                    returnUrl1 = Request.QueryString["ReturnUrl"];
                    lblInfo.Text = "Please check User Email or Password";
                }
                Response.Redirect(returnUrl1);
                // Response.Redirect("Default.aspx");
            }
            else
            { lblInfo.Text = "Please check User Email or Password"; }
        }
    }
}