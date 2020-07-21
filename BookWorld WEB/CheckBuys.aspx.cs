using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookWorld_WEB
{
    public partial class CheckBuys : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BackToDefaultLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }

        protected void HeadsInXML_Click(object sender, EventArgs e)
        {
            Response.Redirect("XmlJsonForDocuments.aspx?isxml=true&isheader=true&document=0&issell=false");
        }

        protected void HeadsInJSON_Click(object sender, EventArgs e)
        {
            Response.Redirect("XmlJsonForDocuments.aspx?isxml=false&isheader=true&document=0&issell=false");
        }

        protected void HeadInXML_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("XmlJsonForDocuments.aspx?isxml=true&isheader=true&document=" + GridView1.SelectedRow.Cells[1].Text + "&issell=false");
            }
            catch
            {
                Response.Write("<script>alert('Выберите документ')</script>");
            }
        }

        protected void HeadInJSON_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("XmlJsonForDocuments.aspx?isxml=false&isheader=true&document=" + GridView1.SelectedRow.Cells[1].Text + "&issell=false");
            }
            catch
            {
                Response.Write("<script>alert('Выберите документ')</script>");
            }
        }

        protected void DocsInXML_Click(object sender, EventArgs e)
        {
            Response.Redirect("XmlJsonForDocuments.aspx?isxml=true&isheader=false&document=0&issell=false");
        }

        protected void DocsInJSON_Click(object sender, EventArgs e)
        {
            Response.Redirect("XmlJsonForDocuments.aspx?isxml=false&isheader=false&document=0&issell=false");
        }

        protected void DocInXML_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("XmlJsonForDocuments.aspx?isxml=true&isheader=false&document=" + GridView1.SelectedRow.Cells[1].Text + "&issell=false");
            }
            catch
            {
                Response.Write("<script>alert('Выберите документ')</script>");
            }
        }

        protected void DocInJSON_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("XmlJsonForDocuments.aspx?isxml=false&isheader=false&document=" + GridView1.SelectedRow.Cells[1].Text + "&issell=false");
            }
            catch
            {
                Response.Write("<script>alert('Выберите документ')</script>");
            }
        }

        protected void DetailedBuysXML_Click(object sender, EventArgs e)
        {
            Response.Redirect("XmlJsonForDetailedDocuments.aspx?isxml=true&issell=false&document=0");
        }

        protected void DetailedBuyDocumentXML_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("XmlJsonForDetailedDocuments.aspx?isxml=true&issell=false&document=" + GridView1.SelectedRow.Cells[1].Text);
            }
            catch
            {
                Response.Write("<script>alert('Выберите документ')</script>");
            }
        }

        protected void DetailedBuysJSON_Click(object sender, EventArgs e)
        {
            Response.Redirect("XmlJsonForDetailedDocuments.aspx?isxml=false&issell=false&document=0");
        }

        protected void DetailedBuyDocumentJSON_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("XmlJsonForDetailedDocuments.aspx?isxml=false&issell=false&document=" + GridView1.SelectedRow.Cells[1].Text);
            }
            catch
            {
                Response.Write("<script>alert('Выберите документ')</script>");
            }
        }

        protected void AddChangeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddChangeBuys.aspx");
        }
    }
}