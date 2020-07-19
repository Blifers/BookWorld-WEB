<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckBuys.aspx.cs" Inherits="BookWorld_WEB.CheckBuys" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="Номер_Прихода" DataSourceID="SqlDataSource1" EmptyDataText="There are no data records to display." ForeColor="Black" GridLines="Vertical">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="Номер_Прихода" HeaderText="Номер_Прихода" ReadOnly="True" SortExpression="Номер_Прихода" />
                    <asp:BoundField DataField="Дата" HeaderText="Дата" SortExpression="Дата" />
                    <asp:BoundField DataField="Комментарий" HeaderText="Комментарий" SortExpression="Комментарий" />
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
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BookWorldDataBaseConnectionString2 %>" DeleteCommand="DELETE FROM [Приход] WHERE [Номер_Прихода] = @Номер_Прихода" InsertCommand="INSERT INTO [Приход] ([Дата], [Комментарий]) VALUES (@Дата, @Комментарий)" ProviderName="<%$ ConnectionStrings:BookWorldDataBaseConnectionString2.ProviderName %>" SelectCommand="SELECT [Номер_Прихода], [Дата], [Комментарий] FROM [Приход]" UpdateCommand="UPDATE [Приход] SET [Дата] = @Дата, [Комментарий] = @Комментарий WHERE [Номер_Прихода] = @Номер_Прихода">
                <DeleteParameters>
                    <asp:Parameter Name="Номер_Прихода" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter DbType="Date" Name="Дата" />
                    <asp:Parameter Name="Комментарий" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter DbType="Date" Name="Дата" />
                    <asp:Parameter Name="Комментарий" Type="String" />
                    <asp:Parameter Name="Номер_Прихода" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
        <div>
            <br />
            <h4>Детальные документы</h4>
            <asp:LinkButton ID="DetailedBuysXML" runat="server" OnClick="DetailedBuysXML_Click">Все документы в XML</asp:LinkButton><br />
            <asp:LinkButton ID="DetailedBuyDocumentXML" runat="server" OnClick="DetailedBuyDocumentXML_Click">Выбранный документ в XML</asp:LinkButton><br />
            <asp:LinkButton ID="DetailedBuysJSON" runat="server" OnClick="DetailedBuysJSON_Click">Все документы в JSON</asp:LinkButton><br />
            <asp:LinkButton ID="DetailedBuyDocumentJSON" runat="server" OnClick="DetailedBuyDocumentJSON_Click">Выбранный документ в JSON</asp:LinkButton>
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
