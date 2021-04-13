<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="VendorAdd.aspx.cs" Inherits="VendorAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">Vendor</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="mydiv" style="width:80%; margin-left:10%; margin-top:5%; background:#ffffff;" class="box box-default">
       
        
        <div class="box-body" style="display: block;">
          <div class="row">
            <div class="col-md-6">               
                <label id="lblId" runat="server" visible="false"></label>              
                <div id="divVendcode" class="form-group" runat="server" visible="false">
                <label id="Label1" runat="server">Vendor Code</label>              
               <asp:TextBox ID="txtVendcode" class="form-control" runat="server" ReadOnly="true" style="margin-left: 0px;" ></asp:TextBox>                    
              </div>              
              <div class="form-group">               
                <label>Vendor Name</label>              
               <asp:TextBox ID="txtVendorname" class="form-control" runat="server" placeholder="Enter Vendor Name ..." style="margin-left: 0px;"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ErrorMessage="* Please Enter Vendor Name!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="txtVendorname" ValidationGroup='valGroup1'></asp:RequiredFieldValidator> 
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ForeColor="Red" ControlToValidate="txtVendorname" SetFocusOnError="true" 
                    Display="Dynamic" ValidationExpression="[a-zA-Z ]*$" ErrorMessage="* Only Valid characters!" />
              </div>              
              <div class="form-group">
                <label>Vendor Type</label>               
                 <asp:TextBox ID="txtVendortype" class="form-control" runat="server" placeholder="Enter Vendor Type ..." style="margin-left: 0px;"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ErrorMessage="* Please Enter Vendor Type!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="txtVendortype" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ForeColor="Red" ControlToValidate="txtVendortype" SetFocusOnError="true" 
                    Display="Dynamic" ValidationExpression="[a-zA-Z ]*$" ErrorMessage="* only Valid characters!" />
              </div>
              <div class="form-group">
                <label>Company Name</label>               
                 <asp:TextBox ID="txtCompanyname" class="form-control" runat="server" placeholder="Enter Company Name ..." style="margin-left: 0px;"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red" ErrorMessage="* Please Enter Company Name!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="txtCompanyname" ValidationGroup='valGroup1'></asp:RequiredFieldValidator> 
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ForeColor="Red" ControlToValidate="txtCompanyname" SetFocusOnError="true" 
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
                    <div class="form-group">
                <label>Pan Number</label>               
              <%--<input runat="server" type="text" class="form-control" style="margin-left: 0px;" id="inputEmail3" placeholder="Email">--%>
               <asp:TextBox ID="txtPannumber" class="form-control" runat="server" placeholder="Enter Pan Number ..." style="margin-left: 0px;"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ForeColor="Red" ErrorMessage="* Please Enter Pan Number!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="txtPannumber" ValidationGroup='valGroup1'></asp:RequiredFieldValidator> 
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
            </div>
           
            <div class="col-md-6">            
               <div class="form-group">
                <label>Address</label>            
               <asp:TextBox ID="txtAddress" class="form-control" runat="server" placeholder="Enter Address ..." TextMode="MultiLine" style="margin-left: 0px;"></asp:TextBox>  
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ForeColor="Red" ErrorMessage="* Please Enter Address!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="txtAddress" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>           
              </div>          
              <div class="form-group" >
                 <label>Country</label>               
                     <asp:TextBox ID="txtCountry" class="form-control" runat="server" placeholder="Enter Country ..."  style="margin-left: 0px;"></asp:TextBox>  
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ForeColor="Red" ErrorMessage="* Please Enter Country!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="txtCountry" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>     
               </div> 
              <div class="form-group" >
                 <label>State</label>               
                    <%-- <asp:TextBox ID="txtState" class="form-control" runat="server" placeholder="Enter State ..."  style="margin-left: 0px;"></asp:TextBox>  
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ForeColor="Red" ErrorMessage="* Please Enter State!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="txtState" ValidationGroup='valGroup1'></asp:RequiredFieldValidator> --%>   
                  <asp:DropDownList ID="ddlstate" class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged" >                               
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ForeColor="Red" ErrorMessage="* Please Select State!" SetFocusOnError="true"
                Display="Dynamic" ControlToValidate="ddlstate" ValidationGroup='valGroup1'></asp:RequiredFieldValidator> 
               </div> 
                 <div class="form-group" >
                 <label>City</label>               
                    <%-- <asp:TextBox ID="txtCity" class="form-control" runat="server" placeholder="Enter City ..."  style="margin-left: 0px;"></asp:TextBox>  
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ForeColor="Red" ErrorMessage="* Please Enter City!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="txtCity" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>  --%>  
                 <asp:DropDownList ID="ddlcity" class="form-control" runat="server">                               
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ForeColor="Red" ErrorMessage="* Please Select City!" SetFocusOnError="true"
                Display="Dynamic" ControlToValidate="ddlcity" ValidationGroup='valGroup1'></asp:RequiredFieldValidator> 
               </div> 
                <div class="form-group" >
                 <label>Pin Code</label>               
                     <asp:TextBox ID="txtPincode" class="form-control" runat="server" placeholder="Enter PinCode ..."  style="margin-left: 0px;"></asp:TextBox>  
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ForeColor="Red" ErrorMessage="* Please Enter Pincode!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="txtPincode" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>  
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtPincode" ErrorMessage="! Only numeric allowed." 
                    ForeColor="Red" ValidationExpression="^[0-9]*$" ValidationGroup="valGroup1" Display="Dynamic" SetFocusOnError="true"></asp:RegularExpressionValidator>    
               </div> 
                 <div class="checkbox">
                 <label>
                    <input id="chkActive" runat="server" type="checkbox"> Active
                  </label>
              </div>
            </div>            
          </div>         
        </div>
        
        <div class="box-footer" style="display: block;">
          <button id="btnCancel" runat="server" type="submit" class="btn btn-info pull-right" onserverclick="btnCancel_Click">Cancel</button>
          <button id="btnSubmit" runat="server"  type="submit" class="btn btn-info pull-right" onserverclick="btnSubmit_Click" ValidationGroup='valGroup1' style="margin-right: 15px;">Submit</button>
        </div>
      </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

