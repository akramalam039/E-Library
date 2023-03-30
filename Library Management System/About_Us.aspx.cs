using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Library_Management_System
{
    public partial class About_Us : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        void sendindb()
        {
            try
            {
                string stcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection(stcon);
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("insert into contact_tbl (name,email,message) values('" + fullname.Text + "','" + email.Text + "','"+messagebox.Text+"')", sqlConnection);
                int a = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                if (a > 0)
                {
                    Response.Write("<script>alert('Save Succusfully in DataBase');</script>");
                }
                else
                {
                    Response.Write("<script>alert('Somethig Went Wrong');</script>");

                }
            }catch(Exception ex)
            {
                Response.Write($"<script>alert({ex.Message});</script>");
            }
        }

        protected void consub_Click(object sender, EventArgs e)
        {

            sendindb();
            try
            {
                var client = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("akneel47@gmail.com", "akramneel@47");
                // Create instance of message
                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();

                // Add receiver
                message.To.Add(email.Text);

                // Set sender
                // In this case the same as the username
                message.From = new System.Net.Mail.MailAddress("akneel47@gmail.com");

                // Set subject
                message.Subject = "Test";

                // Set body of message
                message.Body = messagebox.Text;

                // Send the message
                client.Send(message);

                // Clean up
                message = null;
                Response.Write($"<script>alert('Message Send Succesfully');</script>");
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert({ex.Message});</script>");
            }

        }
    }
}