<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="CourseProject.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        
        .form1{
           margin-left:3px;
           margin-right:3px;
           width:100%
        }
        .genderbox{
            display:inline-block;
        }
       
        .form{
            margin:auto;
            border-top:20px;
        }
        .img{
            height:100%;
            width:100%;
        }
        td{
            vertical-align:middle;
        }
                
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Image ID="Image2" runat="server" ImageUrl="~/img/top_blk.png" style="position:absolute"/>
        
        
        
        <asp:Image ID="Image1" runat="server" ImageUrl="~/img/registerbackground.jpg" Width="100%" CssClass="img" />
        <br />
        <div  style="background-color: #335c67; margin:auto; padding:10px;position:absolute; top:20%;left:20%;right:20%;width:500px; ">
           <table style="width:100%;" cellspacing="5">
          
               <tr>
                   <td>
                <asp:Label runat="server"  Text ="手机号" CssClass="form1"></asp:Label>
                       </td>
                   <td>
                <asp:TextBox runat="server" ID="phone" CssClass="form1"></asp:TextBox>
                       <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="请输入正确的手机号" CssClass="form1" ControlToValidate="phone" ForeColor="Red" ValidationExpression="^1[0-9]{10}$"></asp:RegularExpressionValidator>
                </td>
                  
               </tr>
               <tr>
                   <td>
                <asp:Label runat="server"  Text ="用户名" ID="Label1" CssClass="form1"></asp:Label>
                </td>
                    <td>
                <asp:TextBox runat="server" ID="username" CssClass="form1"></asp:TextBox>
                        <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="请输入用户名" CssClass="form1" ControlToValidate="username" ForeColor="Red"></asp:RequiredFieldValidator>
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
                <asp:Label runat="server"  Text ="性别" ID="Label5" CssClass=" genderbox" ></asp:Label>
                </td>
                    <td>
                            <asp:RadioButton ID="RadioButton1" runat="server" CssClass=" " GroupName="gender" Text="男"/>
                             <asp:RadioButton ID="RadioButton2" runat="server" CssClass="" GroupName="gender" Text="女"/>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage=" " CssClass="form1" ControlToValidate="username" Font-Bold="False"></asp:RequiredFieldValidator>
             </td>
                    </tr>
               <tr>
                   <td>
                <asp:Label runat="server"  Text ="密码" ID="Label3" CssClass="form1"></asp:Label>
                 </td>
                   <td>
                <asp:TextBox runat="server" ID="pwd" CssClass="form1" TextMode="Password"></asp:TextBox>
                              <br />
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请输入密码" CssClass="form1" ControlToValidate="pwd" ForeColor="Red"></asp:RequiredFieldValidator>
                   </td>
                    </tr>
                <tr>
                   <td>
                <asp:Label runat="server"  Text ="确认密码" ID="Label4" CssClass="form1"></asp:Label>
             </td>
                     <td>
                <asp:TextBox runat="server" ID="pwd_confirm" CssClass="form1" TextMode="Password"></asp:TextBox>
                                                           <br />
                                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="请输入密码" CssClass="form1" ControlToValidate="pwd_confirm" ForeColor="Red"></asp:RequiredFieldValidator>
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
                <asp:Button runat="server" ID="loginbtn" style="width:100%" Text="注册" OnClick="loginbtn_Click" />
                       </td>
                   </tr>
                   
           </table>
        </div>
    </form>
</body>
</html>
