using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CourseProject
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginbtn_Click(object sender, EventArgs e)
        {
            if (DBHelper.VerifyUser(phone.Text, pwd.Text))
            {
                HttpCookie aCookie = new HttpCookie("userphone");
                aCookie.Value = phone.Text;
                aCookie.Expires = DateTime.MaxValue;
                Response.Cookies.Add(aCookie);
                Response.Redirect("index.aspx");

            }
            else
            {
                Response.Write("<script>alert('用户名或密码错误！')</script>");
            }
        }
    }
}