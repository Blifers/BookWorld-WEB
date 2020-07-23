using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookWorld_WEB
{
    public partial class ToShowASMX : System.Web.UI.Page
    {
        ServiceReference1.ServiceSoapClient client = new ServiceReference1.ServiceSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            string text = string.Empty;
            string Command = Request.QueryString[0];
            switch (Command)
            {
                case "goodsXml":
                    text = client.ПолучитьСправочникТоварыJSON();
                    Response.Clear();
                    Response.Write(text);
                    break;
                case "goodsJson":
                    text = client.ПолучитьСправочникТоварыXML();
                    Response.Clear();
                    Response.Write(text);
                    break;
                case "genresXml":
                    text = client.ПолучитьСправочникЖанрыXML();
                    Response.Clear();
                    Response.Write(text);
                    break;
                case "genresJson":
                    text = client.ПолучитьСправочникЖанрыJSON(); 
                    Response.Clear();
                    Response.Write(text);
                    break;
                case "typesXml":
                    text = client.ПолучитьСправочникТипТовараXML();
                    Response.Clear();
                    Response.Write(text);
                    break;
                case "typesJson":
                    text = client.ПолучитьСправочникТипТовараJSON();
                    Response.Clear();
                    Response.Write(text);
                    break;
                case "workersXml":
                    text = client.ПолучитьСправочникСотрудникиXML();
                    Response.Clear();
                    Response.Write(text);
                    break;
                case "workersJson":
                    text = client.ПолучитьСправочникСотрудникиJSON();
                    Response.Clear();
                    Response.Write(text);
                    break;
                case "customersXml":
                    text = client.ПолучитьСправочникПостоянныеКлиентыXML();
                    Response.Clear();
                    Response.Write(text);
                    break;
                case "customersJson":
                    text = client.ПолучитьСправочникПостоянныеКлиентыJSON();
                    Response.Clear();
                    Response.Write(text);
                    break;
                case "buysXml":
                    text = client.ПолучитьДокументПриходXml();
                    Response.Clear();
                    Response.Write(text);
                    break;
                case "buysJson":
                    text = client.ПолучитьДокументПриходJson();
                    Response.Clear();
                    Response.Write(text);
                    break;
            }


        }
    }
}