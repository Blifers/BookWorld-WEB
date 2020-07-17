using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookWorld_WEB
{
    public partial class Постоянные_клиенты : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            SqlConnection Connection = new SqlConnection("workstation id=BookWorldDataBase.mssql.somee.com;packet size=4096;user id=PaninI_SQLLogin_1;pwd=CegthGhfrnbrf1;data source=BookWorldDataBase.mssql.somee.com;persist security info=False;initial catalog=BookWorldDataBase");
            SqlCommand Command = new SqlCommand("INSERT INTO Постоянные_Клиенты (ФИО, Дата_Вручения, Телефон) VALUES (@ФИО, @Дата_Вручения, @Телефон)", Connection);
            SqlParameter fio = new SqlParameter("ФИО", FIOTextBox.Text);
            SqlParameter dateOfGetting = new SqlParameter("Дата_Вручения", Calendar1.SelectedDate);
            SqlParameter phoneNumber = new SqlParameter("Телефон", PhoneNumberTextBox.Text);
            Command.Parameters.Add(fio);
            Command.Parameters.Add(dateOfGetting);
            Command.Parameters.Add(phoneNumber);
            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();
            Response.Redirect("Customers.aspx");
        }

        protected void BackToDefaultLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }
        protected void XmlLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("XmlJsonForCatalogs.aspx?table=клиенты&isxml=true");
        }

        protected void JsonLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("XmlJsonForCatalogs.aspx?table=клиенты&isxml=false");
        }
    }
}