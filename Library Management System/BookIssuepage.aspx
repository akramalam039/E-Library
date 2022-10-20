<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="BookIssuepage.aspx.cs" Inherits="Library_Management_System.BookIssuepage" %>
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
                   <center><h3>Book Issuing</h3></center>
               </div>
           </div>
                <div class="row">
               <div class="col">
                   <center><img src="Images/books.png" width="100"/></center>
               </div>
           </div>
                <div class="row">
               <div class="col-6">
                   <label>Member ID</label>
                   <asp:TextBox ID="memberid" placeholder="ID" class="form-control" runat="server"></asp:TextBox>
               </div>
                    <div class="col-6">
                    <label>Book ID</label>
                        <div class="input-group">
                            <asp:TextBox ID="bookid"  placeholder="Book Id" class="form-control" runat="server"></asp:TextBox>
                            <asp:Button ID="gobtn" runat="server" class="btn btn-primary btn-dark" Text="Go" OnClick="gobtn_Click" />
                        </div>
                   
               </div>
           </div>
                
                <div class="row">
               <div class="col-6">
                   <label>Member Name</label>
                   <asp:TextBox ID="membername" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
               </div>
                    <div class="col-6">
                   <label>Book Name</label>
                   <asp:TextBox ID="bookname" placeholder="" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
               </div>
           </div>
                
                <div class="row">
               <div class="col-6">
                   <label>Start Date</label>
                   <asp:TextBox ID="startdate" TextMode="Date" placeholder="Start Date" class="form-control" runat="server"></asp:TextBox>
               </div>
                    <div class="col-6">
                   <label>End Date</label>
                   <asp:TextBox ID="enddate" TextMode="Date" placeholder="End Date" class="form-control" runat="server"></asp:TextBox>
               </div>
           </div>
                <br />
                <div class="row">
               <div class="col-6">
                   <asp:Button ID="issuebtn" runat="server" CssClass="btn btn-primary btn-lg btn-block" Text="Issue" OnClick="issuebtn_Click" />
                   
               </div>
                    <div class="col-6">
                        <asp:Button ID="returnbtn" CssClass="btn btn-success btn-lg btn-block" runat="server" Text="Return" OnClick="returnbtn_Click"/>
                   
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
                   <center><h1>Issued Books Lists</h1></center>
               </div>
           </div>
                <div class="row">
                    <div class="col">
                        <hr />
                    </div>
                </div>

                <div class="row">
                    <div class="col">
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:libraryDBConnectionString %>" SelectCommand="SELECT * FROM [book_issue_tbl]"></asp:SqlDataSource>
                        <asp:GridView ID="GridView1" runat="server" Class="table table-striped table-bordered table-dark" AutoGenerateColumns="False" DataKeyNames="member_id" DataSourceID="SqlDataSource1" OnRowDataBound="GridView1_RowDataBound"  >
                            <Columns>
                                <asp:BoundField DataField="member_id" HeaderText="Member ID" ReadOnly="True" SortExpression="member_id" />
                                <asp:BoundField DataField="member_name" HeaderText="Name" SortExpression="member_name" />
                                <asp:BoundField DataField="book_id" HeaderText="Book ID" SortExpression="book_id" />
                                <asp:BoundField DataField="book_name" HeaderText="Book Name" SortExpression="book_name" />
                                <asp:BoundField DataField="issue_date" HeaderText="Issue Date" SortExpression="issue_date" />
                                <asp:BoundField DataField="due_date" HeaderText="Return Date" SortExpression="due_date" />
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
