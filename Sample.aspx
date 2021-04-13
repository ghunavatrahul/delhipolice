<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Sample.aspx.cs" Inherits="Sample" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">Sample
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <%--<asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"  >  
        </asp:ToolkitScriptManager>  
        <br />  
        <asp:TabContainer ID="TabContainer1" runat="server" style="margin-left: 117px;visibility: visible;" ActiveTabIndex="0" >  
            <asp:TabPanel runat="server" HeaderText="Staff Assigned the Delivery" ID="TabPanel1">              
                <ContentTemplate>  --%>
                 <%--    <style>
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
    </style>--%>
                    <%-- <script>
                         function OnSearch() {
                             var assignemp = document.getElementById('<%= txtAssignto.ClientID %>').value;
                              var product = document.getElementById('<%= txtProduct.ClientID %>').value;
                              if (assignemp == "" && product == "") {
                                  alert('Please fill any search fields!');
                                  return false;
                              }
                              return true;
                          }
                    </script>--%>
                  <%--  <div style=" float: left; margin-left: 8%; margin-bottom: 10px;" runat="server" >
                        <asp:Button ID="btnSearch" class="btn btn-info pull-right" runat="server" Text="Search" Style="margin-right: 15px;" OnClick="btnSearch_Click" OnClientClick="return OnSearch();" />
                        <asp:TextBox ID="txtAssignto" placeholder="Assigned Employee ..." runat="server" Style="width: 240px; margin-right: 15px; padding: 4px; float: right;" ReadOnly="false"></asp:TextBox>
                        <asp:TextBox ID="txtProduct" placeholder="Product Name ..." runat="server" Style="width: 240px; margin-right: 15px; padding: 4px; float: right;"></asp:TextBox>                            
                    </div>--%>
                      <%--  <asp:GridView ID="GridView1" Style="width: 95%; margin-left: 2%;" AutoGenerateColumns="False" DataKeyNames="DeliveryID" 
                    runat="server" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="GridView1_PageIndexChanging" CellPadding="4"
                    GridLines="None">
                    <PagerStyle HorizontalAlign="Right" Width="100%" CssClass="GridPager" />
                    <Columns>
                        <asp:TemplateField HeaderText="S.No." ItemStyle-Width="1">
                            <ItemTemplate>
                                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 +"."%>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="DeliveryID" HeaderText="DeliveryID" ItemStyle-Width="8%"  Visible="false"/>
                        <asp:BoundField DataField="Title" HeaderText="Products" />
                        <asp:TemplateField HeaderText="Assigned Employee">
                            <ItemTemplate>
                                <%# Eval("Assignto")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PickUp Address">
                            <ItemTemplate>
                                <%# Eval("PickupAddr")%> <%# Eval("PickState")%> <%# Eval("PickCity")%> <%# Eval("PickZipcode") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Delivery Address">
                            <ItemTemplate>
                                <%# Eval("Addr1")%> <%# Eval("Delvstate")%> <%# Eval("Delvcity")%> <%# Eval("Zipcode") %>
                            </ItemTemplate>
                        </asp:TemplateField>                    
                    </Columns>
                </asp:GridView>--%>
               <%-- </ContentTemplate>                 
            </asp:TabPanel>  
            <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="Delivery status ">  
            </asp:TabPanel>  
             <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="Warehouse Delivery Report">  
            </asp:TabPanel>  
             <asp:TabPanel ID="TabPanel4" runat="server" HeaderText="Product Delivery Report">  
            </asp:TabPanel>  
        </asp:TabContainer> --%>
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

                   <script>
                       function OnSearch() {
                           var assignemp = document.getElementById('<%= txtAssignto.ClientID %>').value;
                           var product = document.getElementById('<%= txtProduct.ClientID %>').value;
                           if (assignemp == "" && product == "") {
                               alert('Please fill any search fields!');
                               return false;
                           }
                           return true;
                       }
                    </script>

     <div style=" float: left; margin-left: 8%; margin-bottom: 10px;" runat="server" >
                    <asp:Button ID="btnSearch" class="btn btn-info pull-right" runat="server" Text="Search" Style="margin-right: 15px;" OnClick="btnSearch_Click" OnClientClick="return OnSearch();" />
                    <asp:TextBox ID="txtAssignto" placeholder="Assigned Employee ..." runat="server" Style="width: 240px; margin-right: 15px; padding: 4px; float: right;" ReadOnly="false"></asp:TextBox>
                    <asp:TextBox ID="txtProduct" placeholder="Product Name ..." runat="server" Style="width: 240px; margin-right: 15px; padding: 4px; float: right;"></asp:TextBox>                            
                </div>

      <div class="box" style="width: 92%; margin-left: 6%; margin-top: 5%; margin-bottom: 5%">
                <asp:GridView ID="GridView1" Style="width: 95%; margin-left: 2%;" AutoGenerateColumns="False" DataKeyNames="DeliveryID" 
                    runat="server" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="GridView1_PageIndexChanging" CellPadding="4"
                    GridLines="None">
                    <PagerStyle HorizontalAlign="Right" Width="100%" CssClass="GridPager" />
                    <Columns>
                        <asp:TemplateField HeaderText="S.No." ItemStyle-Width="1">
                            <ItemTemplate>
                                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 +"."%>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="DeliveryID" HeaderText="DeliveryID" ItemStyle-Width="8%"  Visible="false"/>
                        <asp:BoundField DataField="Title" HeaderText="Products" />
                        <asp:TemplateField HeaderText="Assigned Employee">
                            <ItemTemplate>
                                <%# Eval("Assignto")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PickUp Address">
                            <ItemTemplate>
                                <%# Eval("PickupAddr")%> <%# Eval("PickState")%> <%# Eval("PickCity")%> <%# Eval("PickZipcode") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Delivery Address">
                            <ItemTemplate>
                                <%# Eval("Addr1")%> <%# Eval("Delvstate")%> <%# Eval("Delvcity")%> <%# Eval("Zipcode") %>
                            </ItemTemplate>
                        </asp:TemplateField>                    
                    </Columns>
                </asp:GridView>
            </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

