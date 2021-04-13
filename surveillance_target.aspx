<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="surveillance_target.aspx.cs" Inherits="surveillance_target" %>

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
                <h3 style="margin-left: 20px;">Targeted Surveillance on Criminals</h3>
                <div class="box box-info">
                    <h3 class="box-title" style="margin-left: 15px;">Checking of BCs</h3>
                    <div class="box-header with-border">
                        <h3 class="box-title">Checking of BCs</h3>
                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                <i class="fa fa-minus"></i>
                            </button>
                            <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                        </div>
                    </div>
                    <div class="box-body">

                        <div class="table-responsive">

                            <asp:GridView ID="GridView1" runat="server" OnPageIndexChanging="GridView1_PageIndexChanging" ForeColor="Black" HeaderStyle-BackColor="#0066cc" Width="100%">
                                <PagerStyle HorizontalAlign="Right" Width="100%" CssClass="GridPager" />
                            </asp:GridView>
                        </div>
                    </div>
                    
                </div>


                <div class="box box-info">
                    <h3 class="box-title" style="margin-left: 15px;">Checking of Jail-Bail Released</h3>
                    <div class="box-header with-border">
                        <h3 class="box-title">Checking of Jail-Bail Released</h3>
                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                <i class="fa fa-minus"></i>
                            </button>
                            <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                        </div>
                    </div>
                    <div class="box-body">

                        <div class="table-responsive">

                            <asp:GridView ID="GridView2" runat="server" OnPageIndexChanging="GridView2_PageIndexChanging" ForeColor="Black" HeaderStyle-BackColor="#0066cc" Width="100%">
                                <PagerStyle HorizontalAlign="Right" Width="100%" CssClass="GridPager" />
                            </asp:GridView>
                        </div>
                    </div>

                </div>


                
                <div class="box box-info">
                    <h3 class="box-title" style="margin-left: 15px;">Checking of Ruffians/Budding Criminals</h3>
                    <div class="box-header with-border">
                        <h3 class="box-title">Checking of Ruffians/Budding Criminals</h3>
                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                <i class="fa fa-minus"></i>
                            </button>
                            <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                        </div>
                    </div>
                    <div class="box-body">

                        <div class="table-responsive">

                            <asp:GridView ID="GridView3" runat="server" OnPageIndexChanging="GridView3_PageIndexChanging" ForeColor="Black" HeaderStyle-BackColor="#0066cc" Width="100%">
                                <PagerStyle HorizontalAlign="Right" Width="100%" CssClass="GridPager" />
                            </asp:GridView>
                        </div>
                    </div>

                </div>




                <div class="box box-info">
                    <h3 class="box-title" style="margin-left: 15px;">Externment 2021</h3>
                    <div class="box-header with-border">
                        <h3 class="box-title">Externment 2021</h3>
                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                <i class="fa fa-minus"></i>
                            </button>
                            <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                        </div>
                    </div>
                    <div class="box-body">

                        <div class="table-responsive">

                            <asp:GridView ID="GridView4" runat="server" OnPageIndexChanging="GridView4_PageIndexChanging" ForeColor="Black" HeaderStyle-BackColor="#0066cc" Width="100%">
                                <PagerStyle HorizontalAlign="Right" Width="100%" CssClass="GridPager" />
                            </asp:GridView>
                        </div>
                    </div>

                </div>




                   <div class="box box-info">
                    <h3 class="box-title" style="margin-left: 15px;">History Sheet  2021</h3>
                    <div class="box-header with-border">
                        <h3 class="box-title">History Sheet  2021<h3>
                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                <i class="fa fa-minus"></i>
                            </button>
                            <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                        </div>
                    </div>
                    <div class="box-body">

                        <div class="table-responsive">

                            <asp:GridView ID="GridView5" runat="server" OnPageIndexChanging="GridView5_PageIndexChanging" ForeColor="Black" HeaderStyle-BackColor="#0066cc" Width="100%">
                                <PagerStyle HorizontalAlign="Right" Width="100%" CssClass="GridPager" />
                            </asp:GridView>
                        </div>
                    </div>

                </div>






                <div class="box box-info">
                    <h3 class="box-title" style="margin-left: 15px;">Dossier  2021</h3>
                    <div class="box-header with-border">
                        <h3 class="box-title">Dossier  2021<h3>
                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                <i class="fa fa-minus"></i>
                            </button>
                            <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                        </div>
                    </div>
                    <div class="box-body">

                        <div class="table-responsive">

                            <asp:GridView ID="GridView6" runat="server" OnPageIndexChanging="GridView6_PageIndexChanging" ForeColor="Black" HeaderStyle-BackColor="#0066cc" Width="100%">
                                <PagerStyle HorizontalAlign="Right" Width="100%" CssClass="GridPager" />
                            </asp:GridView>
                        </div>
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

