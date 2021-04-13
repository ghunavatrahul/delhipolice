<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Category.aspx.cs" Inherits="Category" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">Manage Category </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel runat="server" id="UpdatePanel" updatemode="Conditional">
          <ContentTemplate>
    <asp:Panel ID="pnlAdd" runat="server" Visible="false">

        <div id="mydiv" style="width: 80%; margin-left:7.5%; margin-top: 5%;  background: #ffffff;" class="box box-default">
            

            <div class="box-body" style="display: block;">
                <div class="row">
                    <%--<div class="col-md-6" style="margin-left: 27%;">--%>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label id="lblId" runat="server" visible="false"></label>
                            <label>Category Name</label>
                            <asp:TextBox ID="txtCategoryname" class="form-control" runat="server" placeholder="Enter Category Name ..." Style="margin-left: 0px;" OnTextChanged="txtCategoryname_TextChanged"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ErrorMessage="* Please Enter Category Name!" SetFocusOnError="true"
                                Display="Dynamic" ControlToValidate="txtCategoryname" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                          <%--  <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ForeColor="Red" ControlToValidate="txtCategoryname" SetFocusOnError="true"
                                Display="Dynamic" ValidationExpression="[a-zA-Z ]*$" ErrorMessage="* Only Valid characters!" ValidationGroup='valGroup1' />--%>
                        </div>

                        <div class="form-group">
                            <label>Status </label><br />
                            <asp:CheckBox ID="chkActive" runat="server" Checked="true" />
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>ParentCategory </label>
                            <asp:DropDownList ID="ddlParentcategory" class="form-control" runat="server">
                            </asp:DropDownList>
                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ErrorMessage="* Please Select!" SetFocusOnError="true"
                                Display="Dynamic" ControlToValidate="ddlParentcategory" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>--%>
                            </div>
                    </div>

                </div>
            </div>

        <div class="box-footer" style="display: block;">
            <asp:Label ID="lblCatId" runat="server" Text="" Visible="false"></asp:Label>
            <asp:Button  id="btnCancel" runat="server" type="submit" class="btn btn-info pull-right" Text="Cancel" OnClick="btnCancel_Click"/>
            <asp:Button  id="btnSave" runat="server" type="submit" class="btn btn-info pull-right" Text="Save" OnClick="btnSave_Click" validationgroup='valGroup1' style="margin-right: 15px;"/>
            <%--<button id="btnCancel" runat="server" type="submit" class="btn btn-info pull-right" onserverclick="btnCancel_Click">Cancel</button>
            <button id="btnSave" runat="server" type="submit" class="btn btn-info pull-right" onserverclick="btnSave_Click" validationgroup='valGroup1' style="margin-right: 15px;">Save</button>--%>

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
        <asp:Button ID="btnAdd" class="btn btn-info pull-right" runat="server" Text="Add Category" Style="margin-right: 140px;" OnClick="btnAdd_Click" /><br />
         <div style="margin-left:7.5%">
         <b> PageSize :</b>
        <asp:DropDownList ID="ddlPageSize" runat="server" Style="width: 100px; margin-left:15px;padding:3px;" AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged" Width="80">
          <asp:ListItem Text="20" Value="20" />
          <asp:ListItem Text="30" Value="30" />
          <asp:ListItem Text="50" Value="50" />
            <asp:ListItem Text="100" Value="100" />
       </asp:DropDownList><br />
            
            </div>
        <div id="mydiv1" style="width: 100%; margin-left: 7.5%; margin-top: 2%;" class="box box-default">
            <asp:GridView ID="gvListing" runat="server" AutoGenerateColumns="false" Width="80%" OnRowCommand="gvListing_RowCommand" HeaderStyle-BackColor="#3c8dbc" 
                BackColor="#ffffff" HeaderStyle-Font-Size="0.4cm" HeaderStyle-ForeColor="White" HeaderStyle-Height="30px" CellPadding="20" 
                AllowPaging="True" OnPageIndexChanging="gvListing_PageIndexChanging" AlternatingRowStyle-BackColor="#FAF2DE" PageSize="20">
                  <PagerStyle HorizontalAlign="Right" Width="90%"    CssClass="box yagya" Wrap="False" />
                
                <AlternatingRowStyle BackColor="#FAF2DE" />
                
                <Columns>
                    <asp:TemplateField HeaderText="S.No" ItemStyle-Width="8%">
                        <ItemTemplate>
                            <%#(Container.DataItemIndex+1)%>.
                        </ItemTemplate>
                        <ItemStyle Width="8%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Category Name">
                        <ItemTemplate>
                            <%# Eval("name") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="parentCategory" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblparentCategory" runat="server" Text='<%# Eval("parentCategory") %>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status" ItemStyle-Width="8%">
                        <ItemTemplate>
                            <img src="dist/img/<%# Eval("Status") %>.png" style="width: 12px; height: 12px;" title='<%# Eval("Status")==DBNull.Value?" ":Convert.ToString(Eval("Status"))=="1"?"Active":"InActive" %>' />
                            <%--<%# (Convert.ToString(Eval("Status"))=="1"?"Active":"InActive") %>--%>
                        </ItemTemplate>
                        <ItemStyle Width="8%" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Action" ItemStyle-Width="10%">
                        <ItemTemplate>
                             <asp:LinkButton ToolTip="Edit" ID="btnEdit" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Edits" Text="Edit">&nbsp;&nbsp;&nbsp;&nbsp;  <img src="images/edit.ico" style="height: 20px; margin-right: 20px; width: 20px;"/> &nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton>
                        <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%# Eval("ID") %>' OnClientClick="return Delete($(this).attr('name'));" name='<%# (Convert.ToInt32(Eval("parent"))==1?"true":"false") %>' CommandName="Deletes"><img src="images/Delete_icon.png" style="height: 20px;width: 20px;" /> </asp:LinkButton>

                           <%-- <asp:Button ID="btnDelete" runat="server" CommandArgument=' <%# Eval("ID") %>' CommandName="Deletes" Text="Delete" Style="margin-left: 10px;" CssClass="btn btn-info pull-right" OnClientClick="return confirm('Are you sure to delete this category!');" />
                            <asp:Button ID="btnEdit" runat="server" CommandArgument=' <%# Eval("ID") %>' CommandName="Edits" Text="Edit" CssClass="btn btn-info pull-right" />--%>

                            <asp:Label ID="lblNID" runat="server" Text='<%#Eval("ID")%>' Visible="false"></asp:Label>
                        </ItemTemplate>

                        <ItemStyle Width="15%" />

                    </asp:TemplateField>

                </Columns>
                <HeaderStyle BackColor="#3C8DBC" Font-Size="0.4cm" ForeColor="White" Height="30px" />
              
            </asp:GridView>
            
        </div>
    </asp:Panel>
               </ContentTemplate>
           <Triggers>
            <asp:AsyncPostBackTrigger controlid="ddlPageSize" eventname="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger controlid="btnCancel" eventname="Click" />
               <asp:AsyncPostBackTrigger controlid="btnSave" eventname="Click" />
            <%--   <asp:AsyncPostBackTrigger controlid="btnEdit" eventname="Click" />--%>
        </Triggers>
          </asp:UpdatePanel>
     <script>
         function Delete(flag) {

             if (flag == "true")
             {
                 return confirm('Are you sure to remove this category?');
             }
             else {
                 alert("Can't delete it?")
                 return false;
                
             }
         }
    </script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

