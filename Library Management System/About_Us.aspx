<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="About_Us.aspx.cs" Inherits="Library_Management_System.About_Us" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col">
                <div class="card">
                    <div class="card-body">
                        <center><h1 style="margin-bottom: 20px;">About Us</h1></center>
                        <img src="Images/31271-Book-BookshelfLibrary-4k-Ultra-HD-Wallpaper.jpg" class="img-fluid" alt="About Us Page Image" width="100%" height="500"/>
                    </div>
                </div>
            </div>
        </div>
           <div class="row">
               <div class="col-4">
                   <div class="card">
                   <img src="Images/Ceo.jpg" class="img-fluid" width="200"/>
                       <h5 class="card-title">Admin and Director</h5>
                   <p class="card-text">About the admin and their Responsibility and many more which is required and </p>
                  </div>
               </div>
               <div class="col-4">
                    <div class="card">
                   <img src="Images/content-managers.jpg" class="img-fluid" style="margin-top:60px;" width="200"/>
                   <h5>Content Manager</h5>
                   <p>About the Content Manger and their Responsibility and many more which is required and </p>
                    </div>
               </div>
               <div class="col-4">
                    <div class="card">
                   <img src="Images/Marketing.jpg" class="img-fluid" style="margin-top:70px;" width="200"/>
                   <h5>Marketing Manager</h5>
                   <p>About the Content Manger and their Responsibility and many more which is required and </p>
                        </div>
               </div>
           </div>
        </div>
    <br />
    <div class="container-fluid" >
        <div class="card">
        <div class="row">
            <div class="col-6">
                <img src="Images/contact_us.jpg" class="img-fluid border" width="80%"/>

            </div>
            <div class="col-6">
                <%--<div class="card">--%>
                    <%--<div class="card-body">--%>
                        <div class="row">
                            <div class="col">
                                <center><h2>Contact Us</h2></center>
                                <hr />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-6">
                                <label>Full Name</label>
                            </div>
                            <div class="col-6">
                                <asp:TextBox ID="fullname" Placeholder="Your Full Name" required Class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-6">
                                <label>Email Address</label>
                            </div>
                            <div class="col-6">
                                <asp:TextBox ID="email" Placeholder="Your Email Address" required TextMode="Email" Class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-6">
                                <label>Message</label>
                            </div>
                            <div class="col-6">
                                <asp:TextBox ID="messagebox" Class="form-control" Placeholder="Enter Your Message Here......." TextMode="MultiLine" runat="server" Rows="3"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <br />
                                <asp:Button ID="consub" CssClass="btn btn-success btn-block" runat="server" Text="Submit" OnClick="consub_Click"/>
                            </div>
                        </div>
                   <%-- </div>--%>
                <%--</div>--%>

            </div>
        </div>
        </div>
    </div>
</asp:Content>
