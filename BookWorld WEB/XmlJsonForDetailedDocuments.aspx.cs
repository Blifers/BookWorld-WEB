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
        private bool IsXml;
        private string CommandText="";
        protected void Page_Load(object sender, EventArgs e)
        {
            IsXml = Convert.ToBoolean(Request.QueryString["isxml"]);
            IsSell = Convert.ToBoolean(Request.QueryString["issell"]);
            Document = Convert.ToInt32(Request.QueryString["document"]);
            if (IsXml)
            {
                if (IsSell)
                {
                    if (Document == 0)
                        CommandText = "Select Продажа.Номер_Продажи,Продажа.Дата,Продажа.Номер_Карты,Продажа.Сумма_Продажи,Товар.Номер_Продажи,Товар.Код_Товара,Товар.Количество From Продажа inner join Состав_Продажи Товар ON Товар.Номер_Продажи=Продажа.Номер_Продажи for xml auto,ROOT('Продажи')";
                    else
                        CommandText = "Select Продажа.Номер_Продажи,Продажа.Дата,Продажа.Номер_Карты,Продажа.Сумма_Продажи,Товар.Номер_Продажи,Товар.Код_Товара,Товар.Количество From Продажа inner join Состав_Продажи Товар ON Товар.Номер_Продажи=Продажа.Номер_Продажи Where Продажа.Номер_Продажи=" + Document.ToString() + " for xml auto,ROOT('Продажи')";
                }
                else
                {
                    if (Document == 0)
                        CommandText = "Select Приход.Номер_Прихода,Приход.Дата,Приход.Комментарий,Товар.Номер_Прихода,Товар.Код_Товара,Товар.Количество From Приход inner join Состав_Прихода Товар ON Товар.Номер_Прихода=Приход.Номер_Прихода for xml auto, Root('Приходы')";
                    else
                        CommandText = "Select Приход.Номер_Прихода,Приход.Дата,Приход.Комментарий,Товар.Номер_Прихода,Товар.Код_Товара,Товар.Количество From Приход inner join Состав_Прихода Товар ON Товар.Номер_Прихода=Приход.Номер_Прихода Where Приход.Номер_Прихода=" + Document.ToString() + " for xml auto, Root('Приходы') ";
                }
            }
            else
            {
                if (IsSell)
                {
                    if (Document == 0)
                        CommandText = "Select Продажа.Номер_Продажи,Продажа.Дата,Продажа.Номер_Карты,Продажа.Сумма_Продажи,Товар.Номер_Продажи,Товар.Код_Товара,Товар.Количество From Продажа inner join Состав_Продажи Товар ON Товар.Номер_Продажи=Продажа.Номер_Продажи for json auto,ROOT('Продажи')";
                    else
                        CommandText = "Select Продажа.Номер_Продажи,Продажа.Дата,Продажа.Номер_Карты,Продажа.Сумма_Продажи,Товар.Номер_Продажи,Товар.Код_Товара,Товар.Количество From Продажа inner join Состав_Продажи Товар ON Товар.Номер_Продажи=Продажа.Номер_Продажи Where Продажа.Номер_Продажи=" + Document.ToString() + " for json auto,ROOT('Продажи')";
                }
                else
                {
                    if (Document == 0)
                        CommandText = "Select Приход.Номер_Прихода,Приход.Дата,Приход.Комментарий,Товар.Номер_Прихода,Товар.Код_Товара,Товар.Количество From Приход inner join Состав_Прихода Товар ON Товар.Номер_Прихода=Приход.Номер_Прихода for json auto, Root('Приходы')";
                    else
                        CommandText = "Select Приход.Номер_Прихода,Приход.Дата,Приход.Комментарий,Товар.Номер_Прихода,Товар.Код_Товара,Товар.Количество From Приход inner join Состав_Прихода Товар ON Товар.Номер_Прихода=Приход.Номер_Прихода Where Приход.Номер_Прихода=" + Document.ToString() + " for json auto, Root('Приходы') ";
                }
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