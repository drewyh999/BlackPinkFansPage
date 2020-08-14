using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CourseProject
{
    public partial class Diournal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime startdate = Convert.ToDateTime("2016-8-8");
            DateTime now = DateTime.Now;
            TimeSpan timeSpan = now - startdate;

            Label1.Text = Convert.ToString( timeSpan.Days+"天");
            Calendar1.TodaysDate = now;

            if (!IsPostBack)
            {

                if (Request.Cookies["userphone"] != null)
                {
                    container_chart.Visible = true;
                }
                else
                {
                    container_chart.Visible = false;

                }


            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            Response.Redirect("register.aspx");
        }
    }
}