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
        private string BlankForAddingXML = "<Приходы>\n\t<Приход Дата=\"гггг-мм-дд\" Комментарий=\"Введите комментарий\">\n\t\t<Товар Код_Товара = \"Введите код товара\" Количество=\"Введите количество товара\"/>\n\t</Приход>\n</Приходы>";
        private string BlankForAddingJSON = "{\"Приходы\":{\n\"Дата\":\"гггг-мм-дд\",\"Комментарий\":\"Введите комментарий\",\"Товар\":[\n\t{\"Код_Товара\":Введите код товара,\"Количество\":Введите количество товара}\n]}}";


        protected void Page_Load(object sender, EventArgs e)
        {
            string CommandText = "Select * From Приход";
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
            string CommandText = "Select * From Состав_Прихода Where Номер_Прихода="+GridView1.SelectedRow.Cells[1].Text;
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
            string CommandText = "";
            SqlConnection Connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["BookWorldDataBaseConnectionString1"].ConnectionString);
            SqlCommand Command = new SqlCommand();
            Command.Connection = Connection;

            if (TextBox1.Text[0] == '<')
            {
                string headerText = "declare @XmlDocument as xml\ndeclare @nx as int\nSet @XmlDocument = N'" + TextBox1.Text + "'\nExec sp_xml_preparedocument @nx OUTPUT, @XmlDocument\n";
                CommandText = headerText;
                if (Label1.Text == "adding")
                {
                    CommandText += "INSERT INTO Приход Select * from OPENXML(@nx,'/Приходы/Приход',3) with (Дата date,Комментарий nvarchar(300))\nExec sp_xml_removedocument @nx";
                    Command.CommandText = CommandText;
                    Connection.Open();
                    Command.ExecuteNonQuery();
                    string GetLastOneAdded = "select top 1 Номер_Прихода from Приход order by Номер_Прихода desc";
                    Command.CommandText = GetLastOneAdded;
                    var reader = Command.ExecuteReader();
                    reader.Read();
                    int NumberOfDoc = reader.GetInt32(0);
                    reader.Close();
                    string find = "<Товар";
                    int startWith=0;
                    while (startWith!=-1)
                    {
                        startWith = TextBox1.Text.IndexOf(find, startWith + find.Length);
                        if (startWith!=-1)
                            TextBox1.Text = TextBox1.Text.Insert(startWith + find.Length, @" Номер_Прихода=""" + NumberOfDoc + @"""");
                    }


                    CommandText = "declare @XmlDocument as xml\ndeclare @nx as int\nSet @XmlDocument = N'" + TextBox1.Text + "'\nExec sp_xml_preparedocument @nx OUTPUT, @XmlDocument\n";
                    CommandText += "Insert Into Состав_Прихода Select * From OPENXML(@nx,'/Приходы/Приход/Товар',3) with (Номер_Прихода int,Код_Товара int,Количество int)\nExec sp_xml_removedocument @nx";
                    Command.CommandText = CommandText;
                    Command.ExecuteNonQuery();
                    Connection.Close();
                    Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri);
                }




            }
            else if (TextBox1.Text[0] == '{')
            {
                string headerText = "declare @json as nvarchar(max)\nset @json=N'" + TextBox1.Text + "'\n";
                CommandText = headerText;
                if (Label1.Text == "adding")
                {
                    CommandText += "Insert into Приход Select * from OPENJSON(@json) with (Дата date N'$.\"Приходы\".\"Дата\"',Комментарий nvarchar(300) N'$.\"Приходы\".\"Комментарий\"')";
                    Command.CommandText = CommandText;
                    Connection.Open();
                    Command.ExecuteNonQuery();
                    string GetLastOneAdded = "select top 1 Номер_Прихода from Приход order by Номер_Прихода desc";
                    Command.CommandText = GetLastOneAdded;
                    var reader = Command.ExecuteReader();
                    reader.Read();
                    int NumberOfDoc = reader.GetInt32(0);
                    reader.Close();
                    int startWith = 0;
                    string find = ":[";
                    int lastPoint = TextBox1.Text.IndexOf(']');
                    startWith = TextBox1.Text.IndexOf(find, startWith + find.Length) + 4;
                    TextBox1.Text = TextBox1.Text.Insert(startWith + find.Length, "\"Номер_Прихода\":" + NumberOfDoc + ", ");
                    find = "{";
                    while (startWith < lastPoint && startWith != -1)
                    {
                        startWith = TextBox1.Text.IndexOf(find, startWith + find.Length + 10);
                        if (startWith != -1)
                            TextBox1.Text = TextBox1.Text.Insert(startWith + find.Length, "\"Номер_Прихода\":" + NumberOfDoc + ", ");
                    }
                    CommandText = "DECLARE @json NVARCHAR(MAX)=N'" + TextBox1.Text + "'\n";
                    CommandText += "INSERT INTO Состав_Прихода SELECT * FROM OPENJSON(@json, N'$.\"Приходы\".\"Товар\"') with (Номер_Прихода int,Код_Товара int,Количество int)";
                    Command.CommandText = CommandText;
                    Command.ExecuteNonQuery();
                    Connection.Close();
                    Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri);
                }
            }
            
        }

        protected void BlankForAddingButton_Click(object sender, EventArgs e)
        {
            Label1.Text = "adding";
            TextBox1.Text = BlankForAddingXML;
        }

        protected void BlankForAddingButtonJson_Click(object sender, EventArgs e)
        {
            Label1.Text = "adding";
            TextBox1.Text = BlankForAddingJSON;
        }
    }
}