<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmUserHomePage.aspx.cs" Inherits="TaskAssignmentApp.frmUserHomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 797px;
        }
        .auto-style3 {
            width: 146px;
        }
        .auto-style5 {
            width: 289px;
        }
        .auto-style6 {
            width: 57px;
        }
        .auto-style7 {
            height: 26px;
        }
        .auto-style8 {
            width: 289px;
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7"></td>
                <td class="auto-style8">
                    <asp:Label ID="Label6" runat="server" Text="View Tasks By"></asp:Label>
                </td>
                <td class="auto-style7"></td>
                <td class="auto-style7">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/frmLogin.aspx">Logout</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style5">
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                        <asp:ListItem>Assigned By</asp:ListItem>
                        <asp:ListItem>Due Date</asp:ListItem>
                        <asp:ListItem>Task</asp:ListItem>
                        <asp:ListItem>Priority</asp:ListItem>
                        <asp:ListItem>Status</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
                <td>
                    <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" Text="OK" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style6">
                        &nbsp;</td>
                    <td class="auto-style3">
                        <asp:Label ID="Label1" runat="server" Text="Assigned By"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlAssignedBy" runat="server">
                    </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">
                        &nbsp;</td>
                    <td class="auto-style3">
                        <asp:Label ID="Label2" runat="server" Text="Due Date"></asp:Label>
                    </td>
                    <td>
                        <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">
                        &nbsp;</td>
                    <td class="auto-style3">
                        <asp:Label ID="Label3" runat="server" Text="Task"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlTask" runat="server" Width="187px">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">
                        &nbsp;</td>
                    <td class="auto-style3">
                        <asp:Label ID="Label4" runat="server" Text="Priority"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlPriority" runat="server" Height="20px" Width="197px">
                            <asp:ListItem>Low</asp:ListItem>
                            <asp:ListItem>Medium</asp:ListItem>
                            <asp:ListItem>High</asp:ListItem>
                            <asp:ListItem>Critical</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">
                        &nbsp;</td>
                    <td class="auto-style3">
                        <asp:Label ID="Label5" runat="server" Text="Status"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlStatus" runat="server" Height="19px" Width="199px">
                        <asp:ListItem>To do</asp:ListItem>
                        <asp:ListItem>In progress</asp:ListItem>
                        <asp:ListItem>Review</asp:ListItem>
                        <asp:ListItem>Done</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>
                        <asp:Button ID="btnSearch" runat="server" Text="Search" Font-Bold="True" OnClick="btnSearch_Click" />
                    </td>
                    <td>
                <asp:Label ID="lblDisplay1" runat="server" ForeColor="#FF3300"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
        <div>
            <table>

            </table>
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="1131px" AllowPaging="True" CssClass="auto-style10" Height="179px" OnPageIndexChanging="GridView1_PageIndexChanging">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lbUpdate" runat="server" CommandArgument='<%# Eval("AssignId") %>' OnCommand="lbUpdate_Command">Update</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="AssignId" HeaderText="Assign Id" Visible="False" />
                <asp:BoundField DataField="Taskname" HeaderText="Task" />
                <asp:BoundField DataField="Name" HeaderText="Assigned By" />
                <asp:BoundField DataField="Description" HeaderText="Description" />
                <asp:BoundField DataField="Duedate" HeaderText="Due date" />
                <asp:BoundField DataField="comment" HeaderText="Comment" />
                <asp:BoundField DataField="Priority" HeaderText="Priority" />
                <asp:BoundField DataField="Status" HeaderText="Status" />
                <asp:BoundField DataField="FileRef" HeaderText="File Uploaded" />
            </Columns>
        </asp:GridView>
        <asp:Panel ID="Panel1" runat="server">
        <div>
    <table class="auto-style1">
        <tr>
            <td class="auto-style9">&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style9">
                <asp:Label ID="Label11" runat="server" Text="Status"></asp:Label>
            </td>
            <td class="auto-style7">&nbsp;</td>
            <td>
                <asp:DropDownList ID="ddlEditStatus" runat="server" Height="19px" Width="199px">
                    <asp:ListItem>To do</asp:ListItem>
                    <asp:ListItem>In progress</asp:ListItem>
                    <asp:ListItem>Review</asp:ListItem>
                    <asp:ListItem>Done</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style9">&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style9">
                <asp:Label ID="Label13" runat="server" Text="Comment"></asp:Label>
            </td>
            <td class="auto-style7">&nbsp;</td>
            <td>
                <asp:TextBox ID="txtEditComment" runat="server" Height="110px" TextMode="MultiLine" Width="333px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style9">&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style9">
                <asp:Label ID="Label14" runat="server" Text="Upload File"></asp:Label>
            </td>
            <td class="auto-style7">&nbsp;</td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" Width="336px" />
            </td>
        </tr>
        <tr>
            <td class="auto-style9">&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style11"></td>
            <td class="auto-style12"></td>
            <td class="auto-style13">
                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" Width="126px" />
            </td>
        </tr>
        <tr>
            <td class="auto-style9"></td>
            <td class="auto-style7"></td>
            <td class="auto-style2"></td>
        </tr>
        <tr>
            <td class="auto-style9">&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
            <td>
                <asp:Label ID="lblDisplay" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style9">&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style9">&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
            <td>
                    &nbsp;</td>
        </tr>
    </table>
        
    </div>
    </asp:Panel>
    </form>

</body>
</html>
