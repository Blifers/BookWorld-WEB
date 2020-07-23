using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.IO;
using System.Xml.Serialization;
using System.Text;

namespace BookWorld_WEB
{
    /// <summary>
    /// Сводное описание для Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class Service : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat=ResponseFormat.Json)]
        public void ПолучитьСправочникТоварыJSON()
        {
            Context.Response.ContentEncoding = Encoding.UTF8;
            //Context.Response.ContentType = "text/plain";
            Context.Response.Write(getGoods());
        }

        private string getGoods()
        {
            SqlConnection Connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["BookWorldDataBaseConnectionString1"].ConnectionString);
            SqlCommand Command = new SqlCommand("Select * From Товары",Connection);
            Connection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(Command);
            adapter.Fill(dt);

            string myResponse = JsonConvert.SerializeObject(dt);

            return myResponse;
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
        public void ПолучитьСправочникТоварыXML()
        {
            Context.Response.ContentEncoding = Encoding.UTF8;
            //Context.Response.ContentType = "text/plain";
            Context.Response.Write(getGoodsXml());
        }

        private string getGoodsXml()
        {
            SqlConnection Connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["BookWorldDataBaseConnectionString1"].ConnectionString);
            SqlCommand Command = new SqlCommand("Select * From Товары", Connection);
            Connection.Open();
            DataTable dt = new DataTable();
            dt.TableName = "Товары";
            SqlDataAdapter adapter = new SqlDataAdapter(Command);
            adapter.Fill(dt);

            string myReturn = string.Empty;
            using (var memoryStream = new MemoryStream()) 
            {
                using (TextWriter streamWriter = new StreamWriter(memoryStream))
                {
                    var xmlSerializer = new XmlSerializer(typeof(DataTable));
                    xmlSerializer.Serialize(streamWriter, dt);
                    myReturn = Encoding.UTF8.GetString(memoryStream.ToArray()); 
                }
            }
            return myReturn;
        }
    }
}
