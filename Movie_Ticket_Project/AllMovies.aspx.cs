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
    public partial class WebForm6 : System.Web.UI.Page
    {
        // Dictionary<string, string> recommended_title_images = new Dictionary<string, string>();

        SqlConnection cnn;
        SqlDataAdapter dap;
        System.Data.DataSet ds;
        string queryString;

        List<ImageButton> img = new List<ImageButton>();

        List<string[]> movie_elements = new List<string[]>();

        string[] movie_contents = new string[11];

        int custAge;
       
        // title only
        protected string deleteColone(string title)
        {

            int index = 0;
            // string title_only;

            foreach (char c in title)
            {

                if (c == ':')
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
        /*
        protected string getBackToPureName(string image_name)
        {

            string pureTileName = image_name.Replace("_", " ");

            return pureTileName;

        }*/

        protected bool validateRating(string rating)
        {

            //Response.Write(custAge + ", ");
            // Response.Write(rating + ", ");
            bool validation = true;

            string trimRating = rating.Trim();

            if (custAge == 17)
            {
                if (trimRating == "R" || trimRating == "18A" || trimRating == "A")
                {

                    validation = false;

                }

            }
            else if (custAge == 13)
            {

                if (trimRating == "R" || trimRating == "18A" || trimRating == "A" || trimRating == "14A")
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

            // Response.Write(rating + ": " + validation + ",       ");

            return validation;

        }

        // xxxxxx_cdg
        protected void addTitles(string[] movie)
        {

            img.Add(new ImageButton());

            //{ movie[1], "dd" }
            movie_elements.Add(new string[] { getImageName(movie[1]), movie[1], movie[2], movie[3], movie[4], movie[5], movie[6], movie[7], movie[8], movie[9], movie[10] });

        }

        /*
        protected void showMovieList()
        {

            string connectionString = "Data Source=LAPTOP-EO2QHHSQ\\SQLEXPRESS;Initial Catalog=TicketEasy;Integrated Security=SSPI;Persist Security Info=False";
            cnn = new SqlConnection(connectionString);
            queryString = "Select * from MOVIES";

            dap = new SqlDataAdapter(queryString, cnn);
            ds = new DataSet();
            dap.Fill(ds, "Movies");

            try
            {
                cnn.Open();

                foreach (DataRow row in ds.Tables["Movies"].Rows)
                {

                    movie_contents[0] = "image";
                    movie_contents[1] = row["title"].ToString().Trim();
                    movie_contents[2] = row["genre"].ToString().Trim();
                    movie_contents[3] = row["director"].ToString().Trim();
                    movie_contents[4] = row["cast1"].ToString().Trim();
                    movie_contents[5] = row["cast2"].ToString().Trim();
                    movie_contents[6] = row["cast3"].ToString().Trim();
                    movie_contents[7] = row["duration"].ToString().Trim();
                    movie_contents[8] = row["synopsis"].ToString().Trim();
                    movie_contents[9] = row["grade"].ToString().Trim();
                    movie_contents[10] = "preference";

                    if ((favCast == movie_contents[4] || favCast == movie_contents[5] || favCast == movie_contents[6]) &&
                        favDirector == movie_contents[3] && favGenre == movie_contents[2])
                    {

                        if (custAge < 18)
                        {

                            if (validateRating(movie_contents[9]))
                            {

                                movie_contents[10] = "cdg";
                                addTitles(movie_contents);

                            }

                        }
                        else
                        {

                            movie_contents[10] = "cdg";
                            addTitles(movie_contents);

                        }

                    }

                    else if ((favCast == movie_contents[4] || favCast == movie_contents[5] || favCast == movie_contents[6]) &&
                        favDirector == movie_contents[3])
                    {

                        if (custAge < 18)
                        {

                            if (validateRating(movie_contents[9]))
                            {

                                //addTitles(row["title"].ToString() + "_cd");
                                movie_contents[10] = "cd";
                                addTitles(movie_contents);


                            }

                        }
                        else
                        {

                            movie_contents[10] = "cd";
                            addTitles(movie_contents);

                        }

                    }
                    else if ((favCast == movie_contents[4] || favCast == movie_contents[5] || favCast == movie_contents[6]) &&
                             favGenre == movie_contents[2])
                    {

                        if (custAge < 18)
                        {

                            if (validateRating(movie_contents[9]))
                            {

                                movie_contents[10] = "cg";
                                addTitles(movie_contents);

                            }

                        }
                        else
                        {

                            movie_contents[10] = "cg";
                            addTitles(movie_contents);

                        }

                    }
                    else if (favDirector == movie_contents[3] && favGenre == movie_contents[2])
                    {

                        if (custAge < 18)
                        {
                            if (validateRating(movie_contents[9]))
                            {

                                movie_contents[10] = "dg";
                                addTitles(movie_contents);

                            }

                        }
                        else
                        {

                            movie_contents[10] = "dg";
                            addTitles(movie_contents);

                        }

                    }

                    else if (favCast == movie_contents[4] || favCast == movie_contents[5] || favCast == movie_contents[6])
                    {

                        if (custAge < 18)
                        {
                            if (validateRating(movie_contents[9]))
                            {

                                movie_contents[10] = "c";
                                addTitles(movie_contents);

                            }

                        }
                        else
                        {

                            movie_contents[10] = "c";
                            addTitles(movie_contents);

                        }

                    }
                    else if (favDirector == movie_contents[3])
                    {

                        if (custAge < 18)
                        {
                            if (validateRating(movie_contents[9]))
                            {

                                movie_contents[10] = "d";
                                addTitles(movie_contents);

                            }

                        }
                        else
                        {

                            movie_contents[10] = "d";
                            addTitles(movie_contents);

                        }

                    }

                    else if (favGenre == movie_contents[2])
                    {

                        if (custAge < 18)
                        {
                            if (validateRating(movie_contents[9]))
                            {

                                movie_contents[10] = "g";
                                addTitles(movie_contents);

                            }

                        }
                        else
                        {

                            movie_contents[10] = "g";
                            addTitles(movie_contents);

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

        }
        */
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            custAge = Convert.ToInt32(Session["Age"]);


            string connectionString = "Data Source=LAPTOP-EO2QHHSQ\\SQLEXPRESS;Initial Catalog=TicketEasy;Integrated Security=SSPI;Persist Security Info=False";
            cnn = new SqlConnection(connectionString);
            queryString = "Select * from MOVIES";

            dap = new SqlDataAdapter(queryString, cnn);
            ds = new DataSet();
            dap.Fill(ds, "Movies");

            try
            {
                cnn.Open();

                foreach (DataRow row in ds.Tables["Movies"].Rows)
                {

                    movie_contents[0] = "image";
                    movie_contents[1] = row["title"].ToString().Trim();
                    movie_contents[2] = row["genre"].ToString().Trim();
                    movie_contents[3] = row["director"].ToString().Trim();
                    movie_contents[4] = row["cast1"].ToString().Trim();
                    movie_contents[5] = row["cast2"].ToString().Trim();
                    movie_contents[6] = row["cast3"].ToString().Trim();
                    movie_contents[7] = row["duration"].ToString().Trim();
                    movie_contents[8] = row["synopsis"].ToString().Trim();
                    movie_contents[9] = row["grade"].ToString().Trim();
                    movie_contents[10] = "preference";

                    if (custAge < 18)
                    {

                        if (validateRating(movie_contents[9]))
                        {

                            movie_contents[10] = "cdg";
                            addTitles(movie_contents);

                        }

                    }
                    else
                    {

                        movie_contents[10] = "cdg";
                        addTitles(movie_contents);

                    }

                }

                if (img.Count != 0)
                {

                    int count = 0;

                    TableRow rows1 = new TableRow();
                    TableRow rows2 = new TableRow();

                    foreach (ImageButton movie in img)
                    {

                        movie.ID = movie_elements[count][0];
                        movie.ImageUrl = $"/images/{getImageName(movie_elements[count][0])}.PNG";
                        //movie.PostBackUrl = "service.aspx";// $"/images/{getImageName(movie_elements[count][0])}.PNG";
                        movie.Visible = true;
                        movie.Click += new ImageClickEventHandler(ImageButton1_Click);
                        movie.Attributes["image"] = movie_elements[count][0];
                        movie.Attributes["title"] = movie_elements[count][1];
                        movie.Attributes["genre"] = movie_elements[count][2];
                        movie.Attributes["director"] = movie_elements[count][3];
                        movie.Attributes["cast1"] = movie_elements[count][4];
                        movie.Attributes["cast2"] = movie_elements[count][5];
                        movie.Attributes["cast3"] = movie_elements[count][6];
                        movie.Attributes["duration"] = movie_elements[count][7];
                        movie.Attributes["synopsis"] = movie_elements[count][8];
                        movie.Attributes["rating"] = movie_elements[count][9];
                        movie.Attributes["preference"] = movie_elements[count][10];
                        movie.AlternateText = movie_elements[count][0];
                        movie.Width = 200;
                        movie.Height = 300;
                        movie.BorderStyle = BorderStyle.Solid;
                        movie.BorderColor = System.Drawing.Color.Red; // BorderStyle("", "") //AttributeCollection .Solid")    ("red");

                        if (count % 4 == 0)
                        {
                            rows1 = new TableRow();
                            rows2 = new TableRow();
                        }

                        TableCell cell1 = new TableCell();
                        TableCell cell2 = new TableCell();
                        rows1.HorizontalAlign = HorizontalAlign.Center;
                        rows2.HorizontalAlign = HorizontalAlign.Center;

                        // cell1.Text = movie_elements[count][10];
                        cell2.Controls.Add(movie);

                        cell2.Width = 300;
                        cell2.Height = 350;

                        rows1.Cells.Add(cell1);
                        rows2.Cells.Add(cell2);

                        this.Table1.Rows.Add(rows1);
                        this.Table1.Rows.Add(rows2);

                        count++;

                    }

                }
                else
                {

                    Response.Write("Sorry we do not have your movies");

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
            //}

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {


            //{
            Session["Image"] = ((ImageButton)sender).Attributes["image"];
            Session["Title"] = ((ImageButton)sender).Attributes["title"];
            Session["Genre"] = ((ImageButton)sender).Attributes["genre"];
            Session["Director"] = ((ImageButton)sender).Attributes["director"];
            Session["Cast1"] = ((ImageButton)sender).Attributes["cast1"];
            Session["Cast2"] = ((ImageButton)sender).Attributes["cast2"];
            Session["Cast3"] = ((ImageButton)sender).Attributes["cast3"];
            Session["Duration"] = ((ImageButton)sender).Attributes["duration"];
            Session["Synopsis"] = ((ImageButton)sender).Attributes["synopsis"];
            Session["Rating"] = ((ImageButton)sender).Attributes["rating"];
            Session["Preference"] = ((ImageButton)sender).Attributes["preference"];

            /*
            Response.Write(sender.ToString());
            Response.Write(e.ToString());
            Response.Write("|" + Session["Image"] + "|");
            Response.Write("|" + Session["Title"] + "|");
            Response.Write("|" + Session["Genre"] + "|");
            Response.Write("|" + Session["Cast1"] + "|");
            Response.Write("|" + Session["Cast2"] + "|");
            Response.Write("|" + Session["Cast3"] + "|");
            Response.Write("|" + Session["Duration"] + "|");
            Response.Write("|" + Session["Synopsis"] + "|");
            Response.Write("|" + Session["Rating"] + "|");
            Response.Write("|" + Session["Preference"] + "|");
            */

            Response.Redirect("Description.aspx");

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Service.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("AllMovies.aspx");
        }
    }
}