<%@ Page Title="" Language="C#" MasterPageFile="~/Site_S.Master" AutoEventWireup="true" CodeBehind="searchpatient.aspx.cs" Inherits="PCV13_LabSystem.searchpatient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>

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

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblerr" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table>
                    <tr>
                        <td>Select Form</td>
                        <td>
                            <asp:DropDownList ID="ddl_frm" CssClass="ddl1" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>Study ID
                        </td>
                        <td>
                            <asp:TextBox ID="studyid" MaxLength="10" runat="server" CssClass="text-caps" onkeypress="return numeralsOnly(event)" Text=""></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="cmdSearch" runat="server" Text="Search" OnClick="cmdSearch_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="text-align: right">
                            <asp:Button ID="cmdAddRecord" runat="server" Text="Add Record" Visible="false" OnClick="cmdAddRecord_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="DG_Request" Name="DG_Request" runat="server" AllowPaging="True" AutoGenerateColumns="False" Width="1167px" BorderColor="#00CC66" BorderStyle="Solid" BorderWidth="2px" PageSize="20" OnRowCommand="DG_Request_RowCommand" OnRowEditing="DG_Request_RowEditing" OnRowDeleting="DG_Request_RowDeleting" OnPageIndexChanging="DG_Request_PageIndexChanging">
                    <AlternatingRowStyle BackColor="#8fe1af" />
                    <Columns>
                        <asp:BoundField DataField="studyid" Visible="False" />
                        <asp:TemplateField HeaderText="studyid" Visible="False">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Enabled="False" BackColor="Silver" Text='<%# Bind("studyid") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("studyid") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle BackColor="#278A05" BorderColor="#278A05" Font-Names="Verdana" Font-Size="8pt" ForeColor="#000FFF" HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Child ID">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("childid") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label7" runat="server" Text='<%# Bind("childid") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle BackColor="#278A05" BorderColor="#278A05" Font-Names="Verdana" Font-Size="8pt" ForeColor="White" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Physician Name">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox5" runat="server" CssClass="txtbox" Text='<%# Bind("q2") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("q2") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle BackColor="#278A05" BorderColor="#278A05" Font-Names="Verdana" Font-Size="8pt" ForeColor="White" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mother Name">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" CssClass="txtbox" Text='<%# Bind("q3") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label11" runat="server" Text='<%# Bind("q3") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle BackColor="#278a05" BorderColor="#278a05" Font-Names="Verdana" Font-Size="8pt" ForeColor="White" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Child Name">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" CssClass="txtbox" Text='<%# Bind("q3a") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("q3a") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle BackColor="#278a05" BorderColor="#278a05" Font-Names="Verdana" Font-Size="8pt" ForeColor="White" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Collection Date">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" CssClass="txtbox" Text='<%# Bind("q5dta") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("q5dta") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle BackColor="#278A05" BorderColor="#278A05" Font-Names="Verdana" Font-Size="8pt" ForeColor="White" />
                        </asp:TemplateField>
                        <%--<asp:TemplateField HeaderText="Writ Off Form No">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox657" runat="server" CssClass="txtbox" Text='<%# Bind("WRITOFF_FORMNO") %>' Enabled="False"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label678" runat="server" Text='<%# Bind("WRITOFF_FORMNO") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle BackColor="#278A05" BorderColor="#278A05" Font-Names="Verdana" Font-Size="8pt" ForeColor="White" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Writ Off Date">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox616" runat="server" CssClass="txtbox" Text='<%# Bind("WODATE") %>' Enabled="False"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label696" runat="server" Text='<%# Bind("WODATE") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle BackColor="#278A05" BorderColor="#278A05" Font-Names="Verdana" Font-Size="8pt" ForeColor="White" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Remarks">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox6747" runat="server" CssClass="txtbox" Text='<%# Bind("REMARKS") %>' Enabled="False"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label6142" runat="server" Text='<%# Bind("REMARKS") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle BackColor="#278A05" BorderColor="#278A05" Font-Names="Verdana" Font-Size="8pt" ForeColor="White" />
                        </asp:TemplateField>--%>
                        <asp:CommandField ShowSelectButton="True" SelectText="View Detail">
                            <HeaderStyle BackColor="#278A05" BorderColor="#278A05" />
                        </asp:CommandField>
                        <asp:CommandField ShowEditButton="True">
                            <HeaderStyle BackColor="#278A05" BorderColor="#278A05" Font-Names="Verdana" Font-Size="8pt" />
                        </asp:CommandField>
                        <asp:CommandField DeleteText="Sample Collection Form" ShowDeleteButton="True">
                            <HeaderStyle BackColor="#278A05" BorderColor="#278A05" Font-Names="verdana" Font-Size="8pt" />
                        </asp:CommandField>
                    </Columns>
                    <PagerStyle BackColor="#278A05" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="White" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DataList CssClass="mydatalist" ID="dl_Inventory" runat="server" Width="50%" CellPadding="0" CellSpacing="0" GridLines="Vertical">
                    <ItemTemplate>
                        <table border="0" style="width: 100%">
                            <tr>
                                <td colspan="2"></td>
                                <td style="text-align: right">
                                    <asp:ImageButton ID="cmdClose" BackColor="#8fe1af" runat="server" ImageUrl="~/Images/close.gif" Width="15" Height="15" OnClick="cmdClose_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Label ID="Label10" CssClass="text-caps_datalist" runat="server" Text="Child ID"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label12" CssClass="text-caps_datalist" runat="server" Text='<%# Bind("childid") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Label ID="lblPRNO" runat="server" CssClass="text-caps_datalist" Text="Study ID"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPRNOValue" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("studyid") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Label ID="Label13" CssClass="text-caps_datalist" runat="server" Text="DSS ID"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label14" CssClass="text-caps_datalist" runat="server" Text='<%# Bind("dssid") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Label ID="Label15" CssClass="text-caps_datalist" runat="server" Text="Field Site"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label16" CssClass="text-caps_datalist" runat="server" Text='<%# Bind("q1") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Label ID="Label17" CssClass="text-caps_datalist" runat="server" Text="Physician Name"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label18" CssClass="text-caps_datalist" runat="server" Text='<%# Bind("q2") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Label ID="lblPRODUCTNO" CssClass="text-caps_datalist" runat="server" Text="Mother Name"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPRODUCTNOValue" CssClass="text-caps_datalist" runat="server" Text='<%# Bind("q3") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Label ID="Label19" CssClass="text-caps_datalist" runat="server" Text="Child Name"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label20" CssClass="text-caps_datalist" runat="server" Text='<%# Bind("q3a") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Label ID="lblTAGNO" runat="server" CssClass="text-caps_datalist" Text="Nasopharyngeal swab collected"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblTAGNOValue" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q4") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Label ID="Label2169" runat="server" CssClass="text-caps_datalist" Text="Collection Date"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label22142" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q5dt") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Label ID="lblCOST" runat="server" CssClass="text-caps_datalist" Text="Collection Time"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblCOSTValue" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q5t") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Label ID="lblCURRENCY" runat="server" CssClass="text-caps_datalist" Text="Specimen Received"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblCURRENCYValue" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q6") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Label ID="lblEMPNO" runat="server" CssClass="text-caps_datalist" Text="Condition of the STGG Tube (Respiratory Specimen)"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblEMPNOValue" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q7") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td style="text-align: center; color: #278A05" colspan="2">MATIARI LAB
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Label ID="lblUSERNAME" runat="server" CssClass="text-caps_datalist" Text="Temperature of the tube upon arrival at lab"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblUSERNAMEValue" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q8") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Label ID="lblRESPPERSONNAME" runat="server" CssClass="text-caps_datalist" Text="Received Date"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblRESPPERSONNAMEValue" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q9dt") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Label ID="lblPROJECT" runat="server" CssClass="text-caps_datalist" Text="Received Time"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPROJECTValue" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q9t") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Label ID="lblOU" runat="server" CssClass="text-caps_datalist" Text="Name of the laboratory person"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblOUValue" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q10") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Label ID="lblAccount" runat="server" CssClass="text-caps_datalist" Text="Lab Person Code"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblAccountValue" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q10a") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td style="text-align: center; color: #278A05" colspan="2">KARACHI LAB
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Label ID="Label95" runat="server" CssClass="text-caps_datalist" Text="Temperature of the tube upon arrival at lab"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label96" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q8a") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Label ID="Label97" runat="server" CssClass="text-caps_datalist" Text="Received Date"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label98" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q9dt1") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Label ID="Label99" runat="server" CssClass="text-caps_datalist" Text="Received Time"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label100" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q9t") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Label ID="Label101" runat="server" CssClass="text-caps_datalist" Text="Name of the laboratory person"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label102" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q10a1") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Label ID="Label103" runat="server" CssClass="text-caps_datalist" Text="Lab Person Code"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label104" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q10a2") %>'></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <AlternatingItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="False" />
                    <HeaderTemplate>
                        <span style="font-size: 10pt; color: #278A05; font-family: Tahoma">
                            <table style="text-align: center; vertical-align: middle; width: 100%; padding: 5px 0px 5px 0px">
                                <tr>
                                    <td>Detail of Receiving Sample</td>
                                </tr>
                            </table>
                        </span>
                    </HeaderTemplate>
                    <SeparatorTemplate>
                        <hr />
                    </SeparatorTemplate>
                </asp:DataList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DataList CssClass="mydatalist" ID="dl_specimen_entry" runat="server" Width="55%" CellPadding="0" CellSpacing="0" GridLines="Vertical">
                    <ItemTemplate>
                        <table border="0" style="width: 100%">
                            <tr>
                                <td colspan="3"></td>
                                <td style="text-align: right">
                                    <asp:ImageButton ID="cmdClose1" BackColor="#8fe1af" runat="server" ImageUrl="~/Images/close.gif" Width="15" Height="15" OnClick="cmdClose1_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Label ID="lbl_studyid" runat="server" CssClass="text-caps_datalist" Text="Study ID"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_studyida" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("studyid") %>'></asp:Label>
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Label ID="lbl_childid" CssClass="text-caps_datalist" runat="server" Text="Child ID"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_childida" CssClass="text-caps_datalist" runat="server" Text='<%# Bind("childid") %>'></asp:Label>
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Panel ID="pnl_receiving" runat="server">
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Label ID="lbl_fieldsite" CssClass="text-caps_datalist" runat="server" Text="Field Site"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_fieldsitea" CssClass="text-caps_datalist" runat="server" Text='<%# Bind("q1") %>'></asp:Label>
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Label ID="lbl_q2" CssClass="text-caps_datalist" runat="server" Text="Physician Name"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_q2a" CssClass="text-caps_datalist" runat="server" Text='<%# Bind("q2") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Label ID="lbl_q3" CssClass="text-caps_datalist" runat="server" Text="Mother Name"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_q3a" CssClass="text-caps_datalist" runat="server" Text='<%# Bind("q3") %>'></asp:Label>
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Label ID="lbl_q3a1" CssClass="text-caps_datalist" runat="server" Text="Child Name"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_q3a2" CssClass="text-caps_datalist" runat="server" Text='<%# Bind("q3a") %>'></asp:Label>
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Label ID="Label105" CssClass="text-caps_datalist" runat="server" Text="BT Number"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label106" CssClass="text-caps_datalist" runat="server" Text='<%# Bind("q4a") %>'></asp:Label>
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Label ID="lbl_q5" runat="server" CssClass="text-caps_datalist" Text="Nasopharyngeal swab collected"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_q5a" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q5") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Label ID="lbl_q6dt" runat="server" CssClass="text-caps_datalist" Text="Collection Date"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_q6dta" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q5dt") %>'></asp:Label>
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Label ID="lbl_q8" runat="server" CssClass="text-caps_datalist" Text="Condition of the STGG Tube (Respiratory Specimen)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_q8a" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q8") %>'></asp:Label>
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Label ID="lbl_q9" runat="server" CssClass="text-caps_datalist" Text="Temperature of the tube upon arrival at lab"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_q9a" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q9") %>'></asp:Label>
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Label ID="lbl_q10dt" runat="server" CssClass="text-caps_datalist" Text="Received Date"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_q10dta" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q10dt") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Label ID="lbl_q10t" runat="server" CssClass="text-caps_datalist" Text="Received Time"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_q10ta" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q10t") %>'></asp:Label>
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Label ID="lbl_q12" runat="server" CssClass="text-caps_datalist" Text="Name of the laboratory person"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_q12a" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q11") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Label ID="lbl_q13" runat="server" CssClass="text-caps_datalist" Text="Lab Person Code"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_q13a" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q13") %>'></asp:Label>
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Panel ID="pnl_idrl" runat="server">
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Label ID="Label1001" runat="server" CssClass="text-caps_datalist" Text="S.pneumoniae Detected in Respiratory Specimen"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label1002" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q12") %>'></asp:Label>
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Label ID="Label10300" runat="server" CssClass="text-caps_datalist" Text="Optochin zone size"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label10040" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q13") %>'></asp:Label>
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Label ID="lbl_q14" runat="server" CssClass="text-caps_datalist" Text="Bile Solubility"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_q14a" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q14") %>'></asp:Label>
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Label ID="lbl_q15a1" runat="server" CssClass="text-caps_datalist" Text="Chloramphenicol (30 µg)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_q15a1a" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q15a1") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label8" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q15b1") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label107" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q15c11") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Label ID="Label3" runat="server" CssClass="text-caps_datalist" Text="Erythromycin (15 µg)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label6" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q15a2") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label9" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q15b2") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label108" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q15c21") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Label ID="Label21" runat="server" CssClass="text-caps_datalist" Text="Oxacillin (1 µg)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label22" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q15a3") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label23" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q15b3") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label109" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q15c31") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Label ID="Label24" runat="server" CssClass="text-caps_datalist" Text="Ofloxacin (5 µg)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label25" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q15a4") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label26" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q15b4") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label110" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q15c41") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Label ID="Label27" runat="server" CssClass="text-caps_datalist" Text="Cotrimoxazole (25 µg)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label28" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q15a5") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label29" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q15b5") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label111" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q15c51") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Label ID="Label30" runat="server" CssClass="text-caps_datalist" Text="Tetracycline (30 µg)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label31" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q15a6") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label32" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q15b6") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label112" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q15c61") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Label ID="Label33" runat="server" CssClass="text-caps_datalist" Text="Vancomycin(30 µg)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label34" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q15a7") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label35" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q15b7") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label113" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q15c71") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;
                                            </td>
                                            <td>
                                                <asp:Label ID="Label36" runat="server" CssClass="text-caps_datalist" Text="Penicillin (non- meningitis)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label78" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q16signa1a") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label37" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q16a1") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label38" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q16b1") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label114" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q16c11") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;
                                            </td>
                                            <td>
                                                <asp:Label ID="Label39" runat="server" CssClass="text-caps_datalist" Text="Ceftriaxone (non- meningitis)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label79" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q16signa2a") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label40" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q16a2") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label41" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q16b2") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label115" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q16c21") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;
                                            </td>
                                            <td>
                                                <asp:Label ID="Label42" runat="server" CssClass="text-caps_datalist" Text="Vancomycin"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label131" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q16signa3a") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label43" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q16a3") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label44" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q16b3") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label116" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q16c31") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Label ID="Label45" runat="server" CssClass="text-caps_datalist" Text="Staphylococcus aureus Detected in Respiratory Specimen"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label46" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q16c") %>'></asp:Label>
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Label ID="Label47" runat="server" CssClass="text-caps_datalist" Text="Amikacin (30 µg)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label48" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q17a1") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label49" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q17b1") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label117" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q17c1155") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Label ID="Label50" runat="server" CssClass="text-caps_datalist" Text="Chloramphenicol (30 µg)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label51" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q17a2") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label52" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q17b2") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label118" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q17c21") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Label ID="Label53" runat="server" CssClass="text-caps_datalist" Text="Gentamycin (2µg)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label54" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q17a3") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label55" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q17b3") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label119" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q17c31") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Label ID="Label127" runat="server" CssClass="text-caps_datalist" Text="Clindamycin (2 µg)* "></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label128" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q17a99") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label129" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q17b99") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label130" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q17c41") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Label ID="Label56" runat="server" CssClass="text-caps_datalist" Text="Erythromycin (15 µg)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label57" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q17a4") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label58" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q17b4") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label120" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q17c51") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Label ID="Label59" runat="server" CssClass="text-caps_datalist" Text="Fusidic Acid (10 µg)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label60" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q17a5") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label61" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q17b5") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label121" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q17c61") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Label ID="Label62" runat="server" CssClass="text-caps_datalist" Text="Oxacillin (1 µg)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label63" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q17a6") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label64" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q17b6") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label122" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q17c71") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Label ID="Label65" runat="server" CssClass="text-caps_datalist" Text="Ciprofloxacin (5 µg)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label66" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q17a7") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label67" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q17b7") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label123" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q17c81") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Label ID="Label68" runat="server" CssClass="text-caps_datalist" Text="Penicillin (10 µg)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label69" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q17a8") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label70" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q17b8") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label124" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q17c91") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Label ID="Label71" runat="server" CssClass="text-caps_datalist" Text="Cotrimoxazole (25 µg)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label72" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q17a9") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label73" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q17b9") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label125" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q17c101") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Label ID="Label74" runat="server" CssClass="text-caps_datalist" Text="Tetracycline (30 µg)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label75" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q17a10") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label76" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q17b10") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label126" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q17c111") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;
                                            </td>
                                            <td>
                                                <asp:Label ID="Label80" runat="server" CssClass="text-caps_datalist" Text="Vancomycin"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label132" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q18signa1a") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label81" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q18a1") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label82" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q18b1") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label77" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q18c11") %>'></asp:Label>
                                            </td>
                                        </tr>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Panel ID="pnl_mdl" runat="server">
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Label ID="Label83" runat="server" CssClass="text-caps_datalist" Text="Conventional Multiplex PCR For Serotyping Done"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label84" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q19") %>'></asp:Label>
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Label ID="Label85" runat="server" CssClass="text-caps_datalist" Text="Sequential Multiplex PCR for Pneumococcal Serotyping"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label86" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q20") %>'></asp:Label>
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Label ID="Label87" runat="server" CssClass="text-caps_datalist" Text="PCR for Pneumococcal Serogroup 6A/6B/6C/6D resolution"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label88" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q21") %>'></asp:Label>
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Label ID="Label89" runat="server" CssClass="text-caps_datalist" Text="Monoplex PCR for Serotype confirmation"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label90" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q22") %>'></asp:Label>
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Label ID="Label91" runat="server" CssClass="text-caps_datalist" Text="Final Results"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label92" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("q23") %>'></asp:Label>
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Label ID="Label93" runat="server" CssClass="text-caps_datalist" Text="Comments"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label94" runat="server" CssClass="text-caps_datalist" Text='<%# Bind("comments") %>'></asp:Label>
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <AlternatingItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="False" />
                    <HeaderTemplate>
                        <span style="font-size: 10pt; color: #278A05; font-family: Tahoma">
                            <table style="text-align: center; vertical-align: middle; width: 100%; padding: 5px 0px 5px 0px">
                                <tr>
                                    <td>Detail of Sample Entered</td>
                                </tr>
                            </table>
                        </span>
                    </HeaderTemplate>
                    <SeparatorTemplate>
                        <hr />
                    </SeparatorTemplate>
                </asp:DataList>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
