using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.IO;

namespace PCV10_LabSystem
{
    public partial class specimen : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            cmdSave.OnClientClick = "return chk();";

            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    studyid.Text = Request.QueryString["id"];
                    studyid.BackColor = Color.Silver;
                    studyid.Enabled = false;

                    FillGrid(studyid.Text, "0");
                }
                else if (Session["id"] != null)
                {
                    if (Session["mycookierole"].ToString() == "receiving" || Session["mycookierole"].ToString() == "idrl"
                        || Session["mycookierole"].ToString() == "admin")
                    {
                        string id = Session["id"].ToString();
                        FillGrid(id, "0");
                    }
                    else
                    {
                        Response.Redirect("~/Account/Login.aspx?errmsg=You do not have permission to view this page");
                        Session.Remove("id");
                    }
                }
                else
                {
                    if (Session["mycookierole"].ToString() == "receiving" || Session["mycookierole"].ToString() == "idrl"
                        || Session["mycookierole"].ToString() == "admin")
                    {
                        DateTime dt_entry = new DateTime();
                        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                        dt_entry = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    }
                    else
                    {
                        Response.Redirect("~/Account/Login.aspx?errmsg=You do not have permission to view this page");
                        Session.Remove("id");
                        Session.Remove("mycookierole");
                    }
                }
            }

            lblerr.Text = "";
        }





        private void FillGrid(string sno, string fieldvalue)
        {
            CDBOperations obj_op = new CDBOperations();
            DataSet ds = null;

            try
            {
                string[] fldname = { "var_studyid", "fldval" };
                string[] fldvalue = { sno, fieldvalue };

                ds = obj_op.ExecuteNonQuery(fldname, fldvalue, "sp_GetRecords");

                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            studyid.Text = Session["id"].ToString();
                            studyid.BackColor = Color.Silver;
                            studyid.Enabled = false;

                            childid.Text = ds.Tables[0].Rows[0]["childid"].ToString();
                            dssid.Text = ds.Tables[0].Rows[0]["dssid"].ToString();


                            if (ds.Tables[0].Rows[0]["q1"].ToString() == "Matiari")
                            {
                                q1.SelectedValue = "1";
                            }


                            q2.Text = ds.Tables[0].Rows[0]["q2"].ToString();
                            q3.Text = ds.Tables[0].Rows[0]["q3"].ToString();
                            q3a.Text = ds.Tables[0].Rows[0]["q3a"].ToString();


                            if (ds.Tables[0].Rows[0]["q4"].ToString() == "Yes")
                            {
                                q4.SelectedValue = "1";
                            }
                            else
                            {
                                q4.SelectedValue = "2";
                            }


                            q5dt.Text = ds.Tables[0].Rows[0]["q5dta"].ToString();



                            string[] arr_q5t = ds.Tables[0].Rows[0]["q5t"].ToString().Split(':');

                            if (ds.Tables[0].Rows[0]["q5t"].ToString() != "")
                            {
                                q5t.Text = arr_q5t[0] + ":" + arr_q5t[1];
                            }




                            if (ds.Tables[0].Rows[0]["q6"].ToString() == "Yes")
                            {
                                q6.SelectedValue = "1";
                            }
                            else
                            {
                                q6.SelectedValue = "2";
                            }





                            if (ds.Tables[0].Rows[0]["q7"].ToString() == "Intact")
                            {
                                q7.SelectedValue = "1";
                            }
                            else if (ds.Tables[0].Rows[0]["q7"].ToString() == "Physical Damage")
                            {
                                q7.SelectedValue = "2";
                            }
                            else if (ds.Tables[0].Rows[0]["q7"].ToString() == "Without swab stick")
                            {
                                q7.SelectedValue = "3";
                            }
                            else if (ds.Tables[0].Rows[0]["q7"].ToString() == "Without media")
                            {
                                q7.SelectedValue = "4";
                            }


                            q8.Text = ds.Tables[0].Rows[0]["q8"].ToString();
                            q9dt.Text = ds.Tables[0].Rows[0]["q9dta"].ToString();


                            string[] arr_q9t = ds.Tables[0].Rows[0]["q9t"].ToString().Split(':');

                            if (ds.Tables[0].Rows[0]["q9t"].ToString() != "")
                            {
                                q9t.Text = arr_q9t[0] + ":" + arr_q9t[1];
                            }




                            q8a.Text = ds.Tables[0].Rows[0]["q8a"].ToString();
                            q9dt1.Text = ds.Tables[0].Rows[0]["q9dt1a"].ToString();


                            string[] arr_q9ta = ds.Tables[0].Rows[0]["q9ta"].ToString().Split(':');

                            if (ds.Tables[0].Rows[0]["q9ta"].ToString() != "")
                            {
                                q9ta.Text = arr_q9ta[0] + ":" + arr_q9ta[1];
                            }



                            if (q6.SelectedValue == "1")
                            {
                                EnableControls(q7);
                                EnableControls(q8);
                                EnableControls(q9dt);
                                EnableControls(q9t);

                                EnableControls(q8a);
                                EnableControls(q9dt1);
                                EnableControls(q9ta);
                            }
                            else
                            {
                                DisableControls(q7);
                                DisableControls(q8);
                                DisableControls(q9dt);
                                DisableControls(q9t);

                                DisableControls(q8a);
                                DisableControls(q9dt1);
                                DisableControls(q9ta);
                            }



                            q10.Text = ds.Tables[0].Rows[0]["q10"].ToString();
                            q10a.Text = ds.Tables[0].Rows[0]["q10a"].ToString();


                            q10a1.Text = ds.Tables[0].Rows[0]["q10a1"].ToString();
                            q10a2.Text = ds.Tables[0].Rows[0]["q10a2"].ToString();

                        }
                    }
                }
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



        public void GetUnit(string fieldvalue, string val1, string val2, DropDownList ddl, string txt, string selectedValue)
        {
            CDBOperations obj_op = new CDBOperations();
            DataSet ds = null;

            try
            {
                string[] fldname = { "sno", "fldvalue" };
                string[] fldvalue = { "", fieldvalue };

                ds = obj_op.ExecuteNonQuery(fldname, fldvalue, "sp_GetRecords");

                ddl.DataSource = ds;
                ddl.DataValueField = ds.Tables[0].Columns[val2].ColumnName;
                ddl.DataTextField = ds.Tables[0].Columns[val1].ColumnName;
                ddl.DataBind();

                ddl.Items.Add(new ListItem("Select " + txt, "0"));
                ddl.SelectedValue = selectedValue;
            }

            catch (Exception ex)
            {
                //lblerr.Text = ex.Message;
            }

            finally
            {
                obj_op = null;
            }
        }



        public bool IsChildExists(string childid1)
        {
            bool IsExists = false;

            SqlCommand cmd = null;
            CConnection cn = null;

            try
            {
                cn = new CConnection();
                cn.MConnOpen();

                if (childid1 != "999999999")
                {
                    cmd = new SqlCommand("select * from sample_recv where childid = '" + childid1 + "'", cn.cn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        if (childid1 == dr.GetValue(dr.GetOrdinal("childid")).ToString() && studyid.Text != dr.GetValue(dr.GetOrdinal("studyid")).ToString())
                        {
                            IsExists = true;
                            lblerr.Text = "Child ID [ " + childid1 + " ] already exists against study id  [ " + dr.GetValue(dr.GetOrdinal("studyid")) + " ]";
                            lblerr.CssClass = "message-error";
                        }
                    }
                }
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

            return IsExists;
        }



        public bool IsFTagExists1(string childid, string id)
        {
            CDBOperations obj_op = new CDBOperations();
            DataSet ds = null;
            bool IsExists = false;

            try
            {
                string[] fldname = { "Criteria", "id", "fldvalue" };
                string[] fldvalue = { childid, "", "0" };

                ds = obj_op.ExecuteNonQuery(fldname, fldvalue, "sp_IsFTagExists");

                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            IsExists = true;
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                lblerr.Text = ex.ToString();
                lblerr.CssClass = "message-error";
            }

            finally
            {
                obj_op = null;
            }

            return IsExists;
        }




        protected void cmdSave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(studyid.Text) == true)
            {
                lblerr.Text = "Please enter study id ";
                lblerr.CssClass = "message-error";
                studyid.Focus();
            }
            else if (childid.Text == "")
            {
                lblerr.Text = "Please enter child id  ";
                lblerr.CssClass = "message-error";
                childid.Focus();
            }
            else if (dssid.Text == "")
            {
                lblerr.Text = "Please enter dss id  ";
                lblerr.CssClass = "message-error";
                dssid.Focus();
            }
            else if (q1.SelectedValue == "0")
            {
                lblerr.Text = "Please select field site  ";
                lblerr.CssClass = "message-error";
                q1.Focus();
            }
            else if (q2.Text == "")
            {
                lblerr.Text = "Please enter physician name ";
                lblerr.CssClass = "message-error";
                q2.Focus();
            }
            else if (q3.Text == "")
            {
                lblerr.Text = "Please enter mother name ";
                lblerr.CssClass = "message-error";
                q3.Focus();
            }
            else if (q3a.Text == "")
            {
                lblerr.Text = "Please enter child name ";
                lblerr.CssClass = "message-error";
                q3a.Focus();
            }
            else if (q4.SelectedValue == "0")
            {
                lblerr.Text = "Please select swab collected ";
                lblerr.CssClass = "message-error";
                q4.Focus();
            }
            else if (q5dt.Text == "")
            {
                lblerr.Text = "Please enter collection date ";
                lblerr.CssClass = "message-error";
                q5dt.Focus();
            }
            else if (q5t.Text == "")
            {
                lblerr.Text = "Please enter collection time ";
                lblerr.CssClass = "message-error";
                q5t.Focus();
            }
            else if (q6.SelectedValue == "0")
            {
                lblerr.Text = "Please select specimen ";
                lblerr.CssClass = "message-error";
                q6.Focus();
            }
            else if (q7.SelectedValue == "0" && q7.Enabled == true)
            {
                lblerr.Text = "Please select condition of the STGG tube ";
                lblerr.CssClass = "message-error";
                q7.Focus();
            }
            else if (q8.Text == "" && q8.Enabled == true)
            {
                lblerr.Text = "Please enter temperature ";
                lblerr.CssClass = "message-error";
                q8.Focus();
            }
            else if (q9dt.Text == "" && q9dt.Enabled == true)
            {
                lblerr.Text = "Please enter receving date of matiari lab ";
                lblerr.CssClass = "message-error";
                q9dt.Focus();
            }
            else if (q9t.Text == "" && q9t.Enabled == true)
            {
                lblerr.Text = "Please enter receiving time of matiari lab ";
                lblerr.CssClass = "message-error";
                q9t.Focus();
            }
            else if (q10.Text == "" && q10.Enabled == true)
            {
                lblerr.Text = "Please enter laboratory person of matiari lab ";
                lblerr.CssClass = "message-error";
                q10.Focus();
            }
            else if (q10a.Text == "" && q10a.Enabled == true)
            {
                lblerr.Text = "Please enter laboratory person code of matiari lab ";
                lblerr.CssClass = "message-error";
                q10a.Focus();
            }
            else if (q8a.Text == "" && q8a.Enabled == true)
            {
                lblerr.Text = "Please enter temperature ";
                lblerr.CssClass = "message-error";
                q8a.Focus();
            }
            else if (q9dt1.Text == "" && q9dt1.Enabled == true)
            {
                lblerr.Text = "Please enter receiving date of karachi lab ";
                lblerr.CssClass = "message-error";
                q9dt1.Focus();
            }
            else if (q9ta.Text == "" && q9ta.Enabled == true)
            {
                lblerr.Text = "Please enter receiving time of karachi lab ";
                lblerr.CssClass = "message-error";
                q9ta.Focus();
            }
            else if (q10a1.Text == "" && q10a1.Enabled == true)
            {
                lblerr.Text = "Please enter laboratory person of karachi lab ";
                lblerr.CssClass = "message-error";
                q10a1.Focus();
            }
            else if (q10a2.Text == "" && q10a2.Enabled == true)
            {
                lblerr.Text = "Please enter laboratory person code of matiari lab ";
                lblerr.CssClass = "message-error";
                q10a2.Focus();
            }
            else
            {
                if (cmdSave.Text == "  Save " && Session["id"] != null)
                {
                    string id = Session["id"].ToString();

                    if (IsChildExists(childid.Text) == false)
                    {
                        if (AuditTrials("sp_AuditTrials") == 0)
                        {
                            SaveData(id);
                            //Session.Remove("id");
                        }
                        else
                        {
                            lblerr.Text = "Error occurred in audit trials ";
                            lblerr.CssClass = "message-success1";
                        }
                    }
                }
                else
                {
                    if (IsChildExists(childid.Text) == false)
                    {
                        SaveData("0");
                        //Session.Remove("id");
                    }
                }
            }
        }

        private void SaveData(string id)
        {
            string[] fldname = { };
            string[] fldvalue = { };

            CDBOperations obj_op = new CDBOperations();


            try
            {


                DateTime dt_entry = new DateTime();
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_entry = Convert.ToDateTime(DateTime.Now.ToShortDateString());


                DateTime dt_q5 = new DateTime();
                if (string.IsNullOrEmpty(q5dt.Text) == false)
                {
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                    dt_q5 = Convert.ToDateTime(q5dt.Text);
                }


                DateTime dt_q9 = new DateTime();
                if (string.IsNullOrEmpty(q9dt.Text) == false)
                {
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                    dt_q9 = Convert.ToDateTime(q9dt.Text);
                }


                DateTime dt_q9a = new DateTime();
                if (string.IsNullOrEmpty(q9dt1.Text) == false)
                {
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                    dt_q9a = Convert.ToDateTime(q9dt1.Text);
                }



                if (dt_q5.ToShortDateString() != "01/01/0001" && dt_q9.ToShortDateString() != "01/01/0001" && dt_q9a.ToShortDateString() != "01/01/0001")
                {

                    //day_no = obj_op.DaysDifference("22", "sp_CalculateDays", "DATE_DIFF", "", dt_q5.ToShortDateString(), dt_q9.ToShortDateString(), "0");


                    if (dt_q5 > DateTime.Now.Date)
                    {
                        lblerr.Text = "Collection date cannot be greater than current date ";
                        lblerr.CssClass = "message-error";
                        q5dt.Focus();
                        return;
                    }
                    else if (dt_q9 > DateTime.Now.Date)
                    {
                        lblerr.Text = "Matiari Receiving date cannot be greater than current date ";
                        lblerr.CssClass = "message-error";
                        q9dt.Focus();
                        return;
                    }
                    else if (dt_q9a > DateTime.Now.Date)
                    {
                        lblerr.Text = "Karachi Receiving date cannot be greater than current date ";
                        lblerr.CssClass = "message-error";
                        q9dt1.Focus();
                        return;
                    }
                    else if (dt_q5 > dt_q9)
                    {
                        lblerr.Text = "Collection date cannot be greater than matiari receiving date ";
                        lblerr.CssClass = "message-error";
                        q5dt.Focus();
                        return;
                    }
                    else if (dt_q5 > dt_q9a)
                    {
                        lblerr.Text = "Collection date cannot be greater than karachi receiving date ";
                        lblerr.CssClass = "message-error";
                        q5dt.Focus();
                        return;
                    }
                    else if (dt_q9 > dt_q9a)
                    {
                        lblerr.Text = "Collection date of matiari site cannot be greater than karachi site ";
                        lblerr.CssClass = "message-error";
                        q9dt.Focus();
                        return;
                    }
                }


                string mytime_q5t = "";
                if (q5t.Text != "")
                {
                    string[] arr_t = q5t.Text.Split(':');
                    mytime_q5t = arr_t[0].Trim() + ":" + arr_t[1].Trim() + ":00";
                }


                string mytime_q9t = "";
                if (q9t.Text != "")
                {
                    string[] arr_t = q9t.Text.Split(':');
                    mytime_q9t = arr_t[0].Trim() + ":" + arr_t[1].Trim() + ":00";
                }


                string mytime_q9ta = "";
                if (q9ta.Text != "")
                {
                    string[] arr_t = q9ta.Text.Split(':');
                    mytime_q9ta = arr_t[0].Trim() + ":" + arr_t[1].Trim() + ":00";
                }



                if (id == "0")
                {
                    string[] fldname1 = { "var_studyid", "var_childid", "var_dssid", "var_q1", "var_q2", "var_q3", "var_q3a", "var_q4", "var_q5dt", "var_q5t", "var_q6", "var_q7", "var_q8", "var_q9dt", "var_q9t", "var_q10", "var_q10a", "var_q8a", "var_q9dt1", "var_q9ta", "var_q10a1", "var_q10a2", "var_userid", "var_entrydate" };
                    string[] fldvalue1 = { studyid.Text, childid.Text, dssid.Text, q1.Text, q2.Text, q3.Text, q3a.Text, q4.Text, dt_q5.ToShortDateString(), mytime_q5t, q6.Text, q7.Text, q8.Text, dt_q9.ToShortDateString(), mytime_q9t, q10.Text, q10a.Text, q8a.Text, dt_q9a.ToShortDateString(), mytime_q9ta, q10a1.Text, q10a2.Text, Session["UserID"].ToString(), dt_entry.ToShortDateString() };

                    fldname = fldname1;
                    fldvalue = fldvalue1;
                }
                else
                {
                    string[] fldname1 = { "var_studyid", "var_childid", "var_dssid", "var_q1", "var_q2", "var_q3", "var_q3a", "var_q4", "var_q5dt", "var_q5t", "var_q6", "var_q7", "var_q8", "var_q9dt", "var_q9t", "var_q10", "var_q10a", "var_q8a", "var_q9dt1", "var_q9ta", "var_q10a1", "var_q10a2", "var_userid", "var_entrydate" };
                    string[] fldvalue1 = { studyid.Text, childid.Text, dssid.Text, q1.Text, q2.Text, q3.Text, q3a.Text, q4.Text, dt_q5.ToShortDateString(), mytime_q5t, q6.Text, q7.Text, q8.Text, dt_q9.ToShortDateString(), mytime_q9t, q10.Text, q10a.Text, q8a.Text, dt_q9a.ToShortDateString(), mytime_q9ta, q10a1.Text, q10a2.Text, Session["UserID"].ToString(), dt_entry.ToShortDateString() };

                    fldname = fldname1;
                    fldvalue = fldvalue1;
                }


                string errmsg = obj_op.ExecuteNonQuery_Inventory(fldname, fldvalue, "sp_specimenentry");


                ClearFields();


                if (string.IsNullOrEmpty(errmsg) == true)
                {
                    lblerr.Text = "Record saved successfully ";
                    lblerr.CssClass = "message-success1";
                }
                else
                {
                    lblerr.Text = errmsg;
                    lblerr.CssClass = "message-error";
                }
            }

            catch (Exception ex)
            {
                lblerr.Text = ex.Message;
                lblerr.CssClass = "message-error";
            }

            finally
            {
                obj_op = null;
            }
        }


        public static string GetUniqueFilename(string folder, string postedFileName)
        {
            string fileExtension = postedFileName.Substring(postedFileName.LastIndexOf('.') + 1);
            int index = 2;

            while (File.Exists(string.Format("{0}", postedFileName)))
            {
                if (index == 2)
                    postedFileName =
                        string.Format("{0} ({1}).{2}",
                                      postedFileName.Substring(0, postedFileName.LastIndexOf('.')),
                                      index,
                                      fileExtension);
                else
                    postedFileName =
                        string.Format("{0} ({1}).{2}",
                                      postedFileName.Substring(0, postedFileName.LastIndexOf(' ')),
                                      index,
                                      fileExtension);
                index++;
            }

            return postedFileName;
        }



        private void ClearFields()
        {

            studyid.Text = "";
            childid.Text = "";
            dssid.Text = "";
            q1.SelectedValue = "0";
            q2.Text = "";
            q3.Text = "";
            q3a.Text = "";
            q4.SelectedValue = "0";
            q5dt.Text = "";
            q5t.Text = "";
            q6.SelectedValue = "0";
            q7.SelectedValue = "0";
            q8.Text = "";
            q9dt.Text = "";
            q9t.Text = "";
            q10.Text = "";
            q10a.Text = "";
            q8a.Text = "";
            q9dt1.Text = "";
            q9ta.Text = "";
            q10a1.Text = "";
            q10a2.Text = "";

            Session.Remove("id");

            studyid.Focus();
        }

        protected void cmdCal_Click(object sender, EventArgs e)
        {
            Control cntl = (Control)FindControl("ContentPlaceHolder1_datepicker");

            if (cntl != null)
            {

            }
        }

        protected void STATUS_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void cmdCancel_Click(object sender, EventArgs e)
        {
            ClearFields();
        }




        private int AuditTrials(string spName)
        {
            CDBOperations obj_op = null;
            DataSet ds = null;
            DataSet ds_dict = null;
            int result = 0;
            DropDownList ddlStatus1 = null;
            TextBox txtbox = null;


            string[] arr;
            string req_id = "";


            try
            {

                req_id = Session["id"].ToString();


                obj_op = new CDBOperations();
                ds = obj_op.GetFormData_VisitID("sp_GetRecords", "2", req_id, "");


                ds_dict = obj_op.GetFormData_VisitID1("sp_GetRecords1", "0", "sample_recv");


                for (int a = 0; a <= ds_dict.Tables[0].Rows.Count - 1; a++)
                {

                    for (int b = 0; b <= ds.Tables[0].Rows.Count - 1; b++)
                    {

                        if (ds_dict.Tables[0].Rows[a]["var_id"].ToString() != "id" && ds_dict.Tables[0].Rows[a]["var_id"].ToString() != "entrydate" && ds_dict.Tables[0].Rows[a]["var_id"].ToString() != "userid")
                        {

                            //if (ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["var_id"].ToString()].ToString() != tabControl1.TabPages[Convert.ToInt32(ds_dict.Tables[0].Rows[a]["TabPageNo"].ToString())].Controls[ds_dict.Tables[0].Rows[a]["var_id"].ToString()].Text)

                            if (ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q1"
                                || ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q4"
                                || ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q6" || ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q7")
                            {

                                ddlStatus1 = (DropDownList)Page.FindControl("ctl00$ContentPlaceHolder1$" + ds_dict.Tables[0].Rows[a]["var_id"].ToString());


                                if (ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["var_id"].ToString()].ToString() != ddlStatus1.Text)
                                {

                                    AddRecord(spName, ds.Tables[0].Rows[b]["studyid"].ToString(), "", "", "sample_recv", "Update", ds_dict.Tables[0].Rows[a]["var_id"].ToString(), ds.Tables[0].Rows[0][ds_dict.Tables[0].Rows[a]["var_id"].ToString()].ToString(), ddlStatus1.SelectedValue.ToUpper());

                                }

                            }
                            else if (ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q5dt" || ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q9dt"
                                    || ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q9dt1")
                            {
                                txtbox = (TextBox)Page.FindControl("ctl00$ContentPlaceHolder1$" + ds_dict.Tables[0].Rows[a]["var_id"].ToString());


                                if (ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["var_id"].ToString()].ToString() != txtbox.Text)
                                {

                                    if (ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["var_id"].ToString()].ToString() == "" && txtbox.Text == "  -  -")
                                    {

                                    }
                                    else if (ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["var_id"].ToString()].ToString() == "  .")
                                    {

                                    }
                                    else
                                    {
                                        string[] arr11 = ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["var_id"].ToString()].ToString().Split('-');
                                        string[] arr12 = txtbox.Text.Split('/');

                                        if (ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["var_id"].ToString()].ToString() != "")
                                        {
                                            string mydt11 = arr11[2] + "-" + arr11[1] + "-" + arr11[0];
                                            string mydt12 = arr12[0] + "-" + arr12[1] + "-" + arr12[2];
                                            string mydt13 = arr12[2] + "-" + arr12[1] + "-" + arr12[0];

                                            if (mydt12 != mydt11)
                                            {
                                                AddRecord(spName, ds.Tables[0].Rows[b]["studyid"].ToString(), "", "", "sample_recv", "Update", ds_dict.Tables[0].Rows[a]["var_id"].ToString(), ds.Tables[0].Rows[0][ds_dict.Tables[0].Rows[a]["var_id"].ToString()].ToString(), mydt13);
                                            }
                                        }
                                        else
                                        {
                                            AddRecord(spName, ds.Tables[0].Rows[b]["studyid"].ToString(), "", "", "sample_recv", "Update", ds_dict.Tables[0].Rows[a]["var_id"].ToString(), ds.Tables[0].Rows[0][ds_dict.Tables[0].Rows[a]["var_id"].ToString()].ToString(), txtbox.Text.ToUpper());
                                        }

                                    }

                                }


                            }
                            else if (ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q5t" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q9t" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q9ta")
                            {

                                txtbox = (TextBox)Page.FindControl("ctl00$ContentPlaceHolder1$" + ds_dict.Tables[0].Rows[a]["var_id"].ToString());

                                string[] arr_t = ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["var_id"].ToString()].ToString().Split(':');
                                string[] arr_t1 = txtbox.Text.Split(':');

                                if (ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["var_id"].ToString()].ToString() != "")
                                {
                                    string mytime = arr_t[0].Trim() + ":" + arr_t[1].Trim();
                                    string mytime1 = "";

                                    if (txtbox.Text != "")
                                    {
                                        mytime1 = arr_t1[0] + ":" + arr_t1[1];
                                    }


                                    if (mytime != mytime1)
                                    {
                                        AddRecord(spName, ds.Tables[0].Rows[b]["studyid"].ToString(), "", "", "sample_recv", "Update", ds_dict.Tables[0].Rows[a]["var_id"].ToString(), ds.Tables[0].Rows[0][ds_dict.Tables[0].Rows[a]["var_id"].ToString()].ToString(), txtbox.Text.ToUpper());

                                    }
                                }
                                else
                                {
                                    AddRecord(spName, ds.Tables[0].Rows[b]["studyid"].ToString(), "", "", "sample_recv", "Update", ds_dict.Tables[0].Rows[a]["var_id"].ToString(), ds.Tables[0].Rows[0][ds_dict.Tables[0].Rows[a]["var_id"].ToString()].ToString(), txtbox.Text.ToUpper());
                                }

                            }
                            else if (ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q8"
                                    || ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q8a")
                            {

                                txtbox = (TextBox)Page.FindControl("ctl00$ContentPlaceHolder1$" + ds_dict.Tables[0].Rows[a]["var_id"].ToString());

                                if (ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["var_id"].ToString()].ToString() != txtbox.Text)
                                {

                                    AddRecord(spName, ds.Tables[0].Rows[b]["studyid"].ToString(), "", "", "sample_recv", "Update", ds_dict.Tables[0].Rows[a]["var_id"].ToString(), ds.Tables[0].Rows[0][ds_dict.Tables[0].Rows[a]["var_id"].ToString()].ToString(), txtbox.Text.ToUpper());

                                }

                            }
                            else
                            {
                                txtbox = (TextBox)Page.FindControl("ctl00$ContentPlaceHolder1$" + ds_dict.Tables[0].Rows[a]["var_id"].ToString());

                                if (ds.Tables[0].Rows[0][ds_dict.Tables[0].Rows[a]["var_id"].ToString()].ToString() != txtbox.Text)
                                {
                                    AddRecord(spName, ds.Tables[0].Rows[b]["studyid"].ToString(), "", "", "sample_recv", "Update", ds_dict.Tables[0].Rows[a]["var_id"].ToString(), ds.Tables[0].Rows[0][ds_dict.Tables[0].Rows[a]["var_id"].ToString()].ToString(), txtbox.Text);
                                }

                            }


                        }  //   if (ds.Tables[0].Rows[0][a].ToString() == tabControl1.TabPages[b].Controls[c].Name)



                    }     //   for (int b = 0; b <= tabControl1.TabPages[b].Controls.Count - 1; c++)


                }     //    for (int a = 0; a <= ds.Tables[0].Columns.Count - 1; a++)


            }


            catch (Exception ex)
            {
                lblerr.Text = ex.Message;
                result = 1;
            }

            finally
            {
                obj_op = null;
                ds = null;
            }

            return result;
        }


        private int AddRecord(string spName, string ChildID, string VisitID, string formno, string FormName, string ActionPerformed, string FieldName, string OldValue, string NewValue)
        {
            CDBOperations obj_op = null;
            string[] st_dt;
            string usrName = "";
            int result = 0;

            try
            {
                obj_op = new CDBOperations();

                st_dt = DateTime.Now.ToShortDateString().Split('/');


                DateTime start_dt = new DateTime();
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                start_dt = Convert.ToDateTime(DateTime.Now.ToShortDateString());

                DateTime start_dt1 = new DateTime();
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                start_dt1 = Convert.ToDateTime(DateTime.Now.ToShortTimeString());

                usrName = Server.HtmlEncode(Request.Cookies["mycookie"].Value);


                string[] fldname = { "var_studyid", "var_formname", "var_actionperformed", "var_entrydate", "var_entrytime", "var_loginusername", "var_fieldname", "var_oldvalue", "var_newvalue" };
                string[] fldvalue = { ChildID, FormName, ActionPerformed, start_dt.ToShortDateString(), start_dt1.ToShortTimeString(), usrName, FieldName, OldValue, NewValue };

                result = obj_op.ExecuteNonQuery_New1(fldname, fldvalue, spName);
            }

            catch (Exception ex)
            {
                lblerr.Text = ex.Message;
            }

            finally
            {
                obj_op = null;
            }

            return result;
        }

        protected void q6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (q6.SelectedValue == "1")
            {
                EnableControls(q7);
                EnableControls(q8);
                EnableControls(q9dt);
                EnableControls(q9t);

                EnableControls(q8a);
                EnableControls(q9dt1);
                EnableControls(q9ta);

                q7.Focus();
            }
            else
            {
                DisableControls(q7);

                DisableControls(q8);
                DisableControls(q9dt);
                DisableControls(q9t);

                DisableControls(q8a);
                DisableControls(q9dt1);
                DisableControls(q9ta);

                q10.Focus();
            }
        }


        public void EnableControls(TextBox txtbox)
        {
            try
            {
                txtbox.Enabled = true;
                txtbox.BackColor = System.Drawing.Color.White;
            }
            catch (Exception ex)
            {

            }

            finally
            {
                txtbox = null;
            }
        }



        public void DisableControls(TextBox txtbox)
        {
            try
            {
                txtbox.Enabled = false;
                txtbox.BackColor = System.Drawing.Color.Silver;
                txtbox.Text = "";
            }
            catch (Exception ex)
            {

            }

            finally
            {
                txtbox = null;
            }
        }


        public void EnableControls(DropDownList txtbox)
        {
            try
            {
                txtbox.Enabled = true;
                txtbox.BackColor = System.Drawing.Color.White;
            }
            catch (Exception ex)
            {

            }

            finally
            {
                txtbox = null;
            }
        }



        public void DisableControls(DropDownList txtbox)
        {
            try
            {
                txtbox.Enabled = false;
                txtbox.BackColor = System.Drawing.Color.Silver;
                txtbox.SelectedValue = "0";
            }
            catch (Exception ex)
            {

            }

            finally
            {
                txtbox = null;
            }
        }

        protected void studyid_TextChanged(object sender, EventArgs e)
        {

        }



    }
}