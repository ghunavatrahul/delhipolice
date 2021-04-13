<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="ManageTask.aspx.cs" Inherits="ManageTask" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">Tasks </asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<%--<style>th{background:#3c8dbc} td:first-child {text-align: left;padding-left: 15px;}th:first-child {text-align: left;padding-left: 5px;}tr:hover{background:silver;cursor:pointer}tr:nth-child(even){background-color:#f4f4f4} </style>--%>
  <script>
      function OnSearch() {
          var task = document.getElementById('<%= txtSearch.ClientID %>').value;
          var Assigned = document.getElementById('<%= txtAssigned.ClientID %>').value;
          var Priority = document.getElementById('<%= ddlPriority.ClientID %>').value;
          var status = document.getElementById('<%= ddlActive.ClientID %>').value;
          if (task == "" && Assigned == "" && Priority == "" && status == "") {
              alert('Please fill any search fields!');
              return false;
          }
          return true;
      }
  </script>
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
  
  <asp:Button ID="btnAdd" class="btn btn-info pull-right" runat="server" Text="Add a Task" Style="margin-right: 55px;" OnClick="btnAdd_Click" />
  

     <br />
    <div style="margin-left: 8%;"> PageSize:
        <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" Style="width: 80px;  padding: 4px; margin-top:10px"  OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged" Width="80">
          <asp:ListItem Text="10" Value="10" />
          <asp:ListItem Text="25" Value="25" />
          <asp:ListItem Text="50" Value="50" />
          <asp:ListItem Text="100" Value="100" />

       </asp:DropDownList><br />
            
            </div>
    <div style="    margin-top: 20px;    float: left; margin-left: 8%; margin-bottom: 10px;" >
         <asp:Button ID="btnSearch" class="btn btn-info pull-right" runat="server" Text="Search" Style="margin-right: 15px;" OnClick="btnSearch_Click" OnClientClick="return OnSearch();" />
    
   
    <asp:DropDownList ID="ddlActive" runat="server" style="     width: 190px;   margin-right: 15px;      padding: 4px;   float: right;">
        <asp:ListItem Value="">-- Select Status --</asp:ListItem>
        <asp:ListItem Value="1">Open</asp:ListItem>
        <asp:ListItem Value="0">Close</asp:ListItem>
    </asp:DropDownList>
        <asp:DropDownList ID="ddlPriority" runat="server" style="     width: 190px;   margin-right: 15px;      padding: 4px;   float: right;">
        <asp:ListItem Value="">-- Select Priority --</asp:ListItem>
        <asp:ListItem Value="1">Low</asp:ListItem>
        <asp:ListItem Value="2">Medium</asp:ListItem>
        <asp:ListItem Value="3">High</asp:ListItem>
    </asp:DropDownList>
     <%--<asp:TextBox ID="txtActive" placeholder="Active ..." runat="server" style="    margin-right: 15px;      padding: 4px;   float: right;"></asp:TextBox>--%>
     <asp:TextBox ID="txtAssigned" placeholder="Assigned To ..." runat="server" style="   width: 237px; margin-right: 15px;      padding: 4px;   float: right;"></asp:TextBox>
    <asp:TextBox ID="txtSearch" placeholder="Task Title ..." runat="server" style=" width: 237px;   margin-right: 15px;      padding: 4px;   float: right;"></asp:TextBox>
   
