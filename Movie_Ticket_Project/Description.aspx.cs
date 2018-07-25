using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Movie_Ticket_Project
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string image = Session["Image"].ToString();
            string title = Session["Title"].ToString();
            string genre = Session["Genre"].ToString();
            string director = Session["Director"].ToString();
            string cast1 = Session["Cast1"].ToString();
            string cast2 = Session["Cast2"].ToString();
            string cast3 = Session["Cast3"].ToString();
            string duration = Session["Duration"].ToString();
            string synopsis = Session["Synopsis"].ToString();
            string rating = Session["Rating"].ToString();
            string preference = Session["Preference"].ToString();

            this.title.InnerHtml = title;


            this.Image1.Visible = true;
            this.Image1.ImageUrl = $"/images/{image}.PNG";
            this.Image1.Width = 350;
            this.Image1.Height = 500;
            this.Image1.BorderStyle = BorderStyle.Solid;
            this.Image1.BorderColor = System.Drawing.Color.Red;

            this.synopsis.InnerText = synopsis;
            //this.synopsis.Style(font);

        }
    }
}