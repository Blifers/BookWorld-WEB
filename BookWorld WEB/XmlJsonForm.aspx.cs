﻿using System;
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
        private bool IsXML;
        private string CommandText;
        private bool cnt = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            TableName = Convert.ToString(Request.QueryString["table"]);
            IsXML = Convert.ToBoolean(Request.QueryString["isxml"]);


            switch (TableName)
            {
                case "товары":
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
                default:
                    Response.Clear();
                    Response.Write("Не переданы данные о таблице");
                    cnt = false;
                    break;
            }
            if (cnt)
            {
                var Connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["BookWorldDataBaseConnectionString1"].ConnectionString);
                Connection.Open();
                var Command = new SqlCommand(CommandText, Connection);
                var reader = Command.ExecuteReader();
                reader.Read();
                string text = reader.GetString(0);
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
                            normalForm += xml[i].Substring(lenghtOfWord, xml[i].Length - 2-lenghtOfWord);
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
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
                Response.Write(normalForm);
            }
        }
    }
}