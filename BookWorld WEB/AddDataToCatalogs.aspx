<%@ Page Language="C#" Debug="true" AutoEventWireup="true" CodeBehind="AddDataToCatalogs.aspx.cs" Inherits="BookWorld_WEB.AddDataToCatalogs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>Жанры</asp:ListItem>
                <asp:ListItem>Товары</asp:ListItem>
            </asp:DropDownList><br /><br />
            <asp:Button ID="XmlAddButton" runat="server" Text="Добавить XML заготовку" style="height: 26px;" OnClick="XmlAddButton_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp<asp:Button ID="JsonAddButton" runat="server" Text="Добавить JSON заготовку" Width="232px" />
            <br />
            <asp:TextBox ID="TextBox" runat="server" Height="195px" TextMode="MultiLine" Width="930px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="ExecButton" runat="server" Text="Отправить запрос" Width="208px" OnClick="ExecButton_Click" />
        </div>
    </form>
</body>
</html>
