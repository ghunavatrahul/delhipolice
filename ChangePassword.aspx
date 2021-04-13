<%@ Page Language="C#" MasterPageFile="Admin.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="admin_ChangePassword" Title="Change Password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server"> Change Password </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <%--   <center style="margin-left: 60px;" >            
    <div style="overflow:auto; height:490px;    margin-top: 20px;">
    <table width="100%">
        <tr>
            <td align="center">
                <br />
                <asp:Panel ID="pnlData" runat="server" Visible="true">
                    <table width="40%" cellpadding="4">
                        <tr>
                            <td width="50%">
                                Type :
                            </td>
                            <td width="50%">
                                 <asp:TextBox ID="txtUserName" runat="server" Width="150px" Height="20px" Enabled="false"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Select Type"
                                    ValidationGroup="aa" SetFocusOnError="true" Display="Dynamic" 
                                    ControlToValidate="txtUserName">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Old Password :
                            </td>
                            <td>
                                <asp:TextBox ID="txtOldPassword" runat="server" Width="150px" Height="20px" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="R1" runat="server" ErrorMessage="Please Enter Old Password"
                                    ValidationGroup="aa" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtOldPassword">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                       <tr>
                            <td>
                                New Password :
                            </td>
                            <td>
                                <asp:TextBox ID="txtNewPassword" runat="server" Width="150px" Height="20px" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter New Password"
                                    ValidationGroup="aa" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtNewPassword">*</asp:RequiredFieldValidator>
                                    
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Retype Password :
                            </td>
                            <td>
                                <asp:TextBox ID="txtRetype" runat="server" Width="150px" Height="20px" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Enter Retype Password"
                                    ValidationGroup="aa" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtRetype">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password Mismatch" 
                                 ControlToCompare="txtNewPassword" ControlToValidate="txtRetype"  ValidationGroup="aa" >*</asp:CompareValidator>
                                    
                            </td>
                        </tr>
                         <tr>
                           
                            <td colspan="2" align="center">
                                <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="aa" Width="100px"
                                    Height="25px" OnClick="btnSave_Click" />
                                   
                                <asp:Label ID="lblCatId" runat="server" Text="" Visible="false"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" >
                                <asp:Label ID="lblMsg" runat="server" Visible="false" ForeColor="Red" Text=""></asp:Label>
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="aa" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        
    </table>
    </div>
        </center>--%>

        <div id="mydiv" style="width:80%; margin-left:10%; margin-top:5%; background:#ffffff;" class="box box-default">               
        <div class="box-body" style="display: block;">
          <div class="row">
            <div class="col-md-6" style="margin-left: 27%;">
               <div class="form-group">
                <label id="lblId" runat="server" visible="false"></label>
                <label>Old Password :</label>                               
                <asp:TextBox ID="txtOldPassword" class="form-control" runat="server" TextMode="Password" placeholder="Enter ..." style="margin-left: 0px;"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red" ErrorMessage="* Please Enter Old Password!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="txtOldPassword" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>                                  
              </div>   
              <div class="form-group" >
                 <label>New Password :</label>                 
                  <asp:TextBox ID="txtNewPassword" class="form-control" runat="server" TextMode="Password" placeholder="Enter ..." style="margin-left: 0px;"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ForeColor="Red" ErrorMessage="* Please Enter New Password!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="txtNewPassword" ValidationGroup='valGroup1'></asp:RequiredFieldValidator> 
               </div>            
               <div class="form-group">
                 <label> Confirm Password :</label>
                 <asp:TextBox ID="txtRetype" class="form-control" runat="server"  TextMode="Password" placeholder="Enter ..." style="margin-left: 0px;"></asp:TextBox>
                 <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ErrorMessage="* Please Enter Confirm Password" SetFocusOnError="true"
                  Display="Dynamic" ValidationGroup="valGroup1"  ControlToValidate="txtRetype">*</asp:RequiredFieldValidator>--%>
                  <asp:CompareValidator ID="CompareValidator1" runat="server" ForeColor="Red" ControlToValidate="txtRetype" ControlToCompare="txtNewPassword" 
                    ValidationGroup='valGroup1' ErrorMessage="* Password MisMatch" SetFocusOnError="true" Display="Dynamic"/> 
                    </div>
              <div class="form-group">
              <asp:Label ID="lblMsg" runat="server" Visible="false" ForeColor="Red" Text=""></asp:Label>    
                       
            </div>                     
          </div>        
        </div>        
        <div class="box-footer" style="display: block; ">
          <button id="btnCancel" runat="server" type="submit" class="btn btn-default" onserverclick="btnCancel_Click">Cancel</button>
          <button id="Button1" runat="server"  type="submit" class="btn btn-info pull-right" onserverclick="btnSave_Click" ValidationGroup='valGroup1'>Change</button>
        </div>
      </div>
      </div>
</asp:Content>

