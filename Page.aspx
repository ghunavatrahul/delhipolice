<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Page.aspx.cs" Inherits="Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div id="mydiv" style="width:80%; margin-left:10%; margin-top:5%" class="box box-default">
        <div class="box-header with-border">
          <h3 class="box-title">Page </h3>

         
        </div>        
        <div class="box-body" style="display: block;">
          <div class="row">
            <div class="col-md-6" style="margin-left: 27%;">
               <div class="form-group">
                <label id="lblId" runat="server" visible="false"></label>
                <label>Name</label>                               
                <asp:TextBox ID="txtName" class="form-control" runat="server" placeholder="Enter ..." style="margin-left: 0px;"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ErrorMessage="* Please Enter Name!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="txtName" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>                                  
              </div>              
               <div class="checkbox">
                 <label><input id="chkActive" runat="server" type="checkbox"> Active</label>
              </div>
            </div>                      
          </div>         
        </div>        
        <div class="box-footer" style="display: block;">
          <button id="btnCancel" runat="server" type="submit" class="btn btn-default" onserverclick="btnCancel_Click">Cancel</button>
          <button id="btnSubmit" runat="server"  type="submit" class="btn btn-info pull-right" onserverclick="btnSubmit_Click" ValidationGroup='valGroup1'>Submit</button>
        </div>
      </div>

 <div class="box" style="width:95%; margin-left:2%; margin-top:5%; margin-bottom:5%">
            <div class="box-header">
              <h3 class="box-title">Page Detail</h3>
            </div>                        
                  <asp:GridView ID="GridView1" style="width:100%" AutoGenerateColumns="False" DataKeyNames="ID" runat="server" 
                   >
                  <Columns>
                <asp:BoundField DataField="Page_ID" HeaderText="Page ID" Visible="false" />                
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Status" HeaderText="Status" />
                <asp:BoundField DataField="Lname" HeaderText="Last Name" />
                <asp:BoundField DataField="EmailID" HeaderText="EmailID" />
                <asp:BoundField DataField="PhoneNO" HeaderText="Phone Number" />
                <%--<asp:BoundField DataField="Role" HeaderText="Role" />--%>
                <asp:BoundField DataField="isActive" HeaderText="Active" />   
                <asp:CommandField ShowSelectButton="true"  />                
                <%--<asp:CommandField ShowEditButton="true" />--%>
                <asp:CommandField ShowDeleteButton="true" />
                </Columns>
                </asp:GridView>         
          </div>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

