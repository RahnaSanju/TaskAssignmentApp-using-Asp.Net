using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TaskAssignmentApp
{
    public partial class frmManagerHomePage : System.Web.UI.Page
    {
        ConnectionCls objCls = new ConnectionCls();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if(!IsPostBack)
            //{
            //    Panel1.Visible = false;
            //    Panel3.Visible = false;

            //    string Qry = "Select * from Task_Tab order by TaskName";
            //    ddlTask.DataSource = objCls.fn_Adapter(Qry);
            //    ddlTask.DataValueField = "TaskId";
            //    ddlTask.DataTextField = "TaskName";
            //    ddlTask.DataBind();
            //    ddlTask.Items.Insert(0, "-Select-");


            //    string Qry1 = "Select * from User_Tab where Role='Member' order by Name";
            //    ddlAssignedTo.DataSource = objCls.fn_Adapter(Qry1);
            //    ddlAssignedTo.DataValueField = "TaskId";
            //    ddlAssignedTo.DataTextField = "TaskName";
            //    ddlAssignedTo.DataBind();
            //    ddlAssignedTo.Items.Insert(0, "-Select-");
            //}
            
        }

        protected void btnAssignTask_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmAssignTask.aspx");
        }

        protected void btEditViewTask_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmEditViewAssignedTask_Manager.aspx");
            //Panel1.Visible = true;
            //Panel3.Visible = false;
        }

        protected void btnCreateEditTask_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmCreateEditTask.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        //protected void btnCreateTask_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("frmEditTask.aspx");
        //    //Response.Redirect("frmCreateTask.aspx");
        //}

        //protected void btnEditTask_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("frmEditTask.aspx");
        //}

    }
}