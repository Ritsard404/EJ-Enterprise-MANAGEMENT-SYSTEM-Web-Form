<%@ Page Title="" Language="C#" MasterPageFile="~/Navigation.Master" AutoEventWireup="true" CodeBehind="employeePage.aspx.cs" Inherits="EJ_Enterprise_MANAGEMENT_SYSTEM.WebForm2" EnableEventValidation="false" %>
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
                                <img width="100px" src="imgs/employees.png" />
                            </center>
                        </div>
                        <div class="row">
                            <center>
                                <h3>New Employee</h3>
                            </center>
                        </div>
                        <div class="row">
                                <hr>
                        </div>
                        <div class="row">
                            <div class="col-6">
                                <div class="wave-group">
                                <input id="empname" type="text" runat="server" class="input" />
                                    <span class="bar"></span>
                                    <label class="label">
                                        <span class="label-char" style="--index: 0">N</span>
                                        <span class="label-char" style="--index: 1">a</span>
                                        <span class="label-char" style="--index: 2">m</span>
                                        <span class="label-char" style="--index: 3">e</span>
                                    </label>
                                </div>
                            </div>
                            <div class="col-6">
                                <div class="wave-group">
                                <input id="txtpassword" type="password" runat="server" class="input" />
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
                        </div><br />
                        <div class="row">
                            <div class="text-end">
                                <asp:Button ID="register" runat="server" Text="Register" class="btn btn-primary" ValidationGroup="register" OnClientClick="return confirm('Click okay to register new employee.');" OnClick="register_Click" />
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
                                <h3>Update Employee</h3>
                            </center>
                        </div>
                        <div class="row">
                            <hr>
                        </div>
                        <div class="row">
                            <div class="col-4">
                                <div class="wave-group">
                                    <input id="EmpId" type="text" runat="server" class="input" />
                                    <span class="bar"></span>
                                    <label class="label">
                                        <span class="label-char" style="--index: 0">I</span>
                                        <span class="label-char" style="--index: 1">D</span>
                                    </label>
                                </div>
                            </div>
                        </div><br />
                        <div class="row">
                            <div class="col-6">
                                <div class="wave-group">
                                    <input id="UpdateName" type="text" runat="server" class="input" />
                                    <span class="bar"></span>
                                    <label class="label">
                                        <span class="label-char" style="--index: 0">N</span>
                                        <span class="label-char" style="--index: 1">a</span>
                                        <span class="label-char" style="--index: 2">m</span>
                                        <span class="label-char" style="--index: 3">e</span>
                                    </label>
                                </div>
                            </div>
                            <div class="col-6">
                                <div class="wave-group">
                                    <input id="UpdatePass" type="password" runat="server" class="input" />
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
                            <asp:Button ID="Update" runat="server" Text="Update" class="btn btn-info" ValidationGroup="register" OnClientClick="return confirm('Click okay to update employee information.');" OnClick="Update_Click" />
                        </div>
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
                        <h3>Employee List</h3>
                    </center>
                </div>
                <div class="row">
                        <hr>
                </div>
                <div class="row">
                    <asp:GridView ID="empList" CssClass="table table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="emp_id" DataSourceID="SqlDataSource1" EmptyDataText="No employee">
                        <Columns>
                            <asp:BoundField DataField="emp_id" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="emp_id" />
                            <asp:BoundField DataField="emp_name" HeaderText="Name" SortExpression="emp_name" />
                            <asp:BoundField DataField="emp_status" HeaderText="Status" SortExpression="emp_status" />
                            <asp:BoundField DataField="create_at" HeaderText="Created" SortExpression="create_at" />
                            <asp:BoundField DataField="update_at" HeaderText="Updated" SortExpression="update_at" />
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:Button ID="SuspendEmp" runat="server" Text="Suspend" class="btn btn-success" OnClick="SuspendEmp_Click" OnClientClick="return confirm('Are you sure you want to suspend this employee?');" Visible='<%# IsActive(Eval("emp_status").ToString()) %>' />
                                    <asp:Button ID="Unsuspend" runat="server" Text="Unsuspend" class="btn btn-warning" OnClick="Unsuspend_Click" OnClientClick="return confirm('Are you sure you want to unsuspend this employee?');" Visible='<%# IsSuspended(Eval("emp_status").ToString()) %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Remove">
                                <ItemTemplate>
                                    <asp:Button ID="Remove" runat="server" Text="Remove" class="btn btn-danger" OnClick="Remove_Click" OnClientClick="return confirm('Are you sure you want to remove this employee?');" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="row">
                        <hr>
                </div>
                <div class="row">

                </div>
            </div>
        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:con %>" SelectCommand="SELECT [emp_id], [emp_name], [create_at], [update_at], [emp_status] FROM [employee] WHERE ([emp_status] &lt;&gt; @emp_status) ORDER BY [emp_status], [emp_id]">
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="Inactive" Name="emp_status" QueryStringField="Inactive" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>

</asp:Content>
