<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Pickets.aspx.cs" Inherits="Pickets" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="plugins/jvectormap/jquery-jvectormap-1.2.2.min.js"></script>
    <script src="plugins/jvectormap/jquery-jvectormap-world-mill-en.js"></script>
    <style>
        .box {
            position: relative;
            border-radius: 3px;
            background: #ffffff;
            margin-bottom: 20px;
            width: 100%;
            box-shadow: 0 1px 1px rgba(0, 0, 0, 0.1);
        }

        .boxpro {
            position: relative;
            border-radius: 3px;
            background: #ffffff;
            width: 100%;
            box-shadow: 0 1px 1px rgba(0, 0, 0, 0.1);
        }

        .box.box-info {
            border-top-color: #00c0ef;
        }

        th {
            padding: 5px;
            background: #117A65;
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
            background: #D5F5E3;
            cursor: pointer;
        }

        tr:nth-child(even) {
            background-color: #ABEBC6;
        }

       /* tr:last-child {
            background: #f4f4f4 !important;
            border: solid 1px silver;
        } */

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
        .testtd{width:10%!important}
    </style>
    <section class="content" style="width: 94%;">


        <div class="row">
            <div class="col-md-12">
                
                <div class="box box-info">
                    <h3 class="box-title" style="margin-left: 5px;">Pickets</h3>
                    <div class="box-header with-border">
                        <h3 class="box-title">Pickets</h3>
                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                <i class="fa fa-minus"></i>
                            </button>
                            <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                        </div>
                    </div>
                    
                    <!-- New style of grid view is added here with edit functionality -->
                     <div class="box" style="width: 100%; margin-left: 1%; margin-top: 0%; margin-right: 1%; margin-bottom: 5%">
                        <div class="btn btn-box-tool text-bold"><h4>Enhancement of Police Visibility</h4></div>
        <asp:Button ID="btnAdd" class="btn btn-info pull-right" runat="server" Text="Add Picket" Style="margin-right:5%; background-color:#117A65;" OnClick="btnAdd_Click" />    
        <asp:GridView ID="GridView3" Style="width: 100%; margin-left: 0%;" AutoGenerateColumns="False" DataKeyNames="picket_id" 
            runat="server" OnRowCommand="GridView3_RowCommand" AllowSorting="True" onsorting="GridView3_Sorting" CellPadding="4" GridLines="None" ShowFooter="False" OnDataBound = "OnDataBound" >
            <PagerStyle HorizontalAlign="Right" Width="100%" CssClass="box yagya" />
            <Columns>
                <asp:TemplateField HeaderText="S.No." ItemStyle-Width="1">
                    <ItemTemplate>
                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 +"."%>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="picket_id" HeaderText="picket_id" ItemStyle-Width="8%"  Visible="false"/>
                <asp:BoundField DataField="picket_type" HeaderText="Picket Type" HeaderStyle-BackColor="#ffcc99" ItemStyle-BackColor="#ffcc99" ItemStyle-Font-Bold="true" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="#ff0000" />  
                 
                 
                
                <asp:TemplateField HeaderText="Location of Integrated Pickets" SortExpression="location">  
                                <EditItemTemplate>  
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("location") %>'></asp:TextBox>  
                                </EditItemTemplate>  
                                <ItemTemplate>  
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("location") %>'></asp:Label>  
                                </ItemTemplate>  
                </asp:TemplateField>
                <asp:BoundField DataField="timing" HeaderText="Timing" />  
                <asp:BoundField DataField="vehiscanAppDailyTarge" HeaderText="Daily Target" ItemStyle-ForeColor="#ff0000" HeaderStyle-BackColor="#cc0000"/>  
                <asp:BoundField DataField="vehiscanApp2Wheelers" HeaderText="2-Wheelers" />  
                <asp:BoundField DataField="vehiscanApp4Wheelers" HeaderText="4-Wheelers" />  
                <asp:BoundField DataField="vehiscanAppBusTSR" HeaderText="Bus/TSR" />  

                <asp:BoundField DataField="dailyTarget66DPAct" HeaderText="Daily Target" ItemStyle-ForeColor="#ff0000" HeaderStyle-BackColor="#cc0000" />  
                <asp:BoundField DataField="action66DPAct" HeaderText="Action" />  
                <asp:BoundField DataField="strangerRollIssuedDailyTarget" HeaderText="Daily Target" ItemStyle-ForeColor="#ff0000" HeaderStyle-BackColor="#cc0000" />  
                <asp:BoundField DataField="strangerRollIssuedAction" HeaderText="Action" />  
                <asp:BoundField DataField="dailyTarget65DPAct" HeaderText="Daily Target" ItemStyle-ForeColor="#ff0000" HeaderStyle-BackColor="#cc0000" /> 
                <asp:BoundField DataField="action65DPAct" HeaderText="Action" /> 
                <asp:BoundField DataField="detailsOfDetectionIfAny" HeaderText="Details of detection, if any" /> 
                <asp:TemplateField HeaderText="Edit/Delete" ItemStyle-Width="10%" >
                    <ItemTemplate>
                        <a href='Pickets1.aspx?picketCode=<%# Eval("picket_id") %>'>
                            <img src="images/edit.ico" style="height: 20px; margin-right: 20px; width: 20px;" title="Edit" />
                        </a>
                        <asp:LinkButton ToolTip="Delete" ID="R1" runat="server" CommandArgument='<%# Eval("picket_id") %>' OnClientClick="return confirm('Are you sure to remove this Delivery?');" CommandName="Deletes"><img src="images/Delete_icon.png" style="height: 20px;width: 20px;" /> </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <SortedAscendingHeaderStyle BackColor="#808080"  />  
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
        </asp:GridView>
    </div>
                </div>

            </div>
        </div>



      

    </section>
    <script>
        function myMap() {
            var mapProp = {
                center: new google.maps.LatLng(28.65381, 77.22897),
                zoom: 5,
            };
            var map = new google.maps.Map(document.getElementById("googleMap"), mapProp);
        }
    </script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAceyJW1y3egtgcfKgJfxISHuzNHSQaNcc&callback=myMap"></script>
    <!-- /.content -->
    <script>
        function Task(ele, action) {
            var query = '';
            if (action == 'edit') {
                var val = ele.checked;
                var id = ele.value;
                if (val) {
                    query = "update Tble set col='" + id + "' where id='" + id + "'";
                }
                else {
                    query = "update Tble set col='" + id + "' where id='" + id + "'";
                }
            }
            else if (action == 'delete') {
                var id = ele.getAttribute('data-value');
                if (id != '' && id != null) {
                    query = "update Tble set col='" + id + "' where id='" + id + "'";
                }
            }
            if (query != '' && query != null) {
                TaskAjax(query);
            }
        }
        function TaskAjax(query) {
            alert(query);
            $.ajax({
                type: "POST",
                url: "home_new.aspx/Task",
                data: '{query: "' + query + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    alert(response.d);
                },
                failure: function (response) {
                    alert(response.d);
                }
            });

        }
    </script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

