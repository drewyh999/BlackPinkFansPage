using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CourseProject
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        static User user;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                DataList1.DataSource = DBHelper.GetMerchandiseAll();
                DataList1.DataBind();
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
                GridView1.DataSource = DBHelper.GetShoppingCartByBuyerId(user.Id);
                GridView1.DataBind();

            }
           
             
        }
        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {

            int index = Convert.ToInt32(e.CommandArgument);
            string item_name = ((Label)(DataList1.Items[index].FindControl("Label1"))).Text;
            string price = ((Label)(DataList1.Items[index].FindControl("Label2"))).Text;
            if (DBHelper.AddShoppingCart(user.Id, item_name, price))
            {
                Response.Write("<script>alert('添加成功')</script>");
                GridView1.DataSource = DBHelper.GetShoppingCartByBuyerId(user.Id);
                GridView1.DataBind();
            }
            else
            {
                Response.Write("<script>alert('添加失败')</script>");
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            DataList1.DataSource = DBHelper.GetMerchandiseAll();
            DataList1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DataList1.DataSource = DBHelper.GetMerchandiseByCate("acc");
            DataList1.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            DataList1.DataSource = DBHelper.GetMerchandiseByCate("album");
            DataList1.DataBind();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            DataList1.DataSource = DBHelper.GetMerchandiseByCate("maga");
            DataList1.DataBind();
        }

        protected void Button6_Click(object sender, EventArgs e)
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument); //待处理的行下标
            string itemId = "";
            switch (e.CommandName)
            {    //删除
                case "Delete":
                    itemId = GridView1.Rows[index].Cells[0].Text;
                    DBHelper.DeleteShoppingCart(itemId);
                    GridView1.DataSource = DBHelper.GetShoppingCartByBuyerId(user.Id);
                    
                    GridView1.DataBind();
                    Response.Write("<script>alert('删除成功')</script>");
                    break;
                default:
                    break;
            }

        }

        protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int sum = DBHelper.GetShoppingCartSum(user.Id);
            int new_balance = user.Balance - sum;
            if (DBHelper.UpdateBalance(user.Id, new_balance))
            {
                Response.Write("<script>alert('购买成功，本次消费" + sum +　"元')</script>");
                user = DBHelper.GetUserInfo(Request.Cookies["userphone"].Value);
                balance_text.Text = Convert.ToString(user.Balance);
            }
            else
            {
                Response.Write("<script>alert('购买失败')</script>");
            }
        }
    }
}