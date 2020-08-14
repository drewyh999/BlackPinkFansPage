<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewPost.aspx.cs" Inherits="CourseProject.NewPost" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        body{
            background-image:url("img/np_background.jpg")
        }
        .input{
            border-radius:15px 15px 15px 15px;
            border:3px solid #457b9d;
            padding:10px;
            margin-top:20px;
        }
        .input:focus{
            border:3px solid #FFc6FF;
        }
        
        .auto-style2 {
            width: 66px;
            height: 174px;
        }
        .auto-style3 {
            height: 174px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
<%--        <asp:Image ID="Image1" runat="server" ImageUrl="~/img/newpost_background_1.jpg" style="height:100%;width:100%;position:absolute;z-index:-1"/>--%>
        <div style="margin-left:10%;width:60%;margin-top:13%">
            <table style="width: 100%; background-color:#b5838d;opacity:0.9; z-index: auto;padding:50px;margin:20px">
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="a" runat="server" Text="主题"></asp:Label>
                    </td>
                    <td colspan="2"><asp:TextBox ID="title" runat="server" style="width:100%" CssClass="input"></asp:TextBox></td>
                    
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label2" runat="server" Text="内容"></asp:Label>
                    </td>
                    <td colspan="2" class="auto-style3">
                        <asp:TextBox ID="content" runat="server" TextMode="MultiLine" style="width:100%;height:100%" CssClass="input"></asp:TextBox>
                    </td>
                   
                </tr>
                <tr >
                    <td  class="auto-style1">
                        <asp:Label ID="Label3" runat="server" Text="图片"></asp:Label>
                        </td>
                    <td colspan="2">
                       
                        <asp:Image ID="postimg" runat="server" style="width:100%"/>
                        <asp:FileUpload ID="pic_upload" runat="server" Width="100%" /><asp:Label ID="lbl_pic" runat="server" class="pic_text" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr >
                    <td span="2" class="auto-style1">
                        
                        </td>
                    <td colspan="2">
                        <asp:Button ID="Button1" runat="server" Text="提交" style="width:100%;height:100%" CssClass="input" OnClick="Button1_Click" /></td>
                    
                </tr>
            </table>
           </div>
    </form>
   
</body>
</html>
