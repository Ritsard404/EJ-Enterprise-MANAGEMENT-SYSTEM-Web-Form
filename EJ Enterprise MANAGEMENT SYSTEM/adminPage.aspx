<%@ Page Title="" Language="C#" MasterPageFile="~/Navigation.Master" AutoEventWireup="true" CodeBehind="adminPage.aspx.cs" Inherits="EJ_Enterprise_MANAGEMENT_SYSTEM.adminPage" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <center>
                                <img width="100px" src="imgs/admins.png" />
                            </center>
                        </div>
                        <div class="row">
                            <center>
                                <h3>New Admin</h3>
                            </center>
                        </div>
                        <div class="row">
                            <hr>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="wave-group">
                                    <input id="adminfname" type="text" runat="server" class="input" />
                                    <span class="bar"></span>
                                    <label class="label">
                                        <span class="label-char" style="--index: 0">F</span>
                                        <span class="label-char" style="--index: 1">i</span>
                                        <span class="label-char" style="--index: 2">r</span>
                                        <span class="label-char" style="--index: 3">s</span>
                                        <span class="label-char" style="--index: 4">t</span>
                                        <span class="label-char" style="--index: 5"></span>
                                        <span class="label-char" style="--index: 6">N</span>
                                        <span class="label-char" style="--index: 7">a</span>
                                        <span class="label-char" style="--index: 8">m</span>
                                        <span class="label-char" style="--index: 9">e</span>
                                    </label>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="wave-group">
                                    <input id="adminlname" type="text" runat="server" class="input" />
                                    <span class="bar"></span>
                                    <label class="label">
                                        <span class="label-char" style="--index: 0">L</span>
                                        <span class="label-char" style="--index: 1">a</span>
                                        <span class="label-char" style="--index: 2">s</span>
                                        <span class="label-char" style="--index: 3">t</span>
                                        <span class="label-char" style="--index: 4"></span>
                                        <span class="label-char" style="--index: 5">N</span>
                                        <span class="label-char" style="--index: 6">a</span>
                                        <span class="label-char" style="--index: 7">m</span>
                                        <span class="label-char" style="--index: 8">e</span>
                                    </label>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-6">
                                <div class="wave-group">
                                    <input id="admincontact" type="text" runat="server" class="input" />
                                    <span class="bar"></span>
                                    <label class="label">
                                        <span class="label-char" style="--index: 0">C</span>
                                        <span class="label-char" style="--index: 1">o</span>
                                        <span class="label-char" style="--index: 2">n</span>
                                        <span class="label-char" style="--index: 3">t</span>
                                        <span class="label-char" style="--index: 4">a</span>
                                        <span class="label-char" style="--index: 5">c</span>
                                        <span class="label-char" style="--index: 6">t</span>
                                    </label>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="wave-group">
                                    <input id="adminpass" type="password" runat="server" class="input" />
                                    <span class="bar"></span>
                                    <label class="label">
                                        <span class="label-char" style="--index: 0">P</span>
                                        <span class="label-char" style="--index: 1">a</span>
                                        <span class="label-char" style="--index: 2">s</span>
                                        <span class="label-char" style="--index: 3">s</span>
                                        <span class="label-char" style="--index: 4">w</span>
                                        <span class="label-char" style="--index: 5">o</span>
                                        <span class="label-char" style="--index: 6">r</span>
                                        <span class="label-char" style="--index: 7">d</span>
                                    </label>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="text-end">
                                <asp:Button ID="register" runat="server" Text="Register" class="btn btn-primary" ValidationGroup="register" OnClientClick="return confirm('Click okay to register admin.');" OnClick="register_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <center>
                                <img width="100px" src="imgs/Update.png" />
                            </center>
                        </div>
                        <div class="row">
                            <center>
                                <h3>Update Admin</h3>
                            </center>
                        </div>
                        <div class="row">
                            <hr>
                        </div>
                        <div class="row">
                            <div class="col-6">
                                <div class="wave-group">
                                    <input id="AdminId" type="text" runat="server" class="input" />
                                    <span class="bar"></span>
                                    <label class="label">
                                        <span class="label-char" style="--index: 0">I</span>
                                        <span class="label-char" style="--index: 1">D</span>
                                    </label>
                                </div>
                            </div>
                        </div><br />
                        <div class="row">
                            <div class="col-md-6">
                                <div class="wave-group">
                                    <input id="Updateadminfname" type="text" runat="server" class="input" />
                                    <span class="bar"></span>
                                    <label class="label">
                                        <span class="label-char" style="--index: 0">F</span>
                                        <span class="label-char" style="--index: 1">i</span>
                                        <span class="label-char" style="--index: 2">r</span>
                                        <span class="label-char" style="--index: 3">s</span>
                                        <span class="label-char" style="--index: 4">t</span>
                                        <span class="label-char" style="--index: 5"></span>
                                        <span class="label-char" style="--index: 6">N</span>
                                        <span class="label-char" style="--index: 7">a</span>
                                        <span class="label-char" style="--index: 8">m</span>
                                        <span class="label-char" style="--index: 9">e</span>
                                    </label>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="wave-group">
                                    <input id="Updateadminlname" type="text" runat="server" class="input" />
                                    <span class="bar"></span>
                                    <label class="label">
                                        <span class="label-char" style="--index: 0">L</span>
                                        <span class="label-char" style="--index: 1">a</span>
                                        <span class="label-char" style="--index: 2">s</span>
                                        <span class="label-char" style="--index: 3">t</span>
                                        <span class="label-char" style="--index: 4"></span>
                                        <span class="label-char" style="--index: 5">N</span>
                                        <span class="label-char" style="--index: 6">a</span>
                                        <span class="label-char" style="--index: 7">m</span>
                                        <span class="label-char" style="--index: 8">e</span>
                                    </label>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-6">
                                <div class="wave-group">
                                    <input id="Updateadmincontact" type="text" runat="server" class="input" />
                                    <span class="bar"></span>
                                    <label class="label">
                                        <span class="label-char" style="--index: 0">C</span>
                                        <span class="label-char" style="--index: 1">o</span>
                                        <span class="label-char" style="--index: 2">n</span>
                                        <span class="label-char" style="--index: 3">t</span>
                                        <span class="label-char" style="--index: 4">a</span>
                                        <span class="label-char" style="--index: 5">c</span>
                                        <span class="label-char" style="--index: 6">t</span>
                                    </label>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="wave-group">
                                    <input id="Updateadminpass" type="password" runat="server" class="input" />
                                    <span class="bar"></span>
                                    <label class="label">
                                        <span class="label-char" style="--index: 0">P</span>
                                        <span class="label-char" style="--index: 1">a</span>
                                        <span class="label-char" style="--index: 2">s</span>
                                        <span class="label-char" style="--index: 3">s</span>
                                        <span class="label-char" style="--index: 4">w</span>
                                        <span class="label-char" style="--index: 5">o</span>
                                        <span class="label-char" style="--index: 6">r</span>
                                        <span class="label-char" style="--index: 7">d</span>
                                    </label>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="text-end">
                                <asp:Button ID="Update" runat="server" Text="Update" class="btn btn-info" ValidationGroup="register" OnClientClick="return confirm('Click okay to register admin.');" OnClick="Update_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
    </div><br />

    <div class="container">
        <div class="card">
            <div class="card-body">
                <div class="row">
                    <center>
                        <h3>Admin List</h3>
                    </center>
                </div>
                <div class="row">
                        <hr>
                </div>
                <div class="row">
                    <asp:GridView ID="adminList" runat="server" class="table table-hover" AutoGenerateColumns="False" DataKeyNames="admin_id" DataSourceID="SqlDataSource1">
                        <Columns>
                            <asp:BoundField DataField="admin_id" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="admin_id" />
                            <asp:BoundField DataField="admin_fname" HeaderText="First Name" SortExpression="admin_fname" />
                            <asp:BoundField DataField="admin_lname" HeaderText="Last Name" SortExpression="admin_lname" />
                            <asp:BoundField DataField="admin_contact" HeaderText="Contact" SortExpression="admin_contact" />
                            <asp:BoundField DataField="admin_status" HeaderText="Status" SortExpression="admin_status" />
                            <asp:BoundField DataField="create_at" HeaderText="Created" SortExpression="create_at" />
                            <asp:BoundField DataField="update_at" HeaderText="Updated" SortExpression="update_at" />
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:Button ID="Suspendadmin" runat="server" Text="Suspend" class="btn btn-success" OnClick="Suspendadmin_Click" OnClientClick="return confirm('Are you sure you want to suspend this admin?');" Visible='<%# IsActive(Eval("admin_status").ToString()) %>' />
                                    <asp:Button ID="Unsuspendadmin" runat="server" Text="Unsuspend" class="btn btn-warning" OnClick="Unsuspend_Click" OnClientClick="return confirm('Are you sure you want to unsuspend this admin?');" Visible='<%# IsSuspended(Eval("admin_status").ToString()) %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Remove">
                                <ItemTemplate>
                                    <asp:Button ID="Remove" runat="server" Text="Remove" class="btn btn-danger" OnClick="Remove_Click" OnClientClick="return confirm('Are you sure you want to remove this Admin?');" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:con %>" SelectCommand="SELECT [admin_id], [admin_fname], [admin_lname], [admin_contact], [admin_status], [create_at], [update_at] FROM [admin] WHERE ([admin_status] &lt;&gt; @admin_status) ORDER BY [admin_status], [admin_id]">
                        <SelectParameters>
                            <asp:QueryStringParameter DefaultValue="Inactive" Name="admin_status" QueryStringField="Inactive" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
