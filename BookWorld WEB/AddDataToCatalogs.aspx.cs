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
        private string XmlBlanketForGenres = "<Жанры>\n\t<Жанр>\n\t<Наименование>Не изменяйте общую структуру документа</Наименование>\n\t</Жанр>\n</Жанры>";
        private string JsonBlanketForGenres = @"[{""Наименование"":""Введите данные сюда""}]";
        private string XmlBlanketForTypes = "<Типы>\n\t<Тип>\n\t\t<Наименование>Не изменяйте общую структуру документа</Наименование>\n\t\t</Тип>\n</Типы>";
        private string JsonBlanketForTypes = @"[{""Наименование"":""Введите данные сюда""}]";
        private string XmlBlanketForGoods = "<Товары>\n\t<Товар>\n\t\t<Тип_Товара>Введите данные сюда</Тип_Товара>\n\t\t<Жанр>Удалите эту строчку, если тип товара не равен 1</Жанр>\n\t\t<Наименование>Введите данные сюда</Наименование>\n\t\t<Цена>Введите данные сюда</Цена>\n\t\t<Остаток>Введите данные сюда</Остаток>\n\t</Товар>\n</Товары>";
        private string JsonBlanketForGoods = "[{\"Тип_Товара\":\"Введите данные сюда\",\"Жанр\":\"Удалите этот элемент, если тип товара не равен 1\",\"Наименование\":\"Введите данные сюда\",\"Цена\":\"Введите данные сюда\",\"Остаток\":\"Введите данные сюда\"}]";

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
                case "Товары":
                    TextBox.Text = XmlBlanketForGoods;
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
                CommandText = "declare @XmlDocument as xml\ndeclare @nx as int\nset @XmlDocument = N'";
                CommandText += @"" + @TextBox.Text;
                CommandText += "'\nExec sp_xml_preparedocument @nx OUTPUT,@XmlDocument\n";
                switch (DropDownList1.SelectedValue)
                {
                    case "Жанры":
                        CommandText += "INSERT INTO Жанры Select * FROM OPENXML(@nx,'/Жанры/Жанр',2) With (Наименование nvarchar(40))\nExec sp_xml_removedocument @nx";
                        break;
                    case "Тип товара":
                        CommandText += "INSERT INTO Тип_Товара Select * FROM OPENXML(@nx,'/Типы/Тип',2) With (Наименование nvarchar(40))\nExec sp_xml_removedocument @nx";
                        break;
                    case "Товары":
                        CommandText += "INSERT INTO Товары SELECT * FROM OPENXML(@nx,'/Товары/Товар',2) With (Тип_Товара int,Жанр int,Наименование nvarchar(80),Цена money,Остаток int)\nExec sp_xml_removedocument @nx";
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
                    case "Тип товара":
                        CommandText += "INSERT INTO Тип_Товара Select * from OPENJSON(@json) With (Наименование nvarchar(40))";
                        break;
                    case "Товары":
                        CommandText+= "INSERT INTO Товары SELECT * from OPENJSON(@json) With (Тип_Товара int,Жанр int,Наименование nvarchar(80),Цена money,Остаток int)";
                        break;
                    default:
                        break;
                }
            }
            Command.CommandText = CommandText;
            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();
            Response.Write("<script>alert('Успешно добавлены данные')</script>");
            TextBox.Text = "";       
            TextBox.Focus();
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
                    TextBox.Text =JsonBlanketForTypes;
                    break;
                case "Товары":
                    TextBox.Text = JsonBlanketForGoods;
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