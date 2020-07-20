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
        private string XMLBlanketForGenres = "<Жанры>\n<Жанр>\n<Наименование>Не изменяйте общую структуру документа</Наименование>\n</Жанр>\n</Жанры>";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void XmlAddButton_Click(object sender, EventArgs e)
        {
            TextBox.Text = "";
            switch (DropDownList1.SelectedValue)
            {
                case "Жанры":
                    TextBox.Text = XMLBlanketForGenres;
                    break;
                default:
                    break;
            }
            TextBox.Focus();
        }

        protected void ExecButton_Click(object sender, EventArgs e)
        {
            SqlConnection Connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["BookWorldDataBaseConnectionString1"].ConnectionString);
            SqlCommand Command = new SqlCommand();
            Command.Connection = Connection;
            string CommandText = "declare @XmlDocument as xml\ndeclare @nx as int \nset @XmlDocument = N'" + TextBox.Text + "'\nExec sp_xml_preparedocument @nx OUTPUT,@XmlDocument\n";
            string [] toParse = TextBox.Text.Split('<');
            string table = toParse[1].Substring(0, toParse[1].Length - 1);
            switch (table)
            {
                case "Жанры":
                    CommandText += "INSERT INTO Жанры Select * FROM OPENXML(@nx,'/Жанры/Жанр',2) With (Наименование nvarchar(40))\nExec sp_xml_removedocument @nx";
                    break;
                default:
                    break;
            }

            Command.CommandText = CommandText;
            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();
            Response.Write(TextBox.Text);
        }


//        declare @XmlDocument as xml
//declare @nx as int
//set @XmlDocument = N'<Жанры><Жанр><Наименование>Постмодернизм</Наименование></Жанр>
//<Жанр><Наименование>Деловая литература</Наименование></Жанр></Жанры>'
//Exec sp_xml_preparedocument @nx OUTPUT, @XmlDocument
//INSERT INTO Жанры Select* from OPENXML(@nx,'/Жанры/Жанр',2) With(Наименование nvarchar(40))
//Exec sp_xml_removedocument @nx
    }
}