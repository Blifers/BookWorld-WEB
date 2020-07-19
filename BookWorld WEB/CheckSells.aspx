<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckSells.aspx.cs" Inherits="BookWorld_WEB.CheckSells" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Номер_Продажи" DataSourceID="SqlDataSource1" EmptyDataText="There are no data records to display." AllowSorting="True" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="Номер_Продажи" HeaderText="Номер_Продажи" ReadOnly="True" SortExpression="Номер_Продажи" />
                    <asp:BoundField DataField="Дата" HeaderText="Дата" SortExpression="Дата" />
                    <asp:BoundField DataField="Номер_Карты" HeaderText="Номер_Карты" SortExpression="Номер_Карты" />
                    <asp:BoundField DataField="Сумма_Продажи" HeaderText="Сумма_Продажи" SortExpression="Сумма_Продажи" />
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
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BookWorldDataBaseConnectionString1 %>" DeleteCommand="DELETE FROM [Продажа] WHERE [Номер_Продажи] = @Номер_Продажи" InsertCommand="INSERT INTO [Продажа] ([Дата], [Номер_Карты], [Сумма_Продажи]) VALUES (@Дата, @Номер_Карты, @Сумма_Продажи)" ProviderName="<%$ ConnectionStrings:BookWorldDataBaseConnectionString2.ProviderName %>" SelectCommand="SELECT [Номер_Продажи], [Дата], [Номер_Карты], [Сумма_Продажи] FROM [Продажа]" UpdateCommand="UPDATE [Продажа] SET [Дата] = @Дата, [Номер_Карты] = @Номер_Карты, [Сумма_Продажи] = @Сумма_Продажи WHERE [Номер_Продажи] = @Номер_Продажи">
                <DeleteParameters>
                    <asp:Parameter Name="Номер_Продажи" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter DbType="Date" Name="Дата" />
                    <asp:Parameter Name="Номер_Карты" Type="Int32" />
                    <asp:Parameter Name="Сумма_Продажи" Type="Decimal" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter DbType="Date" Name="Дата" />
                    <asp:Parameter Name="Номер_Карты" Type="Int32" />
                    <asp:Parameter Name="Сумма_Продажи" Type="Decimal" />
                    <asp:Parameter Name="Номер_Продажи" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
        <div>
            <br />
            <h4>Детальные документы</h4>
            <asp:LinkButton ID="DetailedSellsXML" runat="server" OnClick="DetailedSellsXML_Click">Все документы в XML</asp:LinkButton><br />
            <asp:LinkButton ID="DetailedSellDocumentXML" runat="server" OnClick="DetailedSellDocumentXML_Click">Выбранный документ в XML</asp:LinkButton><br />
            <asp:LinkButton ID="DetailedSellsJSON" runat="server" OnClick="DetailedSellsJSON_Click">Все документы в JSON</asp:LinkButton><br />
            <asp:LinkButton ID="DetailedSellDocumentJSON" runat="server" OnClick="DetailedSellDocumentJSON_Click">Выбранный документ в JSON</asp:LinkButton>
        </div>
        <div>
            <br />
            <h4>Шапки документа</h4>
            <asp:LinkButton ID="HeadsInXML" runat="server" OnClick="HeadsInXML_Click">Посмотреть все шапки документа в XML</asp:LinkButton><br />
            <asp:LinkButton ID="HeadsInJSON" runat="server" OnClick="HeadsInJSON_Click">Посмотреть все шапки документа в JSON</asp:LinkButton><br />
            <asp:LinkButton ID="HeadInXML" runat="server" OnClick="HeadInXML_Click">Посмотреть шапку этого документа в XML</asp:LinkButton><br />
            <asp:LinkButton ID="HeadInJSON" runat="server" OnClick="HeadInJSON_Click">Посмотреть шапку этого документа в JSON</asp:LinkButton><br />
        </div>
        <div>
            <br />
            <h4>Табличные части документа</h4>
            <asp:LinkButton ID="DocsInXML" runat="server" OnClick="DocsInXML_Click">Посмотреть табличные части всех документов в XML</asp:LinkButton><br />
            <asp:LinkButton ID="DocsInJSON" runat="server" OnClick="DocsInJSON_Click">Посмотреть табличные части всех документов в JSON</asp:LinkButton><br />
            <asp:LinkButton ID="DocInXML" runat="server" OnClick="DocInXML_Click">Посмотреть табличную часть этого документа в XML</asp:LinkButton><br />
            <asp:LinkButton ID="DocInJSON" runat="server" OnClick="DocInJSON_Click">Посмотреть табличную часть этого документа в JSON</asp:LinkButton><br />
        </div>
        <div>
            <br /><br /><br />
            <asp:LinkButton ID="BackToDefaultLinkButton" runat="server" OnClick="BackToDefaultLinkButton_Click">Вернуться на главную</asp:LinkButton>
        </div>
    </form>
</body>
</html>
