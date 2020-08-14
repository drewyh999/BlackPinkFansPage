<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Lisa.aspx.cs" Inherits="CourseProject.Lisa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        body{
            background-image:url("img/lisa_background.jpg")
        }
         .lgrgbtn {
    padding: 20px;
    background-color: #f48c06;
    color: white;
    margin-right: 3px;
    border: 0;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        
           <%-- <div style="display:flex;align-items:center;justify-items:center;flex-direction:row">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/img/lisa_self.jpg" Height="400px"  />
           <div >
               <asp:Image ID="Image2" runat="server" ImageUrl="~/img/lisa_name.jpg" Width="400px" />
            <asp:GridView ID="GridView1" runat="server" Height="149px" Width="518px" >
        </asp:GridView>
               </div>
            <asp:Button ID="Button1" runat="server" Text="签到" Width="114px" CssClass="lgrgbtn" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="发帖" Width="90px" CssClass="lgrgbtn" />
        </div>--%>
         <div >
            <table>
                <tr>
                    <td></td>
                    <td><asp:Image ID="Image2" runat="server" ImageUrl="~/img/lisa_name.jpg" Width="600px" /></td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                         <asp:Image ID="Image3" runat="server" ImageUrl="~/img/lisa_self.jpg" Width="300px"  />
                    </td>
                    <td style="vertical-align:top">
                         <asp:GridView ID="GridView1" runat="server" style="width:100%" AutoGenerateColumns="False" >
                             <Columns>
                                 <asp:BoundField DataField="title" HeaderText="标题" />
                                 <asp:BoundField DataField="authorid" HeaderText="作者" />
                                 <asp:BoundField DataField="posttime" HeaderText="发帖时间" />
                                 <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="PostDetail.aspx?post_id={0}" HeaderText="详情" Text="帖子详情" />
                             </Columns>
                         </asp:GridView>
                    </td>
                    <td style="vertical-align:top">
                         <div id="info" runat="server" style="align-items:center; background-color:#ada7c9;flex-direction:column;padding:20px">
                            
        <div style="display:inline-block;height:100px;width:100px">
            <asp:Image ID="avatar" runat="server" Height="100px" Width="100px"  />       
            </div>
        <div style="display:inline-block;width:200px; margin-top:0px;padding:10px">
          用户名： <asp:Label ID="id_text" runat="server" Text="用户名" Font-Size="Large"></asp:Label>
            <br/>
          手机号：  <asp:Label ID="phone_text" runat="server" Text="手机号"  Font-Size="Large"></asp:Label>
            <br/>
           余额： <asp:Label ID="balance_text" runat="server" Text="余额"  Font-Size="Large"></asp:Label> 元
            <br/>
       
        <div >
           
            <asp:Button ID="Button4" runat="server" Text="退出当前账号" style="margin:auto" Width="200px" OnClick="Button2_Click"/>
        </div>
             </div>
                                
                             <br />
                            
                             <asp:Button ID="Button1" runat="server" Text="签到" Width="150px" CssClass="lgrgbtn" OnClick="Button1_Click" />
                    
                         
            <asp:Button ID="Button2" runat="server" Text="发帖" Width="150px" CssClass="lgrgbtn"  PostBackUrl="~/NewPost.aspx?section=lisa" />
                               <asp:Button  runat="server" Text="返回主页" CssClass="lgrgbtn" PostBackUrl="~/index.aspx" />
                  </div>
        <div id="nolog" runat="server" >
            <asp:Label ID="Label4" runat="server" Text="未登陆" Font-Size="X-Large"></asp:Label> </div>
                         
                  
                        </td>
                              
                </tr>
           
           
           
                </table>
            
        </div>
    </form>
</body>
</html>
