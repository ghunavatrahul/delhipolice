<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Delivery.aspx.cs" Inherits="Delivery" %>
 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">Delivery</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
    <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.10.0.min.js" type="text/javascript"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/jquery-ui.min.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/themes/blitzer/jquery-ui.css"
        rel="Stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $("[id$=txtSearch]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/Delivery.aspx/GetCustomers") %>',
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
                    //alert("text");
                },
                select: function (e, i) {
                    $("[id$=hfCustomerId]").val(i.item.val);
                    //alert('id Yagya' + i.item.val);

                    $.ajax({
                        url: '<%=ResolveUrl("~/Delivery.aspx/Getloc") %>',
                        data: "{ 'prefix': '" + i.item.val + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {
                                var result = JSON.stringify(data.d);
                                result = JSON.parse(result);
                                $("[id$=txtDelivery]").val(result[0]);
                                $("[id$=txtadr2]").val(result[1]);
                                $("[id$=ddldeliverystate]").val(result[3]);
                               
                                $("[id$=txtZipcode]").val(result[4]);
                                $("[id$=txtEmial]").val(result[5]);
                                $("[id$=txtphone]").val(result[6]);

                                //getDeliverycity();
                                $("[id$=ddldeliverycity]").val(result[2]);
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
                <label>Vendor Name</label>               
                 <asp:TextBox ID="txtVendor" class="form-control" runat="server" placeholder="Enter Vendor ..." style="margin-left: 0px;" ></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ForeColor="Red" ErrorMessage="* Please Enter Vendor!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="txtVendor" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="Red" ControlToValidate="txtVendor" SetFocusOnError="true" 
                 Display="Dynamic" ValidationExpression="[a-zA-Z ]*$" ErrorMessage="* Only Valid characters!" />                       
              </div>          
               <div class="form-group">
                <label>Product</label>             
                <asp:TextBox ID="txtProduct" class="form-control" runat="server" placeholder="Enter Product ..." />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ForeColor="Red" ControlToValidate="txtProduct" SetFocusOnError="true" 
                 Display="Dynamic" ValidationExpression="[a-zA-Z ]*$" ErrorMessage="* Only Valid characters!" />
                <asp:HiddenField ID="hfProductId" runat="server" />                 
              </div>                 
                  <div class="form-group">
                <label>Quantity</label>               
                 <asp:TextBox ID="txtQuantity" class="form-control" runat="server" placeholder="Enter Quantity ..." style="margin-left: 0px;" ></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ForeColor="Red" ErrorMessage="* Please Enter Quantity!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="txtQuantity" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>  
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtQuantity" ErrorMessage="! Only numeric allowed." 
                    ForeColor="Red" ValidationExpression="^[0-9]*$" ValidationGroup="valGroup1" Display="Dynamic" SetFocusOnError="true"></asp:RegularExpressionValidator>                    
              </div>   
               <div class="form-group">
                <label>Pick up Location</label>               
                 <asp:TextBox ID="txtpick" class="form-control" runat="server" placeholder="Enter Pick Up Location ..." TextMode="MultiLine" style="margin-left: 0px;"   ></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red" ErrorMessage="* Please Enter Pick Up Address!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="txtpick" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                   <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ForeColor="Red" ControlToValidate="txtpick" SetFocusOnError="true" 
                 Display="Dynamic" ValidationExpression="[a-zA-Z ]*$" ErrorMessage="* Only Valid characters!" />--%>                      
              </div> 
                <div class="form-group"> 
                 <label>Country</label>                 
                 <asp:TextBox ID="txtpickaddr" class="form-control" runat="server" placeholder="Enter Country..." style="margin-left: 0px;" ></asp:TextBox> 
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ForeColor="Red" ErrorMessage="* Please Enter Country!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="txtpickaddr" ValidationGroup='valGroup1'></asp:RequiredFieldValidator> 
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ForeColor="Red" ControlToValidate="txtpickaddr" SetFocusOnError="true" 
                 Display="Dynamic" ValidationExpression="[a-zA-Z ]*$" ErrorMessage="* Only Valid characters!" />                                      
            </div>
            
            <div class="form-group">           
                  <label> State </label>
                <%-- <asp:TextBox ID="txtpickstate" class="form-control" runat="server" placeholder="Enter State..." style="margin-left: 0px;" ></asp:TextBox> 
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ForeColor="Red" ErrorMessage="* Please Enter State!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="txtpickstate" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>--%>    
                 <asp:DropDownList ID="ddlstate" class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged"  >                               
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ForeColor="Red" ErrorMessage="* Please Select State!" SetFocusOnError="true"
                Display="Dynamic" ControlToValidate="ddlstate" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>            
            </div> 
            
            <div class="form-group">           
                  <label> City </label>                
                 <asp:DropDownList ID="ddlcity" class="form-control" runat="server">                               
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ForeColor="Red" ErrorMessage="* Please Select City!" SetFocusOnError="true"
                Display="Dynamic" ControlToValidate="ddlcity" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>               
            </div>
                <div class="form-group">           
                  <label> WareHouse </label>                
                 <asp:DropDownList ID="ddlwarehouse" class="form-control" runat="server">                               
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ForeColor="Red" ErrorMessage="* Please Select Warehouse!" SetFocusOnError="true"
                Display="Dynamic" ControlToValidate="ddlwarehouse" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>               
            </div>
            
            
            <div class="form-group">           
                  <label> Zipcode </label>
                 <asp:TextBox ID="txtpickzipcode" class="form-control" runat="server" placeholder="Enter Zipcode..." style="margin-left: 0px;" ></asp:TextBox> 
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ForeColor="Red" ErrorMessage="* Please Enter Zipcode!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="txtpickzipcode" ValidationGroup='valGroup1'></asp:RequiredFieldValidator> 
                   <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtpickzipcode" ErrorMessage="! Only numeric allowed." 
                    ForeColor="Red" ValidationExpression="^[0-9]*$" ValidationGroup="valGroup1" Display="Dynamic" SetFocusOnError="true"></asp:RegularExpressionValidator>                
            </div>
                  <div class="form-group">
                <label>Assign To</label>             
                <asp:TextBox ID="txtEmployee" class="form-control" runat="server" placeholder="Enter Employee Name..." />
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ForeColor="Red" ControlToValidate="txtEmployee" SetFocusOnError="true" 
                 Display="Dynamic" ValidationExpression="[a-zA-Z ]*$" ErrorMessage="* Only Valid characters!" />
                <asp:HiddenField ID="hfempId" runat="server" />                 
              </div>
                    <div class="form-group">
                <label>Order Date:</label>               
                  <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                    </cc1:ToolkitScriptManager>
                    <asp:TextBox ID="txtstartdate"  onkeypress = 'return false' onclick="showDate();"  runat="server" class="form-control pull-right" placeholder="Choose Order Date ..." ></asp:TextBox>
                    <asp:ImageButton ID="imgPopup" ImageUrl="images/calendar.png" class="form-control pull-right" ImageAlign="Bottom" runat="server" style="margin-top: -34px; width: 42px;" />
                    <cc1:CalendarExtender TodaysDateFormat="dd/MM/yyyy" ID="Calendar1" PopupButtonID="imgPopup" BehaviorID="Date" runat="server" TargetControlID="txtstartdate" Format="dd/MM/yyyy">
                    </cc1:CalendarExtender>                
                </div>            
             <script type="text/javascript">
                 function showDate() {
                     $find("Date").show();
                 }
            </script>
                 <div class="form-group" >
                 <label style="margin-top: 12px;">Delivery Status </label>
                 <asp:DropDownList ID="ddldeliverstatus" class="form-control" runat="server" >
                    <asp:ListItem Value="">Select Delivery Status ...</asp:ListItem>
                     <asp:ListItem Value="1">Opened</asp:ListItem>
                     <asp:ListItem Value="2">Delivered</asp:ListItem>                     
                  </asp:DropDownList> 
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ForeColor="Red" ErrorMessage="* Please Select Delivery Status!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="ddldeliverstatus" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>                  
               </div>          
            </div>           
            <div class="col-md-6">
                   
                <div class="form-group">    
                <%--  <input type="text"  id="rrr" />    --%>      
                <label>Customer</label>               
                <asp:TextBox ID="txtSearch" class="form-control" runat="server" placeholder="Enter Customer Name..."/>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ForeColor="Red" ControlToValidate="txtSearch" SetFocusOnError="true" 
                 Display="Dynamic" ValidationExpression="[a-zA-Z ]*$" ErrorMessage="* Only Valid characters!" />
                <asp:HiddenField ID="hfCustomerId" runat="server" />
                <asp:Button ID="Button1" Text="Submit" runat="server" OnClick="Submit" Visible="false" />   
              </div>  
                  <div class="form-group">           
                  <label> Email ID </label>
                 <asp:TextBox ID="txtEmial" class="form-control" runat="server" placeholder="Enter Email..." style="margin-left: 0px;" ></asp:TextBox> 
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ForeColor="Red" ErrorMessage="* Please Enter Email!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="txtEmial" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>   
                 <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                    ControlToValidate="txtEmial" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" ErrorMessage="* Invalid Email Format"></asp:RegularExpressionValidator>             
            </div> 
            
            <div class="form-group">           
                  <label> Phone Number </label>
                 <asp:TextBox ID="txtphone" class="form-control" runat="server" placeholder="Enter Phone Number..." style="margin-left: 0px;" ></asp:TextBox> 
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ForeColor="Red" ErrorMessage="* Please Enter Phone Number!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="txtphone" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>  
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtphone" ErrorMessage="! Only numeric allowed." 
                    ForeColor="Red" ValidationExpression="^[0-9]*$" ValidationGroup="valGroup1" Display="Dynamic" SetFocusOnError="true"></asp:RegularExpressionValidator> 
                  <%--  <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ControlToValidate="txtphone" ErrorMessage="! Maximum 10 characters allowed." 
                    ForeColor="Red" ValidationExpression="^[\s\S]{10,10}$" ValidationGroup="valGroup1" Display="Dynamic" SetFocusOnError="true"></asp:RegularExpressionValidator>                --%>
            </div>          
                <div class="form-group">
                <label>Delivery Location</label>               
                 <asp:TextBox ID="txtDelivery" class="form-control" runat="server" placeholder="Enter Delivery Location ..." TextMode="MultiLine" style="margin-left: 0px;"  ></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ForeColor="Red" ErrorMessage="* Please Enter Delivery Address!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="txtDelivery" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                    <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ForeColor="Red" ControlToValidate="txtEmployee" SetFocusOnError="true" 
                 Display="Dynamic" ValidationExpression="[a-zA-Z ]*$" ErrorMessage="* Only Valid characters!" /> --%>
                                         
              </div> 
                <div class="form-group"> 
                 <label>Country</label>                   
                 <asp:TextBox ID="txtadr2" class="form-control" runat="server" placeholder="Enter Country..." style="margin-left: 0px;" ></asp:TextBox>  
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ForeColor="Red" ErrorMessage="* Please Enter Country!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="txtadr2" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ForeColor="Red" ControlToValidate="txtEmployee" SetFocusOnError="true" 
                 Display="Dynamic" ValidationExpression="[a-zA-Z ]*$" ErrorMessage="* Only Valid characters!" />                                      
            </div>
            
            <div class="form-group">           
                  <label> State </label>
                <%-- <asp:TextBox ID="txtState" class="form-control" runat="server" placeholder="Enter State..." style="margin-left: 0px;" ></asp:TextBox> 
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ErrorMessage="* Please Enter State!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="txtState" ValidationGroup='valGroup1'></asp:RequiredFieldValidator> --%>  
                 <asp:DropDownList ID="ddldeliverystate" class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddldeliverystate_SelectedIndexChanged"  >                               
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ErrorMessage="* Please Select State!" SetFocusOnError="true"
                Display="Dynamic" ControlToValidate="ddldeliverystate" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>             
            </div> 
            
            <div class="form-group">           
                  <label> City </label>
                 <%--<asp:TextBox ID="txtCity" class="form-control" runat="server" placeholder="Enter City..." style="margin-left: 0px;" ></asp:TextBox> 
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ErrorMessage="* Please Enter City!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="txtCity" ValidationGroup='valGroup1'></asp:RequiredFieldValidator> --%>   
                 <asp:DropDownList ID="ddldeliverycity" class="form-control" runat="server">                               
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ErrorMessage="* Please Select City!" SetFocusOnError="true"
                Display="Dynamic" ControlToValidate="ddldeliverycity" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>             
            </div>
            
            <div class="form-group">           
                  <label> Zipcode </label>
                 <asp:TextBox ID="txtZipcode" class="form-control" runat="server" placeholder="Enter Zipcode..." style="margin-left: 0px;" ></asp:TextBox> 
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ErrorMessage="* Please Enter Zipcode!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="txtZipcode" ValidationGroup='valGroup1'></asp:RequiredFieldValidator> 
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server" ControlToValidate="txtpickzipcode" ErrorMessage="! Only numeric allowed." 
                    ForeColor="Red" ValidationExpression="^[0-9]*$" ValidationGroup="valGroup1" Display="Dynamic" SetFocusOnError="true"></asp:RegularExpressionValidator>                
            </div>                                
                   <div class="form-group" >
                 <label>Priority </label>
                 <asp:DropDownList ID="ddlPriority" class="form-control" runat="server" >
                    <asp:ListItem Value="">Select Priority ...</asp:ListItem>
                     <asp:ListItem Value="1">Low</asp:ListItem>
                     <asp:ListItem Value="2">Medium</asp:ListItem>
                     <asp:ListItem Value="3">High</asp:ListItem>
                  </asp:DropDownList> 
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ForeColor="Red" ErrorMessage="* Please Select Priority!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="ddlPriority" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>                  
               </div>  
                  <div class="form-group">
                <label>Estimated Date:</label>                
                <asp:TextBox ID="txtduedate" onkeypress = 'return false' onclick="showDate1();" runat="server" PopupButtonID="ImageButton1" class="form-control pull-right" placeholder="Choose Estimated Date ..." ></asp:TextBox>
                <asp:ImageButton ID="ImageButton1" ImageUrl="images/calendar.png" class="form-control pull-right" ImageAlign="Bottom" runat="server" style="margin-top: -34px; width: 42px;" />
                <cc1:CalendarExtender  TodaysDateFormat="dd/MM/yyyy"  ID="CalendarExtender1" BehaviorID="Date1" PopupButtonID="ImageButton1" runat="server" TargetControlID="txtduedate" Format="dd/MM/yyyy">
                </cc1:CalendarExtender>                
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
          <button id="btnMap" runat="server" type="submit" class="btn btn-info pull-left" onserverclick="btnMap_Click">Map</button>
          <button id="btnCancel" runat="server" type="submit" class="btn btn-info pull-right" onserverclick="btnCancel_Click">Cancel</button>
            <asp:Button id="btnSubmit" runat="server" Text="Save" class="btn btn-info pull-right" OnClick="btnSubmit_Click" ValidationGroup='valGroup1' style="margin-right: 15px;"/>
       <%--   <button id="btnSubmit" runat="server"  type="submit" class="btn btn-info pull-right" onserverclick="btnSubmit_Click" ValidationGroup='valGroup1' style="margin-right: 15px;">Submit</button>--%>
        </div>
      
      </div>
      <iframe src="Map.aspx?addr1=<%=addr1 %>&addr2=<%=addr2 %>" style="margin-bottom:100px;  border: solid 1px silver;margin-left: 137px;width: 80%;height: 500px;"></iframe>
</asp:Content>


