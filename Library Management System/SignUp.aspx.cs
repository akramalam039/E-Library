using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace Library_Management_System
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds = new DataSet();
                string path = Server.MapPath("~/Statename.xml");
                ds.ReadXml(path);
                state.DataSource = ds.Tables[0];
                state.DataTextField = "name";
                state.DataValueField = "id";
                state.DataBind();
            }
        }
        string gender;
        protected void signup_Click(object sender, EventArgs e)
        {
            if (checkMemberExist())
            {
                Response.Write("<script>alert('User Id has already in Use Choose Another..');</script>");
            }
            else
            {
                NewMethod();
            }
        }

        bool checkMemberExist()
        {
            try
            {
                string stcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection(stcon);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("Select *from member_master_tbl where member_id='" + userid.Text + "'", sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
              
                if (sqlDataReader.HasRows)
                {
                    return true;
                    //Response.Write("<script>alert('User Id has already in Use Choose Another..');</script>");
                }
                else
                {
                    return false;
                }
            }catch(Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"');</script>");
                return false;
            }
        }

        private void NewMethod()
        {
            try
            {
                if (female.Checked)
                {
                    gender = "Female";
                }
                else if (male.Checked)
                {
                    gender = "Male";
                }
                else if (other.Checked)
                {
                    gender = "Other";
                }
                string stcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection(stcon);
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("insert into member_master_tbl (first_name,last_name,dob,contact_no,email,state,city,pincode,full_address,member_id,password,gender) values('" + firstName.Text + "','" + lastName.Text + "','" + birthdayDate.Text + "','" + phoneNumber.Text + "','" + emailAddress.Text + "','" + state.SelectedItem + "','" + city.Text + "','" + zip.Text + "','" + fulladdress.Text + "','" + userid.Text + "','" + password.Text + "','" + gender + "')", sqlConnection);
                int a = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                if (a > 0)
                {
                    Response.Write("<script>alert('Registration Succesfully');</script>");
                    
                }
                else
                {
                    Response.Write("<script>alert('Somethig Went Wrong');</script>");
                   
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('{ex.Message}');</script>");
                //Response.Redirect("SignUp.aspx");
            }
        }
    }
}