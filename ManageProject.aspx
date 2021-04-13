<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="ManageProject.aspx.cs" Inherits="ManageProject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">Project Details</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <script>
        function OnSearch() {
            var task = document.getElementById('<%= txtSearch.ClientID %>').value;
            var Assigned = document.getElementById('<%= txtAssigned.ClientID %>').value;
            var status = document.getElementById('<%= ddlActive.ClientID %>').value;
            if (task == "" && Assigned == "" && status == "") {
                alert('Please fill any search fields!');
                return false;
            }
            return true;
        }
        function validate() {
            if ($("#<%= FileUpload1.ClientID %>").val() == '') {
                alert('Please select CSV file!')
                return false;
            }
            return true;
        }


        function CSV() {
            $("#csv").toggle();
            return false;
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

    <asp:Button ID="btnAdd" class="btn btn-info pull-right" runat="server" Text="Add Project" Style="margin-right: 55px;" OnClick="btnAdd_Click" />
    <asp:Button ID="btnImportCSVClient" class="btn btn-info pull-right" runat="server" Text="Import CSV" Style="margin-right: 25px;" OnClientClick="return  CSV();" />
    <div id="csv" style="display: none; padding: 16px 16px 6px 16px; background: white; float: right; margin-top: -16px; border-radius: 10px; margin-right: 25px;">
        <asp:Button ID="btnImportCSV" class="btn btn-info pull-right" runat="server" Text="Upload CSV" OnClick="btnImportCSV_Click" OnClientClick="return validate();" />
        <asp:FileUpload ID="FileUpload1" runat="server" accept=".csv" Style="float: right;"  />
        <br />
    </div>
    <br />
    <br />
    <div style="margin-top: 20px; float: left; margin-left: 8%; margin-bottom: 10px;">
        <asp:Button ID="btnSearch" class="btn btn-info pull-right" runat="server" Text="Search" Style="margin-right: 15px;" OnClientClick="return OnSearch();" />
        <asp:DropDownList ID="ddlActive" runat="server" Style="width: 210px; margin-right: 15px; padding: 4px; float: right;">
            <asp:ListItem Value="">-- Select Status --</asp:ListItem>
            <asp:ListItem Value="1">Open</asp:ListItem>
            <asp:ListItem Value="0">Close</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="txtAssigned" placeholder="Assigned To ..." runat="server" Style="width: 335px; margin-right: 15px; padding: 4px; float: right;"></asp:TextBox>
        <asp:TextBox ID="txtSearch" placeholder="Project Name ..." runat="server" Style="width: 335px; margin-right: 15px; padding: 4px; float: right;"></asp:TextBox>
    </div>
    <div class="box" style="width: 92%; margin-left: 6%; margin-top: 5%; margin-bottom: 5%">
          <asp:GridView ID="GridView2" runat="server"></asp:GridView>
        <asp:GridView ID="GridView1" Style="width: 95%; margin-left: 2%;" AutoGenerateColumns="False" DataKeyNames="ProjectId" OnRowDataBound="GridView1_OnRowDataBound"
            runat="server" OnRowCommand="GridView1_RowCommand" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="GridView1_PageIndexChanging" CellPadding="4"
            GridLines="None">
            <PagerStyle HorizontalAlign="Right" Width="100%" CssClass="GridPager" />
            <Columns>
                <asp:TemplateField HeaderText="S.No." ItemStyle-Width="1">
                    <ItemTemplate>
                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 +"."%>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ProjectId" HeaderText="Project Id" Visible="false" />
                <asp:TemplateField HeaderText="Project Name">
                    <ItemTemplate>
                        <a href='ManageTask.aspx?project=<%# Eval("ProjectId") %>' style="font-weight: bold;"><%# Eval("Project_Name")%></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Employee Name">
                    <ItemTemplate>
                        <asp:Label ID="gvemp" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Due_Date" HeaderText="Due Date" />
                <asp:TemplateField HeaderText="Status" ItemStyle-Width="7%">
                    <ItemTemplate>
                        <img src="dist/img/<%# Eval("Status") %>.png" style="width: 12px; height: 12px;" title='<%# Eval("Status")==DBNull.Value?" ":Convert.ToBoolean(Eval("Status"))==true?"Active":"InActive" %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action" ItemStyle-Width="18%">
                    <ItemTemplate>
                        <a href='TaskAdd.aspx?project=<%# Eval("ProjectId") %>' style="margin-right: 15px; padding: 2px 5px 2px 5px; background: #3c8dbc; color: white; border-radius: 5px;" title="Add Task">Add Task</a>
                        <a href='ProjectAdd.aspx?ID=<%# Eval("ProjectId") %>'>
                            <img src="images/edit.ico" style="height: 20px; margin-right: 20px; width: 20px;" title="Edit" />
                        </a>
                        <asp:LinkButton ToolTip="Delete" ID="R1" runat="server" CommandArgument='<%# Eval("ProjectId") %>' OnClientClick="return confirm('Are you sure to remove this employee?');" CommandName="Deletes"><img src="images/Delete_icon.png" style="height: 20px;width: 20px;" /> </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

