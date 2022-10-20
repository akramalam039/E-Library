using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace Library_Management_System
{
    public partial class MemberMang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        bool CheckIfMemberExits()
        {
            try
            {
                string stcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection(stcon);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("Select *from member_master_tbl where member_id='"+memberid.Text.Trim()+"';", sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
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
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        protected void Gobtn_Click(object sender, EventArgs e)
        {
            try
            {
                string name1;
                string stcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection(stcon);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("Select *from member_master_tbl where member_id='" + memberid.Text + "'", sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        fullName.Text = sqlDataReader.GetValue(0).ToString() +" "+ sqlDataReader.GetValue(1).ToString();
                        dob.Text=sqlDataReader.GetValue(2).ToString();
                        contactno.Text=sqlDataReader.GetValue(3).ToString();
                        emailid.Text=sqlDataReader.GetValue(4).ToString();
                        statename.Text=sqlDataReader.GetValue(5).ToString();
                        cityname.Text=sqlDataReader.GetValue(6).ToString();
                        pincode.Text=sqlDataReader.GetValue(7).ToString();
                        fulladdress.Text = sqlDataReader.GetValue(8).ToString();
                        acstatus.Text = sqlDataReader.GetValue(11).ToString();
                        
                    }
                    Response.Write("<script>alert('Record Found...');</script>");

                    GridView1.DataBind();
                }
                else
                {
                    Response.Write($"<script>alert('No Match Record found....');</script>");
                }
            }catch(Exception ex)
            {
                Response.Write($"<script>alert('{ex.Message}');</script>");
            }
         }

        protected void Approvedbtn_Click(object sender, EventArgs e)
        {
            try
            {
                string stcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
                SqlConnection sqConnection = new SqlConnection(stcon);
                if (sqConnection.State == ConnectionState.Closed)
                {
                    sqConnection.Open();
                }
                SqlCommand sqlCommand = new SqlCommand("update member_master_tbl set account_status='Approved' where member_id='" + memberid.Text.Trim() + "';", sqConnection);
                int a = sqlCommand.ExecuteNonQuery();
                sqConnection.Close();
                if (a > 0)
                {
                    //Response.Write("<script>alert('A Member or User Record Delated Succusfully...');</script>");
                    GridView1.DataBind();
                    acstatus.Text = "Approved";
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

        protected void Pendingbtn_Click(object sender, EventArgs e)
        {
            try
            {
                string stcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
                SqlConnection sqConnection = new SqlConnection(stcon);
                if (sqConnection.State == ConnectionState.Closed)
                {
                    sqConnection.Open();
                }
                SqlCommand sqlCommand = new SqlCommand("update member_master_tbl set account_status='Pending' where member_id='" + memberid.Text.Trim() + "';", sqConnection);
                int a = sqlCommand.ExecuteNonQuery();
                sqConnection.Close();
                if (a > 0)
                {
                    //Response.Write("<script>alert('A Member or User Record Delated Succusfully...');</script>");
                    GridView1.DataBind();
                    acstatus.Text = "Pending";
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

        protected void Restrictedbtn_Click(object sender, EventArgs e)
        {
            try
            {
                string stcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
                SqlConnection sqConnection = new SqlConnection(stcon);
                if (sqConnection.State == ConnectionState.Closed)
                {
                    sqConnection.Open();
                }
                SqlCommand sqlCommand = new SqlCommand("update member_master_tbl set account_status='Restricted' where member_id='" + memberid.Text.Trim() + "';", sqConnection);
                int a = sqlCommand.ExecuteNonQuery();
                sqConnection.Close();
                if (a > 0)
                {
                    //Response.Write("<script>alert('A Member or User Record Delated Succusfully...');</script>");
                    GridView1.DataBind();
                    acstatus.Text = "Restricted";
                }
               
                else
                {
                    Response.Write("<script>alert('Somethig Went Wrong');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"');</script>");
            }
        }

        void DeleteMember()
        {
            //if (CheckIfMemberExits())
            {
                string stcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
                SqlConnection sqConnection = new SqlConnection(stcon);
                if (sqConnection.State == ConnectionState.Closed)
                {
                    sqConnection.Open();
                }
                SqlCommand sqlCommand = new SqlCommand("delete from member_master_tbl where member_id='" + memberid.Text.Trim() + "';", sqConnection);
                int a = sqlCommand.ExecuteNonQuery();
                sqConnection.Close();
                if (a > 0)
                {
                    Response.Write("<script>alert('A Member or User Record Delated Succusfully...');</script>");
                    ResetField();
                    GridView1.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('Somethig Went Wrong');</script>");
                }
            //}
            //else
            //{
            //    Response.Write("<script>alert('User/Member Id Did't Found...');</script>");
            }
            
        }

        protected void dltbtn_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteMember();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('{ex.Message}');</script>");
            }
        }
        void ResetField()
        {
            memberid.Text = "";
            fullName.Text = "";
            dob.Text = "";
            contactno.Text = "";
            emailid.Text = "";
            statename.Text = "";
            cityname.Text = "";
            pincode.Text = "";
            fulladdress.Text ="";
            acstatus.Text = "";
        }
    }
}