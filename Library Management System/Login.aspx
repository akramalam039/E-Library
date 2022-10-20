<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Library_Management_System.Login" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .vh-95 {
            margin-top: 50px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <section class="vh-95">
            <div class="container-fluid h-custom">
                
                <div class="row d-flex justify-content-center align-items-center h-100">
                    <div class="col-md-9 col-lg-6 col-xl-5">
                        <%--<img src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-login-form/draw2.webp"
                            class="img-fluid" alt="Sample image">--%>
                        <img src="Images/LoginpageImg.png" class="img-fluid" alt="Sample image">
                    </div>
                    <div class="col-md-8 col-lg-6 col-xl-4 offset-xl-1">

                        <div class="form-outline mb-4">
                            <div class="card">
                                <center><img src="Images/generaluser.png" width="150"/></center><hr />
                                <h4 style="text-align: center; color: #002E94;">User Log In Form</h4>
                                <label class="form-label" for="form3Example3">User ID</label>
                                <asp:TextBox ID="userid" runat="server" required class="form-control form-control-lg" placeholder="Enter Your User ID"></asp:TextBox>
                                <div class="form-outline mb-3">
                            <label class="form-label" for="form3Example4">Password</label>
                            <asp:TextBox ID="passwordtxt" class="form-control form-control-lg" runat="server" required placeholder="Enter Password" onClick="" type="password"></asp:TextBox>
                            <%--<input type="password" id="form3Example4"  />--%>
                        </div>

                        <div class="d-flex justify-content-between align-items-center">
                            <!-- Checkbox -->
                            <div class="form-check mb-0">
                                <input class="form-check-input me-2" type="checkbox" value="" id="form2Example3" />
                                <label class="form-check-label" for="form2Example3">
                                    Remember me
                                </label>
                            </div>

                            <a href="#!" class="text-body">Forgot password?</a>
                        </div>
                                    <div class="text-center text-lg-start mt-4 pt-2">
                            <asp:Button ID="submitbtn" runat="server" Text="Login" class="btn btn-primary btn-lg"
                                Style="padding-left: 2.5rem; padding-right: 2.5rem;" OnClick="submitbtn_Click" />
                            <p class="small fw-bold mt-2 pt-1 mb-0">
                                <b>Don't have an account? </b><a href="SignUp.aspx" class="link-danger">Register</a>
                            </p>
                        </div>
                             </div>
                            
                        </div>
                       
                        <!-- Password input -->
                        
                             </div>
                             </div>
                    </div>
        </section>
</asp:Content>
