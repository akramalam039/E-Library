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
    public partial class AuthorMang : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["role"] == null)
            //{
            //    Response.Write("<script>alert('First Log in as Admin');</script>");
            //    Response.Redirect("AdminLogin.aspx");
            //}
            //else if (Session["role"].Equals("admin"))
            //{
            //    GridView1.DataBind();
            //}
            //else if (Session["role"].Equals("user"))
            //{
            //    Response.Write("<script>alert('First Log in as Admin');</script>");
            //    Response.Redirect("AdminLogin.aspx");
            //}
        }
        //add btn
        bool CheckIfAuthorExits()
        {
            try
            {
                string stcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection(stcon);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("Select *from author_table where author_id='" + authorid.Text + "'", sqlConnection);
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
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }
        
        protected void updatebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckIfAuthorExits())
                {
                    Response.Write("<script>alert('this Author has already Added...');</script>");
                    
                }
                else
                {
                    AddAuthor();
                    GridView1.DataBind();
                    ResetField();
                }
            }catch(Exception ex)
            {
                Response.Write($"<script>alert('{ex.Message}');</script>");
            }
           
        }

        private void AddAuthor()
        {
            string stcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
            SqlConnection sqConnection = new SqlConnection(stcon);
            if (sqConnection.State == ConnectionState.Closed)
            {
                sqConnection.Open();
            }
            SqlCommand sqlCommand = new SqlCommand("insert into author_table values (@authorid,@authorname)", sqConnection);
            sqlCommand.Parameters.AddWithValue("@authorid", authorid.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@authorname", authorName.Text.Trim());
            int a = sqlCommand.ExecuteNonQuery();
            sqConnection.Close();
            if (a > 0)
            {
                Response.Write("<script>alert('Author has Succusfully Added...');</script>");
            }
            else
            {
                Response.Write("<script>alert('Somethig Went Wrong');</script>");
            }
        }
        private void UpdateAuthor()
        {
            string stcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
            SqlConnection sqConnection = new SqlConnection(stcon);
            if (sqConnection.State == ConnectionState.Closed)
            {
                sqConnection.Open();
            }
            SqlCommand sqlCommand = new SqlCommand("update author_table set auther_name='"+authorName.Text.Trim()+"' where author_id='"+authorid.Text.Trim()+"';", sqConnection);
            int a = sqlCommand.ExecuteNonQuery();
            sqConnection.Close();
            if (a > 0)
            {
                Response.Write("<script>alert('Author Name Updated Succusfully...');</script>");
            }
            else
            {
                Response.Write("<script>alert('Somethig Went Wrong');</script>");
            }
        }
        //update btn

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckIfAuthorExits())
                {
                    UpdateAuthor();
                    GridView1.DataBind();
                    ResetField();
                }
                else
                {
                    Response.Write("<script>alert('Somethig Went Wrong');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('{ex.Message}');</script>");
            }

        }
        
        // delete btn
        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckIfAuthorExits())
                {
                    DeleteAuthor();
                    GridView1.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('Somethig Went Wrong');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('{ex.Message}');</script>");
            }

        }

        void DeleteAuthor()
        {
            string stcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
            SqlConnection sqConnection = new SqlConnection(stcon);
            if (sqConnection.State == ConnectionState.Closed)
            {
                sqConnection.Open();
            }
            SqlCommand sqlCommand = new SqlCommand("delete from author_table where author_id='"+authorid.Text.Trim()+"';", sqConnection);
            int a = sqlCommand.ExecuteNonQuery();
            sqConnection.Close();
            if (a > 0)
            {
                Response.Write("<script>alert('A Author Record Delated Succusfully...');</script>");
                ResetField();
            }
            else
            {
                Response.Write("<script>alert('Somethig Went Wrong');</script>");
            }
        }
        
        string name1 = "";
        protected void gobtn_Click(object sender, EventArgs e)
        {
            try
            {
                string stcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection(stcon);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("Select *from author_table where author_id='" + authorid.Text + "'", sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        name1 = sqlDataReader.GetValue(1).ToString();
                    }
                    Response.Write("<script>alert('Record Found...');</script>");
                    authorName.Text = name1;
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

        void ResetField()
        {
            authorid.Text = "";
            authorName.Text = "";
        }
    }
}