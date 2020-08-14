<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="CourseProject.News" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        #item td{
            background-color:#0094ff;
            border-radius:20px;
            padding:10px;
        }
        body{
            background-color:#ffcbf2
        }
    </style>
</head> 
<body>
    <form id="form1" runat="server">
        <div style="width:60%;margin:auto">
            <div style="text-align:center">
            <asp:Label ID="Label3" runat="server" Text="BlackPink最新讯息" Font-Size="XX-Large" Font-Names="方正超粗黑繁体" ForeColor="#3399FF"></asp:Label>
                </div>
            <div style="position:absolute;right:0;top:0">
                  <asp:Button  runat="server" Text="返回主页" CssClass="lgrgbtn" PostBackUrl="~/index.aspx" />
            </div>
            <div>
            <asp:DataList ID="DataList1" runat="server">
                <ItemTemplate>
                   <table style="border-collapse:separate;margin-bottom:10px" cellspacing="30" id="item">
                        <tr>
                            <td rowspan="2">
                                <div >
                                <asp:Image ID="Image2" runat="server"   ImageUrl='<%#Eval("img") %>' ImageAlign="Middle" Width="200px" style="border-radius:20px" />
                                    </div>
                            </td>
                            <td style="background-color:#ffba08">
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("title") %>' Font-Size="X-Large"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("content") %>'></asp:Label>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
           
        </div>
            </div>
    </form>
</body>
</html>
