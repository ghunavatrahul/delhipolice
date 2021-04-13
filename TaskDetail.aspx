<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="TaskDetail.aspx.cs" Inherits="TaskDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">Task Details</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<style>
        th {
            padding: 5px;
            background: #3c8dbc;
        }
        td:first-child {
            text-align: left;
            padding-left: 15px;
        }
        th:first-child {
            text-align: left;
            padding-left: 5px;
        }
        tr:hover {
            background: silver;
            cursor: pointer;
        }
        tr:nth-child(even) {
            background-color: #f4f4f4;
        }
        tr:last-child 
        {
            background: #f4f4f4!important;
            border: solid 1px silver;
        }       
        .GridPager table
        {       
            float: right;
        }
        .GridPager tr:hover {
            background: none;
            cursor: pointer;
        }
        .GridPager tr:last-child {
           border: none;
        }
        .GridPager td {   
            border: none;
        }
        .GridPager a {
            font-weight: bold;
            color: white;
            padding: 6px;
            background: #3c8dbc;
        }
        .GridPager span {
            font-weight: bold;
            color: black;
            padding: 6px;
            background: #3c8dbc;
        }             
    </style>

<div id="mydiv" style="width:80%; margin-left:10%; margin-top:5%; background:#ffffff;" class="box box-default">
              
        <div class="box-body" style="display: block;">
          <div class="row">
            <div class="col-md-6">
               <div class="form-group">
                <label id="lblId" runat="server" visible="false"></label>
                <label>Task</label>                               
                <asp:TextBox ID="txtTask" class="form-control" runat="server" ReadOnly="true"  style="margin-left: 0px;" ></asp:TextBox>                                                     
              </div>                 
              <div class="form-group" >
                 <label>Description </label>                 
                  <asp:TextBox ID="txtDescription" class="form-control" runat="server" ReadOnly="true"  TextMode="MultiLine" style="margin-left: 0px; height: 80px;"></asp:TextBox>                  
               </div>
              <div class="form-group">              
                 <label>Project Status </label>
                 <asp:TextBox ID="txtProjectStatus" class="form-control" runat="server" ReadOnly="true"  style="margin-left: 0px;" ></asp:TextBox> 
              </div>
               <div class="form-group">              
                 <label>Status </label>
                 <asp:TextBox ID="txtStatus" class="form-control" runat="server" ReadOnly="true"  style="margin-left: 0px;" ></asp:TextBox> 
              </div> 
              
            <div class="form-group">
                <label>Attached Files</label> 
                <%--<a href="FilesUpload/demo.txt">ll</a>--%>
                <asp:LinkButton ID="LinkButton1" ToolTip="Download" OnClick="LinkButton1_Click" runat="server"><img src="images/download_icon.png" style="height: 20px;width: 20px;" /> </asp:LinkButton>
                <asp:TextBox ID="txtAttachfiles" class="form-control" runat="server" ReadOnly="true"  style="margin-left: 0px;" ></asp:TextBox>                
            </div>             
           </div> 
                     
            <div class="col-md-6">               
               <div class="form-group">                
                <label>Priority</label>                               
                <asp:TextBox ID="txtPriority" class="form-control" runat="server" ReadOnly="true"  style="margin-left: 0px;"></asp:TextBox>                                                   
              </div> 
              <div class="form-group">
                <label>Assigned To </label> 
                <asp:TextBox ID="txtAssignedto" class="form-control" runat="server" ReadOnly="true"  style="margin-left: 0px;" ></asp:TextBox>
              </div>
             <div class="form-group">
                <label>Start Date</label> 
                <asp:TextBox ID="txtStartdate" class="form-control" runat="server" ReadOnly="true"  style="margin-left: 0px;" ></asp:TextBox>
            </div>
              <div class="form-group">
                <label>Due Date</label> 
                <asp:TextBox ID="txtDueDate" class="form-control" runat="server" ReadOnly="true"  style="margin-left: 0px;" ></asp:TextBox>
            </div>                                   
            </div>                      
          </div>         
        </div>        
        <%--<div class="box-footer" style="display: block;">
          <button id="btnCancel" runat="server" type="submit" class="btn btn-info pull-right" onserverclick="btnCancel_Click">Cancel</button>
          <button id="btnSave" runat="server"  type="submit" class="btn btn-info pull-right" onserverclick="btnSave_Click" ValidationGroup='valGroup1' style="margin-right: 15px;">Save</button>
        </div>--%>
      </div>

