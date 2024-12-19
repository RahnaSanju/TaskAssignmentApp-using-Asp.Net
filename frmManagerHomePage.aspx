<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmManagerHomePage.aspx.cs" Inherits="TaskAssignmentApp.frmManagerHomePage" %>

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
            margin-left: 0px;
        }
        .auto-style4 {
            width: 238px;
        }
        .auto-style5 {
            height: 26px;
            width: 238px;
        }
        .auto-style6 {
            height: 156px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style4">
                        <asp:Button ID="btnCreateEditTask" runat="server" OnClick="btnCreateEditTask_Click" Text="Manage Tasks" Width="204px" />
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2"></td>
                    <td class="auto-style5"></td>
                    <td class="auto-style2"></td>
                    <td class="auto-style2"></td>
                    <td class="auto-style2"></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style4">
                        <asp:Button ID="btnAssignTask" runat="server" Text="Assign Task" Width="204px" OnClick="btnAssignTask_Click" />
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style4">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style4">
                        <asp:Button ID="btEditViewTask" runat="server" Text="Edit/View Assigned Task" Width="204px" OnClick="btEditViewTask_Click" CssClass="auto-style3" />
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/frmLogin.aspx">Logout</asp:HyperLink>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

