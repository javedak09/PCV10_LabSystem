using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PCV13_LabSystem
{
    public partial class Site_S : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/Account/Login.aspx");
            }
            else
            {
                LinkButton lnkLogout = (LinkButton)FindControl("lnkLogout");
                lnkLogout.Text = "Logout";

                LinkButton lnkUser = (LinkButton)FindControl("lnkUser");
                lnkUser.Text = "Welcome: " + HttpContext.Current.Request["mycookie"].ToString();

                lnkLogout = null;
                lnkUser = null;
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/Account/Login.aspx");
            }
            else
            {
                LinkButton lnkLogout = (LinkButton)FindControl("lnkLogout");
                lnkLogout.Text = "Logout";

                LinkButton lnkUser = (LinkButton)FindControl("lnkUser");
                lnkUser.Text = "Welcome: " + HttpContext.Current.Request["mycookie"].ToString();

                lnkLogout = null;
                lnkUser = null;
            }
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("UserID");
            Session.Abandon();
            Response.Redirect("~/Account/login.aspx");
        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {

        }
    }
}