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
    public partial class XmlJsonForDocuments : System.Web.UI.Page
    {
        private bool IsXml;
        private bool IsSell;
        private int Document;
        private bool IsHeader;
        private string CommandText="";
        private string NormalForm = "";
        private string Title = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            IsXml = Convert.ToBoolean(Request.QueryString["isxml"]);
            IsSell = Convert.ToBoolean(Request.QueryString["issell"]);
            IsHeader = Convert.ToBoolean(Request.QueryString["isheader"]);
            Document = Convert.ToInt32(Request.QueryString["document"]);

            SqlConnection Connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["BookWorldDataBaseConnectionString1"].ConnectionString);

            //logic
            //Продажа
            if (IsSell)
            {
                if (IsHeader)//Шапка
                {
                    if (Document == 0)//Все шапки
                    {
                        Title = "Все шапки документа 'Продажа'";
                        CommandText = "Select * from Продажа";
                    }
                    else//Конкретная шапка
                    {
                        Title = "Шапка документа 'Продажа' с номером - " + Document.ToString();
                        CommandText = "Select * from Продажа Where Номер_Продажи=" + Document.ToString();
                    }
                }
                else//Табличные части
                {
                    if (Document == 0)//Все табличные части
                    {
                        Title = "Все табличные части документа 'Продажа'";
                        CommandText = "Select * from Состав_Продажи";
                    }
                    else//Конкретная табличная часть
                    {
                        Title = "Табличная часть документа 'Продажа' с номером - " + Document.ToString();
                        CommandText = "Select * from Состав_Продажи Where Номер_Продажи=" + Document.ToString();
                    }
                }
            }
            //Приход
            else
            {
                if (IsHeader)//Шапка
                {
                    if (Document == 0)//Все шапки
                    {
                        Title = "Все шапки документа 'Приход'";
                        CommandText = "Select * From Приход";
                    }
                    else//Конкретная шапка
                    {
                        Title = "Шапка документа 'Приход' с номером - " + Document.ToString();
                        CommandText = "Select * from Приход Where Номер_Прихода=" + Document.ToString();
                    }
                }
                else//Табличные части
                {
                    if (Document == 0)//Все табличные части
                    { 
                        Title = "Все табличные части документа 'Приход'";
                        CommandText = "Select * From Состав_Прихода";
                    }
                    else//Конкретная табличная часть
                    {
                        Title = "Табличная часть документа 'Приход' с номером - " + Document.ToString();
                        CommandText = "Select * from Состав_Прихода Where Номер_Прихода=" + Document.ToString();
                    }
                }
            }
            Connection.Open();
            if (IsXml)
                CommandText += " for XML AUTO";
            else
                CommandText += " for JSON AUTO";
            SqlCommand Command = new SqlCommand(CommandText, Connection);
            var reader = Command.ExecuteReader();
            NormalForm += "<h2>" + Title + "</h2><br/>";
            ShowFile(reader);
            Connection.Close();
        }
        
        private void ShowFile(SqlDataReader reader)
        {
            reader.Read();
            string text;
            text = reader[0].ToString();
            if (IsXml)
                ShowXml(text);
            else
                ShowJson(text);
        }
        private void ShowXml(string text)
        {

            string[] xml = text.Split('<');
            string[] withSpaces = xml[1].Split(' ');
            int lenghtOfWord = withSpaces[0].Length;
            for (int i = 1; i < xml.Length; i++)
            {
                NormalForm += "<p>";
                NormalForm += xml[i].Substring(lenghtOfWord, xml[i].Length - 2 - lenghtOfWord);
                NormalForm += " </p>";
            }
            Response.Clear();
            Response.Write(NormalForm);
        }

        private void ShowJson(string text)
        {
            string[] json = text.Split('{');
            for (int i = 1; i < json.Length; i++)
            {
                NormalForm += "<p>";
                NormalForm += json[i].Substring(0, json[i].Length - 2);
                NormalForm += "</p>";
            }
            Response.Clear();
            Response.Write(NormalForm);
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