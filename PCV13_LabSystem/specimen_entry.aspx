<%@ Page Title="" Language="C#" MasterPageFile="~/Site_S.Master" AutoEventWireup="true" CodeBehind="specimen_entry.aspx.cs" Inherits="PCV13_LabSystem.specimen_entry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<link rel="stylesheet" media="screen" type="text/css" href="../Scripts/datepicker/css/datepicker.css" />
    <script type="text/javascript" src="../Scripts/datepicker/js/datepicker.js"></script>--%>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.4/themes/smoothness/jquery-ui.css">
    <script src="http://code.jquery.com/jquery-1.10.2.js"></script>
    <script src="http://code.jquery.com/ui/1.10.4/jquery-ui.js"></script>

    <script src="js/jquery-1.8.3.js" type="text/javascript"></script>
    <script type="text/javascript" src="js/jquery-ui-1.9.2.custom.min.js"></script>
    <link rel="stylesheet" type="text/css" href="css/jquery-ui.css" />

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



        function ValidateFields(txt) {
            if (txt.value.length != 5) {
                alert("Length of study id must be 5 digits 00.00 ");
                txt.focus();
                return false;
            }
            else if (txt.value.substring(3, 2) != ".") {

                alert("2nd Digit must be . ");
                txt.focus();
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
    <asp:UpdatePanel ID="UpdatePanel188" runat="server">
        <ContentTemplate>
            <table>
                <tr>
                    <td style="text-align: center; vertical-align: middle">
                        <h1>Sample Collection Entry</h1>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblerr" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <table class="mytable2">
                            <tr>
                                <td>
                                    <table>
                                        <tr>
                                            <td style="vertical-align: top;">Study ID<span class="message-error">*</span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="studyid" MaxLength="10" runat="server" CssClass="text-caps1" onkeypress="return numeralsOnly(event)" Text=""></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: top; display: none;">Field Site<span class="message-error">*</span>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="q1" CssClass="ddl1" runat="server" Visible="false">
                                                    <asp:ListItem Selected="True" Value="0">Please Select</asp:ListItem>
                                                    <asp:ListItem Value="1">Matiari</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: top; display: none;">Physician Name<span class="message-error">*</span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="q2" runat="server" MaxLength="45" CssClass="text-caps1" Visible="false" Text="" onkeypress="return lettersOnly_WithSpace(event)"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: top; display: none;">Mother Name<span class="message-error">*</span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="q3" runat="server" MaxLength="45" Visible="false" CssClass="text-caps1" Text="" onkeypress="return lettersOnly_WithSpace(event)"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: top; display: none;">Child Name<span class="message-error">*</span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="q3a" runat="server" MaxLength="45" Visible="false" CssClass="text-caps1" Text="" onkeypress="return lettersOnly_WithSpace(event)"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: top;">Child ID / Respak ID<span class="message-error">*</span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="q4" MaxLength="10" runat="server" CssClass="text-caps1" onkeypress="return numeralsOnly(event)"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: top;">BT Number<span class="message-error">*</span>
                                            </td>
                                            <td>BT-
                                        <asp:TextBox ID="q4a" MaxLength="10" runat="server" CssClass="text-caps" onkeypress="return numeralsOnly(event)"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: top; display: none;">Nasopharyngeal swab collected<span class="message-error">*</span>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="q5" CssClass="ddl1" runat="server" Visible="false">
                                                    <asp:ListItem Selected="True" Value="0">Please Select</asp:ListItem>
                                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                                    <asp:ListItem Value="2">No</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: top; display: none;">Collection date<span class="message-error">*</span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="q6dt" runat="server" MaxLength="7" Visible="false" CssClass="text-caps1" Text="" TextMode="Date"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: top; display: none;">Collection time<span class="message-error">*</span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="q6t" runat="server" MaxLength="6" Visible="false" CssClass="text-caps1" Text="" TextMode="Time"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: top; display: none;">Specimen received<span class="message-error">*</span>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="q7" CssClass="ddl1" Visible="false" runat="server" AutoPostBack="True" OnSelectedIndexChanged="q7_SelectedIndexChanged">
                                                    <asp:ListItem Selected="True" Value="0">Please Select</asp:ListItem>
                                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                                    <asp:ListItem Value="2">No</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: top; display: none;">Condition of the STGG tube (respiratory specimen)<span class="message-error">*</span>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="q8" CssClass="ddl1" runat="server" Visible="false">
                                                    <asp:ListItem Selected="True" Value="0">Please Select</asp:ListItem>
                                                    <asp:ListItem Value="1">Intact</asp:ListItem>
                                                    <asp:ListItem Value="2">Physical Damage</asp:ListItem>
                                                    <asp:ListItem Value="3">Without swab stick</asp:ListItem>
                                                    <asp:ListItem Value="4">Without media</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: top; display: none;">Temperature of the tube upon arrival at lab
                                            </td>
                                            <td>
                                                <asp:TextBox ID="q9" runat="server" MaxLength="2" Visible="false" CssClass="text-caps1" Text="" onkeypress="return numeralsOnly(event)"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: top; display: none;">Received date
                                            </td>
                                            <td>
                                                <asp:TextBox ID="q10dt" runat="server" Visible="false" CssClass="text-caps1" Text="" TextMode="Date"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: top; display: none;">Received time<span class="message-error">*</span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="q10t" runat="server" CssClass="text-caps1" Visible="false" Text="" TextMode="Time"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: top; display: none;">Name of laboratory person<span class="message-error">*</span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="q11" runat="server" MaxLength="45" Visible="false" CssClass="text-caps1" Text="" onkeypress="return lettersOnly_WithSpace(event)"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: top;">S.pneumoniae Detected in Respiratory Specimen<span class="message-error">*</span>
                                            </td>
                                            <td>
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="q12" CssClass="ddl1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="q12_SelectedIndexChanged">
                                                            <asp:ListItem Selected="True" Value="0">Please Select</asp:ListItem>
                                                            <asp:ListItem Value="1">Yes</asp:ListItem>
                                                            <asp:ListItem Value="2">No</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: top;">Optochin zone size<span class="message-error">*</span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="q13" runat="server" MaxLength="5" CssClass="text-caps1" Text="" onkeypress="return numeralsOnly(event)"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: top;">Bile Solubility<span class="message-error">*</span>
                                            </td>
                                            <td>
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="q14" CssClass="ddl1" runat="server">
                                                            <asp:ListItem Selected="True" Value="0">Please Select</asp:ListItem>
                                                            <asp:ListItem Value="1">POS</asp:ListItem>
                                                            <asp:ListItem Value="2">NEG</asp:ListItem>
                                                            <asp:ListItem Value="9">NOT APPLICABLE</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: middle;">Chloramphenicol (30 µg)<span class="message-error">*</span>
                                            </td>
                                            <td>
                                                <table style="padding: 0px 0px 0px 0px; vertical-align: middle;">
                                                    <tr>
                                                        <td style="vertical-align: middle;">
                                                            <asp:TextBox ID="q15a1" runat="server" CssClass="text-caps" Text="" onkeypress="return numeralsOnly(event)" OnTextChanged="q15a1_TextChanged"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="q15b1" runat="server" CssClass="text-caps" Visible="false" Enabled="false" Text="" onkeypress="return numeralsOnly(event)"></asp:TextBox>
                                                            <table style="padding: 0px 0px 0px 0px">
                                                                <tr>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q15c1_1" runat="server" GroupName="rdo71" Text="S" OnCheckedChanged="q15c1_1_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q15c1_2" runat="server" GroupName="rdo71" Text="I" OnCheckedChanged="q15c1_2_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q15c1_3" runat="server" GroupName="rdo71" Text="R" OnCheckedChanged="q15c1_3_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: middle;">Erythromycin (15 µg)<span class="message-error">*</span>
                                            </td>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="q15a2" runat="server" CssClass="text-caps" Text="" onkeypress="return numeralsOnly(event)"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="q15b2" runat="server" CssClass="text-caps" Text="" Visible="false" Enabled="false" onkeypress="return numeralsOnly(event)"></asp:TextBox>
                                                            <table>
                                                                <tr>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q15c2_111" runat="server" GroupName="rdo2" Text="S" OnCheckedChanged="q15c2_111_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q15c2_112" runat="server" GroupName="rdo2" Text="I" OnCheckedChanged="q15c2_112_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q15c2_113" runat="server" GroupName="rdo2" Text="R" OnCheckedChanged="q15c2_113_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: middle;">Oxacillin (1 µg)<span class="message-error">*</span>
                                            </td>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="q15a3" runat="server" CssClass="text-caps" Text="" onkeypress="return numeralsOnly(event)"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="q15b3" runat="server" CssClass="text-caps" Text="" Visible="false" Enabled="false" onkeypress="return numeralsOnly(event)"></asp:TextBox>
                                                            <table>
                                                                <tr>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q15c3_120" runat="server" GroupName="rdo3" Text="S" OnCheckedChanged="q15c3_120_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q15c3_121" runat="server" GroupName="rdo3" Text="I" OnCheckedChanged="q15c3_121_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q15c3_122" runat="server" GroupName="rdo3" Text="R" OnCheckedChanged="q15c3_122_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: middle;">Ofloxacin (5 µg)<span class="message-error">*</span>
                                            </td>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="q15a4" runat="server" CssClass="text-caps" Text="" onkeypress="return numeralsOnly(event)"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="q15b4" runat="server" CssClass="text-caps" Text="" Visible="false" Enabled="false" onkeypress="return numeralsOnly(event)"></asp:TextBox>
                                                            <table>
                                                                <tr>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q15c4_130" runat="server" GroupName="rdo4" Text="S" OnCheckedChanged="q15c4_130_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q15c4_131" runat="server" GroupName="rdo4" Text="I" OnCheckedChanged="q15c4_131_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q15c4_132" runat="server" GroupName="rdo4" Text="R" OnCheckedChanged="q15c4_132_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: middle;">Cotrimoxazole (25 µg)<span class="message-error">*</span>
                                            </td>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="q15a5" runat="server" CssClass="text-caps" Text="" onkeypress="return numeralsOnly(event)"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="q15b5" runat="server" CssClass="text-caps" Text="" Visible="false" Enabled="false" onkeypress="return numeralsOnly(event)"></asp:TextBox>
                                                            <table>
                                                                <tr>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q15c5_140" runat="server" GroupName="rdo5" Text="S" OnCheckedChanged="q15c5_140_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q15c5_141" runat="server" GroupName="rdo5" Text="I" OnCheckedChanged="q15c5_141_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q15c5_142" runat="server" GroupName="rdo5" Text="R" OnCheckedChanged="q15c5_142_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: middle;">Tetracycline (30 µg)<span class="message-error">*</span>
                                            </td>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="q15a6" runat="server" CssClass="text-caps" Text="" onkeypress="return numeralsOnly(event)"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="q15b6" runat="server" CssClass="text-caps" Text="" Visible="false" Enabled="false" onkeypress="return numeralsOnly(event)"></asp:TextBox>
                                                            <table>
                                                                <tr>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q15c6_150" runat="server" GroupName="rdo6" Text="S" OnCheckedChanged="q15c6_150_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q15c6_151" runat="server" GroupName="rdo6" Text="I" OnCheckedChanged="q15c6_151_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q15c6_152" runat="server" GroupName="rdo6" Text="R" OnCheckedChanged="q15c6_152_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: middle;">Vancomycin (30 µg)<span class="message-error">*</span>
                                            </td>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="q15a7" runat="server" CssClass="text-caps" Text="" onkeypress="return numeralsOnly(event)"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="q15b7" runat="server" CssClass="text-caps" Text="" Visible="false" Enabled="false" onkeypress="return numeralsOnly(event)"></asp:TextBox>
                                                            <table>
                                                                <tr>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q15c7_160" runat="server" GroupName="rdo7" Text="S" OnCheckedChanged="q15c7_160_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q15c7_161" runat="server" GroupName="rdo7" Text="I" OnCheckedChanged="q15c7_161_CheckedChanged" CausesValidation="True" />
                                                                    </td>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q15c7_162" runat="server" GroupName="rdo7" Text="R" OnCheckedChanged="q15c7_162_CheckedChanged" CausesValidation="True" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: middle;">Penicillin (non- meningitis) (MIC)<span class="message-error">*</span>
                                            </td>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="q16signa1" CssClass="ddl" runat="server" AutoPostBack="True">
                                                                <asp:ListItem Selected="True" Value="0">Please Select Sign</asp:ListItem>
                                                                <asp:ListItem Value="1"><</asp:ListItem>
                                                                <asp:ListItem Value="2">></asp:ListItem>
                                                                <asp:ListItem Value="3">=</asp:ListItem>
                                                                <asp:ListItem Value="4">>=</asp:ListItem>
                                                                <asp:ListItem Value="5"><=</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="q16a1" runat="server" CssClass="text-caps" Text="" onkeypress="return numeralsOnly_decimal(event)"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="q16b1" runat="server" CssClass="text-caps" Text="" Visible="false" Enabled="false" onkeypress="return numeralsOnly_decimal(event)"></asp:TextBox>
                                                            <table>
                                                                <tr>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q16c1_170" runat="server" GroupName="rdo8" Text="S" OnCheckedChanged="q16c1_170_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q16c1_171" runat="server" GroupName="rdo8" Text="I" OnCheckedChanged="q16c1_171_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q16c1_172" runat="server" GroupName="rdo8" Text="R" OnCheckedChanged="q16c1_172_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: middle;">Ceftriaxone (non- meningitis) (MIC)<span class="message-error">*</span>
                                            </td>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="q16signa2" CssClass="ddl" runat="server" AutoPostBack="True">
                                                                <asp:ListItem Selected="True" Value="0">Please Select Sign</asp:ListItem>
                                                                <asp:ListItem Value="1"><</asp:ListItem>
                                                                <asp:ListItem Value="2">></asp:ListItem>
                                                                <asp:ListItem Value="3">=</asp:ListItem>
                                                                <asp:ListItem Value="4">>=</asp:ListItem>
                                                                <asp:ListItem Value="5"><=</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="q16a2" runat="server" CssClass="text-caps" Text="" onkeypress="return numeralsOnly_decimal(event)"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="q16b2" runat="server" CssClass="text-caps" Text="" Visible="false" Enabled="false" onkeypress="return numeralsOnly_decimal(event)"></asp:TextBox>
                                                            <table>
                                                                <tr>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q16c2_180" runat="server" GroupName="rdo9" Text="S" OnCheckedChanged="q16c2_180_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q16c2_181" runat="server" GroupName="rdo9" Text="I" OnCheckedChanged="q16c2_181_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q16c2_182" runat="server" GroupName="rdo9" Text="R" OnCheckedChanged="q16c2_182_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: middle;">Vancomycin (MIC)<span class="message-error">*</span>
                                            </td>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="q16signa3" CssClass="ddl" runat="server" AutoPostBack="True">
                                                                <asp:ListItem Selected="True" Value="0">Please Select Sign</asp:ListItem>
                                                                <asp:ListItem Value="1"><</asp:ListItem>
                                                                <asp:ListItem Value="2">></asp:ListItem>
                                                                <asp:ListItem Value="3">=</asp:ListItem>
                                                                <asp:ListItem Value="4">>=</asp:ListItem>
                                                                <asp:ListItem Value="5"><=</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="q16a3" runat="server" CssClass="text-caps" Text="" onkeypress="return numeralsOnly_decimal(event)"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="q16b3" runat="server" CssClass="text-caps" Text="" Visible="false" Enabled="false" onkeypress="return numeralsOnly_decimal(event)"></asp:TextBox>
                                                            <table>
                                                                <tr>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q16c3_190" runat="server" GroupName="rdo10" Text="S" OnCheckedChanged="q16c3_190_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q16c3_191" runat="server" GroupName="rdo10" Text="I" OnCheckedChanged="q16c3_191_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q16c3_192" runat="server" GroupName="rdo10" Text="R" OnCheckedChanged="q16c3_192_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: middle;">Staphylococcus aureus Detected in Respiratory Specimen<span class="message-error">*</span>
                                            </td>
                                            <td>
                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="q16c" CssClass="ddl1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="q16c_SelectedIndexChanged">
                                                            <asp:ListItem Selected="True" Value="0">Please Select</asp:ListItem>
                                                            <asp:ListItem Value="1">Yes</asp:ListItem>
                                                            <asp:ListItem Value="2">No</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: middle;">Amikacin (30 µg)<span class="message-error">*</span>
                                            </td>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="q17a1" runat="server" CssClass="text-caps" Text="" onkeypress="return numeralsOnly(event)"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="q17b1" runat="server" CssClass="text-caps" Text="" Visible="false" Enabled="false" onkeypress="return numeralsOnly(event)"></asp:TextBox>
                                                            <table>
                                                                <tr>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q17c1_200" runat="server" GroupName="rdo11" Text="S" OnCheckedChanged="q17c1_200_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q17c1_201" runat="server" GroupName="rdo11" Text="I" OnCheckedChanged="q17c1_201_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q17c1_202" runat="server" GroupName="rdo11" Text="R" OnCheckedChanged="q17c1_202_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: middle;">Chloramphenicol (30 µg)<span class="message-error">*</span>
                                            </td>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="q17a2" runat="server" CssClass="text-caps" Text="" onkeypress="return numeralsOnly(event)"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="q17b2" runat="server" CssClass="text-caps" Text="" Visible="false" Enabled="false" onkeypress="return numeralsOnly(event)"></asp:TextBox>
                                                            <table>
                                                                <tr>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q17c2_300" runat="server" GroupName="rdo12" Text="S" OnCheckedChanged="q17c2_300_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q17c2_301" runat="server" GroupName="rdo12" Text="I" OnCheckedChanged="q17c2_301_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q17c2_302" runat="server" GroupName="rdo12" Text="R" OnCheckedChanged="q17c2_302_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: middle;">Clindamycin (2 µg)<span class="message-error">*</span>
                                            </td>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="q17a99" runat="server" CssClass="text-caps" Text="" onkeypress="return numeralsOnly(event)"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="q17b99" runat="server" CssClass="text-caps" Text="" Visible="false" Enabled="false" onkeypress="return numeralsOnly(event)"></asp:TextBox>
                                                            <table>
                                                                <tr>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q17c3_303" runat="server" GroupName="rdo13" Text="S" OnCheckedChanged="q17c3_303_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q17c3_304" runat="server" GroupName="rdo13" Text="I" OnCheckedChanged="q17c3_304_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q17c3_305" runat="server" GroupName="rdo13" Text="R" OnCheckedChanged="q17c3_305_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: middle;">Gentamycin (10µg)<span class="message-error">*</span>
                                            </td>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="q17a3" runat="server" CssClass="text-caps" Text="" onkeypress="return numeralsOnly(event)"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="q17b3" runat="server" CssClass="text-caps" Text="" Visible="false" Enabled="false" onkeypress="return numeralsOnly(event)"></asp:TextBox>
                                                            <table>
                                                                <tr>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q17c4_306" runat="server" GroupName="rdo14" Text="S" OnCheckedChanged="q17c4_306_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q17c4_307" runat="server" GroupName="rdo14" Text="I" OnCheckedChanged="q17c4_307_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q17c4_308" runat="server" GroupName="rdo14" Text="R" OnCheckedChanged="q17c4_308_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: middle;">Erythromycin (15 µg)<span class="message-error">*</span>
                                            </td>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="q17a4" runat="server" CssClass="text-caps" Text="" onkeypress="return numeralsOnly(event)"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="q17b4" runat="server" CssClass="text-caps" Text="" Visible="false" Enabled="false" onkeypress="return numeralsOnly(event)"></asp:TextBox>
                                                            <table>
                                                                <tr>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q17c5_309" runat="server" GroupName="rdo15" Text="S" OnCheckedChanged="q17c5_309_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q17c5_400" runat="server" GroupName="rdo15" Text="I" OnCheckedChanged="q17c5_400_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q17c5_401" runat="server" GroupName="rdo15" Text="R" OnCheckedChanged="q17c5_401_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: middle;">Fusidic Acid (10 µg)<span class="message-error">*</span>
                                            </td>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="q17a5" runat="server" CssClass="text-caps" Text="" onkeypress="return numeralsOnly(event)"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="q17b5" runat="server" CssClass="text-caps" Text="" Visible="false" Enabled="false" onkeypress="return numeralsOnly(event)"></asp:TextBox>
                                                            <table>
                                                                <tr>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q17c6_402" runat="server" GroupName="rdo16" Text="S" OnCheckedChanged="q17c6_402_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q17c6_403" runat="server" GroupName="rdo16" Text="I" OnCheckedChanged="q17c6_403_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q17c6_404" runat="server" GroupName="rdo16" Text="R" OnCheckedChanged="q17c6_404_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: middle;">Oxacillin (1 µg)<span class="message-error">*</span>
                                            </td>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="q17a6" runat="server" CssClass="text-caps" Text="" onkeypress="return numeralsOnly(event)"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="q17b6" runat="server" CssClass="text-caps" Text="" Visible="false" Enabled="false" onkeypress="return numeralsOnly(event)"></asp:TextBox>
                                                            <table>
                                                                <tr>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q17c7_405" runat="server" GroupName="rdo17" Text="S" OnCheckedChanged="q17c7_405_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q17c7_406" runat="server" GroupName="rdo17" Text="I" OnCheckedChanged="q17c7_406_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q17c7_407" runat="server" GroupName="rdo17" Text="R" OnCheckedChanged="q17c7_407_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: middle;">Ciprofloxacin (5 µg)<span class="message-error">*</span>
                                            </td>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="q17a7" runat="server" CssClass="text-caps" Text="" onkeypress="return numeralsOnly(event)"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="q17b7" runat="server" CssClass="text-caps" Text="" Visible="false" Enabled="false" onkeypress="return numeralsOnly(event)"></asp:TextBox>
                                                            <table>
                                                                <tr>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q17c8_408" runat="server" GroupName="rdo18" Text="S" OnCheckedChanged="q17c8_408_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q17c8_409" runat="server" GroupName="rdo18" Text="I" OnCheckedChanged="q17c8_409_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q17c8_410" runat="server" GroupName="rdo18" Text="R" OnCheckedChanged="q17c8_410_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: middle;">Penicillin (10 µg)<span class="message-error">*</span>
                                            </td>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="q17a8" runat="server" CssClass="text-caps" Text="" onkeypress="return numeralsOnly(event)"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="q17b8" runat="server" CssClass="text-caps" Text="" Visible="false" Enabled="false" onkeypress="return numeralsOnly(event)"></asp:TextBox>
                                                            <table>
                                                                <tr>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q17c9_411" runat="server" GroupName="rdo19" Text="S" OnCheckedChanged="q17c9_411_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q17c9_412" runat="server" GroupName="rdo19" Text="I" OnCheckedChanged="q17c9_412_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q17c9_413" runat="server" GroupName="rdo19" Text="R" OnCheckedChanged="q17c9_413_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: middle;">Cotrimoxazole (25 µg)<span class="message-error">*</span>
                                            </td>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="q17a9" runat="server" CssClass="text-caps" Text="" onkeypress="return numeralsOnly(event)"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="q17b9" runat="server" CssClass="text-caps" Text="" Visible="false" Enabled="false" onkeypress="return numeralsOnly(event)"></asp:TextBox>
                                                            <table>
                                                                <tr>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q17c10_414" runat="server" GroupName="rdo20" Text="S" OnCheckedChanged="q17c10_414_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q17c10_415" runat="server" GroupName="rdo20" Text="I" OnCheckedChanged="q17c10_415_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q17c10_416" runat="server" GroupName="rdo20" Text="R" OnCheckedChanged="q17c10_416_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: middle;">Tetracycline (30 µg)<span class="message-error">*</span>
                                            </td>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="q17a10" runat="server" CssClass="text-caps" Text="" onkeypress="return numeralsOnly(event)"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="q17b10" runat="server" CssClass="text-caps" Text="" Visible="false" Enabled="false" onkeypress="return numeralsOnly(event)"></asp:TextBox>
                                                            <table>
                                                                <tr>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q17c11_417" runat="server" GroupName="rdo21" Text="S" OnCheckedChanged="q17c11_417_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q17c11_418" runat="server" GroupName="rdo21" Text="I" OnCheckedChanged="q17c11_418_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q17c11_419" runat="server" GroupName="rdo21" Text="R" OnCheckedChanged="q17c11_419_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: middle;">Vancomycin (MIC) (Staphylococcus aureus ATCC29213 value S=≤2  I=4-8 R=≥16)<span class="message-error">*</span>
                                            </td>
                                            <td style="vertical-align: top;">
                                                <table style="width: 550px;">
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="q18signa1" CssClass="ddl" runat="server" AutoPostBack="True">
                                                                <asp:ListItem Selected="True" Value="0">Please Select Sign</asp:ListItem>
                                                                <asp:ListItem Value="1"><</asp:ListItem>
                                                                <asp:ListItem Value="2">></asp:ListItem>
                                                                <asp:ListItem Value="3">=</asp:ListItem>
                                                                <asp:ListItem Value="4">>=</asp:ListItem>
                                                                <asp:ListItem Value="5"><=</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="q18a1" runat="server" CssClass="text-caps" Text="" onkeypress="return numeralsOnly_decimal(event)"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="q18b1" runat="server" CssClass="text-caps" Text="" Visible="false" Enabled="false" onkeypress="return numeralsOnly_decimal(event)" OnTextChanged="q18b1_TextChanged"></asp:TextBox>
                                                            <table>
                                                                <tr>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q18c1_420" runat="server" GroupName="rdo22" Text="S" OnCheckedChanged="q18c1_420_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q18c1_421" runat="server" GroupName="rdo22" Text="I" OnCheckedChanged="q18c1_421_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                    <td style="padding: 0px 0px 0px 0px">
                                                                        <asp:RadioButton ID="q18c1_422" runat="server" GroupName="rdo22" Text="R" OnCheckedChanged="q18c1_422_CheckedChanged" AutoPostBack="True" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: top;">Conventional Multiplex PCR For Serotyping Done<span class="message-error">*</span>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="q19" CssClass="ddl1" runat="server" OnSelectedIndexChanged="q19_SelectedIndexChanged" AutoPostBack="True">
                                                    <asp:ListItem Selected="True" Value="0">Please Select</asp:ListItem>
                                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                                    <asp:ListItem Value="2">No</asp:ListItem>
                                                    <asp:ListItem Value="9">NA</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">Sequential Multiplex PCR for Pneumococcal Serotyping</td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <table>
                                        <tr>
                                            <td style="text-align: left;">
                                                <table style="padding: 0px 0px 0px 0px">
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="q20_1" GroupName="rdo" runat="server" Text="6A/6B/6C/6D" Width="270px" OnCheckedChanged="q20_1_CheckedChanged" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="q20_2" GroupName="rdo" runat="server" Text="3" OnCheckedChanged="q20_2_CheckedChanged" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="q20_3" GroupName="rdo" runat="server" Text="19A" OnCheckedChanged="q20_3_CheckedChanged" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="q20_4" GroupName="rdo" runat="server" Text="22F/22A" OnCheckedChanged="q20_4_CheckedChanged" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="q20_5" GroupName="rdo" runat="server" Text="16F" OnCheckedChanged="q20_5_CheckedChanged" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="q20_6" GroupName="rdo" runat="server" Text="8" OnCheckedChanged="q20_6_CheckedChanged" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="q20_7" GroupName="rdo" runat="server" Text="33F/33A/37" OnCheckedChanged="q20_7_CheckedChanged" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="q20_8" GroupName="rdo" runat="server" Text="15A/15F" OnCheckedChanged="q20_8_CheckedChanged" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="q20_9" GroupName="rdo" runat="server" Text="7F/7A" OnCheckedChanged="q20_9_CheckedChanged" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="q20_10" GroupName="rdo" runat="server" Text="23A" OnCheckedChanged="q20_10_CheckedChanged" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                                <table style="padding: 0px 0px 0px 0px">
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="q20_11" GroupName="rdo" runat="server" Text="19F" Width="316px" OnCheckedChanged="q20_11_CheckedChanged" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="q20_12" GroupName="rdo" runat="server" Text="12F/12A/44/46" OnCheckedChanged="q20_12_CheckedChanged" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="q20_13" GroupName="rdo" runat="server" Text="11A/11D" OnCheckedChanged="q20_13_CheckedChanged" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="q20_14" GroupName="rdo" runat="server" Text="38/25F/25A" OnCheckedChanged="q20_14_CheckedChanged" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="q20_15" GroupName="rdo" runat="server" Text="35B" OnCheckedChanged="q20_15_CheckedChanged" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="q20_16" GroupName="rdo" runat="server" Text="24F/24A/24B" OnCheckedChanged="q20_16_CheckedChanged" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="q20_17" GroupName="rdo" runat="server" Text="7C/7B/40" OnCheckedChanged="q20_17_CheckedChanged" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="q20_18" GroupName="rdo" runat="server" Text="4" OnCheckedChanged="q20_18_CheckedChanged" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="q20_19" GroupName="rdo" runat="server" Text="18C/18F/18B/18A" OnCheckedChanged="q20_19_CheckedChanged" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="q20_20" GroupName="rdo" runat="server" Text="9V/9A" OnCheckedChanged="q20_20_CheckedChanged" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                                <table style="padding: 0px 0px 0px 0px">
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="q20_21" GroupName="rdo" runat="server" Text="14" Width="266px" OnCheckedChanged="q20_21_CheckedChanged" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="q20_22" GroupName="rdo" runat="server" Text="1" OnCheckedChanged="q20_22_CheckedChanged" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="q20_23" GroupName="rdo" runat="server" Text="23F" OnCheckedChanged="q20_23_CheckedChanged" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="q20_24" GroupName="rdo" runat="server" Text="15B/15C" OnCheckedChanged="q20_24_CheckedChanged" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="q20_25" GroupName="rdo" runat="server" Text="10A" OnCheckedChanged="q20_25_CheckedChanged" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="q20_26" GroupName="rdo" runat="server" Text="39" OnCheckedChanged="q20_26_CheckedChanged" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="q20_27" GroupName="rdo" runat="server" Text="10F/10C/33C" OnCheckedChanged="q20_27_CheckedChanged" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="q20_28" GroupName="rdo" runat="server" Text="5" OnCheckedChanged="q20_28_CheckedChanged" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="q20_29" GroupName="rdo" runat="server" Text="35F/47F" OnCheckedChanged="q20_29_CheckedChanged" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="q20_30" GroupName="rdo" runat="server" Text="17F" OnCheckedChanged="q20_30_CheckedChanged" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                                <table style="padding: 0px 0px 0px 0px; width: 192px;">
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="q20_31" GroupName="rdo" runat="server" Text="23B" Width="265px" OnCheckedChanged="q20_31_CheckedChanged" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="q20_32" GroupName="rdo" runat="server" Text="35A/35C/42" OnCheckedChanged="q20_32_CheckedChanged" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="q20_33" GroupName="rdo" runat="server" Text="34" OnCheckedChanged="q20_33_CheckedChanged" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="q20_34" GroupName="rdo" runat="server" Text="9N/9L" OnCheckedChanged="q20_34_CheckedChanged" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="q20_35" GroupName="rdo" runat="server" Text="31" OnCheckedChanged="q20_35_CheckedChanged" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="q20_36" GroupName="rdo" runat="server" Text="21" OnCheckedChanged="q20_36_CheckedChanged" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="q20_37" GroupName="rdo" runat="server" Text="2" OnCheckedChanged="q20_37_CheckedChanged" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="q20_38" GroupName="rdo" runat="server" Text="20" OnCheckedChanged="q20_38_CheckedChanged" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="q20_39" GroupName="rdo" runat="server" Text="13" OnCheckedChanged="q20_39_CheckedChanged" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="q20_40" GroupName="rdo" runat="server" Text="NON TYPEABLE" OnCheckedChanged="q20_40_CheckedChanged" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td colspan="2">PCR for Pneumococcal Serogroup 6A/6B/6C/6D resolution</td>
                                                        <td colspan="2">
                                                            <asp:DropDownList ID="q21" CssClass="ddl1" runat="server">
                                                                <asp:ListItem Selected="True" Value="0">Please Select</asp:ListItem>
                                                                <asp:ListItem Value="1">6A</asp:ListItem>
                                                                <asp:ListItem Value="2">6B</asp:ListItem>
                                                                <asp:ListItem Value="3">6C</asp:ListItem>
                                                                <asp:ListItem Value="4">6D</asp:ListItem>
                                                                <asp:ListItem Value="9">NA</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">Monoplex PCR for Serotype confirmation</td>
                                                        <td colspan="2">
                                                            <asp:DropDownList ID="q22" CssClass="ddl1" runat="server">
                                                                <asp:ListItem Selected="True" Value="0">Please Select</asp:ListItem>
                                                                <asp:ListItem Value="1">Confirmed</asp:ListItem>
                                                                <asp:ListItem Value="2">Not Confirmed</asp:ListItem>
                                                                <asp:ListItem Value="9">NA</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">Final Results</td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <table>
                                                    <tr>
                                                        <td style="text-align: left;">
                                                            <table style="padding: 0px 0px 0px 0px">
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="q23_1" GroupName="rdo1" runat="server" Text="6A/6B/6C/6D" Width="270px" OnCheckedChanged="q23_1_CheckedChanged" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="q23_2" GroupName="rdo1" runat="server" Text="3" OnCheckedChanged="q23_2_CheckedChanged" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="q23_3" GroupName="rdo1" runat="server" Text="19A" OnCheckedChanged="q23_3_CheckedChanged" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="q23_4" GroupName="rdo1" runat="server" Text="22F/22A" OnCheckedChanged="q23_4_CheckedChanged" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="q23_5" GroupName="rdo1" runat="server" Text="16F" OnCheckedChanged="q23_5_CheckedChanged" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="q23_6" GroupName="rdo1" runat="server" Text="8" OnCheckedChanged="q23_6_CheckedChanged" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="q23_7" GroupName="rdo1" runat="server" Text="33F/33A/37" OnCheckedChanged="q23_7_CheckedChanged" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="q23_8" GroupName="rdo1" runat="server" Text="15A/15F" OnCheckedChanged="q23_8_CheckedChanged" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="q23_9" GroupName="rdo1" runat="server" Text="7F/7A" OnCheckedChanged="q23_9_CheckedChanged" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="q23_10" GroupName="rdo1" runat="server" Text="23A" OnCheckedChanged="q23_10_CheckedChanged" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="q23_10a" GroupName="rdo1" runat="server" Text="6A" OnCheckedChanged="q23_10a_CheckedChanged" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td>
                                                            <table style="padding: 0px 0px 0px 0px">
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="q23_11" GroupName="rdo1" runat="server" Text="19F" Width="316px" OnCheckedChanged="q23_11_CheckedChanged" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="q23_12" GroupName="rdo1" runat="server" Text="12F/12A/44/46" OnCheckedChanged="q23_12_CheckedChanged" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="q23_13" GroupName="rdo1" runat="server" Text="11A/11D" OnCheckedChanged="q23_13_CheckedChanged" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="q23_14" GroupName="rdo1" runat="server" Text="38/25F/25A" OnCheckedChanged="q23_14_CheckedChanged" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="q23_15" GroupName="rdo1" runat="server" Text="35B" OnCheckedChanged="q23_15_CheckedChanged" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="q23_16" GroupName="rdo1" runat="server" Text="24F/24A/24B" OnCheckedChanged="q23_16_CheckedChanged" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="q23_17" GroupName="rdo1" runat="server" Text="7C/7B/40" OnCheckedChanged="q23_17_CheckedChanged" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="q23_18" GroupName="rdo1" runat="server" Text="4" OnCheckedChanged="q23_18_CheckedChanged" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="q23_19" GroupName="rdo1" runat="server" Text="18C/18F/18B/18A" OnCheckedChanged="q23_19_CheckedChanged" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="q23_20" GroupName="rdo1" runat="server" Text="9V/9A" OnCheckedChanged="q23_20_CheckedChanged" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="q23_20a" GroupName="rdo1" runat="server" Text="6B" OnCheckedChanged="q23_20a_CheckedChanged" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td>
                                                            <table style="padding: 0px 0px 0px 0px">
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="q23_21" GroupName="rdo1" runat="server" Text="14" Width="266px" OnCheckedChanged="q23_21_CheckedChanged" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="q23_22" GroupName="rdo1" runat="server" Text="1" OnCheckedChanged="q23_22_CheckedChanged" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="q23_23" GroupName="rdo1" runat="server" Text="23F" OnCheckedChanged="q23_23_CheckedChanged" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="q23_24" GroupName="rdo1" runat="server" Text="15B/15C" OnCheckedChanged="q23_24_CheckedChanged" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="q23_25" GroupName="rdo1" runat="server" Text="10A" OnCheckedChanged="q23_25_CheckedChanged" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="q23_26" GroupName="rdo1" runat="server" Text="39" OnCheckedChanged="q23_26_CheckedChanged" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="q23_27" GroupName="rdo1" runat="server" Text="10F/10C/33C" OnCheckedChanged="q23_27_CheckedChanged" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="q23_28" GroupName="rdo1" runat="server" Text="5" OnCheckedChanged="q23_28_CheckedChanged" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="q23_29" GroupName="rdo1" runat="server" Text="35F/47F" OnCheckedChanged="q23_29_CheckedChanged" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="q23_30" GroupName="rdo1" runat="server" Text="17F" OnCheckedChanged="q23_30_CheckedChanged" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="q23_30a" GroupName="rdo1" runat="server" Text="6C" OnCheckedChanged="q23_30a_CheckedChanged" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td>
                                                            <table style="padding: 0px 0px 0px 0px; width: 192px;">
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="q23_31" GroupName="rdo1" runat="server" Text="23B" Width="265px" OnCheckedChanged="q23_31_CheckedChanged" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="q23_32" GroupName="rdo1" runat="server" Text="35A/35C/42" OnCheckedChanged="q23_32_CheckedChanged" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="q23_33" GroupName="rdo1" runat="server" Text="34" OnCheckedChanged="q23_33_CheckedChanged" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="q23_34" GroupName="rdo1" runat="server" Text="9N/9L" OnCheckedChanged="q23_34_CheckedChanged" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="q23_35" GroupName="rdo1" runat="server" Text="31" OnCheckedChanged="q23_35_CheckedChanged" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="q23_36" GroupName="rdo1" runat="server" Text="21" OnCheckedChanged="q23_36_CheckedChanged" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="q23_37" GroupName="rdo1" runat="server" Text="2" OnCheckedChanged="q23_37_CheckedChanged" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="q23_38" GroupName="rdo1" runat="server" Text="20" OnCheckedChanged="q23_38_CheckedChanged" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="q23_39" GroupName="rdo1" runat="server" Text="13" OnCheckedChanged="q23_39_CheckedChanged" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="q23_40" GroupName="rdo1" runat="server" Text="NON TYPEABLE" OnCheckedChanged="q23_40_CheckedChanged" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="q23_40a" GroupName="rdo1" runat="server" Text="6D" OnCheckedChanged="q23_40a_CheckedChanged" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">Comments
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="Comments" runat="server" TextMode="MultiLine" Width="750px" Height="100px" CssClass="text-caps" Text=""></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <%--<tr>
                        <td style="vertical-align: top;">Conventional Multiplex PCR Serotyping Results<span class="message-error">*</span>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="q20" CssClass="ddl1" runat="server">
                                        <asp:ListItem Selected="True" Value="0">Please Select</asp:ListItem>
                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                        <asp:ListItem Value="2">No</asp:ListItem>
                                        <asp:ListItem Value="9">NA</asp:ListItem>
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;">Serotype Confirmation On Conventional Monoplex PCR<span class="message-error">*</span>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="q21" CssClass="ddl1" runat="server">
                                        <asp:ListItem Selected="True" Value="0">Please Select</asp:ListItem>
                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                        <asp:ListItem Value="2">No</asp:ListItem>
                                        <asp:ListItem Value="9">NA</asp:ListItem>
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;">6A/B/C/D Serogroup Resolution<span class="message-error">*</span>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="q22" CssClass="ddl1" runat="server">
                                        <asp:ListItem Selected="True" Value="0">Please Select</asp:ListItem>
                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                        <asp:ListItem Value="2">No</asp:ListItem>
                                        <asp:ListItem Value="9">NA</asp:ListItem>
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;">6A/B/C/D Serogroup Resolution Results<span class="message-error">*</span>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="q23" CssClass="ddl1" runat="server">
                                        <asp:ListItem Selected="True" Value="0">Please Select</asp:ListItem>
                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                        <asp:ListItem Value="2">No</asp:ListItem>
                                        <asp:ListItem Value="9">NA</asp:ListItem>
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;">Lyt A Real Time PCR done<span class="message-error">*</span>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="q24" CssClass="ddl1" runat="server">
                                        <asp:ListItem Selected="True" Value="0">Please Select</asp:ListItem>
                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                        <asp:ListItem Value="2">No</asp:ListItem>
                                        <asp:ListItem Value="9">NA</asp:ListItem>
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;">Lyt A Real Time PCR Result<span class="message-error">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="q25" CssClass="ddl1" runat="server" OnSelectedIndexChanged="q25_SelectedIndexChanged" AutoPostBack="True">
                                <asp:ListItem Selected="True" Value="0">Please Select</asp:ListItem>
                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                <asp:ListItem Value="2">No</asp:ListItem>
                                <asp:ListItem Value="9">NA</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;">If Lyt A Real Time PCR Positive<span class="message-error">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="q26" runat="server" CssClass="text-caps" Enabled="false" Text="" onkeypress="return numeralsOnly(event)"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;">Serotype Detected As<span class="message-error">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="q27" runat="server" CssClass="text-caps" Text="" onkeypress="return lettersOnly_WithSpace(event)"></asp:TextBox>
                        </td>
                    </tr>--%>
                            <tr>
                                <td colspan="4" style="text-align: center">
                                    <asp:Button ID="cmdSave" runat="server" Text="  Save " OnClick="cmdSave_Click" />
                                    <asp:Button ID="cmdCancel" runat="server" Text="Cancel" OnClick="cmdCancel_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
