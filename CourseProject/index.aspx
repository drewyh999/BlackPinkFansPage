<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CourseProject.index" MasterPageFile="~/Diournal.Master" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
    <div style="padding:30px; background-color:#ada7c9;margin-top:2px;display:flex;align-items:center; flex-direction:row">
        <div id="info" runat="server" style="display:flex;align-items:center;">
        <div style="display:inline-block;height:100px;width:100px">
            <asp:ImageButton ID="avatar" runat="server" Height="100px" Width="100px" PostBackUrl="~/Personal.aspx"  />       
            </div>
        <div style="display:inline-block;width:200px; margin-top:0px;padding:10px">
          用户名： <asp:Label ID="id_text" runat="server" Text="用户名" Font-Size="Large"></asp:Label>
            <br/>
          手机号：  <asp:Label ID="phone_text" runat="server" Text="手机号"  Font-Size="Large"></asp:Label>
            <br/>
           余额： <asp:Label ID="balance_text" runat="server" Text="余额"  Font-Size="Large"></asp:Label> 元
            <br/>
        </div>
        <div style="display:inline-block;">
            <asp:TextBox ID="payment" runat="server" style="margin:auto" Width="200px"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" Text="充值" style="margin:auto" Width="200px" OnClick="Button1_Click1" />
            <br />
            <asp:Button ID="Button2" runat="server" Text="退出当前账号" style="margin:auto" Width="200px" OnClick="Button2_Click"/>
        </div>
            </div>
        <div id="nolog" runat="server" >
            <asp:Label ID="Label4" runat="server" Text="未登陆" Font-Size="X-Large"></asp:Label> </div>
    </div>     
</asp:Content>
