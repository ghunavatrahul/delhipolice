<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="WareHouse.aspx.cs" Inherits="WareHouse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">WareHouse Management</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel runat="server" id="UpdatePanel" updatemode="Conditional">
          <ContentTemplate>
    <script>
        function OnSearch() {
            var cust = document.getElementById('<%= txtName.ClientID %>').value;
           <%-- var email = document.getElementById('<%= txtEmailId.ClientID %>').value;--%>
            var status = document.getElementById('<%= ddlActive.ClientID %>').value;
            if (cust == "" && email == "" && status == "") {
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

        tr:last-child {
            background: #f4f4f4 !important;
            border: solid 1px silver;
        }

        .GridPager table {
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
    <asp:Button ID="btnAdd" class="btn btn-info pull-right" runat="server" Text="Create Warehouse" Style="margin-right: 5%" OnClick="btnAdd_Click" />
    <br />
    <%--<div>
               &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp       PageSize:
        <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged" Width="80">
          <asp:ListItem Text="10" Value="10" />
          <asp:ListItem Text="25" Value="25" />
          <asp:ListItem Text="50" Value="50" />
            <asp:ListItem Text="100" Value="100" />
       </asp:DropDownList><br />
            
            </div>--%>
    <div style="margin-top: 20px; float: left; margin-left: 33.5%; margin-bottom: 10px;">
        <asp:Button ID="btnSearch" class="btn btn-info pull-right" runat="server" Text="Search" Style="margin-right: 15px;" OnClick="btnSearch_Click" OnClientClick="return OnSearch();" />
<%--         <asp:TextBox ID="txtEmailId" placeholder="Email Id ..." runat="server" Style="width: 240px; margin-right: 15px; padding: 4px; float: right;"></asp:TextBox>--%>
        <asp:TextBox ID="txtName" placeholder=" Name ..." runat="server" Style="width: 240px; margin-right: 15px; padding: 4px; float: right;"></asp:TextBox>
        <asp:DropDownList ID="ddlActive" runat="server" Style="width: 167px; margin-right: 15px; padding: 4px; float: right;">
            <asp:ListItem Value="">-- Select --</asp:ListItem>
            <asp:ListItem Value="1">Active</asp:ListItem>
            <asp:ListItem Value="0">InActive</asp:ListItem>
        </asp:DropDownList> 
          <b> PageSize:</b>&nbsp
        <asp:DropDownList ID="ddlPageSize" runat="server" Style="width: 100px; margin-right: 15px; padding: 4px; float: right;"  AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged" Width="80">
          <%--<asp:ListItem Text="10" Value="10" />--%>
          <asp:ListItem Text="20" Value="20" />
          <asp:ListItem Text="50" Value="50" />
            <asp:ListItem Text="100" Value="100" />
       </asp:DropDownList><br />     
    </div>
    <div class="box" style="width: 92%; margin-left: 6%; margin-top: 5%; margin-bottom: 5%">

        <asp:GridView ID="GridView1" Style="width: 95%; margin-left: 2%;" AutoGenerateColumns="False" DataKeyNames="WarehouseId" 
            runat="server" OnRowCommand="GridView1_RowCommand" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="GridView1_PageIndexChanging" CellPadding="4"
            GridLines="None" PageSize="20">
            <PagerSettings PageButtonCount="3" />
            <PagerStyle HorizontalAlign="Right" Width="100%" CssClass="box yagya" />
            <Columns>
                <asp:TemplateField HeaderText="S.No." ItemStyle-Width="8%">
                    <ItemTemplate>
                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 +"."%>' runat="server" />
                    </ItemTemplate>
                    <ItemStyle Width="8%" />
                </asp:TemplateField>
                <asp:BoundField DataField="WarehouseId" HeaderText="Warehouse ID" ItemStyle-Width="8%"  Visible="false">
                <ItemStyle Width="8%" />
                </asp:BoundField>
                <asp:TemplateField HeaderText=" WareHouse Name">
                    <ItemTemplate>
                        <%# Eval("Fname")%>
                    </ItemTemplate>
                </asp:TemplateField>
<%--                <asp:BoundField DataField="EmailID" ItemStyle-Width="15%" HeaderText="Email ID" />--%>
             
                <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" ItemStyle-Width="12%" >
                <ItemStyle Width="12%" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Active" ItemStyle-Width="8%">
                    <ItemTemplate>
                        <img src="dist/img/<%# Eval("Status") %>.png" style="width: 12px; height: 12px;" title='<%# Eval("Status")==DBNull.Value?" ":Convert.ToBoolean(Eval("Status"))==true?"Active":"InActive" %>' />
                    </ItemTemplate>
                    <ItemStyle Width="8%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action" ItemStyle-Width="10%">
                    <ItemTemplate>
                        <a href='WareHouseAdd.aspx?WarehouseId=<%# Eval("WarehouseId") %>'>
                            <img src="images/edit.ico" style="height: 20px; margin-right: 20px; width: 20px;" title="Edit" />
                        </a>
                        <asp:LinkButton ToolTip="Delete" ID="R1" runat="server" CommandArgument='<%# Eval("WarehouseId") %>' OnClientClick="return confirm('Are you sure to remove this Warehouse?');" CommandName="Deletes"><img src="images/Delete_icon.png" style="height: 20px;width: 20px;" /> </asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="10%" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
   </ContentTemplate>
           <Triggers>
         <asp:AsyncPostBackTrigger controlid="ddlPageSize" eventname="SelectedIndexChanged" />
               <%-- <asp:AsyncPostBackTrigger controlid="btnCancel" eventname="Click" />
               <asp:AsyncPostBackTrigger controlid="btnAdd" eventname="Click" />
            <asp:AsyncPostBackTrigger controlid="btnEdit" eventname="Click" />--%>
        </Triggers>
            </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

