using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TaskAssignmentApp
{
    public partial class frmCreateEditTask : System.Web.UI.Page
    {
        ConnectionCls objCls = new ConnectionCls();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                fn_GridViewBind();
            }
            
        }


        public void fn_GridViewBind()
        {
            string qry = "Select * from Task_Tab order by TaskName";
            GridView1.DataSource = objCls.fn_Adapter(qry);
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int i = e.RowIndex;
            int getid = Convert.ToInt32(GridView1.DataKeys[i].Value);
            string Qry = "Delete from Task_tab where TaskId=" + getid;
            objCls.fn_ExecNonQuery(Qry);
            fn_GridViewBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            fn_GridViewBind();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            fn_GridViewBind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int i = e.RowIndex;
            int getid = Convert.ToInt32(GridView1.DataKeys[i].Value);
            TextBox txtTaskName = (TextBox)GridView1.Rows[i].Cells[2].Controls[0];
            string Qry = "Update Task_tab set TaskName='"+ txtTaskName.Text +"' where TaskId=" + getid;
            objCls.fn_ExecNonQuery(Qry);
            GridView1.EditIndex = -1;
            fn_GridViewBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            fn_GridViewBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string insQry = "Insert into Task_Tab values ('" + txtTaskName.Text + "')";
            int st = objCls.fn_ExecNonQuery(insQry);
            if (st == 1)
            {
                lblDisplay.Text = "Inserted";
                txtTaskName.Text = "";
            }
            fn_GridViewBind();
        }
    }
}