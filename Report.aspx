<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Report.aspx.cs" Inherits="Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
    Report Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager2" runat="server" />
    <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional">
        <ContentTemplate>
            <script type="text/javascript" language="javascript">
                function Func(id1, id2) {
                    //alert("hello!")
                    document.getElementById('staff').setAttribute('class', '');
                    document.getElementById('StaffAssigned').setAttribute('class', 'tab-pane');
                    document.getElementById(id1).setAttribute('class', 'active');
                    document.getElementById(id2).setAttribute('class', 'tab-pane active');
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
            <section class="content" style="margin-left: 5%; width=98%">
                <div class="row">
                    <div class="col-xs-12">
                        <div class="nav-tabs-custom">
                            <ul class="nav nav-tabs">
                                <li class="active" id="staff"><a href="#StaffAssigned" data-toggle="tab" aria-expanded="true">Staff Assigned the Delivery</a></li>
                                <li class="" id="delivery"><a href="#DeliveryStatus" data-toggle="tab" aria-expanded="false">Delivery status </a></li>
                                <li class="" id="ware"><a href="#WarehouseDelivery" data-toggle="tab" aria-expanded="true">Warehouse Delivery Report </a></li>
                                <li class="" id="prod"><a href="#ProductDelivery" data-toggle="tab" aria-expanded="false">Product Delivery Report </a></li>
                            </ul>
                            <div class="tab-content">
                                <div class="tab-pane active" id="StaffAssigned">

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

                                    <%-- <table border="0" style="width: 95%; margin-left: 22px; margin-bottom: 30px; background-color: white;">--%>
                                    <div style="margin-top: 20px; float: left; margin-left: 23.5%; margin-bottom: 15px;">
                                        <asp:Button ID="btnSearch" class="btn btn-info pull-right" runat="server" Text="Search" Style="margin-right: 15px;" OnClick="btnSearch_Click" OnClientClick="return OnSearch();" />
                                        <asp:TextBox ID="txtAssignto" placeholder="Assigned Employee ..." runat="server" Style="width: 240px; margin-right: 15px; padding: 4px; float: right;" ReadOnly="false"></asp:TextBox>
                                        <asp:TextBox ID="txtProduct" placeholder="Product Name ..." runat="server" Style="width: 240px; margin-right: 15px; padding: 4px; float: right;"></asp:TextBox>
                                        PageSize :&nbsp&nbsp
                              <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged" Style="width: 80px; margin-right: 15px; padding: 4px; float: right;">
                                  <%--<asp:ListItem Text="5" Value="5" />
                                  <asp:ListItem Text="10" Value="10" />
                                  <asp:ListItem Text="25" Value="25" />
                                  <asp:ListItem Text="50" Value="50" />
                                  <asp:ListItem Text="100" Value="100" />--%>
                                  <asp:ListItem Text="20" Value="20" />
                                  <asp:ListItem Text="50" Value="50" />
                                  <asp:ListItem Text="100" Value="100" />
                              </asp:DropDownList>
                                    </div>
                                    <%-- <tr>

                          <td>Size 
                              <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged" Width="80">
                                  <asp:ListItem Text="5" Value="5" />
                                  <asp:ListItem Text="10" Value="10" />
                                  <asp:ListItem Text="25" Value="25" />
                                  <asp:ListItem Text="50" Value="50" />
                                  <asp:ListItem Text="100" Value="100" />
                              </asp:DropDownList>
                          </td>
                          <td>
                              <asp:TextBox ID="txtAssignto" placeholder="Assigned Employee ..." runat="server" Style="width: 240px; margin-right: 15px; padding: 4px; float: right;" ReadOnly="false"></asp:TextBox>
                          </td>
                          <td>
                              <asp:TextBox ID="txtProduct" placeholder="Product Name ..." runat="server" Style="width: 240px; margin-right: 15px; padding: 4px; float: right;"></asp:TextBox>
                          </td>
                          <td>
                              <asp:Button ID="btnSearch" class="btn btn-info pull-right" runat="server" Text="Search" Style="margin-right: 15px;" OnClick="btnSearch_Click" OnClientClick="return OnSearch();" />
                          </td>
                      </tr>--%>

                                    <%-- </table>--%>


                                    <%--   <div class="box" style="width: 92%; margin-left: 6%; margin-top: 5%; margin-bottom: 5%">--%>
                                    <asp:GridView ID="GridView1" Style="width: 95%; margin-left: 2%;" AutoGenerateColumns="False" DataKeyNames="DeliveryID"
                                        runat="server" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="GridView1_PageIndexChanging" CellPadding="4"
                                        GridLines="None" PageSize="20">
                                        <PagerStyle HorizontalAlign="Right" Width="100%" CssClass="box-footer" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No." ItemStyle-Width="5%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 +"."%>' runat="server" />
                                                </ItemTemplate>
                                                <ItemStyle Width="5%" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="DeliveryID" HeaderText="DeliveryID" ItemStyle-Width="8%" Visible="false">
                                                <ItemStyle Width="8%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Title" HeaderText="Products" />
                                            <asp:TemplateField HeaderText="Assigned Employee">
                                                <ItemTemplate>
                                                    <%# Eval("Assignto")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <%-- <asp:BoundField DataField="Title" HeaderText="Assign Date" />--%>
                                            <asp:TemplateField HeaderText="Assign Date">
                                                <ItemTemplate>
                                                    <%# Eval("Ordereddate")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Estimate Date">
                                                <ItemTemplate>
                                                    <%# Eval("Estimateddate")%>
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
                                            <asp:TemplateField HeaderText="Delivery Status">
                                                <ItemTemplate>
                                                    <%# Eval("DeliveryStatus")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>

                                    <%--  </div>--%>
                                </div>
                                <div class="tab-pane" id="DeliveryStatus">

                                    <script>
                                        function OnSearch1() {
                                            var txtdlvAsgemp = document.getElementById('<%= txtdlvAsgemp.ClientID %>').value;
                        var txtdlvProd = document.getElementById('<%= txtdlvProd.ClientID %>').value;
                                        var ddldlvstatus = document.getElementById('<%= ddldlvstatus.ClientID %>').value;
                                        if (txtdlvAsgemp == "" && txtdlvProd == "" && ddldlvstatus == "") {
                                            alert('Please fill any search fields!');
                                            return false;
                                        }
                                        return true;
                                        }
                                    </script>
                                    <div style="float: left; margin-left: 2%; margin-bottom: 10px;" runat="server">
                                        <asp:Button ID="btnSearch1" class="btn btn-info pull-right" runat="server" Text="Search" Style="margin-right: 15px;" OnClick="btnSearch1_Click" OnClientClick="return OnSearch1();" />
                                        <asp:DropDownList ID="ddldlvstatus" runat="server" Style="width: 167px; margin-right: 15px; padding: 4px; float: right;">
                                            <asp:ListItem Value="">-- Delivery Status --</asp:ListItem>
                                            <asp:ListItem Value="1">Opened</asp:ListItem>
                                            <asp:ListItem Value="2">Delivered</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txtdlvAsgemp" placeholder="Assigned Employee ..." runat="server" Style="width: 240px; margin-right: 15px; padding: 4px; float: right;" ReadOnly="false"></asp:TextBox>
                                        <asp:TextBox ID="txtdlvProd" placeholder="Product Name ..." runat="server" Style="width: 240px; margin-right: 15px; padding: 4px; float: right;"></asp:TextBox>
                                        PageSize : &nbsp&nbsp
                     <asp:DropDownList ID="ddldlvstatussize" runat="server" Style="width: 80px; margin-right: 15px; padding: 4px; float: right;" AutoPostBack="true" OnSelectedIndexChanged="ddldlvstatussize_SelectedIndexChanged" Width="80">
                         <%--<asp:ListItem Text="5" Value="5" />
                        <asp:ListItem Text="10" Value="10" />--%>
                         <asp:ListItem Text="20" Value="20" />
                         <asp:ListItem Text="50" Value="50" />
                         <asp:ListItem Text="100" Value="100" />
                     </asp:DropDownList>
                                    </div>
                                    <%--  <div class="box" style="width: 92%; margin-left: 6%; margin-top: 5%; margin-bottom: 5%">--%>
                                    <asp:GridView ID="gridDeliveryStatus" Style="width: 95%; margin-left: 2%;" AutoGenerateColumns="False" DataKeyNames="DeliveryID"
                                        runat="server" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="gridDeliveryStatus_PageIndexChanging" CellPadding="4"
                                        GridLines="None" PageSize="20">
                                        <PagerStyle HorizontalAlign="Right" Width="100%" CssClass="box yagya" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No." ItemStyle-Width="8%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 +"."%>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="DeliveryID" HeaderText="DeliveryID" ItemStyle-Width="8%" Visible="false" />
                                            <asp:BoundField DataField="Title" HeaderText="Products" />
                                            <asp:TemplateField HeaderText="Assign Employee">
                                                <ItemTemplate>
                                                    <%# Eval("Assignto")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Assign Date">
                                                <ItemTemplate>
                                                    <%# Eval("Ordereddate")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Estimate Date">
                                                <ItemTemplate>
                                                    <%# Eval("Estimateddate")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Estimateddate" HeaderText="Estimated/Delivered Date" />
                                            <asp:BoundField DataField="DeliveryStatus" HeaderText="Delivery Status" />

                                        </Columns>
                                    </asp:GridView>
                                    <%-- </div>--%>
                                    <%-- <div style=" margin-top: 15px;margin-left: 25px;">
                     <label>Size</label> 
                     <asp:DropDownList ID="ddldlvstatussize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddldlvstatussize_SelectedIndexChanged" Width="80">
                        <%--<asp:ListItem Text="5" Value="5" />
                        <asp:ListItem Text="10" Value="10" />
                        <asp:ListItem Text="25" Value="25" />
                        <asp:ListItem Text="50" Value="50" />
                        <asp:ListItem Text="100" Value="100" />
                     </asp:DropDownList><br />            
                  </div>--%>
                                </div>
                                <div class="tab-pane active" id="WarehouseDelivery">
                                </div>
                                <div class="tab-pane" id="ProductDelivery">
                                    <script>
                                        function OnSearch2() {
                                            var txtprdlvasnemp = document.getElementById('<%= txtprdlvasnemp.ClientID %>').value;
                           var txtprdlvProd = document.getElementById('<%= txtprdlvProd.ClientID %>').value;
                                        var ddlprdlvstatus = document.getElementById('<%= ddlprdlvstatus.ClientID %>').value;
                                        if (txtprdlvasnemp == "" && txtprdlvProd == "" && ddlprdlvstatus == "") {
                                            alert('Please fill any search fields!');
                                            return false;
                                        }
                                        return true;
                                        }
                                    </script>
                                    <div style="float: left; margin-left: 2%; margin-bottom: 10px;" runat="server">
                                        <asp:Button ID="btnSearch2" class="btn btn-info pull-right" runat="server" Text="Search" Style="margin-right: 15px;" OnClick="btnSearch2_Click" OnClientClick="return OnSearch2();" />
                                        <asp:DropDownList ID="ddlprdlvstatus" runat="server" Style="width: 167px; margin-right: 15px; padding: 4px; float: right;">
                                            <asp:ListItem Value="">-- Delivery Status --</asp:ListItem>
                                            <asp:ListItem Value="1">Opened</asp:ListItem>
                                            <asp:ListItem Value="2">Delivered</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txtprdlvasnemp" placeholder="Assigned Employee ..." runat="server" Style="width: 240px; margin-right: 15px; padding: 4px; float: right;" ReadOnly="false"></asp:TextBox>
                                        <asp:TextBox ID="txtprdlvProd" placeholder="Product Name ..." runat="server" Style="width: 240px; margin-right: 15px; padding: 4px; float: right;"></asp:TextBox>
                                        PageSize : &nbsp&nbsp
                     <asp:DropDownList ID="ddlproddlvsize" runat="server" AutoPostBack="true" Style="width: 80px; margin-right: 15px; padding: 4px; float: right;" OnSelectedIndexChanged="ddlproddlvsize_SelectedIndexChanged" Width="80">
                         <%--<asp:ListItem Text="5" Value="5" />
                        <asp:ListItem Text="10" Value="10" />--%>
                         <asp:ListItem Text="20" Value="20" />
                         <asp:ListItem Text="50" Value="50" />
                         <asp:ListItem Text="100" Value="100" />
                     </asp:DropDownList><br />
                                    </div>
                                    <asp:GridView ID="gridProductdelivery" Style="width: 95%; margin-left: 2%;" AutoGenerateColumns="False" DataKeyNames="DeliveryID"
                                        runat="server" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="gridProductdelivery_PageIndexChanging" CellPadding="4"
                                        GridLines="None" PageSize="20">
                                        <PagerStyle HorizontalAlign="Right" Width="100%" CssClass="GridPager" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No." ItemStyle-Width="8%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 +"."%>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="DeliveryID" HeaderText="DeliveryID" ItemStyle-Width="8%" Visible="false" />
                                            <asp:BoundField DataField="Title" HeaderText="Products" />
                                            <asp:TemplateField HeaderText="Assign To">
                                                <ItemTemplate>
                                                    <%# Eval("Assignto")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Assign Date" ItemStyle-Width="100px">
                                                <ItemTemplate>
                                                    <%# Eval("Ordereddate")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Estimate Date">
                                                <ItemTemplate>
                                                    <%# Eval("Estimateddate")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delivery Address">
                                                <ItemTemplate>
                                                    <%# Eval("Addr1")%> <%# Eval("Delvstate")%> <%# Eval("Delvcity")%> <%# Eval("Zipcode") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="DeliveryStatus" HeaderText="Delivery Status" />

                                        </Columns>
                                    </asp:GridView>
                                    <%--<div style=" margin-top: 15px;margin-left: 25px;">
                     <label>Size</label> 
                     <asp:DropDownList ID="ddlproddlvsize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlproddlvsize_SelectedIndexChanged" Width="80">
                        <asp:ListItem Text="5" Value="5" />
                        <asp:ListItem Text="10" Value="10" />
                        <asp:ListItem Text="25" Value="25" />
                        <asp:ListItem Text="50" Value="50" />
                        <asp:ListItem Text="100" Value="100" />
                     </asp:DropDownList><br />            
                  </div>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                </div>    
            </section>
        </ContentTemplate>
        <Triggers>
            <%--   <asp:AsyncPostBackTrigger ControlID="ddlPageSize" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" /> 
                <asp:AsyncPostBackTrigger ControlID="btnSearch1" EventName="Click" /> 
                <asp:AsyncPostBackTrigger ControlID="btnSearch2" EventName="Click" />           --%>
        </Triggers>
    </asp:UpdatePanel>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

