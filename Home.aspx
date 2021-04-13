<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<style>
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
    </style>--%>
    <div class="box box-primary" style="width: 92%; margin-top: -30px; margin-left: 6%;">
        <style>
            td {
                padding: 1px;
                text-align: center;
            }
        </style>
        <div class="box-header ui-sortable-handle" style="cursor: move;">
            <i class="ion ion-clipboard"></i>
            <h3 class="box-title">To Do List</h3>
            <div class="box-tools pull-right">
                <%--<ul class="pagination pagination-sm inline">
                    <li><a href="#">«</a></li>
                    <li><a href="#">1</a></li>
                    <li><a href="#">2</a></li>
                    <li><a href="#">3</a></li>
                    <li><a href="#">»</a></li>--%>

                <asp:DataList ID="rptPaging" runat="server" OnItemCommand="rptPaging_ItemCommand" OnItemDataBound="rptPaging_ItemDataBound" Style="background: #fafafa; font-weight: bold;" RepeatDirection="Horizontal">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbPaging" runat="server" CommandArgument='<%# Eval("PageIndex") %>' CommandName="newPage" Text='<%# Eval("PageText") %> ' Width="20px">	</asp:LinkButton>
                    </ItemTemplate>
                </asp:DataList>

                <%--</ul>--%>
            </div>
        </div>
        <!-- /.box-header -->
        <div class="box-body">
            <ul class="todo-list ui-sortable">
                <asp:Repeater ID="RepMenu" runat="server">
                    <ItemTemplate>
                        <li>
                            <a href="NotificationShow.aspx?ID=<%# Eval("id")%>">
                                <!-- drag handle -->
                                <span class="handle ui-sortable-handle"><i class="fa fa-ellipsis-v"></i><i class="fa fa-ellipsis-v"></i></span><span class="text">
                                    <%# Eval("TaskTitle")%>
                                </span>
                                <!-- Emphasis label -->
                                <small class="label label-danger" style="padding-bottom: 4px; float: right;"><i class="fa fa-clock-o"></i>
                                    <%# Eval("Updated Before")%></small></a>
                            <!-- General tools such as edit or delete-->
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <!-- /.box-body -->
    </div>
    <div class="box box-solid bg-green-gradient" style="width: 92%; margin-left: 6%; margin-top: 5%; margin-bottom: 5%">
        <div class="box-header ui-sortable-handle" style="cursor: move;">
            <i class="fa fa-calendar"></i>
            <h3 class="box-title">Calendar</h3>
            <div class="pull-right box-tools">
                <div class="btn-group">
                    <button type="button" class="btn btn-success btn-sm dropdown-toggle" data-toggle="dropdown">
                        <i class="fa fa-bars"></i>
                    </button>
                    <ul class="dropdown-menu pull-right" role="menu">
                        <li><a href="TaskAdd.aspx">Add new task</a></li>
                        <%-- <li><a href="#">Clear events</a></li>
                        <li class="divider"></li>
                        <li><a href="#">View calendar</a></li>--%>
                    </ul>
                </div>
            </div>
        </div>
        <div class="box-body no-padding">
            <asp:Calendar ID="Calendar1" runat="server" Width="100%" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
        </div>
    </div>

    <div class="box" style="width: 92%; margin-left: 6%; margin-top: 5%; margin-bottom: 5%;">
        <asp:GridView ID="GridView1" Style="width: 100%; background-color: #00b160;"
            AutoGenerateColumns="False" DataKeyNames="TaskID" runat="server"
            CellPadding="4" ForeColor="#333333" GridLines="None">
            <PagerStyle HorizontalAlign="Right" Width="100%" CssClass="GridPager" />
            <Columns>
                <asp:TemplateField HeaderText="S.No." ItemStyle-Width="1">
                    <ItemTemplate>
                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1+"." %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="TaskID" HeaderText="TaskID" Visible="false" />
                <asp:TemplateField HeaderText="Task">
                    <ItemTemplate>
                        <%# Eval("TaskTitle")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Description" HeaderText="Description" />
                <%--<asp:BoundField DataField="Assignedby" HeaderText="Assigned By" />--%>
                <%--   <asp:TemplateField HeaderText="Assigned By">
                    <ItemTemplate>
                        <%# Eval("Fname")%> <%# Eval("Mname")%> <%# Eval("Lname")%>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <%--<asp:TemplateField HeaderText="Assigned To">
                <ItemTemplate>
                <asp:Label ID="gvassignto" runat="server" /><br /><asp:Label ID="lblassignto" runat="server" />                                    
               </ItemTemplate>
               </asp:TemplateField>--%>
                <%--  <asp:BoundField DataField="Start_Date_Time" HeaderText="Start Date/Time" />          --%>
                <asp:BoundField DataField="Due_Date_Time" HeaderText="Due Date" />
                <asp:TemplateField HeaderText="Priority">
                    <ItemTemplate>
                        <asp:Label ID="lblpriority" runat="server" Text='<%# Bind("TaskPriority") %>' Font-Bold="true" ForeColor='<%# Convert.ToString(Eval("TaskPriority")) == "High" ? System.Drawing.Color.Red: Convert.ToString(Eval("TaskPriority")) == "Medium" ? System.Drawing.Color.Green: System.Drawing.Color.Orange%>' />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>

        <asp:Label ID="Label1" runat="server"></asp:Label>
    </div>
</asp:Content>
