<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="RoleAdd.aspx.cs" Inherits="RoleAdd" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">Roles</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="mydiv" style="width:80%; margin-left:10%; margin-top:5%; background:#ffffff;" class="box box-default">
        <div class="box-header with-border">
   
           <div class="box-tools pull-right">
            <%--<button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>--%>
            <%--<button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>--%>
          </div>
         
        </div>        
        <div class="box-body" style="display: block;">
          <div class="row">
            <div class="col-md-6" style="margin-left: 27%;">
               <div class="form-group">
                <label id="lblId" runat="server" visible="false"></label>
                <label>Role Name</label>                               
                <asp:TextBox ID="txtRolename" class="form-control" runat="server" placeholder="Role Name ..." style="margin-left: 0px;"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ErrorMessage="* Please Enter Role!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="txtRolename" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>                                  
              </div>   
              <div class="form-group" >
                 <label>Page </label>                 
                  <asp:listbox runat="server" id="lstBoxTest" class="form-control" SelectionMode="Multiple"></asp:listbox> 
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ForeColor="Red" ErrorMessage="* Please Select Page!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="lstBoxTest" ValidationGroup='valGroup1'></asp:RequiredFieldValidator> 
               </div>            
               <div class="checkbox">
                 <label><input id="chkStatus" runat="server" type="checkbox"> Status</label>
              </div>
            </div>                      
          </div>         
        </div>        
        <div class="box-footer" style="display: block;">
          <button id="btnCancel" runat="server" type="submit" class="btn btn-info pull-right" onserverclick="btnCancel_Click">Cancel</button>
          <button id="btnSave" runat="server"  type="submit" class="btn btn-info pull-right" onserverclick="btnSave_Click" ValidationGroup='valGroup1' style="margin-right: 15px;">Submit</button>
        </div>
      </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

