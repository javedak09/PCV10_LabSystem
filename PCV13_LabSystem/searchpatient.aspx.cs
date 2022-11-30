using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
using System.Xml.Linq;

namespace PCV13_LabSystem
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

                ddl.Items.Add(new ListItem("Please Select Form", "0"));
                ddl.Items.Add(new ListItem("Sample Receiving", "1"));
                ddl.Items.Add(new ListItem("Sample Entry", "2"));


                //if (Session["mycookierole"].ToString() == "idrl" || Session["mycookierole"].ToString() == "receiving")
                //{
                //    ddl.Items.Add(new ListItem("Please Select Form", "0"));
                //    ddl.Items.Add(new ListItem("Sample Receiving", "1"));
                //    ddl.Items.Add(new ListItem("Sample Entry", "2"));
                //}
                //else if (Session["mycookierole"].ToString() == "mdl")
                //{
                //    ddl.Items.Add(new ListItem("Please Select Form", "0"));
                //    ddl.Items.Add(new ListItem("Sample Entry", "1"));
                //}
                //else
                //{
                //    ddl.Items.Add(new ListItem("Please Select Form", "0"));
                //    ddl.Items.Add(new ListItem("Sample Receiving", "1"));
                //    ddl.Items.Add(new ListItem("Sample Entry", "2"));
                //}
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
                    FillGrid_1(DG_Request, "1");
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



                string qry = "SELECT id, " +
        "studyid, " +
        "childid, " +
        "dssid, " +
        "case when q1 = 1 then 'Matiari'" +
        "end q1, " +
        "q2, " +
        "q3, " +
        "q3a, " +
        "case when q4 = 1 then 'Yes'" +
        "     when q4 = 2 then 'No' " +
        "end q4, " +
        "convert(varchar(13), q5dt, 103) q5dt, " +
        "convert(varchar(13), q5dt, 103) q5dta, " +
        "q5t, " +
        "case when q6 = 1 then 'Yes' " +
        "     when q6 = 2 then 'No' " +
        "end q6, " +
        "case when q7 = 1 then 'Intact' " +
        "    when q7 = 2 then 'Physical Damage' " +
        "    when q7 = 3 then 'Without swab stick' " +
        "    when q7 = 4 then 'Without media' " +
        "end q7, " +
        "q8, " +
        "convert(varchar(13), q9dt, 103) q9dt, " +
        "convert(varchar(13), q9dt, 103) q9dta, " +
        "q9t, " +
        "q10, " +
        "q10a, " +
        "q8a, " +
        "convert(varchar(13), q9dt1, 103) q9dt1, " +
        "convert(varchar(13), q9dt1, 103) q9dt1a, " +
        "q9ta, " +
        "q10a1, " +
        "q10a2 " +
        " FROM sample_recv where studyid='" + studyid.Text + "'";


                //ds = obj_op.ExecuteNonQuery(fldname, fldvalue, "sp_GetRecords");
                ds = ExecuteNonQuery_Qry(fldname, fldvalue, qry);


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





        private void FillGrid_1(GridView dg, string fieldvalue)
        {
            CDBOperations obj_op = new CDBOperations();
            DataSet ds = null;

            try
            {
                string[] fldname = { "var_studyid", "fldval" };
                string[] fldvalue = { studyid.Text, fieldvalue };



                string qry = "SELECT a.id, " +
        "b.q2, " +
        "b.q3, " +
        "b.q3a, " +
        "b.childid, " +
        "b.studyid, " +
        "case when b.q1 = 1 then 'Matiari' " +
        "end q1, " +
        "b.q2, " +
        "b.q3, " +
        "b.q3a, " +
        "q4a, " +
        "convert(varchar(13), b.q5dt, 103) q5dta, " +
        "case when q5 = 1 then 'Yes' " +
        "     when q5 = 2 then 'No' " +
        "end q5, " +
        "case when b.q7 = 1 then 'Yes' " +
        "     when b.q7 = 2 then 'No' " +
        "end q7, " +
        "case when b.q8 = 1 then 'Intact' " +
        "    when b.q8 = 2 then 'Physical Damage' " +
        "    when b.q8 = 3 then 'Without swab stick' " +
        "    when b.q8 = 4 then 'Without media' " +
        "end q8, " +
        "q9, " +
        "convert(varchar(13), q10dt, 103) q10dt, " +
        "convert(varchar(13), q10dt, 103) q10dta, " +
        "q10t, " +
        "q11, " +
        "case when q12 = 1 then 'Yes' " +
        "     when q12 = 2 then 'No' " +
        "end q12, " +
        "q13, " +
        "case when q14 = 1 then 'POS' " +
        "     when q14 = 2 then 'NEG' " +
        "     when q14 = 9 then 'NOT APPLICABLE' " +
        "end q14, " +
        "q15a1, " +
        "q15b1, " +
        "q15c1, " +
        "case when q15c1 = 1 then 'S' " +
        "     when q15c1 = 2 then 'I' " +
        "     when q15c1 = 3 then 'R' " +
        "end q15c11, " +
        "q15a2, " +
        "q15b2, " +
        "q15c2, " +
        "case when q15c2 = 1 then 'S' " +
        "     when q15c2 = 2 then 'I' " +
        "     when q15c2 = 3 then 'R' " +
        "end q15c21, " +
        "q15a3, " +
        "q15b3, " +
        "q15c3, " +
        "case when q15c3 = 1 then 'S' " +
        "     when q15c3 = 2 then 'I' " +
        "     when q15c3 = 3 then 'R' " +
        "end q15c31, " +
        "q15a4, " +
        "q15b4, " +
        "q15c4, " +
        "case when q15c4 = 1 then 'S' " +
        "     when q15c4 = 2 then 'I' " +
        "     when q15c4 = 3 then 'R' " +
        "end q15c41, " +
        "q15a5, " +
        "q15b5, " +
        "q15c5, " +
        "case when q15c5 = 1 then 'S' " +
        "     when q15c5 = 2 then 'I' " +
        "     when q15c5 = 3 then 'R' " +
        "end q15c51, " +
        "q15a6, " +
        "q15b6, " +
        "q15c6, " +
        "case when q15c6 = 1 then 'S' " +
        "     when q15c6 = 2 then 'I' " +
        "     when q15c6 = 3 then 'R' " +
        "end q15c61, " +
        "q15a7, " +
        "q15b7, " +
        "q15c7, " +
        "case when q15c7 = 1 then 'S' " +
        "     when q15c7 = 2 then 'I' " +
        "     when q15c7 = 3 then 'R' " +
        "end q15c71, " +
        "case when q16signa1 = 1 then '<' " +
        "     when q16signa1 = 2 then '>' " +
        "     when q16signa1 = 3 then '=' " +
        "     when q16signa1 = 4 then '>=' " +
        "     when q16signa1 = 5 then '<=' " +
        "end q16signa1a, " +
        "q16signa1, " +
        "q16a1, " +
        "q16b1, " +
        "q16c1, " +
        "case when q16c1 = 1 then 'S' " +
        "     when q16c1 = 2 then 'I' " +
        "     when q16c1 = 3 then 'R' " +
        "end q16c11, " +
        "case when q16signa2 = 1 then '<' " +
        "     when q16signa2 = 2 then '>' " +
        "     when q16signa2 = 3 then '=' " +
        "     when q16signa2 = 4 then '>=' " +
        "     when q16signa2 = 5 then '<=' " +
        "end q16signa2a, " +
        "q16signa2, " +
        "q16a2, " +
        "q16b2, " +
        "q16c2, " +
        "case when q16c2 = 1 then 'S' " +
        "     when q16c2 = 2 then 'I' " +
        "     when q16c2 = 3 then 'R' " +
        "end q16c21, " +
        "case when q16signa3 = 1 then '<' " +
        "     when q16signa3 = 2 then '>' " +
        "     when q16signa3 = 3 then '=' " +
        "     when q16signa3 = 4 then '>=' " +
        "     when q16signa3 = 5 then '<=' " +
        "end q16signa3a, " +
        "q16signa3, " +
        "q16a3, " +
        "q16b3, " +
        "q16c3, " +
        "case when q16c3 = 1 then 'S' " +
        "     when q16c3 = 2 then 'I' " +
        "     when q16c3 = 3 then 'R' " +
        "end q16c31, " +
        "case when q16c = 1 then 'Yes' " +
        "     when q16c = 2 then 'No' " +
        "end q16c, " +
        "q17a1, " +
        "q17b1, " +
        "q17c1, " +
        "case when q17c1 = 1 then 'S' " +
        "     when q17c1 = 2 then 'I' " +
        "     when q17c1 = 3 then 'R' " +
        "end q17c1155, " +
        "q17a2, " +
        "q17b2, " +
        "q17c2, " +
        "case when q17c2 = 1 then 'S' " +
        "     when q17c2 = 2 then 'I' " +
        "     when q17c2 = 3 then 'R' " +
        "end q17c21, " +
        "q17a99, " +
        "q17b99, " +
        "q17c3, " +
        "case when q17c3 = 1 then 'S' " +
        "     when q17c3 = 2 then 'I' " +
        "     when q17c3 = 3 then 'R' " +
        "end q17c31, " +
        "q17a3, " +
        "q17b3, " +
        "q17c4, " +
        "case when q17c4 = 1 then 'S' " +
        "     when q17c4 = 2 then 'I' " +
        "     when q17c4 = 3 then 'R' " +
        "end q17c41, " +
        "q17a4, " +
        "q17b4, " +
        "q17c5, " +
        "case when q17c5 = 1 then 'S' " +
        "     when q17c5 = 2 then 'I' " +
        "     when q17c5 = 3 then 'R' " +
        "end q17c51, " +
        "q17a5, " +
        "q17b5, " +
        "q17c6, " +
        "case when q17c6 = 1 then 'S' " +
        "     when q17c6 = 2 then 'I' " +
        "     when q17c6 = 3 then 'R' " +
        "end q17c61, " +
        "q17a6, " +
        "q17b6, " +
        "q17c7, " +
        "case when q17c7 = 1 then 'S' " +
        "     when q17c7 = 2 then 'I' " +
        "     when q17c7 = 3 then 'R' " +
        "end q17c71, " +
        "q17a7, " +
        "q17b7, " +
        "q17c8, " +
        "case when q17c8 = 1 then 'S' " +
        "     when q17c8 = 2 then 'I' " +
        "     when q17c8 = 3 then 'R' " +
        "end q17c81, " +
        "q17a8, " +
        "q17b8, " +
        "q17c9, " +
        "case when q17c9 = 1 then 'S' " +
        "     when q17c9 = 2 then 'I' " +
        "     when q17c9 = 3 then 'R' " +
        "end q17c91, " +
        "q17a9, " +
        "q17b9, " +
        "q17c10, " +
        "case when q17c10 = 1 then 'S' " +
        "     when q17c10 = 2 then 'I' " +
        "     when q17c10 = 3 then 'R' " +
        "end q17c101, " +
        "q17a10, " +
        "q17b10, " +
        "q17c11, " +
        "case when q17c11 = 1 then 'S' " +
        "     when q17c11 = 2 then 'I' " +
        "     when q17c11 = 3 then 'R' " +
        "end q17c111, " +
        "case when q18signa1 = 1 then '<' " +
        "     when q18signa1 = 2 then '>' " +
        "     when q18signa1 = 3 then '=' " +
        "     when q18signa1 = 4 then '>=' " +
        "     when q18signa1 = 5 then '<=' " +
        "end q18signa1a, " +
        "q18signa1, " +
        "q18a1, " +
        "q18b1, " +
        "q18c1, " +
        "case when q18c1 = 1 then 'S' " +
        "     when q18c1 = 2 then 'I' " +
        "     when q18c1 = 3 then 'R' " +
        "end q18c11, " +
        "case when q19 = 1 then 'Yes' " +
        "     when q19 = 2 then 'No' " +
        "     when q19 = 9 then 'NA' " +
        "end q19, " +
        "q20, " +
        "case when q21 = 1 then '6A' " +
        "     when q21 = 2 then '6B' " +
        "     when q21 = 3 then '6C' " +
        "     when q21 = 4 then '6D' " +
        "     when q21 = 9 then 'NA' " +
        "end q21, " +
        "case when q22 = 1 then 'Confirmed' " +
        "     when q22 = 2 then 'Not Confirmed' " +
        "     when q22 = 9 then 'NA' " +
        "end q22, " +
        "q23, " +
        " comments " +
        " FROM sample_entry a inner join sample_recv b on a.studyid = b.studyid and b.studyid = '" + studyid.Text + "'";


                //ds = obj_op.ExecuteNonQuery(fldname, fldvalue, "sp_GetRecords");
                ds = ExecuteNonQuery_Qry(fldname, fldvalue, qry);


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


            string qry = "SELECT id, " +
        "studyid, " +
        "childid, " +
        "dssid, " +
        "case when q1 = 1 then 'Matiari'" +
        "end q1, " +
        "q2, " +
        "q3, " +
        "q3a, " +
        "case when q4 = 1 then 'Yes'" +
        "     when q4 = 2 then 'No' " +
        "end q4, " +
        "convert(varchar(13), q5dt, 103) q5dt, " +
        "convert(varchar(13), q5dt, 103) q5dta, " +
        "q5t, " +
        "case when q6 = 1 then 'Yes' " +
        "     when q6 = 2 then 'No' " +
        "end q6, " +
        "case when q7 = 1 then 'Intact' " +
        "    when q7 = 2 then 'Physical Damage' " +
        "    when q7 = 3 then 'Without swab stick' " +
        "    when q7 = 4 then 'Without media' " +
        "end q7, " +
        "q8, " +
        "convert(varchar(13), q9dt, 103) q9dt, " +
        "convert(varchar(13), q9dt, 103) q9dta, " +
        "q9t, " +
        "q10, " +
        "q10a, " +
        "q8a, " +
        "convert(varchar(13), q9dt1, 103) q9dt1, " +
        "convert(varchar(13), q9dt1, 103) q9dt1a, " +
        "q9ta, " +
        "q10a1, " +
        "q10a2 " +
        " FROM sample_recv where studyid='" + studyid.Text + "'";


            string val = obj_op.GetDataFieldWise("0", "sp_GetRecords", "q6", studyid.Text);



            qry = "SELECT a.id, " +
        "b.q2, " +
        "b.q3, " +
        "b.q3a, " +
        "b.childid, " +
        "b.studyid, " +
        "case when b.q1 = 1 then 'Matiari' " +
        "end q1, " +
        "b.q2, " +
        "b.q3, " +
        "b.q3a, " +
        "q4a, " +
        "convert(varchar(13), b.q5dt, 103) q5dta, " +
        "case when q5 = 1 then 'Yes' " +
        "     when q5 = 2 then 'No' " +
        "end q5, " +
        "case when b.q7 = 1 then 'Yes' " +
        "     when b.q7 = 2 then 'No' " +
        "end q7, " +
        "case when b.q8 = 1 then 'Intact' " +
        "    when b.q8 = 2 then 'Physical Damage' " +
        "    when b.q8 = 3 then 'Without swab stick' " +
        "    when b.q8 = 4 then 'Without media' " +
        "end q8, " +
        "q9, " +
        "convert(varchar(13), q10dt, 103) q10dt, " +
        "convert(varchar(13), q10dt, 103) q10dta, " +
        "q10t, " +
        "q11, " +
        "case when q12 = 1 then 'Yes' " +
        "     when q12 = 2 then 'No' " +
        "end q12, " +
        "q13, " +
        "case when q14 = 1 then 'POS' " +
        "     when q14 = 2 then 'NEG' " +
        "     when q14 = 9 then 'NOT APPLICABLE' " +
        "end q14, " +
        "q15a1, " +
        "q15b1, " +
        "q15c1, " +
        "case when q15c1 = 1 then 'S' " +
        "     when q15c1 = 2 then 'I' " +
        "     when q15c1 = 3 then 'R' " +
        "end q15c11, " +
        "q15a2, " +
        "q15b2, " +
        "q15c2, " +
        "case when q15c2 = 1 then 'S' " +
        "     when q15c2 = 2 then 'I' " +
        "     when q15c2 = 3 then 'R' " +
        "end q15c21, " +
        "q15a3, " +
        "q15b3, " +
        "q15c3, " +
        "case when q15c3 = 1 then 'S' " +
        "     when q15c3 = 2 then 'I' " +
        "     when q15c3 = 3 then 'R' " +
        "end q15c31, " +
        "q15a4, " +
        "q15b4, " +
        "q15c4, " +
        "case when q15c4 = 1 then 'S' " +
        "     when q15c4 = 2 then 'I' " +
        "     when q15c4 = 3 then 'R' " +
        "end q15c41, " +
        "q15a5, " +
        "q15b5, " +
        "q15c5, " +
        "case when q15c5 = 1 then 'S' " +
        "     when q15c5 = 2 then 'I' " +
        "     when q15c5 = 3 then 'R' " +
        "end q15c51, " +
        "q15a6, " +
        "q15b6, " +
        "q15c6, " +
        "case when q15c6 = 1 then 'S' " +
        "     when q15c6 = 2 then 'I' " +
        "     when q15c6 = 3 then 'R' " +
        "end q15c61, " +
        "q15a7, " +
        "q15b7, " +
        "q15c7, " +
        "case when q15c7 = 1 then 'S' " +
        "     when q15c7 = 2 then 'I' " +
        "     when q15c7 = 3 then 'R' " +
        "end q15c71, " +
        "case when q16signa1 = 1 then '<' " +
        "     when q16signa1 = 2 then '>' " +
        "     when q16signa1 = 3 then '=' " +
        "     when q16signa1 = 4 then '>=' " +
        "     when q16signa1 = 5 then '<=' " +
        "end q16signa1a, " +
        "q16signa1, " +
        "q16a1, " +
        "q16b1, " +
        "q16c1, " +
        "case when q16c1 = 1 then 'S' " +
        "     when q16c1 = 2 then 'I' " +
        "     when q16c1 = 3 then 'R' " +
        "end q16c11, " +
        "case when q16signa2 = 1 then '<' " +
        "     when q16signa2 = 2 then '>' " +
        "     when q16signa2 = 3 then '=' " +
        "     when q16signa2 = 4 then '>=' " +
        "     when q16signa2 = 5 then '<=' " +
        "end q16signa2a, " +
        "q16signa2, " +
        "q16a2, " +
        "q16b2, " +
        "q16c2, " +
        "case when q16c2 = 1 then 'S' " +
        "     when q16c2 = 2 then 'I' " +
        "     when q16c2 = 3 then 'R' " +
        "end q16c21, " +
        "case when q16signa3 = 1 then '<' " +
        "     when q16signa3 = 2 then '>' " +
        "     when q16signa3 = 3 then '=' " +
        "     when q16signa3 = 4 then '>=' " +
        "     when q16signa3 = 5 then '<=' " +
        "end q16signa3a, " +
        "q16signa3, " +
        "q16a3, " +
        "q16b3, " +
        "q16c3, " +
        "case when q16c3 = 1 then 'S' " +
        "     when q16c3 = 2 then 'I' " +
        "     when q16c3 = 3 then 'R' " +
        "end q16c31, " +
        "case when q16c = 1 then 'Yes' " +
        "     when q16c = 2 then 'No' " +
        "end q16c, " +
        "q17a1, " +
        "q17b1, " +
        "q17c1, " +
        "case when q17c1 = 1 then 'S' " +
        "     when q17c1 = 2 then 'I' " +
        "     when q17c1 = 3 then 'R' " +
        "end q17c1155, " +
        "q17a2, " +
        "q17b2, " +
        "q17c2, " +
        "case when q17c2 = 1 then 'S' " +
        "     when q17c2 = 2 then 'I' " +
        "     when q17c2 = 3 then 'R' " +
        "end q17c21, " +
        "q17a99, " +
        "q17b99, " +
        "q17c3, " +
        "case when q17c3 = 1 then 'S' " +
        "     when q17c3 = 2 then 'I' " +
        "     when q17c3 = 3 then 'R' " +
        "end q17c31, " +
        "q17a3, " +
        "q17b3, " +
        "q17c4, " +
        "case when q17c4 = 1 then 'S' " +
        "     when q17c4 = 2 then 'I' " +
        "     when q17c4 = 3 then 'R' " +
        "end q17c41, " +
        "q17a4, " +
        "q17b4, " +
        "q17c5, " +
        "case when q17c5 = 1 then 'S' " +
        "     when q17c5 = 2 then 'I' " +
        "     when q17c5 = 3 then 'R' " +
        "end q17c51, " +
        "q17a5, " +
        "q17b5, " +
        "q17c6, " +
        "case when q17c6 = 1 then 'S' " +
        "     when q17c6 = 2 then 'I' " +
        "     when q17c6 = 3 then 'R' " +
        "end q17c61, " +
        "q17a6, " +
        "q17b6, " +
        "q17c7, " +
        "case when q17c7 = 1 then 'S' " +
        "     when q17c7 = 2 then 'I' " +
        "     when q17c7 = 3 then 'R' " +
        "end q17c71, " +
        "q17a7, " +
        "q17b7, " +
        "q17c8, " +
        "case when q17c8 = 1 then 'S' " +
        "     when q17c8 = 2 then 'I' " +
        "     when q17c8 = 3 then 'R' " +
        "end q17c81, " +
        "q17a8, " +
        "q17b8, " +
        "q17c9, " +
        "case when q17c9 = 1 then 'S' " +
        "     when q17c9 = 2 then 'I' " +
        "     when q17c9 = 3 then 'R' " +
        "end q17c91, " +
        "q17a9, " +
        "q17b9, " +
        "q17c10, " +
        "case when q17c10 = 1 then 'S' " +
        "     when q17c10 = 2 then 'I' " +
        "     when q17c10 = 3 then 'R' " +
        "end q17c101, " +
        "q17a10, " +
        "q17b10, " +
        "q17c11, " +
        "case when q17c11 = 1 then 'S' " +
        "     when q17c11 = 2 then 'I' " +
        "     when q17c11 = 3 then 'R' " +
        "end q17c111, " +
        "case when q18signa1 = 1 then '<' " +
        "     when q18signa1 = 2 then '>' " +
        "     when q18signa1 = 3 then '=' " +
        "     when q18signa1 = 4 then '>=' " +
        "     when q18signa1 = 5 then '<=' " +
        "end q18signa1a, " +
        "q18signa1, " +
        "q18a1, " +
        "q18b1, " +
        "q18c1, " +
        "case when q18c1 = 1 then 'S' " +
        "     when q18c1 = 2 then 'I' " +
        "     when q18c1 = 3 then 'R' " +
        "end q18c11, " +
        "case when q19 = 1 then 'Yes' " +
        "     when q19 = 2 then 'No' " +
        "     when q19 = 9 then 'NA' " +
        "end q19, " +
        "q20, " +
        "case when q21 = 1 then '6A' " +
        "     when q21 = 2 then '6B' " +
        "     when q21 = 3 then '6C' " +
        "     when q21 = 4 then '6D' " +
        "     when q21 = 9 then 'NA' " +
        "end q21, " +
        "case when q22 = 1 then 'Confirmed' " +
        "     when q22 = 2 then 'Not Confirmed' " +
        "     when q22 = 9 then 'NA' " +
        "end q22, " +
        "q23, " +
        " comments " +
        " FROM sample_entry a inner join sample_recv b on a.studyid = b.studyid and b.studyid = '" + studyid.Text + "'";


            string val1 = obj_op.GetDataFieldWise("1", "sp_GetRecords", "q2", qry);

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




        public DataSet ExecuteNonQuery_Qry(string[] fieldName, string[] fieldValues, string qry)
        {
            SqlCommand cmd = null;
            CConnection cn = null;
            SqlDataAdapter da = null;
            DataSet ds = null;

            string[] dt;


            try
            {
                cn = new CConnection();

                cmd = new SqlCommand();
                cmd.Connection = cn.cn;
                cmd.CommandText = qry;
                cmd.CommandType = CommandType.Text;

                for (int a = 0; a <= fieldName.Length - 1; a++)
                {
                    if (fieldValues[a] == "" || fieldValues[a] == " -" || fieldValues[a] == "  /  /" || fieldValues[a] == "  :" || fieldValues[a] == "" || fieldValues[a] == "  -   -  -      -  - -" || fieldValues[a] == "3-     -" || fieldValues[a] == "  ." || fieldValues[a] == "  -   -  -    -  - -")
                    {
                        cmd.Parameters.AddWithValue(fieldName[a], DBNull.Value);
                    }
                    else
                    {
                        if (fieldName[a] == "DOP" || fieldName[a] == "StartDate" || fieldName[a] == "EndDate" || fieldName[a] == "AADOP")
                        {
                            if (fieldValues[a].ToString() == "01/01/0001")
                            {
                                cmd.Parameters.AddWithValue(fieldName[a], DBNull.Value);
                            }
                            else
                            {
                                dt = fieldValues[a].Split('/');
                                cmd.Parameters.AddWithValue(fieldName[a], dt[1] + "/" + dt[0] + "/" + dt[2]);
                            }
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(fieldName[a], fieldValues[a]);
                        }
                    }
                }

                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);

            }

            catch (Exception ex)
            {

            }

            finally
            {
                cn.MConnClose();
                cmd = null;
                cn = null;
            }

            return ds;
        }



    }
}