<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="CourseProject.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        
        .form1{
           margin-left:3px;
           margin-right:3px;
        }
       
        .form{
            margin:auto;
            border-top:20px;
        }
        .img{
            height:100%;
            width:100%;
        }
        .auto-style4 {
            position: absolute;
            left: 10px;
            top: 15px;
            width: 796px;
            height: 183px;
        }
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Image ID="Image2" runat="server" ImageUrl="~/img/top_white.png" CssClass="auto-style4" />
        <asp:Image ID="Image1" runat="server" ImageUrl="~/img/loginbackground2.jpg" Width="100%" CssClass="img" />
        <br />
        <div  style="background-color: #ffd6a5; margin:auto; padding:50px;position:absolute; top:25%;left:20%;right:20%;width:500px;height:100px;">
    
            <div id="form" >
                <div style="display:block;text-align:center"  >

                <asp:Label runat="server"  Text ="手机号" CssClass="form1"></asp:Label>
                <asp:TextBox runat="server" ID="phone" CssClass="form1"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="请输入手机号" ControlToValidate="phone" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                <br />
                    </div>
                <div style="display:block;text-align:center" >
                <asp:Label runat="server"  Text ="密码" ID="Label1" CssClass="form1"></asp:Label>
                &nbsp;&nbsp;&nbsp;
                <asp:TextBox runat="server" ID="pwd" CssClass="form1" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请输入密码" ControlToValidate="pwd" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    </div>
                <br />
                <div style="display:block;text-align:center">
                <asp:Button runat="server" ID="loginbtn" CssClass =" form1" Text="登入" OnClick="loginbtn_Click" />
                    </div>
            </div>
        </div>
    </form>
</body>
</html>
