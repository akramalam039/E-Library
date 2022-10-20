<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="userProfile.aspx.cs" Inherits="Library_Management_System.userProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
       $(document).ready(function () {
           $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
       });
   </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class="container-fluid">
		<div class="row">
			<div class="col-md-5">
				<div class="card shadow-2-strong card-registration" style="border-radius: 15px;">
					<div class="card-body p-4 p-md-5">
						<center>
								<img src="Images/generaluser.png" width="100" />
								<h3 class="mb-1">Your Profile</h3>
								<span>Account Status -</span>
									<asp:Label ID="Label1" class="badge badge-pill badge-success" runat="server" Text="Label"></asp:Label>

							</center>
						<hr />
						<div class="row">
							<div class="col-md-6">

								<div class="form-outline">
									<label class="form-label" for="firstName">First Name</label>
									<asp:TextBox ID="firstName" class="form-control" placeholder="First Name" runat="server"></asp:TextBox>
								</div>

							</div>
							<div class="col-md-6 ">

								<div class="form-outline">
									<label class="form-label" for="lastName">Last Name</label>
									<%-- <input type="text" id="lastName" class="form-control form-control-lg" />--%>
									<asp:TextBox ID="lastName" class="form-control" placeholder="Last Name" runat="server"></asp:TextBox>
								</div>

							</div>
						</div>

						<div class="row">
							<div class="col-md-6 mb-4 d-flex align-items-center">

								<div class="form-outline datepicker w-100">
									<label for="birthdayDate" class="form-label">Date of Birth</label>
									<asp:TextBox ID="birthdayDate" class="form-control" placeholder="Date of Birth" TextMode="Date" runat="server"></asp:TextBox>
									<%--<input type="text" class="form-control form-control-lg" id="birthdayDate" />--%>
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
									<asp:TextBox ID="emailAddress" class="form-control" runat="server" placeholder="Email Address" TextMode="Email"></asp:TextBox>
									<%--<input type="email" id="emailAddress" class="form-control form-control-lg" />--%>
								</div>

							</div>
							<div class="col-md-6 mb-4 pb-2">

								<div class="form-outline">
									<label class="form-label" for="phoneNumber">Phone Number</label>

									<asp:TextBox ID="phoneNumber" class="form-control" runat="server" placeholder="Phone Number" TextMode="Number" MaxLength="10"></asp:TextBox>
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
									<asp:TextBox ID="city" class="form-control" Placeholder="City" runat="server"></asp:TextBox>
								</div>

							</div>
							<div class="col-md-4">

								<div class="form-outline">
									<label>Zip</label>
									<asp:TextBox ID="zip" class="form-control" Placeholder="Zip" runat="server"></asp:TextBox>
								</div>

							</div>
						</div>
						<div class="row">
							<div class="col-md-12">
								<label>Full Address</label>
								<asp:TextBox ID="fulladdress" TextMode="MultiLine" Class="form-control form-control-lg" placeholder="Full Address" runat="server"></asp:TextBox>
							</div>
						</div>
						<center><span class="badge badge-pill badge-info">Log In Info</span></center>
						<div class="row">
							<div class="col-md-4">
								<label>User Id</label>
								<asp:TextBox ID="userid" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
							</div>

							<div class="col-md-4">
								<label>Old Password</label>
								<asp:TextBox ID="password" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
							</div>

							<div class="col-md-4">
								<label>New Password</label>
								<asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="New Paasword" TextMode="Password"></asp:TextBox>
							</div>
						</div>

						<br />
						<div class="row">
							<div class="col-12">
								<center><asp:Button ID="updatebtn" runat="server" Class="btn btn-primary btn-lg" text="Update" Style="padding-left:90px; padding-right:90px; text-align: center;" OnClick="updatebtn_Click"/></center>
							</div>
						</div>
					</div>
				</div>
				<a href="Homepage.aspx">Go to Home</a>
			</div>


			<div class="col-md-7">
				<div class="card">
					<div class="card-body">
						<div class="row">
							<div class="col-md-12">
								<center>
								<img src="Images/books.png" width="100" />
								<h3 class="mb-1">Your Issued Books</h3>
								<span>Account Status -</span>
									<asp:Label ID="Label2" class="badge badge-pill badge-info" runat="server" Text="Books Info"></asp:Label>
							</center>
							</div>
						</div>
						<div class="row">
							<div class="col">
                                <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>--%>
								<asp:GridView ID="GridView1" Class="table table-striped table-bordered table-dark" runat="server" OnRowDataBound="GridView1_RowDataBound"></asp:GridView>
							</div>
						</div>
					</div>

				</div>
			</div>

		</div>
	</div>
</asp:Content>
