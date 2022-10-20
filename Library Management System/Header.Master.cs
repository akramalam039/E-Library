using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management_System
{
    public partial class Header : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"].Equals(""))//when page open there will no role
                {
                    LinkButton1.Visible = true; //user log in link button
                    LinkButton2.Visible = true; //user sign up  link button
                    LinkButton3.Visible = false; //user log out link button
                    LinkButton5.Visible = false; //user log name link button
                    LinkButton6.Visible = true; // admin log in link button
                    LinkButton7.Visible = false; // author link button
                    LinkButton8.Visible = false; //publisher link button
                    LinkButton9.Visible = false; //book inventroy button
                    LinkButton10.Visible = false; //book issueing link button
                }
                else if (Session["role"].Equals("user"))
                {
                    string name = Session["name"].ToString();
                    LinkButton5.Text = "Hello " +name;
                    LinkButton1.Visible = false; //user log in link button
                    LinkButton2.Visible = false; //user sign up  link button
                    LinkButton3.Visible = true; //user log out link button
                    LinkButton5.Visible = true; //user name link button
                    LinkButton6.Visible = true; // admin log in link button
                    LinkButton7.Visible = false; // author link button
                    LinkButton8.Visible = false; //publisher link button
                    LinkButton9.Visible = false; //book inventroy button
                    LinkButton10.Visible = false; //book issueing link button
                    LinkButtonmembermange.Visible = false; //member management
                }
                else if (Session["role"].Equals("admin"))
                {
                    string name = Session["name"].ToString();
                    LinkButton5.Text = "Hello " + name;
                    LinkButton1.Visible = false; //user log in link button
                    LinkButton2.Visible = false; //user sign up  link button
                    LinkButton3.Visible = true; //user log out link button
                    LinkButton5.Visible = true; //user name link button
                    LinkButton6.Visible = false; // admin log in link button
                    LinkButton7.Visible = true; // author link button
                    LinkButton8.Visible = true; //publisher link button
                    LinkButton9.Visible = true; //book inventroy button
                    LinkButton10.Visible = true; //book issueing link button
                    LinkButtonmembermange.Visible = true; //member management
                }
            }catch(Exception ex)
            {

            }
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookView.aspx");
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLogin.aspx");
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("AuthorMang.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("PublisherMang.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookInventory.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookIssuepage.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx");
        }
        //log out btn
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            //become by default aal one
            Session["user"] = "";
            Session["name"] = "";
            Session["status"] = "";
            Session["role"] = "";
            LinkButton1.Visible = true; //user log in link button
            LinkButton2.Visible = true; //user sign up  link button
            LinkButton3.Visible = false; //user log out link button
            LinkButton5.Visible = false; //user log name link button
            LinkButton6.Visible = true; // admin log in link button
            LinkButton7.Visible = false; // author link button
            LinkButton8.Visible = false; //publisher link button
            LinkButton9.Visible = false; //book inventroy button
            LinkButton10.Visible = false; //book issueing link button
            LinkButtonmembermange.Visible = false; //member management
            Response.Redirect("homepage.aspx");
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            if (Session["role"].Equals("admin"))
            {

            }
            if (Session["role"].Equals("user"))
            {
                Response.Redirect("userProfile.aspx");
            }
            
        }

        

        protected void LinkButtonmembermange_Click1(object sender, EventArgs e)
        {
            Response.Redirect("MemberMang.aspx");
        }
    }
}