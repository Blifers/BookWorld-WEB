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
    public partial class ChangeDataInCatalogs : System.Web.UI.Page
    {
        private string BlankForGenresXmlDeleting = "<Жанры>\n\t<Жанр>\n\t\t<Код_Жанра>Выберите код жанра для удаления</Код_Жанра>\n\t</Жанр>\n</Жанры>";
        private string BlankForGenresXmlUpdating = "<Жанры>\n\t<Жанр>\n\t\t<Код_Жанра>Выберите код для изменения</Код_Жанра>\n\t\t<Наименование>Введите желаемое наименование</Наименование>\n\t</Жанр>\n</Жанры>";
        private string BlankForGenresJsonDeleting = @"[{""Код_Жанра"":""Выберите код жанра для удаления""}]";
        private string BlankForGenresJsonUpdating = @"[{""Код_Жанра"":""Выберите код жанра для изменения"",""Наименование"":""Введите желаемое наименование""}]";

        private string BlankForGoodsXmlUpdating = "<Товары>\n\t<Товар>\n\t\t<Код_Товара>Введите код товара сюда</Код_Товара>\n\t\t<Тип_Товара>Введите данные сюда</Тип_Товара>\n\t\t<Жанр>Удалите тег если тип товара не равно 1</Жанр>\n\t\t<Наименование>Введите данные сюда</Наименование>\n\t\t<Цена>Введите данные сюда</Цена>\n\t\t<Остаток>Введите данные сюда</Остаток>\n\t</Товар>\n</Товары>";
        private string BlankForGoodsXmlDeleting = "<Товары><Товар><Код_Товара>Введите сюда код товара</Код_Товара></Товар></Товары>";
        private string BlankForGoodsJsonUpdating = "[{\"Код_Товара\":\"Выберите код товара для изменения\",\"Тип_Товара\":\"Введите данные сюда\",\"Жанр\":\"Удалите этот элемент, если тип товара не равен 1\",\"Наименование\":\"Введите данные сюда\",\"Цена\":\"Введите данные сюда\",\"Остаток\":\"Введите данные сюда\"}]";
        private string BlankForGoodsJsonDeleting = @"[{""Код_Товара"":""Выберите код товара для удаления""}]";


        private string TableName;
        private string CommandText = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            TableName = Convert.ToString(Request.QueryString["table"]);
            switch (TableName)
            {
                case "жанры":
                    CommandText = "Select * From Жанры";
                    break;
                case "типы":
                    CommandText = "Select * From Тип_Товара";
                    break;
                case "товары":
                    CommandText = "Select * From Товары";
                    break;
                default:
                    break;
            }

            SqlConnection Connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["BookWorldDataBaseConnectionString1"].ConnectionString);
            SqlCommand Command = new SqlCommand(CommandText, Connection);
            Connection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(Command);
            adapter.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void BackToDefault_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }

        protected void ClearButton_Click(object sender, EventArgs e)
        {
            TextBox.Text = "";
            TextBox.Focus();
        }

        protected void XmlDeleteButton_Click(object sender, EventArgs e)
        {
            Label1.Text = "false";
            switch (TableName)
            {
                case "жанры":
                    TextBox.Text = BlankForGenresXmlDeleting;
                    break;
                case "товары":
                    TextBox.Text = BlankForGoodsXmlDeleting;
                    break;
                default:
                    break;
            }
        }

        protected void XmlChangeButton_Click(object sender, EventArgs e)
        {
            Label1.Text = "true";
            switch (TableName)
            {
                case "жанры":
                    TextBox.Text = BlankForGenresXmlUpdating;
                    break;
                case "товары":
                    TextBox.Text = BlankForGoodsXmlUpdating;
                    break;
                default:
                    break;
            }
        }

        protected void JsonDeleteButton_Click(object sender, EventArgs e)
        {
            Label1.Text = "false";
            switch (TableName)
            {
                case "жанры":
                    TextBox.Text = BlankForGenresJsonDeleting;
                    break;
                case "товары":
                    TextBox.Text = BlankForGoodsJsonDeleting;
                    break;
                default:
                    break;
            }
        }

        protected void JsonChangeButton_Click(object sender, EventArgs e)
        {
            Label1.Text = "true";
            switch (TableName)
            {
                case "жанры":
                    TextBox.Text = BlankForGenresJsonUpdating;
                    break;
                case "товары":
                    TextBox.Text = BlankForGoodsJsonUpdating;
                    break;
                default:
                    break;
            }
        }

        protected void ExecButton_Click(object sender, EventArgs e)
        {
            SqlConnection Connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["BookWorldDataBaseConnectionString1"].ConnectionString);
            SqlCommand Command = new SqlCommand();
            Command.Connection = Connection;
            string CommandText = "";
            Response.Write(Label1.Text);
            if (TextBox.Text[0] == '<')
            {
                CommandText = "declare @XmlDocument as xml\ndeclare @nx as int \nset @XmlDocument = N'" + TextBox.Text + "'\nExec sp_xml_preparedocument @nx OUTPUT,@XmlDocument\n";
                if (Label1.Text == "true")
                {
                    switch (TableName)
                    {
                        case "жанры":
                            CommandText += "Update Жанры\nSET Наименование=(Select Наименование FROM OPENXML(@nx,'/Жанры/Жанр',2) with (Наименование nvarchar(40)))\nWhere Код_Жанра=(Select Код_Жанра FROM OPENXML(@nx,'/Жанры/Жанр',2) with(Код_Жанра int))\nExec sp_xml_removedocument @nx";
                            break;
                        case "товары":
                            CommandText += "Update Товары\nSET Тип_Товара=(Select Тип_Товара FROM OPENXML(@nx,'/Товары/Товар',2) with (Тип_Товара int)),Жанр=(Select Жанр FROM OPENXML(@nx,'/Товары/Товар',2) with (Жанр int)),Наименование=(Select Наименование FROM OPENXML(@nx,'/Товары/Товар',2) with (Наименование nvarchar(80))),Цена=(Select Цена FROM OPENXML(@nx,'/Товары/Товар',2) with (Цена money)),Остаток=(Select Остаток FROM OPENXML(@nx,'/Товары/Товар',2) with (Остаток int)) where Код_Товара=(Select Код_Товара FROM OPENXML(@nx,'/Товары/Товар',2) with (Код_Товара int))\nExec sp_xml_removedocument @nx";
                            break;
                        default:
                            break;
                    }
                }
                else if (Label1.Text == "false")
                {
                    switch (TableName)
                    {
                        case "жанры":
                            CommandText += "Delete FROM Жанры\nWhere Код_Жанра = (Select Код_Жанра FROM OPENXML(@nx,'/Жанры/Жанр',2) with (Код_Жанра int))\nExec sp_xml_removedocument @nx";
                            break;
                        case "товары":
                            CommandText += "Delete FROM Товары \nWhere Код_Товара=(Select Код_Товара FROM OPENXML(@nx,'/Товары/Товар',2) with (Код_Товара int))\nExec sp_xml_removedocument @nx";
                            break;
                        default:
                            break;
                    }
                }
            }
            else if (TextBox.Text[0] == '[')
            {
                CommandText = "declare @j as nvarchar(max)\nset @j=N'" + TextBox.Text + "'";
                if (Label1.Text == "true")
                {
                    switch (TableName)
                    {
                        case "жанры":
                            CommandText += "Update Жанры\nSET Наименование=(Select Наименование from OPENJSON(@j) with (Наименование nvarchar(40)))\nWhere Код_Жанра=(Select Код_Жанра from OPENJSON(@j) with(Код_Жанра int))";
                            break;
                        case "товары":
                            CommandText += "Update Товары\nSET Тип_Товара=(Select Тип_Товара FROM OPENJSON(@j) with (Тип_Товара int)),Жанр=(Select Жанр FROM OPENJSON(@j) with (Жанр int)),Наименование=(Select Наименование FROM OPENJSON(@j) with (Наименование nvarchar(80))),Цена=(Select Цена FROM OPENJSON(@j) with (Цена money)),Остаток=(Select Остаток FROM OPENJSON(@j) with (Остаток int)) where Код_Товара=(Select Код_Товара FROM OPENJSON(@j) with (Код_Товара int))";
                            break;
                        default:
                            break;
                    }
                }
                else if (Label1.Text == "false")
                {
                    switch (TableName)
                    {
                        case "жанры":
                            CommandText += "Delete FROM Жанры\nWhere Код_Жанра=(Select Код_Жанра from OPENJSON(@j) with (Код_Жанра int))";
                            break;
                        case "товары":
                            CommandText += "Delete FROM Товары\nWhere Код_Товара=(Select Код_Товара FROM OPENJSON(@j) with (Код_Товара int))";
                            break;
                        default:
                            break;
                    }
                }
            }
            //Response.Write(CommandText);
            Command.CommandText = CommandText;
            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            Response.Redirect(url);
        }
    }
}