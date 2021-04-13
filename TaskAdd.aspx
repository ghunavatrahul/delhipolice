<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="TaskAdd.aspx.cs" Inherits="TaskAdd" %>
  <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">Task </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="mydiv" style="width:80%; margin-left:10%; margin-top:5%; background:#ffffff;" class="box box-default">
       <style>
           .ajax__calendar
{
       
}
       </style>       
        <div class="box-body" style="display: block;">
          <div class="row">
            <%--<div class="col-md-6" style="margin-left: 27%;">--%>
            <div class="col-md-6" >
               <div class="form-group">
                <label id="lblId" runat="server" visible="false"></label>
                <label>Task Title</label>                               
                <asp:TextBox ID="txtTaskname" class="form-control" runat="server" placeholder="Enter Task Title ..." style="margin-left: 0px;"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ErrorMessage="* Please Enter Task!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="txtTaskname" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ForeColor="Red" ControlToValidate="txtTaskname" SetFocusOnError="true" 
                    Display="Dynamic" ValidationExpression="[a-zA-Z ]*$" ErrorMessage="* Only Valid characters!" />                                  
              </div> 
              <div class="form-group" >
                 <label>Priority </label>
                 <asp:DropDownList ID="ddlPriority" class="form-control" runat="server" >
                    <asp:ListItem Value="">Select Priority</asp:ListItem>
                     <asp:ListItem Value="1">Low</asp:ListItem>
                     <asp:ListItem Value="2">Medium</asp:ListItem>
                     <asp:ListItem Value="3">High</asp:ListItem>
                  </asp:DropDownList> 
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ErrorMessage="* Please Select Priority!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="ddlPriority" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>                  
               </div>
               <div class="form-group" >
                 <label>Description </label>                 
                  <asp:TextBox ID="txtDescription" class="form-control" runat="server" placeholder="Enter Description ..." TextMode="MultiLine" style="margin-left: 0px; height: 90px;" ></asp:TextBox> 
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ForeColor="Red" ErrorMessage="* Please Enter Description!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="txtDescription" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="Red" ControlToValidate="txtDescription" SetFocusOnError="true" 
                    Display="Dynamic" ValidationExpression="[a-zA-Z ]*$" ErrorMessage="* Only Valid characters!" /> 
               </div>  
               <div class="form-group">
                <label>Start Date:</label>               
                  <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                    </cc1:ToolkitScriptManager>
                    <asp:TextBox ID="txtstartdate"  onkeypress = 'return false' onclick="showDate();"  runat="server" class="form-control pull-right" placeholder="Choose Start Date ..." ></asp:TextBox>
                    <asp:ImageButton ID="imgPopup" ImageUrl="images/calendar.png" class="form-control pull-right" ImageAlign="Bottom" runat="server" style="margin-top: -34px; width: 42px;" />
                    <cc1:CalendarExtender TodaysDateFormat="dd/MM/yyyy" ID="Calendar1" PopupButtonID="imgPopup" BehaviorID="Date" runat="server" TargetControlID="txtstartdate" Format="dd/MM/yyyy">
                    </cc1:CalendarExtender>                
                </div>            
             <script type="text/javascript">
                 function showDate() {
                     $find("Date").show();
                 }                
            </script>
            <div class="form-group">
                  <label for="exampleInputFile" style="margin-top: 10px;">Attachments</label>
                   <asp:FileUpload ID="FileUpload1" runat="server" />                                
              </div>  
             
           </div>           
            <div class="col-md-6">
              <div class="form-group" >
                 <label>Status </label>                 
                  <asp:DropDownList ID="ddlStatus" class="form-control" runat="server" >
                      <asp:ListItem Value="">Select Status</asp:ListItem>
                      <asp:ListItem Value="1">Open</asp:ListItem>
                      <asp:ListItem Value="2">Close</asp:ListItem>
                  </asp:DropDownList> 
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red" ErrorMessage="* Please Select Status!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="ddlStatus" ValidationGroup='valGroup1'></asp:RequiredFieldValidator> 
               </div> 
               <div class="form-group" >
                 <label>Project Status </label>                 
                  <asp:DropDownList ID="ddlProjectStatus" class="form-control" runat="server" >
                       <asp:ListItem Value="">Select Project Status</asp:ListItem>
                      <asp:ListItem Value="1">Schedule</asp:ListItem>
                      <asp:ListItem Value="2">ReSchedule</asp:ListItem>
                   </asp:DropDownList> 
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ForeColor="Red" ErrorMessage="* Please Select Project Status!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="ddlProjectStatus" ValidationGroup='valGroup1'></asp:RequiredFieldValidator> 
               </div>
                         
              <div class="form-group" >
                 <label>Assigned To </label> 
                 <asp:listbox runat="server" id="lstBoxTest" class="form-control" SelectionMode="Multiple"></asp:listbox>                
                  <asp:DropDownList Visible="false" ID="ddlAssignedby" class="form-control" runat="server" ><asp:ListItem Value="">Select Assigned To</asp:ListItem> </asp:DropDownList>
                  
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ErrorMessage="* Please Select Assigned By!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="lstBoxTest" ValidationGroup='valGroup1'></asp:RequiredFieldValidator> 
               </div> 
                <div class="form-group">
                <label>Due Date:</label>                
                <asp:TextBox ID="txtduedate" onkeypress = 'return false' onclick="showDate1();" runat="server" PopupButtonID="ImageButton1" class="form-control pull-right" placeholder="Choose Due Date ..." ></asp:TextBox>
                <asp:ImageButton ID="ImageButton1" ImageUrl="images/calendar.png" class="form-control pull-right" ImageAlign="Bottom" runat="server" style="margin-top: -34px; width: 42px;" />
                <cc1:CalendarExtender  TodaysDateFormat="dd/MM/yyyy"  ID="CalendarExtender1" BehaviorID="Date1" PopupButtonID="ImageButton1" runat="server" TargetControlID="txtduedate" Format="dd/MM/yyyy">
                </cc1:CalendarExtender>                
                </div> 
                <script type="text/javascript">
                    function showDate1() {
                        $find("Date1").show();
                    }                
            </script>   

                     
              </div>                           
            </div>                      
          </div>         
     
        <div class="box-footer" style="display: block;">
          <button id="btnCancel" runat="server" type="submit" class="btn btn-info pull-right" onserverclick="btnCancel_Click">Cancel</button>
          <button id="btnSave" runat="server"  type="submit" class="btn btn-info pull-right" onserverclick="btnSave_Click" ValidationGroup='valGroup1' style="margin-right: 15px;">Save</button>
        </div>
      </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

