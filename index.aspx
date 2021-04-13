<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" ViewStateMode="Enabled" Inherits="index" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome To Login Page</title>
    <link href="css/responsive.css" rel="stylesheet" type="text/css" />
</head>
<body bgcolor="#3c8dbc">
    <form id="form1" runat="server">
    <table width="100%">
        <tr style="height:150px;">
            <td>&nbsp;
                
            </td>
        </tr>
        <tr>
            <td align="center" >
                <table width="40%" style="background-color: #FFFFFF" border="0" id="tablelogin">
                    <tr>
                        <td colspan="4" style="background-color:#222d32">
                     <%--<img src="../images/logo.png" height="70px" width="250px"/>--%>
                            <h1 style="    text-align: center;      font-family: cursive;  color: white;">Delhi Police - Rohin District</h1>
                     <hr />
                        </td>
                    </tr>
                     <tr style="height:60px;">
                        <td rowspan="3">
                            <img src="images/Lock.png" height="150px" width="180px" />
                        </td>
                         
                        <td>
                        <asp:Label ID="lblUserName" runat="server" Text="User Name"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtUserName" runat="server" width="180px" height="20px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="R1" runat="server" ErrorMessage="Please Enter User Name!"
                             ValidationGroup="aa" SetFocusOnError="true" Display="Dynamic"
                              ControlToValidate="txtUserName">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                     <tr style="height:60px;">
                                                 
                        <td>
                        <asp:Label ID="lblPass" runat="server" Text="Password"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPassword" runat="server"  width="180px" height="20px" TextMode="Password"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Password!"
                             ValidationGroup="aa" SetFocusOnError="true" Display="Dynamic"
                              ControlToValidate="txtPassword">*</asp:RequiredFieldValidator>

                              <br/><asp:Label  Display="Dynamic" SetFocusOnError="true" ID="lblMsg" runat="server" Text="" Font-Size="Small" Visible="false" ForeColor="Red"></asp:Label>
                              <asp:ValidationSummary ID="VS1" ru SetFocusOnError="true" runat="server" ValidationGroup="aa" Font-Size="Small" />
                        </td>
                    </tr>
                     <tr style="height:80px;">
                                                 
                        <td colspan="2" align="center">
                            &nbsp;&nbsp;&nbsp;<asp:Button ID="btnLogin" runat="server" Text="Login" 
                                ValidationGroup="aa" Height="30px" Width="100px" onclick="btnLogin_Click" />
                        </td>
                    </tr>
                     <tr>                                                 
                        <td colspan="3" align="left" >
                           <%-- <asp:Label ID="lblMsg" runat="server" Text="" Font-Size="Small" Visible="false" ForeColor="Red"></asp:Label>
                            <asp:ValidationSummary ID="VS1" runat="server" ValidationGroup="aa" Font-Size="Small" />--%>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
