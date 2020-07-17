<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Types.aspx.cs" Inherits="BookWorld_WEB.Types" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Типы товаров</title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 class="auto-style1">Типы товаров</h1>
            <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="Код_Типа" DataSourceID="SqlDataSource1" EmptyDataText="There are no data records to display." ForeColor="Black" GridLines="Vertical" ShowHeaderWhenEmpty="True">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                    <asp:BoundField DataField="Код_Типа" HeaderText="Код_Типа" ReadOnly="True" SortExpression="Код_Типа" />
                    <asp:BoundField DataField="Наименование" HeaderText="Наименование" SortExpression="Наименование" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BookWorldDataBaseConnectionString1 %>" DeleteCommand="DELETE FROM [Тип_Товара] WHERE [Код_Типа] = @Код_Типа" InsertCommand="INSERT INTO [Тип_Товара] ([Наименование]) VALUES (@Наименование)" ProviderName="<%$ ConnectionStrings:BookWorldDataBaseConnectionString1.ProviderName %>" SelectCommand="SELECT [Код_Типа], [Наименование] FROM [Тип_Товара]" UpdateCommand="UPDATE [Тип_Товара] SET [Наименование] = @Наименование WHERE [Код_Типа] = @Код_Типа">
                <DeleteParameters>
                    <asp:Parameter Name="Код_Типа" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Наименование" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Наименование" Type="String" />
                    <asp:Parameter Name="Код_Типа" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Введите название"></asp:Label><br />
            <asp:TextBox ID="TitleTextBox" runat="server"></asp:TextBox><br /><br />
            <asp:Button ID="AddButton" runat="server" Text="Добавить" OnClick="AddButton_Click" />
        </div>
        <div>
            <br />
            <asp:LinkButton ID="XmlLinkButton" runat="server" OnClick="XmlLinkButton_Click">Посмотреть в XML</asp:LinkButton><br />
            <asp:LinkButton ID="JsonLinkButton" runat="server" OnClick="JsonLinkButton_Click">Посмотреть в JSON</asp:LinkButton>
        </div>
        <div>
            <br />
            <br />
            <br />
            <asp:LinkButton ID="BackToDefaultLinkButton" runat="server" OnClick="BackToDefaultLinkButton_Click">Вернуться на главную</asp:LinkButton>
        </div>
    </form>
</body>
</html>
