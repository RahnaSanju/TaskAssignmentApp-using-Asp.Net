using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TaskAssignmentApp
{
    public partial class frmAdminHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ConnectionCls objCls = new ConnectionCls();

            if (!IsPostBack)
            {
                Panel1.Visible = false;
            }
            
        }

        protected void btnViewUserOptions_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
        }

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmAddUser.aspx");
        }

        protected void btnAssignViewTask_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Response.Redirect("frmEditViewAssignedTask_Admin.aspx");
        }

        protected void btnEditRemoveUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmEditRemoveUser.aspx");
        }
    }
}