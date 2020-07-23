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
        //Чтобы добавить выберите ConnectedServices->добавить ссылку на на службу и вставляете вашу службу
        //Отсюда можем получать методы
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
            }


        }
    }
}