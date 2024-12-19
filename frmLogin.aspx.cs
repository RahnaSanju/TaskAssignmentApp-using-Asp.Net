using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace TaskAssignmentApp
{
    public partial class frmLogin : System.Web.UI.Page
    {
        ConnectionCls objCls = new ConnectionCls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string qry = "Select count(userid) from User_Tab where username ='" + txtUsername.Text + "' and password='" + txtPassword.Text + "'";
            string cid = objCls.fn_ExecScalar(qry).ToString();
            if (cid == "1")
            {
                string gettype = "Select userid,role from User_Tab where username ='" + txtUsername.Text + "' and password='" + txtPassword.Text + "'";
                SqlDataReader dr = objCls.fn_ExecReader(gettype);
                if (dr.Read() == true)
                {
                    Session["userid"] = dr["userid"];
                    string role = dr["role"].ToString();
                    switch (role)
                    {
                        case "Administrator": Response.Redirect("frmAdminHomePage.aspx");
                            break;
                        case "Manager": Response.Redirect("frmManagerHomePage.aspx");
                            break;
                        case "Member":Response.Redirect("frmUserHomePage.aspx");
                            break;
                    }
                }
            }
            else
            {
                lblDisplay.Text = "Invalid username and password";
                txtUsername.Text = "";
                txtPassword.Text = "";
                txtUsername.Focus();
            }
        }
    }
}