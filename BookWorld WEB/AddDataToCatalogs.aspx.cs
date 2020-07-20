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
    public partial class AddDataToCatalogs : System.Web.UI.Page
    {
        private string XmlBlanketForGenres = "<Жанры>\n<Жанр>\n<Наименование>Не изменяйте общую структуру документа</Наименование>\n</Жанр>\n</Жанры>";
        private string JsonBlanketForGenres = @"[{""Наименование"":""Введите данные сюда""}]";



        private string XmlBlanketForTypes = "<Типы>\n<Тип>\n<Наименование>Не изменяйте общую структуру документа</Наименование>\n</Тип>\n</Типы>";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void XmlAddButton_Click(object sender, EventArgs e)
        {
            TextBox.Text = "";
            switch (DropDownList1.SelectedValue)
            {
                case "Жанры":
                    TextBox.Text = XmlBlanketForGenres;
                    break;
                case "Тип товара":
                    TextBox.Text = XmlBlanketForTypes;
                    break;
                default:
                    TextBox.Text = "Такого бланка пока в системе нет";
                    break;
            }
            TextBox.Focus();
        }

        protected void ExecButton_Click(object sender, EventArgs e)
        {
            SqlConnection Connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["BookWorldDataBaseConnectionString1"].ConnectionString);
            SqlCommand Command = new SqlCommand();
            Command.Connection = Connection;
            string CommandText = "";
            if (TextBox.Text[0] == '<')
            {
                CommandText = "declare @XmlDocument as xml\ndeclare @nx as int \nset @XmlDocument = N'" + TextBox.Text + "'\nExec sp_xml_preparedocument @nx OUTPUT,@XmlDocument\n";
                string[] toParse = TextBox.Text.Split('<');
                string table = toParse[1].Substring(0, toParse[1].Length - 1);
                switch (table)
                {
                    case "Жанры":
                        CommandText += "INSERT INTO Жанры Select * FROM OPENXML(@nx,'/Жанры/Жанр',2) With (Наименование nvarchar(40))\nExec sp_xml_removedocument @nx";
                        break;
                    case "Типы":
                        CommandText += "INSERT INTO Тип_Товара Select * FROM OPENXML(@nx,'/Типы/Тип',2) With (Наименование nvarchar(40))\nExec sp_xml_removedocument @nx";
                        break;
                    default:
                        break;
                }
            }
            else if (TextBox.Text[0] == '[')
            {
                CommandText = "declare @json as nvarchar(max)\nset @json=N'" + TextBox.Text + "'";
                switch (DropDownList1.SelectedValue)
                {
                    case "Жанры":
                        CommandText += "INSERT INTO Жанры Select * from OPENJSON(@json) With (Наименование nvarchar(40))";
                        break;
                    default:
                        break;
                }
            }
            Command.CommandText = CommandText;
            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();
            TextBox.Text = "";
            Response.Write("<script>alert('Успешно добавлены данные')</script>");
            TextBox.Focus();
            //Response.Write();
        }

        protected void ClearButton_Click(object sender, EventArgs e)
        {
            TextBox.Text = "";
            TextBox.Focus();
        }

        protected void JsonAddButton_Click(object sender, EventArgs e)
        {
            TextBox.Text = "";
            switch (DropDownList1.SelectedValue)
            {
                case "Жанры":
                    TextBox.Text = JsonBlanketForGenres;
                    break;
                case "Тип товара":
                    TextBox.Text ="";
                    break;
                default:
                    TextBox.Text = "Такого бланка пока в системе нет";
                    break;
            }
            TextBox.Focus();
        }

        protected void BackToDefault_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }
    }
}