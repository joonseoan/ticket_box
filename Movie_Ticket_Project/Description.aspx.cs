﻿using System;
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
            

            string image = Session["Image_Desc"].ToString();
            string title = Session["Title_Desc"].ToString();
            string genre = Session["Genre_Desc"].ToString();
            string director = Session["Director_Desc"].ToString();
            string cast1 = Session["Cast1_Desc"].ToString();
            string cast2 = Session["Cast2_Desc"].ToString();
            string cast3 = Session["Cast3_Desc"].ToString();
            string duration = Session["Duration_Desc"].ToString();
            string synopsis = Session["Synopsis_Desc"].ToString();
            string rating = Session["Rating_Desc"].ToString();
            string preference = Session["Preference_Desc"].ToString();

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

        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("service.aspx", true);
        }
    }
}