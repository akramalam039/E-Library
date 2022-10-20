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
    public partial class PublisherMang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        bool CheckIfPublisherExits()
        {
            try
            {
                string stcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection(stcon);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("Select *from publisher_table where publisher_id='" + publisherid.Text + "'", sqlConnection);
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
        string name1;
        protected void gobtn_Click(object sender, EventArgs e)
        {
            try
            {
                string stcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection(stcon);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("Select *from publisher_table where publisher_id='" + publisherid.Text + "'", sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        name1 = sqlDataReader.GetValue(1).ToString();
                    }
                    Response.Write("<script>alert('Record Found...');</script>");
                    publisherName.Text = name1;
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


        private void UpdatePublisher()
        {
            string stcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
            SqlConnection sqConnection = new SqlConnection(stcon);
            if (sqConnection.State == ConnectionState.Closed)
            {
                sqConnection.Open();
            }
            SqlCommand sqlCommand = new SqlCommand("update publisher_table set publisher_name='" + publisherName.Text.Trim() + "' where publisher_id='" + publisherid.Text.Trim() + "';", sqConnection);
            int a = sqlCommand.ExecuteNonQuery();
            sqConnection.Close();
            if (a > 0)
            {
                Response.Write("<script>alert('Publisher Name Updated Succusfully...');</script>");
            }
            else
            {
                Response.Write("<script>alert('Somethig Went Wrong');</script>");
            }
        }
        protected void Updatebtn_Click(object sender, EventArgs e)
        {
            if (CheckIfPublisherExits())
            {
                UpdatePublisher();
                ResetField();
                GridView1.DataBind();
            }
            else
            {
                Response.Write("<script>alert('Somethig Went Wrong');</script>");
            }
        }

        void DeletePublisher()
        {
            string stcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
            SqlConnection sqConnection = new SqlConnection(stcon);
            if (sqConnection.State == ConnectionState.Closed)
            {
                sqConnection.Open();
            }
            SqlCommand sqlCommand = new SqlCommand("delete from publisher_table where publisher_id='" + publisherid.Text.Trim() + "';", sqConnection);
            int a = sqlCommand.ExecuteNonQuery();
            sqConnection.Close();
            if (a > 0)
            {
                Response.Write("<script>alert('A Publisher Record Delated Succusfully...');</script>");
                ResetField();
                GridView1.DataBind();
            }
            else
            {
                Response.Write("<script>alert('Somethig Went Wrong');</script>");
            }
        }
        protected void Deletebtn_Click(object sender, EventArgs e)
        {
            if (CheckIfPublisherExits())
            {
                DeletePublisher();
            }
            else
            {
                Response.Write("<script>alert('Somethig Went Wrong');</script>");
            }
        }
        private void AddPublisher()
        {
            string stcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
            SqlConnection sqConnection = new SqlConnection(stcon);
            if (sqConnection.State == ConnectionState.Closed)
            {
                sqConnection.Open();
            }
            SqlCommand sqlCommand = new SqlCommand("insert into publisher_table values (@publisherid,@publishername)", sqConnection);
            sqlCommand.Parameters.AddWithValue("@publisherid", publisherid.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@publishername", publisherName.Text.Trim());
            int a = sqlCommand.ExecuteNonQuery();
            sqConnection.Close();
            if (a > 0)
            {
                Response.Write("<script>alert('Publisher Added Succusfully...');</script>");
            }
            else
            {
                Response.Write("<script>alert('Somethig Went Wrong');</script>");
            }
        }
        protected void Addbtn_Click(object sender, EventArgs e)
        {
            if (CheckIfPublisherExits())
            {
                Response.Write("<script>alert('Publisher Id has already in Use Choose Another..');</script>");

            }
            else
            {
                AddPublisher();
                GridView1.DataBind();
                ResetField();
            }
        }

        void ResetField()
        {
            publisherid.Text = "";
            publisherName.Text = "";
        }
    }
}