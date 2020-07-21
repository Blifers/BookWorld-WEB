using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookWorld_WEB
{
    public partial class AddChangeBuys : Page
    {
        private string BlankForAddingXML= "<Приходы><Приход Дата=""2020-07-20/" Комментарий="Получили товар от нового поставщика BookWit"><Товар Код_Товара = "3" Количество="2"/><Товар Код_Товара = "4" Количество="1"/></Приход></Приходы>"


        protected void Page_Load(object sender, EventArgs e)
        {
            string CommandText = "Select * From Продажа";
            SqlConnection Connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["BookWorldDataBaseConnectionString1"].ConnectionString);
            SqlCommand Command = new SqlCommand(CommandText, Connection);
            Connection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(Command);
            adapter.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string CommandText = "Select * From Состав_Продажи Where Номер_Продажи="+GridView1.SelectedRow.Cells[1].Text;
            SqlConnection Connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["BookWorldDataBaseConnectionString1"].ConnectionString);
            SqlCommand Command = new SqlCommand(CommandText, Connection);
            Connection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(Command);
            adapter.Fill(dt);
            GridView2.DataSource = dt;
            GridView2.DataBind();
        }

        protected void BackToDefaultButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }

        protected void ClearButton_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {

        }

        protected void BlankForAddingButton_Click(object sender, EventArgs e)
        {
            Label1.Text = "adding";
        }
    }
}