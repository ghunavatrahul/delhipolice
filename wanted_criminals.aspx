<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="wanted_criminals.aspx.cs" Inherits="wanted_criminals" %>

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
    <section class="content" style="width: 90%;">


        <div class="row">
            <div class="col-md-12">
                <div class="box box-info">
                    <h3 class="box-title" style="margin-left: 15px;">Wanted Criminals</h3>
                    <div class="box-header with-border">
                        <h3 class="box-title">Wanted Criminals</h3>
                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                <i class="fa fa-minus"></i>
                            </button>
                            <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                        </div>
                    </div>



                    <!-- New style of grid view is added here with edit functionality -->
                     <div class="box" style="width: 98%; margin-left: 2%; margin-top: 0%; margin-right: 1%; margin-bottom: 5%">
                        <div class="btn btn-box-tool text-bold"><h4>Wanted Criminals</h4></div>
        <asp:Button ID="btnAdd" class="btn btn-info pull-right" runat="server" Text="Add BC'S" Style="margin-right:5%; background-color:#117A65;" OnClick="btnAdd_Click" />    
        <asp:GridView ID="GridView1" Style="width: 100%; margin-left: 0%;" AutoGenerateColumns="False" DataKeyNames="wanted_id" 
            runat="server" OnRowCommand="GridView1_RowCommand" AllowSorting="True" CellPadding="4" GridLines="None" ShowFooter="False">
            <PagerStyle HorizontalAlign="Right" Width="100%" CssClass="box yagya" />




            <Columns>
              <asp:TemplateField HeaderText="S.No." ItemStyle-Width="1">
                    <ItemTemplate>
                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 +"."%>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="wanted_id" HeaderText="wanted_id" ItemStyle-Width="8%"  Visible="false"/>
                <asp:BoundField DataField="details" HeaderText="Details of Wanted Criminal" />  
                <asp:BoundField DataField="detailsofgang" HeaderText="Details of the gang (if any) to which the criminal is associated" />  
                <asp:BoundField DataField="rivalgang" HeaderText="Rival gang of the criminal/of the gang to which the criminal belongs" /> 
                <asp:BoundField DataField="associatesofcrimals" HeaderText="Associates of the criminal" />
                <asp:BoundField DataField="detailscasehewanted" HeaderText="Details of Case in which he is wanted" />
                <asp:BoundField DataField="assiendpoliceofficer" HeaderText="Police officer assigned including Inspr./SI/Beat Officer" />
                <asp:BoundField DataField="effortsduringday" HeaderText="Efforts made during the day" />


            <asp:TemplateField HeaderText="Action" ItemStyle-Width="10%" >
             <ItemTemplate>
                        <a href='wanted_criminals1.aspx?WantedId=<%# Eval("wanted_id") %>'>
                            <img src="images/edit.ico" style="height: 20px; margin-right: 20px; width: 20px;" title="Edit" />
                        </a>
                        <asp:LinkButton ToolTip="Delete" ID="R1" runat="server" CommandArgument='<%# Eval("wanted_id") %>' OnClientClick="return confirm('Are you sure to remove this Delivery?');" CommandName="Deletes"><img src="images/Delete_icon.png" style="height: 20px;width: 20px;" /> </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                </Columns>
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