</div>
    <%--<asp:Button ID="btnNotify" class="btn btn-info pull-right" runat="server" Text="Notification" Style="margin-right: 55px;" OnClick="btnNotify_Click" />--%>
  <div class="box" style="width:92%; margin-left:6%; margin-top:5%; margin-bottom:5%">
                                 
                  <asp:GridView ID="GridView1"  style="width: 95%;margin-left: 2%;" 
                AutoGenerateColumns="False" DataKeyNames="TaskID" runat="server" 
                  OnRowCommand="GridView1_RowCommand"  AllowPaging="True" OnRowDataBound="GridView1_OnRowDataBound"
                AllowSorting="True" onpageindexchanging="GridView1_PageIndexChanging" 
                CellPadding="4" ForeColor="#333333" GridLines="None" >
                  <PagerStyle HorizontalAlign = "Right" Width="100%" CssClass = "box yagya" /> 
                 <Columns>
                 <asp:TemplateField HeaderText = "S.No." ItemStyle-Width="1">
                    <ItemTemplate>
                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1+"." %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="TaskID" HeaderText="TaskID" Visible="false" />
                 <asp:TemplateField HeaderText="Task">
                <ItemTemplate>
                 <a href='TaskDetail.aspx?tasks=<%# Eval("TaskID") %>' style="    font-weight: bold;"><%# Eval("TaskTitle")%></a>                                  
               </ItemTemplate>
               </asp:TemplateField>
               <%-- <asp:BoundField DataField="TaskTitle" HeaderText="Task" />--%>
              <%--  <asp:BoundField DataField="Description" HeaderText="Description" />--%>
                <%--<asp:BoundField DataField="Assignedby" HeaderText="Assigned By" />--%>
              <%--   <asp:TemplateField HeaderText="Assigned By">
                    <ItemTemplate>
                        <%# Eval("Fname")%> <%# Eval("Mname")%> <%# Eval("Lname")%>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="Assigned To">
                <ItemTemplate>
                <asp:Label ID="gvassignto" runat="server" /><br /><asp:Label ID="lblassignto" runat="server" />                                    
               </ItemTemplate>
               </asp:TemplateField>
              <%--  <asp:BoundField DataField="Start_Date_Time" HeaderText="Start Date/Time" />          --%>    
                <asp:BoundField DataField="Due_Date_Time" HeaderText="Due Date"  />               
               <%-- <asp:BoundField DataField="TaskPriority" HeaderText="Priority" />--%>
                <asp:TemplateField HeaderText="Priority">
                    <ItemTemplate>
                        <asp:Label ID="lblpriority" runat="server" Text='<%# Bind("TaskPriority") %>' Font-Bold="true" ForeColor='<%# Convert.ToString(Eval("TaskPriority"))== ""?System.Drawing.Color.White: Convert.ToString(Eval("TaskPriority")) == "High" ? System.Drawing.Color.Red: Convert.ToString(Eval("TaskPriority")) == "Medium" ? System.Drawing.Color.Green: System.Drawing.Color.Orange%>' />                                    
                    </ItemTemplate>
               </asp:TemplateField>
               <%-- <asp:BoundField DataField="status" HeaderText="status" />--%>
                 <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <%# Eval("status")==DBNull.Value?" " :Convert.ToBoolean(Eval("status")) == true ? "Open" : "Close"%>
                        <%--<img src="dist/img/<%# Eval("status") %>.png" style="width: 12px; height: 12px;" title='<%# Convert.ToBoolean(Eval("status"))==true?"Open":"Close" %>' />--%>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--<asp:BoundField DataField="Projectstatus" HeaderText="Project Status" />--%>
                 <%--<asp:BoundField DataField="Attachment" HeaderText="Attachment" /> --%>                       
				  
                <asp:TemplateField HeaderText="Action" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                       <%-- <a href='TaskDetail.aspx?tasks=<%# Eval("TaskID") %>'>
                         <img src="images/tasks-icon.png" style="height: 20px;     margin-right: 20px; width: 20px;" title="Details" />
                        </a>--%>
                        <a href='NotificationAdd.aspx?tasks=<%# Eval("TaskID") %>'>
                         <img src="images/notify_icon.png" style="height: 20px;     margin-right: 20px; width: 20px;" title="Notification" />
                        </a>
                        <a href='TaskAdd.aspx?ID=<%# Eval("TaskID") %>'>
                            <img src="images/edit.ico" style="height: 20px;     margin-right: 20px; width: 20px;" title="Edit" />
                        </a>
                        <asp:LinkButton ToolTip="Delete" ID="R1" runat="server" CommandArgument='<%# Eval("TaskID") %>' OnClientClick="return confirm('Are you sure to remove this task?');" CommandName="Deletes"><img src="images/Delete_icon.png" style="height: 20px;width: 20px;" /> </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                </Columns>
                </asp:GridView>         
          </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

