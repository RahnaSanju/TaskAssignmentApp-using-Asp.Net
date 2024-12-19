using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace TaskAssignmentApp
{
    public partial class frmUserHomePage : System.Web.UI.Page
    {
        ConnectionCls objCls = new ConnectionCls();

        string SearchQry,OrderbyQry;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Label1.Visible = false;
                ddlAssignedBy.Visible = false;
                Label2.Visible = false;
                Calendar1.Visible = false;
                Label3.Visible = false;
                ddlTask.Visible = false;
                Label4.Visible = false;
                ddlPriority.Visible = false;
                Label5.Visible = false;
                ddlStatus.Visible = false;
                btnSearch.Visible = false;
                Panel1.Visible = false;

                OrderbyQry = " ORDER BY CASE WHEN a.Status = 'To Do' THEN 1 WHEN a.Status = 'In Progress' THEN 2 WHEN a.Status = 'Review' THEN 3 WHEN a.Status = 'Done' THEN 4 END, CASE WHEN a.Priority = 'Critical' THEN 1 WHEN a.Priority = 'High' THEN 2 WHEN a.Priority = 'Medium' THEN 3 WHEN a.Priority = 'Low' THEN 4 END, DueDate ASC";
                SearchQry = "Select a.AssignId,t.TaskName,u.Name,a.Description,a.duedate,a.Comment,a.Priority,a.Status,a.FileRef from Assign_Tab a join Task_Tab t on a.TaskId=t.TaskId join User_Tab u on a.AssignedBy=u.userid where a.AssignedTo=" + Session["userid"];
                SearchQry += OrderbyQry;

                //SearchQry = "Select a.AssignId,t.TaskName,u.Name,a.Description,a.duedate,a.Comment,a.Priority,a.Status,a.FileRef from Assign_Tab a join Task_Tab t on a.TaskId=t.TaskId join User_Tab u on a.AssignedBy=u.userid where a.AssignedTo=" + Session["userid"];
                fn_GridviewBind();
            }

        }

        protected void btnOK_Click(object sender, EventArgs e)
        {

            Label1.Visible = false;
            ddlAssignedBy.Visible = false;
            Label2.Visible = false;
            Calendar1.Visible = false;
            Label3.Visible = false;
            ddlTask.Visible = false;
            Label4.Visible = false;
            ddlPriority.Visible = false;
            Label5.Visible = false;
            ddlStatus.Visible = false;

            if (CheckBoxList1.Items[0].Selected) //assigned to 
            {
                string Qry1 = "Select * from User_Tab where Role='Manager' order by Name";
                ddlAssignedBy.DataSource = objCls.fn_Adapter(Qry1);
                ddlAssignedBy.DataValueField = "UserId";
                ddlAssignedBy.DataTextField = "Name";
                ddlAssignedBy.DataBind();
                ddlAssignedBy.Items.Insert(0, "-Select-");

                Label1.Visible = true;
                ddlAssignedBy.Visible = true;

            }
            if (CheckBoxList1.Items[1].Selected) //due date
            {
                Label2.Visible = true;
                Calendar1.Visible = true;

            }
            if (CheckBoxList1.Items[2].Selected) //task
            {
                string Qry = "Select * from Task_Tab order by TaskName";
                ddlTask.DataSource = objCls.fn_Adapter(Qry);
                ddlTask.DataValueField = "TaskId";
                ddlTask.DataTextField = "TaskName";
                ddlTask.DataBind();
                ddlTask.Items.Insert(0, "-Select-");

                Label3.Visible = true;
                ddlTask.Visible = true;

            }
            if (CheckBoxList1.Items[3].Selected) //priority
            {
                Label4.Visible = true;
                ddlPriority.Visible = true;

            }
            if (CheckBoxList1.Items[4].Selected) //status
            {
                Label5.Visible = true;
                ddlStatus.Visible = true;

            }
            btnSearch.Visible = true;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            OrderbyQry = " ORDER BY CASE WHEN a.Status = 'To Do' THEN 1 WHEN a.Status = 'In Progress' THEN 2 WHEN a.Status = 'Review' THEN 3 WHEN a.Status = 'Done' THEN 4 END, CASE WHEN a.Priority = 'Critical' THEN 1 WHEN a.Priority = 'High' THEN 2 WHEN a.Priority = 'Medium' THEN 3 WHEN a.Priority = 'Low' THEN 4 END, DueDate ASC";
            SearchQry = "Select a.AssignId,t.TaskName,u.Name,a.Description,a.duedate,a.Comment,a.Priority,a.Status,a.FileRef from Assign_Tab a join Task_Tab t on a.TaskId=t.TaskId join User_Tab u on a.AssignedBy=u.userid where a.AssignedTo=" + Session["userid"];
            if (CheckBoxList1.Items[0].Selected) //assigned to 
            {
                if(ddlAssignedBy.SelectedItem.Text=="-Select-")
                {
                    lblDisplay1.Text = "Select Assigned By";
                    ddlAssignedBy.Focus();
                }
                else
                {
                    lblDisplay1.Text = "";
                    string qry = "Select userid from User_tab where Name='" + ddlAssignedBy.SelectedItem.Text + "'";
                    int id = Convert.ToInt32(objCls.fn_ExecScalar(qry));
                    SearchQry += " and a.AssignedBy=" + id;
                }
                
            }
            if (CheckBoxList1.Items[1].Selected) //due date
            {
                SearchQry += " and a.DueDate ='" + Calendar1.SelectedDate.Date.ToString("yyyy-MM-dd") + "'";
            }
            if (CheckBoxList1.Items[2].Selected) //task
            {
                if (ddlTask.SelectedItem.Text == "-Select-")
                {
                    lblDisplay1.Text = "Select Task";
                    ddlTask.Focus();
                }
                else
                {
                    lblDisplay1.Text = "";
                    string qry = "Select taskid from Task_tab where TaskName='" + ddlTask.SelectedItem.Text + "'";
                    int Taskid = Convert.ToInt32(objCls.fn_ExecScalar(qry));
                    SearchQry += " and a.TaskId =" + Taskid;
                }
            }
            if (CheckBoxList1.Items[3].Selected) //priority
            {
                SearchQry += " and a.Priority ='" + ddlPriority.SelectedItem.Text + "'";
            }
            if (CheckBoxList1.Items[4].Selected) //status
            {
                SearchQry += " and a.Status ='" + ddlStatus.SelectedItem.Text + "'";
            }

            SearchQry += OrderbyQry;
            fn_GridviewBind();
        }

        public void fn_GridviewBind()
        {
            GridView1.DataSource = objCls.fn_Adapter(SearchQry);
            GridView1.DataBind();
        }

        protected void lbUpdate_Command(object sender, CommandEventArgs e)
        {

            Session["updid"] = Convert.ToInt32(e.CommandArgument);
            Panel1.Visible = true;

            string getValues = "Select * from Assign_Tab where AssignId=" + Session["updid"];
            SqlDataReader dr = objCls.fn_ExecReader(getValues);
            if (dr.Read())
            {

                ddlEditStatus.SelectedValue = dr["Status"].ToString();
                txtEditComment.Text = dr["Comment"].ToString();

            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string updQry;
            if (FileUpload1.HasFile)
            {
                //string filePath = Server.MapPath("~/Uploads/") + FileUpload1.FileName;
                string filePath = "~/UploadedFiles/" + FileUpload1.FileName;
                FileUpload1.SaveAs(MapPath(filePath));
                updQry = "Update Assign_Tab set Status='" + ddlEditStatus.SelectedItem.Text + "' , Comment='" + txtEditComment.Text + "' , FileRef='" + filePath + "' where AssignId=" + Session["updid"];
            }
            else
            {
                updQry = "Update Assign_Tab set Status='" + ddlEditStatus.SelectedItem.Text + "' , Comment='" + txtEditComment.Text + "' where AssignId=" + Session["updid"];
                //updQry = "Update Assign_Tab set (TaskId,Description,AssignedBy,AssignedTo,Priority,Status,DueDate,Comment) values (" + ddlEditTask.SelectedItem.Value + ",'" + txtEditDescription.Text + "'," + Session["userid"] + "," + ddlEditAssignedTo.SelectedItem.Value + ",'" + ddlEditPriority.SelectedItem.Text + "','" + ddlEditStatus.SelectedItem.Text + "','" + cldEditDuedate.SelectedDate.Date.ToString("yyyy-MM-dd") + "','" + txtEditComment.Text + "' where AssignId=" + updid + ")";
            }


            int st = objCls.fn_ExecNonQuery(updQry);
            if (st == 1)
            {
                Panel1.Visible = false;
                //lblDisplay.Text = "Updated";
                OrderbyQry = " ORDER BY CASE WHEN a.Status = 'To Do' THEN 1 WHEN a.Status = 'In Progress' THEN 2 WHEN a.Status = 'Review' THEN 3 WHEN a.Status = 'Done' THEN 4 END, CASE WHEN Priority = 'Critical' THEN 1 WHEN Priority = 'High' THEN 2 WHEN Priority = 'Medium' THEN 3 WHEN Priority = 'Low' THEN 4 END, DueDate ASC";
                SearchQry = "Select a.AssignId,t.TaskName,u.Name,a.Description,a.duedate,a.Comment,a.Priority,a.Status,a.FileRef from Assign_Tab a join Task_Tab t on a.TaskId=t.TaskId join User_Tab u on a.AssignedBy=u.userid where a.AssignedTo=" + Session["userid"];
                SearchQry += OrderbyQry;
                fn_GridviewBind();
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            fn_GridviewBind();
        }
    }
}