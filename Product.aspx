<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="ItemsAdd" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">Manage Products </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server" />
       <asp:UpdatePanel runat="server" id="UpdatePanel" updatemode="Conditional">
          <ContentTemplate>
    <script>
        function OnSearch() {
            var vendor = document.getElementById('<%= txtVendorname.ClientID %>').value;
            var title = document.getElementById('<%= txtTitlenm.ClientID %>').value;            
            if (title == "" && vendor== "" ) {
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
    <asp:Panel ID="pnlAdd" runat="server" Visible="false">
        <div id="mydiv" style="width: 80%; margin-left: 10%; margin-top: 5%; background: #ffffff;" class="box box-default">
            <style>
                .ajax__calendar {
                }
            </style>
           <div class="box-body" style="display: block;">
                <div class="row">
                   
                    <div class="col-md-6">
                        <div class="form-group">
                            <label id="lblId" runat="server" visible="false"></label>
                            <label>Title</label>
                            <asp:TextBox ID="txtTitle" class="form-control" runat="server" placeholder="Enter Title ..." Style="margin-left: 0px;"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ErrorMessage="* Please Enter Task!" SetFocusOnError="true"
                                Display="Dynamic" ControlToValidate="txtTitle" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ForeColor="Red" ControlToValidate="txtTitle" SetFocusOnError="true"
                                Display="Dynamic" ValidationExpression="[a-zA-Z ]*$" ErrorMessage="* Only Valid characters!"  ValidationGroup='valGroup1'/>
                        </div>
                        <div class="form-group">
                            <label>Description </label>
                            <asp:TextBox ID="txtDescription" class="form-control" runat="server" placeholder="Enter Description ..." TextMode="MultiLine" Style="margin-left: 0px; height: 90px;"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ErrorMessage="* Please Enter Description!" SetFocusOnError="true"
                                Display="Dynamic" ControlToValidate="txtDescription" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ForeColor="Red" ControlToValidate="txtDescription" SetFocusOnError="true"
                                Display="Dynamic" ValidationExpression="[a-zA-Z ]*$" ErrorMessage="* Only Valid characters!"  ValidationGroup='valGroup1'/>
                        </div>
                        
                        <div class="form-group" >
                            <label>Quantity </label>
                            <asp:TextBox ID="txtquantity" runat="server"  onkeypress='return event.charCode >= 48 && event.charCode <= 57'  class="form-control" placeholder="Type here Product Quantity" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Enter your Product Quantity" 
                                ControlToValidate="txtquantity" SetFocusOnError="true" ValidationGroup="valGroup1" ForeColor="Red"></asp:RequiredFieldValidator>                           
                        </div>                      
                      
                    </div>
                    <div class="col-md-6">
                             <div class="form-group">
                            <label>Vendor Name </label>
                            <asp:DropDownList ID="ddlVendorName" class="form-control" runat="server">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ErrorMessage="* Please Select Vendor Name!" SetFocusOnError="true"
                                Display="Dynamic" ControlToValidate="ddlVendorName" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                        </div>
                     <%--   <div class="form-group" >
                            <label>Employee Name </label>
                            <asp:DropDownList ID="ddlEmployeeId" class="form-control" runat="server">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red" ErrorMessage="* Please Select Status!" SetFocusOnError="true"
                                Display="Dynamic" ControlToValidate="ddlEmployeeId" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label>Customer Name </label>
                            <asp:DropDownList ID="ddlCustomerName" class="form-control" runat="server">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ForeColor="Red" ErrorMessage="* Please Select CustomerName!" SetFocusOnError="true"
                                Display="Dynamic" ControlToValidate="ddlCustomerName" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                        </div>--%>

                        <div class="form-group">
                            <label>Category </label>
                            <asp:DropDownList ID="ddlCategory" class="form-control" runat="server">
                               
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ForeColor="Red" ErrorMessage="* Please Select Category!" SetFocusOnError="true"
                                Display="Dynamic" ControlToValidate="ddlCategory" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                        </div>                      
                         <div class="form-group"  style="margin-top: 0px;margin-bottom: -11px;">
                            <label>Price</label>
                            <asp:TextBox onkeypress='return event.charCode >= 48 && event.charCode <= 57' ID="txtprice" class="form-control" runat="server" placeholder="Enter Price ..."></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ForeColor="Red" ErrorMessage="* Please Enter Task!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="txtprice" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ForeColor="Red" ControlToValidate="txtprice" SetFocusOnError="true" 
                    Display="Dynamic" ValidationExpression="[a-zA-Z ]*$" ErrorMessage="* Only Valid characters!" />   --%>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter your product price" ControlToValidate="txtprice" SetFocusOnError="true" ValidationGroup="valGroup1" ForeColor="Red"></asp:RequiredFieldValidator>
                             </div>
                          <div class="form-group" style="display:none;" >
                            <div class="form-group">
                                <label>Image</label>
                                <asp:FileUpload ID="FLupload" runat="server" />
                                <asp:Label ID="lblbackImge" runat="server" Text="" />
                            </div>
                        </div>

                        <div class="form-group" runat="server" visible="false"  style="margin-top: -18px;">
                            <label>Discount</label>
                            <asp:TextBox onkeypress='return event.charCode >= 48 && event.charCode <= 57' ID="txtDiscount" class="form-control" runat="server" placeholder="Enter Discount ..." Style="margin-left: 0px;"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Enter your Product Discount" ControlToValidate="txtDiscount" SetFocusOnError="true" ValidationGroup="valGroup1" ForeColor="Red"></asp:RequiredFieldValidator>
                            <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ForeColor="Red" ErrorMessage="* Please Enter Discount!" SetFocusOnError="true" 
                                Display="Dynamic" ControlToValidate="txtDiscount" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ForeColor="Red" ControlToValidate="txtDiscount" SetFocusOnError="true" 
                                Display="Dynamic" ValidationExpression="[a-zA-Z ]*$" ErrorMessage="* Only Valid characters!" />  --%>
                        </div>
                         
                    </div>
                </div>

                <div class="box-footer" style="display: block;">
                    <asp:Label ID="lblCatId" runat="server" Text="" Visible="false"></asp:Label>
                    <asp:Button id="btnCancel" runat="server"  class="btn btn-info pull-right" Text="Cancel" OnClick="btnCancel_Click" />
                    <asp:Button  id="btnSave" runat="server" Text="Save" class="btn btn-info pull-right" OnClick="btnSave_Click" validationgroup='valGroup1'/>
                  <%--  <button id="btnCancel" runat="server" type="submit" class="btn btn-info pull-right" onserverclick="btnCancel_Click">Cancel</button>--%>
                 <%--   <button id="btnSave" runat="server" type="submit" class="btn btn-info pull-right" onserverclick="btnSave_Click" validationgroup='valGroup1' style="margin-right: 15px;">Save</button>--%>
                </div>
            </div>
        </div>

    </asp:Panel>
    <asp:Panel ID="pnlGrid" runat="server" Visible="false">
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
           <asp:Button ID="btnAdd" class="btn btn-info pull-right" runat="server" Text="Add Product" Style="margin-right: 10%;" OnClick="btnAdd_Click" />
        <asp:Button ID="btnImportCSVClient" class="btn btn-info pull-right" runat="server" Text="Import CSV" Style="margin-right: 25px;" OnClientClick="return  CSV();" />
         <asp:LinkButton ID="btndemoproject" class="btn btn-info pull-right" runat="server" Text="Sample CSV" Style="margin-right: 25px;" href="FilesUpload/DownloadCSV/Product_CSV.csv" />
     
       <%-- <div>
               &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp PageSize:
        <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged" Width="80">
          <asp:ListItem Text="10" Value="10" />
          <asp:ListItem Text="25" Value="25" />
          <asp:ListItem Text="50" Value="50" />
            <asp:ListItem Text="100" Value="100" />
       </asp:DropDownList><br />
            
            </div>--%>
           
    <div id="csv" style="display: none; padding: 16px 16px 6px 16px; background: white; float: right; margin-top: -16px; border-radius: 10px; margin-right: 25px;">
        <asp:Button ID="btnImportCSV" class="btn btn-info pull-right" runat="server" Text="Upload CSV" OnClick="btnImportCSV_Click" OnClientClick="return validate();" />
        <asp:FileUpload ID="FileUpload1" runat="server" accept=".csv" Style="float: right;"  />
        <br />
    </div>
    <br />
    <br />
         <div style="margin-top: 20px; float: left; margin-left: 10%; margin-bottom: 10px;">
        <asp:Button ID="btnSearch" class="btn btn-info pull-right" runat="server" Text="Search" Style="margin-right: 15px;" OnClick="btnSearch_Click" OnClientClick="return OnSearch();" />        
        <asp:TextBox ID="txtVendorname" placeholder="Vendor Name ..." runat="server" Style="width: 315px; margin-right: 15px; padding: 4px; float: right;"></asp:TextBox>
        <asp:TextBox ID="txtTitlenm" placeholder="Title ..." runat="server" Style="width: 315px; margin-right: 15px; padding: 4px; float: right;"></asp:TextBox>
        PageSize : &nbsp&nbsp
        <asp:DropDownList ID="ddlPageSize" runat="server" Style="width: 80px; margin-right: 15px; padding: 4px; float: right;" AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged" Width="80">
         <%-- <asp:ListItem Text="10" Value="10" />--%>
          <asp:ListItem Text="20" Value="20" />
          <asp:ListItem Text="50" Value="50" />
            <asp:ListItem Text="100" Value="100" />
       </asp:DropDownList>
    </div>
             <div id="mydiv1" style="width: 100%; margin-left: 10%; margin-top: 5%; " class="box box-default">
                   <asp:GridView ID="gvListing" runat="server" BackColor="#ffffff" AutoGenerateColumns="false" Width="80%" OnRowCommand="gvListing_RowCommand" 
                       HeaderStyle-BackColor="#3c8dbc" HeaderStyle-Font-Size="0.4cm" HeaderStyle-ForeColor="White" HeaderStyle-Height="30px" CellPadding="20" 
                       AlternatingRowStyle-BackColor="#FAF2DE" AllowPaging="True" OnPageIndexChanging="gvListing_PageIndexChanging" PageSize="20">
                       <PagerStyle HorizontalAlign="Right" Width="100%" CssClass="box yagya" />
                <Columns>
                    <asp:TemplateField HeaderText="S.No" ItemStyle-Width="8%">
                        <ItemTemplate>
                            <%#(Container.DataItemIndex+1)%>.
                        </ItemTemplate>
                    </asp:TemplateField>

<%--                    <asp:TemplateField HeaderText=" Image">
                        <ItemTemplate>
                            <img src="../images/item/<%# Eval("image") %>" width="100" height="100" alt="" />
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Title">
                        <ItemTemplate>
                            <%# Eval("Title") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                  <%--  <asp:TemplateField HeaderText="Employee Name">
                        <ItemTemplate>
                            <%# Eval("Name") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Customer">
                        <ItemTemplate>
                            <%# Eval("custName") %>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Vendor Name">
                        <ItemTemplate>
                            <%# Eval("VendorName") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Price">
                        <ItemTemplate>
                            <%# Eval("price") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <%# Eval("Quantity") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                  <%--  <asp:TemplateField HeaderText="Discount">
                        <ItemTemplate>
                            <%# Eval("discount") %>
                        </ItemTemplate>
                    </asp:TemplateField>--%>

                    <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                        <ItemTemplate>
                             <asp:Label ID="lbl" runat="server" Visible="false" Text=' <%# Eval("ID") %>'></asp:Label>
                      <asp:LinkButton ToolTip="Edit" ID="btnEdit" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Edits" Text="Edit">  <img src="images/edit.ico" style="height: 20px; margin-right: 20px; width: 20px;"/> </asp:LinkButton>
                        <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%# Eval("ID") %>' OnClientClick="return Delete($(this).attr('name'));" name='<%# (Convert.ToInt32(Eval("dependancy"))==1?"true":"false") %>' CommandName="Deletes"><img src="images/Delete_icon.png" style="height: 20px;width: 20px;" /> </asp:LinkButton>


                           <%-- <asp:Button ID="btnDelete" runat="server" CommandArgument=' <%# Eval("ID") %>' CommandName="Deletes" Text="Delete" Style="    margin-left: 10px;" CssClass="btn btn-info pull-right" OnClientClick="return confirm('Are you sure to delete this product!');" />
                            <asp:Button ID="btnEdit" runat="server" CommandArgument=' <%# Eval("ID") %>' CommandName="Edits" Text="Edit" CssClass="btn btn-info pull-right" />--%>

                            <asp:Label ID="lblNID" runat="server" Text='<%#Eval("ID")%>' Visible="false"></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>
    </asp:Panel>
 </ContentTemplate>
           <Triggers>
            <asp:AsyncPostBackTrigger controlid="ddlPageSize" eventname="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger controlid="btnSearch" eventname="Click" />
               <asp:AsyncPostBackTrigger controlid="btnCancel" eventname="Click" />
               <asp:AsyncPostBackTrigger controlid="btnSave" eventname="Click" />
        </Triggers>
      </asp:UpdatePanel>
     <script>
         function Delete(flag) {

             if (flag == "true") {
                 alert("Can't delete it?")
                 return false;
             }
             else {
                 return confirm('Are you sure to remove this product?');
             }
         }
    </script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

