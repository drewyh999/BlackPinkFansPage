using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CourseProject
{
    
    public partial class index : System.Web.UI.Page
    {

        public static User user;
        protected void Page_PreInit(object sender, EventArgs e)
        {
            string mm = Request["master"];
            if (mm == "black")
                this.MasterPageFile = "Nocturnal.master";
            else
                this.MasterPageFile = "Diournal.master";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(MasterPageFile == "~/Nocturnal.Master")
            {
                MasterPageFile = "~/Diournal.Master";
            }
            else
            {
                MasterPageFile = "~/Nocturnal.Master";
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            int delta = Convert.ToInt32(payment.Text);
            int ori = user.Balance;
            delta += ori;
            if (DBHelper.UpdateBalance(user.Id, delta))
            {
                //Response.Write("<script>alert('充值成功！')</script>");
                Response.Redirect("index.aspx");
            }
            else
            {
                Response.Write("<script>alert('充值失败！')</script>");
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
    }
}