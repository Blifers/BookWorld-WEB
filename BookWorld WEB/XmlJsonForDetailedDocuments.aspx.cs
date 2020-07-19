using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookWorld_WEB
{
    public partial class XmlJsonForDetailedDocuments : System.Web.UI.Page
    {
        private int Document;
        private bool IsSell;
        private string CommandText="";
        protected void Page_Load(object sender, EventArgs e)
        {
            IsSell = Convert.ToBoolean(Request.QueryString["issell"]);
            Document = Convert.ToInt32(Request.QueryString["document"]);

            if (IsSell)
            {
                if (Document == 0)
                    CommandText = "";
            }
            else
            {
                if (Document == 0)
                    CommandText = "Select Приход.Номер_Прихода,Приход.Дата,Приход.Комментарий,Товар.Номер_Прихода,Товар.Код_Товара,Товар.Количество From Приход inner join Состав_Прихода Товар ON Товар.Номер_Прихода=Приход.Номер_Прихода for xml auto, Root('Приходы')";
                else
                    CommandText = "Select Приход.Номер_Прихода,Приход.Дата,Приход.Комментарий,Товар.Номер_Прихода,Товар.Код_Товара,Товар.Количество From Приход inner join Состав_Прихода Товар ON Товар.Номер_Прихода=Приход.Номер_Прихода Where Приход.Номер_Прихода=" + Document.ToString()+"for xml auto, Root('Приходы') ";
            }
            SqlConnection Connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["BookWorldDataBaseConnectionString1"].ConnectionString);
            SqlCommand Command = new SqlCommand(CommandText, Connection);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            string text="";
            while (reader.Read())
                text += reader.GetString(0);
            Connection.Close();
            Response.Clear();
            Response.Write(text);
        }
        protected void BackToPreviousLinkButton_Click(object sender, EventArgs e)
        {
            if (IsSell)
                Response.Redirect("CheckSells.aspx");
            else
                Response.Redirect("CheckBuys.aspx");
        }
    }
}