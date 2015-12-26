<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="SampleApp.MyEmployee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <asp:ScriptManager ScriptMode="" ></asp:ScriptManager>
    <form id="form1" runat="server">
        <h1>Welcome</h1>
        <div>
            <table width="100%">
                <tr height="30Px">
                    <td></td>
                </tr>
                <tr align="center">
                    <td>
                        <asp:Label ID="lblErrorMessage" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td align="center">
                        <table border="1" cellpadding="0" cellspacing="0" width="500Px">
                            <tr bgcolor="lightgreen">
                                <td colspan="3" align="center"><b>Employee Form</b></td>
                            </tr>
                            <tr>
                                <td>
                                    <table width="100%">
                                        <tr>
                                            <td align="right">Employee Id</td>
                                            <td>:</td>
                                            <td align="center">
                                                <asp:TextBox ID="txtEmployeeId" runat="server" Enabled="false"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td align="right">Employee Name</td>
                                            <td>:</td>
                                            <td align="center">
                                                <asp:TextBox ID="txtEmployeeName" runat="server" MaxLength="100" ></asp:TextBox><br />
                                                <asp:RequiredFieldValidator ID="reqNameValidator" runat="server" ControlToValidate="txtEmployeeName" ErrorMessage="Employee Name Required." ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                             </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblDesignation" runat="server" Text="Designation"></asp:Label></td>
                                            <td>:</td>
                                            <td align="center">
                                                <asp:TextBox ID="txtDesignation" runat="server" MaxLength="100"></asp:TextBox><br />
                                                 <asp:RequiredFieldValidator ID="reqDesignationValidator" runat="server" ControlToValidate="txtDesignation" ErrorMessage="Designation Required." ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" align="center">
                                                <asp:Button ID="btnSubmit" runat="server" Text="Add Employee" OnClick="btnSubmit_Click" />
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"/>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>

                        <br />
                        Employees
                        <hr  style="width:500px;"/>
            <table width="500Px">
                <tr>
                    <td>
                        <asp:GridView runat="server" ID="grdEmployees" AutoGenerateColumns="False" Width="100%"
                             OnRowCommand="grdEmployees_RowCommand" DataKeyNames="EmpID">
                            <Columns>
                                <asp:BoundField HeaderText="Employee ID" DataField="EmpID" />
                                <asp:BoundField HeaderText="Employee Name" DataField="EmpName" />
                                <asp:BoundField HeaderText="Designation" DataField="Designation" />
                                <asp:ButtonField HeaderText="Edit" CommandName="EditEmployee" Text="Edit"/>
                                <asp:ButtonField HeaderText="Delete" CommandName="DeleteEmployee" Text="Delete" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
