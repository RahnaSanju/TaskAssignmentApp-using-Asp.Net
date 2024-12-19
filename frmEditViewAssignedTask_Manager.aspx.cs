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
    public partial class frmEditViewAssignedTask_Manager : System.Web.UI.Page
    {
        ConnectionCls objCls = new ConnectionCls();

        string SearchQry;
        protected void Page_Load(object sender, EventArgs e)
        {

            if(!IsPostBack)
            {
                Label1.Visible = false;
                ddlAssignedTo.Visible = false;
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
                SearchQry = "Select a.AssignId,t.TaskName,u.Name,a.Description,a.duedate,a.Comment,a.Priority,a.Status,a.FileRef from Assign_Tab a join Task_Tab t on a.TaskId=t.TaskId join User_Tab u on a.AssignedTo=u.userid where a.AssignedBy=" + Session["userid"];
                fn_GridviewBind();
            }

        }

        protected void btnOK_Click(object sender, EventArgs e)
        {

            Label1.Visible = false;
            ddlAssignedTo.Visible = false;
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
                string Qry1 = "Select * from User_Tab where Role='Member' order by Name";
                ddlAssignedTo.DataSource = objCls.fn_Adapter(Qry1);
                ddlAssignedTo.DataValueField = "UserId";
                ddlAssignedTo.DataTextField = "Name";
                ddlAssignedTo.DataBind();
                ddlAssignedTo.Items.Insert(0, "-Select-");

                Label1.Visible = true;
                ddlAssignedTo.Visible = true;
                
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
            SearchQry = "Select a.AssignId,t.TaskName,u.Name,a.Description,a.duedate,a.Comment,a.Priority,a.Status,a.FileRef from Assign_Tab a join Task_Tab t on a.TaskId=t.TaskId join User_Tab u on a.AssignedTo=u.userid where AssignedBy=" + Session["userid"];
            if (CheckBoxList1.Items[0].Selected) //assigned to 
            {
                if (ddlAssignedTo.SelectedItem.Text == "-Select-")
                {
                    lblDisplay1.Text = "Select Assigned To";
                    ddlAssignedTo.Focus();
                }
                else
                {
                    lblDisplay1.Text = "";
                    string qry = "Select userid from User_tab where Name='" + ddlAssignedTo.SelectedItem.Text + "'";
                    int id = Convert.ToInt32(objCls.fn_ExecScalar(qry));
                    SearchQry += " and a.AssignedTo=" + id;
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

            fn_GridviewBind();
        }

        public void fn_GridviewBind()
        {
            GridView1.DataSource = objCls.fn_Adapter(SearchQry);
            GridView1.DataBind();
        }

        protected void lbUpdate_Command(object sender, CommandEventArgs e)
        {

            string Qry = "Select * from Task_Tab order by TaskName";
            ddlEditTask.DataSource = objCls.fn_Adapter(Qry);
            ddlEditTask.DataValueField = "TaskId";
            ddlEditTask.DataTextField = "TaskName";
            ddlEditTask.DataBind();
            ddlEditTask.Items.Insert(0, "-Select-");

            string Qry1 = "Select * from User_Tab where Role='Member' order by Name";
            ddlEditAssignedTo.DataSource = objCls.fn_Adapter(Qry1);
            ddlEditAssignedTo.DataValueField = "UserId";
            ddlEditAssignedTo.DataTextField = "Name";
            ddlEditAssignedTo.DataBind();
            ddlEditAssignedTo.Items.Insert(0, "-Select-");



            Session["updid"] = Convert.ToInt32(e.CommandArgument);
            Panel1.Visible = true;

            string getValues = "Select * from Assign_Tab where AssignId=" + Session["updid"] ;
            SqlDataReader dr= objCls.fn_ExecReader(getValues);
            if(dr.Read())
            {
                ddlEditTask.SelectedValue = dr["TaskId"].ToString();

                ddlEditAssignedTo.SelectedValue = dr["AssignedTo"].ToString();

                txtEditDescription.Text = dr["Description"].ToString();

                ddlEditPriority.SelectedValue = dr["Priority"].ToString();

                ddlEditStatus.SelectedValue = dr["Status"].ToString();

                cldEditDuedate.SelectedDate = Convert.ToDateTime(dr["Duedate"].ToString());

                txtEditComment.Text = dr["Comment"].ToString();
            }

        }

        protected void lbDelete_Command(object sender, CommandEventArgs e)
        {
            int getid = Convert.ToInt32(e.CommandArgument);
            string str = "Delete from Assign_Tab where AssignId=" + getid;
            int st = objCls.fn_ExecNonQuery(str);
            if (st == 1)
            {
                Panel1.Visible = false;;
                SearchQry = "Select a.AssignId,t.TaskName,u.Name,a.Description,a.duedate,a.Comment,a.Priority,a.Status,a.FileRef from Assign_Tab a join Task_Tab t on a.TaskId=t.TaskId join User_Tab u on a.AssignedTo=u.userid where a.AssignedBy=" + Session["userid"];
                fn_GridviewBind();
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
                updQry = "Update Assign_Tab set TaskId=" + ddlEditTask.SelectedItem.Value + " , Description='"+ txtEditDescription.Text + "' , AssignedBy= " + Session["userid"] + " , AssignedTo= " + ddlEditAssignedTo.SelectedItem.Value + " , Priority='" + ddlEditPriority.SelectedItem.Text + "' , Status='" + ddlEditStatus.SelectedItem.Text + "' , DueDate='" + cldEditDuedate.SelectedDate.Date.ToString("yyyy - MM - dd") +  "' , Comment='" + txtEditComment.Text + "' , FileRef='" + filePath + "' where AssignId="+ Session["updid"] ;
            }
            else
            {
                updQry = "Update Assign_Tab set TaskId=" + ddlEditTask.SelectedItem.Value + " , Description='" + txtEditDescription.Text + "' , AssignedBy= " + Session["userid"] + " , AssignedTo= " + ddlEditAssignedTo.SelectedItem.Value + " , Priority='" + ddlEditPriority.SelectedItem.Text + "' , Status='" + ddlEditStatus.SelectedItem.Text + "' , DueDate='" + cldEditDuedate.SelectedDate.Date.ToString("yyyy - MM - dd") + "' , Comment='" + txtEditComment.Text + "' where AssignId=" + Session["updid"] ;
                //updQry = "Update Assign_Tab set (TaskId,Description,AssignedBy,AssignedTo,Priority,Status,DueDate,Comment) values (" + ddlEditTask.SelectedItem.Value + ",'" + txtEditDescription.Text + "'," + Session["userid"] + "," + ddlEditAssignedTo.SelectedItem.Value + ",'" + ddlEditPriority.SelectedItem.Text + "','" + ddlEditStatus.SelectedItem.Text + "','" + cldEditDuedate.SelectedDate.Date.ToString("yyyy-MM-dd") + "','" + txtEditComment.Text + "' where AssignId=" + updid + ")";
            }


            int st = objCls.fn_ExecNonQuery(updQry);
            if (st == 1)
            {
                Panel1.Visible = false;
                //lblDisplay.Text = "Updated";
                SearchQry = "Select a.AssignId,t.TaskName,u.Name,a.Description,a.duedate,a.Comment,a.Priority,a.Status,a.FileRef from Assign_Tab a join Task_Tab t on a.TaskId=t.TaskId join User_Tab u on a.AssignedTo=u.userid where a.AssignedBy=" + Session["userid"];
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