<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddChangeBuys.aspx.cs" Inherits="BookWorld_WEB.AddChangeBuys" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="True" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
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
            <br />
            <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
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
            <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
            <br />
            <asp:Button ID="BlankForAddingButton" runat="server" Text="Добавить заготовку для добавления документа" OnClick="BlankForAddingButton_Click" />
            <br />
            <br />
            <asp:TextBox ID="TextBox1" runat="server" Height="150px" Width="750px" TextMode="MultiLine"></asp:TextBox>

            <br />
            <asp:Button ID="ClearButton" runat="server" Text="Очистить" OnClick="ClearButton_Click" />
            <br /><br />
            <asp:Button ID="SubmitButton" runat="server" Text="Отправить" OnClick="SubmitButton_Click" />

        </div>

        <div>
            <br /><br /><br />
            <asp:LinkButton ID="BackToDefaultButton" runat="server" OnClick="BackToDefaultButton_Click">Вернуться на главную</asp:LinkButton>
        </div>
    </form>
</body>
</html>
