using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Library_Management_System
{
    public partial class userProfile : System.Web.UI.Page
    {
        string stcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
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
            try
            {
                if (Session["memberid"].ToString() == "" || Session["memberid"] == null)
                {
                    Response.Write("<script>alert('Session Expired Log In Agian..');</script>");
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    getBookdata();
                    GridView1.DataBind();
                    if (!Page.IsPostBack)
                    {
                        getUserData();
                    }
                    

                }
            }catch(Exception ex)
            {
                //Response.Write("<script>alert('this is page load" + ex.Message + "');</script>");
                Response.Write("<script>alert('Session Expired Log In Agian..');</script>");
                Response.Redirect("Login.aspx");
            }
        }
        void getUserData()
        {
            try
            {
                string gender;
                string stcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection(stcon);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("Select *from member_master_tbl where member_id='" + Session["memberid"].ToString() + "'", sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        firstName.Text = sqlDataReader.GetValue(0).ToString();
                        lastName.Text=sqlDataReader.GetValue(1).ToString();
                        birthdayDate.Text = sqlDataReader.GetValue(2).ToString();
                        phoneNumber.Text = sqlDataReader.GetValue(3).ToString();
                        emailAddress.Text = sqlDataReader.GetValue(4).ToString();
                        state.SelectedValue = sqlDataReader.GetValue(5).ToString();
                        city.Text = sqlDataReader.GetValue(6).ToString();
                        zip.Text = sqlDataReader.GetValue(7).ToString();
                        fulladdress.Text = sqlDataReader.GetValue(8).ToString();
                        userid.Text = sqlDataReader.GetValue(9).ToString();
                        password.Text = sqlDataReader.GetValue(10).ToString();
                        gender = sqlDataReader.GetValue(12).ToString();
                        Label1.Text = sqlDataReader.GetValue(11).ToString();
                        //seting the color of pill according to acunt status
                        if (sqlDataReader.GetValue(11).ToString().Trim() == "Approved")
                        {
                            Label1.Attributes.Add("class", "badge rounded-pill bg-success");
                        }
                        else if(sqlDataReader.GetValue(11).ToString().Trim() == "Pending")
                        {
                            Label1.Attributes.Add("class", "badge rounded-pill bg-warning text-dark");
                        }
                        else if (sqlDataReader.GetValue(11).ToString().Trim() == "Restricted")
                        {
                            Label1.Attributes.Add("class", "badge rounded-pill bg-danger");
                        }
                        else
                        {
                            Label1.Attributes.Add("class", "badge rounded-pill bg-primary");
                        }
                        //Response.Write($"<script>alert('"+gender+"');</script>");
                        //for selecting the gender
                        if (gender.Trim() == "Male")
                        {
                            male.Checked=true;
                        }
                        else if (gender.Trim() == "Female")
                        {
                            female.Checked = true;
                        }
                        else if (gender.Trim() == "Other")
                        {
                            other.Checked = true;
                        }
                    }
                    //Response.Write("<script>alert('Record Found...');</script>");
                    GridView1.DataBind();
                }
                else
                {
                    Response.Write($"<script>alert('No Match Record found....');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('{ex.Message}');</script>");
            }
        }
        void getBookdata()
        {
            try
            {
                //string stcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection(stcon);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("Select *from book_issue_tbl where member_id='" + Session["memberid"].ToString() + "'", sqlConnection);
                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('This is getbookby data" + ex.Message + "');</script>");
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;
                    if (today > dt)
                    {
                        e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('{ex.Message}');</script>");
            }
        }
        string gender;
        void updateUserDetail()
        {
            //gender 
           
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

            //for password if user dosen't want to change password
            string password1 = "";
            if (TextBox1.Text.Trim() == "")
            {
                password1 = password.Text.Trim();
            }
            else
            {
                password1 = TextBox1.Text.Trim();
            }
            try
            {
                string stcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
                SqlConnection sqConnection = new SqlConnection(stcon);
                if (sqConnection.State == ConnectionState.Closed)
                {
                    sqConnection.Open();
                }
                SqlCommand sqlCommand = new SqlCommand("update member_master_tbl set first_name=@first_name,last_name=@last_name,dob=@dob,contact_no=@contact_no,email=@email,state=@state,city=@city,pincode=@pincode,full_address=@full_address,password=@password,gender=@gender,account_status=@account_status where member_id='" + Session["memberid"].ToString() + "';", sqConnection);
                sqlCommand.Parameters.AddWithValue("@first_name", firstName.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@last_name", lastName.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@dob", birthdayDate.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@contact_no", phoneNumber.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@email", emailAddress.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@state", state.SelectedValue.Trim());
                sqlCommand.Parameters.AddWithValue("@city", city.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@pincode", zip.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@full_address", fulladdress.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@password", password1);
                sqlCommand.Parameters.AddWithValue("@gender", gender);
                sqlCommand.Parameters.AddWithValue("@account_status", "Pending");
               

                int a = sqlCommand.ExecuteNonQuery();
                sqConnection.Close();
                if (a > 0)
                {
                    Response.Write("<script>alert('Account Updated Succesfully...');</script>");
                    GridView1.DataBind();
                    getUserData();
                }

                else
                {
                    Response.Write("<script>alert('Somethig Went Wrong');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        protected void updatebtn_Click(object sender, EventArgs e)
        {
            updateUserDetail();
        }
    }
}