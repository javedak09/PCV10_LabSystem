using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace PCV10_LabSystem
{
    public partial class searchpatient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Fill_Dropdown(ddl_frm);
            }
        }


        private void Fill_Dropdown(DropDownList ddl)
        {
            try
            {
                ddl.Items.Clear();

                if (Session["mycookierole"].ToString() == "idrl" || Session["mycookierole"].ToString() == "receiving")
                {
                    ddl.Items.Add(new ListItem("Please Select Form", "0"));
                    ddl.Items.Add(new ListItem("Sample Receiving", "1"));
                    ddl.Items.Add(new ListItem("Sample Entry", "2"));
                }
                else if (Session["mycookierole"].ToString() == "mdl")
                {
                    ddl.Items.Add(new ListItem("Please Select Form", "0"));
                    ddl.Items.Add(new ListItem("Sample Entry", "1"));
                }
                else
                {
                    ddl.Items.Add(new ListItem("Please Select Form", "0"));
                    ddl.Items.Add(new ListItem("Sample Receiving", "1"));
                    ddl.Items.Add(new ListItem("Sample Entry", "2"));
                }
            }

            catch (Exception ex)
            {
                lblerr.Text = ex.Message;
            }

            finally
            {

            }
        }

        protected void cmdSearch_Click(object sender, EventArgs e)
        {
            if (ddl_frm.SelectedValue == "0")
            {
                lblerr.Text = "Please select form ";
                lblerr.CssClass = "message-error";
                ddl_frm.Focus();
            }
            else
            {
                if (ddl_frm.SelectedItem.Text == "Sample Receiving")
                {
                    FillGrid(DG_Request, "0");

                    if (Session["mycookierole"].ToString() == "idrl" || Session["mycookierole"].ToString() == "receiving")
                    {
                        DG_Request.Columns[9].Visible = true;
                    }
                    else if (Session["mycookierole"].ToString() == "mdl")
                    {
                        DG_Request.Columns[9].Visible = true;
                    }
                    else
                    {
                        DG_Request.Columns[9].Visible = true;
                    }
                }
                else
                {
                    FillGrid(DG_Request, "1");
                    DG_Request.Columns[9].Visible = false;
                }

                dl_Inventory.DataSource = null;
                dl_Inventory.DataBind();

                dl_specimen_entry.DataSource = null;
                dl_specimen_entry.DataBind();

                lblerr.Text = "";
            }
        }


        private void FillGrid(GridView dg, string fieldvalue)
        {
            CDBOperations obj_op = new CDBOperations();
            DataSet ds = null;

            try
            {
                string[] fldname = { "var_studyid", "fldval" };
                string[] fldvalue = { studyid.Text, fieldvalue };

                ds = obj_op.ExecuteNonQuery(fldname, fldvalue, "sp_GetRecords");


                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            cmdAddRecord.Visible = false;
                        }
                        else
                        {
                            cmdAddRecord.Visible = true;
                        }
                    }
                    else
                    {
                        cmdAddRecord.Visible = true;
                    }
                }
                else
                {
                    cmdAddRecord.Visible = true;
                }



                dg.Columns[0].Visible = true;

                dg.DataSource = ds;
                dg.DataBind();

                dg.Columns[0].Visible = false;
            }

            catch (Exception ex)
            {
                lblerr.Text = ex.Message;
                lblerr.CssClass = "message-error";
            }

            finally
            {
                obj_op = null;
                ds = null;
            }
        }


        private void FillGrid1(DataList dl, string fieldvalue)
        {
            CDBOperations obj_op = new CDBOperations();
            DataSet ds = null;

            try
            {
                string[] fldname = { "var_studyid", "fldval" };
                string[] fldvalue = { studyid.Text, fieldvalue };

                ds = obj_op.ExecuteNonQuery(fldname, fldvalue, "sp_GetRecords");

                dl.DataSource = ds;
                dl.DataBind();
            }

            catch (Exception ex)
            {
                lblerr.Text = ex.Message;
                lblerr.CssClass = "message-error";
            }

            finally
            {
                obj_op = null;
                ds = null;
            }
        }


        protected void DG_Request_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                DG_Request.Columns[0].Visible = true;
                string id = DG_Request.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
                DG_Request.Columns[0].Visible = false;


                if (ddl_frm.SelectedItem.Text == "Sample Receiving")
                {
                    FillGrid1(dl_Inventory, "0");
                }
                else
                {
                    FillGrid1(dl_specimen_entry, "1");


                    Panel panel_rcv = (Panel)dl_specimen_entry.Items[0].FindControl("pnl_receiving");
                    Panel panel_idrl = (Panel)dl_specimen_entry.Items[0].FindControl("pnl_idrl");
                    Panel panel_mdl = (Panel)dl_specimen_entry.Items[0].FindControl("pnl_mdl");



                    if (Session["mycookierole"].ToString() == "idrl")
                    {
                        panel_rcv.Visible = false;
                        panel_idrl.Visible = true;
                        panel_mdl.Visible = false;
                    }
                    else if (Session["mycookierole"].ToString() == "mdl")
                    {
                        panel_rcv.Visible = false;
                        panel_idrl.Visible = false;
                        panel_mdl.Visible = true;
                    }
                    else
                    {
                        panel_rcv.Visible = true;
                        panel_idrl.Visible = true;
                        panel_mdl.Visible = true;
                    }


                    panel_idrl = null;
                    panel_mdl = null;
                    panel_rcv = null;
                }



            }
            else if (e.CommandName == "Delete")
            {
                DG_Request.Columns[0].Visible = true;
                string id = DG_Request.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
                DG_Request.Columns[0].Visible = false;

                CDBOperations obj_op = new CDBOperations();
                string val = obj_op.GetDataFieldWise("0", "sp_GetRecords", "q6", studyid.Text);
                string val1 = obj_op.GetDataFieldWise("1", "sp_GetRecords", "q2", studyid.Text);
                obj_op = null;


                if (val1 != null)
                {
                    Session["id"] = id;
                }


                if (Session["mycookierole"].ToString() == "receiving" && ddl_frm.SelectedItem.Text == "Sample Receiving"
                || Session["mycookierole"].ToString() == "idrl" && ddl_frm.SelectedItem.Text == "Sample Receiving")



                if (Session["mycookierole"].ToString() == "receiving")
                {
                    Response.Redirect("specimen.aspx?id=" + studyid.Text);
                }
                else if (Session["mycookierole"].ToString() == "idrl")
                {
                    if (val == "No" || val == "")
                    {
                        Response.Redirect("specimen_entry.aspx?errmsg=Status of Specimen is not received so you cannot fill the sample collection form");
                    }
                    else
                    {
                        if (ddl_frm.SelectedItem.Text == "Sample Receiving")
                        {
                            Response.Redirect("specimen.aspx?id=" + studyid.Text);
                        }
                        else if (ddl_frm.SelectedItem.Text == "Sample Entry")
                        {
                            Response.Redirect("specimen_entry.aspx?id=" + studyid.Text);
                        }
                    }
                }
                else if (Session["mycookierole"].ToString() == "mdl")
                {
                    if (val == "No" || val == "")
                    {
                        Response.Redirect("specimen_entry.aspx?errmsg=Status of Specimen is not received so you cannot fill the sample collection form");
                    }
                    else
                    {
                        if (ddl_frm.SelectedItem.Text == "Sample Receiving")
                        {
                            Response.Redirect("specimen.aspx?id=" + studyid.Text);
                        }
                        else if (ddl_frm.SelectedItem.Text == "Sample Entry")
                        {
                            Response.Redirect("specimen_entry.aspx?id=" + studyid.Text);
                        }
                    }
                }
                else
                {
                    if (val == "No" || val == "")
                    {
                        Response.Redirect("specimen_entry.aspx?errmsg=Status of Specimen is not received so you cannot fill the sample collection form");
                    }
                    else
                    {
                        if (ddl_frm.SelectedItem.Text == "Sample Receiving")
                        {
                            Response.Redirect("specimen.aspx?id=" + studyid.Text);
                        }
                        else if (ddl_frm.SelectedItem.Text == "Sample Entry")
                        {
                            Response.Redirect("specimen_entry.aspx?id=" + studyid.Text);
                        }
                    }
                }






            }
        }

        protected void DG_Request_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string id = "";

            DG_Request.Columns[0].Visible = true;
            id = DG_Request.Rows[e.NewEditIndex].Cells[0].Text;
            DG_Request.Columns[0].Visible = false;

            e.NewEditIndex = -1;

            Session["id"] = id;


            if (ddl_frm.SelectedItem.Text == "Sample Receiving")
            {
                Response.Redirect("specimen.aspx");
            }
            else
            {
                Response.Redirect("specimen_entry.aspx");
            }
        }

        protected void DG_Request_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (ddl_frm.SelectedItem.Text == "Sample Receiving")
            {
                FillGrid(DG_Request, "0");
            }
            else
            {
                FillGrid(DG_Request, "1");
            }
        }

        protected void cmdClose_Click(object sender, ImageClickEventArgs e)
        {
            dl_Inventory.DataSource = null;
            dl_Inventory.DataBind();
        }

        protected void cmdClose1_Click(object sender, ImageClickEventArgs e)
        {
            dl_specimen_entry.DataSource = null;
            dl_specimen_entry.DataBind();
        }

        protected void cmdAddRecord_Click(object sender, EventArgs e)
        {
            CDBOperations obj_op = new CDBOperations();
            string val = obj_op.GetDataFieldWise("0", "sp_GetRecords", "q6", studyid.Text);
            string val1 = obj_op.GetDataFieldWise("1", "sp_GetRecords", "q2", studyid.Text);
            obj_op = null;



            if (Session["mycookierole"].ToString() == "receiving" && ddl_frm.SelectedItem.Text == "Sample Receiving"
                || Session["mycookierole"].ToString() == "idrl" && ddl_frm.SelectedItem.Text == "Sample Receiving")
            {
                Response.Redirect("specimen.aspx?id=" + studyid.Text);
            }
            else if (Session["mycookierole"].ToString() == "idrl" && ddl_frm.SelectedItem.Text == "Sample Entry")
            {
                if (val == "No" || val == "")
                {
                    Response.Redirect("specimen_entry.aspx?errmsg=Status of Specimen is not received so you cannot fill the sample collection form");
                }
                else
                {
                    if (ddl_frm.SelectedItem.Text == "Sample Receiving")
                    {
                        Response.Redirect("specimen.aspx?id=" + studyid.Text);
                    }
                    else if (ddl_frm.SelectedItem.Text == "Sample Entry")
                    {
                        Response.Redirect("specimen_entry.aspx?id=" + studyid.Text);
                    }
                }
            }
            else if (Session["mycookierole"].ToString() == "mdl")
            {
                if (val == "No" || val == "")
                {
                    Response.Redirect("specimen_entry.aspx?errmsg=Status of Specimen is not received so you cannot fill the sample collection form");
                }
                else
                {
                    if (ddl_frm.SelectedItem.Text == "Sample Receiving")
                    {
                        Response.Redirect("specimen.aspx?id=" + studyid.Text);
                    }
                    else if (ddl_frm.SelectedItem.Text == "Sample Entry")
                    {
                        Response.Redirect("specimen_entry.aspx?id=" + studyid.Text);
                    }
                }
            }
            else
            {
                if (val == "No" || val == "")
                {
                    Response.Redirect("specimen_entry.aspx?errmsg=Status of Specimen is not received so you cannot fill the sample collection form");
                }
                else
                {
                    if (ddl_frm.SelectedItem.Text == "Sample Receiving")
                    {
                        Response.Redirect("specimen.aspx?id=" + studyid.Text);
                    }
                    else if (ddl_frm.SelectedItem.Text == "Sample Entry")
                    {
                        Response.Redirect("specimen_entry.aspx?id=" + studyid.Text);
                    }
                }
            }





        }



    }
}