<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Jennie.aspx.cs" Inherits="CourseProject.Jennie" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-image:url('img/jennie_background.jpg')">
    <form id="form1" runat="server">
        <div>
            <asp:Image ID="Image1" runat="server" ImageUrl="~/img/jennie_background_2.jpg" />

            <asp:GridView ID="GridView1" runat="server" Height="359px" Width="1131px">
        </asp:GridView>
        </div>
        
    </form>
</body>
</html>
