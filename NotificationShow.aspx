<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="NotificationShow.aspx.cs" Inherits="NotificationShow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">Notification</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="mydiv" style="width:80%; margin-left:10%; margin-top:5%; background:#ffffff;" class="box box-default">
              
        <div class="box-body" style="display: block;">
          <div class="row">
            <div class="col-md-6">
               <div class="form-group">
                <label id="lblId" runat="server" visible="false"></label>
                <label id="lbltask" runat="server" visible="false"></label>
                <label>Subject</label>                               
                <asp:TextBox ID="txtSubject" class="form-control" ReadOnly="true" runat="server" placeholder="Write Subject ..." style="margin-left: 0px;"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ErrorMessage="* Please Enter Subject!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="txtSubject" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>                                  
              </div> 
             
               <div class="form-group" >
                 <label>Description </label>                 
                  <asp:TextBox ID="txtDescription" class="form-control" ReadOnly="true" runat="server" placeholder="Write Description ..." TextMode="MultiLine" style="margin-left: 0px; height: 100px;"></asp:TextBox> 
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ForeColor="Red" ErrorMessage="* Please Enter Description!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="txtDescription" ValidationGroup='valGroup1'></asp:RequiredFieldValidator> 
               </div>  
            </div>           
            <div class="col-md-6">                                      
              <div class="form-group" >
                 <label>Notified To </label>                 
                  <asp:listbox runat="server" id="lstBoxTest" class="form-control" ReadOnly="true" SelectionMode="Multiple" style="height: 174px;"></asp:listbox> 
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ErrorMessage="* Please Select!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="lstBoxTest" ValidationGroup='valGroup1'></asp:RequiredFieldValidator> 
               </div>                            
            </div>                      
          </div>         
        </div>        
        <div runat="server" visible="false" class="box-footer" style="display: block;">
          <button id="btnCancel" runat="server" type="submit" class="btn btn-info pull-right" onserverclick="btnCancel_Click">Cancel</button>
          <button id="btnSave" runat="server"  type="submit" class="btn btn-info pull-right" onserverclick="btnSave_Click" ValidationGroup='valGroup1' style="margin-right: 15px;">Save</button>
        </div>
      </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

