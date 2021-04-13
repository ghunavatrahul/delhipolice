<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="PCRCallsEdit.aspx.cs" Inherits="PCRCallsEdit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">Edit PCR Calls</asp:Content>
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
                            <label>Head/Section</label>
                            <asp:TextBox ID="txtHeadName" class="form-control" runat="server" Style="margin-left: 0px;" ReadOnly="true"></asp:TextBox>
                            <asp:HiddenField ID="hfCallId" runat="server" />
                            <asp:HiddenField ID="hfHeadId" runat="server" />
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label>Hotspot Name</label>
                            <asp:TextBox ID="txtHotSpotName" class="form-control" runat="server"  Style="margin-left: 0px;" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label>Target for Calls During Week</label>
                            <asp:TextBox ID="txtWeeklyTarget" class="form-control" runat="server"  Style="margin-left: 0px;" ReadOnly="true" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="col-md-12">
                    &nbsp;&nbsp;&nbsp;&nbsp;<label>No. of Calls</label>
                    <div class="form-group">
                        <div class="col-md-4">
                            <label>Received in week</label>
                            <asp:TextBox ID="txtCallsRecivedInWeek" class="form-control" runat="server" Style="margin-left: 0px;" placeholder="No of Calls Recived in Week"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ErrorMessage="*Calls Count Please" SetFocusOnError="true"
                                Display="Dynamic" ControlToValidate="txtCallsRecivedInWeek" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="Red" ControlToValidate="txtCallsRecivedInWeek" SetFocusOnError="true"
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
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ErrorMessage="*Time slot Please" SetFocusOnError="true"
                                Display="Dynamic" ControlToValidate="txtTimeSlotIdentified" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ForeColor="Red" ControlToValidate="txtTimeSlotIdentified" SetFocusOnError="true"
                                Display="Dynamic" ValidationExpression="[AMPamp0-9-,&]*$" ErrorMessage="* Alpha Numeric value with symbols -,&" />
                        </div>
                        <div class="col-md-4">
                            <label>Strategy</label>
                            <asp:TextBox ID="txtStrategy" class="form-control" runat="server" placeholder="Strategy " Style="margin-left: 0px;"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ErrorMessage="* Strategy Please.." SetFocusOnError="true"
                                Display="Dynamic" ControlToValidate="txtStrategy" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ForeColor="Red" ControlToValidate="txtStrategy" SetFocusOnError="true"
                                Display="Dynamic" ValidationExpression="[a-zA-Z0-9 /&]*$" ErrorMessage="* Alpha Numeric value with symbols /&" />
                        </div>
                        <div class="col-md-4">
                            <label>Outcome</label>
                            <asp:TextBox ID="txtOutCome" class="form-control" runat="server" placeholder="Outcome" Style="margin-left: 0px;"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red" ErrorMessage="* Outcome please.." SetFocusOnError="true"
                                Display="Dynamic" ControlToValidate="txtOutCome" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ForeColor="Red" ControlToValidate="txtOutCome" SetFocusOnError="true"
                                Display="Dynamic" ValidationExpression="[a-zA-Z0-9 %]*$" ErrorMessage="* Alpha Numeric value with symbols %" />
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


