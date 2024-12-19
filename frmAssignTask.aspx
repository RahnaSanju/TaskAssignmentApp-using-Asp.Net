<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmAssignTask.aspx.cs" Inherits="TaskAssignmentApp.frmAssignTask" %>

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
    </style>
</head>
<body>
    <form id="form1" runat="server">
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
                <asp:Label ID="Label1" runat="server" Text="Task"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>
                <asp:DropDownList ID="ddlTask" runat="server" Width="187px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Description"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>
                <asp:TextBox ID="txtDescription" runat="server" Height="101px" TextMode="MultiLine" Width="321px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2"></td>
            <td class="auto-style2"></td>
            <td class="auto-style2"></td>
            <td class="auto-style2"></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Assigned To"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>
                <asp:DropDownList ID="ddlAssignedTo" runat="server" Height="16px" Width="197px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Set Priority"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>
                <asp:DropDownList ID="ddlPriority" runat="server" Height="20px" Width="197px">
                    <asp:ListItem>Low</asp:ListItem>
                    <asp:ListItem>Medium</asp:ListItem>
                    <asp:ListItem>High</asp:ListItem>
                    <asp:ListItem>Critical</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Status"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>
                <asp:DropDownList ID="ddlStatus" runat="server" Height="19px" Width="199px">
                    <asp:ListItem>To do</asp:ListItem>
                    <asp:ListItem>In progress</asp:ListItem>
                    <asp:ListItem>Review</asp:ListItem>
                    <asp:ListItem>Done</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Due Date"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>
                <asp:Calendar ID="cldEditDuedate" runat="server"></asp:Calendar>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="Label7" runat="server" Text="Comment"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>
                <asp:TextBox ID="txtEditComment" runat="server" Height="110px" TextMode="MultiLine" Width="333px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="Label8" runat="server" Text="Upload File"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" Width="336px" />
            </td>
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
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" Width="126px" />
            </td>
        </tr>
        <tr>
            <td class="auto-style2"></td>
            <td class="auto-style2"></td>
            <td class="auto-style2"></td>
            <td class="auto-style2"></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="lblDisplay" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/frmManagerHomePage.aspx">Go Back to Home Page</asp:HyperLink>
            </td>
        </tr>
    </table>
        
        </div>
    </form>
</body>
</html>
