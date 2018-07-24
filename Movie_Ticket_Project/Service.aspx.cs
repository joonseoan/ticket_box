using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Movie_Ticket_Project
{
    public partial class WebForm4 : System.Web.UI.Page
    {

        // Dictionary<string, string> recommended_title_images = new Dictionary<string, string>();

        List<ImageButton> img = new List<ImageButton>();

        List<String> recommended_title_images = new List<String>();

        string favGenre;
        string favDirector;
        string favCast;
        int custAge;


        protected string[] splitTitle(string processed_title)
        {

            string[] basic_title = processed_title.Split('_');

            return basic_title;

        }

        // title only
        protected string deleteColone(string title)
        {

            int index = 0;
            // string title_only;

            foreach (char c in title)
            {
                if(c == ':')
                {
                    index = title.IndexOf(':');
                }

            }

            string title_only = index != 0 ? title.Substring(0, index) : title;

            return title_only;

        }

        // image title
        protected string getImageName(string title)
        {

            string no_colone = deleteColone(title);  
           
            string image_title = no_colone.Replace(" ", "_");

            return image_title;

        }

        protected string getBackToPureName(string image_name)
        {
            
            string pureTileName = image_name.Replace("_", " ");

            return pureTileName;

        } 

        protected bool validateRating(string rating)
        {

            //Response.Write(custAge + ", ");
            // Response.Write(rating + ", ");
            bool validation = true;

            string trimRating = rating.Trim();
            
            if(custAge == 17)
            {
                if(trimRating == "R" || trimRating == "18A" || trimRating == "A")
                {

                    validation = false;

                }

            }
            else if(custAge == 13)
            {

                if (trimRating == "R" || trimRating == "18A" || trimRating == "A" || trimRating == "14A" )
                {

                    validation = false;

                }

            }
            else if (custAge == 7)
            {

                if (trimRating == "R" || trimRating == "18A" || trimRating == "A" || trimRating == "14A" || trimRating == "PG")
                {

                    validation = false;

                }

            }

            Response.Write(rating + ": " + validation + ",       ");

            return validation;

        }
        // xxxxxx_cdg
        protected void addTitles(string title)
        {

            string title_database = title.Trim();

            // xxxx and cdg
            string [] title_name = splitTitle(title_database);

            string image_title = getImageName(title_name[0]);

            img.Add(new ImageButton());
            
            //recommended_title_images.Add(image_title, title_name[1]);
            recommended_title_images.Add(image_title);

        }

       protected void Page_Load(object sender, EventArgs e)
       {

           favGenre = Session["Genre"].ToString();
           favDirector = Session["Director"].ToString();
           favCast = Session["Cast"].ToString();
           custAge = Convert.ToInt32(Session["Age"]);


           SqlConnection cnn;
           SqlDataAdapter dap;
           System.Data.DataSet ds;
           string queryString;

           string connectionString = "Data Source=LAPTOP-EO2QHHSQ\\SQLEXPRESS;Initial Catalog=TicketEasy;Integrated Security=SSPI;Persist Security Info=False";
           cnn = new SqlConnection(connectionString);
           queryString = "Select * from MOVIES";

           try
           {
               cnn.Open();

               dap = new SqlDataAdapter(queryString, cnn);
               ds = new DataSet();
               dap.Fill(ds, "Movies");

               foreach (DataRow row in ds.Tables["Movies"].Rows)
               {

                   // when customer's favorite genre, cast, and directors
                   //      are equal to data  --> Filter
                   if ((favCast == row["cast1"].ToString().Trim() ||
                        favCast == row["cast2"].ToString().Trim() ||
                        favCast == row["cast3"].ToString().Trim()) &&
                       favGenre == row["genre"].ToString().Trim() &&
                       favDirector == row["director"].ToString().Trim())
                   {
                        
                        if(custAge < 18)
                        {
                            if(validateRating(row["grade"].ToString())) {

                                addTitles(row["title"].ToString() + "_cdg");

                            }
                        }
                        else
                        {

                            addTitles(row["title"].ToString() + "_cdg");

                        }

                    }

                   else if ((favCast == row["cast1"].ToString().Trim() ||
                       favCast == row["cast2"].ToString().Trim() ||
                       favCast == row["cast3"].ToString().Trim()) &&
                       favDirector == row["director"].ToString().Trim())
                   {

                        if (custAge < 18)
                        {
                            if (validateRating(row["grade"].ToString()))
                            {

                                addTitles(row["title"].ToString() + "_cd");

                            }
                        }
                        else
                        {

                            addTitles(row["title"].ToString() + "_cd");

                        }

                    }
                   else if ((favCast == row["cast1"].ToString().Trim() ||
                   favCast == row["cast2"].ToString().Trim() ||
                   favCast == row["cast3"].ToString().Trim()) &&
                   favGenre == row["genre"].ToString().Trim())
                   {

                        if (custAge < 18)
                        {
                            if (validateRating(row["grade"].ToString()))
                            {

                                addTitles(row["title"].ToString() + "_cg");

                            }
                        }
                        else
                        {

                            addTitles(row["title"].ToString() + "_cg");

                        }

                   }

                   else if (favDirector == row["director"].ToString().Trim() &&
                    favGenre == row["genre"].ToString().Trim())
                   {

                        if (custAge < 18)
                        {
                            if (validateRating(row["grade"].ToString()))
                            {

                                addTitles(row["title"].ToString() + "_dg");

                            }
                            
                        }
                        else
                        {

                            addTitles(row["title"].ToString() + "_dg");

                        }

                    }

                   else if (favCast == row["cast1"].ToString().Trim() ||
                    favCast == row["cast2"].ToString().Trim() ||
                    favCast == row["cast3"].ToString().Trim())
                    {

                        if (custAge < 18)
                        {
                            if (validateRating(row["grade"].ToString()))
                            {

                                addTitles(row["title"].ToString() + "_c");

                            }   

                        }
                        else
                        {

                            addTitles(row["title"].ToString() + "_c");

                        }

                   }
                   else if (favDirector == row["Director"].ToString().Trim())
                   {

                        if (custAge < 18)
                        {
                            if (validateRating(row["grade"].ToString()))
                            {

                                addTitles(row["title"].ToString() + "_d");

                            }

                        }
                        else
                        {

                            addTitles(row["title"].ToString() + "_d");

                        }

                    }

                   else if (favGenre == row["genre"].ToString().Trim())
                   {

                        if (custAge < 18)
                        {
                            if (validateRating(row["grade"].ToString()))
                            {

                                addTitles(row["title"].ToString() + "_g");

                            }

                        }
                        else
                        {

                            addTitles(row["title"].ToString() + "_g");

                        }

                    }

               } 

            }
            catch (SqlException ex)
            {

                Response.Write(ex.Message);

            }
            finally
            {

                if (cnn.State == ConnectionState.Open)
                {

                    cnn.Close();

                }

            }

            //Button btn = new Button();

            if (img.Count != 0)
            {
                int count = 0;
                foreach(ImageButton movie in img)
                {

                    movie.ID = movie.ToString() + count.ToString(); //recommended_title_images[count];
                    movie.ImageUrl = $"/images/{recommended_title_images[count]}.PNG";
                    //movie.NavigateUrl = "Description.aspx";
                    movie.Visible = true;
                    movie.Click += new ImageClickEventHandler(ImageButton1_Click);
                    movie.Width = 200;
                    movie.Height = 300;
                    // movie.Text = recommended_title_images[count];
                    //movie.Target = "targetTest";
                    this.Controls.Add(movie);

                    //img1.ID = "ImageButton1";
                    //img1.ImageUrl = $"/images/{recommended_title_images[2]}.PNG";
                    //img1.Click += new ImageClickEventHandler(ImageButton1_Click);
                    //Panel1.Controls.Add(img1);


                    // btn.Visible = true;

                    // this.Controls.Add(btn);



                    count++;

                }



            }
            else
            {

                Response.Write("Sorry we do not have your movies");

            }

            //this.DynamicHyperLink1.DataField ="dd"


            /*
            foreach(KeyValuePair <string, string> movie in recommended_title_images)
            {
                // ImageButton  = new ImageButton;
                //Response.Write(recommended_title_images[movie] + ", ");
                this.ImageButton1.ImageUrl = $"/images/{movie.Key}.PNG";

                if(movie.Value == "cdg")
                {

                    this.Label1.Text = $"Perfect Movie that is identifed with your favorite cast {favCast}" +
                        $", director, {favDirector}, genre, {favGenre.ToLower()}";

                }
                else if (movie.Value == "cd")
                {

                    this.Label1.Text = $"Picked for you because you love {favCast} " +
                        $"and  director, {favDirector}";

                }
                else if (movie.Value == "cg")
                {

                    this.Label1.Text = $"Picked for you because you love {favCast} " +
                        $"and  this genre, {favGenre.ToLower()}";

                }
                else if (movie.Value == "dg")
                {

                    this.Label1.Text = $"Picked for you because you like a director{favDirector} " +
                        $"and  this genre, {favGenre.ToLower()}";

                }
                else if (movie.Value == "c")
                {

                    this.Label1.Text = $"You love {favCast}, right?";

                }

                else if (movie.Value == "d")
                {

                    this.Label1.Text = $"You expect {favDirector}'s movie, right?";

                }
                else
                {

                    this.Label1.Text = $"You like this {favGenre.ToLower()}  movie, right?";

                }

            }

            */

            /*
            if(recommended_title_images.Count != 0)
            {
                this.ImageButton1.ImageUrl = $"/images/{recommended_title_images[0]}.PNG";
                this.ImageButton2.ImageUrl = $"/images/{recommended_title_images[1]}.PNG";
                this.ImageButton3.ImageUrl = $"/images/{recommended_title_images[2]}.PNG";
                this.ImageButton4.ImageUrl = $"/images/{recommended_title_images[3]}.PNG";
                this.ImageButton5.ImageUrl = $"/images/{recommended_title_images[4]}.PNG";
                //this.ImageButton6.ImageUrl = $"/images/{recommended_title_images[5]}.PNG";

            }
            else
            {
                Response.Write("No movies");
            }
            */


            // Image Image2 = new Image();
            // Image2.AlternateText = "test";
            // Image2.Visible = true;
            // Image2.ImageUrl = $"/images/{recommended_title_images[4]}.PNG";
            // this.Controls.Add(Image2);

            /*
             
             Image myImg = new Image();
myImg.ImageUrl = "path_of_the_image.jpg";
myImg.Visible = true;
Panel1.Controls.Add(myImg);   //You can attach the image to any control on your page
Or similarly:

this.Controls.Add(myImg);     //Incase you wanted the image on your page controls
Label1.Controls.Add(myImg);   //Incase you wanted the image to appear in a certain label
             
             */


            //ImageMapEventHandler ie = new ImageMapEventHandler().; 


            // = test_imageMap;

            //  ImageButton ImageButton = new ImageButton();
            //ImageButton.Visible = true;
            //ImageButton.ImageUrl = $"/images/{recommended_title_images[3]}.PNG";

            // ImageMap.HotSpotMode = HotSpotMode.PostBack;
            // ImageButton.Click = new ImageEventHandler(test_imageMap);
            // this.Controls.Add(ImageButton);


            // this.HyperLink1.ImageUrl = $"/images/{recommended_title_images[3]}.PNG"; 
            // this.HyperLink1.wi
            //   $"/images/{recommended_title_images[count]}.PNG"

            //this.Button1.Style["background-image"] = $"url(/images/{recommended_title_images[2]}.PNG)";

            // Button btn = new Button();
            // btn.Visible = true;
            //this.Controls.Add(btn);
            // testSpace.Style["background-image"] = "url(images/foo.png)";


            //ImageButton img1 = new ImageButton();
            //img1.ID = "ImageButton1";
            //img1.ImageUrl = $"/images/{recommended_title_images[2]}.PNG";
            //img1.Click += new ImageClickEventHandler(ImageButton1_Click);
            //Panel1.Controls.Add(img1);
        }
        //background-image:url('Image/1.png')
        //public void targetTest(string imageName)
        //{
          //  Response.("ddd");
        //}

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Write(e.ToString());
            Response.Write(sender.ToString());
                // ClientScript.RegisterStartupScript(this.GetType(), "ImageButton_Alert", "alert('ImageButton clicked!');", true);
        }

    }

}