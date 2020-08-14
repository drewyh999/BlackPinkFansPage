<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="market_page.aspx.cs" Inherits="CourseProject.WebForm1"  EnableEventValidation="True" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        .lgrgbtn {
    padding: 20px;
    background-color: #f48c06;
    color: white;
    margin-top: 10px;
    border: 0;
    width:100%;
}
    .lgrgbtn:hover {
        background-color: #2b2d42;
        color: #f48c06;
    }
        body{
            background:#ffe5d9;
        }
        .auto-style1 {
            width: 144px;
        }
        .igrid
    {
        border: thin solid #DBDBDB;
        }
        
        .igrid:hover
        {
            border: thin solid #DBDBDB;
            }
        .img{
            width:150px;
            height:150px;
        }
        .auto-style2 {
            top: 0;
            position: relative;
            left: 0px;
            width: 281px;
        }
        .auto-style3 {
            height: 193px;
        }
        .auto-style4 {
            height: 95px;
        }
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
             <div style="width:60%;">
            <table style="width: 100%; opacity:0.9; z-index: auto;" cellspacing="10">
                <tr>
                    <td style="vertical-align:bottom">
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
           
            <asp:Button ID="Button6" runat="server" Text="退出当前账号" style="margin:auto" Width="200px" OnClick="Button6_Click"/>
        </div>
             </div>
                                
                             <br />
                            
                            
                  </div>
                         <div id="nolog" runat="server" >
            <asp:Label ID="Label4" runat="server" Text="未登陆" Font-Size="X-Large"></asp:Label> </div>
                    </td>
                    <td>                 <asp:Image ID="Image1" runat="server" ImageUrl="~/img/market_title.jpg" style="width:100%"/>
</td>
                </tr>
                <tr>
                    <td class="auto-style4" style="background-color:#81b29a;border:10px;vertical-align:top">
                        <asp:Button ID="Button5" runat="server" Text="全部" CssClass="lgrgbtn" OnClick="Button5_Click" />
                        <asp:Button ID="Button2" runat="server" Text="周边" CssClass="lgrgbtn" OnClick="Button2_Click"  />
                        <br />
                        
                        <asp:Button ID="Button3" runat="server" Text="专辑" CssClass="lgrgbtn" OnClick="Button3_Click" />
                        <br />
                        <asp:Button ID="Button4" runat="server" Text="杂志" CssClass="lgrgbtn" OnClick="Button4_Click" />
                    </td>
                      <td colspan="2" class="auto-style3" rowspan="3" style="vertical-align:top">
                          <div style="height:700px;overflow:scroll">
                        <asp:DataList ID="DataList1" runat="server" RepeatColumns="4" 
                RepeatDirection="Horizontal" Width="100%" 
        onitemcommand="DataList1_ItemCommand" Height="400px">
    <ItemStyle CssClass="igrid" />
    <ItemTemplate>
       <table class="tbl" style="margin-left:10px;margin-top:10px">
            <tr>
                <td style="text-align: center;margin:20px">
                    <div class="img">
                    <asp:Image ID="Image2" runat="server"  style="height:100%" ImageUrl='<%#Eval("image") %>' />
                        </div>
                </td>
            </tr>
            <tr>
                <td>
                                名称 :
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("name") %>' Font-Size="Medium"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                                价格 :
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("price") %>'></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                                <asp:Button ID="LinkButton1" runat="server" CommandArgument='<%#Eval("Id") %>' Text="加入购物车"></asp:Button>
                </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:DataList>
                        <br />
                              </div>
                    </td>
                    
                </tr>
                <tr>
                 <td class="auto-style1" style="vertical-align:top;background-color:#81b29a">
                        <div style="text-align:center">
                            <asp:Label ID="Label3" runat="server" Text="购物车" Font-Size="X-Large" Font-Names="方正粗黑繁体" ForeColor="#9933FF"></asp:Label>
                        </div>
                     <div style="height:300px;overflow:scroll">
                        <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False" CssClass="auto-style2" DataKeyNames="Id" OnRowCommand="GridView1_RowCommand" OnRowDeleted="GridView1_RowDeleted" OnRowDeleting="GridView1_RowDeleting">
                            <Columns>
                                <asp:BoundField DataField="Id" HeaderText="ID" />
                                <asp:BoundField DataField="name" HeaderText="品名" SortExpression="name" />
                                <asp:BoundField DataField="price" HeaderText="价格" SortExpression="price" />
                                <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="删除" />
                            </Columns>
                        </asp:GridView>
                         </div>
                        <br />
                        <asp:Button ID="Button1" runat="server" Text="结算" style="width:100%" CssClass="lgrgbtn" OnClick="Button1_Click" />
                        <br />
                        <asp:Button  runat="server" Text="返回主页" CssClass="lgrgbtn" PostBackUrl="~/index.aspx" />
                    </td>
                  
                   
                </tr>
                                
            </table>
                 <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [merchandise]"></asp:SqlDataSource>
           </div>
        </div>
        
        <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/marketcate.xml"></asp:XmlDataSource>
        <br />
        </div>
    </form>
</body>
</html>
