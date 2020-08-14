using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CourseProject
{
    public partial class Jennie : System.Web.UI.Page
    {
        public static User user;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int lastVisitCounter;
                if (Request.Cookies["lastVisitCounter"] == null)
                {
                    lastVisitCounter = 0;
                }
                else
                {
                    lastVisitCounter = int.Parse(Request.Cookies["lastVisitCounter"].Value);
                }
                lastVisitCounter++;
                HttpCookie aCookie = new HttpCookie("lastVisitCounter");
                aCookie.Value = lastVisitCounter.ToString();
                aCookie.Expires = DateTime.MaxValue;
                Response.Cookies.Add(aCookie);

                if (!IsPostBack)
                {

                    if (Request.Cookies["userphone"] != null)
                    {
                        user = DBHelper.GetUserInfo(Request.Cookies["userphone"].Value);
                        nolog.Attributes.CssStyle.Value = "display:none";
                        id_text.Text = user.Id;
                        phone_text.Text = user.Phone;
                        balance_text.Text = Convert.ToString(user.Balance);
                        avatar.ImageUrl = user.Avatar;
                    }
                    else
                    {
                        info.Attributes.CssStyle.Value = "display:none";

                    }


                }
            }
            GridView1.DataSource = DBHelper.GetPostsBySection("jennie");
            GridView1.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["lastVisitCounter"] == null)
            {
                Response.Write("<script>alert('你已经连续在jennie基地签到了" + "1"　+ "天')</script>");
            }
            else
            {
                HttpCookie aCookie = Request.Cookies["lastVisitCounter"];
                Response.Write("<script>alert('你已经连续在jennie基地签到了" + aCookie.Value + "天')</script>");
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            HttpCookie cok = Request.Cookies["userphone"];
            if (cok != null)
            {





                TimeSpan ts = new TimeSpan(-1, 0, 0, 0);
                cok.Expires = DateTime.Now.Add(ts);//删除整个Cookie，只要把过期时间设置为现在

                Response.AppendCookie(cok);
            }
            user = null;
            Response.Redirect("index.aspx");
        }
        protected void Button5_Click(object sender, EventArgs e)
        {

            //Response.Redirect("NewPost.aspx");
        }
    }
}