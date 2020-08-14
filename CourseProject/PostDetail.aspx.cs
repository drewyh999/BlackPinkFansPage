using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CourseProject
{
    public partial class PostDetail : System.Web.UI.Page
    {
        static Post post;
        protected void Page_Load(object sender, EventArgs e)
        {
            string post_id = Request["post_id"];

            /*Get the post info and the author info*/
            
            post = DBHelper.GetAPostById(post_id);
            
            
            User author = DBHelper.GetUserInfo(post.authorphone);
            
            
            title.Text = post.title;
            content_t.Text = post.content;
            posttime.Text = post.posttime;
            ID.Text = post.author;
            avatar.ImageUrl = author.Avatar;

            /*Get the image of this post */

            postimg.ImageUrl = post.imgpath;

            /*Get the comments of this post*/

            DataList1.DataSource = DBHelper.GetReplyByOriginalPostId(post_id);
            DataList1.DataBind();



        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            comment_text.CssClass = "input vis";
            comment_submit.CssClass = "input vis";
            comment_add.CssClass = "input invis";
        }

        protected void comment_submit_Click(object sender, EventArgs e)
        {
            User user = DBHelper.GetUserInfo(Request["userphone"]);
            if (DBHelper.InsertComment(post.Id, user.Id, Convert.ToString(DateTime.Now), comment_text.Text)){
                //Response.Write(" < script language=javascript>window.location.href=document.URL; < /script>");
                DataList1.DataSource = DBHelper.GetReplyByOriginalPostId(Convert.ToString(post.Id));
                DataList1.DataBind();
                comment_text.Text = "";
                comment_text.CssClass = "input invis";
                comment_submit.CssClass = "input invis";
                comment_add.CssClass = "input vis";
            }
            else
            {
                Response.Write("<script>alert('评论失败')</script>");
            }
        }
    }
}