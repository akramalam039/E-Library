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
    public partial class BookIssuepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
           
        }
        bool CheckIfissuedbookexits()
        {
            try
            {
                string stcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection(stcon);
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("Select *from book_issue_tbl where member_id='" + memberid.Text.Trim() + "' and book_id='"+bookid.Text.Trim()+"'", sqlConnection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        bool CheckIfMemberxits()
        {
            try
            {
                string stcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection(stcon);
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("Select *from member_master_tbl where member_id='" + memberid.Text.Trim() + "'", sqlConnection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        bool CheckIfBookExits()
        {
            try
            {
                string stcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection(stcon);
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("Select *from book_master_tbl where book_id='" + bookid.Text.Trim() + "' And current_stock>0 ", sqlConnection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        void GetDatabyID()
        {
            try
            {
                string stcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection(stcon);
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("Select book_name from book_master_tbl where book_id='" + bookid.Text.Trim() + "'", sqlConnection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count>=1)
                {
                    bookname.Text = dt.Rows[0]["book_name"].ToString();
                }
                else
                {
                    Response.Write($"<script>alert('No Match Book Record found....');</script>");
                }

                cmd = new SqlCommand("Select first_name, last_name from member_master_tbl where member_id='" + memberid.Text.Trim() + "'", sqlConnection);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    string fname = dt.Rows[0]["first_name"].ToString();
                    string lname = dt.Rows[0]["last_name"].ToString();
                    membername.Text = fname + " " + lname;
                }
                else
                {
                    Response.Write($"<script>alert('No Match Member Record found....');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Exection is {ex.Message}');</script>");
            }
        }
        protected void gobtn_Click(object sender, EventArgs e)
        {
            GetDatabyID();
        }
        void issuebook()
        {
            string stcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
            SqlConnection sqConnection = new SqlConnection(stcon);
            if (sqConnection.State == ConnectionState.Closed)
            {
                sqConnection.Open();
            }
            SqlCommand sqlCommand = new SqlCommand("insert into book_issue_tbl (member_id,member_name,book_id,book_name,issue_date,due_date) values (@member_id,@member_name,@book_id,@book_name,@issue_date,@due_date)", sqConnection);
            sqlCommand.Parameters.AddWithValue("@member_id", memberid.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@member_name", membername.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@book_id", bookid.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@book_name", bookname.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@issue_date", startdate.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@due_date", enddate.Text.Trim());
           
            sqlCommand.ExecuteNonQuery();

            sqlCommand = new SqlCommand("update book_master_tbl set current_stock=current_stock-1 where book_id='" + bookid.Text.Trim()+"'",sqConnection);

            sqlCommand.ExecuteNonQuery();

            sqConnection.Close();
           
            Response.Write("<script>alert('Book Issue Succusfully...');</script>");
            GridView1.DataBind();
        }
        protected void issuebtn_Click(object sender, EventArgs e)
        {
            if(CheckIfMemberxits() && CheckIfBookExits())//&& CheckIfMemberxits()CheckIfBookExits()
            {
                if (CheckIfissuedbookexits())
                {
                    Response.Write($"<script>alert('This Book is Already Taken By This Memeber....');</script>");
                }
                else
                {
                    issuebook();
                    ResetField();
                    GridView1.DataBind();
                }
            }
            else
            {
                Response.Write($"<script>alert('Wrong Book Id or Book Stock is not Available or Member ID....');</script>");
            }
        }
        void ResetField()
        {
            bookid.Text = "";
            bookname.Text = "";
            membername.Text = "";
            memberid.Text = "";
            startdate.Text = "";
            enddate.Text = "";
        }


        void returnbook()
        {
            try
            {
                string stcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
                SqlConnection sqConnection = new SqlConnection(stcon);
                if (sqConnection.State == ConnectionState.Closed)
                {
                    sqConnection.Open();
                }
                SqlCommand sqlCommand = new SqlCommand("delete from book_issue_tbl where member_id='"+memberid.Text.Trim()+ "' and book_id='"+bookid.Text.Trim()+"'", sqConnection);
                int a = sqlCommand.ExecuteNonQuery();
                if (a > 0)
                {
                    sqlCommand = new SqlCommand("update book_master_tbl set current_stock=current_stock+1 where book_id='" + bookid.Text.Trim() + "'", sqConnection);
                    sqlCommand.ExecuteNonQuery();
                    sqConnection.Close();
                    Response.Write("<script>alert('Book returned succesfully');</script>");
                    GridView1.DataBind();
                }
            }
            catch(Exception ex)
            {
                Response.Write($"<script>alert('{ex.Message}');</script>");
            }
        }
        protected void returnbtn_Click(object sender, EventArgs e)
        {
            if (CheckIfMemberxits() && CheckIfBookExits())//&& CheckIfMemberxits()CheckIfBookExits()
            {
                if (CheckIfissuedbookexits())
                {
                    returnbook();
                }
                else
                {
                    Response.Write($"<script>alert('Something Went Wrong....');</script>");
                }
            }
            else
            {
                Response.Write($"<script>alert('Wrong Book Id or Book Stock is not Available or Member ID....');</script>");
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
            catch(Exception ex)
            {
                Response.Write($"<script>alert('{ex.Message}');</script>");
            }
        }
    }
}