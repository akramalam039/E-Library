<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="AuthorMang.aspx.cs" Inherits="Library_Management_System.AuthorMang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
       $(document).ready(function () {
           $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
       });
   </script>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
		<div class="row">
			<div class="col-md-6">
				<div class="card shadow-2-strong card-registration" style="border-radius: 15px;">
					<div class="card-body p-4 p-md-5">
						<center>
										<h3 class="mb-1">Author Details</h3>
                                    <img src="Images/writer.png" width="100" />
							</center>
						<hr />
                        

						<div class="row">
							<div class="col-md-4">

								<div class="form-outline">
									<label class="form-label" for="firstName">Author Id</label>
                                    <div class="input-group">
									<asp:TextBox ID="authorid" class="form-control" required placeholder="ID" runat="server"></asp:TextBox>
                                     <asp:Button ID="gobtn" class="btn btn-primary" runat="server" Text="Go" OnClick="gobtn_Click" />
								</div>
                                 </div>
   							</div>
                        
                        
							<div class="col-md-8">

								<div class="form-outline">
									<label class="form-label" for="lastName">Author Name</label>
									<asp:TextBox ID="authorName" class="form-control" placeholder="Enter Author Name" runat="server"></asp:TextBox>
								</div>

							</div>
						</div>


						<br />
						<div class="row">
							<div class="col-4">
								<asp:Button ID="updatebtn" runat="server" Class="btn btn-success btn-lg btn-block" text="Add" OnClick="updatebtn_Click"/>
							</div>
                            <div class="col-4">
								<asp:Button ID="Button2" runat="server" Class="btn btn-warning btn-lg btn-block" text="Update" OnClick="Button2_Click"/>
							</div>

                            <div class="col-4">
								<asp:Button ID="Button3" runat="server" Class="btn btn-danger btn-lg btn-block" text="Delete" OnClick="Button3_Click"/>
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
										<h3 class="mb-1">Author Details</h3>
							</center>
							</div>
						</div>
                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>
						<div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:libraryDBConnectionString %>" SelectCommand="SELECT * FROM [author_table]"></asp:SqlDataSource>
							<div class="col">
								<asp:GridView ID="GridView1" Class="table table-striped table-bordered" runat="server" AutoGenerateColumns="False" DataKeyNames="author_id" DataSourceID="SqlDataSource1" PageSize="5">
                                    <Columns>
                                        <asp:BoundField DataField="author_id" HeaderText="author_id" ReadOnly="True" SortExpression="author_id" />
                                        <asp:BoundField DataField="auther_name" HeaderText="auther_name" SortExpression="auther_name" />
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
