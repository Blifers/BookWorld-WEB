<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Goods.aspx.cs" Inherits="BookWorld_WEB.Goods" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Товары</title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 class="auto-style1">Товары</h1>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Код_Товара" DataSourceID="SqlDataSource1" EmptyDataText="There are no data records to display." AllowPaging="True" AllowSorting="True" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
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
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BookWorldDataBaseConnectionString1 %>" DeleteCommand="DELETE FROM [Товары] WHERE [Код_Товара] = @Код_Товара" InsertCommand="INSERT INTO [Товары] ([Тип_Товара], [Жанр], [Наименование], [Цена], [Остаток]) VALUES (@Тип_Товара, @Жанр, @Наименование, @Цена, @Остаток)" ProviderName="<%$ ConnectionStrings:BookWorldDataBaseConnectionString1.ProviderName %>" SelectCommand="SELECT [Код_Товара], [Тип_Товара], [Жанр], [Наименование], [Цена], [Остаток] FROM [Товары]" UpdateCommand="UPDATE [Товары] SET [Тип_Товара] = @Тип_Товара, [Жанр] = @Жанр, [Наименование] = @Наименование, [Цена] = @Цена, [Остаток] = @Остаток WHERE [Код_Товара] = @Код_Товара">
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
            <div>
                <br />
                <asp:Label ID="Label5" runat="server" Text="Тип товара"></asp:Label><br />
                <asp:DropDownList ID="TypeDropDown" runat="server" DataSourceID="SqlDataSource3" DataTextField="Наименование" DataValueField="Код_Типа"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:BookWorldDataBaseConnectionString1 %>" SelectCommand="SELECT * FROM [Тип_Товара]"></asp:SqlDataSource>
                <br />
                <asp:Label ID="Label4" runat="server" Text="Жанры"></asp:Label><br />
                <asp:DropDownList ID="GenreDropDown" runat="server" DataSourceID="SqlDataSource2" DataTextField="Наименование" DataValueField="Код_Жанра"></asp:DropDownList><br />
                <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:BookWorldDataBaseConnectionString1 %>' SelectCommand="SELECT * FROM [Жанры]"></asp:SqlDataSource>
                <asp:Label ID="Label1" runat="server" Text="Наименование"></asp:Label><br />
                <asp:TextBox ID="TitleTextBox" runat="server"></asp:TextBox><br />
                <asp:Label ID="Label2" runat="server" Text="Цена"></asp:Label><br />
                <asp:TextBox ID="PriceTextBox" runat="server"></asp:TextBox><br />
                <asp:Label ID="Label3" runat="server" Text="Остаток"></asp:Label><br />
                <asp:TextBox ID="LeftTextBox" runat="server"></asp:TextBox><br />
                <br />
                <asp:Button ID="AddButton" runat="server" Text="Добавить" OnClick="AddButton_Click" />
            </div>
        </div>
        <div>
            <br /><br /><br />
            <asp:LinkButton ID="BackToDefaultLinkButton" runat="server" OnClick="BackToDefaultLinkButton_Click">Вернуться на главную</asp:LinkButton>
        </div>
    </form>
</body>
</html>
