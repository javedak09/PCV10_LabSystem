<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PCV13_LabSystem.Account.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script language="javascript" type="text/javascript">
        function ValidateLogin() {
            var txtuserid = document.getElementById("MainContent_txtUserID");
            var txtpasswd = document.getElementById("MainContent_txtPwd");


            if (txtuserid.value == "") {
                txtuserid.focus();
                alert("User name required field");
                return false;
            }


            if (txtpasswd.value == "") {
                txtpasswd.focus();
                alert("Password required field");
                return false;
            }

            return true;

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <table style="width: 50px;">
                    <tr>
                        <td>User ID
                        </td>
                        <td>
                            <asp:TextBox ID="txtUserID" CssClass="textentry1" runat="server" Text=""></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Password
                        </td>
                        <td>
                            <asp:TextBox ID="txtPwd" runat="server" CssClass="textentry1" Text="" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblerr" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="cmdLogin" runat="server" Text=" Login  "
                                OnClick="cmdLogin_Click" CssClass="btn" />
                            <asp:Button ID="cmdCancel" runat="server" Text="Cancel"
                                OnClick="cmdCancel_Click" CssClass="btn" />
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
