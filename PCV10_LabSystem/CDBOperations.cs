using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for CDBOperations
/// </summary>
public class CDBOperations
{
    public CDBOperations()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public DataSet ExecuteNonQuery(string[] fieldName, string[] fieldValues, string spName)
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
            cmd.CommandText = spName;
            cmd.CommandType = CommandType.StoredProcedure;

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



    public string GetDataFieldWise(string id, string spName, string fieldname, string fieldvalue)
    {
        string value = "";
        CDBOperations obj_op = null;

        try
        {
            string[] fldname = { "var_studyid", "fldval" };
            string[] fldvalue = { fieldvalue, id.ToString() };

            obj_op = new CDBOperations();
            DataSet ds = obj_op.ExecuteNonQuery(fldname, fldvalue, spName);

            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        value = ds.Tables[0].Rows[0]["" + fieldname + ""].ToString();
                    }
                }
            }
        }

        catch (Exception ex)
        {

        }

        finally
        {
            obj_op = null;
        }

        return value;
    }


    public DataSet GetFormData_VisitID(string spName, string fldval, string formno, string visitid)
    {
        CDBOperations obj_op = new CDBOperations();
        DataSet ds = null;

        try
        {
            string[] fldname = { "var_studyid", "fldval" };
            string[] fldvalue = { formno, fldval };

            ds = obj_op.ExecuteNonQuery(fldname, fldvalue, "sp_GetRecords");
        }

        catch (Exception ex)
        {

        }

        finally
        {
            obj_op = null;
        }

        return ds;
    }


    public DataSet ExecuteNonQuery_Request(string[] fieldName, string[] fieldValues, string spName)
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
            cmd.CommandText = spName;
            cmd.CommandType = CommandType.StoredProcedure;

            for (int a = 0; a <= fieldName.Length - 1; a++)
            {
                if (fieldValues[a] == " -" || fieldValues[a] == "  /  /" || fieldValues[a] == "  :" || fieldValues[a] == "" || fieldValues[a] == "  -   -  -      -  - -" || fieldValues[a] == "3-     -" || fieldValues[a] == "  ." || fieldValues[a] == "  -   -  -    -  - -")
                {
                    cmd.Parameters.AddWithValue(fieldName[a], DBNull.Value);
                }
                else
                {
                    if (fieldName[a] == "PRDATE")
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


    public string ExecuteNonQuery_Inventory(string[] fieldName, string[] fieldValues, string spName)
    {
        SqlCommand cmd = null;
        CConnection cn = null;
        SqlDataAdapter da = null;
        DataSet ds = null;
        string errmsg = null;

        string[] dt;


        try
        {
            cn = new CConnection();

            cmd = new SqlCommand();
            cmd.Connection = cn.cn;
            cmd.CommandText = spName;
            cmd.CommandType = CommandType.StoredProcedure;

            for (int a = 0; a <= fieldName.Length - 1; a++)
            {
                if (fieldValues[a] == "" || fieldValues[a] == " -" || fieldValues[a] == "  /  /" || fieldValues[a] == "  :" || fieldValues[a] == "" || fieldValues[a] == "  -   -  -      -  - -" || fieldValues[a] == "3-     -" || fieldValues[a] == "  ." || fieldValues[a] == "  -   -  -    -  - -")
                {
                    cmd.Parameters.AddWithValue(fieldName[a], DBNull.Value);
                }
                else
                {
                    if (fieldName[a] == "var_entrydate")
                    {
                        if (fieldValues[a].ToString() == "01/01/0001")
                        {
                            cmd.Parameters.AddWithValue(fieldName[a], DBNull.Value);
                        }
                        else
                        {
                            dt = fieldValues[a].Split('/');
                            cmd.Parameters.AddWithValue(fieldName[a], dt[2] + "/" + dt[1] + "/" + dt[0]);
                        }
                    }
                    else if (fieldName[a] == "var_q5dt" || fieldName[a] == "var_q9dt" || fieldName[a] == "var_q9dt1" || fieldName[a] == "var_q6dt" || fieldName[a] == "var_q10dt")
                    {
                        if (fieldValues[a].ToString() == "01/01/0001")
                        {
                            cmd.Parameters.AddWithValue(fieldName[a], DBNull.Value);
                        }
                        else
                        {
                            dt = fieldValues[a].Split('/');
                            cmd.Parameters.AddWithValue(fieldName[a], dt[2] + "-" + dt[1] + "-" + dt[0]);
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
            errmsg = ex.Message;
        }

        finally
        {
            cn.MConnClose();
            cmd = null;
            cn = null;
        }

        return errmsg;
    }




    public bool ExecuteNonQuery_Add(string[] fieldName, string[] fieldValues, string spName)
    {
        SqlCommand cmd = null;
        CConnection cn = null;
        SqlDataAdapter da = null;
        DataSet ds = null;
        bool IsSucess = false;

        string[] dt;


        try
        {
            cn = new CConnection();

            cmd = new SqlCommand();
            cmd.Connection = cn.cn;
            cmd.CommandText = spName;
            cmd.CommandType = CommandType.StoredProcedure;

            for (int a = 0; a <= fieldName.Length - 1; a++)
            {
                if (fieldValues[a] == " -" || fieldValues[a] == "  /  /" || fieldValues[a] == "  :" || fieldValues[a] == "" || fieldValues[a] == "  -   -  -      -  - -" || fieldValues[a] == "3-     -" || fieldValues[a] == "  ." || fieldValues[a] == "  -   -  -    -  - -")
                {
                    cmd.Parameters.AddWithValue(fieldName[a], DBNull.Value);
                }
                else
                {
                    if (fieldName[a] == "DOP" || fieldName[a] == "AADOP")
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

            IsSucess = true;
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

        return IsSucess;
    }



    public bool Login(string UserID, string Pwd, string spName)
    {
        bool IsExists = false;

        try
        {
            string[] fldname = { "var_usernme", "var_passwd" };
            string[] fldvalue = { UserID, Pwd };

            //DataSet ds = ExecuteNonQuery(fldname, fldvalue, spName);

            DataSet ds = ExecuteNonQuery_Qry(fldname, fldvalue, "select * from login where userid='" + UserID + "' and passwd='" + Pwd + "' and userstatus = 1");

            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        HttpContext.Current.Response.Cookies["mycookie"].Value = ds.Tables[0].Rows[0][1].ToString();
                        HttpContext.Current.Session["mycookierole"] = ds.Tables[0].Rows[0]["role"].ToString();
                        //HttpContext.Current.Response.Cookies["UserName"].Value = ds.Tables[0].Rows[0][1].ToString();
                        //HttpContext.Current.Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(5);
                        HttpContext.Current.Session["UserID"] = ds.Tables[0].Rows[0][0].ToString();
                        HttpContext.Current.Response.Cookies["IsUserOrAdmin"].Value = ds.Tables[0].Rows[0]["IsUserOrAdmin"].ToString();

                        IsExists = true;
                    }
                }
            }

            ds = null;
        }

        catch (Exception ex)
        {
        }

        finally
        {

        }

        return IsExists;
    }



    public static DataSet ExecuteNonQuery_Qry(string[] fieldName, string[] fieldValues, string qry)
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



    public DataSet GetFormData_VisitID1(string spName, string fldval, string frmName)
    {
        DataSet ds = null;

        try
        {
            string[] fldname = { "var_tabname", "fldval" };
            string[] fldvalue = { frmName, fldval };

            ds = ExecuteNonQuery(fldname, fldvalue, spName);
        }

        catch (Exception ex)
        {

        }

        finally
        {

        }

        return ds;
    }




    public int ExecuteNonQuery_New1(string[] fieldName, string[] fieldValues, string spName)
    {
        SqlCommand cmd = null;
        CConnection cn = null;
        SqlDataAdapter da = null;
        DataSet ds = null;
        int result = 0;

        string[] dt;


        try
        {
            cn = new CConnection();

            cmd = new SqlCommand();
            cmd.Connection = cn.cn;
            cmd.CommandText = spName;
            cmd.CommandType = CommandType.StoredProcedure;

            for (int a = 0; a <= fieldName.Length - 1; a++)
            {
                if (fieldValues[a] == " -" || fieldValues[a] == "  /  /" || fieldValues[a] == "  :" || fieldValues[a] == "" || fieldValues[a] == "  -   -  -      -  - -" || fieldValues[a] == "3-     -" || fieldValues[a] == "  ." || fieldValues[a] == "  -   -  -    -  - -")
                {
                    cmd.Parameters.AddWithValue(fieldName[a], DBNull.Value);
                }
                else
                {
                    if (fieldName[a] == "DOP" || fieldName[a] == "AADOP" || fieldName[a] == "EntryDate" || fieldName[a] == "var_entrydate")
                    {
                        if (fieldValues[a].ToString() == "01/01/0001")
                        {
                            cmd.Parameters.AddWithValue(fieldName[a], DBNull.Value);
                        }
                        else
                        {
                            dt = fieldValues[a].Split('/');
                            cmd.Parameters.AddWithValue(fieldName[a], dt[2] + "-" + dt[1] + "-" + dt[0]);
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

            result = 1;
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

        return result;
    }




    public string DaysDifference(string id, string spName, string fieldname, string fieldvalue, string StartDate, string EndDate, string VisitID)
    {
        string value = "";
        CDBOperations obj_op = null;

        try
        {
            string[] fldname = { "FormID", "fldvalue", "StartDate", "EndDate", "VisitID" };
            string[] fldvalue = { fieldvalue, id, StartDate, EndDate, VisitID };

            obj_op = new CDBOperations();
            DataSet ds = obj_op.ExecuteNonQuery(fldname, fldvalue, spName);

            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        value = ds.Tables[0].Rows[0]["" + fieldname + ""].ToString();

                        if (value == "")
                        {
                            value = "-0";
                        }
                    }
                    else
                    {
                        value = "99/99/9999";
                    }
                }
                else
                {
                    value = "99/99/9999";
                }
            }
            else
            {
                value = "99/99/9999";
            }
        }

        catch (Exception ex)
        {

        }

        finally
        {
            obj_op = null;
        }

        return value;
    }



    public bool Validate_Dictionary_SpecialCode(string fldval, string spName, string criteria, string formno, Label lblerr)
    {
        DataSet ds = null;
        bool IsError = false;

        try
        {
            string[] fldname = { "var_criteria" };
            string[] fldvalue = { criteria };

            ds = ExecuteNonQuery(fldname, fldvalue, spName);

            if (formno == "")
            {
                lblerr.Text = "Invalid value ";
                IsError = true;
            }
            else
            {
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["value1"].ToString()) == false && string.IsNullOrEmpty(ds.Tables[0].Rows[0]["value2"].ToString()) == false)
                        {
                            if (formno != ds.Tables[0].Rows[0]["value1"].ToString() && formno != ds.Tables[0].Rows[0]["value2"].ToString())
                            {
                                if (formno.ToString().IndexOf('.') == -1)
                                {
                                    if (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["minval"].ToString()) == false && string.IsNullOrEmpty(ds.Tables[0].Rows[0]["maxval"].ToString()) == false)
                                    {
                                        if (Convert.ToInt32(ds.Tables[0].Rows[0]["minval"]) > Convert.ToInt32(formno) || Convert.ToInt32(ds.Tables[0].Rows[0]["maxval"]) < Convert.ToInt32(formno))
                                        {
                                            lblerr.Text = "Invalid value ";
                                            lblerr.CssClass = "message-error";
                                            IsError = true;
                                        }
                                    }
                                }
                                else
                                {
                                    if (Convert.ToDouble(ds.Tables[0].Rows[0]["value1"]) == Convert.ToDouble(formno) || Convert.ToDouble(ds.Tables[0].Rows[0]["value2"]) == Convert.ToDouble(formno))
                                    {

                                    }
                                    else
                                    {
                                        if (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["minval"].ToString()) == false && string.IsNullOrEmpty(ds.Tables[0].Rows[0]["maxval"].ToString()) == false)
                                        {
                                            if (Convert.ToDouble(ds.Tables[0].Rows[0]["minval"]) > Convert.ToDouble(formno) || Convert.ToDouble(ds.Tables[0].Rows[0]["maxval"]) < Convert.ToDouble(formno))
                                            {
                                                lblerr.Text = "Invalid value ";
                                                lblerr.CssClass = "message-error";
                                                IsError = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else if (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["value1"].ToString()) == false)
                        {
                            if (formno != ds.Tables[0].Rows[0]["value1"].ToString())
                            {
                                if (formno.ToString().IndexOf('.') == -1)
                                {
                                    if (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["minval"].ToString()) == false && string.IsNullOrEmpty(ds.Tables[0].Rows[0]["maxval"].ToString()) == false)
                                    {
                                        if (Convert.ToInt32(ds.Tables[0].Rows[0]["minval"]) > Convert.ToInt32(formno) || Convert.ToInt32(ds.Tables[0].Rows[0]["maxval"]) < Convert.ToInt32(formno))
                                        {
                                            lblerr.Text = "Invalid value ";
                                            lblerr.CssClass = "message-error";
                                            IsError = true;
                                        }
                                    }
                                }
                                else
                                {
                                    if (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["minval"].ToString()) == false && string.IsNullOrEmpty(ds.Tables[0].Rows[0]["maxval"].ToString()) == false)
                                    {
                                        if (Convert.ToDouble(ds.Tables[0].Rows[0]["minval"]) > Convert.ToDouble(formno) || Convert.ToDouble(ds.Tables[0].Rows[0]["maxval"]) < Convert.ToDouble(formno))
                                        {
                                            lblerr.Text = "Invalid value ";
                                            lblerr.CssClass = "message-error";
                                            IsError = true;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (formno.ToString().IndexOf('.') == -1)
                            {
                                if (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["minval"].ToString()) == false && string.IsNullOrEmpty(ds.Tables[0].Rows[0]["maxval"].ToString()) == false)
                                {
                                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["minval"]) > Convert.ToInt32(formno) || Convert.ToInt32(ds.Tables[0].Rows[0]["maxval"]) < Convert.ToInt32(formno))
                                    {
                                        lblerr.Text = "Invalid value ";
                                        lblerr.CssClass = "message-error";
                                        IsError = true;
                                    }
                                }
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["minval"].ToString()) == false && string.IsNullOrEmpty(ds.Tables[0].Rows[0]["maxval"].ToString()) == false)
                                {
                                    if (Convert.ToDouble(ds.Tables[0].Rows[0]["minval"]) > Convert.ToDouble(formno) || Convert.ToDouble(ds.Tables[0].Rows[0]["maxval"]) < Convert.ToDouble(formno))
                                    {
                                        lblerr.Text = "Invalid value ";
                                        lblerr.CssClass = "message-error";
                                        IsError = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        catch (Exception ex)
        {
            lblerr.Text = ex.Message;
        }

        finally
        {
            ds = null;
        }

        return IsError;
    }




    public bool Validate_Dictionary_SpecialCode_old(string fldval, string spName, string criteria, string formno, Label lblerr)
    {
        DataSet ds = null;
        bool IsError = false;

        try
        {
            string[] fldname = { "var_criteria" };
            string[] fldvalue = { criteria };

            ds = ExecuteNonQuery(fldname, fldvalue, spName);

            if (formno == "")
            {
                lblerr.Text = "Invalid value ";
                IsError = true;
            }
            else
            {
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {

                        if (formno.ToString().IndexOf('.') == -1)
                        {
                            if (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["minval"].ToString()) == false && string.IsNullOrEmpty(ds.Tables[0].Rows[0]["maxval"].ToString()) == false)
                            {
                                if (Convert.ToInt32(ds.Tables[0].Rows[0]["minval"]) > Convert.ToInt32(formno) || Convert.ToInt32(ds.Tables[0].Rows[0]["maxval"]) < Convert.ToInt32(formno))
                                {
                                    lblerr.Text = "Invalid value ";
                                    lblerr.CssClass = "message-error";
                                    IsError = true;
                                }
                            }
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["minval"].ToString()) == false && string.IsNullOrEmpty(ds.Tables[0].Rows[0]["maxval"].ToString()) == false)
                            {
                                if (Convert.ToDouble(ds.Tables[0].Rows[0]["minval"]) > Convert.ToDouble(formno) || Convert.ToDouble(ds.Tables[0].Rows[0]["maxval"]) < Convert.ToDouble(formno))
                                {
                                    lblerr.Text = "Invalid value ";
                                    lblerr.CssClass = "message-error";
                                    IsError = true;
                                }

                            }
                        }
                    }
                }
            }


        }

        catch (Exception ex)
        {
            lblerr.Text = ex.Message;
        }

        finally
        {
            ds = null;
        }

        return IsError;
    }







}