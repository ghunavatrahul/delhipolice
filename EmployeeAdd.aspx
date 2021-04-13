<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="EmployeeAdd.aspx.cs" Inherits="EmployeeAdd" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">Employee</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div id="mydiv" style="width:80%; margin-left:10%; margin-top:5%; background:#ffffff;" class="box box-default">
       
        
        <div class="box-body" style="display: block;">
          <div class="row">
            <div class="col-md-6">               
                <label id="lblId" runat="server" visible="false"></label>              
                <div id="divEmpcode" class="form-group" runat="server" visible="false">
                <label id="Label1" runat="server">Employee Code</label>              
               <asp:TextBox ID="txtEmpcode" class="form-control" runat="server" ReadOnly="true" style="margin-left: 0px;" ></asp:TextBox>                    
              </div>              
              <div class="form-group">               
                <label>First Name</label>              
               <asp:TextBox ID="txtFirstname" class="form-control" runat="server" placeholder="Enter First Name ..." style="margin-left: 0px;"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ErrorMessage="* Please Enter First Name!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="txtFirstname" ValidationGroup='valGroup1'></asp:RequiredFieldValidator> 
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ForeColor="Red" ControlToValidate="txtFirstname" SetFocusOnError="true" 
                    Display="Dynamic" ValidationExpression="[a-zA-Z ]*$" ErrorMessage="* Only Valid characters!" />
              </div>              
              <div class="form-group">
                <label>Middle Name</label>               
                 <asp:TextBox ID="txtMiddlename" class="form-control" runat="server" placeholder="Middle Name ..." style="margin-left: 0px;"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ErrorMessage="* Please Enter Middle Name!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="txtMiddlename" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>--%>
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ForeColor="Red" ControlToValidate="txtMiddlename" SetFocusOnError="true" 
                    Display="Dynamic" ValidationExpression="[a-zA-Z ]*$" ErrorMessage="* only Valid characters!" />
              </div>
              <div class="form-group">
                <label>Last Name</label>               
                 <asp:TextBox ID="txtLastname" class="form-control" runat="server" placeholder="Enter Last Name ..." style="margin-left: 0px;"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red" ErrorMessage="* Please Enter Last Name!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="txtLastname" ValidationGroup='valGroup1'></asp:RequiredFieldValidator> 
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ForeColor="Red" ControlToValidate="txtLastname" SetFocusOnError="true" 
                    Display="Dynamic" ValidationExpression="[a-zA-Z ]*$" ErrorMessage="* Only Valid characters!" />
              </div>
              <div class="form-group">
                <label>Email ID</label>                
                <asp:TextBox ID="txtEmailid" class="form-control" runat="server" placeholder="Enter Email ID ..." style="margin-left: 0px;"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ErrorMessage="* Please Enter Email!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="txtEmailid" ValidationGroup='valGroup1'></asp:RequiredFieldValidator> 
                    <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                    ControlToValidate="txtEmailid" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" ErrorMessage="* Invalid Email Format"></asp:RegularExpressionValidator>
              </div>
               <div class="checkbox">
                 <label>
                    <input id="chkActive" runat="server" type="checkbox"> Active
                  </label>
              </div>
            </div>
           
            <div class="col-md-6">
              
              <!-- /.form-group -->
              <div class="form-group">
                <label>Password</label>               
              <%--<input runat="server" type="text" class="form-control" style="margin-left: 0px;" id="inputEmail3" placeholder="Email">--%>
               <asp:TextBox ID="txtPassword" class="form-control" runat="server" placeholder="Enter Password ..." style="margin-left: 0px;" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ForeColor="Red" ErrorMessage="* Please Enter Password!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="txtPassword" ValidationGroup='valGroup1'></asp:RequiredFieldValidator> 
              </div>
              <div class="form-group">
                <label>Confirm Password</label>               
              <%--<input runat="server" type="text" class="form-control" style="margin-left: 0px;" id="inputEmail3" placeholder="Email">--%>
               <asp:TextBox ID="txtConfirmPassword" class="form-control" runat="server" placeholder="Enter Confirm Password ..." style="margin-left: 0px;" TextMode="Password"></asp:TextBox>
               <asp:CompareValidator ID="CompareValidator1" runat="server" ForeColor="Red" ControlToValidate="txtConfirmPassword" ControlToCompare="txtPassword" 
               ValidationGroup='valGroup1' ErrorMessage="* Password Not Match" SetFocusOnError="true" Display="Dynamic"/> 
              </div>
             <div class="form-group">
                <label>Phone Number</label>                
                <asp:TextBox ID="txtPhoneNumber" class="form-control" runat="server" placeholder="Enter Phone Number ..." style="margin-left: 0px;"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ForeColor="Red" ErrorMessage="* Please Enter Phone number!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="txtPhoneNumber" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPhoneNumber" ErrorMessage="! Only numeric allowed." 
                    ForeColor="Red" ValidationExpression="^[0-9]*$" ValidationGroup="valGroup1" Display="Dynamic" SetFocusOnError="true"></asp:RegularExpressionValidator> 
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPhoneNumber" ErrorMessage="! Maximum 10 characters allowed." 
                    ForeColor="Red" ValidationExpression="^[\s\S]{10,10}$" ValidationGroup="valGroup1" Display="Dynamic" SetFocusOnError="true"></asp:RegularExpressionValidator> 
              </div>           
              <div class="form-group" >
                 <label>Role</label>
                 <%--<select id="ddlRole" class="form-control" name="roles"><option value="">Select ...</option></select>--%>
                 <%-- <asp:DropDownList ID="ddlRole" class="form-control" runat="server" Visible="false"></asp:DropDownList>--%>
                  <asp:listbox runat="server" id="lstBoxTest" class="form-control" SelectionMode="Multiple"></asp:listbox> 
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ForeColor="Red" ErrorMessage="* Please Select Role!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="lstBoxTest" ValidationGroup='valGroup1'></asp:RequiredFieldValidator> 
               </div> 
              <%--<div class="checkbox">
                 <label>
                    <input id="chkActive" runat="server" type="checkbox"> Active
                  </label>
              </div>--%>
             
            </div>
            <!-- /.col -->
          </div>
          <!-- /.row -->
        </div>
        <!-- /.box-body -->
        <div class="box-footer" style="display: block;">
          <button id="btnCancel" runat="server" type="submit" class="btn btn-info pull-right" onserverclick="btnCancel_Click">Cancel</button>
          <button id="btnSubmit" runat="server"  type="submit" class="btn btn-info pull-right" onserverclick="btnSubmit_Click" ValidationGroup='valGroup1' style="margin-right: 15px;">Submit</button>
        </div>
      </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

