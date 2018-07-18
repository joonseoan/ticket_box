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
    public partial class WebForm2 : System.Web.UI.Page
    {
        SqlConnection cnn;

        string connectionString = "Data Source=LAPTOP-EO2QHHSQ\\SQLEXPRESS;Initial Catalog=TicketEasy;Integrated Security=SSPI;Persist Security Info=False";

        List<String> directors;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                SqlDataAdapter dap;
                System.Data.DataSet ds;
                string queryString;

                cnn = new SqlConnection(connectionString);
                queryString = "Select * from MOVIES;";

                try
                {
                    cnn.Open();

                    dap = new SqlDataAdapter(queryString, cnn);
                    ds = new DataSet();
                    dap.Fill(ds, "Movies");

                    directors = new List<string>();

                    foreach (DataRow row in ds.Tables["Movies"].Rows)
                    {

                        directors.Add(row["director"].ToString());


                    }
                    foreach (string director in directors)
                    {
                        Response.Write(director);

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













                // Customer' movie genre setup
                this.DropDownList1.Items.Add("Action & Adventure");
                this.DropDownList1.Items.Add("Romantic Movies");
                this.DropDownList1.Items.Add("Drama");
                this.DropDownList1.Items.Add("Animation");

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            SqlCommand command;
            cnn = new SqlConnection(connectionString);

            this.Label9.Text = "";

            try
            {

                cnn.Open();

                command = new SqlCommand("INSERT INTO CUSTOMERS VALUES (@first_name, @last_name, @gender, @age, @email, @password, @password_confirm, @genre, @director, @cast)", cnn);

                // Assign book_name, author_name, publish_date to Insert query
                command.Parameters.AddWithValue("@first_name", this.TextBox1.Text);
                command.Parameters.AddWithValue("@last_name", this.TextBox2.Text);
                command.Parameters.AddWithValue("@gender", this.RadioButtonList1.SelectedValue.ToString());
                command.Parameters.AddWithValue("@age", Int32.Parse(this.RadioButtonList2.SelectedValue));
                command.Parameters.AddWithValue("@email", this.TextBox5.Text);
                command.Parameters.AddWithValue("@password", this.TextBox6.Text);
                command.Parameters.AddWithValue("@password_confirm", this.TextBox7.Text);
                command.Parameters.AddWithValue("@genre", this.DropDownList1.SelectedValue.ToString());
                command.Parameters.AddWithValue("@director", this.TextBox8.Text);
                command.Parameters.AddWithValue("@cast", this.TextBox9.Text);
                

                command.ExecuteNonQuery();

                cnn.Close();

                this.Label9.Text = "You are successfully registered on our database";

                /*
                this.TextBox1.Text = "";
                this.TextBox2.Text = "";
                this.TextBox3.Text = "";
                this.TextBox4.Text = "";
                this.TextBox5.Text = "";
                this.TextBox6.Text = "";
                this.TextBox7.Text = "";
                */

                // this.DropDownList2.Items.Clear();
            }

            catch (SqlException ex)
            {

                Response.Write("Error in connection ! ");

            }

            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            Response.Redirect("Default.aspx");

        }
    }
}