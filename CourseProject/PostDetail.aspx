<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PostDetail.aspx.cs" Inherits="CourseProject.PostDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
   <style>
       body{
           background-color:#ffa69e;
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
        .auto-style3 {
            height: 174px;
        }
        .vis{
            display:block;
        }
        .invis{
            display:none;
        }
   </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin:auto;width:60%;">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/img/detail_1.jpg"  Width="200px"/>
            <asp:Image ID="Image3" runat="server" ImageUrl="~/img/detail_2.jpg"  Width="200px"/>
            <br />
            <table style="width: 100%; background-color:#b5838d;opacity:0.9; z-index: auto;padding:50px;">
                <tr>
                    <td class="auto-style1">
                        <div style="width:100px;height:200px">
                            <asp:Image ID="avatar" runat="server" ImageUrl="~/img/0.gif" style="width:100px;height:100px"/>
                            <br />
                            发帖人：<asp:Label ID="ID" runat="server" Text="发帖人ID"></asp:Label>
                            <br />
                            时间： <asp:Label ID="posttime" runat="server" Text="2020-8-9 21:00"></asp:Label>

                        </div>
                    </td>
                    <td colspan="2">
                        <asp:Label ID="title" runat="server" Text="主题" Font-Size="X-Large"></asp:Label></td>
                    
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="c" runat="server" Text="内容"></asp:Label>
                    </td>
                    <td colspan="2" class="auto-style3">
                        <asp:TextBox ID="content_t" runat="server" TextMode="MultiLine" style="width:100%;height:100%" CssClass="input" Enabled="True" ReadOnly="True"></asp:TextBox>
                    </td>
                   
                </tr>
                <tr >
                    <td span="2" class="auto-style1">
                       
                        </td>
                    <td colspan="2">
                        <asp:Image ID="postimg" runat="server" ImageUrl="~/img/car_1.jpg" style="width:100%;margin-top:30px"/></td>
                    
                </tr>
                <tr >
                    <td span="2" class="auto-style1">
                        <asp:Label ID="Label3" runat="server" Text="评论"></asp:Label>
                        </td>
                    <td colspan="2">
                    <%--     <asp:GridView ID="GridView1" runat="server"></asp:GridView>--%>
                        <asp:DataList ID="DataList1" runat="server" style="width:100%;overflow:scroll;">
                            <ItemTemplate>
                                <div style="width:100%;display:flex;align-content:center;justify-items:center;padding:20px;margin-top:8px;background-color:#02c39a;border-radius:20px">
                                    <asp:Label ID="Label4" runat="server"  Text='<%#Eval("author") %>'></asp:Label>&nbsp
                                     <asp:Label ID="Label5" runat="server"  Text='<%#Eval("replytime") %>'></asp:Label>&nbsp
                                     <asp:Label ID="Label6" runat="server"  Text='<%#Eval("replycontent") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:DataList>
                        </td>
                    
                </tr>
                <tr >
                    <td span="2" class="auto-style1">
                       
                        </td>
                    <td colspan="2">
                        <asp:Button ID="comment_add" runat="server" Text="添加评论" Cssclass="input" style="width:80%" OnClick="Button1_Click"  />
                        
                        <asp:TextBox ID="comment_text" runat="server" TextMode="MultiLine" style="width:100%;height:100%" CssClass="input invis auto-style3" ></asp:TextBox>
                         
                         <asp:Button ID="comment_submit" runat="server" Text="提交" Cssclass="input invis" style="width:80%" OnClick="comment_submit_Click" />
                        </td>
                    
                </tr>
            </table>
            
           </div>
    </form>
    <script>

    </script>
</body>
</html>
