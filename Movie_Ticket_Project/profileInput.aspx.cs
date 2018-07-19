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
        List<String> casts;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                // Customer' movie genre setup
                this.DropDownList1.Items.Add("Action & Adventure");
                this.DropDownList1.Items.Add("Romantic Movies");
                this.DropDownList1.Items.Add("Drama");
                this.DropDownList1.Items.Add("Animation");

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

                    // add all directors
                    directors = new List<string>();
                    casts = new List<string>();

                    foreach (DataRow row in ds.Tables["Movies"].Rows)
                    {
                        
                        // Filter out duplicated director names
                        if (!directors.Contains(row["director"].ToString()))
                            directors.Add(row["director"].ToString().Trim());

                        // Added cast1, cast2, and cast3 fields to casts collection
                        //  by filtering out the duplicated names
                        for(int i = 1; i < 4; i++)
                        {

                            if (!casts.Contains(row[$"cast{i}"].ToString())) 
                                casts.Add(row[$"cast{i}"].ToString().Trim());
                            
                        }
  

                    }

                    directors.Sort();
                    casts.Sort();

                    foreach (string director in directors)
                    {

                        // Response.Write(director);
                        this.ListBox1.Items.Add(director);

                    }

                    foreach (string cast in casts)
                    {

                        this.ListBox2.Items.Add(cast);

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

                command.Parameters.AddWithValue("@first_name", this.TextBox1.Text.Trim());
                command.Parameters.AddWithValue("@last_name", this.TextBox2.Text.Trim());
                command.Parameters.AddWithValue("@gender", this.RadioButtonList1.SelectedValue.ToString());
                command.Parameters.AddWithValue("@age", Int32.Parse(this.RadioButtonList2.SelectedValue));
                command.Parameters.AddWithValue("@email", this.TextBox5.Text.Trim());
                command.Parameters.AddWithValue("@password", this.TextBox6.Text.Trim());
                command.Parameters.AddWithValue("@password_confirm", this.TextBox7.Text);
                command.Parameters.AddWithValue("@genre", this.DropDownList1.SelectedValue.ToString());
                command.Parameters.AddWithValue("@director", this.Label11.Text);
                command.Parameters.AddWithValue("@cast", this.Label12.Text);
                
                command.ExecuteNonQuery();

                cnn.Close();

                this.Label9.Text = "You are successfully registered on our database";
                
                /*
                this.TextBox1.Text = "";
                this.TextBox2.Text = "";
                this.TextBox5.Text = "";
                this.TextBox6.Text = "";
                this.TextBox7.Text = "";
                */

                Response.Redirect("Default.aspx");
                
            }

            catch (SqlException ex)
            {

                this.Label9.Text = "Error in connection!";

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
    
        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Since autoPostBack property is checked, do not need to specify postback = true here
            this.Label11.Text = this.ListBox1.SelectedItem.ToString();

        }

        protected void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Since autoPostBack property is checked, do not need to specify postback = true here
            this.Label12.Text = this.ListBox2.SelectedItem.ToString();

        }

    }

}