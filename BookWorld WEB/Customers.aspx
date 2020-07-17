<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="BookWorld_WEB.Постоянные_клиенты" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Постоянные клиенты</title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            text-align: justify;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 class="auto-style1">Постоянные клиенты</h1>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Номер_Карты" DataSourceID="SqlDataSource1" EmptyDataText="There are no data records to display." AllowSorting="True" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" ShowHeaderWhenEmpty="True">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                    <asp:BoundField DataField="Номер_Карты" HeaderText="Номер_Карты" ReadOnly="True" SortExpression="Номер_Карты" />
                    <asp:BoundField DataField="ФИО" HeaderText="ФИО" SortExpression="ФИО" />
                    <asp:BoundField DataField="Дата_Вручения" HeaderText="Дата_Вручения" SortExpression="Дата_Вручения" />
                    <asp:BoundField DataField="Телефон" HeaderText="Телефон" SortExpression="Телефон" />
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
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BookWorldDataBaseConnectionString1 %>" DeleteCommand="DELETE FROM [Постоянные_Клиенты] WHERE [Номер_Карты] = @Номер_Карты" InsertCommand="INSERT INTO [Постоянные_Клиенты] ([ФИО], [Дата_Вручения], [Телефон]) VALUES (@ФИО, @Дата_Вручения, @Телефон)" ProviderName="<%$ ConnectionStrings:BookWorldDataBaseConnectionString1.ProviderName %>" SelectCommand="SELECT [Номер_Карты], [ФИО], [Дата_Вручения], [Телефон] FROM [Постоянные_Клиенты]" UpdateCommand="UPDATE [Постоянные_Клиенты] SET [ФИО] = @ФИО, [Дата_Вручения] = @Дата_Вручения, [Телефон] = @Телефон WHERE [Номер_Карты] = @Номер_Карты">
                <DeleteParameters>
                    <asp:Parameter Name="Номер_Карты" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="ФИО" Type="String" />
                    <asp:Parameter DbType="Date" Name="Дата_Вручения" />
                    <asp:Parameter Name="Телефон" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="ФИО" Type="String" />
                    <asp:Parameter DbType="Date" Name="Дата_Вручения" />
                    <asp:Parameter Name="Телефон" Type="String" />
                    <asp:Parameter Name="Номер_Карты" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <br />
        </div>
        <div class="auto-style2">
            <div class="auto-style2">
            <asp:Label ID="Label1" runat="server" Text="ФИО"></asp:Label><br />
            <asp:TextBox ID="FIOTextBox" runat="server"></asp:TextBox><br />
            <asp:Label ID="Label2" runat="server" Text="Дата вручения"></asp:Label><br />
            </div>
            <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
            <div class="auto-style2">
            <asp:Label ID="Label3" runat="server" Text="Номер телефона"></asp:Label><br />
            <asp:TextBox ID="PhoneNumberTextBox" runat="server"></asp:TextBox><br /><br />
            <asp:Button ID="AddButton" runat="server" Text="Добавить" OnClick="AddButton_Click" />
            </div>
        </div>
        <div>
            <br />
            <asp:LinkButton ID="XmlLinkButton" runat="server" OnClick="XmlLinkButton_Click">Посмотреть в XML</asp:LinkButton><br />
            <asp:LinkButton ID="JsonLinkButton" runat="server" OnClick="JsonLinkButton_Click">Посмотреть в JSON</asp:LinkButton>
        </div>
        <div>
            <br /><br /><br />
            <asp:LinkButton ID="BackToDefaultLinkButton" runat="server" OnClick="BackToDefaultLinkButton_Click">Вернуться на главную</asp:LinkButton>
        </div>
    </form>
</body>
</html>
