using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookWorld_WEB
{
    public partial class XmlJsonForm : System.Web.UI.Page
    {
        private string TableName;
        private string SelStringForGoods = "Select * From Товары ";
        private string SelStringForGenres = "Select * from Жанры ";
        private string SelStringForTypes = "Select * from Тип_Товара ";
        private string SelStringForCustomers = "Select * from Постоянные_Клиенты ";
        private string SelStringForWorkers = "Select * from Сотрудники ";

        private bool IsXML;
        private string CommandText;
        private bool cnt = true;

        private int Type = 0;

        private string ComText;
        protected void BackToPreviousLinkButton_Click(object sender, EventArgs e)
        {
            switch (TableName)
            {
                case "товары":
                    Response.Redirect("Goods.aspx");
                    break;
                case "жанры":
                    Response.Redirect("Genres.aspx");
                    break;
                case "тип":
                    Response.Redirect("Types.aspx");
                    break;
                case "сотрудники":
                    Response.Redirect("Workers.aspx");
                    break;
                case "клиенты":
                    Response.Redirect("Customers.aspx");
                    break;
                default:
                    Response.Redirect("default.aspx");
                    break;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            TypeDropDownList.Visible = false;
            EnterButton.Visible = false;
            DropButton.Visible = false;
            TableName = Convert.ToString(Request.QueryString["table"]);
            IsXML = Convert.ToBoolean(Request.QueryString["isxml"]);
            Type = Convert.ToInt32(Request.QueryString["type"]);



            switch (TableName)
            {
                case "товары":
                    TypeDropDownList.Visible = true;
                    EnterButton.Visible = true;
                    DropButton.Visible = true;
                    if (IsXML)
                        CommandText = SelStringForGoods + "for XML AUTO";
                    else
                        CommandText = SelStringForGoods + "for JSON AUTO";
                    break;
                case "жанры":
                    if (IsXML)
                        CommandText = SelStringForGenres + "for XML AUTO";
                    else
                        CommandText = SelStringForGenres + "for JSON AUTO";
                    break;
                case "тип":
                    if (IsXML)
                        CommandText = SelStringForTypes + "for XML AUTO";
                    else
                        CommandText = SelStringForTypes + "for JSON AUTO";
                    break;
                case "сотрудники":
                    if (IsXML)
                        CommandText = SelStringForWorkers + "for XML AUTO";
                    else
                        CommandText = SelStringForWorkers + "for JSON AUTO";
                    break;
                case "клиенты":
                    if (IsXML)
                        CommandText = SelStringForCustomers + "for XML AUTO";
                    else
                        CommandText = SelStringForCustomers + "for JSON AUTO";
                    break;
                default:
                    Response.Clear();
                    Response.Write("Не переданы данные о таблице");
                    cnt = false;
                    break;
            }
            if (cnt)
            {
                if(IsXML)
                    ComText = "Select * from Товары WHERE Тип_Товара="+Type+" for XML AUTO";
                else
                    ComText = "Select * from Товары WHERE Тип_Товара="+Type+" for JSON AUTO";
                if (Type != 0)
                {  
                    var Connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["BookWorldDataBaseConnectionString1"].ConnectionString);
                    Connection.Open();
                    var Command = new SqlCommand(ComText, Connection);
                    Response.Write(ComText);
                    var reader = Command.ExecuteReader();
                    string text = "";
                    while (reader.Read())
                    {
                        text += reader[0].ToString();
                    }
                    string normalForm = "<h1>" + TableName.ToUpper() + "</h1><br/>";
                    Response.Clear();
                    try
                    {
                        if (IsXML)
                        {
                            string[] xml = text.Split('<');
                            string[] withSpaces = xml[1].Split(' ');
                            int lenghtOfWord = withSpaces[0].Length;
                            for (int i = 1; i < xml.Length; i++)
                            {
                                normalForm += "<p>";
                                normalForm += xml[i].Substring(lenghtOfWord, xml[i].Length - 2 - lenghtOfWord);
                                normalForm += " </p>";
                            }
                        }
                        else
                        {
                            string[] json = text.Split('{');
                            for (int i = 1; i < json.Length; i++)
                            {
                                normalForm += "<p>";
                                normalForm += json[i].Substring(0, json[i].Length - 2);
                                normalForm += "</p>";
                            }
                        }
                        Connection.Close();
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);
                    }
                    Response.Write(normalForm);
                }
                else
                {
                    var Connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["BookWorldDataBaseConnectionString1"].ConnectionString);
                    Connection.Open();
                    var Command = new SqlCommand(CommandText, Connection);
                    var reader = Command.ExecuteReader();
                    string text="";
                    while (reader.Read())
                    {
                        text += reader[0].ToString();
                    }
                    string normalForm = "<h1>" + TableName.ToUpper() + "</h1><br/>";
                    Response.Clear();
                    try
                    {
                        if (IsXML)
                        {
                            string[] xml = text.Split('<');
                            string[] withSpaces = xml[1].Split(' ');
                            int lenghtOfWord = withSpaces[0].Length;
                            for (int i = 1; i < xml.Length; i++)
                            {
                                normalForm += "<p>";
                                normalForm += xml[i].Substring(lenghtOfWord, xml[i].Length - 2 - lenghtOfWord);
                                normalForm += " </p>";
                            }
                        }
                        else
                        {
                            string[] json = text.Split('{');
                            for (int i = 1; i < json.Length; i++)
                            {
                                normalForm += "<p>";
                                normalForm += json[i].Substring(0, json[i].Length - 2);
                                normalForm += "</p>";
                            }
                        }
                        Connection.Close();
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);
                    }
                    Response.Write(normalForm);
                }
            }
        }

        protected void EnterButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("XmlJsonForCatalogs.aspx?table="+TableName+"&isxml=" + IsXML.ToString() + "&type=" + TypeDropDownList.SelectedValue);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("XmlJsonForCatalogs.aspx?table=" + TableName + "&isxml=" + IsXML.ToString() + "&type=0"); 
        }
    }
}