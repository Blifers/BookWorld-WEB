<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="BookWorld_WEB._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Web Application BookWorld</title>
</head>
<body>
    <form id="main" runat="server">
        <h1>BookWorld DataBase Web Interface</h1>
        <div>
            <asp:LinkButton ID="GenresLinkButton" runat="server" OnClick="GenresLinkButton_Click">Жанры</asp:LinkButton><br />
            <asp:LinkButton ID="TypesLinkButton" runat="server" OnClick="TypesLinkButton_Click">Типы товаров</asp:LinkButton><br />
            <asp:LinkButton ID="GoodsLinkButton" runat="server" OnClick="GoodsLinkButton_Click">Товары</asp:LinkButton><br />
            <asp:LinkButton ID="SellLinkButton" runat="server" OnClick="SellLinkButton_Click">Продажа</asp:LinkButton><br />
        </div>
    </form>
</body>
</html>
