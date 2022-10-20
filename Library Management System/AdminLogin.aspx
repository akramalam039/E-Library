<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="AdminLogin.aspx.cs" Inherits="Library_Management_System.AdminLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                        <img src="Images/adminuser.png" width="150"/>
                        
                        </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                        <h3>Admin Login</h3>
                        
                        </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <label>Admin Id</label>
                                    <asp:TextBox ID="adminid" runat="server" Class="form-control" required placeholder="Enter Admin Id"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <label>Admin Password</label>
                                    <asp:TextBox ID="adminpassword" runat="server" Class="form-control" required placeholder="Enter Admin Password" Type="password"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <asp:Button ID="loginbtn" class="btn btn-success btn-block btn-lg" runat="server" OnClick="loginbtn_Click" Text="Log In" />
                                </div>

                            </div>
                        </div>
                    </div>

                </div>

                <a href="Homepage.aspx"><b>Back to Home</b></a><br />
                <br />
            </div>

        </div>
    </div>
</asp:Content>
