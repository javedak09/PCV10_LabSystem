<%@ Page Title="" Language="C#" MasterPageFile="~/Site_S.Master" AutoEventWireup="true" CodeBehind="specimen.aspx.cs" Inherits="PCV10_LabSystem.specimen" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ OutputCache Location="None" VaryByParam="None" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<link rel="stylesheet" media="screen" type="text/css" href="Scripts/datepicker/css/datepicker.css" />
    <script type="text/javascript" src="Scripts/datepicker/js/datepicker.js"></script>--%>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.4/themes/smoothness/jquery-ui.css" />
    <script src="http://code.jquery.com/jquery-1.10.2.js"></script>
    <script src="http://code.jquery.com/ui/1.10.4/jquery-ui.js"></script>

    <%--<script src="js/jquery-1.8.3.js" type="text/javascript"></script>
    <script type="text/javascript" src="js/jquery-ui-1.9.2.custom.min.js"></script>
    <link rel="stylesheet" type="text/css" href="css/jquery-ui.css" />--%>


    <%--<script src="http://code.jquery.com/jquery-1.10.2.js"></script>
    <script src="http://code.jquery.com/ui/1.10.4/jquery-ui.js"></script>--%>


    <%--<script src="js/jquery-1.8.3.js" type="text/javascript"></script>
    <script type="text/javascript" src="js/jquery-ui-1.9.2.custom.min.js"></script>
    <link rel="stylesheet" type="text/css" href="css/jquery-ui.css" />--%>


    <link href="Scripts/timpicker/css/style.css" rel="stylesheet" />
    <link href="Scripts/timepicker/css/timepicki.css" rel="stylesheet" />
    <script src="Scripts/timepicker/jquery.min.js"></script>
    <script src="Scripts/timepicker/timepicki.js"></script>


    <script src="Scripts/timepicker/bootstrap.min.js"></script>


    <script type="text/javascript">
        function lettersOnly(evt) {
            evt = (evt) ? evt : event;
            var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode :
               ((evt.which) ? evt.which : 0));

            if (charCode > 31 && (charCode < 65 || charCode > 90) &&
               (charCode < 97 || charCode > 122)) {
                alert("Please enter string value ");
                return false;
            }
            return true;
        }

        function lettersOnly_WithSpace(evt) {
            evt = (evt) ? evt : event;
            var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode :
               ((evt.which) ? evt.which : 0));

            if (charCode > 31 && (charCode < 65 || charCode > 90) &&
               (charCode < 97 || charCode > 122) && charCode != 32) {
                alert("Please enter string value ");
                return false;
            }
            return true;
        }

        function numeralsOnly(evt) {
            evt = (evt) ? evt : event;
            var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode :
               ((evt.which) ? evt.which : 0));

            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                alert("Please enter Numeric value ");
                return false;
            }
            return true;
        }


        function numeralsOnly_decimal(evt) {
            evt = (evt) ? evt : event;
            var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode :
               ((evt.which) ? evt.which : 0));

            if (charCode > 31 && charCode != 46 && (charCode < 48 || charCode > 57)) {
                alert("Please enter Numeric value ");
                return false;
            }
            return true;
        }


        function numeralsOnly1(evt) {
            evt = (evt) ? evt : event;
            var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode :
               ((evt.which) ? evt.which : 0));

            if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 46) {
                alert("Please enter Numeric value ");
                return false;
            }
            return true;
        }

        function RestrictSpecialCharacters(evt) {
            evt = (evt) ? evt : event;
            var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode :
               ((evt.which) ? evt.which : 0));
            if (charCode > 31 && (charCode < 65 || charCode > 90) &&
               (charCode < 97 || charCode > 122) && charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 32) {
                alert("Please enter string / numeric value but special characters not allowed ");
                return false;
            }
            return true;
        }

        function RestrictSpecialCharacters_New2(evt) {
            evt = (evt) ? evt : event;
            var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode :
               ((evt.which) ? evt.which : 0));
            if (charCode > 31 && (charCode < 65 || charCode > 90) &&
               (charCode < 97 || charCode > 122) && charCode > 31 && (charCode < 48 || charCode > 57)) {
                alert("Please enter string / numeric value but special characters not allowed ");
                return false;
            }
            return true;
        }


        function RestrictSpecialCharacters_New(evt) {
            evt = (evt) ? evt : event;
            var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode :
               ((evt.which) ? evt.which : 0));

            if (charCode > 31 && (charCode < 65 || charCode > 90) &&
               (charCode < 97 || charCode > 122) && charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 32 && charCode != 46 && charCode != 47) {
                alert("Please enter string / numeric value but special characters not allowed ");
                return false;
            }
            return true;
        }


        function RestrictSpecialCharacters_Projectcode(evt) {
            evt = (evt) ? evt : event;
            var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode :
               ((evt.which) ? evt.which : 0));

            if (charCode > 31 && (charCode < 65 || charCode > 90) &&
               (charCode < 97 || charCode > 122) && charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 32 && charCode != 46 && charCode != 47) {
                alert("Please enter string / numeric value but special characters not allowed ");
                return false;
            }
            return true;
        }


    </script>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td style="text-align: center; vertical-align: middle">
                <h1>Sample Receiving</h1>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblerr" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table class="mytable2">
                    <tr>
                        <td style="vertical-align: top;">Study ID<span class="message-error">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="studyid" MaxLength="10" runat="server" CssClass="text-caps1" onkeypress="return numeralsOnly(event)" Text="" OnTextChanged="studyid_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;">Child ID<span class="message-error">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="childid" MaxLength="10" runat="server" CssClass="text-caps1" onkeypress="return numeralsOnly(event)"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;">DSS ID<span class="message-error">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="dssid" MaxLength="16" runat="server" CssClass="text-caps1"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;">Field Site<span class="message-error">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="q1" CssClass="ddl1" runat="server">
                                <asp:ListItem Selected="True" Value="0">Please Select</asp:ListItem>
                                <asp:ListItem Value="1">Matiari</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;">Physician Name<span class="message-error">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="q2" runat="server" MaxLength="45" CssClass="text-caps1" Text="" onkeypress="return lettersOnly_WithSpace(event)"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;">Mother Name<span class="message-error">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="q3" runat="server" MaxLength="45" CssClass="text-caps1" Text="" onkeypress="return lettersOnly_WithSpace(event)"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;">Child Name<span class="message-error">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="q3a" runat="server" MaxLength="45" CssClass="text-caps1" Text="" onkeypress="return lettersOnly_WithSpace(event)"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;">Nasopharyngeal swab collected<span class="message-error">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="q4" CssClass="ddl1" runat="server">
                                <asp:ListItem Selected="True" Value="0">Please Select</asp:ListItem>
                                <asp:ListItem Value="1">YES</asp:ListItem>
                                <asp:ListItem Value="2">NO</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;">Collection date<span class="message-error">*</span></td>
                        <td>
                            <asp:TextBox ID="q5dt" runat="server" MaxLength="7" CssClass="text-caps1" Text=""></asp:TextBox>

                            <div id="Div2" runat="server">
                                <script type="text/javascript">
                                    $(document).ready(function () {
                                        $('#<%=q5dt.ClientID%>').datepicker({
                                            dateFormat: 'dd/mm/yy',
                                            focusOn: 'button',
                                            onSelect: function () { },
                                            onClose: function () { $(this).focus(); }
                                        });
                                    });
                                </script>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;">Collection time<span class="message-error">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="q5t" runat="server" MaxLength="6" CssClass="text-caps1" Text=""></asp:TextBox>
                            <script src="Scripts/timepicker/timepicki.js"></script>
                            <script>
                                $('#<%=q5t.ClientID%>').timepicki();
                            </script>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;">Specimen received<span class="message-error">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="q6" CssClass="ddl1" runat="server" OnSelectedIndexChanged="q6_SelectedIndexChanged" AutoPostBack="True">
                                <asp:ListItem Selected="True" Value="0">Please Select</asp:ListItem>
                                <asp:ListItem Value="1">YES</asp:ListItem>
                                <asp:ListItem Value="2">NO</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;">Condition of the STGG tube (respiratory specimen)<span class="message-error">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="q7" CssClass="ddl1" runat="server" Enabled="False">
                                <asp:ListItem Selected="True" Value="0">Please Select</asp:ListItem>
                                <asp:ListItem Value="1">Intact</asp:ListItem>
                                <asp:ListItem Value="2">Physical Damage</asp:ListItem>
                                <asp:ListItem Value="3">Without swab stick</asp:ListItem>
                                <asp:ListItem Value="4">Without media</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="text-heading">MATIARI LAB
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;">Temperature of the tube upon arrival at lab
                        </td>
                        <td>
                            <asp:TextBox ID="q8" runat="server" MaxLength="4" CssClass="text-caps1" Text="" onkeypress="return numeralsOnly_decimal(event)" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;">Received date</td>
                        <td>
                            <asp:TextBox ID="q9dt" runat="server" CssClass="text-caps1" Text="" Enabled="False"></asp:TextBox>
                            <div id="Div1" runat="server">
                                <script type="text/javascript">
                                    $(document).ready(function () {
                                        $('#<%=q9dt.ClientID%>').datepicker({
                                            dateFormat: 'dd/mm/yy',
                                            focusOn: 'button',
                                            onSelect: function () { },
                                            onClose: function () { $(this).focus(); }
                                        });
                                    });
                                </script>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;">Received time<span class="message-error">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="q9t" runat="server" CssClass="text-caps1" Text="" Enabled="False"></asp:TextBox>
                            <script src="Scripts/timepicker/timepicki.js"></script>
                            <script>
                                $('#<%=q9t.ClientID%>').timepicki();
                            </script>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;">Name of laboratory person<span class="message-error">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="q10" runat="server" MaxLength="45" CssClass="text-caps1" Text="" onkeypress="return lettersOnly_WithSpace(event)"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;">Laboratory person code<span class="message-error">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="q10a" runat="server" MaxLength="4" CssClass="text-caps1" Text="" onkeypress="return numeralsOnly(event)"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2"></td>
                    </tr>
                    <tr>
                        <td colspan="2" class="text-heading">KARACHI LAB
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2"></td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;">Temperature of the tube upon arrival at lab
                        </td>
                        <td>
                            <asp:TextBox ID="q8a" runat="server" MaxLength="4" CssClass="text-caps1" Text="" onkeypress="return numeralsOnly_decimal(event)" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;">Received date</td>
                        <td>
                            <asp:TextBox ID="q9dt1" runat="server" CssClass="text-caps1" Text="" Enabled="False"></asp:TextBox>
                            <div id="Div3" runat="server">
                                <script type="text/javascript">
                                    $(document).ready(function () {
                                        $('#<%=q9dt1.ClientID%>').datepicker({
                                            dateFormat: 'dd/mm/yy',
                                            focusOn: 'button',
                                            onSelect: function () { },
                                            onClose: function () { $(this).focus(); }
                                        });
                                    });
                                </script>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;">Received time<span class="message-error">*</span></td>
                        <td>
                            <asp:TextBox ID="q9ta" runat="server" CssClass="text-caps1" Text="" Enabled="False"></asp:TextBox>
                            <script src="Scripts/timepicker/timepicki.js"></script>
                            <script>
                                $('#<%=q9ta.ClientID%>').timepicki();
                            </script>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;">Name of laboratory person<span class="message-error">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="q10a1" runat="server" MaxLength="45" CssClass="text-caps1" Text="" onkeypress="return lettersOnly_WithSpace(event)"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;">Laboratory person code<span class="message-error">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="q10a2" runat="server" MaxLength="4" CssClass="text-caps1" Text="" onkeypress="return numeralsOnly(event)"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center">
                            <asp:Button ID="cmdSave" runat="server" Text="  Save " OnClick="cmdSave_Click" />
                            <asp:Button ID="cmdCancel" runat="server" Text="Cancel" OnClick="cmdCancel_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
