<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmAdminHomePage.aspx.cs" Inherits="TaskAssignmentApp.frmAdminHomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 26px;
        }
        .auto-style3 {
            width: 337px;
        }
        .auto-style4 {
            height: 26px;
            width: 337px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style3">
                        <asp:Button ID="btnViewUserOptions" runat="server" Text="Manage User" OnClick="btnViewUserOptions_Click" Width="213px" />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2"></td>
                    <td class="auto-style4"></td>
                    <td class="auto-style2"></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style3">
                        <asp:Button ID="btnAssignViewTask" runat="server" Text="Task Management" Width="211px" OnClick="btnAssignViewTask_Click" />
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/frmLogin.aspx">Logout</asp:HyperLink>
                    </td>
                </tr>
            </table>
        </div>
        <asp:Panel ID="Panel1" runat="server">
            <div>
            <table class="auto-style1">
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:Button ID="btnAddUser" runat="server" Text="Add User" Width="166px" OnClick="btnAddUser_Click" />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="btnEditRemoveUser" runat="server" OnClick="btnEditRemoveUser_Click" Text="Edit/Remove User" Width="164px" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
        </asp:Panel>
    </form>
</body>
</html>
