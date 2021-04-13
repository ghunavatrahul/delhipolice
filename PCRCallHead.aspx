<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="PCRCallHead.aspx.cs" Inherits="PCRCallHead" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">Manage Head</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="pnlAdd" runat="server" Visible="false">

                <div id="mydiv" style="width: 80%; margin-left: 7.5%; margin-top: 5%; background: #ffffff;" class="box box-default">
                    

                    <div class="box-body" style="display: block;">
                        <div class="row">
                            <%--<div class="col-md-6" style="margin-left: 27%;">--%>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label id="lblId" runat="server" visible="false"></label>
                                    <label>Head Name</label>
                                    <asp:TextBox ID="txtHeadName" class="form-control" runat="server" placeholder="Enter Head Name ..." Style="margin-left: 0px;" OnTextChanged="txtHeadName_TextChanged"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ErrorMessage="* Please Enter Head Name!" SetFocusOnError="true"
                                        Display="Dynamic" ControlToValidate="txtHeadName" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ForeColor="Red" ControlToValidate="txtHeadName" SetFocusOnError="true"
                                        Display="Dynamic" ValidationExpression="[a-zA-Z /.-]*$" ErrorMessage="* Only Valid characters!" ValidationGroup='valGroup1' />
                                </div>
                            </div>
                        </div>

                        <div class="box-footer" style="display: block;">
                            <asp:Label ID="lblHeadId" runat="server" Text="" Visible="false"></asp:Label>
                            <asp:Button ID="btnCancel" runat="server" type="submit" class="btn btn-info pull-right" Text="Cancel" OnClick="btnCancel_Click" />
                            <asp:Button ID="btnSave" runat="server" type="submit" class="btn btn-info pull-right" Text="Add Head" OnClick="btnSave_Click" ValidationGroup='valGroup1' Style="margin-right: 15px;" />
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
                <asp:Button ID="btnAdd" class="btn btn-info pull-right" runat="server" Text="Add Head" Style="margin-right: 140px;" OnClick="btnAdd_Click" /><br />
                <div style="margin-left: 7.5%">
                    <b>PageSize :</b>
                    <asp:DropDownList ID="ddlPageSize" runat="server" Style="width: 100px; margin-left: 15px; padding: 3px;" AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged" Width="80">
                        <asp:ListItem Text="20" Value="20" />
                        <asp:ListItem Text="30" Value="30" />
                        <asp:ListItem Text="50" Value="50" />
                        <asp:ListItem Text="100" Value="100" />
                    </asp:DropDownList><br />

                </div>
                <div id="mydiv1" style="width: 100%; margin-left: 7.5%; margin-top: 2%;" class="box box-default">
                    <asp:GridView ID="gvListing" runat="server" AutoGenerateColumns="false" Width="80%" HeaderStyle-BackColor="#3c8dbc"
                        BackColor="#ffffff" HeaderStyle-Font-Size="0.4cm" HeaderStyle-ForeColor="White" HeaderStyle-Height="30px" CellPadding="20"
                        AllowPaging="True" OnPageIndexChanging="gvListing_PageIndexChanging" AlternatingRowStyle-BackColor="#FAF2DE" PageSize="20">
                        <PagerStyle HorizontalAlign="Right" Width="90%" CssClass="box yagya" Wrap="False" />

                        <AlternatingRowStyle BackColor="#FAF2DE" />

                        <Columns>
                            <asp:TemplateField HeaderText="S.No" ItemStyle-Width="8%">
                                <ItemTemplate>
                                    <%#(Container.DataItemIndex+1)%>.
                                </ItemTemplate>
                                <ItemStyle Width="8%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Head Name">
                                <ItemTemplate>
                                    <%# Eval("headName") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Record Count">
                                <ItemTemplate>
                                    <%# Eval("record_count") %>
                                </ItemTemplate>
                                <ItemStyle Width="8%" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                </div>
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlPageSize" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

