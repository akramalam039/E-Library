<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="MemberMang.aspx.cs" Inherits="Library_Management_System.MemberMang" %>
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
            <div class="col-5">
        <div class="card">
            <div class="card-body">
                <div class="row">
               <div class="col">
                   <center><h3>Member Details</h3></center>
               </div>
           </div>
                <div class="row">
               <div class="col">
                   <center><img src="Images/generaluser.png" width="100"/></center>
               </div>
           </div>
                <div class="row">
               <div class="col-3">
                   <label>Member ID</label>
                   <div class="input-group">
                       <asp:TextBox ID="memberid" placeholder="ID" class="form-control" required runat="server"></asp:TextBox>
                       <asp:Button ID="Gobtn" runat="server" class="btn btn-primary btn-dark" Text="Go" OnClick="Gobtn_Click" />
                   </div>
                   
               </div>
                     <div class="col-3">
                    <label>Full Name</label>
                            <asp:TextBox ID="fullName"  placeholder="Full Name" ReadOnly="true" class="form-control" runat="server"></asp:TextBox>
                       
               </div>
                    <div class="col-6">
                    <label>Account Status</label>
                        <div class="input-group">
                            <asp:TextBox ID="acstatus"  placeholder="Status" ReadOnly="true" class="form-control" runat="server"></asp:TextBox>
                            
                            <asp:LinkButton ID="Approvedbtn" runat="server" class="btn btn-success ml-1 mr-1" ToolTip="Approved" OnClick="Approvedbtn_Click"><i class="fa-solid fa-check"></i></asp:LinkButton>
                            <asp:LinkButton ID="Pendingbtn" runat="server" class="btn btn-warning mr-1" ToolTip="Pending" OnClick="Pendingbtn_Click"><i class="fa-solid fa-pause"></i></asp:LinkButton>
                            <asp:LinkButton ID="Restrictedbtn" runat="server" class="btn btn-danger mr-1" ToolTip="Restricted" OnClick="Restrictedbtn_Click"><i class="fa-solid fa-times"></i></asp:LinkButton>
                        </div>
               </div>
           </div>
                
                <div class="row">
               <div class="col-4">
                   <label>DOB</label>
                   <asp:TextBox ID="dob" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
               </div>
                    <div class="col-4">
                   <label>Contact No.</label>
                   <asp:TextBox ID="contactno" placeholder="" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
               </div>
                     <div class="col-4">
                   <label>Email Id</label>
                   <asp:TextBox ID="emailid" placeholder="" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
               </div>
           </div>
                
                <div class="row">
               <div class="col-4">
                   <label>State</label>
                   <asp:TextBox ID="statename" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
               </div>
                    <div class="col-4">
                   <label>City</label>
                   <asp:TextBox ID="cityname" placeholder="" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
               </div>
                     <div class="col-4">
                   <label>Pin Code</label>
                   <asp:TextBox ID="pincode" placeholder="" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
               </div>
           </div>
                 <div class="row">
                    <div class="col">
                        <label>Full Address</label>
                        <asp:TextBox ID="fulladdress" runat="server" CssClass="form-control" TextMode="MultiLine" ReadOnly="true"></asp:TextBox>
                    </div>
           </div>
                <br />
                <div class="row">
                    <div class="col">
                        <asp:Button ID="dltbtn" runat="server" CssClass="btn btn-danger btn-lg btn-block" Text="Delete User Permanently" OnClick="dltbtn_Click"/>
                    </div>
           </div>
            </div>
        </div>
                <a href="Homepage.aspx">Go to Home</a>
        </div>
    

            <div class="col-7">
            <div class="card">
            <div class="card-body">
                <div class="row">
               <div class="col">
                   <center><h1>Members Lists</h1></center>
               </div>
           </div>
                <div class="row">
                    <div class="col">
                        <hr />
                    </div>
                </div>

                <div class="row">
                    <div class="col">
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:libraryDBConnectionString %>" SelectCommand="SELECT [first_name], [contact_no], [email], [member_id], [account_status] FROM [member_master_tbl]"></asp:SqlDataSource>
                        <asp:GridView ID="GridView1" runat="server" Class="table table-striped table-bordered table-dark" AutoGenerateColumns="False" DataKeyNames="member_id" DataSourceID="SqlDataSource1" Width="100%"  >
                            <Columns>
                                <asp:BoundField DataField="member_id" HeaderText="Member ID" SortExpression="member_id" ReadOnly="True" />
                                <asp:BoundField DataField="first_name" HeaderText="Name" SortExpression="first_name" />
                                <asp:BoundField DataField="contact_no" HeaderText="Contact No." SortExpression="contact_no" />
                                <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                                <asp:BoundField DataField="account_status" HeaderText="Account Status" SortExpression="account_status" />
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
