<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Vendor.aspx.cs" Inherits="Vendor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">Manage Vendor</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel runat="server" id="UpdatePanel" updatemode="Conditional">
          <ContentTemplate>
      <script>
          function OnSearch() {
              var vend = document.getElementById('<%= txtVendorName.ClientID %>').value;
            var email = document.getElementById('<%= txtEmailId.ClientID %>').value;
            var status = document.getElementById('<%= ddlActive.ClientID %>').value;
              if (vend == "" && email == "" && status == "") {
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
              <asp:Button ID="btnAdd" class="btn btn-info pull-right" runat="server" Text="Create Vendor" Style="margin-right: 55px;" OnClick="btnAdd_Click" />
     <br />
   <%-- <div>
               &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp       PageSize:
        <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged" Width="80">
          <asp:ListItem Text="10" Value="10" />
          <asp:ListItem Text="25" Value="25" />
          <asp:ListItem Text="50" Value="50" />
            <asp:ListItem Text="100" Value="100" />
       </asp:DropDownList><br />
            
      </div>--%>
    <div style="margin-top: 20px; float: left; margin-left: 13%; margin-bottom: 10px;">
        <asp:Button ID="btnSearch" class="btn btn-info pull-right" runat="server" Text="Search" Style="margin-right: 15px;" OnClick="btnSearch_Click" OnClientClick="return OnSearch();" />
         <asp:TextBox ID="txtEmailId" placeholder="Email Id ..." runat="server" Style="width: 240px; margin-right: 15px; padding: 4px; float: right;"></asp:TextBox>
        <asp:TextBox ID="txtVendorName" placeholder="Vendor Name ..." runat="server" Style="width: 240px; margin-right: 15px; padding: 4px; float: right;"></asp:TextBox>
        <asp:DropDownList ID="ddlActive" runat="server" Style="width: 167px; margin-right: 15px; padding: 4px; float: right;">
            <asp:ListItem Value="">-- Select --</asp:ListItem>
            <asp:ListItem Value="1">Active</asp:ListItem>
            <asp:ListItem Value="0">InActive</asp:ListItem>
        </asp:DropDownList>   
            PageSize :&nbsp&nbsp
        <asp:DropDownList ID="ddlPageSize" runat="server" Style="width: 80px; margin-right: 15px; padding: 4px; float: right;" AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged" Width="80">
       <%--   <asp:ListItem Text="10" Value="10" />--%>
          <asp:ListItem Text="20" Value="20" />
          <asp:ListItem Text="50" Value="50" />
            <asp:ListItem Text="100" Value="100" />
       </asp:DropDownList>
    </div>
    <div class="box" style="width: 92%; margin-left: 6%; margin-top: 5%; margin-bottom: 5%">

        <asp:GridView ID="GridView1" Style="width: 95%; margin-left: 2%;" AutoGenerateColumns="False" DataKeyNames="VendorId" 
            runat="server" OnRowCommand="GridView1_RowCommand" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="GridView1_PageIndexChanging" CellPadding="4"
            GridLines="None">
            <PagerStyle HorizontalAlign="Right" Width="100%" CssClass="box yagya" />
            <Columns>
                <asp:TemplateField HeaderText="S.No." ItemStyle-Width="1">
                    <ItemTemplate>
                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 +"."%>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="VendorId" HeaderText="VendorId" ItemStyle-Width="8%"  Visible="false"/>
                <asp:TemplateField HeaderText="Vendor Name">
                    <ItemTemplate>
                        <%# Eval("VendorName")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="VendorType" HeaderText="Vendor Type" />  
                <asp:BoundField DataField="CompanyName" HeaderText="Company Name" />  
                <asp:BoundField DataField="Mobile" HeaderText="Phone Number" /> 
                <asp:BoundField DataField="EmailID" HeaderText="Email ID" />              
                
                <asp:TemplateField HeaderText="Active">
                    <ItemTemplate>
                        <img src="dist/img/<%# Eval("Status") %>.png" style="width: 12px; height: 12px;" title='<%# Eval("Status")==DBNull.Value?" ":Convert.ToBoolean(Eval("Status"))==true?"Active":"InActive" %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                           <asp:Label ID="lbl" runat="server" Visible="false" Text=' <%# Eval("VendorId") %>'></asp:Label>
                        <a href='VendorAdd.aspx?VendorId=<%# Eval("VendorId") %>'>
                            <img src="images/edit.ico" style="height: 20px; margin-right: 20px; width: 20px;" title="Edit" />
                        </a>
                        <asp:LinkButton ID="R1" runat="server" CommandArgument='<%# Eval("VendorId") %>' OnClientClick="return Delete($(this).attr('name'));" name='<%# (Convert.ToInt32(Eval("dependancy"))==1?"true":"false") %>' CommandName="Deletes"><img src="images/Delete_icon.png" style="height: 20px;width: 20px;" /> </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
               </ContentTemplate>
           <Triggers>
          <%--  <asp:AsyncPostBackTrigger controlid="btnSave" eventname="Click" />
                <asp:AsyncPostBackTrigger controlid="btnCancel" eventname="Click" />
               <asp:AsyncPostBackTrigger controlid="btnAdd" eventname="Click" />--%>
            <%--   <asp:AsyncPostBackTrigger controlid="btnEdit" eventname="Click" />--%>
        </Triggers>
      </asp:UpdatePanel>
 
    <script>
        function Delete(flag)
        {

            if (flag=="true")
            {
                alert("Can't delete it?")
                return false;
            }
            else
            {
                return confirm('Are you sure to remove this vendor?');
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

