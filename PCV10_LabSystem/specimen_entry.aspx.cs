using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace PCV10_LabSystem
{
    public partial class specimen_entry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["errmsg"] != null)
                {
                    lblerr.Text = Request.QueryString["errmsg"].ToString();
                    lblerr.CssClass = "message-error";
                    Disable_ErrorMsg();

                    cmdSave.Visible = false;
                    cmdCancel.Visible = false;
                }
                else if (Request.QueryString["id"] != null)
                {
                    studyid.Text = Request.QueryString["id"];
                    studyid.Enabled = false;
                    studyid.BackColor = Color.Silver;


                    if (Session["mycookierole"].ToString() == "idrl" || Session["mycookierole"].ToString() == "mdl" || Session["mycookierole"].ToString() == "admin")
                    {
                        if (Session["mycookierole"].ToString() == "receiving")
                        {
                            if (Session["id"] != null)
                            {
                                string id = Session["id"].ToString();
                                FillGrid(id, "1");
                                studyid.Text = id;
                                studyid.Enabled = false;
                                studyid.BackColor = Color.Silver;
                            }


                            Enable_Receiver();
                            Disable_Lab();
                            Disable_Serotyping();
                        }
                        else if (Session["mycookierole"].ToString() == "idrl")
                        {
                            if (Session["id"] != null)
                            {
                                string id = Session["id"].ToString();
                                FillGrid(id, "1");
                                studyid.Text = id;
                                studyid.Enabled = false;
                                studyid.BackColor = Color.Silver;
                            }

                            Enable_Lab();
                            Disable_Receiver();
                            Disable_Serotyping();
                        }
                        else if (Session["mycookierole"].ToString() == "mdl")
                        {
                            if (Session["id"] != null)
                            {
                                string id = Session["id"].ToString();
                                FillGrid(id, "1");
                                studyid.Text = id;
                                studyid.Enabled = false;
                                studyid.BackColor = Color.Silver;
                            }

                            Enable_Serotyping();
                            Disable_Lab();
                            Disable_Receiver();
                        }
                        else
                        {
                            Enable_ErrorMsg();

                            if (Session["id"] != null)
                            {
                                string id = Session["id"].ToString();
                                FillGrid(id, "1");
                                studyid.Text = id;
                                studyid.Enabled = false;
                                studyid.BackColor = Color.Silver;
                            }
                        }
                    }
                    else
                    {
                        Response.Redirect("~/Account/Login.aspx?errmsg=You do not have permission to view this page");
                        Session.Remove("id");
                        Session.Remove("mycookierole");
                    }


                    cmdSave.Visible = true;
                    cmdCancel.Visible = true;
                }
                else
                {
                    cmdSave.Visible = true;
                    cmdCancel.Visible = true;


                    if (Session["mycookierole"].ToString() == "idrl" || Session["mycookierole"].ToString() == "mdl" || Session["mycookierole"].ToString() == "admin")
                    {
                        if (Session["mycookierole"].ToString() == "receiving")
                        {
                            if (Session["id"] != null)
                            {
                                string id = Session["id"].ToString();
                                FillGrid(id, "1");
                                studyid.Text = id;
                                studyid.Enabled = false;
                                studyid.BackColor = Color.Silver;
                            }


                            Enable_Receiver();
                            Disable_Lab();
                            Disable_Serotyping();
                        }
                        else if (Session["mycookierole"].ToString() == "idrl")
                        {
                            if (Session["id"] != null)
                            {
                                string id = Session["id"].ToString();
                                FillGrid(id, "1");
                                studyid.Text = id;
                                studyid.Enabled = false;
                                studyid.BackColor = Color.Silver;
                            }

                            Enable_Lab();
                            Disable_Receiver();
                            Disable_Serotyping();
                        }
                        else if (Session["mycookierole"].ToString() == "mdl")
                        {
                            if (Session["id"] != null)
                            {
                                string id = Session["id"].ToString();
                                FillGrid(id, "1");
                                studyid.Text = id;
                                studyid.Enabled = false;
                                studyid.BackColor = Color.Silver;
                            }

                            Enable_Serotyping();
                            Disable_Lab();
                            Disable_Receiver();
                        }
                        else
                        {
                            Enable_ErrorMsg();

                            if (Session["id"] != null)
                            {
                                string id = Session["id"].ToString();
                                FillGrid(id, "1");
                                studyid.Text = id;
                                studyid.Enabled = false;
                                studyid.BackColor = Color.Silver;
                            }
                        }
                    }
                    else
                    {
                        Response.Redirect("~/Account/Login.aspx?errmsg=You do not have permission to view this page");
                        Session.Remove("id");
                        Session.Remove("mycookierole");
                    }
                }
            }
        }

        protected void cmdCancel_Click(object sender, EventArgs e)
        {
            ClearFields();
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

                            //if (ds.Tables[0].Rows[0]["q1"].ToString() == "Matiari")
                            //{
                            //    q1.SelectedValue = "1";
                            //}

                            //q2.Text = ds.Tables[0].Rows[0]["q2"].ToString();
                            //q3.Text = ds.Tables[0].Rows[0]["q3"].ToString();
                            //q3a.Text = ds.Tables[0].Rows[0]["q3a"].ToString();

                            q4.Text = ds.Tables[0].Rows[0]["childid"].ToString();
                            q4a.Text = ds.Tables[0].Rows[0]["q4a"].ToString();


                            //if (ds.Tables[0].Rows[0]["q5"].ToString() == "Yes")
                            //{
                            //    q5.SelectedValue = "1";
                            //}
                            //else if (ds.Tables[0].Rows[0]["q5"].ToString() == "No")
                            //{
                            //    q5.SelectedValue = "2";
                            //}
                            //else
                            //{
                            //    q5.SelectedValue = "0";
                            //}





                            //q6dt.Text = ds.Tables[0].Rows[0]["q6dt"].ToString();
                            //q6t.Text = ds.Tables[0].Rows[0]["q6t"].ToString();


                            //if (ds.Tables[0].Rows[0]["q7"].ToString() == "Yes")
                            //{
                            //    q7.SelectedValue = "1";
                            //}
                            //else if (ds.Tables[0].Rows[0]["q7"].ToString() == "No")
                            //{
                            //    q7.SelectedValue = "2";
                            //}
                            //else
                            //{
                            //    q7.SelectedValue = "0";
                            //}


                            //if (ds.Tables[0].Rows[0]["q8"].ToString() == "Intact")
                            //{
                            //    q8.SelectedValue = "1";
                            //}
                            //else if (ds.Tables[0].Rows[0]["q8"].ToString() == "Physical Damage")
                            //{
                            //    q8.SelectedValue = "2";
                            //}
                            //else if (ds.Tables[0].Rows[0]["q8"].ToString() == "Without swab stick")
                            //{
                            //    q8.SelectedValue = "3";
                            //}
                            //else if (ds.Tables[0].Rows[0]["q8"].ToString() == "Without media")
                            //{
                            //    q8.SelectedValue = "4";
                            //}


                            //q9.Text = ds.Tables[0].Rows[0]["q9"].ToString();
                            //q10dt.Text = ds.Tables[0].Rows[0]["q10dt"].ToString();
                            //q10t.Text = ds.Tables[0].Rows[0]["q10t"].ToString();
                            //q11.Text = ds.Tables[0].Rows[0]["q11"].ToString();



                            if (ds.Tables[0].Rows[0]["q12"].ToString() == "Yes")
                            {
                                q12.SelectedValue = "1";
                            }
                            else if (ds.Tables[0].Rows[0]["q12"].ToString() == "No")
                            {
                                q12.SelectedValue = "2";
                            }
                            else
                            {
                                q12.SelectedValue = "0";
                            }




                            if (q12.SelectedValue == "1")
                            {
                                Q12_Enable();
                            }
                            else
                            {
                                Q12_Disable();
                            }





                            q13.Text = ds.Tables[0].Rows[0]["q13"].ToString();





                            if (ds.Tables[0].Rows[0]["q14"].ToString() == "POS")
                            {
                                q14.SelectedValue = "1";
                            }
                            else if (ds.Tables[0].Rows[0]["q14"].ToString() == "NEG")
                            {
                                q14.SelectedValue = "2";
                            }
                            else if (ds.Tables[0].Rows[0]["q14"].ToString() == "NOT APPLICABLE")
                            {
                                q14.SelectedValue = "9";
                            }
                            else
                            {
                                q14.SelectedValue = "0";
                            }



                            q15a1.Text = ds.Tables[0].Rows[0]["q15a1"].ToString();
                            q15b1.Text = ds.Tables[0].Rows[0]["q15b1"].ToString();




                            if (ds.Tables[0].Rows[0]["q15c1"].ToString() == "1")
                            {
                                q15c1_1.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q15c1"].ToString() == "2")
                            {
                                q15c1_2.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q15c1"].ToString() == "3")
                            {
                                q15c1_3.Checked = true;
                            }




                            q15a2.Text = ds.Tables[0].Rows[0]["q15a2"].ToString();
                            q15b2.Text = ds.Tables[0].Rows[0]["q15b2"].ToString();




                            if (ds.Tables[0].Rows[0]["q15c2"].ToString() == "1")
                            {
                                q15c2_111.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q15c2"].ToString() == "2")
                            {
                                q15c2_112.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q15c2"].ToString() == "3")
                            {
                                q15c2_113.Checked = true;
                            }



                            q15a3.Text = ds.Tables[0].Rows[0]["q15a3"].ToString();
                            q15b3.Text = ds.Tables[0].Rows[0]["q15b3"].ToString();




                            if (ds.Tables[0].Rows[0]["q15c3"].ToString() == "1")
                            {
                                q15c3_120.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q15c3"].ToString() == "2")
                            {
                                q15c3_121.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q15c3"].ToString() == "3")
                            {
                                q15c3_122.Checked = true;
                            }




                            q15a4.Text = ds.Tables[0].Rows[0]["q15a4"].ToString();
                            q15b4.Text = ds.Tables[0].Rows[0]["q15b4"].ToString();




                            if (ds.Tables[0].Rows[0]["q15c4"].ToString() == "1")
                            {
                                q15c4_130.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q15c4"].ToString() == "2")
                            {
                                q15c4_131.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q15c4"].ToString() == "3")
                            {
                                q15c4_132.Checked = true;
                            }




                            q15a5.Text = ds.Tables[0].Rows[0]["q15a5"].ToString();
                            q15b5.Text = ds.Tables[0].Rows[0]["q15b5"].ToString();




                            if (ds.Tables[0].Rows[0]["q15c5"].ToString() == "1")
                            {
                                q15c5_140.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q15c5"].ToString() == "2")
                            {
                                q15c5_141.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q15c5"].ToString() == "3")
                            {
                                q15c5_142.Checked = true;
                            }




                            q15a6.Text = ds.Tables[0].Rows[0]["q15a6"].ToString();
                            q15b6.Text = ds.Tables[0].Rows[0]["q15b6"].ToString();



                            if (ds.Tables[0].Rows[0]["q15c6"].ToString() == "1")
                            {
                                q15c6_150.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q15c6"].ToString() == "2")
                            {
                                q15c6_151.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q15c6"].ToString() == "3")
                            {
                                q15c6_152.Checked = true;
                            }





                            q15a7.Text = ds.Tables[0].Rows[0]["q15a7"].ToString();
                            q15b7.Text = ds.Tables[0].Rows[0]["q15b7"].ToString();




                            if (ds.Tables[0].Rows[0]["q15c7"].ToString() == "1")
                            {
                                q15c7_160.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q15c7"].ToString() == "2")
                            {
                                q15c7_161.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q15c7"].ToString() == "3")
                            {
                                q15c7_162.Checked = true;
                            }





                            if (ds.Tables[0].Rows[0]["q16signa1"].ToString() == "1")
                            {
                                q16signa1.SelectedValue = "1";
                            }
                            else if (ds.Tables[0].Rows[0]["q16signa1"].ToString() == "2")
                            {
                                q16signa1.SelectedValue = "2";
                            }
                            else if (ds.Tables[0].Rows[0]["q16signa1"].ToString() == "3")
                            {
                                q16signa1.SelectedValue = "3";
                            }
                            else if (ds.Tables[0].Rows[0]["q16signa1"].ToString() == "4")
                            {
                                q16signa1.SelectedValue = "4";
                            }
                            else if (ds.Tables[0].Rows[0]["q16signa1"].ToString() == "5")
                            {
                                q16signa1.SelectedValue = "5";
                            }




                            q16a1.Text = ds.Tables[0].Rows[0]["q16a1"].ToString();
                            q16b1.Text = ds.Tables[0].Rows[0]["q16b1"].ToString();



                            if (q16a1.Text != "99")
                            {
                                if (ds.Tables[0].Rows[0]["q16c1"].ToString() == "1")
                                {
                                    q16c1_170.Checked = true;
                                }
                                else if (ds.Tables[0].Rows[0]["q16c1"].ToString() == "2")
                                {
                                    q16c1_171.Checked = true;
                                }
                                else if (ds.Tables[0].Rows[0]["q16c1"].ToString() == "3")
                                {
                                    q16c1_172.Checked = true;
                                }
                            }




                            if (ds.Tables[0].Rows[0]["q16signa2"].ToString() == "1")
                            {
                                q16signa2.SelectedValue = "1";
                            }
                            else if (ds.Tables[0].Rows[0]["q16signa2"].ToString() == "2")
                            {
                                q16signa2.SelectedValue = "2";
                            }
                            else if (ds.Tables[0].Rows[0]["q16signa2"].ToString() == "3")
                            {
                                q16signa2.SelectedValue = "3";
                            }
                            else if (ds.Tables[0].Rows[0]["q16signa2"].ToString() == "4")
                            {
                                q16signa2.SelectedValue = "4";
                            }
                            else if (ds.Tables[0].Rows[0]["q16signa2"].ToString() == "5")
                            {
                                q16signa2.SelectedValue = "5";
                            }




                            q16a2.Text = ds.Tables[0].Rows[0]["q16a2"].ToString();
                            q16b2.Text = ds.Tables[0].Rows[0]["q16b2"].ToString();



                            if (q16a2.Text != "99")
                            {
                                if (ds.Tables[0].Rows[0]["q16c2"].ToString() == "1")
                                {
                                    q16c2_180.Checked = true;
                                }
                                else if (ds.Tables[0].Rows[0]["q16c2"].ToString() == "2")
                                {
                                    q16c2_181.Checked = true;
                                }
                                else if (ds.Tables[0].Rows[0]["q16c2"].ToString() == "3")
                                {
                                    q16c2_182.Checked = true;
                                }
                            }




                            if (ds.Tables[0].Rows[0]["q16signa3"].ToString() == "1")
                            {
                                q16signa3.SelectedValue = "1";
                            }
                            else if (ds.Tables[0].Rows[0]["q16signa3"].ToString() == "2")
                            {
                                q16signa3.SelectedValue = "2";
                            }
                            else if (ds.Tables[0].Rows[0]["q16signa3"].ToString() == "3")
                            {
                                q16signa3.SelectedValue = "3";
                            }
                            else if (ds.Tables[0].Rows[0]["q16signa3"].ToString() == "4")
                            {
                                q16signa3.SelectedValue = "4";
                            }
                            else if (ds.Tables[0].Rows[0]["q16signa3"].ToString() == "5")
                            {
                                q16signa3.SelectedValue = "5";
                            }




                            q16a3.Text = ds.Tables[0].Rows[0]["q16a3"].ToString();
                            q16b3.Text = ds.Tables[0].Rows[0]["q16b3"].ToString();


                            if (q16a3.Text != "99")
                            {
                                if (ds.Tables[0].Rows[0]["q16c3"].ToString() == "1")
                                {
                                    q16c3_190.Checked = true;
                                }
                                else if (ds.Tables[0].Rows[0]["q16c3"].ToString() == "2")
                                {
                                    q16c3_191.Checked = true;
                                }
                                else if (ds.Tables[0].Rows[0]["q16c3"].ToString() == "3")
                                {
                                    q16c3_192.Checked = true;
                                }
                            }




                            if (ds.Tables[0].Rows[0]["q16c"].ToString() == "Yes")
                            {
                                q16c.SelectedValue = "1";
                            }
                            else if (ds.Tables[0].Rows[0]["q16c"].ToString() == "No")
                            {
                                q16c.SelectedValue = "2";
                            }
                            else
                            {
                                q16c.SelectedValue = "0";
                            }




                            if (q16c.SelectedValue == "1")
                            {
                                Q16c_Enable();
                            }
                            else
                            {
                                Q16c_Disable();
                            }





                            q17a1.Text = ds.Tables[0].Rows[0]["q17a1"].ToString();
                            q17b1.Text = ds.Tables[0].Rows[0]["q17b1"].ToString();


                            if (ds.Tables[0].Rows[0]["q17c1"].ToString() == "1")
                            {
                                q17c1_200.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q17c1"].ToString() == "2")
                            {
                                q17c1_201.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q17c1"].ToString() == "3")
                            {
                                q17c1_202.Checked = true;
                            }




                            q17a2.Text = ds.Tables[0].Rows[0]["q17a2"].ToString();
                            q17b2.Text = ds.Tables[0].Rows[0]["q17b2"].ToString();



                            if (ds.Tables[0].Rows[0]["q17c2"].ToString() == "1")
                            {
                                q17c2_300.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q17c2"].ToString() == "2")
                            {
                                q17c2_301.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q17c2"].ToString() == "3")
                            {
                                q17c2_302.Checked = true;
                            }






                            q17a99.Text = ds.Tables[0].Rows[0]["q17a99"].ToString();
                            q17b99.Text = ds.Tables[0].Rows[0]["q17b99"].ToString();



                            if (ds.Tables[0].Rows[0]["q17c3"].ToString() == "1")
                            {
                                q17c3_303.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q17c3"].ToString() == "2")
                            {
                                q17c3_304.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q17c3"].ToString() == "3")
                            {
                                q17c3_305.Checked = true;
                            }







                            q17a3.Text = ds.Tables[0].Rows[0]["q17a3"].ToString();
                            q17b3.Text = ds.Tables[0].Rows[0]["q17b3"].ToString();




                            if (ds.Tables[0].Rows[0]["q17c4"].ToString() == "1")
                            {
                                q17c4_306.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q17c4"].ToString() == "2")
                            {
                                q17c4_307.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q17c4"].ToString() == "3")
                            {
                                q17c4_308.Checked = true;
                            }





                            q17a4.Text = ds.Tables[0].Rows[0]["q17a4"].ToString();
                            q17b4.Text = ds.Tables[0].Rows[0]["q17b4"].ToString();



                            if (ds.Tables[0].Rows[0]["q17c5"].ToString() == "1")
                            {
                                q17c5_309.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q17c5"].ToString() == "2")
                            {
                                q17c5_400.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q17c5"].ToString() == "3")
                            {
                                q17c5_401.Checked = true;
                            }




                            q17a5.Text = ds.Tables[0].Rows[0]["q17a5"].ToString();
                            q17b5.Text = ds.Tables[0].Rows[0]["q17b5"].ToString();



                            if (ds.Tables[0].Rows[0]["q17c6"].ToString() == "1")
                            {
                                q17c6_402.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q17c6"].ToString() == "2")
                            {
                                q17c6_403.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q17c6"].ToString() == "3")
                            {
                                q17c6_404.Checked = true;
                            }




                            q17a6.Text = ds.Tables[0].Rows[0]["q17a6"].ToString();
                            q17b6.Text = ds.Tables[0].Rows[0]["q17b6"].ToString();




                            if (ds.Tables[0].Rows[0]["q17c7"].ToString() == "1")
                            {
                                q17c7_405.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q17c7"].ToString() == "2")
                            {
                                q17c7_406.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q17c7"].ToString() == "3")
                            {
                                q17c7_407.Checked = true;
                            }






                            q17a7.Text = ds.Tables[0].Rows[0]["q17a7"].ToString();
                            q17b7.Text = ds.Tables[0].Rows[0]["q17b7"].ToString();



                            if (ds.Tables[0].Rows[0]["q17c8"].ToString() == "1")
                            {
                                q17c8_408.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q17c8"].ToString() == "2")
                            {
                                q17c8_409.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q17c8"].ToString() == "3")
                            {
                                q17c8_410.Checked = true;
                            }






                            q17a8.Text = ds.Tables[0].Rows[0]["q17a8"].ToString();
                            q17b8.Text = ds.Tables[0].Rows[0]["q17b8"].ToString();



                            if (ds.Tables[0].Rows[0]["q17c9"].ToString() == "1")
                            {
                                q17c9_411.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q17c9"].ToString() == "2")
                            {
                                q17c9_412.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q17c9"].ToString() == "3")
                            {
                                q17c9_413.Checked = true;
                            }







                            q17a9.Text = ds.Tables[0].Rows[0]["q17a9"].ToString();
                            q17b9.Text = ds.Tables[0].Rows[0]["q17b9"].ToString();




                            if (ds.Tables[0].Rows[0]["q17c10"].ToString() == "1")
                            {
                                q17c10_414.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q17c10"].ToString() == "2")
                            {
                                q17c10_415.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q17c10"].ToString() == "3")
                            {
                                q17c10_416.Checked = true;
                            }





                            q17a10.Text = ds.Tables[0].Rows[0]["q17a10"].ToString();
                            q17b10.Text = ds.Tables[0].Rows[0]["q17b10"].ToString();


                            if (ds.Tables[0].Rows[0]["q17c11"].ToString() == "1")
                            {
                                q17c11_417.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q17c11"].ToString() == "2")
                            {
                                q17c11_418.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q17c11"].ToString() == "3")
                            {
                                q17c11_419.Checked = true;
                            }




                            if (ds.Tables[0].Rows[0]["q18signa1"].ToString() == "1")
                            {
                                q18signa1.SelectedValue = "1";
                            }
                            else if (ds.Tables[0].Rows[0]["q18signa1"].ToString() == "2")
                            {
                                q18signa1.SelectedValue = "2";
                            }
                            else if (ds.Tables[0].Rows[0]["q18signa1"].ToString() == "3")
                            {
                                q18signa1.SelectedValue = "3";
                            }
                            else if (ds.Tables[0].Rows[0]["q18signa1"].ToString() == "4")
                            {
                                q18signa1.SelectedValue = "4";
                            }
                            else if (ds.Tables[0].Rows[0]["q18signa1"].ToString() == "5")
                            {
                                q18signa1.SelectedValue = "5";
                            }




                            q18a1.Text = ds.Tables[0].Rows[0]["q18a1"].ToString();
                            q18b1.Text = ds.Tables[0].Rows[0]["q18b1"].ToString();


                            if (q18a1.Text != "9999")
                            {
                                if (ds.Tables[0].Rows[0]["q18c1"].ToString() == "1")
                                {
                                    q18c1_420.Checked = true;
                                }
                                else if (ds.Tables[0].Rows[0]["q18c1"].ToString() == "2")
                                {
                                    q18c1_421.Checked = true;
                                }
                                else if (ds.Tables[0].Rows[0]["q18c1"].ToString() == "3")
                                {
                                    q18c1_422.Checked = true;
                                }
                            }



                            if (ds.Tables[0].Rows[0]["q19"].ToString() == "Yes")
                            {
                                q19.SelectedValue = "1";
                            }
                            else if (ds.Tables[0].Rows[0]["q19"].ToString() == "No")
                            {
                                q19.SelectedValue = "2";
                            }
                            else if (ds.Tables[0].Rows[0]["q19"].ToString() == "NA")
                            {
                                q19.SelectedValue = "9";
                            }
                            else
                            {
                                q19.SelectedValue = "0";
                            }







                            if (ds.Tables[0].Rows[0]["q20"].ToString() == q20_1.Text)
                            {
                                q20_1.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q20"].ToString() == q20_2.Text)
                            {
                                q20_2.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q20"].ToString() == q20_3.Text)
                            {
                                q20_3.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q20"].ToString() == q20_4.Text)
                            {
                                q20_4.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q20"].ToString() == q20_5.Text)
                            {
                                q20_5.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q20"].ToString() == q20_6.Text)
                            {
                                q20_6.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q20"].ToString() == q20_7.Text)
                            {
                                q20_7.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q20"].ToString() == q20_8.Text)
                            {
                                q20_8.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q20"].ToString() == q20_9.Text)
                            {
                                q20_9.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q20"].ToString() == q20_10.Text)
                            {
                                q20_10.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q20"].ToString() == q20_11.Text)
                            {
                                q20_11.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q20"].ToString() == q20_12.Text)
                            {
                                q20_12.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q20"].ToString() == q20_13.Text)
                            {
                                q20_13.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q20"].ToString() == q20_14.Text)
                            {
                                q20_14.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q20"].ToString() == q20_15.Text)
                            {
                                q20_15.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q20"].ToString() == q20_16.Text)
                            {
                                q20_16.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q20"].ToString() == q20_17.Text)
                            {
                                q20_17.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q20"].ToString() == q20_18.Text)
                            {
                                q20_18.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q20"].ToString() == q20_19.Text)
                            {
                                q20_19.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q20"].ToString() == q20_20.Text)
                            {
                                q20_20.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q20"].ToString() == q20_21.Text)
                            {
                                q20_21.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q20"].ToString() == q20_22.Text)
                            {
                                q20_22.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q20"].ToString() == q20_23.Text)
                            {
                                q20_23.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q20"].ToString() == q20_24.Text)
                            {
                                q20_24.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q20"].ToString() == q20_25.Text)
                            {
                                q20_25.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q20"].ToString() == q20_26.Text)
                            {
                                q20_26.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q20"].ToString() == q20_27.Text)
                            {
                                q20_27.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q20"].ToString() == q20_28.Text)
                            {
                                q20_28.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q20"].ToString() == q20_29.Text)
                            {
                                q20_29.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q20"].ToString() == q20_30.Text)
                            {
                                q20_30.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q20"].ToString() == q20_31.Text)
                            {
                                q20_31.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q20"].ToString() == q20_32.Text)
                            {
                                q20_32.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q20"].ToString() == q20_33.Text)
                            {
                                q20_33.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q20"].ToString() == q20_34.Text)
                            {
                                q20_34.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q20"].ToString() == q20_35.Text)
                            {
                                q20_35.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q20"].ToString() == q20_36.Text)
                            {
                                q20_36.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q20"].ToString() == q20_37.Text)
                            {
                                q20_37.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q20"].ToString() == q20_38.Text)
                            {
                                q20_38.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q20"].ToString() == q20_39.Text)
                            {
                                q20_39.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q20"].ToString() == q20_40.Text)
                            {
                                q20_40.Checked = true;
                            }







                            //if (ds.Tables[0].Rows[0]["q20"].ToString() == "Yes")
                            //{
                            //    q20.SelectedValue = "1";
                            //}
                            //else if (ds.Tables[0].Rows[0]["q20"].ToString() == "No")
                            //{
                            //    q20.SelectedValue = "2";
                            //}
                            //else if (ds.Tables[0].Rows[0]["q20"].ToString() == "NA")
                            //{
                            //    q20.SelectedValue = "9";
                            //}
                            //else
                            //{
                            //    q20.SelectedValue = "0";
                            //}




                            if (ds.Tables[0].Rows[0]["q21"].ToString() == "6A")
                            {
                                q21.SelectedValue = "1";
                            }
                            else if (ds.Tables[0].Rows[0]["q21"].ToString() == "6B")
                            {
                                q21.SelectedValue = "2";
                            }
                            else if (ds.Tables[0].Rows[0]["q21"].ToString() == "6C")
                            {
                                q21.SelectedValue = "3";
                            }
                            else if (ds.Tables[0].Rows[0]["q21"].ToString() == "6D")
                            {
                                q21.SelectedValue = "4";
                            }
                            else if (ds.Tables[0].Rows[0]["q21"].ToString() == "NA")
                            {
                                q21.SelectedValue = "9";
                            }
                            else
                            {
                                q21.SelectedValue = "0";
                            }




                            if (ds.Tables[0].Rows[0]["q22"].ToString() == "Confirmed")
                            {
                                q22.SelectedValue = "1";
                            }
                            else if (ds.Tables[0].Rows[0]["q22"].ToString() == "Not Confirmed")
                            {
                                q22.SelectedValue = "2";
                            }
                            else if (ds.Tables[0].Rows[0]["q22"].ToString() == "NA")
                            {
                                q22.SelectedValue = "9";
                            }
                            else
                            {
                                q22.SelectedValue = "0";
                            }




                            if (ds.Tables[0].Rows[0]["q23"].ToString() == q23_1.Text)
                            {
                                q23_1.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q23"].ToString() == q23_2.Text)
                            {
                                q23_2.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q23"].ToString() == q23_3.Text)
                            {
                                q23_3.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q23"].ToString() == q23_4.Text)
                            {
                                q23_4.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q23"].ToString() == q23_5.Text)
                            {
                                q23_5.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q23"].ToString() == q23_6.Text)
                            {
                                q23_6.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q23"].ToString() == q23_7.Text)
                            {
                                q23_7.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q23"].ToString() == q23_8.Text)
                            {
                                q23_8.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q23"].ToString() == q23_9.Text)
                            {
                                q23_9.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q23"].ToString() == q23_10.Text)
                            {
                                q23_10.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q23"].ToString() == q23_10a.Text)
                            {
                                q23_10a.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q23"].ToString() == q23_11.Text)
                            {
                                q23_11.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q23"].ToString() == q23_12.Text)
                            {
                                q23_12.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q23"].ToString() == q23_13.Text)
                            {
                                q23_13.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q23"].ToString() == q23_14.Text)
                            {
                                q23_14.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q23"].ToString() == q23_15.Text)
                            {
                                q23_15.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q23"].ToString() == q23_16.Text)
                            {
                                q23_16.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q23"].ToString() == q23_17.Text)
                            {
                                q23_17.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q23"].ToString() == q23_18.Text)
                            {
                                q23_18.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q23"].ToString() == q23_19.Text)
                            {
                                q23_19.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q23"].ToString() == q23_20.Text)
                            {
                                q23_20.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q23"].ToString() == q23_20a.Text)
                            {
                                q23_20a.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q23"].ToString() == q23_21.Text)
                            {
                                q23_21.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q23"].ToString() == q23_22.Text)
                            {
                                q23_22.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q23"].ToString() == q23_23.Text)
                            {
                                q23_23.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q23"].ToString() == q23_24.Text)
                            {
                                q23_24.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q23"].ToString() == q23_25.Text)
                            {
                                q23_25.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q23"].ToString() == q23_26.Text)
                            {
                                q23_26.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q23"].ToString() == q23_27.Text)
                            {
                                q23_27.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q23"].ToString() == q23_28.Text)
                            {
                                q23_28.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q23"].ToString() == q23_29.Text)
                            {
                                q23_29.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q23"].ToString() == q23_30.Text)
                            {
                                q23_30.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q23"].ToString() == q23_30a.Text)
                            {
                                q23_30a.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q23"].ToString() == q23_31.Text)
                            {
                                q23_31.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q23"].ToString() == q23_32.Text)
                            {
                                q23_32.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q23"].ToString() == q23_33.Text)
                            {
                                q23_33.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q23"].ToString() == q23_34.Text)
                            {
                                q23_34.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q23"].ToString() == q23_35.Text)
                            {
                                q23_35.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q23"].ToString() == q23_36.Text)
                            {
                                q23_36.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q23"].ToString() == q23_37.Text)
                            {
                                q23_37.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q23"].ToString() == q23_38.Text)
                            {
                                q23_38.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q23"].ToString() == q23_39.Text)
                            {
                                q23_39.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q23"].ToString() == q23_40.Text)
                            {
                                q23_40.Checked = true;
                            }
                            else if (ds.Tables[0].Rows[0]["q23"].ToString() == q23_40a.Text)
                            {
                                q23_40a.Checked = true;
                            }




                            //if (ds.Tables[0].Rows[0]["q23"].ToString() == "Yes")
                            //{
                            //    q23.SelectedValue = "1";
                            //}
                            //else if (ds.Tables[0].Rows[0]["q23"].ToString() == "No")
                            //{
                            //    q23.SelectedValue = "2";
                            //}
                            //else if (ds.Tables[0].Rows[0]["q23"].ToString() == "NA")
                            //{
                            //    q23.SelectedValue = "9";
                            //}
                            //else
                            //{
                            //    q23.SelectedValue = "0";
                            //}





                            //if (ds.Tables[0].Rows[0]["q24"].ToString() == "Yes")
                            //{
                            //    q24.SelectedValue = "1";
                            //}
                            //else if (ds.Tables[0].Rows[0]["q24"].ToString() == "No")
                            //{
                            //    q24.SelectedValue = "2";
                            //}
                            //else if (ds.Tables[0].Rows[0]["q24"].ToString() == "NA")
                            //{
                            //    q24.SelectedValue = "9";
                            //}
                            //else
                            //{
                            //    q24.SelectedValue = "0";
                            //}




                            //if (ds.Tables[0].Rows[0]["q25"].ToString() == "Yes")
                            //{
                            //    q25.SelectedValue = "1";
                            //}
                            //else if (ds.Tables[0].Rows[0]["q25"].ToString() == "No")
                            //{
                            //    q25.SelectedValue = "2";
                            //}
                            //else if (ds.Tables[0].Rows[0]["q25"].ToString() == "NA")
                            //{
                            //    q25.SelectedValue = "9";
                            //}
                            //else
                            //{
                            //    q25.SelectedValue = "0";
                            //}




                            //q26.Text = ds.Tables[0].Rows[0]["q26"].ToString();
                            //q27.Text = ds.Tables[0].Rows[0]["q27"].ToString();



                            //if (q7.SelectedValue == "1")
                            //{
                            //    Enable_q7();
                            //}
                            //else
                            //{
                            //    Disable_q7();
                            //}



                            if (q19.SelectedValue == "1")
                            {
                                q19_Enabled();
                            }
                            else
                            {
                                q19_Disabled();
                            }


                            Comments.Text = ds.Tables[0].Rows[0]["comments"].ToString();


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



        private void ClearFields()
        {
            studyid.Text = "";


            //q1.SelectedValue = "0";
            //q2.Text = "";
            //q3.Text = "";
            //q3a.Text = "";

            q4.Text = "";
            q4a.Text = "";

            //q5.SelectedValue = "0";
            //q6dt.Text = "";
            //q6t.Text = "";
            //q7.SelectedValue = "0";
            //q8.SelectedValue = "0";
            //q9.Text = "";
            //q10dt.Text = "";
            //q10t.Text = "";
            //q11.Text = "";


            q12.SelectedValue = "0";
            q13.Text = "";
            q14.SelectedValue = "0";


            q15a1.Text = "";
            q15b1.Text = "";
            q15c1_1.Checked = false;
            q15c1_2.Checked = false;
            q15c1_3.Checked = false;


            q15a2.Text = "";
            q15b2.Text = "";
            q15c2_111.Checked = false;
            q15c2_112.Checked = false;
            q15c2_113.Checked = false;


            q15a3.Text = "";
            q15b3.Text = "";
            q15c3_120.Checked = false;
            q15c3_121.Checked = false;
            q15c3_122.Checked = false;


            q15a4.Text = "";
            q15b4.Text = "";
            q15c4_130.Checked = false;
            q15c4_131.Checked = false;
            q15c4_132.Checked = false;


            q15a5.Text = "";
            q15b5.Text = "";
            q15c5_140.Checked = false;
            q15c5_141.Checked = false;
            q15c5_142.Checked = false;


            q15a6.Text = "";
            q15b6.Text = "";
            q15c6_150.Checked = false;
            q15c6_151.Checked = false;
            q15c6_152.Checked = false;


            q15a7.Text = "";
            q15b7.Text = "";
            q15c7_160.Checked = false;
            q15c7_161.Checked = false;
            q15c7_162.Checked = false;


            q16signa1.SelectedValue = "0";
            q16a1.Text = "";
            q16b1.Text = "";
            q16c1_170.Checked = false;
            q16c1_171.Checked = false;
            q16c1_172.Checked = false;


            q16signa2.SelectedValue = "0";
            q16a2.Text = "";
            q16b2.Text = "";
            q16c2_180.Checked = false;
            q16c2_181.Checked = false;
            q16c2_182.Checked = false;


            q16signa3.SelectedValue = "0";
            q16a3.Text = "";
            q16b3.Text = "";
            q16c3_190.Checked = false;
            q16c3_191.Checked = false;
            q16c3_192.Checked = false;


            q16c.SelectedValue = "0";

            q17a1.Text = "";
            q17b1.Text = "";
            q17c1_200.Checked = false;
            q17c1_201.Checked = false;
            q17c1_202.Checked = false;


            q17a2.Text = "";
            q17b2.Text = "";
            q17c2_300.Checked = false;
            q17c2_301.Checked = false;
            q17c2_302.Checked = false;


            q17a99.Text = "";
            q17b99.Text = "";
            q17c3_303.Checked = false;
            q17c3_304.Checked = false;
            q17c3_305.Checked = false;


            q17a3.Text = "";
            q17b3.Text = "";
            q17c4_306.Checked = false;
            q17c4_307.Checked = false;
            q17c4_308.Checked = false;


            q17a4.Text = "";
            q17b4.Text = "";
            q17c5_309.Checked = false;
            q17c5_400.Checked = false;
            q17c5_401.Checked = false;



            q17a5.Text = "";
            q17b5.Text = "";
            q17c6_402.Checked = false;
            q17c6_403.Checked = false;
            q17c6_404.Checked = false;


            q17a6.Text = "";
            q17b6.Text = "";
            q17c7_405.Checked = false;
            q17c7_406.Checked = false;
            q17c7_407.Checked = false;


            q17a7.Text = "";
            q17b7.Text = "";
            q17c8_408.Checked = false;
            q17c8_409.Checked = false;
            q17c8_410.Checked = false;


            q17a8.Text = "";
            q17b8.Text = "";
            q17c9_411.Checked = false;
            q17c9_412.Checked = false;
            q17c9_413.Checked = false;


            q17a9.Text = "";
            q17b9.Text = "";
            q17c10_414.Checked = false;
            q17c10_415.Checked = false;
            q17c10_416.Checked = false;


            q17a10.Text = "";
            q17b10.Text = "";
            q17c11_417.Checked = false;
            q17c11_418.Checked = false;
            q17c11_419.Checked = false;


            q18signa1.SelectedValue = "0";
            q18a1.Text = "";
            q18b1.Text = "";
            q18c1_420.Checked = false;
            q18c1_421.Checked = false;
            q18c1_422.Checked = false;


            q19.SelectedValue = "0";


            q20_1.Checked = false;
            q20_2.Checked = false;
            q20_3.Checked = false;
            q20_4.Checked = false;
            q20_5.Checked = false;
            q20_6.Checked = false;
            q20_7.Checked = false;
            q20_8.Checked = false;
            q20_9.Checked = false;
            q20_10.Checked = false;
            q20_11.Checked = false;
            q20_12.Checked = false;
            q20_13.Checked = false;
            q20_14.Checked = false;
            q20_15.Checked = false;
            q20_16.Checked = false;
            q20_17.Checked = false;
            q20_18.Checked = false;
            q20_19.Checked = false;
            q20_20.Checked = false;
            q20_21.Checked = false;
            q20_22.Checked = false;
            q20_23.Checked = false;
            q20_24.Checked = false;
            q20_25.Checked = false;
            q20_26.Checked = false;
            q20_27.Checked = false;
            q20_28.Checked = false;
            q20_29.Checked = false;
            q20_30.Checked = false;
            q20_31.Checked = false;
            q20_32.Checked = false;
            q20_33.Checked = false;
            q20_34.Checked = false;
            q20_35.Checked = false;
            q20_36.Checked = false;
            q20_37.Checked = false;
            q20_38.Checked = false;
            q20_39.Checked = false;
            q20_40.Checked = false;



            q21.SelectedValue = "0";
            q22.SelectedValue = "0";


            q23_1.Checked = false;
            q23_2.Checked = false;
            q23_3.Checked = false;
            q23_4.Checked = false;
            q23_5.Checked = false;
            q23_6.Checked = false;
            q23_7.Checked = false;
            q23_8.Checked = false;
            q23_9.Checked = false;
            q23_10.Checked = false;
            q23_10a.Checked = false;
            q23_11.Checked = false;
            q23_12.Checked = false;
            q23_13.Checked = false;
            q23_14.Checked = false;
            q23_15.Checked = false;
            q23_16.Checked = false;
            q23_17.Checked = false;
            q23_18.Checked = false;
            q23_19.Checked = false;
            q23_20.Checked = false;
            q23_20a.Checked = false;
            q23_21.Checked = false;
            q23_22.Checked = false;
            q23_23.Checked = false;
            q23_24.Checked = false;
            q23_25.Checked = false;
            q23_26.Checked = false;
            q23_27.Checked = false;
            q23_28.Checked = false;
            q23_29.Checked = false;
            q23_30.Checked = false;
            q23_30a.Checked = false;
            q23_31.Checked = false;
            q23_32.Checked = false;
            q23_33.Checked = false;
            q23_34.Checked = false;
            q23_35.Checked = false;
            q23_36.Checked = false;
            q23_37.Checked = false;
            q23_38.Checked = false;
            q23_39.Checked = false;
            q23_40.Checked = false;
            q23_40a.Checked = false;


            //q20.SelectedValue = "0";
            //q21.SelectedValue = "0";
            //q22.SelectedValue = "0";
            //q23.SelectedValue = "0";
            //q24.SelectedValue = "0";
            //q25.SelectedValue = "0";
            //q26.Text = "";
            //q27.Text = "";

            Session.Remove("id");

            studyid.Focus();
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

        protected void cmdSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(studyid.Text) == true)
            {
                lblerr.Text = "Please enter study id ";
                lblerr.CssClass = "message-error";
                studyid.Focus();
            }
            //else if (q1.SelectedValue == "0" && q1.Enabled == true)
            //{
            //    lblerr.Text = "Please select field site  ";
            //    lblerr.CssClass = "message-error";
            //    q1.Focus();
            //}
            //else if (q2.Text == "" && q2.Enabled == true)
            //{
            //    lblerr.Text = "Please enter physician name ";
            //    lblerr.CssClass = "message-error";
            //    q2.Focus();
            //}
            //else if (q3.Text == "" && q3.Enabled == true)
            //{
            //    lblerr.Text = "Please enter mother name ";
            //    lblerr.CssClass = "message-error";
            //    q3.Focus();
            //}
            //else if (q3a.Text == "" && q3a.Enabled == true)
            //{
            //    lblerr.Text = "Please enter child name ";
            //    lblerr.CssClass = "message-error";
            //    q3a.Focus();
            //}
            else if (q4.Text == "" && q4.Enabled == true)
            {
                lblerr.Text = "please enter child id ";
                lblerr.CssClass = "message-error";
                q4.Focus();
            }
            else if (q4a.Text == "" && q4a.Enabled == true)
            {
                lblerr.Text = "please enter BT Number ";
                lblerr.CssClass = "message-error";
                q4a.Focus();
            }
            //else if (q5.SelectedValue == "0" && q5.Enabled == true)
            //{
            //    lblerr.Text = "Please select swab collected ";
            //    lblerr.CssClass = "message-error";
            //    q5.Focus();
            //}
            //else if (q6dt.Text == "" && q6dt.Enabled == true)
            //{
            //    lblerr.Text = "Please enter collection date ";
            //    lblerr.CssClass = "message-error";
            //    q6dt.Focus();
            //}
            //else if (q6t.Text == "0" && q6t.Enabled == true)
            //{
            //    lblerr.Text = "Please select specimen collection time ";
            //    lblerr.CssClass = "message-error";
            //    q6t.Focus();
            //}
            //else if (q7.SelectedValue == "0" && q7.Enabled == true)
            //{
            //    lblerr.Text = "Please select condition of the STGG tube ";
            //    lblerr.CssClass = "message-error";
            //    q7.Focus();
            //}
            //else if (q8.Text == "" && q8.Enabled == true)
            //{
            //    lblerr.Text = "Please enter temperature ";
            //    lblerr.CssClass = "message-error";
            //    q8.Focus();
            //}
            //else if (q9.Text == "" && q9.Enabled == true)
            //{
            //    lblerr.Text = "Please enter temperature of the tube ";
            //    lblerr.CssClass = "message-error";
            //    q9.Focus();
            //}
            //else if (q10dt.Text == "" && q10dt.Enabled == true)
            //{
            //    lblerr.Text = "Please enter receiving date ";
            //    lblerr.CssClass = "message-error";
            //    q10dt.Focus();
            //}
            //else if (q10t.Text == "" && q10t.Enabled == true)
            //{
            //    lblerr.Text = "Please enter receiving time ";
            //    lblerr.CssClass = "message-error";
            //    q10t.Focus();
            //}
            //else if (q11.Text == "" && q11.Enabled == true)
            //{
            //    lblerr.Text = "Please enter laboratory person name ";
            //    lblerr.CssClass = "message-error";
            //    q11.Focus();
            //}
            else if (q12.SelectedValue == "0" && q12.Enabled == true)
            {
                lblerr.Text = "Please enter S.pneumoniae Detected in Respiratory Specimen ";
                lblerr.CssClass = "message-error";
                q12.Focus();
            }
            else if (q13.Text == "" && q13.Enabled == true)
            {
                lblerr.Text = "Please enter Optochin zone size ";
                lblerr.CssClass = "message-error";
                q13.Focus();
            }
            else if (q14.SelectedValue == "0" && q14.Enabled == true)
            {
                lblerr.Text = "Please enter Bile Solubility ";
                lblerr.CssClass = "message-error";
                q14.Focus();
            }
            else if (q15a1.Text == "" && q15a1.Enabled == true)
            {
                lblerr.Text = "Please enter Chloramphenicol (30 µg) ";
                lblerr.CssClass = "message-error";
                q15a1.Focus();
            }
            else if (q15b1.Text == "" && q15b1.Enabled == true && q15b1.Visible == true)
            {
                lblerr.Text = "Please enter Chloramphenicol (30 µg) ";
                lblerr.CssClass = "message-error";
                q15b1.Focus();
            }
            else if (q15c1_1.Enabled == true && q15c1_1.Checked == false
                && q15c1_2.Enabled == true && q15c1_2.Checked == false
                && q15c1_3.Enabled == true && q15c1_3.Checked == false)
            {
                lblerr.Text = "Please enter Chloramphenicol (30 µg) sensitivity ";
                lblerr.CssClass = "message-error";
                q15c1_1.Focus();
            }
            else if (q15a2.Text == "" && q15a2.Enabled == true)
            {
                lblerr.Text = "Please enter Erythromycin (15 µg) ";
                lblerr.CssClass = "message-error";
                q15a2.Focus();
            }
            else if (q15b2.Text == "" && q15b2.Enabled == true && q15b2.Visible == true)
            {
                lblerr.Text = "Please enter Erythromycin (15 µg) ";
                lblerr.CssClass = "message-error";
                q15b2.Focus();
            }
            else if (q15c2_111.Enabled == true && q15c2_111.Checked == false
                && q15c2_112.Enabled == true && q15c2_112.Checked == false
                && q15c2_113.Enabled == true && q15c2_113.Checked == false)
            {
                lblerr.Text = "Please enter Erythromycin (15 µg) sensitivity ";
                lblerr.CssClass = "message-error";
                q15c2_111.Focus();
            }
            else if (q15a3.Text == "" && q15a3.Enabled == true)
            {
                lblerr.Text = "Please enter Oxacillin (1 µg) ";
                lblerr.CssClass = "message-error";
                q15a3.Focus();
            }
            else if (q15b3.Text == "" && q15b3.Enabled == true && q15b3.Visible == true)
            {
                lblerr.Text = "Please enter Oxacillin (1 µg) ";
                lblerr.CssClass = "message-error";
                q15b3.Focus();
            }
            else if (q15c3_120.Checked == false && q15c3_120.Enabled == true
                && q15c3_121.Checked == false && q15c3_121.Enabled == true
                && q15c3_122.Checked == false && q15c3_122.Enabled == true)
            {
                lblerr.Text = "Please enter Oxacillin (1 µg) sensitivity ";
                lblerr.CssClass = "message-error";
                q15c3_120.Focus();
            }
            else if (q15a4.Text == "" && q15a4.Enabled == true)
            {
                lblerr.Text = "Please enter Ofloxacin (5 µg) ";
                lblerr.CssClass = "message-error";
                q15a4.Focus();
            }
            else if (q15b4.Text == "" && q15b4.Enabled == true && q15b4.Visible == true)
            {
                lblerr.Text = "Please enter Ofloxacin (5 µg) ";
                lblerr.CssClass = "message-error";
                q15b4.Focus();
            }
            else if (q15c4_130.Checked == false && q15c4_130.Enabled == true
            && q15c4_131.Checked == false && q15c4_131.Enabled == true
            && q15c4_132.Checked == false && q15c4_132.Enabled == true)
            {
                lblerr.Text = "Please enter Ofloxacin (5 µg) sensitivity ";
                lblerr.CssClass = "message-error";
                q15c4_130.Focus();
            }
            else if (q15a5.Text == "" && q15a5.Enabled == true)
            {
                lblerr.Text = "Please enter Cotrimoxazole (25 µg) ";
                lblerr.CssClass = "message-error";
                q15a5.Focus();
            }
            else if (q15b5.Text == "" && q15b5.Enabled == true && q15b5.Visible == true)
            {
                lblerr.Text = "Please enter Cotrimoxazole (25 µg) ";
                lblerr.CssClass = "message-error";
                q15b5.Focus();
            }
            else if (q15c5_140.Checked == false && q15c5_140.Enabled == true
            && q15c5_141.Checked == false && q15c5_141.Enabled == true
            && q15c5_142.Checked == false && q15c5_142.Enabled == true)
            {
                lblerr.Text = "Please enter Cotrimoxazole (25 µg) sensitivity ";
                lblerr.CssClass = "message-error";
                q15c5_140.Focus();
            }
            else if (q15a6.Text == "" && q15a6.Enabled == true)
            {
                lblerr.Text = "Please enter Tetracycline (30 µg) ";
                lblerr.CssClass = "message-error";
                q15a6.Focus();
            }
            else if (q15c6_150.Checked == false && q15c6_150.Enabled == true
            && q15c6_151.Checked == false && q15c6_151.Enabled == true
            && q15c6_152.Checked == false && q15c6_152.Enabled == true)
            {
                lblerr.Text = "Please enter Tetracycline (30 µg) sensitivity ";
                lblerr.CssClass = "message-error";
                q15c6_150.Focus();
            }
            else if (q15a7.Text == "" && q15a7.Enabled == true)
            {
                lblerr.Text = "Please enter Vancomycin(30 µg) ";
                lblerr.CssClass = "message-error";
                q15a7.Focus();
            }
            else if (q15c7_160.Checked == false && q15c7_160.Enabled == true
            && q15c7_161.Checked == false && q15c7_161.Enabled == true
            && q15c7_162.Checked == false && q15c7_162.Enabled == true)
            {
                lblerr.Text = "Please enter Vancomycin(30 µg) sensitivity ";
                lblerr.CssClass = "message-error";
                q15c7_160.Focus();
            }
            else if (q16signa1.SelectedValue == "0" && q16signa1.Enabled == true)
            {
                lblerr.Text = "Please select sign of Penicillin (non - meningitis) ";
                lblerr.CssClass = "message-error";
                q16signa1.Focus();
            }
            else if (q16a1.Text == "" && q16a1.Enabled == true)
            {
                lblerr.Text = "Please enter Penicillin (non - meningitis) ";
                lblerr.CssClass = "message-error";
                q16a1.Focus();
            }
            else if (q16b1.Text == "" && q16b1.Enabled == true && q16b1.Visible == true)
            {
                lblerr.Text = "Please enter Penicillin (non - meningitis) ";
                lblerr.CssClass = "message-error";
                q16b1.Focus();
            }
            else if (q16c1_170.Checked == false && q16c1_170.Enabled == true
            && q16c1_171.Checked == false && q16c1_171.Enabled == true
            && q16c1_172.Checked == false && q16c1_172.Enabled == true && q16a1.Text != "99")
            {
                lblerr.Text = "Please enter Penicillin (non - meningitis) sensitivity ";
                lblerr.CssClass = "message-error";
                q16c1_170.Focus();
            }
            else if (q16signa2.SelectedValue == "0" && q16signa2.Enabled == true)
            {
                lblerr.Text = "Please select sign of Ceftriaxone (non - meningitis) ";
                lblerr.CssClass = "message-error";
                q16signa2.Focus();
            }
            else if (q16a2.Text == "" && q16a2.Enabled == true)
            {
                lblerr.Text = "Please enter Ceftriaxone (non - meningitis) ";
                lblerr.CssClass = "message-error";
                q16a2.Focus();
            }
            else if (q16b2.Text == "" && q16b2.Enabled == true && q16b2.Visible == true)
            {
                lblerr.Text = "Please enter Ceftriaxone (non - meningitis) ";
                lblerr.CssClass = "message-error";
                q16b2.Focus();
            }
            else if (q16c2_180.Checked == false && q16c2_180.Enabled == true
            && q16c2_181.Checked == false && q16c2_181.Enabled == true
            && q16c2_182.Checked == false && q16c2_182.Enabled == true && q16a2.Text != "99")
            {
                lblerr.Text = "Please enter Ceftriaxone (non - meningitis) sensitivity ";
                lblerr.CssClass = "message-error";
                q16c2_180.Focus();
            }
            else if (q16signa3.SelectedValue == "0" && q16signa3.Enabled == true)
            {
                lblerr.Text = "Please select sign of Vancomycin ";
                lblerr.CssClass = "message-error";
                q16signa3.Focus();
            }
            else if (q16a3.Text == "" && q16a3.Enabled == true)
            {
                lblerr.Text = "Please enter Vancomycin ";
                lblerr.CssClass = "message-error";
                q16a3.Focus();
            }
            else if (q16b3.Text == "" && q16b3.Enabled == true && q16b3.Visible == true)
            {
                lblerr.Text = "Please enter Vancomycin ";
                lblerr.CssClass = "message-error";
                q16b3.Focus();
            }
            else if (q16c3_190.Checked == false && q16c3_190.Enabled == true
            && q16c3_191.Checked == false && q16c3_191.Enabled == true
            && q16c3_192.Checked == false && q16c3_192.Enabled == true && q16a3.Text != "99")
            {
                lblerr.Text = "Please enter Vancomycin sensitivity ";
                lblerr.CssClass = "message-error";
                q16c3_190.Focus();
            }
            else if (q16c.SelectedValue == "0" && q16c.Enabled == true)
            {
                lblerr.Text = "Please enter Staphylococcus aureus Detected ";
                lblerr.CssClass = "message-error";
                q16c.Focus();
            }
            else if (q17a1.Text == "" && q17a1.Enabled == true)
            {
                lblerr.Text = "Please enter Amikacin (30 µg) ";
                lblerr.CssClass = "message-error";
                q17a1.Focus();
            }
            else if (q17b1.Text == "" && q17b1.Enabled == true && q17b1.Visible == true)
            {
                lblerr.Text = "Please enter Amikacin (30 µg) ";
                lblerr.CssClass = "message-error";
                q17b1.Focus();
            }
            else if (q17c1_200.Checked == false && q17c1_200.Enabled == true
            && q17c1_201.Checked == false && q17c1_201.Enabled == true
            && q17c1_202.Checked == false && q17c1_202.Enabled == true)
            {
                lblerr.Text = "Please enter Amikacin (30 µg) sensivitity ";
                lblerr.CssClass = "message-error";
                q17c1_200.Focus();
            }
            else if (q17a2.Text == "" && q17a2.Enabled == true)
            {
                lblerr.Text = "Please enter Chloramphenicol (30 µg) ";
                lblerr.CssClass = "message-error";
                q17a2.Focus();
            }
            else if (q17b2.Text == "" && q17b2.Enabled == true && q17b2.Visible == true)
            {
                lblerr.Text = "Please enter Chloramphenicol (30 µg) ";
                lblerr.CssClass = "message-error";
                q17b2.Focus();
            }
            else if (q17c2_300.Checked == false && q17c2_300.Enabled == true
            && q17c2_301.Checked == false && q17c2_301.Enabled == true
            && q17c2_302.Checked == false && q17c2_302.Enabled == true)
            {
                lblerr.Text = "Please enter Chloramphenicol (30 µg) sensitivity ";
                lblerr.CssClass = "message-error";
                q17c2_300.Focus();
            }
            else if (q17a99.Text == "" && q17a99.Enabled == true)
            {
                lblerr.Text = "Please enter Clindamycin (2 µg) ";
                lblerr.CssClass = "message-error";
                q17a99.Focus();
            }
            else if (q17b99.Text == "" && q17b99.Enabled == true && q17b99.Visible == true)
            {
                lblerr.Text = "Please enter Clindamycin (2 µg) ";
                lblerr.CssClass = "message-error";
                q17b99.Focus();
            }
            else if (q17c3_303.Checked == false && q17c3_303.Enabled == true
            && q17c3_304.Checked == false && q17c3_304.Enabled == true
            && q17c3_305.Checked == false && q17c3_305.Enabled == true)
            {
                lblerr.Text = "Please enter Clindamycin (2 µg) sensitivity ";
                lblerr.CssClass = "message-error";
                q17c3_303.Focus();
            }
            else if (q17a3.Text == "" && q17a3.Enabled == true)
            {
                lblerr.Text = "Please enter Gentamycin (2µg) ";
                lblerr.CssClass = "message-error";
                q17a3.Focus();
            }
            else if (q17b3.Text == "" && q17b3.Enabled == true && q17b3.Visible == true)
            {
                lblerr.Text = "Please enter Gentamycin (2µg) ";
                lblerr.CssClass = "message-error";
                q17b3.Focus();
            }
            else if (q17c4_306.Checked == false && q17c4_306.Enabled == true
            && q17c4_307.Checked == false && q17c4_307.Enabled == true
            && q17c4_308.Checked == false && q17c4_308.Enabled == true)
            {
                lblerr.Text = "Please enter Gentamycin (2µg) senstivity ";
                lblerr.CssClass = "message-error";
                q17c4_306.Focus();
            }
            else if (q17a4.Text == "" && q17a4.Enabled == true)
            {
                lblerr.Text = "Please enter Erythromycin (15 µg) ";
                lblerr.CssClass = "message-error";
                q17a4.Focus();
            }
            else if (q17b4.Text == "" && q17b4.Enabled == true && q17b4.Visible == true)
            {
                lblerr.Text = "Please enter Erythromycin (15 µg) ";
                lblerr.CssClass = "message-error";
                q17b4.Focus();
            }
            else if (q17c5_309.Checked == false && q17c5_309.Enabled == true
            && q17c5_400.Checked == false && q17c5_400.Enabled == true
            && q17c5_401.Checked == false && q17c5_401.Enabled == true)
            {
                lblerr.Text = "Please enter Erythromycin (15 µg) sensitivity ";
                lblerr.CssClass = "message-error";
                q17b4.Focus();
            }
            else if (q17a5.Text == "" && q17a5.Enabled == true)
            {
                lblerr.Text = "Please enter Fusidic Acid (10 µg) ";
                lblerr.CssClass = "message-error";
                q17a5.Focus();
            }
            else if (q17b5.Text == "" && q17b5.Enabled == true && q17b5.Visible == true)
            {
                lblerr.Text = "Please enter Fusidic Acid (10 µg) ";
                lblerr.CssClass = "message-error";
                q17b5.Focus();
            }
            else if (q17c6_402.Checked == false && q17c6_402.Enabled == true
            && q17c6_403.Checked == false && q17c6_403.Enabled == true
            && q17c6_404.Checked == false && q17c6_404.Enabled == true)
            {
                lblerr.Text = "Please enter Fusidic Acid (10 µg) sensitivity ";
                lblerr.CssClass = "message-error";
                q17c6_402.Focus();
            }
            else if (q17a6.Text == "" && q17a6.Enabled == true)
            {
                lblerr.Text = "Please enter Oxacillin (1 µg) ";
                lblerr.CssClass = "message-error";
                q17a6.Focus();
            }
            else if (q17b6.Text == "" && q17b6.Enabled == true && q17b6.Visible == true)
            {
                lblerr.Text = "Please enter Oxacillin (1 µg) ";
                lblerr.CssClass = "message-error";
                q17b6.Focus();
            }
            else if (q17c7_405.Checked == false && q17c7_405.Enabled == true
            && q17c7_406.Checked == false && q17c7_406.Enabled == true
            && q17c7_407.Checked == false && q17c7_407.Enabled == true)
            {
                lblerr.Text = "Please enter Oxacillin (1 µg) sensitivity ";
                lblerr.CssClass = "message-error";
                q17c7_405.Focus();
            }
            else if (q17a7.Text == "" && q17a7.Enabled == true)
            {
                lblerr.Text = "Please enter Ciprofloxacin (5 µg) ";
                lblerr.CssClass = "message-error";
                q17a7.Focus();
            }
            else if (q17b7.Text == "" && q17b7.Enabled == true && q17b7.Visible == true)
            {
                lblerr.Text = "Please enter Ciprofloxacin (5 µg) ";
                lblerr.CssClass = "message-error";
                q17b7.Focus();
            }
            else if (q17c8_408.Checked == false && q17c8_408.Enabled == true
            && q17c8_409.Checked == false && q17c8_409.Enabled == true
            && q17c8_410.Checked == false && q17c8_410.Enabled == true)
            {
                lblerr.Text = "Please enter Ciprofloxacin (5 µg) sensitivity ";
                lblerr.CssClass = "message-error";
                q17c8_408.Focus();
            }
            else if (q17a8.Text == "" && q17a8.Enabled == true)
            {
                lblerr.Text = "Please enter Penicillin (10 µg) ";
                lblerr.CssClass = "message-error";
                q17a8.Focus();
            }
            else if (q17b8.Text == "" && q17b8.Enabled == true && q17b8.Visible == true)
            {
                lblerr.Text = "Please enter Penicillin (10 µg) ";
                lblerr.CssClass = "message-error";
                q17b8.Focus();
            }
            else if (q17c9_411.Checked == false && q17c9_411.Enabled == true
            && q17c9_412.Checked == false && q17c9_412.Enabled == true
            && q17c9_413.Checked == false && q17c9_413.Enabled == true)
            {
                lblerr.Text = "Please enter Penicillin (10 µg) sensitivity ";
                lblerr.CssClass = "message-error";
                q17c9_411.Focus();
            }
            else if (q17a9.Text == "" && q17a9.Enabled == true)
            {
                lblerr.Text = "Please enter Cotrimoxazole (25 µg) ";
                lblerr.CssClass = "message-error";
                q17a9.Focus();
            }
            else if (q17b9.Text == "" && q17b9.Enabled == true && q17b9.Visible == true)
            {
                lblerr.Text = "Please enter Cotrimoxazole (25 µg) ";
                lblerr.CssClass = "message-error";
                q17b9.Focus();
            }
            else if (q17c10_414.Checked == false && q17c10_414.Enabled == true
            && q17c10_415.Checked == false && q17c10_415.Enabled == true
            && q17c10_416.Checked == false && q17c10_416.Enabled == true)
            {
                lblerr.Text = "Please enter Cotrimoxazole (25 µg) sensitivity ";
                lblerr.CssClass = "message-error";
                q17c10_414.Focus();
            }
            else if (q17a10.Text == "" && q17a10.Enabled == true)
            {
                lblerr.Text = "Please enter Tetracycline (30 µg) ";
                lblerr.CssClass = "message-error";
                q17a10.Focus();
            }
            else if (q17b10.Text == "" && q17b10.Enabled == true && q17b10.Visible == true)
            {
                lblerr.Text = "Please enter Tetracycline (30 µg) ";
                lblerr.CssClass = "message-error";
                q17b10.Focus();
            }
            else if (q17c11_417.Checked == false && q17c11_417.Enabled == true
            && q17c11_418.Checked == false && q17c11_418.Enabled == true
            && q17c11_419.Checked == false && q17c11_419.Enabled == true)
            {
                lblerr.Text = "Please enter Tetracycline (30 µg) sensitivity ";
                lblerr.CssClass = "message-error";
                q17c11_417.Focus();
            }
            else if (q18signa1.SelectedValue == "0" && q18signa1.Enabled == true)
            {
                lblerr.Text = "Please select sign of Vancomycin ";
                lblerr.CssClass = "message-error";
                q18signa1.Focus();
            }
            else if (q18a1.Text == "" && q18a1.Enabled == true)
            {
                lblerr.Text = "Please enter Vancomycin ";
                lblerr.CssClass = "message-error";
                q18a1.Focus();
            }
            else if (q18b1.Text == "" && q18b1.Enabled == true && q18b1.Visible == true)
            {
                lblerr.Text = "Please enter Vancomycin ";
                lblerr.CssClass = "message-error";
                q18b1.Focus();
            }
            else if (q18c1_420.Checked == false && q18c1_420.Enabled == true
            && q18c1_421.Checked == false && q18c1_421.Enabled == true
            && q18c1_422.Checked == false && q18c1_422.Enabled == true && q18a1.Text != "9999")
            {
                lblerr.Text = "Please enter Vancomycin sensitivity ";
                lblerr.CssClass = "message-error";
                q18c1_420.Focus();
            }
            else if (q19.SelectedValue == "0" && q19.Enabled == true)
            {
                lblerr.Text = "Please enter Conventional Multiplex PCR ";
                lblerr.CssClass = "message-error";
                q19.Focus();
            }
            else if (
                q20_1.Checked == false && q20_1.Enabled == true &&
                q20_2.Checked == false && q20_2.Enabled == true &&
                q20_3.Checked == false && q20_3.Enabled == true &&
                q20_4.Checked == false && q20_4.Enabled == true &&
                q20_5.Checked == false && q20_5.Enabled == true &&
                q20_6.Checked == false && q20_6.Enabled == true &&
                q20_7.Checked == false && q20_7.Enabled == true &&
                q20_8.Checked == false && q20_8.Enabled == true &&
                q20_9.Checked == false && q20_9.Enabled == true &&
                q20_10.Checked == false && q20_10.Enabled == true &&
                q20_11.Checked == false && q20_11.Enabled == true &&
                q20_12.Checked == false && q20_12.Enabled == true &&
                q20_13.Checked == false && q20_13.Enabled == true &&
                q20_14.Checked == false && q20_14.Enabled == true &&
                q20_15.Checked == false && q20_15.Enabled == true &&
                q20_16.Checked == false && q20_16.Enabled == true &&
                q20_17.Checked == false && q20_17.Enabled == true &&
                q20_18.Checked == false && q20_18.Enabled == true &&
                q20_19.Checked == false && q20_19.Enabled == true &&
                q20_20.Checked == false && q20_20.Enabled == true &&
                q20_21.Checked == false && q20_21.Enabled == true &&
                q20_22.Checked == false && q20_22.Enabled == true &&
                q20_23.Checked == false && q20_23.Enabled == true &&
                q20_24.Checked == false && q20_24.Enabled == true &&
                q20_25.Checked == false && q20_25.Enabled == true &&
                q20_26.Checked == false && q20_26.Enabled == true &&
                q20_27.Checked == false && q20_27.Enabled == true &&
                q20_28.Checked == false && q20_28.Enabled == true &&
                q20_29.Checked == false && q20_29.Enabled == true &&
                q20_30.Checked == false && q20_30.Enabled == true &&
                q20_31.Checked == false && q20_31.Enabled == true &&
                q20_32.Checked == false && q20_32.Enabled == true &&
                q20_33.Checked == false && q20_33.Enabled == true &&
                q20_34.Checked == false && q20_34.Enabled == true &&
                q20_35.Checked == false && q20_35.Enabled == true &&
                q20_36.Checked == false && q20_36.Enabled == true &&
                q20_37.Checked == false && q20_37.Enabled == true &&
                q20_38.Checked == false && q20_38.Enabled == true &&
                q20_39.Checked == false && q20_39.Enabled == true &&
                q20_40.Checked == false && q20_40.Enabled == true
                )
            {
                lblerr.Text = "Please select at least one option ";
                lblerr.CssClass = "message-error";
                q20_1.Focus();
            }
            //else if (q20.SelectedValue == "0" && q20.Enabled == true)
            //{
            //    lblerr.Text = "Please enter Conventional Multiplex PCR ";
            //    lblerr.CssClass = "message-error";
            //    q20.Focus();
            //}
            else if (q21.SelectedValue == "0" && q21.Enabled == true)
            {
                lblerr.Text = "Please enter Serotype Confirmation ";
                lblerr.CssClass = "message-error";
                q21.Focus();
            }
            else if (q22.SelectedValue == "0" && q22.Enabled == true)
            {
                lblerr.Text = "Please enter 6A/B/C/D Serogroup Resolution ";
                lblerr.CssClass = "message-error";
                q22.Focus();
            }
            else if (
            q23_1.Checked == false && q23_1.Enabled == true &&
            q23_2.Checked == false && q23_2.Enabled == true &&
            q23_3.Checked == false && q23_3.Enabled == true &&
            q23_4.Checked == false && q23_4.Enabled == true &&
            q23_5.Checked == false && q23_5.Enabled == true &&
            q23_6.Checked == false && q23_6.Enabled == true &&
            q23_7.Checked == false && q23_7.Enabled == true &&
            q23_8.Checked == false && q23_8.Enabled == true &&
            q23_9.Checked == false && q23_9.Enabled == true &&
            q23_10.Checked == false && q23_10.Enabled == true &&
            q23_10a.Checked == false && q23_10a.Enabled == true &&
            q23_11.Checked == false && q23_11.Enabled == true &&
            q23_12.Checked == false && q23_12.Enabled == true &&
            q23_13.Checked == false && q23_13.Enabled == true &&
            q23_14.Checked == false && q23_14.Enabled == true &&
            q23_15.Checked == false && q23_15.Enabled == true &&
            q23_16.Checked == false && q23_16.Enabled == true &&
            q23_17.Checked == false && q23_17.Enabled == true &&
            q23_18.Checked == false && q23_18.Enabled == true &&
            q23_19.Checked == false && q23_19.Enabled == true &&
            q23_20.Checked == false && q23_20.Enabled == true &&
            q23_20a.Checked == false && q23_20a.Enabled == true &&
            q23_21.Checked == false && q23_21.Enabled == true &&
            q23_22.Checked == false && q23_22.Enabled == true &&
            q23_23.Checked == false && q23_23.Enabled == true &&
            q23_24.Checked == false && q23_24.Enabled == true &&
            q23_25.Checked == false && q23_25.Enabled == true &&
            q23_26.Checked == false && q23_26.Enabled == true &&
            q23_27.Checked == false && q23_27.Enabled == true &&
            q23_28.Checked == false && q23_28.Enabled == true &&
            q23_29.Checked == false && q23_29.Enabled == true &&
            q23_30.Checked == false && q23_30.Enabled == true &&
            q23_30a.Checked == false && q23_30a.Enabled == true &&
            q23_31.Checked == false && q23_31.Enabled == true &&
            q23_32.Checked == false && q23_32.Enabled == true &&
            q23_33.Checked == false && q23_33.Enabled == true &&
            q23_34.Checked == false && q23_34.Enabled == true &&
            q23_35.Checked == false && q23_35.Enabled == true &&
            q23_36.Checked == false && q23_36.Enabled == true &&
            q23_37.Checked == false && q23_37.Enabled == true &&
            q23_38.Checked == false && q23_38.Enabled == true &&
            q23_39.Checked == false && q23_39.Enabled == true &&
            q23_40.Checked == false && q23_40.Enabled == true &&
            q23_40a.Checked == false && q23_40a.Enabled == true
            )
            {
                lblerr.Text = "Please select at least one option ";
                lblerr.CssClass = "message-error";
                q23_1.Focus();
            }

            //else if (q23.SelectedValue == "0" && q23.Enabled == true)
            //{
            //    lblerr.Text = "Please enter 6A/B/C/D Serogroup Resolution Results ";
            //    lblerr.CssClass = "message-error";
            //    q23.Focus();
            //}
            //else if (q24.SelectedValue == "0" && q24.Enabled == true)
            //{
            //    lblerr.Text = "Please enter Lyt A Real Time PCR done ";
            //    lblerr.CssClass = "message-error";
            //    q24.Focus();
            //}
            //else if (q25.SelectedValue == "0" && q25.Enabled == true)
            //{
            //    lblerr.Text = "Please enter Lyt A Real Time PCR Result ";
            //    lblerr.CssClass = "message-error";
            //    q25.Focus();
            //}
            //else if (q26.Text == "" && q26.Enabled == true)
            //{
            //    lblerr.Text = "Please enter Real Time PCR Positive ";
            //    lblerr.CssClass = "message-error";
            //    q26.Focus();
            //}
            //else if (q27.Text == "" && q27.Enabled == true)
            //{
            //    lblerr.Text = "Please enter Serotype Detected ";
            //    lblerr.CssClass = "message-error";
            //    q27.Focus();
            //}
            else
            {
                if (IsStudyID_Exists_In_Receiving() == false)
                {
                    lblerr.Text = "Study id [ " + studyid.Text + " ] does not exist in sample receiving table or status of the Specimen Received is NO in sample receiving table  ";
                    lblerr.CssClass = "message-success1";
                }
                else
                {
                    CDBOperations obj_op = new CDBOperations();
                    string child_id = obj_op.GetDataFieldWise("0", "sp_GetRecords", "childid", studyid.Text);
                    obj_op = null;


                    if (cmdSave.Text == "  Save " && Session["id"] != null)
                    {
                        string id = Session["id"].ToString();

                        if (IsChildExists(q4.Text) == false)
                        {
                            if (child_id == q4.Text)
                            {
                                if (IsValid() == true)
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
                                else
                                {
                                    lblerr.Text = "Invalid value ";
                                    lblerr.CssClass = "message-error";
                                }
                            }
                            else
                            {
                                lblerr.Text = "Child id in sample receiving form and on this (sample entry form) must be same ";
                                lblerr.CssClass = "message-error";
                                q4.Focus();
                            }
                        }
                    }
                    else
                    {
                        if (child_id == q4.Text)
                        {
                            if (IsChildExists(q4.Text) == false)
                            {
                                if (IsValid() == true)
                                {
                                    SaveData("0");
                                    //Session.Remove("id");
                                }
                                else
                                {
                                    lblerr.Text = "Invalid value ";
                                    lblerr.CssClass = "message-error";
                                }
                            }
                        }
                        else
                        {
                            lblerr.Text = "Child id in sample receiving form and on this (sample entry form) must be same ";
                            lblerr.CssClass = "message-error";
                            q4.Focus();
                        }
                    }
                }
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
                    cmd = new SqlCommand("select * from sample_entry where q4 = '" + childid1 + "'", cn.cn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        if (childid1 == dr.GetValue(dr.GetOrdinal("q4")).ToString() && studyid.Text != dr.GetValue(dr.GetOrdinal("studyid")).ToString())
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




        public bool IsStudyID_Exists_In_Receiving()
        {
            bool IsExists = false;

            SqlCommand cmd = null;
            CConnection cn = null;

            try
            {
                cn = new CConnection();
                cn.MConnOpen();

                cmd = new SqlCommand("select * from sample_recv where studyid = '" + studyid.Text + "'", cn.cn);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    IsExists = true;

                    if (dr.GetValue(dr.GetOrdinal("q6")).ToString() == "2")
                    {
                        IsExists = false;
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




        private void SaveData(string id)
        {
            string errmsg = "";
            string[] fldname = { };
            string[] fldvalue = { };
            //string day_no = "0";

            string q20_1_val = "";
            string q23_1_val = "";

            string var_Q15_c1 = "";
            string var_Q15_c2 = "";
            string var_Q15_c3 = "";
            string var_Q15_c4 = "";
            string var_Q15_c5 = "";
            string var_Q15_c6 = "";
            string var_Q15_c7 = "";

            string var_Q16_c1 = "";
            string var_Q16_c2 = "";
            string var_Q16_c3 = "";


            string var_Q17_c1 = "";
            string var_Q17_c2 = "";
            string var_Q17_c3 = "";
            string var_Q17_c4 = "";
            string var_Q17_c5 = "";
            string var_Q17_c6 = "";
            string var_Q17_c7 = "";
            string var_Q17_c8 = "";
            string var_Q17_c9 = "";
            string var_Q17_c10 = "";
            string var_Q17_c11 = "";

            string var_Q18_c1 = "";


            CDBOperations obj_op = new CDBOperations();


            try
            {


                DateTime dt_entry = new DateTime();
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_entry = Convert.ToDateTime(DateTime.Now.ToShortDateString());




                if (q15c1_1.Checked == true)
                {
                    var_Q15_c1 = "1";
                }
                else if (q15c1_2.Checked == true)
                {
                    var_Q15_c1 = "2";
                }
                else if (q15c1_3.Checked == true)
                {
                    var_Q15_c1 = "3";
                }




                if (q15c2_111.Checked == true)
                {
                    var_Q15_c2 = "1";
                }
                else if (q15c2_112.Checked == true)
                {
                    var_Q15_c2 = "2";
                }
                else if (q15c2_113.Checked == true)
                {
                    var_Q15_c2 = "3";
                }



                if (q15c3_120.Checked == true)
                {
                    var_Q15_c3 = "1";
                }
                else if (q15c3_121.Checked == true)
                {
                    var_Q15_c3 = "2";
                }
                else if (q15c3_122.Checked == true)
                {
                    var_Q15_c3 = "3";
                }



                if (q15c4_130.Checked == true)
                {
                    var_Q15_c4 = "1";
                }
                else if (q15c4_131.Checked == true)
                {
                    var_Q15_c4 = "2";
                }
                else if (q15c4_132.Checked == true)
                {
                    var_Q15_c4 = "3";
                }



                if (q15c5_140.Checked == true)
                {
                    var_Q15_c5 = "1";
                }
                else if (q15c5_141.Checked == true)
                {
                    var_Q15_c5 = "2";
                }
                else if (q15c5_142.Checked == true)
                {
                    var_Q15_c5 = "3";
                }



                if (q15c6_150.Checked == true)
                {
                    var_Q15_c6 = "1";
                }
                else if (q15c6_151.Checked == true)
                {
                    var_Q15_c6 = "2";
                }
                else if (q15c6_152.Checked == true)
                {
                    var_Q15_c6 = "3";
                }




                if (q15c7_160.Checked == true)
                {
                    var_Q15_c7 = "1";
                }
                else if (q15c7_161.Checked == true)
                {
                    var_Q15_c7 = "2";
                }
                else if (q15c7_162.Checked == true)
                {
                    var_Q15_c7 = "3";
                }




                if (q16c1_170.Checked == true)
                {
                    var_Q16_c1 = "1";
                }
                else if (q16c1_171.Checked == true)
                {
                    var_Q16_c1 = "2";
                }
                else if (q16c1_172.Checked == true)
                {
                    var_Q16_c1 = "3";
                }



                if (q16c2_180.Checked == true)
                {
                    var_Q16_c2 = "1";
                }
                else if (q16c2_181.Checked == true)
                {
                    var_Q16_c2 = "2";
                }
                else if (q16c2_182.Checked == true)
                {
                    var_Q16_c2 = "3";
                }




                if (q16c3_190.Checked == true)
                {
                    var_Q16_c3 = "1";
                }
                else if (q16c3_191.Checked == true)
                {
                    var_Q16_c3 = "2";
                }
                else if (q16c3_192.Checked == true)
                {
                    var_Q16_c3 = "3";
                }




                if (q17c1_200.Checked == true)
                {
                    var_Q17_c1 = "1";
                }
                else if (q17c1_201.Checked == true)
                {
                    var_Q17_c1 = "2";
                }
                else if (q17c1_202.Checked == true)
                {
                    var_Q17_c1 = "3";
                }




                if (q17c2_300.Checked == true)
                {
                    var_Q17_c2 = "1";
                }
                else if (q17c2_301.Checked == true)
                {
                    var_Q17_c2 = "2";
                }
                else if (q17c2_302.Checked == true)
                {
                    var_Q17_c2 = "3";
                }






                if (q17c3_303.Checked == true)
                {
                    var_Q17_c3 = "1";
                }
                else if (q17c3_304.Checked == true)
                {
                    var_Q17_c3 = "2";
                }
                else if (q17c3_305.Checked == true)
                {
                    var_Q17_c3 = "3";
                }




                if (q17c4_306.Checked == true)
                {
                    var_Q17_c4 = "1";
                }
                else if (q17c4_307.Checked == true)
                {
                    var_Q17_c4 = "2";
                }
                else if (q17c4_308.Checked == true)
                {
                    var_Q17_c4 = "3";
                }




                if (q17c5_309.Checked == true)
                {
                    var_Q17_c5 = "1";
                }
                else if (q17c5_400.Checked == true)
                {
                    var_Q17_c5 = "2";
                }
                else if (q17c5_401.Checked == true)
                {
                    var_Q17_c5 = "3";
                }



                if (q17c6_402.Checked == true)
                {
                    var_Q17_c6 = "1";
                }
                else if (q17c6_403.Checked == true)
                {
                    var_Q17_c6 = "2";
                }
                else if (q17c6_404.Checked == true)
                {
                    var_Q17_c6 = "3";
                }



                if (q17c7_405.Checked == true)
                {
                    var_Q17_c7 = "1";
                }
                else if (q17c7_406.Checked == true)
                {
                    var_Q17_c7 = "2";
                }
                else if (q17c7_407.Checked == true)
                {
                    var_Q17_c7 = "3";
                }




                if (q17c8_408.Checked == true)
                {
                    var_Q17_c8 = "1";
                }
                else if (q17c8_409.Checked == true)
                {
                    var_Q17_c8 = "2";
                }
                else if (q17c8_410.Checked == true)
                {
                    var_Q17_c8 = "3";
                }




                if (q17c9_411.Checked == true)
                {
                    var_Q17_c9 = "1";
                }
                else if (q17c9_412.Checked == true)
                {
                    var_Q17_c9 = "2";
                }
                else if (q17c9_413.Checked == true)
                {
                    var_Q17_c9 = "3";
                }




                if (q17c10_414.Checked == true)
                {
                    var_Q17_c10 = "1";
                }
                else if (q17c10_415.Checked == true)
                {
                    var_Q17_c10 = "2";
                }
                else if (q17c10_416.Checked == true)
                {
                    var_Q17_c10 = "3";
                }




                if (q17c11_417.Checked == true)
                {
                    var_Q17_c11 = "1";
                }
                else if (q17c11_418.Checked == true)
                {
                    var_Q17_c11 = "2";
                }
                else if (q17c11_419.Checked == true)
                {
                    var_Q17_c11 = "3";
                }




                if (q18c1_420.Checked == true)
                {
                    var_Q18_c1 = "1";
                }
                else if (q18c1_421.Checked == true)
                {
                    var_Q18_c1 = "2";
                }
                else if (q18c1_422.Checked == true)
                {
                    var_Q18_c1 = "3";
                }




                //DateTime dt_q6 = new DateTime();
                //if (string.IsNullOrEmpty(q6dt.Text) == false)
                //{
                //    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                //    dt_q6 = Convert.ToDateTime(q6dt.Text);
                //}


                //DateTime dt_q10dt = new DateTime();
                //if (string.IsNullOrEmpty(q10dt.Text) == false)
                //{
                //    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                //    dt_q10dt = Convert.ToDateTime(q10dt.Text);
                //}




                //if (dt_q6.ToShortDateString() != "01/01/0001" && dt_q10dt.ToShortDateString() != "01/01/0001")
                //{

                //    //day_no = obj_op.DaysDifference("22", "sp_CalculateDays", "DATE_DIFF", "", dt_q6.ToShortDateString(), dt_q10dt.ToShortDateString(), "0");


                //    if (dt_q6 > DateTime.Now.Date)
                //    {
                //        lblerr.Text = "Collection date cannot be greater than current date ";
                //        lblerr.CssClass = "message-error";
                //        q6dt.Focus();
                //        return;
                //    }
                //    else if (dt_q10dt > DateTime.Now.Date)
                //    {
                //        lblerr.Text = "Receiving date cannot be greater than current date ";
                //        lblerr.CssClass = "message-error";
                //        q10dt.Focus();
                //        return;
                //    }
                //    else if (dt_q6 > dt_q10dt)
                //    {
                //        lblerr.Text = "Collection date cannot be greater than receiving date ";
                //        lblerr.CssClass = "message-error";
                //        q6dt.Focus();
                //        return;
                //    }
                //}



                //if (id == "0")
                //{
                //    string[] fldname1 = { "var_studyid", "var_q1", "var_q2", "var_q3", "var_q3a", "var_q4", "var_q5", "var_q6dt", "var_q6t", "var_q7", "var_q8", "var_q9", "var_q10dt", "var_q10t", "var_q11", "var_q12", "var_q13", "var_q14", "var_q15a1", "var_q15b1", "var_q15a2", "var_q15b2", "var_q15a3", "var_q15b3", "var_q15a4", "var_q15b4", "var_q15a5", "var_q15b5", "var_q15a6", "var_q15b6", "var_q15a7", "var_q15b7", "var_q16a1", "var_q16b1", "var_q16a2", "var_q16b2", "var_q16a3", "var_q16b3", "var_q16c", "var_q17a1", "var_q17b1", "var_q17a2", "var_q17b2", "var_q17a3", "var_q17b3", "var_q17a4", "var_q17b4", "var_q17a5", "var_q17b5", "var_q17a6", "var_q17b6", "var_q17a7", "var_q17b7", "var_q17a8", "var_q17b8", "var_q17a9", "var_q17b9", "var_q17a10", "var_q17b10", "var_q17a11", "var_q17b11", "var_q18a1", "var_q18b1", "var_q19", "var_q20", "var_q21", "var_q22", "var_q23", "var_q24", "var_q25", "var_q26", "var_q27", "var_userid", "var_entrydate" };
                //    string[] fldvalue1 = { studyid.Text, q1.SelectedValue, q2.Text, q3.Text, q3a.Text, q4.Text, q5.SelectedValue, dt_q6.ToShortDateString(), q6t.Text, q7.SelectedValue, q8.SelectedValue, q9.Text, dt_q10dt.ToShortDateString(), q10t.Text, q11.Text, q12.SelectedValue, q13.Text, q14.SelectedValue, q15a1.Text, q15b1.Text, q15a2.Text, q15b2.Text, q15a3.Text, q15b3.Text, q15a4.Text, q15b4.Text, q15a5.Text, q15b5.Text, q15a6.Text, q15b6.Text, q15a7.Text, q15b7.Text, q16a1.Text, q16b1.Text, q16a2.Text, q16b2.Text, q16a3.Text, q16b3.Text, q16c.SelectedValue, q17a1.Text, q17b1.Text, q17a2.Text, q17b2.Text, q17a3.Text, q17b3.Text, q17a4.Text, q17b4.Text, q17a5.Text, q17b5.Text, q17a6.Text, q17b6.Text, q17a7.Text, q17b7.Text, q17a8.Text, q17b8.Text, q17a9.Text, q17b9.Text, q17a10.Text, q17b10.Text, q17a11.Text, q17b11.Text, q18a1.Text, q18b1.Text, q19.SelectedValue, q20.SelectedValue, q21.SelectedValue, q22.SelectedValue, q23.SelectedValue, q24.SelectedValue, q25.SelectedValue, q26.Text, q27.Text, Session["UserID"].ToString(), dt_entry.ToShortDateString() };

                //    fldname = fldname1;
                //    fldvalue = fldvalue1;
                //}
                //else
                //{
                //    string[] fldname1 = { "var_studyid", "var_q1", "var_q2", "var_q3", "var_q3a", "var_q4", "var_q5", "var_q6dt", "var_q6t", "var_q7", "var_q8", "var_q9", "var_q10dt", "var_q10t", "var_q11", "var_q12", "var_q13", "var_q14", "var_q15a1", "var_q15b1", "var_q15a2", "var_q15b2", "var_q15a3", "var_q15b3", "var_q15a4", "var_q15b4", "var_q15a5", "var_q15b5", "var_q15a6", "var_q15b6", "var_q15a7", "var_q15b7", "var_q16a1", "var_q16b1", "var_q16a2", "var_q16b2", "var_q16a3", "var_q16b3", "var_q16c", "var_q17a1", "var_q17b1", "var_q17a2", "var_q17b2", "var_q17a3", "var_q17b3", "var_q17a4", "var_q17b4", "var_q17a5", "var_q17b5", "var_q17a6", "var_q17b6", "var_q17a7", "var_q17b7", "var_q17a8", "var_q17b8", "var_q17a9", "var_q17b9", "var_q17a10", "var_q17b10", "var_q17a11", "var_q17b11", "var_q18a1", "var_q18b1", "var_q19", "var_q20", "var_q21", "var_q22", "var_q23", "var_q24", "var_q25", "var_q26", "var_q27", "var_userid", "var_entrydate" };
                //    string[] fldvalue1 = { studyid.Text, q1.SelectedValue, q2.Text, q3.Text, q3a.Text, q4.Text, q5.SelectedValue, dt_q6.ToShortDateString(), q6t.Text, q7.SelectedValue, q8.SelectedValue, q9.Text, dt_q10dt.ToShortDateString(), q10t.Text, q11.Text, q12.SelectedValue, q13.Text, q14.SelectedValue, q15a1.Text, q15b1.Text, q15a2.Text, q15b2.Text, q15a3.Text, q15b3.Text, q15a4.Text, q15b4.Text, q15a5.Text, q15b5.Text, q15a6.Text, q15b6.Text, q15a7.Text, q15b7.Text, q16a1.Text, q16b1.Text, q16a2.Text, q16b2.Text, q16a3.Text, q16b3.Text, q16c.SelectedValue, q17a1.Text, q17b1.Text, q17a2.Text, q17b2.Text, q17a3.Text, q17b3.Text, q17a4.Text, q17b4.Text, q17a5.Text, q17b5.Text, q17a6.Text, q17b6.Text, q17a7.Text, q17b7.Text, q17a8.Text, q17b8.Text, q17a9.Text, q17b9.Text, q17a10.Text, q17b10.Text, q17a11.Text, q17b11.Text, q18a1.Text, q18b1.Text, q19.SelectedValue, q20.SelectedValue, q21.SelectedValue, q22.SelectedValue, q23.SelectedValue, q24.SelectedValue, q25.SelectedValue, q26.Text, q27.Text, Session["UserID"].ToString(), dt_entry.ToShortDateString() };

                //    fldname = fldname1;
                //    fldvalue = fldvalue1;
                //}



                if (q20_1.Checked == true)
                {
                    q20_1_val = q20_1.Text.ToUpper();
                }
                else if (q20_2.Checked == true)
                {
                    q20_1_val = q20_2.Text.ToUpper();
                }
                else if (q20_3.Checked == true)
                {
                    q20_1_val = q20_3.Text.ToUpper();
                }
                else if (q20_4.Checked == true)
                {
                    q20_1_val = q20_4.Text.ToUpper();
                }
                else if (q20_5.Checked == true)
                {
                    q20_1_val = q20_5.Text.ToUpper();
                }
                else if (q20_6.Checked == true)
                {
                    q20_1_val = q20_6.Text.ToUpper();
                }
                else if (q20_7.Checked == true)
                {
                    q20_1_val = q20_7.Text.ToUpper();
                }
                else if (q20_8.Checked == true)
                {
                    q20_1_val = q20_8.Text.ToUpper();
                }
                else if (q20_9.Checked == true)
                {
                    q20_1_val = q20_9.Text.ToUpper();
                }
                else if (q20_10.Checked == true)
                {
                    q20_1_val = q20_10.Text.ToUpper();
                }
                else if (q20_11.Checked == true)
                {
                    q20_1_val = q20_11.Text.ToUpper();
                }
                else if (q20_12.Checked == true)
                {
                    q20_1_val = q20_12.Text.ToUpper();
                }
                else if (q20_13.Checked == true)
                {
                    q20_1_val = q20_13.Text.ToUpper();
                }
                else if (q20_14.Checked == true)
                {
                    q20_1_val = q20_14.Text.ToUpper();
                }
                else if (q20_15.Checked == true)
                {
                    q20_1_val = q20_15.Text.ToUpper();
                }
                else if (q20_16.Checked == true)
                {
                    q20_1_val = q20_16.Text.ToUpper();
                }
                else if (q20_17.Checked == true)
                {
                    q20_1_val = q20_17.Text.ToUpper();
                }
                else if (q20_18.Checked == true)
                {
                    q20_1_val = q20_18.Text.ToUpper();
                }
                else if (q20_19.Checked == true)
                {
                    q20_1_val = q20_19.Text.ToUpper();
                }
                else if (q20_20.Checked == true)
                {
                    q20_1_val = q20_20.Text.ToUpper();
                }
                else if (q20_21.Checked == true)
                {
                    q20_1_val = q20_21.Text.ToUpper();
                }
                else if (q20_22.Checked == true)
                {
                    q20_1_val = q20_22.Text.ToUpper();
                }
                else if (q20_23.Checked == true)
                {
                    q20_1_val = q20_23.Text.ToUpper();
                }
                else if (q20_24.Checked == true)
                {
                    q20_1_val = q20_24.Text.ToUpper();
                }
                else if (q20_25.Checked == true)
                {
                    q20_1_val = q20_25.Text.ToUpper();
                }
                else if (q20_26.Checked == true)
                {
                    q20_1_val = q20_26.Text.ToUpper();
                }
                else if (q20_27.Checked == true)
                {
                    q20_1_val = q20_27.Text.ToUpper();
                }
                else if (q20_28.Checked == true)
                {
                    q20_1_val = q20_28.Text.ToUpper();
                }
                else if (q20_29.Checked == true)
                {
                    q20_1_val = q20_29.Text.ToUpper();
                }
                else if (q20_30.Checked == true)
                {
                    q20_1_val = q20_30.Text.ToUpper();
                }
                else if (q20_31.Checked == true)
                {
                    q20_1_val = q20_31.Text.ToUpper();
                }
                else if (q20_32.Checked == true)
                {
                    q20_1_val = q20_32.Text.ToUpper();
                }
                else if (q20_33.Checked == true)
                {
                    q20_1_val = q20_33.Text.ToUpper();
                }
                else if (q20_34.Checked == true)
                {
                    q20_1_val = q20_34.Text.ToUpper();
                }
                else if (q20_35.Checked == true)
                {
                    q20_1_val = q20_35.Text.ToUpper();
                }
                else if (q20_36.Checked == true)
                {
                    q20_1_val = q20_36.Text.ToUpper();
                }
                else if (q20_37.Checked == true)
                {
                    q20_1_val = q20_37.Text.ToUpper();
                }
                else if (q20_38.Checked == true)
                {
                    q20_1_val = q20_38.Text.ToUpper();
                }
                else if (q20_39.Checked == true)
                {
                    q20_1_val = q20_39.Text.ToUpper();
                }
                else if (q20_40.Checked == true)
                {
                    q20_1_val = q20_40.Text.ToUpper();
                }









                if (q23_1.Checked == true)
                {
                    q23_1_val = q23_1.Text.ToUpper();
                }
                else if (q23_2.Checked == true)
                {
                    q23_1_val = q23_2.Text.ToUpper();
                }
                else if (q23_3.Checked == true)
                {
                    q23_1_val = q23_3.Text.ToUpper();
                }
                else if (q23_4.Checked == true)
                {
                    q23_1_val = q23_4.Text.ToUpper();
                }
                else if (q23_5.Checked == true)
                {
                    q23_1_val = q23_5.Text.ToUpper();
                }
                else if (q23_6.Checked == true)
                {
                    q23_1_val = q23_6.Text.ToUpper();
                }
                else if (q23_7.Checked == true)
                {
                    q23_1_val = q23_7.Text.ToUpper();
                }
                else if (q23_8.Checked == true)
                {
                    q23_1_val = q23_8.Text.ToUpper();
                }
                else if (q23_9.Checked == true)
                {
                    q23_1_val = q23_9.Text.ToUpper();
                }
                else if (q23_10.Checked == true)
                {
                    q23_1_val = q23_10.Text.ToUpper();
                }
                else if (q23_10a.Checked == true)
                {
                    q23_1_val = q23_10a.Text.ToUpper();
                }
                else if (q23_11.Checked == true)
                {
                    q23_1_val = q23_11.Text.ToUpper();
                }
                else if (q23_12.Checked == true)
                {
                    q23_1_val = q23_12.Text.ToUpper();
                }
                else if (q23_13.Checked == true)
                {
                    q23_1_val = q23_13.Text.ToUpper();
                }
                else if (q23_14.Checked == true)
                {
                    q23_1_val = q23_14.Text.ToUpper();
                }
                else if (q23_15.Checked == true)
                {
                    q23_1_val = q23_15.Text.ToUpper();
                }
                else if (q23_16.Checked == true)
                {
                    q23_1_val = q23_16.Text.ToUpper();
                }
                else if (q23_17.Checked == true)
                {
                    q23_1_val = q23_17.Text.ToUpper();
                }
                else if (q23_18.Checked == true)
                {
                    q23_1_val = q23_18.Text.ToUpper();
                }
                else if (q23_19.Checked == true)
                {
                    q23_1_val = q23_19.Text.ToUpper();
                }
                else if (q23_20.Checked == true)
                {
                    q23_1_val = q23_20.Text.ToUpper();
                }
                else if (q23_20a.Checked == true)
                {
                    q23_1_val = q23_20a.Text.ToUpper();
                }
                else if (q23_21.Checked == true)
                {
                    q23_1_val = q23_21.Text.ToUpper();
                }
                else if (q23_22.Checked == true)
                {
                    q23_1_val = q23_22.Text.ToUpper();
                }
                else if (q23_23.Checked == true)
                {
                    q23_1_val = q23_23.Text.ToUpper();
                }
                else if (q23_24.Checked == true)
                {
                    q23_1_val = q23_24.Text.ToUpper();
                }
                else if (q23_25.Checked == true)
                {
                    q23_1_val = q23_25.Text.ToUpper();
                }
                else if (q23_26.Checked == true)
                {
                    q23_1_val = q23_26.Text.ToUpper();
                }
                else if (q23_27.Checked == true)
                {
                    q23_1_val = q23_27.Text.ToUpper();
                }
                else if (q23_28.Checked == true)
                {
                    q23_1_val = q23_28.Text.ToUpper();
                }
                else if (q23_29.Checked == true)
                {
                    q23_1_val = q23_29.Text.ToUpper();
                }
                else if (q23_30.Checked == true)
                {
                    q23_1_val = q23_30.Text.ToUpper();
                }
                else if (q23_30a.Checked == true)
                {
                    q23_1_val = q23_30a.Text.ToUpper();
                }
                else if (q23_31.Checked == true)
                {
                    q23_1_val = q23_31.Text.ToUpper();
                }
                else if (q23_32.Checked == true)
                {
                    q23_1_val = q23_32.Text.ToUpper();
                }
                else if (q23_33.Checked == true)
                {
                    q23_1_val = q23_33.Text.ToUpper();
                }
                else if (q23_34.Checked == true)
                {
                    q23_1_val = q23_34.Text.ToUpper();
                }
                else if (q23_35.Checked == true)
                {
                    q23_1_val = q23_35.Text.ToUpper();
                }
                else if (q23_36.Checked == true)
                {
                    q23_1_val = q23_36.Text.ToUpper();
                }
                else if (q23_37.Checked == true)
                {
                    q23_1_val = q23_37.Text.ToUpper();
                }
                else if (q23_38.Checked == true)
                {
                    q23_1_val = q23_38.Text.ToUpper();
                }
                else if (q23_39.Checked == true)
                {
                    q23_1_val = q23_39.Text.ToUpper();
                }
                else if (q23_40.Checked == true)
                {
                    q23_1_val = q23_40.Text.ToUpper();
                }
                else if (q23_40a.Checked == true)
                {
                    q23_1_val = q23_40a.Text.ToUpper();
                }






                if (Session["mycookierole"].ToString() == "idrl")
                {


                    if (id == "0")
                    {
                        string[] fldname1 = { "var_studyid", "var_q4", "var_q4a", "var_q12", "var_q13", "var_q14", "var_q15a1", "var_q15b1", "var_q15c1", "var_q15a2", "var_q15b2", "var_q15c2", "var_q15a3", "var_q15b3", "var_q15c3", "var_q15a4", "var_q15b4", "var_q15c4", "var_q15a5", "var_q15b5", "var_q15c5", "var_q15a6", "var_q15b6", "var_q15c6", "var_q15a7", "var_q15b7", "var_q15c7", "var_q16signa1", "var_q16a1", "var_q16b1", "var_q16c1", "var_q16signa2", "var_q16a2", "var_q16b2", "var_q16c2", "var_q16signa3", "var_q16a3", "var_q16b3", "var_q16c3", "var_q16c", "var_q17a1", "var_q17b1", "var_q17c1", "var_q17a2", "var_q17b2", "var_q17c2", "var_q17a99", "var_q17b99", "var_q17c3", "var_q17a3", "var_q17b3", "var_q17c4", "var_q17a4", "var_q17b4", "var_q17c5", "var_q17a5", "var_q17b5", "var_q17c6", "var_q17a6", "var_q17b6", "var_q17c7", "var_q17a7", "var_q17b7", "var_q17c8", "var_q17a8", "var_q17b8", "var_q17c9", "var_q17a9", "var_q17b9", "var_q17c10", "var_q17a10", "var_q17b10", "var_q17c11", "var_q18signa1", "var_q18a1", "var_q18b1", "var_q18c1", "var_userid", "var_entrydate" };
                        string[] fldvalue1 = { studyid.Text, q4.Text, q4a.Text, q12.SelectedValue, q13.Text, q14.SelectedValue, q15a1.Text, q15b1.Text, var_Q15_c1, q15a2.Text, q15b2.Text, var_Q15_c2, q15a3.Text, q15b3.Text, var_Q15_c3, q15a4.Text, q15b4.Text, var_Q15_c4, q15a5.Text, q15b5.Text, var_Q15_c5, q15a6.Text, q15b6.Text, var_Q15_c6, q15a7.Text, q15b7.Text, var_Q15_c7, q16signa1.SelectedValue, q16a1.Text, q16b1.Text, var_Q16_c1, q16signa2.SelectedValue, q16a2.Text, q16b2.Text, var_Q16_c2, q16signa3.SelectedValue, q16a3.Text, q16b3.Text, var_Q16_c3, q16c.SelectedValue, q17a1.Text, q17b1.Text, var_Q17_c1, q17a2.Text, q17b2.Text, var_Q17_c2, q17a99.Text, q17b99.Text, var_Q17_c3, q17a3.Text, q17b3.Text, var_Q17_c4, q17a4.Text, q17b4.Text, var_Q17_c5, q17a5.Text, q17b5.Text, var_Q17_c6, q17a6.Text, q17b6.Text, var_Q17_c7, q17a7.Text, q17b7.Text, var_Q17_c8, q17a8.Text, q17b8.Text, var_Q17_c9, q17a9.Text, q17b9.Text, var_Q17_c10, q17a10.Text, q17b10.Text, var_Q17_c11, q18signa1.SelectedValue, q18a1.Text, q18b1.Text, var_Q18_c1, Session["UserID"].ToString(), dt_entry.ToShortDateString() };

                        fldname = fldname1;
                        fldvalue = fldvalue1;
                    }
                    else
                    {
                        string[] fldname1 = { "var_studyid", "var_q4", "var_q4a", "var_q12", "var_q13", "var_q14", "var_q15a1", "var_q15b1", "var_q15c1", "var_q15a2", "var_q15b2", "var_q15c2", "var_q15a3", "var_q15b3", "var_q15c3", "var_q15a4", "var_q15b4", "var_q15c4", "var_q15a5", "var_q15b5", "var_q15c5", "var_q15a6", "var_q15b6", "var_q15c6", "var_q15a7", "var_q15b7", "var_q15c7", "var_q16signa1", "var_q16a1", "var_q16b1", "var_q16c1", "var_q16signa2", "var_q16a2", "var_q16b2", "var_q16c2", "var_q16signa3", "var_q16a3", "var_q16b3", "var_q16c3", "var_q16c", "var_q17a1", "var_q17b1", "var_q17c1", "var_q17a2", "var_q17b2", "var_q17c2", "var_q17a99", "var_q17b99", "var_q17c3", "var_q17a3", "var_q17b3", "var_q17c4", "var_q17a4", "var_q17b4", "var_q17c5", "var_q17a5", "var_q17b5", "var_q17c6", "var_q17a6", "var_q17b6", "var_q17c7", "var_q17a7", "var_q17b7", "var_q17c8", "var_q17a8", "var_q17b8", "var_q17c9", "var_q17a9", "var_q17b9", "var_q17c10", "var_q17a10", "var_q17b10", "var_q17c11", "var_q18signa1", "var_q18a1", "var_q18b1", "var_q18c1", "var_userid", "var_entrydate" };
                        string[] fldvalue1 = { studyid.Text, q4.Text, q4a.Text, q12.SelectedValue, q13.Text, q14.SelectedValue, q15a1.Text, q15b1.Text, var_Q15_c1, q15a2.Text, q15b2.Text, var_Q15_c2, q15a3.Text, q15b3.Text, var_Q15_c3, q15a4.Text, q15b4.Text, var_Q15_c4, q15a5.Text, q15b5.Text, var_Q15_c5, q15a6.Text, q15b6.Text, var_Q15_c6, q15a7.Text, q15b7.Text, var_Q15_c7, q16signa1.SelectedValue, q16a1.Text, q16b1.Text, var_Q16_c1, q16signa2.SelectedValue, q16a2.Text, q16b2.Text, var_Q16_c2, q16signa3.SelectedValue, q16a3.Text, q16b3.Text, var_Q16_c3, q16c.SelectedValue, q17a1.Text, q17b1.Text, var_Q17_c1, q17a2.Text, q17b2.Text, var_Q17_c2, q17a99.Text, q17b99.Text, var_Q17_c3, q17a3.Text, q17b3.Text, var_Q17_c4, q17a4.Text, q17b4.Text, var_Q17_c5, q17a5.Text, q17b5.Text, var_Q17_c6, q17a6.Text, q17b6.Text, var_Q17_c7, q17a7.Text, q17b7.Text, var_Q17_c8, q17a8.Text, q17b8.Text, var_Q17_c9, q17a9.Text, q17b9.Text, var_Q17_c10, q17a10.Text, q17b10.Text, var_Q17_c11, q18signa1.SelectedValue, q18a1.Text, q18b1.Text, var_Q18_c1, Session["UserID"].ToString(), dt_entry.ToShortDateString() };

                        fldname = fldname1;
                        fldvalue = fldvalue1;
                    }


                    errmsg = obj_op.ExecuteNonQuery_Inventory(fldname, fldvalue, "sp_specimenentry1");



                }
                else if (Session["mycookierole"].ToString() == "mdl")
                {


                    if (id == "0")
                    {
                        string[] fldname1 = { "var_studyid", "var_q4", "var_q4a", "var_q19", "var_q20", "var_q21", "var_q22", "var_q23", "var_comments", "var_userid", "var_entrydate" };
                        string[] fldvalue1 = { studyid.Text, q4.Text, q4a.Text, q19.SelectedValue, q20_1_val, q21.SelectedValue, q22.SelectedValue, q23_1_val, Comments.Text.ToUpper(), Session["UserID"].ToString(), dt_entry.ToShortDateString() };

                        fldname = fldname1;
                        fldvalue = fldvalue1;
                    }
                    else
                    {
                        string[] fldname1 = { "var_studyid", "var_q4", "var_q4a", "var_q19", "var_q20", "var_q21", "var_q22", "var_q23", "var_comments", "var_userid", "var_entrydate" };
                        string[] fldvalue1 = { studyid.Text, q4.Text, q4a.Text, q19.SelectedValue, q20_1_val, q21.SelectedValue, q22.SelectedValue, q23_1_val, Comments.Text.ToUpper(), Session["UserID"].ToString(), dt_entry.ToShortDateString() };

                        fldname = fldname1;
                        fldvalue = fldvalue1;
                    }


                    errmsg = obj_op.ExecuteNonQuery_Inventory(fldname, fldvalue, "sp_specimenentry2");


                }
                else
                {
                    if (id == "0")
                    {
                        string[] fldname1 = { "var_studyid", "var_q4", "var_q4a", "var_q12", "var_q13", "var_q14", "var_q15a1", "var_q15b1", "var_q15c1", "var_q15a2", "var_q15b2", "var_q15c2", "var_q15a3", "var_q15b3", "var_q15c3", "var_q15a4", "var_q15b4", "var_q15c4", "var_q15a5", "var_q15b5", "var_q15c5", "var_q15a6", "var_q15b6", "var_q15c6", "var_q15a7", "var_q15b7", "var_q15c7", "var_q16signa1", "var_q16a1", "var_q16b1", "var_q16c1", "var_q16signa2", "var_q16a2", "var_q16b2", "var_q16c2", "var_q16signa3", "var_q16a3", "var_q16b3", "var_q16c3", "var_q16c", "var_q17a1", "var_q17b1", "var_q17c1", "var_q17a2", "var_q17b2", "var_q17c2", "var_q17a99", "var_q17b99", "var_q17c3", "var_q17a3", "var_q17b3", "var_q17c4", "var_q17a4", "var_q17b4", "var_q17c5", "var_q17a5", "var_q17b5", "var_q17c6", "var_q17a6", "var_q17b6", "var_q17c7", "var_q17a7", "var_q17b7", "var_q17c8", "var_q17a8", "var_q17b8", "var_q17c9", "var_q17a9", "var_q17b9", "var_q17c10", "var_q17a10", "var_q17b10", "var_q17c11", "var_q18signa1", "var_q18a1", "var_q18b1", "var_q18c1", "var_q19", "var_q20", "var_q21", "var_q22", "var_q23", "var_comments", "var_userid", "var_entrydate" };
                        string[] fldvalue1 = { studyid.Text, q4.Text, q4a.Text, q12.SelectedValue, q13.Text, q14.SelectedValue, q15a1.Text, q15b1.Text, var_Q15_c1, q15a2.Text, q15b2.Text, var_Q15_c2, q15a3.Text, q15b3.Text, var_Q15_c3, q15a4.Text, q15b4.Text, var_Q15_c4, q15a5.Text, q15b5.Text, var_Q15_c5, q15a6.Text, q15b6.Text, var_Q15_c6, q15a7.Text, q15b7.Text, var_Q15_c7, q16signa1.SelectedValue, q16a1.Text, q16b1.Text, var_Q16_c1, q16signa2.SelectedValue, q16a2.Text, q16b2.Text, var_Q16_c2, q16signa3.SelectedValue, q16a3.Text, q16b3.Text, var_Q16_c3, q16c.SelectedValue, q17a1.Text, q17b1.Text, var_Q17_c1, q17a2.Text, q17b2.Text, var_Q17_c2, q17a99.Text, q17b99.Text, var_Q17_c3, q17a3.Text, q17b3.Text, var_Q17_c4, q17a4.Text, q17b4.Text, var_Q17_c5, q17a5.Text, q17b5.Text, var_Q17_c6, q17a6.Text, q17b6.Text, var_Q17_c7, q17a7.Text, q17b7.Text, var_Q17_c8, q17a8.Text, q17b8.Text, var_Q17_c9, q17a9.Text, q17b9.Text, var_Q17_c10, q17a10.Text, q17b10.Text, var_Q17_c11, q18signa1.SelectedValue, q18a1.Text, q18b1.Text, var_Q18_c1, q19.SelectedValue, q20_1_val, q21.SelectedValue, q22.SelectedValue, q23_1_val, Comments.Text.ToUpper(), Session["UserID"].ToString(), dt_entry.ToShortDateString() };

                        fldname = fldname1;
                        fldvalue = fldvalue1;
                    }
                    else
                    {
                        string[] fldname1 = { "var_studyid", "var_q4", "var_q4a", "var_q12", "var_q13", "var_q14", "var_q15a1", "var_q15b1", "var_q15c1", "var_q15a2", "var_q15b2", "var_q15c2", "var_q15a3", "var_q15b3", "var_q15c3", "var_q15a4", "var_q15b4", "var_q15c4", "var_q15a5", "var_q15b5", "var_q15c5", "var_q15a6", "var_q15b6", "var_q15c6", "var_q15a7", "var_q15b7", "var_q15c7", "var_q16signa1", "var_q16a1", "var_q16b1", "var_q16c1", "var_q16signa2", "var_q16a2", "var_q16b2", "var_q16c2", "var_q16signa3", "var_q16a3", "var_q16b3", "var_q16c3", "var_q16c", "var_q17a1", "var_q17b1", "var_q17c1", "var_q17a2", "var_q17b2", "var_q17c2", "var_q17a99", "var_q17b99", "var_q17c3", "var_q17a3", "var_q17b3", "var_q17c4", "var_q17a4", "var_q17b4", "var_q17c5", "var_q17a5", "var_q17b5", "var_q17c6", "var_q17a6", "var_q17b6", "var_q17c7", "var_q17a7", "var_q17b7", "var_q17c8", "var_q17a8", "var_q17b8", "var_q17c9", "var_q17a9", "var_q17b9", "var_q17c10", "var_q17a10", "var_q17b10", "var_q17c11", "var_q18signa1", "var_q18a1", "var_q18b1", "var_q18c1", "var_q19", "var_q20", "var_q21", "var_q22", "var_q23", "var_comments", "var_userid", "var_entrydate" };
                        string[] fldvalue1 = { studyid.Text, q4.Text, q4a.Text, q12.SelectedValue, q13.Text, q14.SelectedValue, q15a1.Text, q15b1.Text, var_Q15_c1, q15a2.Text, q15b2.Text, var_Q15_c2, q15a3.Text, q15b3.Text, var_Q15_c3, q15a4.Text, q15b4.Text, var_Q15_c4, q15a5.Text, q15b5.Text, var_Q15_c5, q15a6.Text, q15b6.Text, var_Q15_c6, q15a7.Text, q15b7.Text, var_Q15_c7, q16signa1.SelectedValue, q16a1.Text, q16b1.Text, var_Q16_c1, q16signa2.SelectedValue, q16a2.Text, q16b2.Text, var_Q16_c2, q16signa3.SelectedValue, q16a3.Text, q16b3.Text, var_Q16_c3, q16c.SelectedValue, q17a1.Text, q17b1.Text, var_Q17_c1, q17a2.Text, q17b2.Text, var_Q17_c2, q17a99.Text, q17b99.Text, var_Q17_c3, q17a3.Text, q17b3.Text, var_Q17_c4, q17a4.Text, q17b4.Text, var_Q17_c5, q17a5.Text, q17b5.Text, var_Q17_c6, q17a6.Text, q17b6.Text, var_Q17_c7, q17a7.Text, q17b7.Text, var_Q17_c8, q17a8.Text, q17b8.Text, var_Q17_c9, q17a9.Text, q17b9.Text, var_Q17_c10, q17a10.Text, q17b10.Text, var_Q17_c11, q18signa1.SelectedValue, q18a1.Text, q18b1.Text, var_Q18_c1, q19.SelectedValue, q20_1_val, q21.SelectedValue, q22.SelectedValue, q23_1_val, Comments.Text.ToUpper(), Session["UserID"].ToString(), dt_entry.ToShortDateString() };

                        fldname = fldname1;
                        fldvalue = fldvalue1;
                    }


                    errmsg = obj_op.ExecuteNonQuery_Inventory(fldname, fldvalue, "sp_specimenentry_admin");
                }




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




        private int AuditTrials(string spName)
        {
            CDBOperations obj_op = null;
            DataSet ds = null;
            DataSet ds_dict = null;
            int result = 0;
            DropDownList ddlStatus1 = null;
            TextBox txtbox = null;
            RadioButton rdo = null;


            string[] arr_rdo;


            string[] arr;
            string req_id = "";


            try
            {

                req_id = Session["id"].ToString();


                obj_op = new CDBOperations();
                ds = obj_op.GetFormData_VisitID("sp_GetRecords", "3", req_id, "");


                ds_dict = obj_op.GetFormData_VisitID1("sp_GetRecords1", "0", "sample_entry");


                for (int a = 0; a <= ds_dict.Tables[0].Rows.Count - 1; a++)
                {

                    for (int b = 0; b <= ds.Tables[0].Rows.Count - 1; b++)
                    {

                        if (ds_dict.Tables[0].Rows[a]["var_id"].ToString() != "id" && ds_dict.Tables[0].Rows[a]["var_id"].ToString() != "entrydate" && ds_dict.Tables[0].Rows[a]["var_id"].ToString() != "userid")
                        {

                            //if (ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["var_id"].ToString()].ToString() != tabControl1.TabPages[Convert.ToInt32(ds_dict.Tables[0].Rows[a]["TabPageNo"].ToString())].Controls[ds_dict.Tables[0].Rows[a]["var_id"].ToString()].Text)

                            if (ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q1" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q5" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q7" || ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q8" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q12" || ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q14" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q16c" || ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q19" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q21" || ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q22" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q16signa1" || ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q16signa2" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q16signa3" || ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q18signa1")
                            {
                                if (ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q18signa1")
                                {
                                    string str = "";
                                }



                                if (Session["mycookierole"].ToString() == "receiving")
                                {
                                    if (ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q1" ||
                                        ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q5" ||
                                        ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q7" ||
                                        ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q8")
                                    {
                                        ddlStatus1 = (DropDownList)Page.FindControl("ctl00$ContentPlaceHolder1$" + ds_dict.Tables[0].Rows[a]["var_id"].ToString());


                                        if (ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["var_id"].ToString()].ToString() != ddlStatus1.SelectedValue && ddlStatus1.Visible == true)
                                        {

                                            AddRecord(spName, ds.Tables[0].Rows[b]["studyid"].ToString(), "", "", "sample_entry", "Update", ds_dict.Tables[0].Rows[a]["var_id"].ToString(), ds.Tables[0].Rows[0][ds_dict.Tables[0].Rows[a]["var_id"].ToString()].ToString(), ddlStatus1.SelectedValue.ToUpper());

                                        }
                                    }
                                }
                                else if (Session["mycookierole"].ToString() == "idrl")
                                {
                                    if (ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q12" ||
                                        ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q14" ||
                                        ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q16c" ||
                                        ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q16signa1" ||
                                        ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q16signa2" ||
                                        ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q16signa3" ||
                                        ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q18signa1")
                                    {
                                        ddlStatus1 = (DropDownList)Page.FindControl("ctl00$ContentPlaceHolder1$" + ds_dict.Tables[0].Rows[a]["var_id"].ToString());


                                        if (ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["var_id"].ToString()].ToString() != ddlStatus1.SelectedValue && ddlStatus1.Visible == true)
                                        {

                                            AddRecord(spName, ds.Tables[0].Rows[b]["studyid"].ToString(), "", "", "sample_entry", "Update", ds_dict.Tables[0].Rows[a]["var_id"].ToString(), ds.Tables[0].Rows[0][ds_dict.Tables[0].Rows[a]["var_id"].ToString()].ToString(), ddlStatus1.SelectedValue.ToUpper());

                                        }
                                    }
                                }
                                else if (Session["mycookierole"].ToString() == "mdl")
                                {
                                    if (ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q19" ||
                                        ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q21" ||
                                        ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q22")
                                    {
                                        ddlStatus1 = (DropDownList)Page.FindControl("ctl00$ContentPlaceHolder1$" + ds_dict.Tables[0].Rows[a]["var_id"].ToString());


                                        if (ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["var_id"].ToString()].ToString() != ddlStatus1.SelectedValue && ddlStatus1.Visible == true)
                                        {

                                            AddRecord(spName, ds.Tables[0].Rows[b]["studyid"].ToString(), "", "", "sample_entry", "Update", ds_dict.Tables[0].Rows[a]["var_id"].ToString(), ds.Tables[0].Rows[0][ds_dict.Tables[0].Rows[a]["var_id"].ToString()].ToString(), ddlStatus1.SelectedValue.ToUpper());

                                        }
                                    }
                                }
                                else
                                {
                                    ddlStatus1 = (DropDownList)Page.FindControl("ctl00$ContentPlaceHolder1$" + ds_dict.Tables[0].Rows[a]["var_id"].ToString());


                                    if (ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["var_id"].ToString()].ToString() != ddlStatus1.SelectedValue && ddlStatus1.Visible == true)
                                    {

                                        AddRecord(spName, ds.Tables[0].Rows[b]["studyid"].ToString(), "", "", "sample_entry", "Update", ds_dict.Tables[0].Rows[a]["var_id"].ToString(), ds.Tables[0].Rows[0][ds_dict.Tables[0].Rows[a]["var_id"].ToString()].ToString(), ddlStatus1.SelectedValue.ToUpper());

                                    }
                                }



                            }
                            else if (ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q20_1" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q20_2" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q20_3" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q20_4" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q20_5" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q20_6" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q20_7" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q20_8" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q20_9" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q20_10" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q20_11" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q20_12" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q20_13" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q20_14" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q20_15" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q20_16" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q20_17" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q20_18" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q20_19" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q20_20" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q20_21" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q20_22" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q20_23" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q20_24" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q20_25" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q20_26" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q20_27" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q20_28" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q20_29" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q20_30" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q20_31" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q20_32" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q20_33" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q20_34" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q20_35" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q20_36" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q20_37" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q20_38" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q20_39" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q20_40"
                                )
                            {


                                if (Session["mycookierole"].ToString() == "admin" || Session["mycookierole"].ToString() == "mdl")
                                {

                                    rdo = (RadioButton)Page.FindControl("ctl00$ContentPlaceHolder1$" + ds_dict.Tables[0].Rows[a]["var_id"].ToString());

                                    arr_rdo = ds_dict.Tables[0].Rows[a]["var_id"].ToString().Split('_');


                                    if (ViewState["rdo_val"] != null)
                                    {
                                        string str = ViewState["rdo_val"].ToString();


                                        if (ds.Tables[0].Rows[b][arr_rdo[0]].ToString() != str)
                                        {

                                            AddRecord(spName, ds.Tables[0].Rows[b]["studyid"].ToString(), "", "", "sample_entry", "Update", arr_rdo[0], ds.Tables[0].Rows[0][arr_rdo[0]].ToString(), str.ToUpper());
                                            ViewState["rdo_val"] = null;
                                        }

                                    }
                                    else
                                    {
                                        if (rdo.Enabled == false && CVariables.IsEntered == false)
                                        {

                                            AddRecord(spName, ds.Tables[0].Rows[b]["studyid"].ToString(), "", "", "sample_entry", "Update", arr_rdo[0], ds.Tables[0].Rows[0][arr_rdo[0]].ToString(), "");
                                            CVariables.IsEntered = true;

                                        }
                                    }

                                }


                            }
                            else if (ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q15c1" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q15c2" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q15c3" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q15c4" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q15c5" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q15c6" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q15c7" ||


                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q16signa1" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q16signa2" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q16signa3" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q18signa1" ||


                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q16c1" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q16c2" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q16c3" ||

                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q17c1" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q17c2" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q17c3" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q17c4" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q17c5" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q17c6" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q17c7" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q17c8" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q17c9" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q17c10" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q17c11" ||

                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q18c1"
                                )
                            {

                                if (Session["mycookierole"].ToString() == "admin" || Session["mycookierole"].ToString() == "idrl")
                                {

                                    string str1 = "";
                                    string[] rdo_val = { "" };


                                    if (CVariables.Store_Q15c1 != null && ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q15c1")
                                    {
                                        str1 = CVariables.Store_Q15c1;
                                        rdo_val = str1.Split('_');
                                    }
                                    else if (CVariables.Store_Q15c2 != null && ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q15c2")
                                    {
                                        str1 = CVariables.Store_Q15c2;
                                        rdo_val = str1.Split('_');
                                    }
                                    else if (CVariables.Store_Q15c3 != null && ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q15c3")
                                    {
                                        str1 = CVariables.Store_Q15c3;
                                        rdo_val = str1.Split('_');
                                    }
                                    else if (CVariables.Store_Q15c4 != null && ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q15c4")
                                    {
                                        str1 = CVariables.Store_Q15c4;
                                        rdo_val = str1.Split('_');
                                    }
                                    else if (CVariables.Store_Q15c5 != null && ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q15c5")
                                    {
                                        str1 = CVariables.Store_Q15c5;
                                        rdo_val = str1.Split('_');
                                    }
                                    else if (CVariables.Store_Q15c6 != null && ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q15c6")
                                    {
                                        str1 = CVariables.Store_Q15c6;
                                        rdo_val = str1.Split('_');
                                    }
                                    else if (CVariables.Store_Q15c7 != null && ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q15c7")
                                    {
                                        str1 = CVariables.Store_Q15c7;
                                        rdo_val = str1.Split('_');
                                    }
                                    else if (CVariables.Store_Q16c1 != null && ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q16c1")
                                    {
                                        str1 = CVariables.Store_Q16c1;
                                        rdo_val = str1.Split('_');
                                    }
                                    else if (CVariables.Store_Q16c2 != null && ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q16c2")
                                    {
                                        str1 = CVariables.Store_Q16c2;
                                        rdo_val = str1.Split('_');
                                    }
                                    else if (CVariables.Store_Q16c3 != null && ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q16c3")
                                    {
                                        str1 = CVariables.Store_Q16c3;
                                        rdo_val = str1.Split('_');
                                    }
                                    else if (CVariables.Store_Q17c1 != null && ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q17c1")
                                    {
                                        str1 = CVariables.Store_Q17c1;
                                        rdo_val = str1.Split('_');
                                    }
                                    else if (CVariables.Store_Q17c2 != null && ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q17c2")
                                    {
                                        str1 = CVariables.Store_Q17c2;
                                        rdo_val = str1.Split('_');
                                    }
                                    else if (CVariables.Store_Q17c3 != null && ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q17c3")
                                    {
                                        str1 = CVariables.Store_Q17c3;
                                        rdo_val = str1.Split('_');
                                    }
                                    else if (CVariables.Store_Q17c4 != null && ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q17c4")
                                    {
                                        str1 = CVariables.Store_Q17c4;
                                        rdo_val = str1.Split('_');
                                    }
                                    else if (CVariables.Store_Q17c5 != null && ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q17c5")
                                    {
                                        str1 = CVariables.Store_Q17c5;
                                        rdo_val = str1.Split('_');
                                    }
                                    else if (CVariables.Store_Q17c6 != null && ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q17c6")
                                    {
                                        str1 = CVariables.Store_Q17c6;
                                        rdo_val = str1.Split('_');
                                    }
                                    else if (CVariables.Store_Q17c7 != null && ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q17c7")
                                    {
                                        str1 = CVariables.Store_Q17c7;
                                        rdo_val = str1.Split('_');
                                    }
                                    else if (CVariables.Store_Q17c8 != null && ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q17c8")
                                    {
                                        str1 = CVariables.Store_Q17c8;
                                        rdo_val = str1.Split('_');
                                    }
                                    else if (CVariables.Store_Q17c9 != null && ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q17c9")
                                    {
                                        str1 = CVariables.Store_Q17c9;
                                        rdo_val = str1.Split('_');
                                    }
                                    else if (CVariables.Store_Q17c10 != null && ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q17c10")
                                    {
                                        str1 = CVariables.Store_Q17c10;
                                        rdo_val = str1.Split('_');
                                    }
                                    else if (CVariables.Store_Q17c11 != null && ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q17c11")
                                    {
                                        str1 = CVariables.Store_Q17c11;
                                        rdo_val = str1.Split('_');
                                    }
                                    else if (CVariables.Store_Q18c1 != null && ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q18c1")
                                    {
                                        str1 = CVariables.Store_Q18c1;
                                        rdo_val = str1.Split('_');
                                    }




                                    if (str1 != null && str1 != "")
                                    {
                                        //rdo = (RadioButton)Page.FindControl("ctl00$ContentPlaceHolder1$" + ds_dict.Tables[0].Rows[a]["var_id"].ToString());


                                        rdo = (RadioButton)Page.FindControl("ctl00$ContentPlaceHolder1$" + rdo_val[1] + "_" + rdo_val[2]);

                                        //string str = ViewState["rdo_val"].ToString();


                                        if (ds.Tables[0].Rows[b][rdo_val[1]].ToString() != rdo_val[0])
                                        {

                                            AddRecord(spName, ds.Tables[0].Rows[b]["studyid"].ToString(), "", "", "sample_entry", "Update", rdo_val[1], ds.Tables[0].Rows[0][rdo_val[1]].ToString(), rdo_val[0].ToUpper());

                                        }

                                    }
                                    else
                                    {
                                        if (rdo != null)
                                        {
                                            if (rdo.Enabled == false)
                                            {

                                                AddRecord(spName, ds.Tables[0].Rows[b]["studyid"].ToString(), "", "", "sample_entry", "Update", rdo_val[1], ds.Tables[0].Rows[0][rdo_val[1]].ToString(), "");

                                            }
                                        }
                                    }

                                }

                            }
                            else if (ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q23_1" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q23_2" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q23_3" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q23_4" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q23_5" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q23_6" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q23_7" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q23_8" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q23_9" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q23_10" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q23_10a" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q23_11" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q23_12" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q23_13" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q23_14" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q23_15" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q23_16" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q23_17" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q23_18" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q23_19" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q23_20" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q23_20a" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q23_21" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q23_22" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q23_23" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q23_24" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q23_25" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q23_26" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q23_27" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q23_28" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q23_29" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q23_30" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q23_30a" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q23_31" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q23_32" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q23_33" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q23_34" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q23_35" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q23_36" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q23_37" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q23_38" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q23_39" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q23_40" ||
                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q23_40a"
                                )
                            {

                                if (Session["mycookierole"].ToString() == "admin" || Session["mycookierole"].ToString() == "mdl")
                                {

                                    rdo = (RadioButton)Page.FindControl("ctl00$ContentPlaceHolder1$" + ds_dict.Tables[0].Rows[a]["var_id"].ToString());

                                    arr_rdo = ds_dict.Tables[0].Rows[a]["var_id"].ToString().Split('_');


                                    if (ViewState["rdo_val1"] != null)
                                    {
                                        string str = ViewState["rdo_val1"].ToString();


                                        if (ds.Tables[0].Rows[b][arr_rdo[0]].ToString() != str)
                                        {

                                            AddRecord(spName, ds.Tables[0].Rows[b]["studyid"].ToString(), "", "", "sample_entry", "Update", arr_rdo[0], ds.Tables[0].Rows[0][arr_rdo[0]].ToString(), str.ToUpper());
                                            ViewState["rdo_val1"] = null;
                                        }

                                    }
                                    else
                                    {
                                        if (rdo.Enabled == false && CVariables.IsEntered1 == false)
                                        {

                                            AddRecord(spName, ds.Tables[0].Rows[b]["studyid"].ToString(), "", "", "sample_entry", "Update", arr_rdo[0], ds.Tables[0].Rows[0][arr_rdo[0]].ToString(), "");
                                            CVariables.IsEntered1 = true;

                                        }
                                    }

                                }


                            }
                            else
                            {
                                txtbox = (TextBox)Page.FindControl("ctl00$ContentPlaceHolder1$" + ds_dict.Tables[0].Rows[a]["var_id"].ToString());


                                if (ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["var_id"].ToString()].ToString() != txtbox.Text && txtbox.Visible == true)
                                {

                                    if (ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q6dt" || ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q10dt")
                                    {

                                        if (ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["var_id"].ToString()].ToString() == "" && txtbox.Text == "  -  -")
                                        {

                                        }
                                        else
                                        {
                                            AddRecord(spName, ds.Tables[0].Rows[b]["studyid"].ToString(), "", "", "sample_entry", "Update", ds_dict.Tables[0].Rows[a]["var_id"].ToString(), ds.Tables[0].Rows[0][ds_dict.Tables[0].Rows[a]["var_id"].ToString()].ToString(), txtbox.Text.ToUpper());

                                            //if (result == 0)
                                            //    return 0;
                                        }

                                    }
                                    else
                                    {

                                        if (Session["mycookierole"].ToString() == "idrl")
                                        {

                                            if (ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q13" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q15a1" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q15b1" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q15a2" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q15b2" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q15a3" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q15b3" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q15a4" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q15b4" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q15a5" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q15b5" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q15a6" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q15b6" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q15a7" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q15b7" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q16a1" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q16b1" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q16a2" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q16b2" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q16a3" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q16b3" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q17a1" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q17b1" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q17a2" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q17b2" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q17a3" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q17b3" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q17a4" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q17b4" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q17a5" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q17b5" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q17a6" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q17b6" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q17a7" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q17b7" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q17a8" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q17b8" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q17a9" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q17b9" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q17a10" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q17b10" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q17a11" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q17b11" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q18a1" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q18b1"
                                                )
                                            {
                                                AddRecord(spName, ds.Tables[0].Rows[b]["studyid"].ToString(), "", "", "sample_entry", "Update", ds_dict.Tables[0].Rows[a]["var_id"].ToString(), ds.Tables[0].Rows[0][ds_dict.Tables[0].Rows[a]["var_id"].ToString()].ToString(), txtbox.Text.ToUpper());
                                            }

                                        }
                                        else if (Session["mycookierole"].ToString() == "mdl")
                                        {

                                            if (ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q20_1" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q20_2" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q20_3" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q20_4" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q20_5" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q20_6" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q20_7" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q20_8" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q20_9" ||
                                                ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "q20_10"
                                                )
                                            {

                                                AddRecord(spName, ds.Tables[0].Rows[b]["studyid"].ToString(), "", "", "sample_entry", "Update", ds_dict.Tables[0].Rows[a]["var_id"].ToString(), ds.Tables[0].Rows[0][ds_dict.Tables[0].Rows[a]["var_id"].ToString()].ToString(), txtbox.Text.ToUpper());

                                            }

                                        }
                                        else
                                        {

                                            AddRecord(spName, ds.Tables[0].Rows[b]["studyid"].ToString(), "", "", "sample_entry", "Update", ds_dict.Tables[0].Rows[a]["var_id"].ToString(), ds.Tables[0].Rows[0][ds_dict.Tables[0].Rows[a]["var_id"].ToString()].ToString(), txtbox.Text.ToUpper());

                                        }



                                    }

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
                CVariables.IsEntered = false;
                CVariables.IsEntered1 = false;
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

        protected void q25_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (q25.SelectedValue == "1")
            //{
            //    EnableControls(q26);

            //    q25.Focus();
            //}
            //else
            //{
            //    DisableControls(q26);

            //    q27.Focus();
            //}
        }

        protected void q7_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (q7.SelectedValue == "1")
            //{
            //    //Enable_q7();

            //    if (Request.Cookies["mycookierole"].Value == "receiver")
            //    {
            //        if (Session["id"] != null)
            //        {
            //            string id = Session["id"].ToString();
            //            FillGrid(id, "1");
            //        }

            //        Enable_Receiver();
            //        Disable_Lab();
            //        Disable_Serotyping();
            //    }
            //    else if (Request.Cookies["mycookierole"].Value == "lab")
            //    {
            //        if (Session["id"] != null)
            //        {
            //            string id = Session["id"].ToString();
            //            FillGrid(id, "1");
            //        }

            //        Enable_Lab();
            //        Disable_Receiver();
            //        Disable_Serotyping();
            //    }
            //    else if (Request.Cookies["mycookierole"].Value == "serotyping")
            //    {
            //        if (Session["id"] != null)
            //        {
            //            string id = Session["id"].ToString();
            //            FillGrid(id, "1");
            //        }

            //        Enable_Serotyping();
            //        Disable_Lab();
            //        Disable_Receiver();
            //    }
            //    else
            //    {
            //        Enable_ErrorMsg();

            //        if (Session["id"] != null)
            //        {
            //            string id = Session["id"].ToString();
            //            FillGrid(id, "1");
            //        }
            //    }

            //    q8.Focus();
            //}
            //else
            //{
            //    Disable_q7();

            //    cmdSave.Focus();
            //}
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





        public void DisableControls1(DropDownList txtbox)
        {
            try
            {
                txtbox.Enabled = false;
                txtbox.BackColor = System.Drawing.Color.Silver;
                txtbox.Visible = false;
            }
            catch (Exception ex)
            {

            }

            finally
            {
                txtbox = null;
            }
        }





        public void DisableControls1(TextBox txtbox)
        {
            try
            {
                txtbox.Enabled = false;
                txtbox.BackColor = System.Drawing.Color.Silver;
                txtbox.Visible = false;
            }
            catch (Exception ex)
            {

            }

            finally
            {
                txtbox = null;
            }
        }







        public void EnableControls(RadioButton rdo)
        {
            try
            {
                rdo.Enabled = true;
                rdo.Visible = true;
            }
            catch (Exception ex)
            {

            }

            finally
            {
                rdo = null;
            }
        }



        public void DisableControls(RadioButton rdo)
        {
            try
            {
                rdo.Enabled = false;
                rdo.Checked = false;
                rdo.Visible = false;
            }
            catch (Exception ex)
            {

            }

            finally
            {
                rdo = null;
            }
        }







        private void Enable_q7()
        {
            //EnableControls(q8);
            //EnableControls(q9);
            //EnableControls(q10dt);
            //EnableControls(q10t);
            //EnableControls(q11);
            EnableControls(q12);
            EnableControls(q13);
            EnableControls(q14);
            EnableControls(q15a1);
            EnableControls(q15b1);
            EnableControls(q15a2);
            EnableControls(q15b2);
            EnableControls(q15a3);
            EnableControls(q15b3);
            EnableControls(q15a4);
            EnableControls(q15b4);
            EnableControls(q15a5);
            EnableControls(q15b5);
            EnableControls(q15a6);
            EnableControls(q15b6);
            EnableControls(q15a7);
            EnableControls(q15b7);
            EnableControls(q16a1);
            EnableControls(q16b1);
            EnableControls(q16a2);
            EnableControls(q16b2);
            EnableControls(q16a3);
            EnableControls(q16b3);
            EnableControls(q16c);
            EnableControls(q17a1);
            EnableControls(q17b1);
            EnableControls(q17a2);
            EnableControls(q17b2);
            EnableControls(q17a3);
            EnableControls(q17b3);
            EnableControls(q17a4);
            EnableControls(q17b4);
            EnableControls(q17a5);
            EnableControls(q17b5);
            EnableControls(q17a6);
            EnableControls(q17b6);
            EnableControls(q17a7);
            EnableControls(q17b7);
            EnableControls(q17a8);
            EnableControls(q17b8);
            EnableControls(q17a9);
            EnableControls(q17b9);
            EnableControls(q17a10);
            EnableControls(q17b10);


            EnableControls(q18a1);
            EnableControls(q18b1);

            EnableControls(q19);


            if (q19.SelectedValue == "1")
            {
                q19_Enabled();
            }
            else
            {
                q19_Disabled();
            }



            //EnableControls(q20);
            //EnableControls(q21);
            //EnableControls(q22);
            //EnableControls(q23);
            //EnableControls(q24);
            //EnableControls(q25);

            //if (q25.SelectedValue == "1")
            //{
            //    EnableControls(q26);
            //}
            //else
            //{
            //    DisableControls(q26);
            //}


            //EnableControls(q27);
        }



        private void Disable_q7()
        {
            //DisableControls(q8);
            //DisableControls(q9);
            //DisableControls(q10dt);
            //DisableControls(q10t);
            //DisableControls(q11);
            DisableControls(q12);
            DisableControls(q13);
            DisableControls(q14);
            DisableControls(q15a1);
            DisableControls(q15b1);
            DisableControls(q15a2);
            DisableControls(q15b2);
            DisableControls(q15a3);
            DisableControls(q15b3);
            DisableControls(q15a4);
            DisableControls(q15b4);
            DisableControls(q15a5);
            DisableControls(q15b5);
            DisableControls(q15a6);
            DisableControls(q15b6);
            DisableControls(q15a7);
            DisableControls(q15b7);
            DisableControls(q16a1);
            DisableControls(q16b1);
            DisableControls(q16a2);
            DisableControls(q16b2);
            DisableControls(q16a3);
            DisableControls(q16b3);
            DisableControls(q16c);

            DisableControls(q17a1);
            DisableControls(q17b1);
            DisableControls(q17a2);
            DisableControls(q17b2);
            DisableControls(q17a3);
            DisableControls(q17b3);
            DisableControls(q17a4);
            DisableControls(q17b4);
            DisableControls(q17a5);
            DisableControls(q17b5);
            DisableControls(q17a6);
            DisableControls(q17b6);
            DisableControls(q17a7);
            DisableControls(q17b7);
            DisableControls(q17a8);
            DisableControls(q17b8);
            DisableControls(q17a9);
            DisableControls(q17b9);
            DisableControls(q17a10);
            DisableControls(q17b10);


            DisableControls(q18a1);
            DisableControls(q18b1);

            DisableControls(q19);
            q19_Disabled();
        }



        private void Disable_ErrorMsg()
        {
            DisableControls(studyid);
            //DisableControls(q1);
            //DisableControls(q2);
            //DisableControls(q3);
            //DisableControls(q3a);

            DisableControls(q4);
            DisableControls(q4a);

            //DisableControls(q5);
            //DisableControls(q6dt);
            //DisableControls(q6t);
            //DisableControls(q7);
            //DisableControls(q8);
            //DisableControls(q9);
            //DisableControls(q10dt);
            //DisableControls(q10t);
            //DisableControls(q11);
            DisableControls(q12);
            DisableControls(q13);
            DisableControls(q14);
            DisableControls(q15a1);
            DisableControls(q15b1);
            DisableControls(q15c1_1);
            DisableControls(q15c1_2);
            DisableControls(q15c1_3);

            DisableControls(q15a2);
            DisableControls(q15b2);
            DisableControls(q15c2_111);
            DisableControls(q15c2_112);
            DisableControls(q15c2_113);

            DisableControls(q15a3);
            DisableControls(q15b3);
            DisableControls(q15c3_120);
            DisableControls(q15c3_121);
            DisableControls(q15c3_122);

            DisableControls(q15a4);
            DisableControls(q15b4);
            DisableControls(q15c4_130);
            DisableControls(q15c4_131);
            DisableControls(q15c4_132);

            DisableControls(q15a5);
            DisableControls(q15b5);
            DisableControls(q15c5_140);
            DisableControls(q15c5_141);
            DisableControls(q15c5_142);

            DisableControls(q15a6);
            DisableControls(q15b6);
            DisableControls(q15c6_150);
            DisableControls(q15c6_151);
            DisableControls(q15c6_152);

            DisableControls(q15a7);
            DisableControls(q15b7);
            DisableControls(q15c7_160);
            DisableControls(q15c7_161);
            DisableControls(q15c7_162);

            DisableControls(q16a1);
            DisableControls(q16b1);
            DisableControls(q16c1_170);
            DisableControls(q16c1_171);
            DisableControls(q16c1_172);

            DisableControls(q16a2);
            DisableControls(q16b2);
            DisableControls(q16c2_180);
            DisableControls(q16c2_181);
            DisableControls(q16c2_182);

            DisableControls(q16a3);
            DisableControls(q16b3);
            DisableControls(q16c3_190);
            DisableControls(q16c3_191);
            DisableControls(q16c3_192);

            DisableControls(q16c);

            DisableControls(q17a1);
            DisableControls(q17b1);
            DisableControls(q17c1_200);
            DisableControls(q17c1_201);
            DisableControls(q17c1_202);

            DisableControls(q17a2);
            DisableControls(q17b2);
            DisableControls(q17c2_300);
            DisableControls(q17c2_301);
            DisableControls(q17c2_302);

            DisableControls(q17a99);
            DisableControls(q17b99);
            DisableControls(q17c3_303);
            DisableControls(q17c3_304);
            DisableControls(q17c3_305);


            DisableControls(q17a3);
            DisableControls(q17b3);
            DisableControls(q17c4_306);
            DisableControls(q17c4_307);
            DisableControls(q17c4_308);

            DisableControls(q17a4);
            DisableControls(q17b4);
            DisableControls(q17c5_309);
            DisableControls(q17c5_400);
            DisableControls(q17c5_401);

            DisableControls(q17a5);
            DisableControls(q17b5);
            DisableControls(q17c6_402);
            DisableControls(q17c6_403);
            DisableControls(q17c6_404);

            DisableControls(q17a6);
            DisableControls(q17b6);
            DisableControls(q17c7_405);
            DisableControls(q17c7_406);
            DisableControls(q17c7_407);

            DisableControls(q17a7);
            DisableControls(q17b7);
            DisableControls(q17c8_408);
            DisableControls(q17c8_409);
            DisableControls(q17c8_410);

            DisableControls(q17a8);
            DisableControls(q17b8);
            DisableControls(q17c9_411);
            DisableControls(q17c9_412);
            DisableControls(q17c9_413);

            DisableControls(q17a9);
            DisableControls(q17b9);
            DisableControls(q17c10_414);
            DisableControls(q17c10_415);
            DisableControls(q17c10_416);

            DisableControls(q17a10);
            DisableControls(q17b10);
            DisableControls(q17c11_417);
            DisableControls(q17c11_418);
            DisableControls(q17c11_419);

            DisableControls(q18a1);
            DisableControls(q18b1);
            DisableControls(q18c1_420);
            DisableControls(q18c1_421);
            DisableControls(q18c1_422);

            DisableControls(q19);

            q19_Disabled();
        }



        private void Enable_ErrorMsg()
        {
            EnableControls(studyid);
            //EnableControls(q1);
            //EnableControls(q2);
            //EnableControls(q3);
            //EnableControls(q3a);

            EnableControls(q4);
            EnableControls(q4a);

            //EnableControls(q5);
            //EnableControls(q6dt);
            //EnableControls(q6t);
            //EnableControls(q7);
            //EnableControls(q8);
        }




        private void Enable_Receiver()
        {
            //EnableControls(q1);
            //EnableControls(q2);
            //EnableControls(q3);
            //EnableControls(q3a);
            //EnableControls(q4);
            //EnableControls(q5);
            //EnableControls(q6dt);
            //EnableControls(q6t);
            //EnableControls(q7);
            //EnableControls(q8);
            //EnableControls(q9);
            //EnableControls(q10dt);
            //EnableControls(q10t);
            //EnableControls(q11);
        }



        private void Disable_Receiver()
        {
            //DisableControls1(q1);
            //DisableControls1(q2);
            //DisableControls1(q3);
            //DisableControls1(q3a);
            //DisableControls1(q4);
            //DisableControls1(q5);
            //DisableControls1(q6dt);
            //DisableControls1(q6t);
            //DisableControls1(q7);
            //DisableControls1(q8);
            //DisableControls1(q9);
            //DisableControls1(q10dt);
            //DisableControls1(q10t);
            //DisableControls1(q11);
        }





        private void Enable_Lab()
        {
            EnableControls(q12);

            if (q12.SelectedValue == "1")
            {
                Q12_Enable();
            }
            else
            {
                Q12_Disable();
            }

            //EnableControls(q13);
            //EnableControls(q14);
            //EnableControls(q15a1);
            //EnableControls(q15b1);
            //EnableControls(q15c1_1);
            //EnableControls(q15c1_2);
            //EnableControls(q15c1_3);

            //EnableControls(q15a2);
            //EnableControls(q15b2);
            //EnableControls(q15c2_111);
            //EnableControls(q15c2_112);
            //EnableControls(q15c2_113);
            //EnableControls(q15a3);
            //EnableControls(q15b3);
            //EnableControls(q15c3_120);
            //EnableControls(q15c3_121);
            //EnableControls(q15c3_122);
            //EnableControls(q15a4);
            //EnableControls(q15b4);
            //EnableControls(q15c4_130);
            //EnableControls(q15c4_131);
            //EnableControls(q15c4_132);
            //EnableControls(q15a5);
            //EnableControls(q15b5);
            //EnableControls(q15c5_140);
            //EnableControls(q15c5_141);
            //EnableControls(q15c5_142);
            //EnableControls(q15a6);
            //EnableControls(q15b6);
            //EnableControls(q15c6_150);
            //EnableControls(q15c6_151);
            //EnableControls(q15c6_152);
            //EnableControls(q15a7);
            //EnableControls(q15b7);
            //EnableControls(q15c7_160);
            //EnableControls(q15c7_161);
            //EnableControls(q15c7_162);
            //EnableControls(q16a1);
            //EnableControls(q16b1);
            //EnableControls(q16c1_170);
            //EnableControls(q16c1_171);
            //EnableControls(q16c1_172);
            //EnableControls(q16a2);
            //EnableControls(q16b2);
            //EnableControls(q16c2_180);
            //EnableControls(q16c2_181);
            //EnableControls(q16c2_182);
            //EnableControls(q16a3);
            //EnableControls(q16b3);
            //EnableControls(q16c3_190);
            //EnableControls(q16c3_191);
            //EnableControls(q16c3_192);


            EnableControls(q16c);

            if (q16c.SelectedValue == "1")
            {
                Q16c_Enable();
            }
            else
            {
                Q16c_Disable();
            }

            //EnableControls(q17a1);
            //EnableControls(q17b1);
            //EnableControls(q17c1_200);
            //EnableControls(q17c1_201);
            //EnableControls(q17c1_202);

            //EnableControls(q17a2);
            //EnableControls(q17b2);
            //EnableControls(q17c2_300);
            //EnableControls(q17c2_301);
            //EnableControls(q17c2_302);

            //EnableControls(q17a99);
            //EnableControls(q17b99);
            //EnableControls(q17c3_303);
            //EnableControls(q17c3_304);
            //EnableControls(q17c3_305);

            //EnableControls(q17a3);
            //EnableControls(q17b3);
            //EnableControls(q17c4_306);
            //EnableControls(q17c4_307);
            //EnableControls(q17c4_308);

            //EnableControls(q17a4);
            //EnableControls(q17b4);
            //EnableControls(q17c5_309);
            //EnableControls(q17c5_400);
            //EnableControls(q17c5_401);

            //EnableControls(q17a5);
            //EnableControls(q17b5);
            //EnableControls(q17c6_402);
            //EnableControls(q17c6_403);
            //EnableControls(q17c6_404);

            //EnableControls(q17a6);
            //EnableControls(q17b6);
            //EnableControls(q17c7_405);
            //EnableControls(q17c7_406);
            //EnableControls(q17c7_407);

            //EnableControls(q17a7);
            //EnableControls(q17b7);
            //EnableControls(q17c8_408);
            //EnableControls(q17c8_409);
            //EnableControls(q17c8_410);

            //EnableControls(q17a8);
            //EnableControls(q17b8);
            //EnableControls(q17c9_411);
            //EnableControls(q17c9_412);
            //EnableControls(q17c9_413);

            //EnableControls(q17a9);
            //EnableControls(q17b9);
            //EnableControls(q17c10_414);
            //EnableControls(q17c10_415);
            //EnableControls(q17c10_416);

            //EnableControls(q17a10);
            //EnableControls(q17b10);
            //EnableControls(q17c11_417);
            //EnableControls(q17c11_418);
            //EnableControls(q17c11_419);

            //EnableControls(q18a1);
            //EnableControls(q18b1);
            //EnableControls(q18c1_420);
            //EnableControls(q18c1_421);
            //EnableControls(q18c1_422);
        }



        private void Disable_Lab()
        {
            DisableControls1(q12);
            DisableControls1(q13);
            DisableControls1(q14);
            DisableControls1(q15a1);
            DisableControls1(q15b1);
            DisableControls(q15c1_1);
            DisableControls(q15c1_2);
            DisableControls(q15c1_3);

            DisableControls1(q15a2);
            DisableControls1(q15b2);
            DisableControls(q15c2_111);
            DisableControls(q15c2_112);
            DisableControls(q15c2_113);

            DisableControls1(q15a3);
            DisableControls1(q15b3);
            DisableControls(q15c3_120);
            DisableControls(q15c3_121);
            DisableControls(q15c3_122);

            DisableControls1(q15a4);
            DisableControls1(q15b4);
            DisableControls(q15c4_130);
            DisableControls(q15c4_131);
            DisableControls(q15c4_132);

            DisableControls1(q15a5);
            DisableControls1(q15b5);
            DisableControls(q15c5_140);
            DisableControls(q15c5_141);
            DisableControls(q15c5_142);

            DisableControls1(q15a6);
            DisableControls1(q15b6);
            DisableControls(q15c6_150);
            DisableControls(q15c6_151);
            DisableControls(q15c6_152);

            DisableControls1(q15a7);
            DisableControls1(q15b7);
            DisableControls(q15c7_160);
            DisableControls(q15c7_161);
            DisableControls(q15c7_162);

            DisableControls1(q16signa1);
            DisableControls1(q16a1);
            DisableControls1(q16b1);
            DisableControls(q16c1_170);
            DisableControls(q16c1_171);
            DisableControls(q16c1_172);

            DisableControls1(q16signa2);
            DisableControls1(q16a2);
            DisableControls1(q16b2);
            DisableControls(q16c2_180);
            DisableControls(q16c2_181);
            DisableControls(q16c2_182);

            DisableControls1(q16signa3);
            DisableControls1(q16a3);
            DisableControls1(q16b3);
            DisableControls(q16c3_190);
            DisableControls(q16c3_191);
            DisableControls(q16c3_192);

            DisableControls1(q16c);

            DisableControls1(q17a1);
            DisableControls1(q17b1);
            DisableControls(q17c1_200);
            DisableControls(q17c1_201);
            DisableControls(q17c1_202);

            DisableControls1(q17a2);
            DisableControls1(q17b2);
            DisableControls(q17c2_300);
            DisableControls(q17c2_301);
            DisableControls(q17c2_302);


            DisableControls1(q17a99);
            DisableControls1(q17b99);
            DisableControls(q17c3_303);
            DisableControls(q17c3_304);
            DisableControls(q17c3_305);

            DisableControls1(q17a3);
            DisableControls1(q17b3);
            DisableControls(q17c4_306);
            DisableControls(q17c4_307);
            DisableControls(q17c4_308);

            DisableControls1(q17a4);
            DisableControls1(q17b4);
            DisableControls(q17c5_309);
            DisableControls(q17c5_400);
            DisableControls(q17c5_401);

            DisableControls1(q17a5);
            DisableControls1(q17b5);
            DisableControls(q17c6_402);
            DisableControls(q17c6_403);
            DisableControls(q17c6_404);

            DisableControls1(q17a6);
            DisableControls1(q17b6);
            DisableControls(q17c7_405);
            DisableControls(q17c7_406);
            DisableControls(q17c7_407);

            DisableControls1(q17a7);
            DisableControls1(q17b7);
            DisableControls(q17c8_408);
            DisableControls(q17c8_409);
            DisableControls(q17c8_410);

            DisableControls1(q17a8);
            DisableControls1(q17b8);
            DisableControls(q17c9_411);
            DisableControls(q17c9_412);
            DisableControls(q17c9_413);

            DisableControls1(q17a9);
            DisableControls1(q17b9);
            DisableControls(q17c10_414);
            DisableControls(q17c10_415);
            DisableControls(q17c10_416);

            DisableControls1(q17a10);
            DisableControls1(q17b10);
            DisableControls(q17c11_417);
            DisableControls(q17c11_418);
            DisableControls(q17c11_419);

            DisableControls1(q18signa1);
            DisableControls1(q18a1);
            DisableControls1(q18b1);
            DisableControls(q18c1_420);
            DisableControls(q18c1_421);
            DisableControls(q18c1_422);
        }



        private void Enable_Serotyping()
        {
            EnableControls(q19);

            if (q19.SelectedValue == "1")
            {
                q19_Enabled();
            }
            else
            {
                q19_Disabled();
            }
        }



        private void Disable_Serotyping()
        {
            DisableControls(q19);

            q19_Disabled();
        }

        protected void q19_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (q19.SelectedValue == "1")
            {
                q19_Enabled();

                q20_1.Focus();
            }
            else
            {
                q19_Disabled();

                cmdSave.Focus();
            }
        }




        private void q19_Enabled()
        {

            EnableControls(q20_1);
            EnableControls(q20_2);
            EnableControls(q20_3);
            EnableControls(q20_4);
            EnableControls(q20_5);
            EnableControls(q20_6);
            EnableControls(q20_7);
            EnableControls(q20_8);
            EnableControls(q20_9);
            EnableControls(q20_10);
            EnableControls(q20_11);
            EnableControls(q20_12);
            EnableControls(q20_13);
            EnableControls(q20_14);
            EnableControls(q20_15);
            EnableControls(q20_16);
            EnableControls(q20_17);
            EnableControls(q20_18);
            EnableControls(q20_19);
            EnableControls(q20_20);
            EnableControls(q20_21);
            EnableControls(q20_22);
            EnableControls(q20_23);
            EnableControls(q20_24);
            EnableControls(q20_25);
            EnableControls(q20_26);
            EnableControls(q20_27);
            EnableControls(q20_28);
            EnableControls(q20_29);
            EnableControls(q20_30);
            EnableControls(q20_31);
            EnableControls(q20_32);
            EnableControls(q20_33);
            EnableControls(q20_34);
            EnableControls(q20_35);
            EnableControls(q20_36);
            EnableControls(q20_37);
            EnableControls(q20_38);
            EnableControls(q20_39);
            EnableControls(q20_40);

            EnableControls(q21);
            EnableControls(q22);

            EnableControls(q23_1);
            EnableControls(q23_2);
            EnableControls(q23_3);
            EnableControls(q23_4);
            EnableControls(q23_5);
            EnableControls(q23_6);
            EnableControls(q23_7);
            EnableControls(q23_8);
            EnableControls(q23_9);
            EnableControls(q23_10);
            EnableControls(q23_10a);
            EnableControls(q23_11);
            EnableControls(q23_12);
            EnableControls(q23_13);
            EnableControls(q23_14);
            EnableControls(q23_15);
            EnableControls(q23_16);
            EnableControls(q23_17);
            EnableControls(q23_18);
            EnableControls(q23_19);
            EnableControls(q23_20);
            EnableControls(q23_20a);
            EnableControls(q23_21);
            EnableControls(q23_22);
            EnableControls(q23_23);
            EnableControls(q23_24);
            EnableControls(q23_25);
            EnableControls(q23_26);
            EnableControls(q23_27);
            EnableControls(q23_28);
            EnableControls(q23_29);
            EnableControls(q23_30);
            EnableControls(q23_30a);
            EnableControls(q23_31);
            EnableControls(q23_32);
            EnableControls(q23_33);
            EnableControls(q23_34);
            EnableControls(q23_35);
            EnableControls(q23_36);
            EnableControls(q23_37);
            EnableControls(q23_38);
            EnableControls(q23_39);
            EnableControls(q23_40);
            EnableControls(q23_40a);
            EnableControls(Comments);
        }



        private void q19_Disabled()
        {
            DisableControls(q20_1);
            DisableControls(q20_2);
            DisableControls(q20_3);
            DisableControls(q20_4);
            DisableControls(q20_5);
            DisableControls(q20_6);
            DisableControls(q20_7);
            DisableControls(q20_8);
            DisableControls(q20_9);
            DisableControls(q20_10);
            DisableControls(q20_11);
            DisableControls(q20_12);
            DisableControls(q20_13);
            DisableControls(q20_14);
            DisableControls(q20_15);
            DisableControls(q20_16);
            DisableControls(q20_17);
            DisableControls(q20_18);
            DisableControls(q20_19);
            DisableControls(q20_20);
            DisableControls(q20_21);
            DisableControls(q20_22);
            DisableControls(q20_23);
            DisableControls(q20_24);
            DisableControls(q20_25);
            DisableControls(q20_26);
            DisableControls(q20_27);
            DisableControls(q20_28);
            DisableControls(q20_29);
            DisableControls(q20_30);
            DisableControls(q20_31);
            DisableControls(q20_32);
            DisableControls(q20_33);
            DisableControls(q20_34);
            DisableControls(q20_35);
            DisableControls(q20_36);
            DisableControls(q20_37);
            DisableControls(q20_38);
            DisableControls(q20_39);
            DisableControls(q20_40);

            DisableControls(q21);
            DisableControls(q22);

            DisableControls(q23_1);
            DisableControls(q23_2);
            DisableControls(q23_3);
            DisableControls(q23_4);
            DisableControls(q23_5);
            DisableControls(q23_6);
            DisableControls(q23_7);
            DisableControls(q23_8);
            DisableControls(q23_9);
            DisableControls(q23_10);
            DisableControls(q23_10a);
            DisableControls(q23_11);
            DisableControls(q23_12);
            DisableControls(q23_13);
            DisableControls(q23_14);
            DisableControls(q23_15);
            DisableControls(q23_16);
            DisableControls(q23_17);
            DisableControls(q23_18);
            DisableControls(q23_19);
            DisableControls(q23_20);
            DisableControls(q23_20a);
            DisableControls(q23_21);
            DisableControls(q23_22);
            DisableControls(q23_23);
            DisableControls(q23_24);
            DisableControls(q23_25);
            DisableControls(q23_26);
            DisableControls(q23_27);
            DisableControls(q23_28);
            DisableControls(q23_29);
            DisableControls(q23_30);
            DisableControls(q23_30a);
            DisableControls(q23_31);
            DisableControls(q23_32);
            DisableControls(q23_33);
            DisableControls(q23_34);
            DisableControls(q23_35);
            DisableControls(q23_36);
            DisableControls(q23_37);
            DisableControls(q23_38);
            DisableControls(q23_39);
            DisableControls(q23_40);
            DisableControls(q23_40a);
            DisableControls(Comments);
        }

        protected void q20_1_CheckedChanged(object sender, EventArgs e)
        {
            if (q20_1.Checked == true)
            {
                ViewState["rdo_val"] = q20_1.Text;
            }
            else
            {
                ViewState["rdo_val"] = null;
            }
        }

        protected void q20_11_CheckedChanged(object sender, EventArgs e)
        {
            if (q20_11.Checked == true)
            {
                ViewState["rdo_val"] = q20_11.Text;
            }
            else
            {
                ViewState["rdo_val"] = null;
            }
        }

        protected void q20_2_CheckedChanged(object sender, EventArgs e)
        {
            if (q20_2.Checked == true)
            {
                ViewState["rdo_val"] = q20_2.Text;
            }
            else
            {
                ViewState["rdo_val"] = null;
            }
        }

        protected void q20_3_CheckedChanged(object sender, EventArgs e)
        {
            if (q20_3.Checked == true)
            {
                ViewState["rdo_val"] = q20_3.Text;
            }
            else
            {
                ViewState["rdo_val"] = null;
            }
        }

        protected void q20_4_CheckedChanged(object sender, EventArgs e)
        {
            if (q20_4.Checked == true)
            {
                ViewState["rdo_val"] = q20_4.Text;
            }
            else
            {
                ViewState["rdo_val"] = null;
            }
        }

        protected void q20_5_CheckedChanged(object sender, EventArgs e)
        {
            if (q20_5.Checked == true)
            {
                ViewState["rdo_val"] = q20_5.Text;
            }
            else
            {
                ViewState["rdo_val"] = null;
            }
        }

        protected void q20_6_CheckedChanged(object sender, EventArgs e)
        {
            if (q20_6.Checked == true)
            {
                ViewState["rdo_val"] = q20_6.Text;
            }
            else
            {
                ViewState["rdo_val"] = null;
            }
        }

        protected void q20_7_CheckedChanged(object sender, EventArgs e)
        {
            if (q20_7.Checked == true)
            {
                ViewState["rdo_val"] = q20_7.Text;
            }
            else
            {
                ViewState["rdo_val"] = null;
            }
        }

        protected void q20_8_CheckedChanged(object sender, EventArgs e)
        {
            if (q20_8.Checked == true)
            {
                ViewState["rdo_val"] = q20_8.Text;
            }
            else
            {
                ViewState["rdo_val"] = null;
            }
        }

        protected void q20_9_CheckedChanged(object sender, EventArgs e)
        {
            if (q20_9.Checked == true)
            {
                ViewState["rdo_val"] = q20_9.Text;
            }
            else
            {
                ViewState["rdo_val"] = null;
            }
        }

        protected void q20_10_CheckedChanged(object sender, EventArgs e)
        {
            if (q20_10.Checked == true)
            {
                ViewState["rdo_val"] = q20_10.Text;
            }
            else
            {
                ViewState["rdo_val"] = null;
            }
        }

        protected void q20_12_CheckedChanged(object sender, EventArgs e)
        {
            if (q20_12.Checked == true)
            {
                ViewState["rdo_val"] = q20_12.Text;
            }
            else
            {
                ViewState["rdo_val"] = null;
            }
        }

        protected void q20_13_CheckedChanged(object sender, EventArgs e)
        {
            if (q20_13.Checked == true)
            {
                ViewState["rdo_val"] = q20_13.Text;
            }
            else
            {
                ViewState["rdo_val"] = null;
            }
        }

        protected void q20_14_CheckedChanged(object sender, EventArgs e)
        {
            if (q20_14.Checked == true)
            {
                ViewState["rdo_val"] = q20_14.Text;
            }
            else
            {
                ViewState["rdo_val"] = null;
            }
        }

        protected void q20_15_CheckedChanged(object sender, EventArgs e)
        {
            if (q20_15.Checked == true)
            {
                ViewState["rdo_val"] = q20_15.Text;
            }
            else
            {
                ViewState["rdo_val"] = null;
            }
        }

        protected void q20_16_CheckedChanged(object sender, EventArgs e)
        {
            if (q20_16.Checked == true)
            {
                ViewState["rdo_val"] = q20_16.Text;
            }
            else
            {
                ViewState["rdo_val"] = null;
            }
        }

        protected void q20_17_CheckedChanged(object sender, EventArgs e)
        {
            if (q20_17.Checked == true)
            {
                ViewState["rdo_val"] = q20_17.Text;
            }
            else
            {
                ViewState["rdo_val"] = null;
            }
        }

        protected void q20_18_CheckedChanged(object sender, EventArgs e)
        {
            if (q20_18.Checked == true)
            {
                ViewState["rdo_val"] = q20_18.Text;
            }
            else
            {
                ViewState["rdo_val"] = null;
            }
        }

        protected void q20_19_CheckedChanged(object sender, EventArgs e)
        {
            if (q20_19.Checked == true)
            {
                ViewState["rdo_val"] = q20_19.Text;
            }
            else
            {
                ViewState["rdo_val"] = null;
            }
        }

        protected void q20_20_CheckedChanged(object sender, EventArgs e)
        {
            if (q20_20.Checked == true)
            {
                ViewState["rdo_val"] = q20_20.Text;
            }
            else
            {
                ViewState["rdo_val"] = null;
            }
        }

        protected void q20_21_CheckedChanged(object sender, EventArgs e)
        {
            if (q20_21.Checked == true)
            {
                ViewState["rdo_val"] = q20_21.Text;
            }
            else
            {
                ViewState["rdo_val"] = null;
            }
        }

        protected void q20_22_CheckedChanged(object sender, EventArgs e)
        {
            if (q20_22.Checked == true)
            {
                ViewState["rdo_val"] = q20_22.Text;
            }
            else
            {
                ViewState["rdo_val"] = null;
            }
        }

        protected void q20_23_CheckedChanged(object sender, EventArgs e)
        {
            if (q20_23.Checked == true)
            {
                ViewState["rdo_val"] = q20_23.Text;
            }
            else
            {
                ViewState["rdo_val"] = null;
            }
        }

        protected void q20_24_CheckedChanged(object sender, EventArgs e)
        {
            if (q20_24.Checked == true)
            {
                ViewState["rdo_val"] = q20_24.Text;
            }
            else
            {
                ViewState["rdo_val"] = null;
            }
        }

        protected void q20_25_CheckedChanged(object sender, EventArgs e)
        {
            if (q20_25.Checked == true)
            {
                ViewState["rdo_val"] = q20_25.Text;
            }
            else
            {
                ViewState["rdo_val"] = null;
            }
        }

        protected void q20_26_CheckedChanged(object sender, EventArgs e)
        {
            if (q20_26.Checked == true)
            {
                ViewState["rdo_val"] = q20_26.Text;
            }
            else
            {
                ViewState["rdo_val"] = null;
            }
        }

        protected void q20_27_CheckedChanged(object sender, EventArgs e)
        {
            if (q20_27.Checked == true)
            {
                ViewState["rdo_val"] = q20_27.Text;
            }
            else
            {
                ViewState["rdo_val"] = null;
            }
        }

        protected void q20_28_CheckedChanged(object sender, EventArgs e)
        {
            if (q20_28.Checked == true)
            {
                ViewState["rdo_val"] = q20_28.Text;
            }
            else
            {
                ViewState["rdo_val"] = null;
            }
        }

        protected void q20_29_CheckedChanged(object sender, EventArgs e)
        {
            if (q20_29.Checked == true)
            {
                ViewState["rdo_val"] = q20_29.Text;
            }
            else
            {
                ViewState["rdo_val"] = null;
            }
        }

        protected void q20_30_CheckedChanged(object sender, EventArgs e)
        {
            if (q20_30.Checked == true)
            {
                ViewState["rdo_val"] = q20_30.Text;
            }
            else
            {
                ViewState["rdo_val"] = null;
            }
        }

        protected void q20_31_CheckedChanged(object sender, EventArgs e)
        {
            if (q20_31.Checked == true)
            {
                ViewState["rdo_val"] = q20_31.Text;
            }
            else
            {
                ViewState["rdo_val"] = null;
            }
        }

        protected void q20_32_CheckedChanged(object sender, EventArgs e)
        {
            if (q20_32.Checked == true)
            {
                ViewState["rdo_val"] = q20_32.Text;
            }
            else
            {
                ViewState["rdo_val"] = null;
            }
        }

        protected void q20_33_CheckedChanged(object sender, EventArgs e)
        {
            if (q20_33.Checked == true)
            {
                ViewState["rdo_val"] = q20_33.Text;
            }
            else
            {
                ViewState["rdo_val"] = null;
            }
        }

        protected void q20_34_CheckedChanged(object sender, EventArgs e)
        {
            if (q20_34.Checked == true)
            {
                ViewState["rdo_val"] = q20_34.Text;
            }
            else
            {
                ViewState["rdo_val"] = null;
            }
        }

        protected void q20_35_CheckedChanged(object sender, EventArgs e)
        {
            if (q20_35.Checked == true)
            {
                ViewState["rdo_val"] = q20_35.Text;
            }
            else
            {
                ViewState["rdo_val"] = null;
            }
        }

        protected void q20_36_CheckedChanged(object sender, EventArgs e)
        {
            if (q20_36.Checked == true)
            {
                ViewState["rdo_val"] = q20_36.Text;
            }
            else
            {
                ViewState["rdo_val"] = null;
            }
        }

        protected void q20_37_CheckedChanged(object sender, EventArgs e)
        {
            if (q20_37.Checked == true)
            {
                ViewState["rdo_val"] = q20_37.Text;
            }
            else
            {
                ViewState["rdo_val"] = null;
            }
        }

        protected void q20_38_CheckedChanged(object sender, EventArgs e)
        {
            if (q20_38.Checked == true)
            {
                ViewState["rdo_val"] = q20_38.Text;
            }
            else
            {
                ViewState["rdo_val"] = null;
            }
        }

        protected void q20_39_CheckedChanged(object sender, EventArgs e)
        {
            if (q20_39.Checked == true)
            {
                ViewState["rdo_val"] = q20_39.Text;
            }
            else
            {
                ViewState["rdo_val"] = null;
            }
        }

        protected void q23_1_CheckedChanged(object sender, EventArgs e)
        {
            if (q23_1.Checked == true)
            {
                ViewState["rdo_val1"] = q23_1.Text;
            }
            else
            {
                ViewState["rdo_val1"] = null;
            }
        }

        protected void q23_2_CheckedChanged(object sender, EventArgs e)
        {
            if (q23_2.Checked == true)
            {
                ViewState["rdo_val1"] = q23_2.Text;
            }
            else
            {
                ViewState["rdo_val1"] = null;
            }
        }

        protected void q23_3_CheckedChanged(object sender, EventArgs e)
        {
            if (q23_3.Checked == true)
            {
                ViewState["rdo_val1"] = q23_3.Text;
            }
            else
            {
                ViewState["rdo_val1"] = null;
            }
        }

        protected void q23_4_CheckedChanged(object sender, EventArgs e)
        {
            if (q23_4.Checked == true)
            {
                ViewState["rdo_val1"] = q23_4.Text;
            }
            else
            {
                ViewState["rdo_val1"] = null;
            }
        }

        protected void q23_5_CheckedChanged(object sender, EventArgs e)
        {
            if (q23_5.Checked == true)
            {
                ViewState["rdo_val1"] = q23_5.Text;
            }
            else
            {
                ViewState["rdo_val1"] = null;
            }
        }

        protected void q23_6_CheckedChanged(object sender, EventArgs e)
        {
            if (q23_6.Checked == true)
            {
                ViewState["rdo_val1"] = q23_6.Text;
            }
            else
            {
                ViewState["rdo_val1"] = null;
            }
        }

        protected void q23_7_CheckedChanged(object sender, EventArgs e)
        {
            if (q23_7.Checked == true)
            {
                ViewState["rdo_val1"] = q23_7.Text;
            }
            else
            {
                ViewState["rdo_val1"] = null;
            }
        }

        protected void q23_8_CheckedChanged(object sender, EventArgs e)
        {
            if (q23_8.Checked == true)
            {
                ViewState["rdo_val1"] = q23_8.Text;
            }
            else
            {
                ViewState["rdo_val1"] = null;
            }
        }

        protected void q23_9_CheckedChanged(object sender, EventArgs e)
        {
            if (q23_9.Checked == true)
            {
                ViewState["rdo_val1"] = q23_9.Text;
            }
            else
            {
                ViewState["rdo_val1"] = null;
            }
        }

        protected void q23_10_CheckedChanged(object sender, EventArgs e)
        {
            if (q23_10.Checked == true)
            {
                ViewState["rdo_val1"] = q23_10.Text;
            }
            else
            {
                ViewState["rdo_val1"] = null;
            }
        }

        protected void q23_11_CheckedChanged(object sender, EventArgs e)
        {
            if (q23_11.Checked == true)
            {
                ViewState["rdo_val1"] = q23_11.Text;
            }
            else
            {
                ViewState["rdo_val1"] = null;
            }
        }

        protected void q23_12_CheckedChanged(object sender, EventArgs e)
        {
            if (q23_12.Checked == true)
            {
                ViewState["rdo_val1"] = q23_12.Text;
            }
            else
            {
                ViewState["rdo_val1"] = null;
            }
        }

        protected void q23_13_CheckedChanged(object sender, EventArgs e)
        {
            if (q23_13.Checked == true)
            {
                ViewState["rdo_val1"] = q23_13.Text;
            }
            else
            {
                ViewState["rdo_val1"] = null;
            }
        }

        protected void q23_14_CheckedChanged(object sender, EventArgs e)
        {
            if (q23_14.Checked == true)
            {
                ViewState["rdo_val1"] = q23_14.Text;
            }
            else
            {
                ViewState["rdo_val1"] = null;
            }
        }

        protected void q23_15_CheckedChanged(object sender, EventArgs e)
        {
            if (q23_15.Checked == true)
            {
                ViewState["rdo_val1"] = q23_15.Text;
            }
            else
            {
                ViewState["rdo_val1"] = null;
            }
        }

        protected void q23_16_CheckedChanged(object sender, EventArgs e)
        {
            if (q23_16.Checked == true)
            {
                ViewState["rdo_val1"] = q23_16.Text;
            }
            else
            {
                ViewState["rdo_val1"] = null;
            }
        }

        protected void q23_17_CheckedChanged(object sender, EventArgs e)
        {
            if (q23_17.Checked == true)
            {
                ViewState["rdo_val1"] = q23_17.Text;
            }
            else
            {
                ViewState["rdo_val1"] = null;
            }
        }

        protected void q23_18_CheckedChanged(object sender, EventArgs e)
        {
            if (q23_18.Checked == true)
            {
                ViewState["rdo_val1"] = q23_18.Text;
            }
            else
            {
                ViewState["rdo_val1"] = null;
            }
        }

        protected void q23_19_CheckedChanged(object sender, EventArgs e)
        {
            if (q23_19.Checked == true)
            {
                ViewState["rdo_val1"] = q23_19.Text;
            }
            else
            {
                ViewState["rdo_val1"] = null;
            }
        }

        protected void q23_20_CheckedChanged(object sender, EventArgs e)
        {
            if (q23_20.Checked == true)
            {
                ViewState["rdo_val1"] = q23_20.Text;
            }
            else
            {
                ViewState["rdo_val1"] = null;
            }
        }

        protected void q23_21_CheckedChanged(object sender, EventArgs e)
        {
            if (q23_21.Checked == true)
            {
                ViewState["rdo_val1"] = q23_21.Text;
            }
            else
            {
                ViewState["rdo_val1"] = null;
            }
        }

        protected void q23_22_CheckedChanged(object sender, EventArgs e)
        {
            if (q23_22.Checked == true)
            {
                ViewState["rdo_val1"] = q23_22.Text;
            }
            else
            {
                ViewState["rdo_val1"] = null;
            }
        }

        protected void q23_23_CheckedChanged(object sender, EventArgs e)
        {
            if (q23_23.Checked == true)
            {
                ViewState["rdo_val1"] = q23_23.Text;
            }
            else
            {
                ViewState["rdo_val1"] = null;
            }
        }

        protected void q23_24_CheckedChanged(object sender, EventArgs e)
        {
            if (q23_24.Checked == true)
            {
                ViewState["rdo_val1"] = q23_24.Text;
            }
            else
            {
                ViewState["rdo_val1"] = null;
            }
        }

        protected void q23_25_CheckedChanged(object sender, EventArgs e)
        {
            if (q23_25.Checked == true)
            {
                ViewState["rdo_val1"] = q23_25.Text;
            }
            else
            {
                ViewState["rdo_val1"] = null;
            }
        }

        protected void q23_26_CheckedChanged(object sender, EventArgs e)
        {
            if (q23_26.Checked == true)
            {
                ViewState["rdo_val1"] = q23_26.Text;
            }
            else
            {
                ViewState["rdo_val1"] = null;
            }
        }

        protected void q23_27_CheckedChanged(object sender, EventArgs e)
        {
            if (q23_27.Checked == true)
            {
                ViewState["rdo_val1"] = q23_27.Text;
            }
            else
            {
                ViewState["rdo_val1"] = null;
            }
        }

        protected void q23_28_CheckedChanged(object sender, EventArgs e)
        {
            if (q23_28.Checked == true)
            {
                ViewState["rdo_val1"] = q23_28.Text;
            }
            else
            {
                ViewState["rdo_val1"] = null;
            }
        }

        protected void q23_29_CheckedChanged(object sender, EventArgs e)
        {
            if (q23_29.Checked == true)
            {
                ViewState["rdo_val1"] = q23_29.Text;
            }
            else
            {
                ViewState["rdo_val1"] = null;
            }
        }

        protected void q23_30_CheckedChanged(object sender, EventArgs e)
        {
            if (q23_30.Checked == true)
            {
                ViewState["rdo_val1"] = q23_30.Text;
            }
            else
            {
                ViewState["rdo_val1"] = null;
            }
        }

        protected void q23_31_CheckedChanged(object sender, EventArgs e)
        {
            if (q23_31.Checked == true)
            {
                ViewState["rdo_val1"] = q23_31.Text;
            }
            else
            {
                ViewState["rdo_val1"] = null;
            }
        }

        protected void q23_32_CheckedChanged(object sender, EventArgs e)
        {
            if (q23_32.Checked == true)
            {
                ViewState["rdo_val1"] = q23_32.Text;
            }
            else
            {
                ViewState["rdo_val1"] = null;
            }
        }

        protected void q23_33_CheckedChanged(object sender, EventArgs e)
        {
            if (q23_33.Checked == true)
            {
                ViewState["rdo_val1"] = q23_33.Text;
            }
            else
            {
                ViewState["rdo_val1"] = null;
            }
        }

        protected void q23_34_CheckedChanged(object sender, EventArgs e)
        {
            if (q23_34.Checked == true)
            {
                ViewState["rdo_val1"] = q23_34.Text;
            }
            else
            {
                ViewState["rdo_val1"] = null;
            }
        }

        protected void q23_35_CheckedChanged(object sender, EventArgs e)
        {
            if (q23_35.Checked == true)
            {
                ViewState["rdo_val1"] = q23_35.Text;
            }
            else
            {
                ViewState["rdo_val1"] = null;
            }
        }

        protected void q23_36_CheckedChanged(object sender, EventArgs e)
        {
            if (q23_36.Checked == true)
            {
                ViewState["rdo_val1"] = q23_36.Text;
            }
            else
            {
                ViewState["rdo_val1"] = null;
            }
        }

        protected void q23_37_CheckedChanged(object sender, EventArgs e)
        {
            if (q23_37.Checked == true)
            {
                ViewState["rdo_val1"] = q23_37.Text;
            }
            else
            {
                ViewState["rdo_val1"] = null;
            }
        }

        protected void q23_38_CheckedChanged(object sender, EventArgs e)
        {
            if (q23_38.Checked == true)
            {
                ViewState["rdo_val1"] = q23_38.Text;
            }
            else
            {
                ViewState["rdo_val1"] = null;
            }
        }

        protected void q23_39_CheckedChanged(object sender, EventArgs e)
        {
            if (q23_39.Checked == true)
            {
                ViewState["rdo_val1"] = q23_39.Text;
            }
            else
            {
                ViewState["rdo_val1"] = null;
            }
        }

        protected void q20_40_CheckedChanged(object sender, EventArgs e)
        {
            if (q20_40.Checked == true)
            {
                ViewState["rdo_val1"] = q20_40.Text;
            }
            else
            {
                ViewState["rdo_val1"] = null;
            }
        }

        protected void q23_40_CheckedChanged(object sender, EventArgs e)
        {
            if (q23_40.Checked == true)
            {
                ViewState["rdo_val1"] = q23_40.Text;
            }
            else
            {
                ViewState["rdo_val1"] = null;
            }
        }

        protected void q23_10a_CheckedChanged(object sender, EventArgs e)
        {
            if (q23_10a.Checked == true)
            {
                ViewState["rdo_val1"] = q23_10a.Text;
            }
            else
            {
                ViewState["rdo_val1"] = null;
            }
        }

        protected void q23_20a_CheckedChanged(object sender, EventArgs e)
        {
            if (q23_20a.Checked == true)
            {
                ViewState["rdo_val1"] = q23_20a.Text;
            }
            else
            {
                ViewState["rdo_val1"] = null;
            }
        }

        protected void q23_30a_CheckedChanged(object sender, EventArgs e)
        {
            if (q23_30a.Checked == true)
            {
                ViewState["rdo_val1"] = q23_30a.Text;
            }
            else
            {
                ViewState["rdo_val1"] = null;
            }
        }

        protected void q23_40a_CheckedChanged(object sender, EventArgs e)
        {
            if (q23_40a.Checked == true)
            {
                ViewState["rdo_val1"] = q23_40a.Text;
            }
            else
            {
                ViewState["rdo_val1"] = null;
            }
        }

        protected void q15c1_1_CheckedChanged(object sender, EventArgs e)
        {
            if (q15c1_1.Checked == true)
            {
                CVariables.Store_Q15c1 = "1_" + q15c1_1.ID;
            }
            else
            {
                CVariables.Store_Q15c1 = null;
            }
        }

        protected void q15c1_2_CheckedChanged(object sender, EventArgs e)
        {
            if (q15c1_2.Checked == true)
            {
                CVariables.Store_Q15c1 = "2_" + q15c1_2.ID;
            }
            else
            {
                CVariables.Store_Q15c1 = null;
            }
        }

        protected void q15c1_3_CheckedChanged(object sender, EventArgs e)
        {
            if (q15c1_3.Checked == true)
            {
                CVariables.Store_Q15c1 = "3_" + q15c1_3.ID;
            }
            else
            {
                CVariables.Store_Q15c1 = null;
            }
        }

        protected void q15c2_111_CheckedChanged(object sender, EventArgs e)
        {
            if (q15c2_111.Checked == true)
            {
                CVariables.Store_Q15c2 = "1_" + q15c2_111.ID;
            }
            else
            {
                CVariables.Store_Q15c2 = null;
            }
        }

        protected void q15c2_112_CheckedChanged(object sender, EventArgs e)
        {
            if (q15c2_112.Checked == true)
            {
                CVariables.Store_Q15c2 = "2_" + q15c2_112.ID;
            }
            else
            {
                CVariables.Store_Q15c2 = null;
            }
        }

        protected void q15c2_113_CheckedChanged(object sender, EventArgs e)
        {
            if (q15c2_113.Checked == true)
            {
                CVariables.Store_Q15c2 = "3_" + q15c2_113.ID;
            }
            else
            {
                CVariables.Store_Q15c2 = null;
            }
        }

        protected void q15c3_120_CheckedChanged(object sender, EventArgs e)
        {
            if (q15c3_120.Checked == true)
            {
                CVariables.Store_Q15c3 = "1_" + q15c3_120.ID;
            }
            else
            {
                CVariables.Store_Q15c3 = null;
            }
        }

        protected void q15c3_121_CheckedChanged(object sender, EventArgs e)
        {
            if (q15c3_121.Checked == true)
            {
                CVariables.Store_Q15c3 = "2_" + q15c3_121.ID;
            }
            else
            {
                CVariables.Store_Q15c3 = null;
            }
        }

        protected void q15c3_122_CheckedChanged(object sender, EventArgs e)
        {
            if (q15c3_122.Checked == true)
            {
                CVariables.Store_Q15c3 = "3_" + q15c3_122.ID;
            }
            else
            {
                CVariables.Store_Q15c3 = null;
            }
        }

        protected void q15c4_130_CheckedChanged(object sender, EventArgs e)
        {
            if (q15c4_130.Checked == true)
            {
                CVariables.Store_Q15c4 = "1_" + q15c4_130.ID;
            }
            else
            {
                CVariables.Store_Q15c4 = null;
            }
        }

        protected void q15c4_131_CheckedChanged(object sender, EventArgs e)
        {
            if (q15c4_131.Checked == true)
            {
                CVariables.Store_Q15c4 = "2_" + q15c4_131.ID;
            }
            else
            {
                CVariables.Store_Q15c4 = null;
            }
        }

        protected void q15c4_132_CheckedChanged(object sender, EventArgs e)
        {
            if (q15c4_132.Checked == true)
            {
                CVariables.Store_Q15c4 = "3_" + q15c4_132.ID;
            }
            else
            {
                CVariables.Store_Q15c4 = null;
            }
        }

        protected void q15c5_140_CheckedChanged(object sender, EventArgs e)
        {
            if (q15c5_140.Checked == true)
            {
                CVariables.Store_Q15c5 = "1_" + q15c5_140.ID;
            }
            else
            {
                CVariables.Store_Q15c5 = null;
            }
        }

        protected void q15c5_141_CheckedChanged(object sender, EventArgs e)
        {
            if (q15c5_141.Checked == true)
            {
                CVariables.Store_Q15c5 = "2_" + q15c5_141.ID;
            }
            else
            {
                CVariables.Store_Q15c5 = null;
            }
        }

        protected void q15c5_142_CheckedChanged(object sender, EventArgs e)
        {
            if (q15c5_142.Checked == true)
            {
                CVariables.Store_Q15c5 = "3_" + q15c5_142.ID;
            }
            else
            {
                CVariables.Store_Q15c5 = null;
            }
        }

        protected void q15c6_150_CheckedChanged(object sender, EventArgs e)
        {
            if (q15c6_150.Checked == true)
            {
                CVariables.Store_Q15c6 = "1_" + q15c6_150.ID;
            }
            else
            {
                CVariables.Store_Q15c6 = null;
            }
        }

        protected void q15c6_151_CheckedChanged(object sender, EventArgs e)
        {
            if (q15c6_151.Checked == true)
            {
                CVariables.Store_Q15c6 = "2_" + q15c6_151.ID;
            }
            else
            {
                CVariables.Store_Q15c6 = null;
            }
        }

        protected void q15c6_152_CheckedChanged(object sender, EventArgs e)
        {
            if (q15c6_152.Checked == true)
            {
                CVariables.Store_Q15c6 = "3_" + q15c6_152.ID;
            }
            else
            {
                CVariables.Store_Q15c6 = null;
            }
        }

        protected void q15c7_160_CheckedChanged(object sender, EventArgs e)
        {
            if (q15c7_160.Checked == true)
            {
                CVariables.Store_Q15c7 = "1_" + q15c7_160.ID;
            }
            else
            {
                CVariables.Store_Q15c7 = null;
            }
        }

        protected void q15c7_161_CheckedChanged(object sender, EventArgs e)
        {
            if (q15c7_161.Checked == true)
            {
                CVariables.Store_Q15c7 = "2_" + q15c7_161.ID;
            }
            else
            {
                CVariables.Store_Q15c7 = null;
            }
        }

        protected void q15c7_162_CheckedChanged(object sender, EventArgs e)
        {
            if (q15c7_162.Checked == true)
            {
                CVariables.Store_Q15c7 = "3_" + q15c7_162.ID;
            }
            else
            {
                CVariables.Store_Q15c7 = null;
            }
        }

        protected void q16c1_170_CheckedChanged(object sender, EventArgs e)
        {
            if (q16c1_170.Checked == true)
            {
                CVariables.Store_Q16c1 = "1_" + q16c1_170.ID;
            }
            else
            {
                CVariables.Store_Q16c1 = null;
            }
        }

        protected void q16c1_171_CheckedChanged(object sender, EventArgs e)
        {
            if (q16c1_171.Checked == true)
            {
                CVariables.Store_Q16c1 = "2_" + q16c1_171.ID;
            }
            else
            {
                CVariables.Store_Q16c1 = null;
            }
        }

        protected void q16c1_172_CheckedChanged(object sender, EventArgs e)
        {
            if (q16c1_172.Checked == true)
            {
                CVariables.Store_Q16c1 = "3_" + q16c1_172.ID;
            }
            else
            {
                CVariables.Store_Q16c1 = null;
            }
        }

        protected void q16c2_180_CheckedChanged(object sender, EventArgs e)
        {
            if (q16c2_180.Checked == true)
            {
                CVariables.Store_Q16c2 = "1_" + q16c2_180.ID;
            }
            else
            {
                CVariables.Store_Q16c2 = null;
            }
        }

        protected void q16c2_181_CheckedChanged(object sender, EventArgs e)
        {
            if (q16c2_181.Checked == true)
            {
                CVariables.Store_Q16c2 = "2_" + q16c2_181.ID;
            }
            else
            {
                CVariables.Store_Q16c2 = null;
            }
        }

        protected void q16c2_182_CheckedChanged(object sender, EventArgs e)
        {
            if (q16c2_182.Checked == true)
            {
                CVariables.Store_Q16c2 = "3_" + q16c2_182.ID;
            }
            else
            {
                CVariables.Store_Q16c2 = null;
            }
        }

        protected void q16c3_190_CheckedChanged(object sender, EventArgs e)
        {
            if (q16c3_190.Checked == true)
            {
                CVariables.Store_Q16c3 = "1_" + q16c3_190.ID;
            }
            else
            {
                CVariables.Store_Q16c3 = null;
            }
        }

        protected void q16c3_191_CheckedChanged(object sender, EventArgs e)
        {
            if (q16c3_191.Checked == true)
            {
                CVariables.Store_Q16c3 = "2_" + q16c3_191.ID;
            }
            else
            {
                CVariables.Store_Q16c3 = null;
            }
        }

        protected void q16c3_192_CheckedChanged(object sender, EventArgs e)
        {
            if (q16c3_192.Checked == true)
            {
                CVariables.Store_Q16c3 = "3_" + q16c3_192.ID;
            }
            else
            {
                CVariables.Store_Q16c3 = null;
            }
        }

        protected void q17c1_200_CheckedChanged(object sender, EventArgs e)
        {
            if (q17c1_200.Checked == true)
            {
                CVariables.Store_Q17c1 = "1_" + q17c1_200.ID;
            }
            else
            {
                CVariables.Store_Q17c1 = null;
            }
        }

        protected void q17c1_201_CheckedChanged(object sender, EventArgs e)
        {
            if (q17c1_201.Checked == true)
            {
                CVariables.Store_Q17c1 = "2_" + q17c1_201.ID;
            }
            else
            {
                CVariables.Store_Q17c1 = null;
            }
        }

        protected void q17c1_202_CheckedChanged(object sender, EventArgs e)
        {
            if (q17c1_202.Checked == true)
            {
                CVariables.Store_Q17c1 = "3_" + q17c1_202.ID;
            }
            else
            {
                CVariables.Store_Q17c1 = null;
            }
        }

        protected void q17c2_300_CheckedChanged(object sender, EventArgs e)
        {
            if (q17c2_300.Checked == true)
            {
                CVariables.Store_Q17c2 = "1_" + q17c2_300.ID;
            }
            else
            {
                CVariables.Store_Q17c2 = null;
            }
        }

        protected void q17c2_301_CheckedChanged(object sender, EventArgs e)
        {
            if (q17c2_301.Checked == true)
            {
                CVariables.Store_Q17c2 = "2_" + q17c2_301.ID;
            }
            else
            {
                CVariables.Store_Q17c2 = null;
            }
        }

        protected void q17c2_302_CheckedChanged(object sender, EventArgs e)
        {
            if (q17c2_302.Checked == true)
            {
                CVariables.Store_Q17c2 = "3_" + q17c2_302.ID;
            }
            else
            {
                CVariables.Store_Q17c2 = null;
            }
        }

        protected void q17c3_303_CheckedChanged(object sender, EventArgs e)
        {
            if (q17c3_303.Checked == true)
            {
                CVariables.Store_Q17c3 = "1_" + q17c3_303.ID;
            }
            else
            {
                CVariables.Store_Q17c3 = null;
            }
        }

        protected void q17c3_304_CheckedChanged(object sender, EventArgs e)
        {
            if (q17c3_304.Checked == true)
            {
                CVariables.Store_Q17c3 = "2_" + q17c3_304.ID;
            }
            else
            {
                CVariables.Store_Q17c3 = null;
            }
        }

        protected void q17c3_305_CheckedChanged(object sender, EventArgs e)
        {
            if (q17c3_305.Checked == true)
            {
                CVariables.Store_Q17c3 = "3_" + q17c3_305.ID;
            }
            else
            {
                CVariables.Store_Q17c3 = null;
            }
        }

        protected void q17c4_306_CheckedChanged(object sender, EventArgs e)
        {
            if (q17c4_306.Checked == true)
            {
                CVariables.Store_Q17c4 = "1_" + q17c4_306.ID;
            }
            else
            {
                CVariables.Store_Q17c4 = null;
            }
        }

        protected void q17c4_307_CheckedChanged(object sender, EventArgs e)
        {
            if (q17c4_307.Checked == true)
            {
                CVariables.Store_Q17c4 = "2_" + q17c4_307.ID;
            }
            else
            {
                CVariables.Store_Q17c4 = null;
            }
        }

        protected void q17c4_308_CheckedChanged(object sender, EventArgs e)
        {
            if (q17c4_308.Checked == true)
            {
                CVariables.Store_Q17c4 = "3_" + q17c4_308.ID;
            }
            else
            {
                CVariables.Store_Q17c4 = null;
            }
        }

        protected void q17c5_309_CheckedChanged(object sender, EventArgs e)
        {
            if (q17c5_309.Checked == true)
            {
                CVariables.Store_Q17c5 = "1_" + q17c5_309.ID;
            }
            else
            {
                CVariables.Store_Q17c5 = null;
            }
        }

        protected void q17c5_400_CheckedChanged(object sender, EventArgs e)
        {
            if (q17c5_400.Checked == true)
            {
                CVariables.Store_Q17c5 = "2_" + q17c5_400.ID;
            }
            else
            {
                CVariables.Store_Q17c5 = null;
            }
        }

        protected void q17c5_401_CheckedChanged(object sender, EventArgs e)
        {
            if (q17c5_401.Checked == true)
            {
                CVariables.Store_Q17c5 = "3_" + q17c5_401.ID;
            }
            else
            {
                CVariables.Store_Q17c5 = null;
            }
        }

        protected void q17c6_402_CheckedChanged(object sender, EventArgs e)
        {
            if (q17c6_402.Checked == true)
            {
                CVariables.Store_Q17c6 = "1_" + q17c6_402.ID;
            }
            else
            {
                CVariables.Store_Q17c6 = null;
            }
        }

        protected void q17c6_403_CheckedChanged(object sender, EventArgs e)
        {
            if (q17c6_403.Checked == true)
            {
                CVariables.Store_Q17c6 = "2_" + q17c6_403.ID;
            }
            else
            {
                CVariables.Store_Q17c6 = null;
            }
        }

        protected void q17c6_404_CheckedChanged(object sender, EventArgs e)
        {
            if (q17c6_404.Checked == true)
            {
                CVariables.Store_Q17c6 = "3_" + q17c6_404.ID;
            }
            else
            {
                CVariables.Store_Q17c6 = null;
            }
        }

        protected void q17c7_405_CheckedChanged(object sender, EventArgs e)
        {
            if (q17c7_405.Checked == true)
            {
                CVariables.Store_Q17c7 = "1_" + q17c7_405.ID;
            }
            else
            {
                CVariables.Store_Q17c7 = null;
            }
        }

        protected void q17c7_406_CheckedChanged(object sender, EventArgs e)
        {
            if (q17c7_406.Checked == true)
            {
                CVariables.Store_Q17c7 = "2_" + q17c7_406.ID;
            }
            else
            {
                CVariables.Store_Q17c7 = null;
            }
        }

        protected void q17c7_407_CheckedChanged(object sender, EventArgs e)
        {
            if (q17c7_407.Checked == true)
            {
                CVariables.Store_Q17c7 = "3_" + q17c7_407.ID;
            }
            else
            {
                CVariables.Store_Q17c7 = null;
            }
        }

        protected void q17c8_408_CheckedChanged(object sender, EventArgs e)
        {
            if (q17c8_408.Checked == true)
            {
                CVariables.Store_Q17c8 = "1_" + q17c8_408.ID;
            }
            else
            {
                CVariables.Store_Q17c8 = null;
            }
        }

        protected void q17c8_409_CheckedChanged(object sender, EventArgs e)
        {
            if (q17c8_409.Checked == true)
            {
                CVariables.Store_Q17c8 = "2_" + q17c8_409.ID;
            }
            else
            {
                CVariables.Store_Q17c8 = null;
            }
        }

        protected void q17c8_410_CheckedChanged(object sender, EventArgs e)
        {
            if (q17c8_410.Checked == true)
            {
                CVariables.Store_Q17c8 = "3_" + q17c8_410.ID;
            }
            else
            {
                CVariables.Store_Q17c8 = null;
            }
        }

        protected void q17c9_411_CheckedChanged(object sender, EventArgs e)
        {
            if (q17c9_411.Checked == true)
            {
                CVariables.Store_Q17c9 = "1_" + q17c9_411.ID;
            }
            else
            {
                CVariables.Store_Q17c9 = null;
            }
        }

        protected void q17c9_412_CheckedChanged(object sender, EventArgs e)
        {
            if (q17c9_412.Checked == true)
            {
                CVariables.Store_Q17c9 = "2_" + q17c9_412.ID;
            }
            else
            {
                CVariables.Store_Q17c9 = null;
            }
        }

        protected void q17c9_413_CheckedChanged(object sender, EventArgs e)
        {
            if (q17c9_413.Checked == true)
            {
                CVariables.Store_Q17c9 = "3_" + q17c9_413.ID;
            }
            else
            {
                CVariables.Store_Q17c9 = null;
            }
        }

        protected void q17c10_414_CheckedChanged(object sender, EventArgs e)
        {
            if (q17c10_414.Checked == true)
            {
                CVariables.Store_Q17c10 = "1_" + q17c10_414.ID;
            }
            else
            {
                CVariables.Store_Q17c10 = null;
            }
        }

        protected void q17c10_415_CheckedChanged(object sender, EventArgs e)
        {
            if (q17c10_415.Checked == true)
            {
                CVariables.Store_Q17c10 = "2_" + q17c10_415.ID;
            }
            else
            {
                CVariables.Store_Q17c10 = null;
            }
        }

        protected void q17c10_416_CheckedChanged(object sender, EventArgs e)
        {
            if (q17c10_416.Checked == true)
            {
                CVariables.Store_Q17c10 = "3_" + q17c10_416.ID;
            }
            else
            {
                CVariables.Store_Q17c10 = null;
            }
        }

        protected void q17c11_417_CheckedChanged(object sender, EventArgs e)
        {
            if (q17c11_417.Checked == true)
            {
                CVariables.Store_Q17c11 = "1_" + q17c11_417.ID;
            }
            else
            {
                CVariables.Store_Q17c11 = null;
            }
        }

        protected void q17c11_418_CheckedChanged(object sender, EventArgs e)
        {
            if (q17c11_418.Checked == true)
            {
                CVariables.Store_Q17c11 = "2_" + q17c11_418.ID;
            }
            else
            {
                CVariables.Store_Q17c11 = null;
            }
        }

        protected void q17c11_419_CheckedChanged(object sender, EventArgs e)
        {
            if (q17c11_419.Checked == true)
            {
                CVariables.Store_Q17c11 = "3_" + q17c11_419.ID;
            }
            else
            {
                CVariables.Store_Q17c11 = null;
            }
        }

        protected void q18c1_420_CheckedChanged(object sender, EventArgs e)
        {
            if (q18c1_420.Checked == true)
            {
                CVariables.Store_Q18c1 = "1_" + q18c1_420.ID;
            }
            else
            {
                CVariables.Store_Q18c1 = null;
            }
        }

        protected void q18c1_421_CheckedChanged(object sender, EventArgs e)
        {
            if (q18c1_421.Checked == true)
            {
                CVariables.Store_Q18c1 = "2_" + q18c1_421.ID;
            }
            else
            {
                CVariables.Store_Q18c1 = null;
            }
        }

        protected void q18c1_422_CheckedChanged(object sender, EventArgs e)
        {
            if (q18c1_422.Checked == true)
            {
                CVariables.Store_Q18c1 = "3_" + q18c1_422.ID;
            }
            else
            {
                CVariables.Store_Q18c1 = null;
            }
        }

        protected void q12_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (q12.SelectedValue == "1")
            {
                Q12_Enable();
            }
            else
            {
                Q12_Disable();
            }
        }


        private void Q12_Enable()
        {
            EnableControls(q13);
            EnableControls(q14);
            EnableControls(q15a1);
            EnableControls(q15c1_1);
            EnableControls(q15c1_2);
            EnableControls(q15c1_3);

            EnableControls(q15a2);
            EnableControls(q15c2_111);
            EnableControls(q15c2_112);
            EnableControls(q15c2_113);

            EnableControls(q15a3);
            EnableControls(q15c3_120);
            EnableControls(q15c3_121);
            EnableControls(q15c3_122);

            EnableControls(q15a4);
            EnableControls(q15c4_130);
            EnableControls(q15c4_131);
            EnableControls(q15c4_132);

            EnableControls(q15a5);
            EnableControls(q15c5_140);
            EnableControls(q15c5_141);
            EnableControls(q15c5_142);

            EnableControls(q15a6);
            EnableControls(q15c6_150);
            EnableControls(q15c6_151);
            EnableControls(q15c6_152);

            EnableControls(q15a7);
            EnableControls(q15c7_160);
            EnableControls(q15c7_161);
            EnableControls(q15c7_162);

            EnableControls(q16signa1);
            EnableControls(q16a1);
            EnableControls(q16c1_170);
            EnableControls(q16c1_171);
            EnableControls(q16c1_172);

            EnableControls(q16signa2);
            EnableControls(q16a2);
            EnableControls(q16c2_180);
            EnableControls(q16c2_181);
            EnableControls(q16c2_182);

            EnableControls(q16signa3);
            EnableControls(q16a3);
            EnableControls(q16c3_190);
            EnableControls(q16c3_191);
            EnableControls(q16c3_192);
        }


        private void Q12_Disable()
        {
            DisableControls(q13);
            DisableControls(q14);
            DisableControls(q15a1);
            DisableControls(q15c1_1);
            DisableControls(q15c1_2);
            DisableControls(q15c1_3);

            DisableControls(q15a2);
            DisableControls(q15c2_111);
            DisableControls(q15c2_112);
            DisableControls(q15c2_113);

            DisableControls(q15a3);
            DisableControls(q15c3_120);
            DisableControls(q15c3_121);
            DisableControls(q15c3_122);

            DisableControls(q15a4);
            DisableControls(q15c4_130);
            DisableControls(q15c4_131);
            DisableControls(q15c4_132);

            DisableControls(q15a5);
            DisableControls(q15c5_140);
            DisableControls(q15c5_141);
            DisableControls(q15c5_142);

            DisableControls(q15a6);
            DisableControls(q15c6_150);
            DisableControls(q15c6_151);
            DisableControls(q15c6_152);

            DisableControls(q15a7);
            DisableControls(q15c7_160);
            DisableControls(q15c7_161);
            DisableControls(q15c7_162);

            DisableControls(q16signa1);
            DisableControls(q16a1);
            DisableControls(q16c1_170);
            DisableControls(q16c1_171);
            DisableControls(q16c1_172);

            DisableControls(q16signa2);
            DisableControls(q16a2);
            DisableControls(q16c2_180);
            DisableControls(q16c2_181);
            DisableControls(q16c2_182);

            DisableControls(q16signa3);
            DisableControls(q16a3);
            DisableControls(q16c3_190);
            DisableControls(q16c3_191);
            DisableControls(q16c3_192);
        }

        protected void q16c_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (q16c.SelectedValue == "1")
            {
                Q16c_Enable();
            }
            else
            {
                Q16c_Disable();
            }
        }


        private void Q16c_Enable()
        {
            EnableControls(q17a1);
            EnableControls(q17c1_200);
            EnableControls(q17c1_201);
            EnableControls(q17c1_202);

            EnableControls(q17a2);
            EnableControls(q17c2_300);
            EnableControls(q17c2_301);
            EnableControls(q17c2_302);

            EnableControls(q17a99);
            EnableControls(q17c3_303);
            EnableControls(q17c3_304);
            EnableControls(q17c3_305);

            EnableControls(q17a3);
            EnableControls(q17c4_306);
            EnableControls(q17c4_307);
            EnableControls(q17c4_308);

            EnableControls(q17a4);
            EnableControls(q17c5_309);
            EnableControls(q17c5_400);
            EnableControls(q17c5_401);

            EnableControls(q17a5);
            EnableControls(q17c6_402);
            EnableControls(q17c6_403);
            EnableControls(q17c6_404);

            EnableControls(q17a6);
            EnableControls(q17c7_405);
            EnableControls(q17c7_406);
            EnableControls(q17c7_407);

            EnableControls(q17a7);
            EnableControls(q17c8_408);
            EnableControls(q17c8_409);
            EnableControls(q17c8_410);

            EnableControls(q17a8);
            EnableControls(q17c9_411);
            EnableControls(q17c9_412);
            EnableControls(q17c9_413);

            EnableControls(q17a9);
            EnableControls(q17c10_414);
            EnableControls(q17c10_415);
            EnableControls(q17c10_416);

            EnableControls(q17a10);
            EnableControls(q17c11_417);
            EnableControls(q17c11_418);
            EnableControls(q17c11_419);

            EnableControls(q18signa1);
            EnableControls(q18a1);
            EnableControls(q18c1_420);
            EnableControls(q18c1_421);
            EnableControls(q18c1_422);
        }



        private void Q16c_Disable()
        {
            DisableControls(q17a1);
            DisableControls(q17c1_200);
            DisableControls(q17c1_201);
            DisableControls(q17c1_202);

            DisableControls(q17a2);
            DisableControls(q17c2_300);
            DisableControls(q17c2_301);
            DisableControls(q17c2_302);

            DisableControls(q17a99);
            DisableControls(q17c3_303);
            DisableControls(q17c3_304);
            DisableControls(q17c3_305);

            DisableControls(q17a3);
            DisableControls(q17c4_306);
            DisableControls(q17c4_307);
            DisableControls(q17c4_308);

            DisableControls(q17a4);
            DisableControls(q17c5_309);
            DisableControls(q17c5_400);
            DisableControls(q17c5_401);

            DisableControls(q17a5);
            DisableControls(q17c6_402);
            DisableControls(q17c6_403);
            DisableControls(q17c6_404);

            DisableControls(q17a6);
            DisableControls(q17c7_405);
            DisableControls(q17c7_406);
            DisableControls(q17c7_407);

            DisableControls(q17a7);
            DisableControls(q17c8_408);
            DisableControls(q17c8_409);
            DisableControls(q17c8_410);

            DisableControls(q17a8);
            DisableControls(q17c9_411);
            DisableControls(q17c9_412);
            DisableControls(q17c9_413);

            DisableControls(q17a9);
            DisableControls(q17c10_414);
            DisableControls(q17c10_415);
            DisableControls(q17c10_416);

            DisableControls(q17a10);
            DisableControls(q17c11_417);
            DisableControls(q17c11_418);
            DisableControls(q17c11_419);

            DisableControls(q18signa1);
            DisableControls(q18a1);
            DisableControls(q18c1_420);
            DisableControls(q18c1_421);
            DisableControls(q18c1_422);
        }



        private bool IsValid()
        {
            CDBOperations obj_op = new CDBOperations();

            if (Session["mycookierole"].ToString() == "mdl")
            {
                return true;
            }


            try
            {
                if (obj_op.Validate_Dictionary_SpecialCode("0", "sp_ValidateDictionary", " select * from dict where tabname = 'sample_entry' and var_id = 'q15a1'", q15a1.Text, lblerr) == true)
                {
                    if (q15a1.Enabled == true)
                    {
                        q15a1.Focus();
                        return false;
                    }
                }
                else
                {
                    if (Convert.ToInt32(q15a1.Text) >= 21 && q15a1.Text != "99" && q15c1_1.Checked == false)
                    {
                        lblerr.Text = "if Chloramphenicol (30 µg) >= 21 it must be sensitive ";
                        lblerr.CssClass = "message-error";
                        q15a1.Focus();
                        return false;
                    }
                    else if (Convert.ToInt32(q15a1.Text) == 99 && q15c1_2.Checked == false)
                    {
                        lblerr.Text = "if Chloramphenicol (30 µg) = 99 it must be intermediate ";
                        lblerr.CssClass = "message-error";
                        q15a1.Focus();
                        return false;
                    }
                    else if (Convert.ToInt32(q15a1.Text) <= 20 && q15c1_3.Checked == false)
                    {
                        lblerr.Text = "if Chloramphenicol (30 µg) <= 20 it must be resistant ";
                        lblerr.CssClass = "message-error";
                        q15a1.Focus();
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                lblerr.Text = ex.Message;
            }





            try
            {
                if (obj_op.Validate_Dictionary_SpecialCode("0", "sp_ValidateDictionary", " select * from dict where tabname = 'sample_entry' and var_id = 'q15a2'", q15a2.Text, lblerr) == true)
                {
                    if (q15a2.Enabled == true)
                    {
                        q15a2.Focus();
                        return false;
                    }
                }
                else
                {
                    if (Convert.ToInt32(q15a2.Text) >= 21 && q15c2_111.Checked == false)
                    {
                        lblerr.Text = "if Erythromycin (15 µg) >= 21 it must be sensitive ";
                        lblerr.CssClass = "message-error";
                        q15a2.Focus();
                        return false;
                    }
                    else if (Convert.ToInt32(q15a2.Text) >= 16 && Convert.ToInt32(q15a2.Text) <= 20 && q15c2_112.Checked == false)
                    {
                        lblerr.Text = "if Erythromycin (15 µg) >= 16 or <= 20 it must be intermediate ";
                        lblerr.CssClass = "message-error";
                        q15a2.Focus();
                        return false;
                    }
                    else if (Convert.ToInt32(q15a2.Text) <= 15 && q15c2_113.Checked == false)
                    {
                        lblerr.Text = "if Erythromycin (15 µg) <= 15 it must be resistant ";
                        lblerr.CssClass = "message-error";
                        q15a2.Focus();
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                lblerr.Text = ex.Message;
            }



            try
            {
                if (obj_op.Validate_Dictionary_SpecialCode("0", "sp_ValidateDictionary", " select * from dict where tabname = 'sample_entry' and var_id = 'q15a3'", q15a3.Text, lblerr) == true)
                {
                    if (q15a3.Enabled == true)
                    {
                        q15a3.Focus();
                        return false;
                    }
                }
                else
                {
                    if (Convert.ToInt32(q15a3.Text) >= 20 && q15c3_120.Checked == false)
                    {
                        lblerr.Text = "if Oxacillin (1 µg) >= 20 it must be sensitive ";
                        lblerr.CssClass = "message-error";
                        q15a3.Focus();
                        return false;
                    }
                    else if (Convert.ToInt32(q15a3.Text) <= 19 && q15c3_120.Checked == true ||
                        Convert.ToInt32(q15a3.Text) <= 19 && q15c3_120.Checked == true)
                    {
                        lblerr.Text = "if Oxacillin (1 µg) <= 19 it can be intermediate or resistant ";
                        lblerr.CssClass = "message-error";
                        q15a3.Focus();
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                lblerr.Text = ex.Message;
            }





            try
            {
                if (obj_op.Validate_Dictionary_SpecialCode("0", "sp_ValidateDictionary", " select * from dict where tabname = 'sample_entry' and var_id = 'q15a4'", q15a4.Text, lblerr) == true)
                {
                    if (q15a4.Enabled == true)
                    {
                        q15a4.Focus();
                        return false;
                    }
                }
                else
                {
                    if (Convert.ToInt32(q15a4.Text) >= 16 && q15c4_130.Checked == false)
                    {
                        lblerr.Text = "if Ofloxacin (5 µg) >= 16 it must be sensitive ";
                        lblerr.CssClass = "message-error";
                        q15a4.Focus();
                        return false;
                    }
                    else if (Convert.ToInt32(q15a4.Text) >= 13 && Convert.ToInt32(q15a4.Text) <= 15 && q15c4_131.Checked == false)
                    {
                        lblerr.Text = "if Ofloxacin (5 µg) >= 13 or <= 15 it must be intermediate ";
                        lblerr.CssClass = "message-error";
                        q15a4.Focus();
                        return false;
                    }
                    else if (Convert.ToInt32(q15a4.Text) <= 12 && q15c4_132.Checked == false)
                    {
                        lblerr.Text = "if Ofloxacin (5 µg) <= 12 it must be resistant ";
                        lblerr.CssClass = "message-error";
                        q15a4.Focus();
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                lblerr.Text = ex.Message;
            }






            try
            {
                if (obj_op.Validate_Dictionary_SpecialCode("0", "sp_ValidateDictionary", " select * from dict where tabname = 'sample_entry' and var_id = 'q15a5'", q15a5.Text, lblerr) == true)
                {
                    if (q15a5.Enabled == true)
                    {
                        q15a5.Focus();
                        return false;
                    }
                }
                else
                {
                    if (Convert.ToInt32(q15a5.Text) >= 19 && q15c5_140.Checked == false)
                    {
                        lblerr.Text = "if Cotrimoxazole (25 µg) >= 19 it must be sensitive ";
                        lblerr.CssClass = "message-error";
                        q15a5.Focus();
                        return false;
                    }
                    else if (Convert.ToInt32(q15a5.Text) >= 16 && Convert.ToInt32(q15a5.Text) <= 18 && q15c5_141.Checked == false)
                    {
                        lblerr.Text = "if Cotrimoxazole (25 µg) >= 16 or <= 18 it must be intermediate ";
                        lblerr.CssClass = "message-error";
                        q15a5.Focus();
                        return false;
                    }
                    else if (Convert.ToInt32(q15a5.Text) <= 15 && q15c5_142.Checked == false)
                    {
                        lblerr.Text = "if Cotrimoxazole (25 µg) <= 15 it must be resistant ";
                        lblerr.CssClass = "message-error";
                        q15a5.Focus();
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                lblerr.Text = ex.Message;
            }





            try
            {
                if (obj_op.Validate_Dictionary_SpecialCode("0", "sp_ValidateDictionary", " select * from dict where tabname = 'sample_entry' and var_id = 'q15a6'", q15a6.Text, lblerr) == true)
                {
                    if (q15a6.Enabled == true)
                    {
                        q15a6.Focus();
                        return false;
                    }
                }
                else
                {
                    if (Convert.ToInt32(q15a6.Text) >= 28 && q15c6_150.Checked == false)
                    {
                        lblerr.Text = "if Tetracycline (30 µg) >= 28 it must be sensitive ";
                        lblerr.CssClass = "message-error";
                        q15a6.Focus();
                        return false;
                    }
                    else if (Convert.ToInt32(q15a6.Text) >= 25 && Convert.ToInt32(q15a6.Text) <= 27 && q15c6_151.Checked == false)
                    {
                        lblerr.Text = "if Tetracycline (30 µg) >= 25 or <= 27 it must be intermediate ";
                        lblerr.CssClass = "message-error";
                        q15a6.Focus();
                        return false;
                    }
                    else if (Convert.ToInt32(q15a6.Text) <= 24 && q15c6_152.Checked == false)
                    {
                        lblerr.Text = "if Tetracycline (30 µg) <= 24 it must be resistant ";
                        lblerr.CssClass = "message-error";
                        q15a6.Focus();
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                lblerr.Text = ex.Message;
            }






            try
            {
                if (obj_op.Validate_Dictionary_SpecialCode("0", "sp_ValidateDictionary", " select * from dict where tabname = 'sample_entry' and var_id = 'q15a7'", q15a7.Text, lblerr) == true)
                {
                    if (q15a7.Enabled == true)
                    {
                        q15a7.Focus();
                        return false;
                    }
                }
                else
                {
                    if (Convert.ToInt32(q15a7.Text) >= 17 && q15a7.Text != "99" && q15c7_160.Checked == false)
                    {
                        lblerr.Text = "if Vancomycin (30 µg) >= 17 it must be sensitive ";
                        lblerr.CssClass = "message-error";
                        q15a7.Focus();
                        return false;
                    }
                    else if (Convert.ToInt32(q15a7.Text) == 99 && q15c7_160.Checked == true ||
                        Convert.ToInt32(q15a7.Text) == 99 && q15c7_160.Checked == true)
                    {
                        lblerr.Text = "if Vancomycin (30 µg) = 99 it can be intermediate or it can be resistant ";
                        lblerr.CssClass = "message-error";
                        q15a7.Focus();
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                lblerr.Text = ex.Message;
            }





            try
            {
                if (obj_op.Validate_Dictionary_SpecialCode("0", "sp_ValidateDictionary", " select * from dict where tabname = 'sample_entry' and var_id = 'q16a1'", q16a1.Text, lblerr) == true)
                {
                    if (q16a1.Enabled == true)
                    {
                        q16a1.Focus();
                        return false;
                    }
                }
                else
                {
                    if (q16a1.Text.ToString().IndexOf('.') == -1)
                    {
                        if (Convert.ToInt32(q16a1.Text) <= 2 && q16c1_170.Checked == false)
                        {
                            lblerr.Text = "if Penicillin (non- meningitis) (MIC) <= 2 it must be sensitive ";
                            lblerr.CssClass = "message-error";
                            q16a1.Focus();
                            return false;
                        }
                        else if (Convert.ToInt32(q16a1.Text) == 4 && q16c1_171.Checked == true)
                        {
                            lblerr.Text = "if Penicillin (non- meningitis) (MIC) = 4 it can be intermediate ";
                            lblerr.CssClass = "message-error";
                            q16a1.Focus();
                            return false;
                        }
                        else if (Convert.ToInt32(q16a1.Text) >= 8 && q16c1_172.Checked == true)
                        {
                            lblerr.Text = "if Penicillin (non- meningitis) (MIC) >= 8 it can be resistant ";
                            lblerr.CssClass = "message-error";
                            q16a1.Focus();
                            return false;
                        }
                    }
                    else
                    {
                        if (Convert.ToDouble(q16a1.Text) <= 2 && q16c1_170.Checked == false)
                        {
                            lblerr.Text = "if Penicillin (non- meningitis) (MIC) <= 2 it must be sensitive ";
                            lblerr.CssClass = "message-error";
                            q16a1.Focus();
                            return false;
                        }
                        else if (Convert.ToDouble(q16a1.Text) == 4 && q16c1_171.Checked == true)
                        {
                            lblerr.Text = "if Penicillin (non- meningitis) (MIC) = 4 it can be intermediate ";
                            lblerr.CssClass = "message-error";
                            q16a1.Focus();
                            return false;
                        }
                        else if (Convert.ToDouble(q16a1.Text) >= 8 && q16c1_172.Checked == true)
                        {
                            lblerr.Text = "if Penicillin (non- meningitis) (MIC) >= 8 it can be resistant ";
                            lblerr.CssClass = "message-error";
                            q16a1.Focus();
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblerr.Text = ex.Message;
            }







            try
            {
                if (obj_op.Validate_Dictionary_SpecialCode("0", "sp_ValidateDictionary", " select * from dict where tabname = 'sample_entry' and var_id = 'q16a2'", q16a2.Text, lblerr) == true)
                {
                    if (q16a2.Enabled == true)
                    {
                        q16a2.Focus();
                        return false;
                    }
                }
                else
                {
                    if (q16a2.Text.ToString().IndexOf('.') == -1)
                    {
                        if (Convert.ToInt32(q16a2.Text) <= 1 && q16c2_180.Checked == false)
                        {
                            lblerr.Text = "if Ceftriaxone (non- meningitis) (MIC) <= 1 it must be sensitive ";
                            lblerr.CssClass = "message-error";
                            q16a2.Focus();
                            return false;
                        }
                        else if (Convert.ToInt32(q16a2.Text) == 2 && q16c2_181.Checked == false)
                        {
                            lblerr.Text = "if Ceftriaxone (non- meningitis) (MIC) = 2 it can be intermediate ";
                            lblerr.CssClass = "message-error";
                            q16a2.Focus();
                            return false;
                        }
                        else if (Convert.ToInt32(q16a2.Text) >= 4 && q16c2_182.Checked == false)
                        {
                            lblerr.Text = "if Ceftriaxone (non- meningitis) (MIC) >= 4 it can be resistant ";
                            lblerr.CssClass = "message-error";
                            q16a2.Focus();
                            return false;
                        }
                    }
                    else
                    {
                        if (Convert.ToDouble(q16a2.Text) <= 1 && q16c2_180.Checked == false)
                        {
                            lblerr.Text = "if Ceftriaxone (non- meningitis) (MIC) <= 1 it must be sensitive ";
                            lblerr.CssClass = "message-error";
                            q16a2.Focus();
                            return false;
                        }
                        else if (Convert.ToDouble(q16a2.Text) == 2 && q16c2_181.Checked == false)
                        {
                            lblerr.Text = "if Ceftriaxone (non- meningitis) (MIC) = 2 it can be intermediate ";
                            lblerr.CssClass = "message-error";
                            q16a2.Focus();
                            return false;
                        }
                        else if (Convert.ToDouble(q16a2.Text) >= 4 && q16c2_182.Checked == false)
                        {
                            lblerr.Text = "if Ceftriaxone (non- meningitis) (MIC) >= 4 it can be resistant ";
                            lblerr.CssClass = "message-error";
                            q16a2.Focus();
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblerr.Text = ex.Message;
            }






            try
            {
                if (obj_op.Validate_Dictionary_SpecialCode("0", "sp_ValidateDictionary", " select * from dict where tabname = 'sample_entry' and var_id = 'q16a3'", q16a3.Text, lblerr) == true)
                {
                    if (q16a3.Enabled == true)
                    {
                        q16a3.Focus();
                        return false;
                    }
                }
                else
                {
                    if (q16a3.Text.ToString().IndexOf('.') == -1)
                    {
                        if (Convert.ToInt32(q16a3.Text) <= 1 && q16c3_190.Checked == false)
                        {
                            lblerr.Text = "if Vancomycin (MIC) <= 1 it must be sensitive ";
                            lblerr.CssClass = "message-error";
                            q16a3.Focus();
                            return false;
                        }
                    }
                    else
                    {
                        if (Convert.ToDouble(q16a3.Text) <= 1 && q16c3_190.Checked == false)
                        {
                            lblerr.Text = "if Vancomycin (MIC) <= 1 it must be sensitive ";
                            lblerr.CssClass = "message-error";
                            q16a3.Focus();
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblerr.Text = ex.Message;
            }










            try
            {
                if (obj_op.Validate_Dictionary_SpecialCode("0", "sp_ValidateDictionary", " select * from dict where tabname = 'sample_entry' and var_id = 'q17a1'", q17a1.Text, lblerr) == true)
                {
                    if (q17a1.Enabled == true)
                    {
                        q17a1.Focus();
                        return false;
                    }
                }
                else
                {
                    if (Convert.ToInt32(q17a1.Text) >= 17 && q17c1_200.Checked == false)
                    {
                        lblerr.Text = "if Amikacin (30 µg) >= 17 it must be sensitive ";
                        lblerr.CssClass = "message-error";
                        q17a1.Focus();
                        return false;
                    }
                    else if (Convert.ToInt32(q17a1.Text) >= 15 && Convert.ToInt32(q17a1.Text) <= 16 && q17c1_201.Checked == false)
                    {
                        lblerr.Text = "if Amikacin (30 µg) >= 15 or <= 16 it must be intermediate ";
                        lblerr.CssClass = "message-error";
                        q17a1.Focus();
                        return false;
                    }
                    else if (Convert.ToInt32(q17a1.Text) <= 14 && q17c1_202.Checked == false)
                    {
                        lblerr.Text = "if Amikacin (30 µg) <= 14 it must be resistant ";
                        lblerr.CssClass = "message-error";
                        q17a1.Focus();
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                lblerr.Text = ex.Message;
            }






            try
            {
                if (obj_op.Validate_Dictionary_SpecialCode("0", "sp_ValidateDictionary", " select * from dict where tabname = 'sample_entry' and var_id = 'q17a2'", q17a2.Text, lblerr) == true)
                {
                    if (q17a2.Enabled == true)
                    {
                        q17a2.Focus();
                        return false;
                    }
                }
                else
                {
                    if (Convert.ToInt32(q17a2.Text) >= 18 && q17c2_300.Checked == false)
                    {
                        lblerr.Text = "if Chloramphenicol (30 µg) >= 18 it must be sensitive ";
                        lblerr.CssClass = "message-error";
                        q17a2.Focus();
                        return false;
                    }
                    else if (Convert.ToInt32(q17a2.Text) >= 13 && Convert.ToInt32(q17a2.Text) <= 17 && q17c2_301.Checked == false)
                    {
                        lblerr.Text = "if Chloramphenicol (30 µg) >= 13 or <= 17 it must be intermediate ";
                        lblerr.CssClass = "message-error";
                        q17a2.Focus();
                        return false;
                    }
                    else if (Convert.ToInt32(q17a2.Text) <= 12 && q17c2_302.Checked == false)
                    {
                        lblerr.Text = "if Chloramphenicol (30 µg) <= 12 it must be resistant ";
                        lblerr.CssClass = "message-error";
                        q17a2.Focus();
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                lblerr.Text = ex.Message;
            }






            try
            {
                if (obj_op.Validate_Dictionary_SpecialCode("0", "sp_ValidateDictionary", " select * from dict where tabname = 'sample_entry' and var_id = 'q17a99'", q17a99.Text, lblerr) == true)
                {
                    if (q17a99.Enabled == true)
                    {
                        q17a99.Focus();
                        return false;
                    }
                }
                else
                {
                    if (Convert.ToInt32(q17a99.Text) >= 21 && q17c3_303.Checked == false)
                    {
                        lblerr.Text = "if Clindamycin (2 µg) >= 21 it must be sensitive ";
                        lblerr.CssClass = "message-error";
                        q17a99.Focus();
                        return false;
                    }
                    else if (Convert.ToInt32(q17a99.Text) >= 15 && Convert.ToInt32(q17a99.Text) <= 20 && q17c3_304.Checked == false)
                    {
                        lblerr.Text = "if Clindamycin (2 µg) >= 15 or <= 20 it must be intermediate ";
                        lblerr.CssClass = "message-error";
                        q17a99.Focus();
                        return false;
                    }
                    else if (Convert.ToInt32(q17a99.Text) <= 14 && q17c3_305.Checked == false)
                    {
                        lblerr.Text = "if Clindamycin (2 µg) <= 14 it must be resistant ";
                        lblerr.CssClass = "message-error";
                        q17a99.Focus();
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                lblerr.Text = ex.Message;
            }








            try
            {
                if (obj_op.Validate_Dictionary_SpecialCode("0", "sp_ValidateDictionary", " select * from dict where tabname = 'sample_entry' and var_id = 'q17a3'", q17a3.Text, lblerr) == true)
                {
                    if (q17a3.Enabled == true)
                    {
                        q17a3.Focus();
                        return false;
                    }
                }
                else
                {
                    if (Convert.ToInt32(q17a3.Text) >= 15 && q17c4_306.Checked == false)
                    {
                        lblerr.Text = "if Gentamycin (10µg) >= 15 it must be sensitive ";
                        lblerr.CssClass = "message-error";
                        q17a3.Focus();
                        return false;
                    }
                    else if (Convert.ToInt32(q17a3.Text) >= 13 && Convert.ToInt32(q17a3.Text) <= 14 && q17c4_307.Checked == false)
                    {
                        lblerr.Text = "if Gentamycin (10µg) >= 13 or <= 14 it must be intermediate ";
                        lblerr.CssClass = "message-error";
                        q17a3.Focus();
                        return false;
                    }
                    else if (Convert.ToInt32(q17a3.Text) <= 12 && q17c4_308.Checked == false)
                    {
                        lblerr.Text = "if Gentamycin (10µg) <= 12 it must be resistant ";
                        lblerr.CssClass = "message-error";
                        q17a3.Focus();
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                lblerr.Text = ex.Message;
            }







            try
            {
                if (obj_op.Validate_Dictionary_SpecialCode("0", "sp_ValidateDictionary", " select * from dict where tabname = 'sample_entry' and var_id = 'q17a4'", q17a4.Text, lblerr) == true)
                {
                    if (q17a4.Enabled == true)
                    {
                        q17a4.Focus();
                        return false;
                    }
                }
                else
                {
                    if (Convert.ToInt32(q17a4.Text) >= 23 && q17c5_309.Checked == false)
                    {
                        lblerr.Text = "if Erythromycin (15 µg) >= 23 it must be sensitive ";
                        lblerr.CssClass = "message-error";
                        q17a4.Focus();
                        return false;
                    }
                    else if (Convert.ToInt32(q17a4.Text) >= 14 && Convert.ToInt32(q17a4.Text) <= 22 && q17c5_400.Checked == false)
                    {
                        lblerr.Text = "if Erythromycin (15 µg) >= 14 or <= 22 it must be intermediate ";
                        lblerr.CssClass = "message-error";
                        q17a4.Focus();
                        return false;
                    }
                    else if (Convert.ToInt32(q17a4.Text) <= 13 && q17c5_401.Checked == false)
                    {
                        lblerr.Text = "if Erythromycin (15 µg) <= 13 it must be resistant ";
                        lblerr.CssClass = "message-error";
                        q17a4.Focus();
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                lblerr.Text = ex.Message;
            }





            try
            {
                if (obj_op.Validate_Dictionary_SpecialCode("0", "sp_ValidateDictionary", " select * from dict where tabname = 'sample_entry' and var_id = 'q17a5'", q17a5.Text, lblerr) == true)
                {
                    if (q17a5.Enabled == true)
                    {
                        q17a5.Focus();
                        return false;
                    }
                }
                else
                {
                    if (Convert.ToInt32(q17a5.Text) >= 30 && q17a5.Text != "99" && q17c6_402.Checked == false)
                    {
                        lblerr.Text = "if Fusidic Acid (10 µg) >= 30 it must be sensitive ";
                        lblerr.CssClass = "message-error";
                        q17a5.Focus();
                        return false;
                    }
                    else if (Convert.ToInt32(q17a5.Text) >= 99 && q17c6_403.Checked == false)
                    {
                        lblerr.Text = "if Fusidic Acid (10 µg) >= 99 it must be intermediate ";
                        lblerr.CssClass = "message-error";
                        q17a5.Focus();
                        return false;
                    }
                    else if (Convert.ToInt32(q17a5.Text) <= 29 && q17c6_404.Checked == false)
                    {
                        lblerr.Text = "if Fusidic Acid (10 µg) <= 29 it must be resistant ";
                        lblerr.CssClass = "message-error";
                        q17a5.Focus();
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                lblerr.Text = ex.Message;
            }






            try
            {
                if (obj_op.Validate_Dictionary_SpecialCode("0", "sp_ValidateDictionary", " select * from dict where tabname = 'sample_entry' and var_id = 'q17a6'", q17a6.Text, lblerr) == true)
                {
                    if (q17a6.Enabled == true)
                    {
                        q17a6.Focus();
                        return false;
                    }
                }
                else
                {
                    if (Convert.ToInt32(q17a6.Text) >= 22 && q17a6.Text != "99" && q17c7_405.Checked == false)
                    {
                        lblerr.Text = "if Oxacillin (1 µg) >= 22 it must be sensitive ";
                        lblerr.CssClass = "message-error";
                        q17a6.Focus();
                        return false;
                    }
                    else if (Convert.ToInt32(q17a6.Text) == 99 && q17c7_406.Checked == false)
                    {
                        lblerr.Text = "if Oxacillin (1 µg) == 99 it must be intermediate ";
                        lblerr.CssClass = "message-error";
                        q17a6.Focus();
                        return false;
                    }
                    else if (Convert.ToInt32(q17a6.Text) <= 22 && q17c7_407.Checked == false)
                    {
                        lblerr.Text = "if Oxacillin (1 µg) <= 22 it must be resistant ";
                        lblerr.CssClass = "message-error";
                        q17a6.Focus();
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                lblerr.Text = ex.Message;
            }






            try
            {
                if (obj_op.Validate_Dictionary_SpecialCode("0", "sp_ValidateDictionary", " select * from dict where tabname = 'sample_entry' and var_id = 'q17a7'", q17a7.Text, lblerr) == true)
                {
                    if (q17a7.Enabled == true)
                    {
                        q17a7.Focus();
                        return false;
                    }
                }
                else
                {
                    if (Convert.ToInt32(q17a7.Text) >= 21 && q17c8_408.Checked == false)
                    {
                        lblerr.Text = "if Ciprofloxacin (5 µg) >= 21 it must be sensitive ";
                        lblerr.CssClass = "message-error";
                        q17a7.Focus();
                        return false;
                    }
                    else if (Convert.ToInt32(q17a7.Text) >= 16 && Convert.ToInt32(q17a7.Text) <= 20 && q17c8_409.Checked == false)
                    {
                        lblerr.Text = "if Ciprofloxacin (5 µg) >= 16 or <= 20 it must be intermediate ";
                        lblerr.CssClass = "message-error";
                        q17a7.Focus();
                        return false;
                    }
                    else if (Convert.ToInt32(q17a7.Text) <= 15 && q17c8_410.Checked == false)
                    {
                        lblerr.Text = "if Ciprofloxacin (5 µg) <= 15 it must be resistant ";
                        lblerr.CssClass = "message-error";
                        q17a7.Focus();
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                lblerr.Text = ex.Message;
            }




            try
            {
                if (obj_op.Validate_Dictionary_SpecialCode("0", "sp_ValidateDictionary", " select * from dict where tabname = 'sample_entry' and var_id = 'q17a8'", q17a8.Text, lblerr) == true)
                {
                    if (q17a8.Enabled == true)
                    {
                        q17a8.Focus();
                        return false;
                    }
                }
                else
                {
                    if (Convert.ToInt32(q17a8.Text) >= 29 && q17a8.Text != "99" && q17c9_411.Checked == false)
                    {
                        lblerr.Text = "if Penicillin (10 µg) >= 29 it must be sensitive ";
                        lblerr.CssClass = "message-error";
                        q17a8.Focus();
                        return false;
                    }
                    else if (Convert.ToInt32(q17a8.Text) >= 99 && q17c9_412.Checked == false)
                    {
                        lblerr.Text = "if Penicillin (10 µg) >= 99 it must be intermediate ";
                        lblerr.CssClass = "message-error";
                        q17a8.Focus();
                        return false;
                    }
                    else if (Convert.ToInt32(q17a8.Text) <= 28 && q17c9_413.Checked == false)
                    {
                        lblerr.Text = "if Penicillin (10 µg) <= 28 it must be resistant ";
                        lblerr.CssClass = "message-error";
                        q17a8.Focus();
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                lblerr.Text = ex.Message;
            }




            try
            {
                if (obj_op.Validate_Dictionary_SpecialCode("0", "sp_ValidateDictionary", " select * from dict where tabname = 'sample_entry' and var_id = 'q17a9'", q17a9.Text, lblerr) == true)
                {
                    if (q17a9.Enabled == true)
                    {
                        q17a9.Focus();
                        return false;
                    }
                }
                else
                {
                    if (Convert.ToInt32(q17a9.Text) >= 16 && q17c10_414.Checked == false)
                    {
                        lblerr.Text = "if Cotrimoxazole (25 µg) >= 16 it must be sensitive ";
                        lblerr.CssClass = "message-error";
                        q17a9.Focus();
                        return false;
                    }
                    else if (Convert.ToInt32(q17a9.Text) >= 11 && Convert.ToInt32(q17a9.Text) <= 15 && q17c10_415.Checked == false)
                    {
                        lblerr.Text = "if Cotrimoxazole (25 µg) >= 11 or <= 15 it must be intermediate ";
                        lblerr.CssClass = "message-error";
                        q17a9.Focus();
                        return false;
                    }
                    else if (Convert.ToInt32(q17a9.Text) <= 10 && q17c10_416.Checked == false)
                    {
                        lblerr.Text = "if Cotrimoxazole (25 µg) <= 10 it must be resistant ";
                        lblerr.CssClass = "message-error";
                        q17a9.Focus();
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                lblerr.Text = ex.Message;
            }




            try
            {
                if (obj_op.Validate_Dictionary_SpecialCode("0", "sp_ValidateDictionary", " select * from dict where tabname = 'sample_entry' and var_id = 'q17a10'", q17a10.Text, lblerr) == true)
                {
                    if (q17a10.Enabled == true)
                    {
                        q17a10.Focus();
                        return false;
                    }
                }
                else
                {
                    if (Convert.ToInt32(q17a10.Text) >= 19 && q17c11_417.Checked == false)
                    {
                        lblerr.Text = "if Tetracycline (30 µg) >= 19 it must be sensitive ";
                        lblerr.CssClass = "message-error";
                        q17a10.Focus();
                        return false;
                    }
                    else if (Convert.ToInt32(q17a10.Text) >= 15 && Convert.ToInt32(q17a10.Text) <= 18 && q17c11_418.Checked == false)
                    {
                        lblerr.Text = "if Tetracycline (30 µg) >= 15 or <= 18 it must be intermediate ";
                        lblerr.CssClass = "message-error";
                        q17a10.Focus();
                        return false;
                    }
                    else if (Convert.ToInt32(q17a10.Text) <= 14 && q17c11_419.Checked == false)
                    {
                        lblerr.Text = "if Tetracycline (30 µg) <= 14 it must be resistant ";
                        lblerr.CssClass = "message-error";
                        q17a10.Focus();
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                lblerr.Text = ex.Message;
            }






            try
            {
                if (obj_op.Validate_Dictionary_SpecialCode("0", "sp_ValidateDictionary", " select * from dict where tabname = 'sample_entry' and var_id = 'q18a1'", q18a1.Text, lblerr) == true)
                {
                    if (q18a1.Enabled == true)
                    {
                        q18a1.Focus();
                        return false;
                    }
                }
                else
                {
                    if (q18a1.Text.ToString().IndexOf('.') == -1)
                    {
                        if (Convert.ToInt32(q18a1.Text) <= 2 && q18c1_420.Checked == false)
                        {
                            lblerr.Text = "if Vancomycin (MIC) <= 2 it must be sensitive ";
                            lblerr.CssClass = "message-error";
                            q18a1.Focus();
                            return false;
                        }
                        else if (Convert.ToInt32(q18a1.Text) >= 4 && Convert.ToInt32(q18a1.Text) <= 8 && q18c1_421.Checked == false)
                        {
                            lblerr.Text = "if Vancomycin (MIC) >= 4 or <= 8 it can be intermediate ";
                            lblerr.CssClass = "message-error";
                            q18a1.Focus();
                            return false;
                        }
                        else if (Convert.ToInt32(q18a1.Text) >= 16 && q18c1_422.Checked == true)
                        {
                            lblerr.Text = "if Vancomycin (MIC) >= 16 it can be resistant ";
                            lblerr.CssClass = "message-error";
                            q18a1.Focus();
                            return false;
                        }
                    }
                    else
                    {
                        if (Convert.ToDouble(q18a1.Text) <= 2 && q18c1_420.Checked == false)
                        {
                            lblerr.Text = "if Vancomycin (MIC) <= 2 it must be sensitive ";
                            lblerr.CssClass = "message-error";
                            q18a1.Focus();
                            return false;
                        }
                        else if (Convert.ToDouble(q18a1.Text) >= 4 && Convert.ToDouble(q18a1.Text) <= 8 && q18c1_421.Checked == false)
                        {
                            lblerr.Text = "if Vancomycin (MIC) >= 4 or <= 8 it can be intermediate ";
                            lblerr.CssClass = "message-error";
                            q18a1.Focus();
                            return false;
                        }
                        else if (Convert.ToDouble(q18a1.Text) >= 16 && q18c1_422.Checked == true)
                        {
                            lblerr.Text = "if Vancomycin (MIC) >= 16 it can be resistant ";
                            lblerr.CssClass = "message-error";
                            q18a1.Focus();
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblerr.Text = ex.Message;
            }

            return true;
        }

        protected void q18b1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void q15a1_TextChanged(object sender, EventArgs e)
        {

        }




    }
}