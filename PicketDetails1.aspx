<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="PicketDetails1.aspx.cs" Inherits="PicketDetails1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">Add Edit Pickets</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.10.0.min.js" type="text/javascript"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/jquery-ui.min.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/themes/blitzer/jquery-ui.css"
        rel="Stylesheet" type="text/css" />


    <div id="mydiv" style="width: 80%; margin-left: 10%; margin-top: 5%; background: #ffffff;" class="box box-default">
        <div class="box-body" style="display: block;">
            <div class="row">
                <div class="col-md-12">
                    <div class="col-md-4">

                        <div class="form-group">
                            <div class="form-group">
                            <label>Location of Integrated Pickets</label>
                            <asp:TextBox ID="txtLocation" class="form-control" runat="server" placeholder="Enter Location" Style="margin-left: 0px;" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ErrorMessage="* Please Enter Location" SetFocusOnError="true"
                                Display="Dynamic" ControlToValidate="txtLocation" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ForeColor="Red" ControlToValidate="txtLocation" SetFocusOnError="true"
                                Display="Dynamic" ValidationExpression="[a-zA-Z0-9 /.()]*$" ErrorMessage="* Only Valid characters!" />

                        </div>
                            
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <asp:DropDownList ID="ddlPicketType" runat="server"></asp:DropDownList>
                            <label id="lblId" runat="server" visible="false"></label>
                            <label>Picket Type</label>
                            <asp:TextBox ID="txtPicketType" class="form-control" runat="server" Style="margin-left: 0px;" ReadOnly="true"></asp:TextBox>
                            <asp:HiddenField ID="hfPicketId" runat="server" />

                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label>Timing</label>
                            <asp:TextBox ID="txtTiming" class="form-control" runat="server" placeholder="Enter Timing" Style="margin-left: 0px;" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ForeColor="Red" ErrorMessage="* Please Enter Timing" SetFocusOnError="true"
                                Display="Dynamic" ControlToValidate="txtTiming" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="Red" ControlToValidate="txtTiming" SetFocusOnError="true"
                                Display="Dynamic" ValidationExpression="[a-zA-Z0-9 /.()]*$" ErrorMessage="* Only Valid characters!" />

                        </div>
                    </div>
                </div>
                <div class="col-md-12">
                    &nbsp;&nbsp;&nbsp;&nbsp;<label>No. of vehicle checked using Vehiscan App</label>
                    <div class="form-group">
                        <div class="col-md-3">
                            <label>Daily Target</label>
                            <asp:TextBox ID="txtVehiscanAppDailyTarget" class="form-control" runat="server" Style="margin-left: 0px;" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <label>2-Wheelers</label>
                            <asp:TextBox ID="txtVehiscanApp2Wheelers" class="form-control" runat="server" placeholder="2 Wheelers" Style="margin-left: 0px;"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ForeColor="Red" ErrorMessage="* 2-Wheelers Count please.." SetFocusOnError="true"
                                Display="Dynamic" ControlToValidate="txtVehiscanApp2Wheelers" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ForeColor="Red" ControlToValidate="txtVehiscanApp2Wheelers" SetFocusOnError="true"
                                Display="Dynamic" ValidationExpression="[0-9]*$" ErrorMessage="* Only Valid characters!" />
                        </div>
                        <div class="col-md-3">
                            <label>4-Wheelers</label>
                            <asp:TextBox ID="txtVehiscanApp4Wheelers" class="form-control" runat="server" placeholder="4 Wheelers" Style="margin-left: 0px;"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ForeColor="Red" ErrorMessage="* 4-Wheelers Count please.." SetFocusOnError="true"
                                Display="Dynamic" ControlToValidate="txtVehiscanApp4Wheelers" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ForeColor="Red" ControlToValidate="txtVehiscanApp4Wheelers" SetFocusOnError="true"
                                Display="Dynamic" ValidationExpression="[0-9]*$" ErrorMessage="* Only Valid characters!" />
                        </div>
                        <div class="col-md-3">
                            <label>Bus/TSR</label>
                            <asp:TextBox ID="txtVehiscanAppBusTSR" class="form-control" runat="server" placeholder="BUS/TSR" Style="margin-left: 0px;"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ForeColor="Red" ErrorMessage="* Bus/TSR Count please.." SetFocusOnError="true"
                                Display="Dynamic" ControlToValidate="txtVehiscanAppBusTSR" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server" ForeColor="Red" ControlToValidate="txtVehiscanAppBusTSR" SetFocusOnError="true"
                                Display="Dynamic" ValidationExpression="[0-9]*$" ErrorMessage="* Only Valid characters!" />
                        </div>
                    </div>
                </div>
                <label>&nbsp;</label>
                <div class="col-md-12">
                    <div class="col-md-6">
                        <label>No. of vehicle impounded u/s 66 DP Act</label>
                        <div class="form-group">
                            <div class="col-md-6">
                                <label>Daily Target</label>
                                <asp:TextBox ID="txt66DPActDailyTarget" class="form-control" runat="server"  Style="margin-left: 0px;" ReadOnly="true"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label>Action</label>
                                <asp:TextBox ID="txt66DPActAction" class="form-control" runat="server" placeholder="Action" Style="margin-left: 0px;"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ForeColor="Red" ErrorMessage="* Action Count please.." SetFocusOnError="true"
                                    Display="Dynamic" ControlToValidate="txt66DPActAction" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server" ForeColor="Red" ControlToValidate="txt66DPActAction" SetFocusOnError="true"
                                    Display="Dynamic" ValidationExpression="[0-9]*$" ErrorMessage="* Only Valid characters!" />
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <label>No. of Stranger Roll issued</label>
                        <div class="form-group">
                            <div class="col-md-6">
                                <label>Daily Target</label>
                                <asp:TextBox ID="txtStrangerRollIssuedDailyTarget" class="form-control" runat="server"  Style="margin-left: 0px;" ReadOnly="true"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label>Action</label>
                                <asp:TextBox ID="txtStrangerRollIssuedAction" class="form-control" runat="server" placeholder="Action" Style="margin-left: 0px;"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ForeColor="Red" ErrorMessage="* Action please.." SetFocusOnError="true"
                                    Display="Dynamic" ControlToValidate="txtStrangerRollIssuedAction" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server" ForeColor="Red" ControlToValidate="txtStrangerRollIssuedAction" SetFocusOnError="true"
                                    Display="Dynamic" ValidationExpression="[0-9]*$" ErrorMessage="* Only Valid characters!" />
                            </div>
                        </div>
                    </div>
                </div>
                <label>&nbsp;</label>
                <div class="col-md-12">
                    <div class="col-md-6">
                        <label>Action under 65 DP Act</label>
                        <div class="form-group">
                            <div class="col-md-6">
                                <label>Daily Target</label>
                                <asp:TextBox ID="txt65DPActDailyTarget" class="form-control" runat="server" Style="margin-left: 0px;" ReadOnly="true"></asp:TextBox>
                            </div>

                            <div class="col-md-6">
                                <label>Action</label>
                                <asp:TextBox ID="txt65DPActAction" class="form-control" runat="server" placeholder="Action" Style="margin-left: 0px;"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ForeColor="Red" ErrorMessage="* Action please.." SetFocusOnError="true"
                                    Display="Dynamic" ControlToValidate="txt65DPActAction" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server" ForeColor="Red" ControlToValidate="txt65DPActAction" SetFocusOnError="true"
                                    Display="Dynamic" ValidationExpression="[0-9]*$" ErrorMessage="* Only Valid characters!" />
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <label>&nbsp;</label>
                        <div class="form-group">
                            <label>Details of detection, if any</label>
                            <asp:TextBox ID="txtDetailDetection" class="form-control" runat="server" placeholder="Details of detection" Style="margin-left: 0px;" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ForeColor="Red" ErrorMessage="* Details of detection please.." SetFocusOnError="true"
                                Display="Dynamic" ControlToValidate="txtDetailDetection" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator17" runat="server" ForeColor="Red" ControlToValidate="txtDetailDetection" SetFocusOnError="true"
                                Display="Dynamic" ValidationExpression="[a-zA-Z0-9 /.()]*$" ErrorMessage="* Only Valid characters!" />
                        </div>
                    </div>
                </div>

            </div>
        </div>
        <div class="box-footer" style="display: block;">
            <button id="btnCancel" runat="server" type="submit" class="btn btn-info pull-right" onserverclick="btnCancel_Click" causesvalidation="false">Cancel</button>
            <asp:Button ID="btnSubmit" runat="server" Text="Save" class="btn btn-info pull-right" OnClick="btnSubmit_Click" ValidationGroup='valGroup1' Style="margin-right: 15px;" />
            <%--   <button id="btnSubmit" runat="server"  type="submit" class="btn btn-info pull-right" onserverclick="btnSubmit_Click" ValidationGroup='valGroup1' style="margin-right: 15px;">Submit</button>--%>
        </div>
    </div>






</asp:Content>


