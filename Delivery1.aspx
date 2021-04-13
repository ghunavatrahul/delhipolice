<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Delivery1.aspx.cs" Inherits="Delivery1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">Delivery Details</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel runat="server" id="UpdatePanel" updatemode="Conditional">
          <ContentTemplate>
     <script>
         function OnSearch() {
             var cust = document.getElementById('<%= txtCustomerName.ClientID %>').value;
            var email = document.getElementById('<%= txtProduct.ClientID %>').value;
            var status = document.getElementById('<%= ddlPriority.ClientID %>').value;
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
        .testtd{width:10%!important}
    </style>
    <asp:Button ID="btnAdd" class="btn btn-info pull-right" runat="server" Text="Create Delivery" Style="margin-right:5%;" OnClick="btnAdd_Click" />
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

    <div style="margin-top: 20px; float: left; margin-left: 13.2%; margin-bottom: 10px;">
        <asp:Button ID="btnSearch" class="btn btn-info pull-right" runat="server" Text="Search" Style="margin-right=10px;    margin-left=45px" OnClick="btnSearch_Click" OnClientClick="return OnSearch();" />
        <asp:DropDownList ID="ddlPriority" runat="server" Style="width: 167px; margin-right: 13px; padding: 4px; float: right;">
            <asp:ListItem Value="">-- Select Priority --</asp:ListItem>
            <asp:ListItem Value="1">Low</asp:ListItem>
            <asp:ListItem Value="2">Medium</asp:ListItem>
            <asp:ListItem Value="3">High</asp:ListItem>
        </asp:DropDownList> 
         <asp:TextBox ID="txtProduct" placeholder="Product Name ..." runat="server" Style="width: 240px; margin-right: 13px; padding: 4px; float: right;"></asp:TextBox>       
        <asp:TextBox ID="txtCustomerName" placeholder="Customer Name ..." runat="server" Style="width: 240px; margin-right: 13px; padding: 4px; float: right;"></asp:TextBox>       
       <b>PageSize :</b>
        <asp:DropDownList ID="ddlPageSize" runat="server" style="width:100px;padding:4px;margin-right:13px" AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged" Width="80">
          <asp:ListItem Text="10" Value="10" />
          <asp:ListItem Text="25" Value="25" />
          <asp:ListItem Text="50" Value="50" />
          <asp:ListItem Text="100" Value="100" />
       </asp:DropDownList>

    </div>
    <div class="box" style="width: 92%; margin-left: 6%; margin-top: 5%; margin-bottom: 5%">

        <asp:GridView ID="GridView1" Style="width: 95%; margin-left: 2%;" AutoGenerateColumns="False" DataKeyNames="DeliveryID" 
            runat="server" OnRowCommand="GridView1_RowCommand" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="GridView1_PageIndexChanging" CellPadding="4"
            GridLines="None">
            <PagerStyle HorizontalAlign="Right" Width="100%" CssClass="box yagya" />
            <Columns>
                <asp:TemplateField HeaderText="S.No." ItemStyle-Width="1">
                    <ItemTemplate>
                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 +"."%>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="DeliveryID" HeaderText="DeliveryID" ItemStyle-Width="8%"  Visible="false"/>
                
                <asp:BoundField DataField="Custname" HeaderText="Customer" />  
                <asp:BoundField DataField="Title" HeaderText="Product" />  
                <asp:BoundField DataField="empname" HeaderText="Assigned Employee" /> 
                   <asp:TemplateField HeaderText="Priority">
                    <ItemTemplate>
                        <asp:Label ID="lblpriority" runat="server" Text='<%# Bind("Priority") %>' Font-Bold="true" ForeColor='<%# Convert.ToString(Eval("Priority"))== ""?System.Drawing.Color.White: Convert.ToString(Eval("Priority")) == "High" ? System.Drawing.Color.Red: Convert.ToString(Eval("Priority")) == "Medium" ? System.Drawing.Color.Green: System.Drawing.Color.Orange%>' />                                    
                    </ItemTemplate>
               </asp:TemplateField>    
                <asp:BoundField DataField="Estimateddate" HeaderText="Estimated Date" />        
               <asp:TemplateField HeaderText="Delivery Address">
                    <ItemTemplate>
                        <%# Eval("Addr1")%>  <%# Eval("State")%> <%# Eval("City")%> <%# Eval("Zipcode")%>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Action" ItemStyle-Width="10%" >
                    <ItemTemplate>
                        <a href='Delivery.aspx?DeliveryID=<%# Eval("DeliveryID") %>'>
                            <img src="images/edit.ico" style="height: 20px; margin-right: 20px; width: 20px;" title="Edit" />
                        </a>
                        <asp:LinkButton ToolTip="Delete" ID="R1" runat="server" CommandArgument='<%# Eval("DeliveryID") %>' OnClientClick="return confirm('Are you sure to remove this Delivery?');" CommandName="Deletes"><img src="images/Delete_icon.png" style="height: 20px;width: 20px;" /> </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
                </ContentTemplate>
           <Triggers>
           </Triggers>
          </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

