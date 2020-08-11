<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CourseProject.index" MasterPageFile="~/Nocturnal.Master" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">


   

    <div style="padding:30px; background-color:#ada7c9;margin-top:2px;display:flex;align-items:center;">
        <div style="display:inline-block;height:100px;width:100px">
       <img src="img/0.gif" style="height:100px;width:100px"/>
            
            </div>
        <div style="display:inline-block;width:200px; margin-top:0px">
            <asp:Label ID="Label1" runat="server" Text="用户名" Font-Size="Large"></asp:Label>
            <br/>
            <asp:Label ID="Label2" runat="server" Text="手机号"  Font-Size="Large"></asp:Label>
            <br/>
            <asp:Label ID="Label3" runat="server" Text="余额"  Font-Size="Large"></asp:Label>
            <br/>
        </div>
        <div style="display:inline-block;">
            <asp:Button ID="Button1" runat="server" Text="充值" style="margin:auto" Width="200px" />
        </div>
      
        
    </div>
      
</asp:Content>
