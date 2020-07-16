<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sell.aspx.cs" Inherits="BookWorld_WEB.Sell" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Продажа</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Код_Товара" DataSourceID="SqlDataSource1" EmptyDataText="There are no data records to display." AllowPaging="True" AllowSorting="True" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" PageSize="20">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="Код_Товара" HeaderText="Код_Товара" ReadOnly="True" SortExpression="Код_Товара" />
                    <asp:BoundField DataField="Тип_Товара" HeaderText="Тип_Товара" SortExpression="Тип_Товара" />
                    <asp:BoundField DataField="Жанр" HeaderText="Жанр" SortExpression="Жанр" />
                    <asp:BoundField DataField="Наименование" HeaderText="Наименование" SortExpression="Наименование" />
                    <asp:BoundField DataField="Цена" HeaderText="Цена" SortExpression="Цена" />
                    <asp:BoundField DataField="Остаток" HeaderText="Остаток" SortExpression="Остаток" />
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
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BookWorldDataBaseConnectionString1 %>" DeleteCommand="DELETE FROM [Товары] WHERE [Код_Товара] = @Код_Товара" InsertCommand="INSERT INTO [Товары] ([Тип_Товара], [Жанр], [Наименование], [Цена], [Остаток]) VALUES (@Тип_Товара, @Жанр, @Наименование, @Цена, @Остаток)" ProviderName="<%$ ConnectionStrings:BookWorldDataBaseConnectionString4.ProviderName %>" SelectCommand="SELECT [Код_Товара], [Тип_Товара], [Жанр], [Наименование], [Цена], [Остаток] FROM [Товары]" UpdateCommand="UPDATE [Товары] SET [Тип_Товара] = @Тип_Товара, [Жанр] = @Жанр, [Наименование] = @Наименование, [Цена] = @Цена, [Остаток] = @Остаток WHERE [Код_Товара] = @Код_Товара">
                <DeleteParameters>
                    <asp:Parameter Name="Код_Товара" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Тип_Товара" Type="Int32" />
                    <asp:Parameter Name="Жанр" Type="Int32" />
                    <asp:Parameter Name="Наименование" Type="String" />
                    <asp:Parameter Name="Цена" Type="Decimal" />
                    <asp:Parameter Name="Остаток" Type="Int32" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Тип_Товара" Type="Int32" />
                    <asp:Parameter Name="Жанр" Type="Int32" />
                    <asp:Parameter Name="Наименование" Type="String" />
                    <asp:Parameter Name="Цена" Type="Decimal" />
                    <asp:Parameter Name="Остаток" Type="Int32" />
                    <asp:Parameter Name="Код_Товара" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <br />
        </div>
        <div>
            <asp:Label ID="Label1" runat="server" Text="Количество"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="AddButton" runat="server" Text="Добавить" />
            <br /><br />
        </div>
        <div>
            <asp:GridView ID="ChequeGridView" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
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
            <br /><br /><br />
            <asp:LinkButton ID="BackToDefaultLinkButton" runat="server" OnClick="BackToDefaultLinkButton_Click">Вернуться на главную</asp:LinkButton>
        </div>
    </form>
</body>
</html>
