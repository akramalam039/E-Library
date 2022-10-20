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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitbtn_Click(object sender, EventArgs e)
        {
            try
            {
                string stcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection(stcon);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("select *from member_master_tbl where member_id='" + userid.Text.Trim() + "' and password='" + passwordtxt.Text.Trim() + "'", sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        string msg = sqlDataReader.GetValue(1).ToString();
                        Response.Write("<script>alert('" + msg + "');</script>");
                        Session["user"]= sqlDataReader.GetValue(10).ToString();
                        Session["name"]= sqlDataReader.GetValue(0).ToString();
                        Session["status"]= sqlDataReader.GetValue(11).ToString();
                        Session["role"] = "user";
                        Session["memberid"] = sqlDataReader.GetValue(9).ToString();
                    }
                    Response.Redirect("homepage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Log In Failed');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"');</script>");
            }
           
        }
    }
}