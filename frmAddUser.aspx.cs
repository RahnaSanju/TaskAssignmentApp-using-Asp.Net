using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TaskAssignmentApp
{
    public partial class frmAddUser : System.Web.UI.Page
    {
        ConnectionCls objCls = new ConnectionCls();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            
            string insQry = "Insert into User_Tab values ('" + txtName.Text + "','" + ConvertQuotes(txtAddress.Text) 
                + "','" + rblGender.Text + "','" + txtEmail.Text + "','" + txtPhoneNo.Text + "','" + txtUsername.Text 
                + "','" + txtPassword.Text + "','" + ddlRole.Text + "','Active')";
            int st = objCls.fn_ExecNonQuery(insQry);
            if (st == 1)
            {
                lblDisplay.Text = "Inserted";
                txtName.Text = "";
                txtAddress.Text = "";
                txtEmail.Text = "";
                txtPassword.Text = "";
                txtConfirmPassword.Text = "";
                txtPhoneNo.Text = "";
                txtUsername.Text = "";
                txtName.Focus();

                }
        }

        public string ConvertQuotes(string str)
        {
            return (str.Replace("'", "''"));
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
    }
}