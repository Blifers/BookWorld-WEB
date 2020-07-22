using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookWorld_WEB
{
    public partial class Goods : System.Web.UI.Page
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
            
            SqlConnection Connection = new SqlConnection("workstation id=BookWorldDataBase.mssql.somee.com;packet size=4096;user id=PaninI_SQLLogin_1;pwd=CegthGhfrnbrf1;data source=BookWorldDataBase.mssql.somee.com;persist security info=False;initial catalog=BookWorldDataBase");
            SqlParameter type = new SqlParameter("Тип_Товара", TypeDropDown.SelectedValue);
            SqlParameter title = new SqlParameter("Наименование", TitleTextBox.Text);
            SqlParameter price = new SqlParameter("Цена", PriceTextBox.Text);
            SqlParameter left = new SqlParameter("Остаток", LeftTextBox.Text);
            if (Convert.ToInt32(TypeDropDown.SelectedValue) != 1)
            {
                SqlCommand Command = new SqlCommand("INSERT INTO Товары ([Тип_Товара], [Наименование], [Цена], [Остаток]) VALUES (@Тип_Товара, @Наименование, @Цена, @Остаток)", Connection);
                Command.Parameters.Add(type);
                Command.Parameters.Add(title);
                Command.Parameters.Add(price);
                Command.Parameters.Add(left);
                Connection.Open();
                Command.ExecuteNonQuery();
                Connection.Close();
                Response.Redirect("Goods.aspx");
            }
            else
            {
                SqlCommand Command = new SqlCommand("INSERT INTO Товары ([Тип_Товара], [Жанр], [Наименование], [Цена], [Остаток]) VALUES (@Тип_Товара, @Жанр, @Наименование, @Цена, @Остаток)", Connection);
                SqlParameter genre = new SqlParameter("Жанр", GenreDropDown.SelectedValue);
                Command.Parameters.Add(type);
                Command.Parameters.Add(title);
                Command.Parameters.Add(price);
                Command.Parameters.Add(left);
                Command.Parameters.Add(genre);
                Connection.Open();
                Command.ExecuteNonQuery();
                Connection.Close();
                Response.Redirect("Goods.aspx");
            }
        }

        protected void XmlLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("XmlJsonForCatalogs.aspx?table=товары&isxml=true");
        }

        protected void JsonLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("XmlJsonForCatalogs.aspx?table=товары&isxml=false");
        }
        protected void AddWithJsonOrXmlLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddDataToCatalogs.aspx");
        }

        protected void ChangeWithJsonOrXmlLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangeDataInCatalogs.aspx?table=товары");
        }
    }
}