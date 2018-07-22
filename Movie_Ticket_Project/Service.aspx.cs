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

        List<String> favMovies = new List<String>();

        protected string splitTitle(string processed_title)
        {

            string[] basic_title = processed_title.Split('_');

            return basic_title[0];

        }

        protected void addTitles(string title)
        {

            
            string title_database = title.Trim();

            favMovies.Add(title_database);

            // Response.Write(title_database + ", ");

            /* 

           if (favMovies.Count > 0)
           {



              foreach(String str in favMovies.ToArray())
              //for(int i = 0;  favMovies.Count < i ; i++)
               // foreach (String c in favMovies)
               {

                   //Response.Write(str + ", ");

                   if (!favMovies.Contains(splitTitle(title_database)))
                   {
                       Response.Write("working?????????");
                       favMovies.Add(title_database);

                   }

               }

           }
           else
           {

               favMovies.Add(title_database);

           }*/


        }

       protected void Page_Load(object sender, EventArgs e)
       {

           string favGenre = Session["Genre"].ToString();
           string favDirector = Session["Director"].ToString();
           string favCast = Session["Cast"].ToString();

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

                        addTitles(row["title"].ToString() + "_cdg");
                        //  favMovies.Add(row["title"].ToString() + "_cdg");

                   }

                   else if ((favCast == row["cast1"].ToString().Trim() ||
                       favCast == row["cast2"].ToString().Trim() ||
                       favCast == row["cast3"].ToString().Trim()) &&
                       favDirector == row["director"].ToString().Trim())
                   {

                        addTitles(row["title"].ToString() + "_cd");

                   }


                   else if ((favCast == row["cast1"].ToString().Trim() ||
                   favCast == row["cast2"].ToString().Trim() ||
                   favCast == row["cast3"].ToString().Trim()) &&
                   favGenre == row["genre"].ToString().Trim())
                   {

                       addTitles(row["title"].ToString() + "_cg");


                   }

                   else if (favDirector == row["director"].ToString().Trim() &&
                    favGenre == row["genre"].ToString().Trim())
                   {

                        addTitles(row["title"].ToString() + "_dg");

                   }

                   else if (favCast == row["cast1"].ToString().Trim() ||
                    favCast == row["cast2"].ToString().Trim() ||
                    favCast == row["cast3"].ToString().Trim())
                   {
                    
                        addTitles(row["title"].ToString() + "_c");
                   
                   }

                   else if (favDirector == row["Director"].ToString().Trim())
                   {

                        addTitles(row["title"].ToString() + "_d");

                   }

                   else if (favGenre == row["genre"].ToString().Trim())
                   {

                         addTitles(row["title"].ToString() + "_g");
  
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

            foreach (string movie in favMovies)
            {

                Response.Write(movie + ", ");

            }

        }

    }

}