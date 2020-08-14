using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CourseProject
{
    public partial class Personal : System.Web.UI.Page
    {
        static string virpath;
        static User user;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["userphone"] != null)
            {
                user = DBHelper.GetUserInfo(Request.Cookies["userphone"].Value);
                phone.Text = user.Phone;
                username.Text = user.Id;
                email.Text = user.Email;
                pwd.Text = user.pwd;
            }
           
                GridView1.DataSource = DBHelper.GetPostsByUserId(user.Id);
                GridView1.DataBind();
            }
        }
        protected void loginbtn_Click(object sender, EventArgs e)
        {
            string phone_s = phone.Text;
            //if (!DBHelper.TestPhoneAva(phone_s))
            //{
            //    Response.Write("<script>alert('手机号已经被注册！')</script>");
            //    return;
            //}

            string id = username.Text;
            string email_s = email.Text;
            string pwd_s = pwd.Text;
            
            
            
            
            Boolean fileOk = false;
            if (pic_upload.HasFile)//验证是否包含文件
            {
                //取得文件的扩展名,并转换成小写
                string fileExtension = Path.GetExtension(pic_upload.FileName).ToLower();
                //验证上传文件是否图片格式
                fileOk = IsImage(fileExtension);

                if (fileOk)
                {
                    //对上传文件的大小进行检测，限定文件最大不超过8M
                    if (pic_upload.PostedFile.ContentLength < 8192000)
                    {
                        string filepath = "img/";
                        if (Directory.Exists(Server.MapPath(filepath)) == false)//如果不存在就创建file文件夹
                        {
                            Directory.CreateDirectory(Server.MapPath(filepath));
                        }
                        virpath = filepath + pwd.Text + phone.Text + fileExtension;//这是存到服务器上的虚拟路径
                        string mappath = Server.MapPath(virpath);//转换成服务器上的物理路径
                        pic_upload.PostedFile.SaveAs(mappath);//保存图片
                                                              //显示图片
                                                              // pic.ImageUrl = virpath;
                                                              //清空提示
                        lbl_pic.Text = "";
                    }
                    else
                    {
                        virpath = "";
                        lbl_pic.Text = "文件大小超出8M！请重新选择！";

                        return;
                    }
                }
                else
                {
                    virpath = "";
                    //pic.ImageUrl = "";
                    lbl_pic.Text = "要上传的文件类型不对！请重新选择！";
                    return;
                }
            }
            else
            {
                virpath = "";
                // pic.ImageUrl = "";
                //lbl_pic.Text = "请选择要上传的头像！";
               
            }
            string avatar = virpath;
            if (!DBHelper.UpdatePersonalInfo(id, email_s, pwd_s, phone_s, avatar))
            {
                Response.Write("<script>alert('数据库错误')</script>");
            }
            else
            {
                Response.Write("<script>alert('更新成功！')</script>");
               
                Response.Redirect("index.aspx");
            }

        }
        public bool IsImage(string str)
        {
            bool isimage = false;
            string thestr = str.ToLower();
            //限定只能上传jpg和gif图片
            string[] allowExtension = { ".jpg", ".gif", ".bmp", ".png" };
            //对上传的文件的类型进行一个个匹对
            for (int i = 0; i < allowExtension.Length; i++)
            {
                if (thestr == allowExtension[i])
                {
                    isimage = true;
                    break;
                }
            }
            return isimage;
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument); //待处理的行下标
            string itemId = "";
            switch (e.CommandName)
            {    //删除
                case "Delete":
                    itemId = GridView1.Rows[index].Cells[0].Text;
                    DBHelper.DeletePostById(itemId);
                    GridView1.DataSource = DBHelper.GetPostsByUserId(user.Id);

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
    }
}