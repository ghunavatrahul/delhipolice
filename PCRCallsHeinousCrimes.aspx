<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="PCRCallsHeinousCrimes.aspx.cs" Inherits="PCRCallsHeinousCrimes" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">PCR Calls -- Details of Heinous (except robbery)</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="pnlAdd" runat="server" Visible="false">

                <div id="mydiv" style="width: 80%; margin-left: 7.5%; margin-top: 5%; background: #ffffff;" class="box box-default">


                    <div class="box-body" style="display: block;">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label id="lblId" runat="server" visible="false"></label>
                                        <label>Head Name</label>
                                        <asp:DropDownList ID="ddlHeadName" runat="server" class="form-control"></asp:DropDownList>
                                        <asp:HiddenField ID="hdfCallId" runat="server" />
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label>Beat No</label>
                                        <asp:TextBox ID="txtBeatNo" class="form-control" runat="server" Style="margin-left: 0px;" placeholder="Beat No."></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red" ErrorMessage="*Beat No. Please" SetFocusOnError="true"
                                            Display="Dynamic" ControlToValidate="txtBeatNo" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ForeColor="Red" ControlToValidate="txtBeatNo" SetFocusOnError="true"
                                            Display="Dynamic" ValidationExpression="[0-9]*$" ErrorMessage="*Numeric only" />
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>DD Number</label>
                                        <asp:TextBox ID="txtDDNumber" class="form-control" runat="server" Style="margin-left: 0px;" placeholder="DD Number"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ErrorMessage="*DD Number Please" SetFocusOnError="true"
                                            Display="Dynamic" ControlToValidate="txtDDNumber" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="Red" ControlToValidate="txtDDNumber" SetFocusOnError="true"
                                            Display="Dynamic" ValidationExpression="[0-9 /]*$" ErrorMessage="*Numeric only with /" />
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>DD Time</label>
                                        <asp:TextBox ID="txtDDTime" class="form-control" runat="server" Style="margin-left: 0px;" placeholder="DD Date"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ForeColor="Red" ErrorMessage="*DD Date Please.." SetFocusOnError="true"
                                            Display="Dynamic" ControlToValidate="txtDDTime" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ForeColor="Red" ControlToValidate="txtDDTime" SetFocusOnError="true"
                                            Display="Dynamic" ValidationExpression="[0-9 /]*$" ErrorMessage="*Date in dd/mm/yyyy Format only" />
                                    </div>
                                </div>
                            </div>


                            <div class="col-md-12">
                                <div class="form-group">
                                    <div class="col-md-4">
                                        <label>Place of Occurance</label>
                                        <asp:TextBox ID="txtPlaceOccurance" class="form-control" runat="server" Style="margin-left: 0px;" placeholder="Place of Occurance"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ErrorMessage="*Place of Occurance please..!" SetFocusOnError="true"
                                            Display="Dynamic" ControlToValidate="txtPlaceOccurance" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ForeColor="Red" ControlToValidate="txtPlaceOccurance" SetFocusOnError="true"
                                            Display="Dynamic" ValidationExpression="[a-zA-Z.,& ]*$" ErrorMessage="* Charecters only with .,&!" />
                                    </div>
                                    <div class="col-md-4">
                                        <label>Name of IO</label>
                                        <asp:TextBox ID="txtNameIO" class="form-control" runat="server" placeholder="Name of IO" Style="margin-left: 0px;"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ForeColor="Red" ErrorMessage="* Name of IO Please.." SetFocusOnError="true"
                                            Display="Dynamic" ControlToValidate="txtNameIO" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ForeColor="Red" ControlToValidate="txtNameIO" SetFocusOnError="true"
                                            Display="Dynamic" ValidationExpression="[a-zA-Z]*$" ErrorMessage="* Charecters only!" />
                                    </div>
                                    <div class="col-md-4">
                                        <label>Cell No of IO</label>
                                        <asp:TextBox ID="txtCellNoIO" class="form-control" runat="server" placeholder="Cell Number IO" Style="margin-left: 0px;"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ForeColor="Red" ErrorMessage="* Cell Number of Please.." SetFocusOnError="true"
                                            Display="Dynamic" ControlToValidate="txtCellNoIO" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ForeColor="Red" ControlToValidate="txtCellNoIO" SetFocusOnError="true"
                                            Display="Dynamic" ValidationExpression="[0-9]*$" ErrorMessage="* Numeric only!" />
                                    </div>

                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="form-group">
                                    <div class="col-md-12">
                                        <label>Call Brif Facts</label>
                                        <asp:TextBox ID="txtCallBrifFacts" class="form-control" runat="server" Style="margin-left: 0px;" placeholder="Call Brif Fact" TextMode="MultiLine"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ErrorMessage="*Call Brif Fact Please.." SetFocusOnError="true"
                                            Display="Dynamic" ControlToValidate="txtCallBrifFacts" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ForeColor="Red" ControlToValidate="txtCallBrifFacts" SetFocusOnError="true"
                                            Display="Dynamic" ValidationExpression="[a-zA-Z0-9 .,&/@!-_']*$" ErrorMessage="*Alpha Numeric with allowed Charecters .,&/@!-_' only!" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="form-group">
                                    <div class="col-md-4">
                                        <label>Action Taken</label>
                                        <asp:TextBox ID="txtActionTaken" class="form-control" runat="server" Style="margin-left: 0px;" placeholder="Action Taken"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ForeColor="Red" ErrorMessage="*Action Taken please..!" SetFocusOnError="true"
                                            Display="Dynamic" ControlToValidate="txtActionTaken" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ForeColor="Red" ControlToValidate="txtActionTaken" SetFocusOnError="true"
                                            Display="Dynamic" ValidationExpression="[a-zA-Z0-9 .,& ]*$" ErrorMessage="* Charecters only with .,&!" />
                                    </div>
                                    <div class="col-md-4">
                                        <label>Remarks</label>
                                        <asp:TextBox ID="txtRemarks" class="form-control" runat="server" placeholder="Remarks" Style="margin-left: 0px;"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ForeColor="Red" ErrorMessage="* Remarks Please.." SetFocusOnError="true"
                                            Display="Dynamic" ControlToValidate="txtRemarks" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ForeColor="Red" ControlToValidate="txtRemarks" SetFocusOnError="true"
                                            Display="Dynamic" ValidationExpression="[a-zA-Z0-9 -/@& ]*$" ErrorMessage="* Alpha Numeric with allowed Charecters -/@& ]*$ only!" />
                                    </div>
                                    <div class="col-md-4">
                                        <label>Status</label>
                                        <asp:DropDownList ID="ddlStatus" class="form-control" runat="server" Style="width: 100px; margin-left: 1px; padding: 3px;" Width="80">
                                            <asp:ListItem Text="Yes" Value="1" />
                                            <asp:ListItem Text="No" Value="0" />
                                        </asp:DropDownList>
                                    </div>

                                </div>
                            </div>
                        </div>

                    <div class="box-footer" style="display: block;">
                        <asp:Button ID="btnCancel" runat="server" type="submit" class="btn btn-info pull-right" Text="Cancel" OnClick="btnCancel_Click" ValidationGroup="none" />
                        <asp:Button ID="btnSave" runat="server" type="submit" class="btn btn-info pull-right" Text="Save" OnClick="btnSave_Click" ValidationGroup='valGroup1' Style="margin-right: 15px;" />
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
                <asp:Button ID="btnAdd" class="btn btn-info pull-right" runat="server" Text="Add New Record" Style="margin-right: 40px;" OnClick="btnAdd_Click" /><br />
                <div style="margin-left: 7.5%">
                    <b>PageSize :</b>
                    <asp:DropDownList ID="ddlPageSize" runat="server" Style="width: 100px; margin-left: 15px; padding: 3px;" AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged" Width="80">
                        <asp:ListItem Text="10" Value="10" />
                        <asp:ListItem Text="20" Value="20" />
                        <asp:ListItem Text="30" Value="30" />
                        <asp:ListItem Text="50" Value="50" />
                        <asp:ListItem Text="100" Value="100" />
                    </asp:DropDownList><br />

                </div>
                <div id="mydiv1" style="width: 100%; margin-left: 7.5%; margin-top: 2%;" class="box box-default">
                    <asp:GridView ID="gvListing" Style="width: 92%; margin-left: 0%;" AutoGenerateColumns="False" DataKeyNames="callId" OnRowCommand="gvListing_RowCommand"
                        runat="server" OnPageIndexChanging="gvListing_PageIndexChanging" AllowSorting="True" CellPadding="4" GridLines="None" ShowFooter="False" AllowPaging="True">
                        <PagerStyle HorizontalAlign="Right" Width="92%" CssClass="box yagya" />
                        <Columns>
                            <asp:TemplateField HeaderText="S.No." ItemStyle-Width="1">
                                <ItemTemplate>
                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 +"."%>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="callId" HeaderText="callId" ItemStyle-Width="8%" Visible="false" />
                            <asp:BoundField DataField="headId" HeaderText="headId" ItemStyle-Width="8%" Visible="false" />
                            <asp:BoundField DataField="headName" HeaderText="Head Name" />
                            <asp:BoundField DataField="Beat_no" HeaderText="Beat Number" />
                            <asp:BoundField DataField="ddNoTime" HeaderText="DD No. & Time" />
                            <asp:BoundField DataField="place_Occurance" HeaderText="Place of Occurrence" />
                            <asp:BoundField DataField="nameMobileIo" HeaderText="Name of IO & Mobile No." />
                            <asp:BoundField DataField="action_taken" HeaderText="Action Taken" />
                            <asp:BoundField DataField="remarks" HeaderText="Remarks" />
                            <asp:TemplateField HeaderText="Status" ItemStyle-Width="8%">
                                <ItemTemplate>
                                    <img src="dist/img/<%# Eval("status") %>.png" style="width: 12px; height: 12px;" title='<%# Eval("status")==DBNull.Value?" ":Convert.ToString(Eval("status"))=="1"?"Active":"InActive" %>' />
                                </ItemTemplate>
                                <ItemStyle Width="8%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action" ItemStyle-Width="10%">
                                <ItemTemplate>
                                    <asp:LinkButton ToolTip="Edit" ID="btnEdit" runat="server" CommandArgument='<%# Eval("callId") %>' CommandName="Edits" Text="Edit">&nbsp;&nbsp;&nbsp;&nbsp;  <img src="images/edit.ico" style="height: 20px; margin-right: 20px; width: 20px;"/> &nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton>
                                    <asp:Label ID="lblNID" runat="server" Text='<%#Eval("callId")%>' Visible="false"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="15%" />
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

