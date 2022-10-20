<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="Library_Management_System.SignUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<%--<section class="vh-90 gradient-custom">--%>
        <section>
		<%--<div class="container py-5 h-100">--%>
            
            <div class="container-fluid">
			<%--<div class="row justify-content-center align-items-center h-100">--%>
                <div class="row justify-content-center">
				<div class="col-md-6">
					<div class="card shadow-2-strong card-registration" style="border-radius: 15px;">
						<div class="card-body p-4 p-md-5">
							<center>
								<img src="Images/generaluser.png" width="100" />
								<h3 class="mb-4 pb-2 pb-md-0 mb-md-5">User Registration Form</h3></center>
							<hr />


							<div class="row">
								<div class="col-md-6">

									<div class="form-outline">
										<label class="form-label" for="firstName">First Name</label>
										<asp:TextBox ID="firstName" class="form-control" placeholder="Enter First Name" required runat="server"></asp:TextBox>
									</div>

								</div>
								<div class="col-md-6 ">

									<div class="form-outline">
										<label class="form-label" for="lastName">Last Name</label>
										
										<asp:TextBox ID="lastName" class="form-control" placeholder="Enter Last Name" required runat="server"></asp:TextBox>
									</div>

								</div>
							</div>

							<div class="row">
								<div class="col-md-6 mb-4 d-flex align-items-center">

									<div class="form-outline datepicker w-100">
										<label for="birthdayDate" class="form-label">Date of Birth</label>
                                        <asp:TextBox ID="birthdayDate" class="form-control" placeholder="Date of Birth" required TextMode="Date" runat="server"></asp:TextBox>
									
									</div>

								</div>
								<div class="col-md-6 mb-4">

									<h6 class="mb-2 pb-1">Gender: </h6>

									<div class="form-check form-check-inline">
										<%--<input class="form-check-input" type="radio" name="inlineRadioOptions" id="femaleGender"
											value="option1" checked />--%>
                                        <asp:RadioButton ID="female" GroupName="gender" class="form-check-input" runat="server" />
										<label class="form-check-label" for="femaleGender">Female</label>
									</div>

									<div class="form-check form-check-inline">
										<asp:RadioButton ID="male" GroupName="gender" class="form-check-input" runat="server" />
										<label class="form-check-label" for="maleGender">Male</label>
									</div>

									<div class="form-check form-check-inline">
                                        <asp:RadioButton ID="other" GroupName="gender" class="form-check-input" runat="server" />
										<label class="form-check-label" for="otherGender">Other</label>
									</div>

								</div>
							</div>

							<div class="row">
								<div class="col-md-6 mb-4 pb-2">

									<div class="form-outline">
										<label class="form-label" for="emailAddress">Email</label>
                                        <asp:TextBox ID="emailAddress" class="form-control" required runat="server" placeholder="Email Address" TextMode="Email"></asp:TextBox>
										<%--<input type="email" id="emailAddress" class="form-control form-control-lg" />--%>
									</div>

								</div>
								<div class="col-md-6 mb-4 pb-2">

									<div class="form-outline">
										<label class="form-label" for="phoneNumber">Phone Number</label>
										
                                        <asp:TextBox ID="phoneNumber" class="form-control" required runat="server" placeholder="Phone Number" TextMode="Number" MaxLength="10"></asp:TextBox>
									</div>

								</div>
							</div>

                            <div class="row">
								<div class="col-md-4">

									<div class="form-outline">
										 <label>State</label>
                                    <asp:DropDownList ID="state" class="form-control" runat="server"></asp:DropDownList>
										 <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/Statename.xml"></asp:XmlDataSource>
										<%--<input type="email" id="emailAddress" class="form-control form-control-lg" />--%>
									</div>

								</div>
								<div class="col-md-4">

									<div class="form-outline">
										 <label>City</label>
                                    <asp:TextBox ID="city" class="form-control" required Placeholder="City" runat="server"></asp:TextBox>
									</div>

								</div>
                                <div class="col-md-4">

									<div class="form-outline">
                                        <label>Zip</label>
                                        <asp:TextBox ID="zip" class="form-control" required  Placeholder="Zip" runat="server"></asp:TextBox>
									</div>

								</div>
							</div>
                            <div class="row">
                                <div class="col-md-12">
                                    <label>Full Address</label>
                                    <asp:TextBox ID="fulladdress" required TextMode="MultiLine" Class="form-control form-control-lg" placeholder="Full Address" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <center><span class="badge badge-pill badge-info">Log In Info</span></center>
							<div class="row">
								<div class="col-md-6">
                                   <label>User Id</label>     
                                    <asp:TextBox ID="userid" runat="server" CssClass="form-control" placeholder="Enter User Id"></asp:TextBox>

								</div>

                                <div class="col-md-6">
                                        
                                    <label>Password</label>     
                                    <asp:TextBox ID="password" runat="server" CssClass="form-control" placeholder="Enter Your Paasword" TextMode="Password"></asp:TextBox>

								</div>
							</div>

							<%--<div class="mt-12 pt-2">
								<input class="btn btn-primary btn-lg" type="submit" value="Submit" />
							</div>--%>
                            <br />
                            <div class="row">
                                <div class="col-12">
                                    <asp:Button ID="signup" runat="server" Class="btn btn-primary btn-lg btn-block" OnClick="signup_Click" text="Sign Up"/>
                                </div>
                            </div>

						</div>
					</div>
                    <a href="Homepage.aspx">Go to Home</a>
				</div>
                
			</div>
             
		</div>
	       
   
    </section>


</asp:Content>
