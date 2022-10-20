using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Library_Management_System
{
    public partial class BookInventory : System.Web.UI.Page
    {
        static string global_filepath;
        static int global_acutal_stock, global_current_stock, global_issued_book;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if we direct acces the page is will show message and redirect to login page
            //if (Session["role"] == null)
            //{
            //    Response.Write("<script>alert('First Log in as Admin');</script>");
            //    Response.Redirect("AdminLogin.aspx");
            //}
            //else if(Session["role"].Equals("admin"))
            //{
            //    GridView1.DataBind();
            //    authornamelist.DataBind();
            //    publishernameList.DataBind();
            //}
            //else if (Session["role"].Equals("user"))
            //{
            //    Response.Write("<script>alert('First Log in as Admin');</script>");
            //    Response.Redirect("AdminLogin.aspx");
            //}
        }

        bool CheckIfBookExits()
        {
            try
            {
                string stcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection(stcon);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("Select *from book_master_tbl where book_id='" + bookid.Text.Trim() + "'", sqlConnection);
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

        //for filling Author Name and Publisher Name in DropDownList from Database althoug this is not in use but if we could we can
        //we are using datasource to add that thing
        void fillAuthorPublisherName()
        {
            try
            {
                string stcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection(stcon);
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
                SqlCommand cmd = new SqlCommand("Select auther_name from author_table;", sqlConnection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                authornamelist.DataSource = dt;
                authornamelist.DataValueField = "auther_name";
                authornamelist.DataBind();

                cmd = new SqlCommand("Select publisher_name from publisher_table;", sqlConnection);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                publishernameList.DataSource = dt;
                publishernameList.DataValueField = "publisher_name";
                publishernameList.DataBind();
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"');</script>");
            }
        }
        void getBookbyID()
        {
            try
            {
                string stcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection(stcon);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("Select *from book_master_tbl where book_id='" + bookid.Text.Trim() + "'", sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        //fetch and store the value in global variagle
                        global_acutal_stock = Convert.ToInt32(sqlDataReader.GetValue(11).ToString().Trim());
                        global_current_stock = Convert.ToInt32(sqlDataReader.GetValue(12).ToString().Trim());
                        global_issued_book = global_acutal_stock - global_current_stock;
                        global_filepath = sqlDataReader.GetValue(13).ToString();

                        //set the data in textfield from DB
                        bookid.Text = sqlDataReader.GetValue(0).ToString().Trim();
                        LanguageList.SelectedValue = sqlDataReader.GetValue(6).ToString();
                        authornamelist.SelectedValue = sqlDataReader.GetValue(3).ToString();
                        publishernameList.SelectedValue = sqlDataReader.GetValue(4).ToString();//select dropdown according to DB
                        bookname.Text = sqlDataReader.GetValue(1).ToString().Trim();
                        publishdate.Text = sqlDataReader.GetValue(5).ToString().Trim();
                        bookedition.Text = sqlDataReader.GetValue(7).ToString().Trim();
                        bookcost.Text = sqlDataReader.GetValue(8).ToString().Trim();
                        bookpage.Text = sqlDataReader.GetValue(9).ToString().Trim();
                        bookdescription.Text = sqlDataReader.GetValue(10).ToString().Trim();
                        actualstock.Text = sqlDataReader.GetValue(11).ToString();
                        currentstock.Text = sqlDataReader.GetValue(12).ToString();
                        issuebook.Text = "" + (Convert.ToInt32(sqlDataReader.GetValue(11).ToString()) - Convert.ToInt32(sqlDataReader.GetValue(12).ToString()));
                        generebox.ClearSelection();//clear the selection in listbox
                        string[] genre = sqlDataReader.GetValue(2).ToString().Split(',');
                        for(int i = 0; i < genre.Length; i++)//genre items from database
                        {
                            for(int j = 0; j < generebox.Items.Count; j++)//genre items in ListBox
                            {
                                if (generebox.Items[j].ToString() == genre[i])//comparing both if true
                                {
                                    generebox.Items[j].Selected = true;//then select the items
                                }
                            }
                        }
                    }
                    
                    Response.Write("<script>alert('Record Found...');</script>");
                    GridView1.DataBind();
                }
               
                else
                {
                    Response.Write($"<script>alert('No Match Record found....');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Exection is {ex.Message}');</script>");
            }
        }
        protected void Gobtn_Click(object sender, EventArgs e)
        {
            if (CheckIfBookExits())
            {
                getBookbyID();
            }
            else
            {
                Response.Write($"<script>alert('No Match Record found....');</script>");
            }
        }


        private void UpdateBook()
        {
            int actual_stock = Convert.ToInt32(actualstock.Text.Trim());
            int current_stock = Convert.ToInt32(currentstock.Text.Trim());
            if (global_acutal_stock == actual_stock)
            {

            }
            else
            {
                if (actual_stock < global_issued_book)
                {
                    Response.Write("<script>alert('Actual Stock Value cannot be less than the Issued Books');</script>");
                    return;
                }
                else
                {
                    current_stock = actual_stock - global_issued_book;
                    currentstock.Text = "" + current_stock;
                }
            }


            string genre = "";
            foreach (int i in generebox.GetSelectedIndices())
            {
                genre = genre + generebox.Items[i] + ",";
            }
            genre = genre.Remove(genre.Length - 1);


            //storing image in update button 
            string filepath = "~/BooksImg/books.png";
            string filename = Path.GetFileName(file.PostedFile.FileName);
            if (filename == "" || filename == null)
            {
                filepath = global_filepath;
            }
            else
            {
                file.SaveAs(Server.MapPath("BooksImg/" + filename));
                filepath = "~/BooksImg/" + filename;
            }
            


            string stcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
            SqlConnection sqConnection = new SqlConnection(stcon);
            if (sqConnection.State == ConnectionState.Closed)
            {
                sqConnection.Open();
            }
            SqlCommand sqlCommand = new SqlCommand("update book_master_tbl set book_name=@book_name,genre=@genre,author_name=@author_name,publisher_name=@publisher_name,publish_date=@publish_date,langugage=@langugage,edition=@edition,book_cost=@book_cost, no_of_page=@no_of_page, book_description=@book_description, actual_stock=@actual_stock, current_stock=@current_stock, book_img_link=@book_img_link where book_id='" + bookid.Text.Trim() + "';", sqConnection);
            sqlCommand.Parameters.AddWithValue("@book_name", bookname.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@genre", genre);
            sqlCommand.Parameters.AddWithValue("@author_name", authornamelist.SelectedItem.Value);
            sqlCommand.Parameters.AddWithValue("@publisher_name", publishernameList.SelectedItem.Value);
            sqlCommand.Parameters.AddWithValue("@publish_date", publishdate.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@langugage", LanguageList.SelectedItem.Value);
            sqlCommand.Parameters.AddWithValue("@edition", bookedition.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@book_cost", bookcost.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@no_of_page", bookpage.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@book_description", bookdescription.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@actual_stock", actual_stock.ToString());
            sqlCommand.Parameters.AddWithValue("@current_stock", current_stock.ToString());
            sqlCommand.Parameters.AddWithValue("@book_img_link", filepath);
           

            int a = sqlCommand.ExecuteNonQuery();
            sqConnection.Close();
            if (a > 0)
            {
                Response.Write("<script>alert('Book Records Updated Succusfully...');</script>");
                GridView1.DataBind();

            }
            else
            {
                Response.Write("<script>alert('Invalid Book Id');</script>");
            }
        }
        protected void Updatebtn_Click(object sender, EventArgs e)
        {
            //if (CheckIfBookExits())
            //{
            //    UpdateBook();
            //}
            //else
            //{
            //    Response.Write("<script>alert('Something Went Wrong');</script>");
            //}

            UpdateBook();
        }
        
        void ResetField()
        {
            bookcost.Text = "";
            bookdescription.Text = "";
            bookedition.Text = "";
            bookid.Text = "";
            bookname.Text = "";
            bookpage.Text = "";
            publishdate.Text = "";
            authornamelist.SelectedIndex =0;
            publishernameList.SelectedIndex = 0;
            LanguageList.SelectedIndex = 0;
            generebox.ClearSelection();
        }
        private void AddBook()
        {
            string genre = "";
            foreach(int i in generebox.GetSelectedIndices())
            {
                genre = genre + generebox.Items[i] + ",";
            }
            genre = genre.Remove(genre.Length - 1);//removing the extra comma ,

            //for uploading image in folder and file path in database
            string filepath = "~/BooksImg/books.png";
            string filename = Path.GetFileName(file.PostedFile.FileName);
            file.SaveAs(Server.MapPath("BooksImg/" + filename));
            filepath = "~/BooksImg/" + filename;

            string stcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
            SqlConnection sqConnection = new SqlConnection(stcon);
            if (sqConnection.State == ConnectionState.Closed)
            {
                sqConnection.Open();
            }
            SqlCommand sqlCommand = new SqlCommand("insert into book_master_tbl (book_id,book_name,genre,author_name,publisher_name,publish_date,langugage,edition,book_cost,no_of_page,book_description,actual_stock,current_stock,book_img_link) values (@book_id,@book_name,@genre,@author_name,@publisher_name,@publish_date,@langugage,@edition,@book_cost,@no_of_page,@book_description,@actual_stock,@current_stock,@book_img_link)", sqConnection);
            sqlCommand.Parameters.AddWithValue("@book_id", bookid.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@book_name", bookname.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@genre", genre);
            sqlCommand.Parameters.AddWithValue("@author_name", authornamelist.SelectedItem.Value);
            sqlCommand.Parameters.AddWithValue("@publisher_name", publishernameList.SelectedItem.Value);
            sqlCommand.Parameters.AddWithValue("@publish_date", publishdate.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@langugage", LanguageList.SelectedItem.Value);
            sqlCommand.Parameters.AddWithValue("@edition", bookedition.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@book_cost", bookcost.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@no_of_page", bookpage.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@book_description", bookdescription.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@actual_stock", actualstock.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@current_stock", actualstock.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@book_img_link", filepath);
            int a = sqlCommand.ExecuteNonQuery();
            sqConnection.Close();
            if (a > 0)
            {
                Response.Write("<script>alert('Book List Added Succusfully...');</script>");
                GridView1.DataBind();
            }
            else
            {
                Response.Write("<script>alert('Somethig Went Wrong');</script>");
            }
        }

        protected void Addbt_Click(object sender, EventArgs e)
        {
            if (CheckIfBookExits())
            {
                Response.Write("<script>alert('Book is Already Exists, Try Other Book ID..');</script>");
            }
            else
            {
                AddBook();
                GridView1.DataBind();
                ResetField();
            }
        }
        void Deletebook()
        {
            string stcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
            SqlConnection sqConnection = new SqlConnection(stcon);
            if (sqConnection.State == ConnectionState.Closed)
            {
                sqConnection.Open();
            }
            SqlCommand sqlCommand = new SqlCommand("delete from book_master_tbl where book_id='" + bookid.Text.Trim() + "';", sqConnection);
            int a = sqlCommand.ExecuteNonQuery();
            sqConnection.Close();
            if (a > 0)
            {
                Response.Write("<script>alert('A Book Record Delated Succusfully...');</script>");
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
            if (CheckIfBookExits())
            {
                Deletebook();
            }
            else
            {
                Response.Write("<script>alert('Enter Book Id not Found....');</script>");
            }
        }
    }
}