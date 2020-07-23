<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="BookWorld_WEB._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Web Application BookWorld</title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            text-align: left;
        }
        .auto-style3 {
            font-size: large;
        }
    </style>
</head>
<body>
    <form id="main" runat="server">
        <h1 class="auto-style1">BookWorld DataBase Web Interface</h1>
        <div class="auto-style1">
            <h3 class="auto-style2">Справочники</h3>
            <div class="auto-style2">
                <asp:LinkButton ID="GenresLinkButton" runat="server" CssClass="auto-style3" OnClick="GenresLinkButton_Click">Жанры</asp:LinkButton>
                <br class="auto-style3" />
                <asp:LinkButton ID="TypesLinkButton" runat="server" CssClass="auto-style3" OnClick="TypesLinkButton_Click">Типы товаров</asp:LinkButton>
                <br class="auto-style3" />
                <asp:LinkButton ID="GoodsLinkButton" runat="server" CssClass="auto-style3" OnClick="GoodsLinkButton_Click">Товары</asp:LinkButton>
                <br class="auto-style3" />
                <asp:LinkButton ID="CustomersLinkButton" CssClass="auto-style3" runat="server" OnClick="CustomersLinkButton_Click">Постоянные клиенты</asp:LinkButton>
                <br />
                <asp:LinkButton ID="WorkersLinkButton" CssClass="auto-style3" runat="server" OnClick="WorkersLinkButton_Click">Сотрудники</asp:LinkButton>
                <br />
            </div>
            <div class="auto-style2">
                <br />
                <h3 class="auto-style2">Документы</h3>
                <asp:LinkButton ID="SellsLinkButton" CssClass="auto-style3" runat="server" OnClick="SellsLinkButton_Click">Продажи</asp:LinkButton><br />
                <asp:LinkButton ID="BuysLinkButton" CssClass="auto-style3" runat="server" OnClick="BuysLinkButton_Click">Приходы</asp:LinkButton>
            </div>
            <div class="auto-style2">
                <br />
                <h3 class="auto-style2">ASMX</h3>
                <asp:LinkButton ID="ASMXPage" CssClass="auto-style3" runat="server" OnClick="ASMXPage_Click">Страница asmx</asp:LinkButton>
                <br /><br />
                <asp:LinkButton ID="LinkButton1" CssClass="auto-style3" runat="server" OnClick="LinkButton1_Click">Справочник Товары в Xml</asp:LinkButton>
                <br />
                <asp:LinkButton ID="LinkButton2" CssClass="auto-style3" runat="server" OnClick="LinkButton2_Click">Справочник Товары в Json</asp:LinkButton>
                <br /><br />
                <asp:LinkButton ID="GenresASMXtoXML" CssClass="auto-style3" runat="server" OnClick="GenresASMXtoXML_Click">Справочник Жанры в Xml</asp:LinkButton><br />
                <asp:LinkButton ID="GenresASMXtoJSON" CssClass="auto-style3" runat="server" OnClick="GenresASMXtoJSON_Click">Справочник Жанры в Json</asp:LinkButton>
                <br /><br />
                <asp:LinkButton ID="TypesASMXtoXML" CssClass="auto-style3" runat="server" OnClick="TypesASMXtoXML_Click">Справочник Тип товара в Xml</asp:LinkButton><br />
                <asp:LinkButton ID="TypesASMXtoJSON" CssClass="auto-style3" runat="server" OnClick="TypesASMXtoJSON_Click">Справочник Тип товара в Json</asp:LinkButton>
                <br /><br />
                <asp:LinkButton ID="WorkersASMXtoXML" CssClass="auto-style3" runat="server" OnClick="WorkersASMXtoXML_Click">Справочник Сотрудники в Xml</asp:LinkButton><br />
                <asp:LinkButton ID="WorkersASMXtoJSON" CssClass="auto-style3" runat="server" OnClick="WorkersASMXtoJSON_Click">Справочник Сотрудники в Json</asp:LinkButton>
                <br /><br />
                <asp:LinkButton ID="CustomersASMXtoXML" CssClass="auto-style3" runat="server" OnClick="CustomersASMXtoXML_Click">Справочник Постоянные клиенты в Xml</asp:LinkButton><br />
                <asp:LinkButton ID="CustomersASMXtoJSON" CssClass="auto-style3" runat="server" OnClick="CustomersASMXtoJSON_Click">Справочник Постоянные клиенты в Json</asp:LinkButton>
                <br />
                <br />
                <asp:LinkButton ID="BuysASMXtoXML" CssClass="auto-style3" runat="server" OnClick="BuysASMXtoXML_Click">Документ Приход в Xml</asp:LinkButton>
                <br />
                <asp:LinkButton ID="BuysASMXtoJSON" CssClass="auto-style3" runat="server" OnClick="BuysASMXtoJSON_Click">Документ Приход в Json</asp:LinkButton>
                <br /><br />
            </div>
        </div>
    </form>
</body>
</html>
