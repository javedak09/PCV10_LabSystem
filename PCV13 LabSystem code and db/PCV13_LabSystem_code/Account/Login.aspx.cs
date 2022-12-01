using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace PCV13_LabSystem.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cmdLogin.OnClientClick = "return ValidateLogin();";

            if (string.IsNullOrEmpty(Request.QueryString["errmsg"]) == false)
            {
                lblerr.Text = Request.QueryString["errmsg"].ToString();
                lblerr.CssClass = "message-error";
            }
            else
            {
                lblerr.Text = "";
            }
        }

        protected void cmdLogin_Click(object sender, EventArgs e)
        {
            CDBOperations obj_op = new CDBOperations();

            if (obj_op.Login(txtUserID.Text, txtPwd.Text, "sp_Login") == true)
            {
                if (Session["mycookierole"].ToString() == "receiving")
                {
                    Response.Redirect("~/searchpatient.aspx");
                }
                else if (Session["mycookierole"].ToString() == "idrl" || Session["mycookierole"].ToString() == "mdl")
                {
                    Response.Redirect("~/searchpatient.aspx");
                }
                else
                {
                    Response.Redirect("~/searchpatient.aspx");
                }
            }
            else
            {
                lblerr.Text = "Userid or password incorrect";
                lblerr.CssClass = "message-error";
            }

            obj_op = null;
        }

        protected void cmdCancel_Click(object sender, EventArgs e)
        {
            txtUserID.Text = "";
            txtPwd.Text = "";
            txtUserID.Focus();
            lblerr.Text = "";
        }
    }
}