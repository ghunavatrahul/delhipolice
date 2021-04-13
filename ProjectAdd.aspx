<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="ProjectAdd.aspx.cs" Inherits="ProjectAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">Project</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<div id="mydiv" style="width:80%; margin-left:10%; margin-top:5%; background:#ffffff;" class="box box-default">
       
        
        <div class="box-body" style="display: block;">
          <div class="row">
            <div class="col-md-6">               
                <label id="lblId" runat="server" visible="false"></label>              
                            
              <div class="form-group">               
               <label>Project Name</label>              
               <asp:TextBox ID="txtProjectname" class="form-control" runat="server" placeholder="Enter Project Name ..." style="margin-left: 0px;"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ErrorMessage="* Please Enter Project Name!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="txtProjectname" ValidationGroup='valGroup1'></asp:RequiredFieldValidator> 
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ForeColor="Red" ControlToValidate="txtProjectname" SetFocusOnError="true" 
                    Display="Dynamic" ValidationExpression="[a-zA-Z ]*$" ErrorMessage="* Only Valid characters!" />
              </div>              
               
               
                <div class="form-group">
                        <label>Start Date:</label>
                        <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                        </cc1:ToolkitScriptManager>
                        <asp:TextBox ID="txtstartdate" onkeypress='return false' onclick="showDate();" runat="server" class="form-control pull-right" placeholder="Choose Start Date ..."></asp:TextBox>
                        <asp:ImageButton ID="imgPopup" ImageUrl="images/calendar.png" class="form-control pull-right" ImageAlign="Bottom" runat="server" Style="margin-top: -34px; width: 42px;" />
                        <cc1:CalendarExtender TodaysDateFormat="dd/MM/yyyy" ID="Calendar1" PopupButtonID="imgPopup" BehaviorID="Date" runat="server" TargetControlID="txtstartdate" Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                    </div>
                    <script type="text/javascript">
                        function showDate() {
                            $find("Date").show();
                        }
                    </script> 
                 <div class="form-group">
                        <label style="    margin-top: 10px;" >Due Date:</label>
                        <asp:TextBox ID="txtduedate" onkeypress='return false' onclick="showDate1();" runat="server" PopupButtonID="ImageButton1" class="form-control pull-right" placeholder="Choose Due Date ..."></asp:TextBox>
                        <asp:ImageButton ID="ImageButton1" ImageUrl="images/calendar.png" class="form-control pull-right" ImageAlign="Bottom" runat="server" Style="margin-top: -34px; width: 42px;" />
                        <cc1:CalendarExtender TodaysDateFormat="dd/MM/yyyy" ID="CalendarExtender1" BehaviorID="Date1" PopupButtonID="ImageButton1" runat="server" TargetControlID="txtduedate" Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                    </div>
                    <script type="text/javascript">
                        function showDate1() {
                            $find("Date1").show();
                        }
                    </script>
            </div>
           
            <div class="col-md-6">               
              <div class="form-group" >
                 <label>Employee</label>               
                  <asp:listbox runat="server" id="lstBoxTest" style="    height: 115px;" class="form-control" SelectionMode="Multiple"></asp:listbox> 
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ForeColor="Red" ErrorMessage="* Please Select Employee!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="lstBoxTest" ValidationGroup='valGroup1'></asp:RequiredFieldValidator> 
               </div> 
                <div class="checkbox" style="    margin-top: 30px;">
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

