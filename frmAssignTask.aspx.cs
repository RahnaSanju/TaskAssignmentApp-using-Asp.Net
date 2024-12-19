using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TaskAssignmentApp
{
    public partial class frmAssignTask : System.Web.UI.Page
    {

        ConnectionCls objCls = new ConnectionCls();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string Qry = "Select * from Task_Tab order by TaskName";
                ddlTask.DataSource = objCls.fn_Adapter(Qry);
                ddlTask.DataValueField = "TaskId";
                ddlTask.DataTextField = "TaskName";
                ddlTask.DataBind();
                ddlTask.Items.Insert(0, "-Select-");

                string Qry1 = "Select * from User_Tab where Role='Member' and status='Active' order by UserName";
                ddlAssignedTo.DataSource = objCls.fn_Adapter(Qry1);
                ddlAssignedTo.DataValueField = "UserId";
                ddlAssignedTo.DataTextField = "Name";
                ddlAssignedTo.DataBind();
                ddlAssignedTo.Items.Insert(0, "-Select-");


            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string insQry;
            if (FileUpload1.HasFile)
            {
                //string filePath = Server.MapPath("~/Uploads/") + FileUpload1.FileName;
                string filePath = "~/UploadedFiles/" + FileUpload1.FileName;
                FileUpload1.SaveAs(MapPath(filePath));
                insQry = "Insert into Assign_Tab (TaskId,Description,AssignedBy,AssignedTo,Priority,Status,DueDate,Comment,FileRef) values (" + ddlTask.SelectedItem.Value + ",'" + txtDescription.Text + "'," + Session["userid"] + "," + ddlAssignedTo.SelectedItem.Value + ",'" + ddlPriority.SelectedItem.Text + "','" + ddlStatus.SelectedItem.Text + "','" + cldEditDuedate.SelectedDate.Date.ToString("yyyy-MM-dd") + "','" + txtEditComment.Text + "','" + filePath + "')";
            }
            else
            {
                insQry = "Insert into Assign_Tab (TaskId,Description,AssignedBy,AssignedTo,Priority,Status,DueDate,Comment) values (" + ddlTask.SelectedItem.Value + ",'" + txtDescription.Text + "'," + Session["userid"] + "," + ddlAssignedTo.SelectedItem.Value + ",'" + ddlPriority.SelectedItem.Text + "','" + ddlStatus.SelectedItem.Text + "','" + cldEditDuedate.SelectedDate.Date.ToString("yyyy-MM-dd") + "','" + txtEditComment.Text + "')";
            }
            
            
            int st = objCls.fn_ExecNonQuery(insQry);
            if (st == 1)
            {
                lblDisplay.Text = "Inserted";
                txtEditComment.Text = "";
                txtDescription.Text = "";
                ddlTask.Focus();
            }
        }
    }
}