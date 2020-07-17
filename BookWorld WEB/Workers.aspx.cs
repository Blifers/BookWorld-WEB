using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookWorld_WEB
{
    public partial class Сотрудники : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BackToDefaultLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection Connection = new SqlConnection("workstation id=BookWorldDataBase.mssql.somee.com;packet size=4096;user id=PaninI_SQLLogin_1;pwd=CegthGhfrnbrf1;data source=BookWorldDataBase.mssql.somee.com;persist security info=False;initial catalog=BookWorldDataBase");
            SqlCommand Command = new SqlCommand("INSERT INTO [Сотрудники] ([ФИО], [Принят], [Дата_Рождения], [Телефон]) VALUES (@ФИО, @Принят, @Дата_Рождения, @Телефон)", Connection);
            SqlParameter fio = new SqlParameter("ФИО", FIOTextBox.Text);
            SqlParameter dateOfHiring = new SqlParameter("Принят", HiringDateCalendar.SelectedDate);
            SqlParameter dateOfBirth = new SqlParameter("Дата_Рождения", DateOfBirth.Text);
            SqlParameter phoneNumber = new SqlParameter("Телефон", PhoneNumberTextBox.Text);
            Command.Parameters.Add(fio);
            Command.Parameters.Add(dateOfHiring);
            Command.Parameters.Add(phoneNumber);
            Command.Parameters.Add(dateOfBirth);
            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();
            Response.Redirect("Workers.aspx");
        }

        protected void XmlLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("XmlJsonForCatalogs.aspx?table=сотрудники&isxml=true");
        }

        protected void JsonLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("XmlJsonForCatalogs.aspx?table=сотрудники&isxml=false");
        }
    }
}