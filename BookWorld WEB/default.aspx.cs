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
    }
}