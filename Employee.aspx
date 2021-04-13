<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" EnableViewState="true" CodeFile="Employee.aspx.cs" Inherits="Employee" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">Manage Employee</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script>
        function OnSearch() {
            var emp = document.getElementById('<%= txtEmployeeName.ClientID %>').value;
           var email = document.getElementById('<%= txtEmailId.ClientID %>').value;
           var role = document.getElementById('<%= txtRoles.ClientID %>').value;
           var status = document.getElementById('<%= ddlActive.ClientID %>').value;
           if (emp == "" && email == "" && role == "" && status == "") {
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
    <asp:Button ID="btnAdd" class="btn btn-info pull-right" runat="server" Text="Create Employee" Style="margin-right: 55px;" OnClick="btnAdd_Click" />
    <br />
    <div style="float: left; margin-left: 8%; margin-bottom: 10px;" runat="server">
                  PageSize:
        <asp:DropDownList ID="ddlPageSize" runat="server" Style="width: 167px; padding: 4px;" AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged" >
        <%--  <asp:ListItem Text="10" Value="10" />--%>
          <asp:ListItem Text="20" Value="20" />
          <asp:ListItem Text="50" Value="50" />
            <asp:ListItem Text="100" Value="100" />
       </asp:DropDownList><br />
            
            </div>
    <div style="margin-top: 20px; float: left; margin-left: 8%; margin-bottom: 10px;">
        <asp:Button ID="btnSearch" class="btn btn-info pull-right" runat="server" Text="Search" Style="margin-right: 15px;" OnClick="btnSearch_Click" OnClientClick="return OnSearch();" />


        <asp:DropDownList ID="ddlActive" runat="server" Style="width: 167px; margin-right: 15px; padding: 4px; float: right;">
            <asp:ListItem Value="">-- Select --</asp:ListItem>
            <asp:ListItem Value="1">Active</asp:ListItem>
            <asp:ListItem Value="0">InActive</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="txtActive" placeholder="Active ..." runat="server" style="    margin-right: 15px;      padding: 4px;   float: right;"></asp:TextBox>--%>
        <asp:TextBox ID="txtRoles" placeholder="Roles ..." runat="server" Style="width: 215px; margin-right: 15px; padding: 4px; float: right;"></asp:TextBox>
        <asp:TextBox ID="txtEmailId" placeholder="Email Id ..." runat="server" Style="width: 240px; margin-right: 15px; padding: 4px; float: right;"></asp:TextBox>
        <asp:TextBox ID="txtEmployeeName" placeholder="Employee Name ..." runat="server" Style="width: 240px; margin-right: 15px; padding: 4px; float: right;"></asp:TextBox>

    </div>

    <div class="box" style="width: 92%; margin-left: 6%; margin-top: 5%; margin-bottom: 5%">

        <asp:GridView ID="GridView1" Style="width: 95%; margin-left: 2%;" AutoGenerateColumns="False" DataKeyNames="ID" OnRowDataBound="GridView1_OnRowDataBound"
            runat="server" OnRowCommand="GridView1_RowCommand" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="GridView1_PageIndexChanging" CellPadding="4"
            GridLines="None" PageSize="20">
            <PagerStyle HorizontalAlign="Right" Width="100%" CssClass="GridPager" />
            <Columns>
                <asp:TemplateField HeaderText="S.No." ItemStyle-Width="1">
                    <ItemTemplate>
                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 +"."%>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ID" HeaderText="Emp Code" ItemStyle-Width="8%" />
                <asp:TemplateField HeaderText="Employee Name">
                    <ItemTemplate>
                        <%# Eval("Fname")%> <%# Eval("Mname")%> <%# Eval("Lname")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="EmailID" HeaderText="Email ID" />

                <asp:TemplateField HeaderText="Roles" ItemStyle-Width="10%">
                    <ItemTemplate>
                        <asp:Label ID="gvrole" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="PhoneNO" HeaderText="Phone Number" ItemStyle-Width="12%" />
                <asp:TemplateField HeaderText="Active">
                    <ItemTemplate>
                        <img src="dist/img/<%# Eval("isActive") %>.png" style="width: 12px; height: 12px;" title='<%# Eval("isActive")==DBNull.Value?" ":Convert.ToBoolean(Eval("isActive"))==true?"Active":"InActive" %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <a href='EmployeeAdd.aspx?ID=<%# Eval("ID") %>'>
                            <img src="images/edit.ico" style="height: 20px; margin-right: 20px; width: 20px;" title="Edit" />
                        </a>
                        <asp:LinkButton ToolTip="Delete" ID="R1" runat="server" CommandArgument='<%# Eval("ID") %>' OnClientClick="return confirm('Are you sure to remove this employee?');" CommandName="Deletes"><img src="images/Delete_icon.png" style="height: 20px;width: 20px;" /> </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>


