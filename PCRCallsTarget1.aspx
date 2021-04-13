<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="PCRCallsTarget1.aspx.cs" Inherits="PCRCallsTarget1" %>
 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">Add Edit Deployment</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
    <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.10.0.min.js" type="text/javascript"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/jquery-ui.min.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/themes/blitzer/jquery-ui.css"
        rel="Stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $("[id$=txtProduct]").autocomplete({
                source: function (request, response) {
                    //var vendor = $("[id$ = txtVendor]").val();
                    $.ajax({
                        url: '<%=ResolveUrl("~/Delivery.aspx/GetCustomer5") %>',
                        data: "{ 'prefix': '" + request.term +"'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('-')[0],
                                    val: item.split('-')[1]
                                }
                            }))
                        },
                        error: function (response) {
                            alert(response.responseText);
                        },
                        failure: function (response) {
                            alert(response.responseText);
                        }
                    });
                },
   

      
             }),
  






            $("[id$=txtVendor]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/Delivery.aspx/GetProducts") %>',
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            if (data.d == null || data.d == '')
                            {
                                alert("Please Enter the valid Vendor Name");
                            }
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('-')[0],
                                    val: item.split('-')[1]
                                }
                            }))
                        },
                        error: function (response) {
                            alert(response.responseText);
                        },
                        failure: function (response) {
                            alert(response.responseText);
                        }
                    });
                },
                select: function (e, i) {
                    $("[id$=hfProductId]").val(i.item.val);
                    //alert('id Yagya' + i.item.val);

                    $.ajax({
                        url: '<%=ResolveUrl("~/Delivery.aspx/GetPickuploc") %>',
                            data: "{ 'prefix': '" + i.item.val + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {
                                var result = JSON.stringify(data.d);
                                result = JSON.parse(result);
                                $("[id$=txtpick]").val(result[0]);
                                $("[id$=txtpickaddr]").val(result[1]);
                                $("[id$=ddlstate]").val(result[2]);
                                $("[id$=ddlcity]").val(result[3]);
                                $("[id$=ddlwarehouse]").val(result[4]);
                                $("[id$=txtpickzipcode]").val(result[5]);
                                $("[id$=txtProduct]").val(result[6]);
                                $("[id$=txtQuantity]").val(result[7]);

                                //getcity();
                                $("[id$=ddlcity]").val(result[3]);
                            },
                            error: function (response) {
                                alert(response.responseText);
                            },
                            failure: function (response) {
                                alert(response.responseText);
                            }
                        });
                },
                minLength: 1
            });


            $("[id$=txtEmployee]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/Delivery.aspx/GetEmployee") %>',
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('-')[0],
                                    val: item.split('-')[1]
                                }
                            }))
                        },
                        error: function (response) {
                            alert(response.responseText);
                        },
                        failure: function (response) {
                            alert(response.responseText);
                        }
                    });
                },
                select: function (e, i) {
                    $("[id$=hfempId]").val(i.item.val);
                    //alert('id Yagya' + i.item.val);
                },
                minLength: 1
            });

        });

        function getcity() {
            $.ajax({
                url: '<%=ResolveUrl("~/Delivery.aspx/GetCity") %>',
                data: "{ 'prefix': '" + $("[id$=ddlstate]").val() + "'}",
                  dataType: "json",
                  type: "POST",
                  contentType: "application/json; charset=utf-8",
                  success: function (Result) {
                      Result = Result.d;
                      //var result = JSON.stringify(data.d);
                      //result = JSON.parse(result);                      
                      $.each(Result, function (key, value) {
                          $("[id$=ddlcity]").append($("<option></option>").val(value.cityid).html(value.name));
                      });
                  },
                  error: function (response) {
                      alert(response.responseText);
                  },
                  failure: function (response) {
                      alert(response.responseText);
                  }
            });
        }

        function getDeliverycity() {
            $.ajax({
                url: '<%=ResolveUrl("~/Delivery.aspx/GetDeliveryCity") %>',
                data: "{ 'prefix': '" + $("[id$=ddldeliverystate]").val() + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (Result) {
                    Result = Result.d;
                    //var result = JSON.stringify(data.d);
                    //result = JSON.parse(result);                      
                    $.each(Result, function (key, value) {
                        $("[id$=ddldeliverycity]").append($("<option></option>").val(value.cityid).html(value.name));
                    });
                },
                error: function (response) {
                    alert(response.responseText);
                },
                failure: function (response) {
                    alert(response.responseText);
                }
            });
        }
    </script>
   
    <div id="mydiv" style="width:80%; margin-left:10%; margin-top:5%;  background:#ffffff;" class="box box-default">        
        <div class="box-body" style="display: block;">
          <div class="row">
            <div class="col-md-6"> 
                <label id="lblId" runat="server" visible="false"></label>                                                 
                   <div class="form-group">
                <label>Head Name</label>               
                 <asp:TextBox ID="txtHeadName" class="form-control" runat="server"  style="margin-left: 0px;" ReadOnly="true"></asp:TextBox>
                 <asp:HiddenField ID="hfId" runat="server" />      
                 <asp:HiddenField ID="hfHeadId" runat="server" />      
              </div>          
               <div class="form-group">
                <label>Weekly Target</label>             
                <asp:TextBox ID="txtWeeklyTarget" class="form-control" runat="server" placeholder="Enter Weekly Target ..." TextMode="MultiLine" />
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ErrorMessage="* Please Enter Weekly Target" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="txtWeeklyTarget" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="Red" ControlToValidate="txtWeeklyTarget" SetFocusOnError="true" 
                 Display="Dynamic" ValidationExpression="[a-zA-Z0-9 /.()-]*$" ErrorMessage="* Only Valid characters!" ValidationGroup='valGroup1' />
              </div>                 
                  
                <script type="text/javascript">
                    function showDate1() {
                        $find("Date1").show();
                    }
            </script>   
                                            
            </div>            
          </div>         
        </div>
        
        <div class="box-footer" style="display: block;">
          
          <button id="btnCancel" runat="server" type="submit" class="btn btn-info pull-right" onserverclick="btnCancel_Click" causesvalidation="false">Cancel</button>
            <asp:Button id="btnSubmit" runat="server" Text="Save" class="btn btn-info pull-right" OnClick="btnSubmit_Click" ValidationGroup='valGroup1' style="margin-right: 15px;"/>
       
        </div>
      
      </div>
      
</asp:Content>


