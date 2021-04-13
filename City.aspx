<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="City.aspx.cs" Inherits="City" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server"><label style="margin-left:2%;"></label>&nbsp Manage City </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel runat="server" id="UpdatePanel" updatemode="Conditional">
          <ContentTemplate>
    <asp:Panel ID="pnlAdd" runat="server" Visible="false">

        <div id="mydiv" style="width: 80%; margin-left: 10%; margin-top: 5%;  background: #ffffff;" class="box box-default">
            

            <div class="box-body" style="display: block;">
                <div class="row">
                    <%--<div class="col-md-6" style="margin-left: 27%;">--%>
                    <div class="col-md-6">
                         <div class="form-group" >
                            <label>State </label>
                             <asp:DropDownList ID="ddlstate" class="form-control" runat="server">
                            </asp:DropDownList>    
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ErrorMessage="* Please Select State!" SetFocusOnError="true"
                             Display="Dynamic" ControlToValidate="ddlstate" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                             </div>
                        <div class="form-group">
                            <label>Status </label><br />
                            <asp:CheckBox ID="chkActive" runat="server" Checked="true" />
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>City Name </label>                            
                            <asp:TextBox ID="txtcityname" runat="server"  class="form-control" placeholder="Type here City Name" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="* Enter your City Name" Display="Dynamic"
                                ControlToValidate="txtcityname" SetFocusOnError="true" ValidationGroup="valGroup1" ForeColor="Red"></asp:RequiredFieldValidator>   
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ForeColor="Red" ControlToValidate="txtcityname" SetFocusOnError="true"
                                Display="Dynamic" ValidationExpression="[a-zA-Z ]*$" ErrorMessage="* Only Valid characters!" ValidationGroup="valGroup1" /> 
                        </div>
                    </div>

                </div>
            </div>

        <div class="box-footer" style="display: block;">
            <asp:Label ID="lblCatId" runat="server" Text="Cancel" Visible="false"></asp:Label>
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-info pull-right" OnClick="btnCancel_Click"/>
          <%--  <button id="btnCancel" runat="server" type="Save" class="btn btn-info pull-right" onserverclick="btnCancel_Click">Cancel</button>--%>
            <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="valGroup1" class="btn btn-info pull-right" OnClick="btnSave_Click"  style="margin-right: 15px;"/>
<%--            <button id="btnSave" runat="server" type="submit" ValidationGroup="valGroup1" class="btn btn-info pull-right" onserverclick="btnSave_Click"  style="margin-right: 15px;">Save</button>--%>
        </div>
        </div>

    </asp:Panel>

    <asp:Panel ID="pnlGrid" runat="server" Visible="false">

        <asp:Button ID="btnAdd" class="btn btn-info pull-right" runat="server" Text="Add City" Style="margin-right: 10%;" OnClick="btnAdd_Click" /><br />
        <div>
       <label style="margin-left:10%;" >PageSize :</label>&nbsp
        <asp:DropDownList ID="ddlPageSize" runat="server" Style="width: 100px; margin-left:2px;padding:3px;" AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged" Width="80">
          <asp:ListItem Text="10" Value="10" />
          <asp:ListItem Text="25" Value="25" />
          <asp:ListItem Text="50" Value="50" />
          <asp:ListItem Text="100" Value="100" />

       </asp:DropDownList><br />
            
            </div>
        <div id="mydiv1" style="width: 100%; margin-left: 10%; margin-top: 1%;" class="box box-default">
            <asp:GridView ID="gvListing" runat="server" AutoGenerateColumns="false" Width="80%"
                OnRowCommand="gvListing_RowCommand" HeaderStyle-BackColor="#3c8dbc" BackColor="#ffffff" HeaderStyle-Font-Size="0.4cm" HeaderStyle-ForeColor="White" HeaderStyle-Height="30px" CellPadding="20" AlternatingRowStyle-BackColor="#FAF2DE"  AllowPaging="True" OnPageIndexChanging="gvListing_PageIndexChanging">
                       <PagerStyle HorizontalAlign="Right" Width="100%" CssClass="box yagya" />
                <Columns>
                    <asp:TemplateField HeaderText="S.No" ItemStyle-Width="8%">
                        <ItemTemplate>
                            <%#(Container.DataItemIndex+1)%>.
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="State Name">
                        <ItemTemplate>
                            <%# Eval("statename") %>
                           
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="City Name">
                        <ItemTemplate>
                            <%# Eval("name") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status" ItemStyle-Width="8%">
                        <ItemTemplate>
                            <img src="dist/img/<%# Eval("Status") %>.png" style="width: 12px; height: 12px;" title='<%# Eval("Status")==DBNull.Value?" ":Convert.ToString(Eval("Status"))=="1"?"Active":"InActive" %>' />
                           <%-- <%# (Convert.ToString(Eval("Status"))=="1"?"Active":"InActive") %>--%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Action" ItemStyle-Width="10%">
                        <ItemTemplate>
                           <%-- <asp:Label ID="lbl" runat="server" Visible="false" Text=' <%# Eval("StateId") %>'></asp:Label>--%>
                      <%--  <a href='City.aspx?ID=<%# Eval("CityId") %>'> <img src="images/edit.ico" style="height: 20px; margin-right: 20px; width: 20px;" title="Edit" /></a>--%>
                        <asp:LinkButton ToolTip="Edit" ID="btnEdit" runat="server" CommandArgument='<%# Eval("CityId") %>' CommandName="Edits" Text="Edit">  <img src="images/edit.ico" style="height: 20px; margin-right: 20px; width: 20px;"/> </asp:LinkButton>
                        <asp:LinkButton ToolTip="Delete" ID="btnDelete" runat="server" CommandArgument='<%# Eval("CityId") %>' OnClientClick="return confirm('Are you sure to delete this City!');" CommandName="Deletes"><img src="images/Delete_icon.png" style="height:20px;width: 20px;" /> </asp:LinkButton>
                   
                           <%-- <asp:Button ID="btnDelete" runat="server" CommandArgument=' <%# Eval("CityId") %>' CommandName="Deletes" Text="Delete" Style="margin-left: 10px;" CssClass="btn btn-info pull-right" OnClientClick="return confirm('Are you sure to delete this City!');" />
                            <asp:Button ID="btnEdit" runat="server" CommandArgument=' <%# Eval("CityId") %>' CommandName="Edits" Text="Edit" CssClass="btn btn-info pull-right" />--%>
                            <asp:Label ID="lblNID" runat="server" Text='<%#Eval("CityId")%>' Visible="false"></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>
    </asp:Panel>
                </ContentTemplate>
           <Triggers>
            <asp:AsyncPostBackTrigger controlid="btnSave" eventname="Click" />
                <asp:AsyncPostBackTrigger controlid="btnCancel" eventname="Click" />
               <asp:AsyncPostBackTrigger controlid="btnAdd" eventname="Click" />
            <%--   <asp:AsyncPostBackTrigger controlid="btnEdit" eventname="Click" />--%>
        </Triggers>
      </asp:UpdatePanel>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

