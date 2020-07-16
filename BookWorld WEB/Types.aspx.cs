using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookWorld_WEB
{
    public partial class Types : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BackToDefaultLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            if (TitleTextBox.Text != "" && TitleTextBox.Text != " ")
            {
                SqlConnection Connection = new SqlConnection("workstation id=BookWorldDataBase.mssql.somee.com;packet size=4096;user id=PaninI_SQLLogin_1;pwd=CegthGhfrnbrf1;data source=BookWorldDataBase.mssql.somee.com;persist security info=False;initial catalog=BookWorldDataBase");

                SqlCommand Command = new SqlCommand("INSERT INTO Тип_Товара VALUES (@Наименование)", Connection);
                SqlParameter p1 = new SqlParameter("Наименование", TitleTextBox.Text);
                Command.Parameters.Add(p1);
                Connection.Open();
                Command.ExecuteNonQuery();
                Connection.Close();
                Response.Redirect("Types.aspx");
            }
            else
            {
                Response.Write("<script>alert('Введите данные в текстовое поле');</script>");
                TitleTextBox.Focus();
            }
        }
    }
}