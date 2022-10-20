<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="PublisherMang.aspx.cs" Inherits="Library_Management_System.PublisherMang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
       $(document).ready(function () {
           $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
       });
   </script>
    <div class="container">
		<div class="row">
			<div class="col-md-6">
				<div class="card shadow-2-strong card-registration" style="border-radius: 15px;">
					<div class="card-body p-4 p-md-5">
						<center>
										<h3 class="mb-1">Publisher Details</h3>
									<img src="Images/publisher.png" width="100" />
							</center>
                        <hr />
						

						<div class="row">
							<div class="col-md-4">

								<div class="form-outline">
									<label class="form-label" for="firstName">Publisher Id</label>
									<div class="input-group">
									<asp:TextBox ID="publisherid" required class="form-control" placeholder="ID" runat="server"></asp:TextBox>
									 <asp:Button ID="gobtn" class="btn btn-primary" runat="server" Text="Go" OnClick="gobtn_Click"/>
								</div>
								 </div>
							</div>
							
							<div class="col-md-8">

								<div class="form-outline">
									<label class="form-label" for="Name">Publisher Name</label>
									<asp:TextBox ID="publisherName" class="form-control" placeholder="Enter Publisher Name" runat="server"></asp:TextBox>
								</div>

							</div>
						</div>


						<br />
						<div class="row">
							<div class="col-4">
								<asp:Button ID="Addbtn" runat="server" Class="btn btn-success btn-lg btn-block" text="Add" OnClick="Addbtn_Click"/>
							</div>
							<div class="col-4">
								<asp:Button ID="Updatebtn" runat="server" Class="btn btn-warning btn-lg btn-block" text="Update" OnClick="Updatebtn_Click"/>
							</div>

							<div class="col-4">
								<asp:Button ID="Deletebtn" runat="server" Class="btn btn-danger btn-lg btn-block" text="Delete" OnClick="Deletebtn_Click"/>
							</div>

						</div>

					</div>
				</div>
				<a href="Homepage.aspx">Go to Home</a>
			</div>


			<div class="col-md-6">
				<div class="card">
					<div class="card-body">
						<div class="row">
							<div class="col">
								<center>
										<h3 class="mb-1">Publisher Details</h3>
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
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:libraryDBConnectionString %>" SelectCommand="SELECT * FROM [publisher_table]"></asp:SqlDataSource>
								<asp:GridView ID="GridView1" Class="table table-striped table-bordered table-dark" runat="server" AutoGenerateColumns="False" DataKeyNames="publisher_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="publisher_id" HeaderText="publisher_id" ReadOnly="True" SortExpression="publisher_id" />
                                        <asp:BoundField DataField="publisher_name" HeaderText="publisher_name" SortExpression="publisher_name" />
                                    </Columns>
                                </asp:GridView>
							</div>
						</div>
					</div>

				</div>
			</div>

		</div>
	</div>
</asp:Content>
