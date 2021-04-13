<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="EmployeeTracking.aspx.cs" Inherits="EmployeeTracking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server" ><label style="margin-left:2%;margin-top:50px"></label>&nbsp<b>Tracking</b></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel runat="server" id="UpdatePanel" updatemode="Conditional">
          <ContentTemplate>
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
      <div>
         <label style="margin-left:9.8%;margin-top:50px"></label>&nbsp<b>Page Size:</b>
        <asp:DropDownList ID="ddlPageSize" runat="server" style="width:100px;padding:4px;" AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged" Width="80">
          <%--<asp:ListItem Text="10" Value="10" />--%>
          <asp:ListItem Text="20" Value="20" />
          <asp:ListItem Text="50" Value="50" />
            <asp:ListItem Text="100" Value="100" />
       </asp:DropDownList><br />
            
            </div>
  <div  style="width: 100%; margin-left: 6%; margin-top: 1%; margin-bottom: 5%">

        <asp:GridView ID="GridView1" Style="width: 80%; margin-left: 4%;" AutoGenerateColumns="False" DataKeyNames="ID" OnRowDataBound="GridView1_OnRowDataBound" 
        runat="server" OnRowCommand="GridView1_RowCommand" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="GridView1_PageIndexChanging" CellPadding="4" 
         GridLines="None" PageSize="20">
        <PagerStyle HorizontalAlign = "Right" Width="100%" CssClass = "box yagya" />
            <Columns>
                <asp:TemplateField HeaderText = "S.No." ItemStyle-Width="8">
                    <ItemTemplate>
                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 +"."%>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:BoundField DataField="ID" HeaderText="ID" Visible="false" />
                 
                <asp:TemplateField HeaderText="Employee Name">
                    <ItemTemplate>
                        <asp:Label ID="gvemp" runat="server" />                                    
                    </ItemTemplate>
               </asp:TemplateField>   
                <asp:BoundField DataField="TrackTime" HeaderText="Track Time" />
                <asp:BoundField DataField="LastLocation" HeaderText="Last Location" />             
               
                <asp:TemplateField HeaderText="Action"  ItemStyle-Width="8%" >
                    <ItemTemplate>                        
                       <%-- <a href='ProjectAdd.aspx?ID=<%# Eval("ProjectId") %>'>
                            <img src="images/edit.ico" style="height: 20px; margin-right: 20px; width: 20px;" title="Edit" />
                        </a>--%>
                        <asp:LinkButton ToolTip="Delete" ID="R1" runat="server" CommandArgument='<%# Eval("ID") %>' OnClientClick="return confirm('Are you sure to remove this Tracking?');" CommandName="Deletes"><img src="images/Delete_icon.png" style="height: 20px;width: 20px;" /> </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
              </ContentTemplate>
           <Triggers>
            <asp:AsyncPostBackTrigger controlid="ddlPageSize" eventname="SelectedIndexChanged" />
               <%-- <asp:AsyncPostBackTrigger controlid="btnCancel" eventname="Click" />--%>
               
        </Triggers>
      </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

