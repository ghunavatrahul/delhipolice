<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Notification.aspx.cs" Inherits="Notification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">Notification </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<%--<style>th{background:#3c8dbc} td:first-child {text-align: left;padding-left: 15px;}th:first-child {text-align: left;padding-left: 5px;}tr:hover{background:silver;cursor:pointer}tr:nth-child(even){background-color:#f4f4f4} </style>--%>

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
  <asp:Button ID="btnAdd" class="btn btn-info pull-right" runat="server" Text="Add Notification" Style="margin-right: 5%" OnClick="btnAdd_Click" />
     <div>
        <label style="margin-left:10%;margin-top:40px"> <b>PageSize :</b> </label>
        <asp:DropDownList ID="ddlPageSize" runat="server" style="width:100px;padding:4px" AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged" Width="80">
         <%-- <asp:ListItem Text="10" Value="10" />--%>
          <asp:ListItem Text="20" Value="20" />
          <asp:ListItem Text="50" Value="50" />
          <asp:ListItem Text="100" Value="100" />

       </asp:DropDownList><br />
            
            </div>
 <div class="box" style="width:90%; margin-left:8%; margin-top:2%; margin-bottom:5%">
                                 
                  <asp:GridView ID="GridView1"  style="width: 95%;margin-left: 2%;" 
                AutoGenerateColumns="False" DataKeyNames="id" runat="server" OnRowDataBound="GridView1_OnRowDataBound" 
                  OnRowCommand="GridView1_RowCommand"  AllowPaging="True" 
                AllowSorting="True" onpageindexchanging="GridView1_PageIndexChanging" 
                CellPadding="4" ForeColor="#333333" GridLines="None" >
                  <PagerStyle HorizontalAlign = "Right" Width="100%" CssClass = "box yagya" /> 
                 <Columns>
                  <asp:TemplateField HeaderText = "S.No." ItemStyle-Width="8%">
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
                <%--<asp:BoundField DataField="Description" HeaderText="Description"  /> --%>              
                <asp:BoundField DataField="Updated_date" HeaderText="Last Updated" />
                <%--<asp:BoundField DataField="Readfield" HeaderText="Read" />--%>
               		  
                <asp:TemplateField HeaderText="Action" ItemStyle-Width="10%">
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

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

