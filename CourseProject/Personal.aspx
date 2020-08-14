<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Personal.aspx.cs" Inherits="CourseProject.Personal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div style="text-align:center">
                  <asp:Label ID="Label7" runat="server" Text="个人信息" Font-Size="X-Large"></asp:Label>
            </div>
          
              <div  style="background-color: #FCA311; margin:auto; padding:10px;margin-top:50px;width:500px; border-radius:20px">
           <table style="width:100%;padding:20px" cellspacing="5" >
          
               <tr>
                   <td>
                <asp:Label runat="server"  Text ="手机号" CssClass="form1"></asp:Label>
                       </td>
                   <td>
                <asp:TextBox runat="server" ID="phone" CssClass="form1" Enabled="False"></asp:TextBox>
                       <br />
                </td>
                  
               </tr>
               <tr>
                   <td>
                <asp:Label runat="server"  Text ="用户名" ID="Label1" CssClass="form1"></asp:Label>
                </td>
                    <td>
                <asp:TextBox runat="server" ID="username" CssClass="form1" Enabled="False"></asp:TextBox>
                        <br />
                     </td>
                   </tr>
                <tr>
                   <td>
                <asp:Label runat="server"  Text ="邮箱" ID="Label2" CssClass="form1"></asp:Label>
                  </td>
                     <td>
                <asp:TextBox runat="server" ID="email" CssClass="form1"></asp:TextBox>
                                             <br />
                                             <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="请输入正确的邮箱" CssClass="form1" ControlToValidate="email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                 </tr>
                
               <tr>
                   <td>
                <asp:Label runat="server"  Text ="密码" ID="Label3" CssClass="form1"></asp:Label>
                 </td>
                   <td>
                <asp:TextBox runat="server" ID="pwd" CssClass="form1"></asp:TextBox>
                              <br />
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请输入密码" CssClass="form1" ControlToValidate="pwd" ForeColor="Red"></asp:RequiredFieldValidator>
                   </td>
                    </tr>
                
              <tr>
                   <td>


       <asp:Label runat="server"  Text ="头像" ID="Label6" ></asp:Label>
      </td><td>
    <div><asp:FileUpload ID="pic_upload" runat="server" Width="100%" /><asp:Label ID="lbl_pic" runat="server" class="pic_text" ForeColor="Red"></asp:Label>
       
                         </div>
  
     </td>
                  </tr>
                       
                
               <tr>
                   <td></td>
                   <td>
                <asp:Button runat="server" ID="loginbtn" style="width:100%" Text="提交更改" OnClick="loginbtn_Click" />
                       </td>
                   </tr>
               <tr>
                   <td></td>
                   <td>
                       <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" style="width:100%" OnRowCommand="GridView1_RowCommand" OnRowDeleted="GridView1_RowDeleted" OnRowDeleting="GridView1_RowDeleting">
                           <Columns>
                               <asp:BoundField DataField="Id" HeaderText="帖子ID" />
                               <asp:BoundField DataField="title" HeaderText="标题" />
                               <asp:BoundField DataField="section" HeaderText="贴区" />
                               <asp:ButtonField CommandName="Delete" HeaderText="操作" Text="删除" />
                           </Columns>
                       </asp:GridView>
                       </td>
                   </tr>
                   
           </table>
        </div>
        </div>
    </form>
</body>
</html>
