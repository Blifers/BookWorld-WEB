<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Workers.aspx.cs" Inherits="BookWorld_WEB.Сотрудники" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 class="auto-style1">Сотрудники</h1>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Код_Сотрудника" DataSourceID="SqlDataSource1" EmptyDataText="There are no data records to display." AllowSorting="True" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                    <asp:BoundField DataField="Код_Сотрудника" HeaderText="Код_Сотрудника" ReadOnly="True" SortExpression="Код_Сотрудника" />
                    <asp:BoundField DataField="ФИО" HeaderText="ФИО" SortExpression="ФИО" />
                    <asp:BoundField DataField="Принят" HeaderText="Принят" SortExpression="Принят" />
                    <asp:BoundField DataField="Уволен" HeaderText="Уволен" SortExpression="Уволен" />
                    <asp:BoundField DataField="Дата_Рождения" HeaderText="Дата_Рождения" SortExpression="Дата_Рождения" />
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
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BookWorldDataBaseConnectionString1 %>" DeleteCommand="DELETE FROM [Сотрудники] WHERE [Код_Сотрудника] = @Код_Сотрудника" InsertCommand="INSERT INTO [Сотрудники] ([ФИО], [Принят], [Уволен], [Дата_Рождения], [Телефон]) VALUES (@ФИО, @Принят, @Уволен, @Дата_Рождения, @Телефон)" ProviderName="<%$ ConnectionStrings:BookWorldDataBaseConnectionString1.ProviderName %>" SelectCommand="SELECT [Код_Сотрудника], [ФИО], [Принят], [Уволен], [Дата_Рождения], [Телефон] FROM [Сотрудники]" UpdateCommand="UPDATE [Сотрудники] SET [ФИО] = @ФИО, [Принят] = @Принят, [Уволен] = @Уволен, [Дата_Рождения] = @Дата_Рождения, [Телефон] = @Телефон WHERE [Код_Сотрудника] = @Код_Сотрудника">
                <DeleteParameters>
                    <asp:Parameter Name="Код_Сотрудника" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="ФИО" Type="String" />
                    <asp:Parameter DbType="Date" Name="Принят" />
                    <asp:Parameter DbType="Date" Name="Уволен" />
                    <asp:Parameter DbType="Date" Name="Дата_Рождения" />
                    <asp:Parameter Name="Телефон" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="ФИО" Type="String" />
                    <asp:Parameter DbType="Date" Name="Принят" />
                    <asp:Parameter DbType="Date" Name="Уволен" />
                    <asp:Parameter DbType="Date" Name="Дата_Рождения" />
                    <asp:Parameter Name="Телефон" Type="String" />
                    <asp:Parameter Name="Код_Сотрудника" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
        <div>
            <asp:Label ID="Label1" runat="server" Text="ФИО"></asp:Label><br />
            <asp:TextBox ID="FIOTextBox" runat="server"></asp:TextBox><br />
            <asp:Label ID="Label2" runat="server" Text="Дата принятия"></asp:Label><br />
            <asp:Calendar ID="HiringDateCalendar" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px">
                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                <OtherMonthDayStyle ForeColor="#999999" />
                <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                <TodayDayStyle BackColor="#CCCCCC" />
            </asp:Calendar>
            <asp:Label ID="Label3" runat="server" Text="Дата рождения"></asp:Label><br />
            <asp:TextBox ID="DateOfBirth" runat="server"></asp:TextBox><br />
            <asp:Label ID="Label5" runat="server" Text="Телефон"></asp:Label><br />
            <asp:TextBox ID="PhoneNumberTextBox" runat="server"></asp:TextBox><br /><br />
            <asp:Button ID="Button1" runat="server" Text="Добавить" OnClick="Button1_Click" />
        </div>
        <div>
            <br /><br /><br />
            <asp:LinkButton ID="BackToDefaultLinkButton" runat="server" OnClick="BackToDefaultLinkButton_Click">Вернуться на главную</asp:LinkButton>
        </div>
    </form>
</body>
</html>
