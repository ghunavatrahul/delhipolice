<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Role.aspx.cs" Inherits="Role" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">Roles Detail</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<%--<style>th{padding: 5px;background: #3c8dbc;}td:first-child{text-align: left;padding-left: 15px;}th:first-child{text-align: left;padding-left: 5px;}tr:hover{background: silver;cursor: pointer;}tr:nth-child(even){background-color: #f4f4f4;}</style>--%>
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
        tr:last-child 
        {
            background: #f4f4f4!important;
            border: solid 1px silver;
        }       
        .GridPager table
        {       
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
    
    
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js" type="text/javascript"></script>
    <script>
        //        $(document).ready(function () {
        //            $('#mydiv').hide();
        //            $("#ContentPlaceHolder1_btnAdd").click(function () {
        //                $('#mydiv').show();
        //                return false;                  
        //            });
        //        });
    </script>
    <%--<asp:Button ID="btnAdd" type="submit" class="btn btn-info pull-right" runat="server" onserverclick="btnAddRole_Click"/>--%>
    <button id="btnAdd" runat="server" type="submit" class="btn btn-info pull-right" style="margin-right: 12%" onserverclick="btnAddRole_Click">Create Role</button>

    <%--<div id="mydiv" style="width:80%; margin-left:10%; margin-top:5%" class="box box-default" >
        <div class="box-header with-border">
          <h3 class="box-title">Roles </h3>
           <div class="box-tools pull-right">
            <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>            
          </div>
         
        </div>        
        <div class="box-body" style="display: block;">
          <div class="row">
            <div class="col-md-6" style="margin-left: 27%;">
               <div class="form-group">
                <label id="lblId" runat="server" visible="false"></label>
                <label>Role Name</label>                               
                <asp:TextBox ID="txtRolename" class="form-control" runat="server" placeholder="Enter ..." style="margin-left: 0px;"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ErrorMessage="* Please Enter Role!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="txtRolename" ValidationGroup='valGroup1'></asp:RequiredFieldValidator>                                  
              </div>   
              <div class="form-group" >
                 <label>Page </label>                 
                  <asp:listbox runat="server" id="lstBoxTest" class="form-control" SelectionMode="Multiple"></asp:listbox> 
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ForeColor="Red" ErrorMessage="* Please Select Page!" SetFocusOnError="true" 
                    Display="Dynamic" ControlToValidate="lstBoxTest" ValidationGroup='valGroup1'></asp:RequiredFieldValidator> 
               </div>            
               <div class="checkbox">
                 <label><input id="chkStatus" runat="server" type="checkbox"> Status</label>
              </div>
            </div>                      
          </div>         
        </div>        
        <div class="box-footer" style="display: block;">
          <button id="btnCancel" runat="server" type="submit" class="btn btn-default" onserverclick="btnCancel_Click">Cancel</button>
          <button id="btnSave" runat="server"  type="submit" class="btn btn-info pull-right" onserverclick="btnSave_Click" ValidationGroup='valGroup1'>Submit</button>
        </div>
      </div>--%>

    <div>
               &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp Page Size:&nbsp
        <asp:DropDownList ID="ddlPageSize" runat="server" Style="width: 80px;  padding: 4px; margin-top:10px" AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged" Width="80">
          <%--<asp:ListItem Text="10" Value="10" />--%>
          <asp:ListItem Text="20" Value="20" />
          <asp:ListItem Text="50" Value="50" />
            <asp:ListItem Text="100" Value="100" />
       </asp:DropDownList><br />
            
            </div>

    <div id="grid" style="width: 80%; margin-left: 8%; margin-top: 5%" class="box">

        <asp:GridView OnRowCommand="GridView1_RowCommand" Style="width: 100%" ID="GridView1" OnRowDataBound="GridView1_OnRowDataBound" AutoGenerateColumns="False" DataKeyNames="role_id" runat="server" AllowSorting="True" AllowPaging="True" CellPadding="4"  GridLines="None" PageSize="20" OnPageIndexChanging="GridView1_PageIndexChanging">
           <PagerStyle HorizontalAlign = "Right" Width="100%" CssClass = "box yagya" />
           <Columns>
                <asp:TemplateField HeaderText = "S.No." ItemStyle-Width="1">
                    <ItemTemplate>
                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1+"." %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="role_name" HeaderText="Role Name" />
                <asp:TemplateField HeaderText="Pages Name">
                <ItemTemplate>
                <asp:Label ID="gvpages" runat="server" />                                    
               </ItemTemplate>
               </asp:TemplateField>
                <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <img src="dist/img/<%# Eval("Status") %>.png" style="width: 12px; height: 12px;" title='<%# Convert.ToBoolean(Eval("Status"))==true?"Active":"InActive" %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <a href='RoleAdd.aspx?ID=<%# Eval("role_id") %>'> <img src="images/edit.ico" style="height: 20px; margin-right: 20px; width: 20px;" title="Edit" /></a>
                        <asp:LinkButton ToolTip="Delete" ID="R1" runat="server" CommandArgument='<%# Eval("role_id") %>' OnClientClick="return confirm('Are you sure to remove this role?');" CommandName="Deletes"><img src="images/Delete_icon.png" style="height:20px;width: 20px;" /> </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>


