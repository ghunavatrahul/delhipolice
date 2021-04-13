<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Manpower1.aspx.cs" Inherits="Manpower1" %>
 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">Add Edit Deployment</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
    <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.10.0.min.js" type="text/javascript"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/jquery-ui.min.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/themes/blitzer/jquery-ui.css"
        rel="Stylesheet" type="text/css" />
    
   
    <div id="mydiv" style="width:80%; margin-left:10%; margin-top:5%;  background:#ffffff;" class="box box-default">        
        <div class="box-body" style="display: block;">
          <div class="row">
            <div class="col-md-6"> 
                <label id="lblId" runat="server" visible="false"></label>                                                 
                   <div class="form-group">
                <label>Mod/Static Duty</label>               
                 <asp:TextBox ID="txtModStaticDuty" class="form-control" runat="server" placeholder="Enter Mod/Static Duty" style="margin-left: 0px;" ></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ForeColor="Red" ErrorMessage="* Please Enter Mod/Static Duty" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="txtModStaticDuty" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="Red" ControlToValidate="txtModStaticDuty" SetFocusOnError="true" 
                 Display="Dynamic" ValidationExpression="[a-zA-Z0-9 /.()]*$" ErrorMessage="* Only Valid characters!" />
                 <asp:HiddenField ID="hfDeploymentId" runat="server" />      
              </div>          
               <div class="form-group">
                <label>Pattern Timing</label>             
                <asp:TextBox ID="txtPatternTiming" class="form-control" runat="server" placeholder="Enter Pattern/Timing ..." />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ForeColor="Red" ControlToValidate="txtPatternTiming" SetFocusOnError="true" 
                 Display="Dynamic" ValidationExpression="[a-zA-Z0-9() .-]*$" ErrorMessage="* Only Valid characters!" />
              </div>                 
                  <div class="form-group">
                <label>US Count</label>               
                 <asp:TextBox ID="txtUS" class="form-control" runat="server" placeholder="Enter Value for US ..." style="margin-left: 0px;" ></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ForeColor="Red" ErrorMessage="* Please Enter SI count!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="txtUS" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>  
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtUS" ErrorMessage="! Only numeric allowed." 
                    ForeColor="Red" ValidationExpression="^[0-9]*$" ValidationGroup="valGroup1" Display="Dynamic" SetFocusOnError="true"></asp:RegularExpressionValidator>                    
              </div>
                <div class="form-group">
                <label>HC Count</label>               
                 <asp:TextBox ID="txtHC" class="form-control" runat="server" placeholder="Enter Value for HC ..." style="margin-left: 0px;" ></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ErrorMessage="* Please Enter HC count!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="txtHC" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>  
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtHC" ErrorMessage="! Only numeric allowed." 
                    ForeColor="Red" ValidationExpression="^[0-9]*$" ValidationGroup="valGroup1" Display="Dynamic" SetFocusOnError="true"></asp:RegularExpressionValidator>                    
              </div>
                <div class="form-group">
                <label>CT Count</label>               
                 <asp:TextBox ID="txtCT" class="form-control" runat="server" placeholder="Enter Value for CTs ..." style="margin-left: 0px;" ></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ErrorMessage="* Please Enter CT count!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="txtCT" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>  
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtCT" ErrorMessage="! Only numeric allowed." 
                    ForeColor="Red" ValidationExpression="^[0-9]*$" ValidationGroup="valGroup1" Display="Dynamic" SetFocusOnError="true"></asp:RegularExpressionValidator>                    
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
          
          <button id="btnCancel" runat="server" type="submit" class="btn btn-info pull-right" onserverclick="btnCancel_Click" style="background-color:#117A65;" causesvalidation="false">Cancel</button>
            <asp:Button id="btnSubmit" runat="server" Text="Save" class="btn btn-info pull-right" OnClick="btnSubmit_Click" ValidationGroup='valGroup1' style="margin-right: 15px; background-color:#117A65;"/>
       <%--   <button id="btnSubmit" runat="server"  type="submit" class="btn btn-info pull-right" onserverclick="btnSubmit_Click" ValidationGroup='valGroup1' style="margin-right: 15px;">Submit</button>--%>
        </div>
      
      </div>
      
</asp:Content>