<div class="box" runat="server" visible="false" style="width:92%; margin-left:6%; margin-top:5%; margin-bottom:5%">
                                 
                  <asp:GridView ID="GridView1"  style="width: 95%;margin-left: 2%;" 
                AutoGenerateColumns="False" DataKeyNames="id" runat="server" OnRowDataBound="GridView1_OnRowDataBound" 
                  OnRowCommand="GridView1_RowCommand"  AllowPaging="True" 
                AllowSorting="True" onpageindexchanging="GridView1_PageIndexChanging" 
                CellPadding="4" ForeColor="#333333" GridLines="None" >
                  <PagerStyle HorizontalAlign = "Right" Width="100%" CssClass = "GridPager" /> 
                 <Columns>
                  <asp:TemplateField HeaderText = "S.No." ItemStyle-Width="1">
                    <ItemTemplate>
                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1+"."  %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="id" HeaderText="ID" Visible="false" />                
                <asp:TemplateField HeaderText="Notified By">
                    <ItemTemplate>
                        <%# Eval("Fname")%> <%# Eval("Mname")%> <%# Eval("Lname")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Notified To">
                <ItemTemplate>
                <asp:Label ID="gvnotifiedto" runat="server" />                                    
               </ItemTemplate>
              </asp:TemplateField>
                 <%--<asp:TemplateField HeaderText="Task">
                    <ItemTemplate>
                        <%# Eval("TaskID")%> 
                    </ItemTemplate>
                </asp:TemplateField>--%>           
                <asp:BoundField DataField="Subject" HeaderText="Subject" />              
                <%--<asp:BoundField DataField="Description" HeaderText="Description"  />  --%>             
                <asp:BoundField DataField="Updated_date" HeaderText="Updated Date" />
               <%-- <asp:BoundField DataField="Readfield" HeaderText="Read" />--%>
               		  
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <a href='NotificationAdd.aspx?ID=<%# Eval("id") %>'>
                            <img src="images/edit.ico" style="height: 20px;     margin-right: 20px; width: 20px;" title="Edit" />
                        </a>
                        <asp:LinkButton ToolTip="Delete" ID="R1" runat="server" CommandArgument='<%# Eval("id") %>' OnClientClick="return confirm('Are you sure to remove this Notification?');" CommandName="Deletes"><img src="images/Delete_icon.png" style="height: 20px;width: 20px;" /> </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                </Columns>
                </asp:GridView>         
          </div>

<div class="box" style="width: 80%;margin-left: 10%; margin-bottom: 5%;">
    <div class="box-header ui-sortable-handle" style="cursor: move;">
    <h3 class="box-title"> Notifications</h3> 
    </div>
        <div class="box-body">
            <ul class="todo-list ui-sortable">
                <asp:Repeater ID="Repeater1" runat="server">                            
                    <ItemTemplate >
                        <li>
                            <b style=" margin-left: 50px;"> <%# Eval("Fname")%> <%# Eval("Mname")%> <%# Eval("Lname")%></b> (SP Dynamics Services Pvt. Ltd.)
                            <small style="padding-bottom: 4px; float: right;"><i class="fa fa-clock-o"></i>
                            <%# Eval("Updated_date")%>
                            </small> <br /><p style="    margin-left: 50px;"><a href="NotificationShow.aspx?ID=<%# Eval("id")%>"><%# Eval("Subject")%></a></p>
                       </li>
                    </ItemTemplate>        
                </asp:Repeater>
            </ul>
        </div>
</div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

