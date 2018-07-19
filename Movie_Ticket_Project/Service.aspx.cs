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
        
        protected void Page_Load(object sender, EventArgs e)
        {

            string favGenre = Session["Genre"].ToString();
            string favDirector = Session["Director"].ToString();
            string favCast = Session["Cast"].ToString();

            List<string> favMovies = new List<string>();

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
                    if (favGenre == row["genre"].ToString().Trim() &&
                        (favCast == row["cast1"].ToString().Trim() ||
                         favCast == row["cast2"].ToString().Trim() ||
                         favCast == row["cast3"].ToString().Trim()) &&
                        favDirector == row["director"].ToString().Trim())
                    {

                        favMovies.Add(row["title"].ToString() + "_cdg");

                    }
                    
                    if ((favCast == row["cast1"].ToString().Trim() ||
                         favCast == row["cast2"].ToString().Trim() ||
                         favCast == row["cast3"].ToString().Trim()) &&
                        favDirector == row["director"].ToString().Trim())
                    {

                        if(favMovies.Count != 0)
                        {
                            for (int i=0; i < favMovies.Count; i++)
                            {
                                /*
                                string [] movie = favMovies[i].Split('_');

                                if(movie[0] != row["title"].ToString())
                                {
                                    favMovies.Add(row["title"].ToString() + "_cd");
                                }
                                else
                                {

                                    favMovies.Add(favMovies[i] + "_cd");
                                    
                                }*/
                            }
                        }
                        else
                        {

                            favMovies.Add(row["title"].ToString() + "_cd");

                        }
                        

                    }

                    if ((favCast == row["cast1"].ToString().Trim() ||
                         favCast == row["cast2"].ToString().Trim() ||
                         favCast == row["cast3"].ToString().Trim()) &&
                        favGenre == row["genre"].ToString().Trim())
                    {

                        favMovies.Add(row["title"].ToString() + "_cg");

                    }
                    
                    if (favDirector == row["director"].ToString().Trim() &&
                        favGenre == row["genre"].ToString().Trim())
                    {

                        favMovies.Add(row["title"].ToString() + "_dg");

                    }
                    

                    if (favCast == row["cast1"].ToString().Trim() ||
                        favCast == row["cast2"].ToString().Trim() ||
                        favCast == row["cast3"].ToString().Trim())
                    {

                        favMovies.Add(row["title"].ToString() + "_c");

                    }

                    if (favDirector == row["Director"].ToString().Trim())
                    {

                        favMovies.Add(row["title"].ToString() + "_d");

                    }
                    
                    if (favGenre == row["genre"].ToString().Trim())
                    {

                        favMovies.Add(row["title"].ToString() + "_g");

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

            foreach (string movie  in favMovies)
            {

                Response.Write(movie + ", ");

            }

            // Response.Write(favCast + favDirector + favGenre);

        }

    }

}