<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangeDataInCatalogs.aspx.cs" Inherits="BookWorld_WEB.ChangeDataInCatalogs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" EnableSortingAndPagingCallbacks="True" ForeColor="Black" GridLines="Vertical" PageSize="20">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
        </div>
        <div>
            <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
            <br /><br />
            <asp:Button ID="XmlDeleteButton" runat="server" Text="Добавить XML заготовку для удаления" Width="340px" OnClick="XmlDeleteButton_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp<asp:Button ID="JsonDeleteButton" runat="server" Text="Добавить JSON заготовку для удаления" CssClass="auto-style1" Width="341px" OnClick="JsonDeleteButton_Click" /><br />
            <asp:Button ID="XmlChangeButton" runat="server" Text="Добавить XML заготовку для изменения" Width="340px" OnClick="XmlChangeButton_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp<asp:Button ID="JsonChangeButton" runat="server" Text="Добавить JSON заготовку для изменения" Width="340px" OnClick="JsonChangeButton_Click" />
            <br />
            <asp:TextBox ID="TextBox" runat="server" Height="195px" TextMode="MultiLine" Width="930px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="ClearButton" runat="server" Text="Очистить" OnClick="ClearButton_Click" />
            <br />
            <br />
            <asp:Button ID="ExecButton" runat="server" Text="Отправить запрос" Width="208px" OnClick="ExecButton_Click" />
            <br />
            <br />
            <asp:LinkButton ID="BackToDefault" runat="server" OnClick="BackToDefault_Click">Вернуться на главную</asp:LinkButton>
        </div>
    </form>
</body>
</html>
