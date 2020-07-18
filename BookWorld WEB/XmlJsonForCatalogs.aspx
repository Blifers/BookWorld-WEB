<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XmlJsonForCatalogs.aspx.cs" Inherits="BookWorld_WEB.XmlJsonForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Вывод данных в XML или JSON</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="TypeDropDownList" runat="server" DataSourceID="SqlDataSource1" DataTextField="Наименование" DataValueField="Код_Типа" width="105px"></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BookWorldDataBaseConnectionString1 %>" SelectCommand="SELECT * FROM [Тип_Товара]"></asp:SqlDataSource>
            <br />
            <br />
            <asp:Button ID="EnterButton" runat="server" Text="Применить" OnClick="EnterButton_Click" width ="105px"/>
            <br />
            <br />
            <asp:Button ID="DropButton" runat="server" OnClick="Button1_Click" Text="Сбросить" Width="105px" />
        </div>
        <div>
            <br /><br />
            <asp:LinkButton ID="BackToPreviousLinkButton" runat="server" OnClick="BackToPreviousLinkButton_Click">Вернуться назад</asp:LinkButton>
        </div>
    </form>
</body>
</html>
