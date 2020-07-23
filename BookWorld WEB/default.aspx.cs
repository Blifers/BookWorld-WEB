using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace BookWorld_WEB
{
    public partial class _default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GenresLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Genres.aspx");
        }

        protected void TypesLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Types.aspx");
        }

        protected void GoodsLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Goods.aspx");
        }

        protected void SellLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Sell.aspx");
        }

        protected void CustomersLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Customers.aspx");
        }

        protected void WorkersLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Workers.aspx");
        }

        protected void SellsLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("CheckSells.aspx");
        }

        protected void BuysLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("CheckBuys.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ToShowASMX.aspx?type=goodsXml");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("ToShowASMX.aspx?type=goodsJson");

        }

        protected void ASMXPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("Service.asmx");
        }
    }
}