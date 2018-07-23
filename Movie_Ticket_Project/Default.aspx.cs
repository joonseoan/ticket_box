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
    public partial class WebForm1 : System.Web.UI.Page
    {

        Boolean admin = false;
        string admin_email;
        string admin_pw;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void signup_Click(object sender, EventArgs e)
        {

            Response.Redirect("ProfileInput.aspx");

        }

        protected void submit_Click(object sender, EventArgs e)
        {

            string email = this.TextBox1.Text.Trim();
            string password = this.TextBox2.Text.Trim();

            if (!admin)
            {

                SqlConnection cnn;
                SqlDataAdapter dap;
                System.Data.DataSet ds;
                string queryString;

                string connectionString = "Data Source=LAPTOP-EO2QHHSQ\\SQLEXPRESS;Initial Catalog=TicketEasy;Integrated Security=SSPI;Persist Security Info=False";
                cnn = new SqlConnection(connectionString);
                queryString = "Select * from CUSTOMERS";

                try
                {
                    cnn.Open();

                    dap = new SqlDataAdapter(queryString, cnn);
                    ds = new DataSet();
                    dap.Fill(ds, "Customer");

                    foreach (DataRow row in ds.Tables["Customer"].Rows)
                    {

                        if (email == row["email"].ToString())
                        {

                            if (password == row["password"].ToString())
                            {

                                Session["FirstName"] = row["first_name"];
                                Session["LastName"] = row["last_name"];
                                Session["Genre"] = row["genre"];
                                Session["Director"] = row["director"];
                                Session["Cast"] = row["cast"];
                                Session["Age"] = row["age"];

                                Response.Redirect("Service.aspx");

                            }
                            else
                            {

                                this.Label1.Text = "You got a wrong password.";
                                return;

                            }

                        }
                        else
                        {

                            this.Label1.Text = "You got a wrong customer name.";

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
            else
            {

                if (admin_email == email)
                {

                    if (admin_pw == password)
                    {

                        Response.Redirect("Movies.aspx");

                    }
                    else
                    {

                        this.Label1.Text = "You got a wrong password.";
                        return;

                    }

                }
                else
                {

                    this.Label1.Text = "You got a wrong customer name.";

                }

            }
            
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

            admin_email = "admin@gmail.com";
            admin_pw = "12345678";

            admin = true;

        }

    }

}