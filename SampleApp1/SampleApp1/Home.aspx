<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="SampleApp1.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
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
                                <td colspan="3" align="center"><b>Department Form</b></td>
                            </tr>
                            <tr>
                                <td>
                                    <table width="100%">
                                        <tr>
                                            <td align="right">Department Id</td>
                                            <td>:</td>
                                            <td align="center">
                                                <asp:TextBox ID="txtDepartmentId" runat="server" Enabled="false"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td align="right">Department Name</td>
                                            <td>:</td>
                                            <td align="center">
                                                <asp:TextBox ID="txtDepartmentName" runat="server" MaxLength="100"></asp:TextBox><br />

                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblLocation" runat="server" Text="Location"></asp:Label></td>
                                            <td>:</td>
                                            <td align="center">
                                                <asp:TextBox ID="txtLocation" runat="server" MaxLength="100"></asp:TextBox><br />

                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" align="center">
                                                <asp:Button ID="btnSubmit" runat="server" Text="Add Department" OnClick="btnSubmit_Click" />
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>

                        <br />
                        Departments
                        <hr style="width: 500px;" />
                        <table width="500Px">
                            <tr>
                                <td>
                                    <asp:GridView runat="server" ID="grdDepartments" AutoGenerateColumns="False" Width="100%"
                                        OnRowCommand="grdDepartments_RowCommand" DataKeyNames="DeptID">
                                        <Columns>
                                            <asp:BoundField HeaderText="Department ID" DataField="DeptID" />
                                            <asp:BoundField HeaderText="Department Name" DataField="DeptName" />
                                            <asp:BoundField HeaderText="Location" DataField="Location" />
                                            <asp:ButtonField HeaderText="Edit" CommandName="EditDepartment" Text="Edit" />
                                            <asp:ButtonField HeaderText="Delete" CommandName="DeleteDepartment" Text="Delete" />
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
