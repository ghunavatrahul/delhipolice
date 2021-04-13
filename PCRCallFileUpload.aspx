<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="PCRCallFileUpload.aspx.cs" Inherits="PCRCallFileUpload" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">Manage Head</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.10.0.min.js" type="text/javascript"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/jquery-ui.min.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/themes/blitzer/jquery-ui.css"
        rel="Stylesheet" type="text/css" />
  

            <asp:Panel ID="pnlGrid" runat="server" Visible="true">
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

                    
                </style>
                <div id="mydiv" style="width: 80%; margin-left: 7.5%; margin-top: 5%; background: #ffffff;" class="box box-default">
                    <div class="box-body" style="display: block;">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Calendar ID="datepicker" runat="server" Visible="false" OnSelectionChanged="datepicker_SelectionChanged"></asp:Calendar>
                                        <asp:TextBox ID="txtdtp" runat="server"></asp:TextBox>
                                        <asp:LinkButton ID="lnkpickdate" runat="server" OnClick="lnkpickdate_Click" class="btn btn-info pull-right">GetDate&nbsp;&nbsp;&nbsp;</asp:LinkButton>
                                        <br />
                                        <asp:FileUpload ID="fileUpload" runat="server" class="btn btn-info pull-left"/>
                                        
                                    </div>

                                </div>
                                <div class="col-md-8">
                                    <br />
                                    <asp:Button ID="btnAdd" class="btn btn-info pull-right" runat="server" Text="Upload File" Style="margin-right: 140px;" OnClick="btnAdd_Click" /><br />
                                </div>
                            </div>
                        </div>
                    </div>

                </div>    
                
            </asp:Panel>
        
    
</asp:Content>



