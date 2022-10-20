using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace Library_Management_System
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        string stcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        void dbconnection()
        {
            string stcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(stcon);
            sqlConnection.Open();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void loginbtn_Click(object sender, EventArgs e)
        {
            try
            {
                string stcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection(stcon);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("select *from admin_login_tbl where username='" + adminid.Text + "' and password='" + adminpassword.Text + "'", sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        Response.Write("<script>alert('Log In Succesfully....');</script>");
                        Session["name"] = sqlDataReader.GetValue(2).ToString();
                        Session["role"] = "admin";
                    }
                    Response.Redirect("homepage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Admin Log In Failed');</script>");
                }
            }catch(Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"');</script>");
            }
        }
    }
}