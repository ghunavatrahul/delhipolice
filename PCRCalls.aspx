<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="PCRCalls.aspx.cs" Inherits="PCRCalls" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">Head Wise Calls</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="pnlAdd" runat="server" Visible="false">

                <div id="mydiv" style="width: 80%; margin-left: 7.5%; margin-top: 5%; background: #ffffff;" class="box box-default">


                    <div class="box-body" style="display: block;">
                        <div class="row">
                            <%--<div class="col-md-6" style="margin-left: 27%;">--%>
                            <div class="col-md-12">
                                <div class="col-md-4">
                                <div class="form-group">
                                    <label id="lblId" runat="server" visible="false"></label>
                                    <label>Head Name</label>
                                    <asp:DropDownList ID="ddlHeadName" runat="server" OnSelectedIndexChanged="ddlHeadName_OnSelectedIndexChanged" AutoPostBack="true" class="form-control"></asp:DropDownList>
                                </div>
                                </div>
                                <div class="col-md-4">
                                <div class="form-group">
                                    <label>Hotspot Name</label>
                                    <asp:TextBox ID="txtHotSpotName" class="form-control" runat="server"  Style="margin-left: 0px;" placeholder="Hotspot Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ErrorMessage="*Hotspot name Please" SetFocusOnError="true"
                                Display="Dynamic" ControlToValidate="txtHotSpotName" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="Red" ControlToValidate="txtHotSpotName" SetFocusOnError="true"
                                Display="Dynamic" ValidationExpression="[a-zA-Z0-9 ./]*$" ErrorMessage="* Alpha numeric value with ./" />
                                </div>
                                </div>
                                <div class="col-md-4">
                                <div class="form-group">
                                    <label>Target for Calls during Week</label>
                                    <asp:TextBox ID="txtWeeklyTarget" class="form-control" runat="server"  Style="margin-left: 0px;" ReadOnly="true"></asp:TextBox>
                                </div>
                                </div>
                            </div>
                                            <div class="col-md-12">
                    &nbsp;&nbsp;&nbsp;&nbsp;<label>No. of Calls</label>
                    <div class="form-group">
                        <div class="col-md-4">
                            <label>Received in week</label>
                            <asp:TextBox ID="txtCallsRecivedInWeek" class="form-control" runat="server" Style="margin-left: 0px;" placeholder="No of Calls Recived in Week"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ErrorMessage="*Calls Count Please" SetFocusOnError="true"
                                Display="Dynamic" ControlToValidate="txtCallsRecivedInWeek" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ForeColor="Red" ControlToValidate="txtCallsRecivedInWeek" SetFocusOnError="true"
                                Display="Dynamic" ValidationExpression="[0-9]*$" ErrorMessage="* Only Numeric value!" />
                        </div>
                        <div class="col-md-4">
                            <label>Received in upto Date-2021</label>
                            <asp:TextBox ID="txtCallsRecivedThisYear" class="form-control" runat="server" placeholder="Calls Recived This year" Style="margin-left: 0px;"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ForeColor="Red" ErrorMessage="* Calls Count Please.." SetFocusOnError="true"
                                Display="Dynamic" ControlToValidate="txtCallsRecivedThisYear" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ForeColor="Red" ControlToValidate="txtCallsRecivedThisYear" SetFocusOnError="true"
                                Display="Dynamic" ValidationExpression="[0-9]*$" ErrorMessage="* Only Numeric value!" />
                        </div>
                        <div class="col-md-4">
                            <label>Received in upto Date-2020</label>
                            <asp:TextBox ID="txtCallsRecivedPreviousYear" class="form-control" runat="server" placeholder="Calls Recived Previous Year" Style="margin-left: 0px;"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ForeColor="Red" ErrorMessage="* Calls Count please.." SetFocusOnError="true"
                                Display="Dynamic" ControlToValidate="txtCallsRecivedPreviousYear" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ForeColor="Red" ControlToValidate="txtCallsRecivedPreviousYear" SetFocusOnError="true"
                                Display="Dynamic" ValidationExpression="[0-9]*$" ErrorMessage="* Only Valid characters!" />
                        </div>
                        
                    </div>
                </div>
                <label>&nbsp;</label>
                <div class="col-md-12">
                   <div class="form-group">
                        <div class="col-md-4">
                            <label>Time slot identified</label>
                            <asp:TextBox ID="txtTimeSlotIdentified" class="form-control" runat="server" Style="margin-left: 0px;" placeholder="Time slot identified"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ErrorMessage="*Time slot Please" SetFocusOnError="true"
                                Display="Dynamic" ControlToValidate="txtTimeSlotIdentified" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ForeColor="Red" ControlToValidate="txtTimeSlotIdentified" SetFocusOnError="true"
                                Display="Dynamic" ValidationExpression="[a-zA-Z0-9 &]*$" ErrorMessage="* Alpha Numeric value with symbols -,&" />
                        </div>
                        <div class="col-md-4">
                            <label>Strategy</label>
                            <asp:TextBox ID="txtStrategy" class="form-control" runat="server" placeholder="Strategy " Style="margin-left: 0px;"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red" ErrorMessage="* Strategy Please.." SetFocusOnError="true"
                                Display="Dynamic" ControlToValidate="txtStrategy" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ForeColor="Red" ControlToValidate="txtStrategy" SetFocusOnError="true"
                                Display="Dynamic" ValidationExpression="[a-zA-Z0-9 /&]*$" ErrorMessage="* Alpha Numeric value with symbols /&" />
                        </div>
                        <div class="col-md-4">
                            <label>Outcome</label>
                            <asp:TextBox ID="txtOutCome" class="form-control" runat="server" placeholder="Outcome" Style="margin-left: 0px;"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ForeColor="Red" ErrorMessage="* Outcome please.." SetFocusOnError="true"
                                Display="Dynamic" ControlToValidate="txtOutCome" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ForeColor="Red" ControlToValidate="txtOutCome" SetFocusOnError="true"
                                Display="Dynamic" ValidationExpression="[a-zA-Z0-9 %]*$" ErrorMessage="* Alpha Numeric value with symbols %" />
                        </div>
                        
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
                    <asp:GridView ID="gvListing" Style="width: 92%; margin-left: 0%;" AutoGenerateColumns="False" DataKeyNames="callId"
                        runat="server"  OnPageIndexChanging="gvListing_PageIndexChanging" AllowSorting="True" CellPadding="4" GridLines="None" ShowFooter="False" AllowPaging="True">
                        <PagerStyle HorizontalAlign="Right" Width="92%" CssClass="box yagya" />
                        <Columns>
                            <asp:TemplateField HeaderText="S.No." ItemStyle-Width="1">
                                <ItemTemplate>
                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 +"."%>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="callId" HeaderText="callId" ItemStyle-Width="8%" Visible="false" />
                            <asp:BoundField DataField="headId" HeaderText="headId" ItemStyle-Width="8%" Visible="false" />
                            <asp:BoundField DataField="headName" HeaderText="Head/Section" />
                            <asp:BoundField DataField="hotspot_name" HeaderText="Hotspot Name" />
                            <asp:BoundField DataField="weekly_target" HeaderText="TARGET for Calls during Week" />
                            <asp:BoundField DataField="calls_recived_in_week" HeaderText="No. of call received this week" />
                            <asp:BoundField DataField="calls_recived_this_year" HeaderText="No. of call received in upto Date - 2021" />
                            <asp:BoundField DataField="calls_recived_last_year" HeaderText="No. of call received in upto Date - 2020" />
                            <asp:BoundField DataField="time_slot_identified" HeaderText="Time slot identified" />
                            <asp:BoundField DataField="strategy" HeaderText="Strategy" />
                            <asp:BoundField DataField="outcome" HeaderText="Outcome" />
                            <asp:TemplateField HeaderText="Action" ItemStyle-Width="10%">
                                <ItemTemplate>
                                    <a href='PCRCallsEdit.aspx?CallId=<%# Eval("callId") %>'>
                                        <img src="images/edit.ico" style="height: 20px; margin-right: 20px; width: 20px;" title="Edit" />
                                    </a>
                                </ItemTemplate>
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

