<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="PCRCallsAccedentPronArea.aspx.cs" Inherits="PCRCallsAccedentPronArea" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">PCR Calls -- Accident Prone Area</asp:Content>
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
                                    <label>Hotspot Name</label>
                                    <asp:TextBox ID="txtHotSpotName" class="form-control" runat="server"  Style="margin-left: 0px;" placeholder="Hotspot Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ForeColor="Red" ErrorMessage="*Hotspot name Please" SetFocusOnError="true"
                                Display="Dynamic" ControlToValidate="txtHotSpotName" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ForeColor="Red" ControlToValidate="txtHotSpotName" SetFocusOnError="true"
                                Display="Dynamic" ValidationExpression="[a-zA-Z0-9 ./]*$" ErrorMessage="* Alpha numeric value with ./" />
                                </div>
                                </div>
                                <div class="col-md-4">
                                <div class="form-group">
                                    <label>Intimation Sent to Traffic</label>
                                    <asp:DropDownList ID="ddlIntimationToTraffic" runat="server" class="form-control" >
                                        <asp:ListItem Text="Yes" Value="Yes" Selected="True" />
                                        <asp:ListItem Text="No" Value="No"  />
                                    </asp:DropDownList>
                                </div>
                                </div>
                                <div class="col-md-4">
                                <div class="form-group">
                                    <label>CCTV Installed</label>
                                    <asp:TextBox ID="txtCctvInstalled" class="form-control" runat="server"  Style="margin-left: 0px;" placeholder="CCTV installed"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ErrorMessage="*CCTV installed Please" SetFocusOnError="true"
                                Display="Dynamic" ControlToValidate="txtCctvInstalled" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="Red" ControlToValidate="txtCctvInstalled" SetFocusOnError="true"
                                Display="Dynamic" ValidationExpression="[a-zA-Z ]*$" ErrorMessage="* Charecters only" />
                                </div>
                                </div>
                            </div>
                                            <div class="col-md-12">
                    <div class="form-group">
                        <div class="col-md-4">
                            <label>Repairing of Pot Holes</label>
                            <asp:TextBox ID="txtPitHoles" class="form-control" runat="server" Style="margin-left: 0px;" placeholder="Repairing of pit holes"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ErrorMessage="*Pit holes status please..!" SetFocusOnError="true"
                                Display="Dynamic" ControlToValidate="txtPitHoles" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ForeColor="Red" ControlToValidate="txtPitHoles" SetFocusOnError="true"
                                Display="Dynamic" ValidationExpression="[a-zA-Z. ]*$" ErrorMessage="* Charecters only!" />
                        </div>
                        <div class="col-md-4">
                            <label>Reason of Accident</label>
                            <asp:TextBox ID="txtReasonAccedent" class="form-control" runat="server" placeholder="Reason of Accident" Style="margin-left: 0px;"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ForeColor="Red" ErrorMessage="* Reason of Accident Please.." SetFocusOnError="true"
                                Display="Dynamic" ControlToValidate="txtReasonAccedent" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ForeColor="Red" ControlToValidate="txtReasonAccedent" SetFocusOnError="true"
                                Display="Dynamic" ValidationExpression="[a-zA-Z. ]*$" ErrorMessage="* Charecters only!" />
                        </div>
                        <div class="col-md-4">
                            <label>Target for Beat Staff</label>
                            <asp:TextBox ID="txtTargetBeatStaff" class="form-control" runat="server" placeholder="Target for Beat Staff" Style="margin-left: 0px;"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ForeColor="Red" ErrorMessage="* Target for Beat Staff Please.." SetFocusOnError="true"
                                Display="Dynamic" ControlToValidate="txtTargetBeatStaff" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ForeColor="Red" ControlToValidate="txtTargetBeatStaff" SetFocusOnError="true"
                                Display="Dynamic" ValidationExpression="[a-zA-Z. ]*$" ErrorMessage="* Charecters only!" />
                        </div>
                        
                    </div>
                </div>
                <label>&nbsp;</label>
                <div class="col-md-12">
                   <div class="form-group">
                        <div class="col-md-6">
                            <label>Target for ATO</label>
                            <asp:TextBox ID="txtTargetATO" class="form-control" runat="server" Style="margin-left: 0px;" placeholder="Target for ATO" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ErrorMessage="*Target for ATO Please.." SetFocusOnError="true"
                                Display="Dynamic" ControlToValidate="txtTargetATO" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ForeColor="Red" ControlToValidate="txtTargetATO" SetFocusOnError="true"
                                Display="Dynamic" ValidationExpression="[a-zA-Z .&]*$" ErrorMessage="* Charecters only!" />
                        </div>
                       <div class="col-md-6">&nbsp;</div>
                    </div>
                </div>
                        </div>

                        <div class="box-footer" style="display: block;">
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
                            <asp:BoundField DataField="hotspot_name" HeaderText="Hotspot of Accident" />
                            <asp:BoundField DataField="intimation_to_traffic" HeaderText="Intimation Sent to Traffic" />
                            <asp:BoundField DataField="cctv_installed" HeaderText="CCTV Installed" />
                            <asp:BoundField DataField="repair_potholes" HeaderText="Repairing of Pot Holes" />
                            <asp:BoundField DataField="reason_accedent" HeaderText="Reason of Accident" />
                            <asp:BoundField DataField="target_beat_officer" HeaderText="TARGET for Beat Staff" />
                            <asp:BoundField DataField="target_ato" HeaderText="TARGET for ATO" />
                            <asp:BoundField DataField="created_on" HeaderText="Date Created" />
                            <asp:BoundField DataField="updated_on" HeaderText="Date Updated" />
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

