using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace TaskAssignmentApp
{
    public partial class frmEditRemoveUser : System.Web.UI.Page
    {
        ConnectionCls objCls = new ConnectionCls();

        string SearchQry;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Panel1.Visible = false;
                SearchQry = "Select * from User_tab order by Name";
                fn_GridviewBind();
            }
            
        }

        public void fn_GridviewBind()
        {
            GridView1.DataSource = objCls.fn_Adapter(SearchQry);
            GridView1.DataBind();
        }

        protected void lbtnDelete_Command(object sender, CommandEventArgs e)
        {
            int getid = Convert.ToInt32(e.CommandArgument);
            string str = "Delete from User_Tab where UserId=" + getid;
            objCls.fn_ExecNonQuery(str);
            SearchQry = "Select * from User_tab order by Name";
            fn_GridviewBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            fn_GridviewBind();
        }

        protected void lbtnUpdate_Command(object sender, CommandEventArgs e)
        {
            Session["updUserId"] = Convert.ToInt32(e.CommandArgument);
            Panel1.Visible = true;

            string getValues = "Select * from User_tab where userid= " + Session["updUserId"];
            SqlDataReader dr = objCls.fn_ExecReader(getValues);
            if (dr.Read())
            {
                txtName.Text = dr["Name"].ToString();
                txtAddress.Text = dr["Address"].ToString();
                rblGender.SelectedValue = dr["Gender"].ToString();
                txtEmail.Text = dr["Email"].ToString();
                txtPhoneNo.Text = dr["PhoneNo"].ToString();
                txtUsername.Text = dr["username"].ToString();
                txtPassword.Text = dr["Password"].ToString();
                ddlRole.SelectedValue = dr["Role"].ToString();
                ddlStatus.SelectedValue = dr["Status"].ToString();
            }

        }

        protected void txtUsername_TextChanged(object sender, EventArgs e)
        {
            string qry = "Select count(UserId) from User_Tab where username ='" + txtUsername.Text + "'";
            string cid = objCls.fn_ExecScalar(qry).ToString();
            if (cid == "1")
            {
                lblDisplay.Text = "Username already exists!!! Try another name..";
            }
            else
            {
                lblDisplay.Text = "";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string updQry = "Update User_Tab set Name='" + txtName.Text + "',Address='" + txtAddress.Text + "',Gender='" + rblGender.SelectedItem.Text + "',Email='" + txtEmail.Text + "',PhoneNo='" + txtPhoneNo.Text + "',Username='" + txtUsername.Text + "',password='" + txtUsername.Text + "',Role='" + ddlRole.SelectedItem.Text + "',Status='" + ddlStatus.SelectedItem.Text + "' where UserId=" + Session["updUserId"];
            int st = objCls.fn_ExecNonQuery(updQry);
            if (st == 1)
            {
                Panel1.Visible = false;
                //lblDisplay.Text = "Updated";
                SearchQry = "Select * from User_tab order by Name";
                fn_GridviewBind();
            }
        }
    }
}