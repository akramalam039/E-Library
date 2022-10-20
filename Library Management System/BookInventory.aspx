<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="BookInventory.aspx.cs" Inherits="Library_Management_System.BookInventory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#imgview').attr('src', e.target.result);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>
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
                                <center><h3>Book Details</h3></center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center><img id="imgview" src="BooksImg/books.png" height="150px" width="100px"/></center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:FileUpload ID="file" runat="server" onchange="readURL(this)" CssClass="form-control" />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-4">
                                <label>Book ID</label>
                                <div class="input-group">
                                    <asp:TextBox ID="bookid" placeholder="ID" class="form-control" required runat="server"></asp:TextBox>
                                    <asp:Button ID="Gobtn" runat="server" class="btn btn-success" Text="Go" OnClick="Gobtn_Click" />
                                </div>

                            </div>
                            <div class="col-8">
                                <label>Book Name</label>
                                <asp:TextBox ID="bookname" placeholder="Book Name" class="form-control" runat="server"></asp:TextBox>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-4">
                                <div class="form-group">
                                    <label>Language</label>
                                    <asp:DropDownList ID="LanguageList" class="form-control" runat="server">
                                        <asp:ListItem Text="English" Value="English" />
                                        <asp:ListItem Text="Hindi" Value="Hindi" />
                                        <asp:ListItem Text="Punjabi" Value="Punjabi" />
                                        <asp:ListItem Text="Gujrati" Value="Gujrati" />
                                        <asp:ListItem Text="Chinies" Value="Chinies" />

                                    </asp:DropDownList>
                                    <label>Publisher Name</label>
                                    <asp:SqlDataSource ID="SqlDataSource2pub" runat="server" ConnectionString="<%$ ConnectionStrings:libraryDBConnectionString %>" SelectCommand="SELECT [publisher_name] FROM [publisher_table]"></asp:SqlDataSource>
                                    <asp:DropDownList ID="publishernameList" class="form-control" runat="server" DataSourceID="SqlDataSource2pub" DataTextField="publisher_name" DataValueField="publisher_name">
                                        
                                    </asp:DropDownList>
                                </div>

                            </div>
                            <div class="col-4">
                                <div class="form-group">
                                    <label>Author Name</label>
                                    <asp:SqlDataSource ID="SqlDataSource2auname" runat="server" ConnectionString="<%$ ConnectionStrings:libraryDBConnectionString %>" SelectCommand="SELECT [auther_name] FROM [author_table]"></asp:SqlDataSource>
                                    <asp:DropDownList ID="authornamelist" class="form-control" runat="server" DataSourceID="SqlDataSource2auname" DataTextField="auther_name" DataValueField="auther_name">
                                        
                                    </asp:DropDownList>
                                    <label>Publish Date</label>
                                    <asp:TextBox ID="publishdate" TextMode="Date" class="form-control" runat="server"></asp:TextBox>
                                </div>

                            </div>
                            <div class="col-4">
                                <label>Genere</label>
                                <asp:ListBox ID="generebox" class="form-control" SelectionMode="Multiple" runat="server">
                                    <asp:ListItem Text="Adventure" Value="Adventure" />
                                    <asp:ListItem Text="Comedy" Value="Comedy" />
                                    <asp:ListItem Text="Horor" Value="Horor" />
                                    <asp:ListItem Text="Motivational" Value="Motivational" />
                                    <asp:ListItem Text="Action" Value="Action" />
                                    <asp:ListItem Text="Crime" Value="Crime" />
                                    <asp:ListItem Text="Thrill" Value="Thrill" />
                                    <asp:ListItem Text="Poetry" Value="Poetry" />
                                    <asp:ListItem Text="AutoBiography" Value="AutoBiography" />
                                </asp:ListBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-4">
                                <label>Edition</label>
                                <asp:TextBox ID="bookedition" placeholder="Book Edition" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-4">
                                <label>Cost (Per Unit)</label>
                                <asp:TextBox ID="bookcost" placeholder="Book Cost" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-4">
                                <label>Pages</label>
                                <asp:TextBox ID="bookpage" placeholder="Book Pages" class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-4">
                                <label>Actual Stock</label>
                                <asp:TextBox ID="actualstock" placeholder="Actual Stock" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-4">
                                <label>Current Stocks</label>
                                <asp:TextBox ID="currentstock" placeholder="Current Stock" class="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-4">
                                <label>Issued Books</label>
                                <asp:TextBox ID="issuebook" placeholder="Issued Book" class="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <label>Description of Book</label>
                                <asp:TextBox ID="bookdescription" placeholder="About Book a brief Description...." rows="4" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-4">
                                <asp:Button ID="Addbtn" runat="server" CssClass="btn btn-primary btn-lg btn-block" Text="Add" OnClick="Addbt_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button ID="Updatebtn" runat="server" CssClass="btn btn-warning btn-lg btn-block" Text="Update" OnClick="Updatebtn_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button ID="Deletebtn" runat="server" CssClass="btn btn-danger btn-lg btn-block" Text="Delete" OnClick="Deletebtn_Click" />
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
                                <center><h1>Book Inventory List</h1></center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:libraryDBConnectionString %>" SelectCommand="SELECT * FROM [book_master_tbl]"></asp:SqlDataSource>
                                <asp:GridView ID="GridView1" runat="server" Class="table table-striped table-bordered" AutoGenerateColumns="False" DataKeyNames="book_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="book_id" HeaderText="ID" ReadOnly="True" SortExpression="book_id" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                               <div class="container-fluid">
                                                   <div class="row">
                                                       <div class="col-lg-10">
                                                           <div class="row">
                                                               <div class="col-12">
                                                                   <asp:Label ID="Label1" runat="server" Text='<%# Eval("book_name") %>' Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                                               </div>
                                                           </div>

                                                           <div class="row">
                                                               <div class="col-12">

                                                                   Author- <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("author_name") %>'></asp:Label>
                                                                   &nbsp;| Genre- <asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("genre") %>'></asp:Label>
                                                                   &nbsp;| Languate- <asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("langugage") %>'></asp:Label>

                                                               </div>
                                                           </div>

                                                           <div class="row">
                                                               <div class="col-12">

                                                                   Publisher-&nbsp;
                                                                   <asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("publisher_name") %>'></asp:Label>
                                                                   &nbsp;| Publish Date-
                                                                   <asp:Label ID="Label6" runat="server" Font-Bold="True" Text='<%# Eval("publish_date") %>'></asp:Label>
                                                                   &nbsp;| Pages-
                                                                   <asp:Label ID="Label7" runat="server" Font-Bold="True" Text='<%# Eval("no_of_page") %>'></asp:Label>
                                                                   &nbsp;| Edition-
                                                                   <asp:Label ID="Label8" runat="server" Font-Bold="True" Text='<%# Eval("edition") %>'></asp:Label>

                                                               </div>
                                                           </div>

                                                           <div class="row">
                                                               <div class="col-12">

                                                                   Cost-
                                                                   <asp:Label ID="Label9" runat="server" Font-Bold="True" Text='<%# Eval("book_cost") %>'></asp:Label>
                                                                   &nbsp;| Actual Stock-
                                                                   <asp:Label ID="Label10" runat="server" Font-Bold="True" Text='<%# Eval("actual_stock") %>'></asp:Label>
                                                                   &nbsp;| Available-
                                                                   <asp:Label ID="Label11" runat="server" Font-Bold="True" Text='<%# Eval("current_stock") %>'></asp:Label>

                                                               </div>
                                                           </div>

                                                           <div class="row">
                                                               <div class="col-12">

                                                                   Description-<asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Italic="True" Text='<%# Eval("book_description") %>'></asp:Label>

                                                               </div>
                                                           </div>
                                                       </div>
                                                       <div class="col-lg-2">
                                                           <asp:Image Class="img-fluid" ID="Image1" runat="server" ImageUrl='<%# Eval("book_img_link") %>' />
                                                       </div>
                                                   </div>
                                               </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>



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
