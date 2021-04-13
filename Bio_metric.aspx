<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Bio_metric.aspx.cs" Inherits="Attendance" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel runat="server" id="UpdatePanel" updatemode="Conditional">
          <ContentTemplate>
   <%--<script>
       function OnSearch() {
           var obh = document.getElementById("ddlmonth");
          
               obj.options[obj.selectedIndex].text;
           var syear = document.getElementById('<%=ddlmonth.SelectedIndex%>').value;
           var smonthstatus = document.getElementById('<%=ddlyear.SelectedIndex%>').value;
          if (syear == '0' && smonthstatus =='0') {
              alert('Please fill any search fields!');
              return false;
          }
          return true;
      }
  </script>--%>
    <style>th{background:#3c8dbc} td:first-child {text-align: left;padding-left: 15px;}th:first-child {text-align: left;padding-left: 5px;}tr:hover{background:silver;cursor:pointer}tr:nth-child(even){background-color:#f4f4f4} </style>

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
    &nbsp
    <div style=" margin-top:20px; float: right;     margin-right: 3.5%; margin-bottom: 10px;" >
                 <asp:Button ID="btnSearch" class="btn btn-info pull-right" runat="server" Text="Search" Style="margin-right: 15px;" OnClick="btnSearch_Click" OnClientClick="return OnSearch();" />
    
  
        <asp:DropDownList ID="ddlyear" runat="server" style="     width: 190px;   margin-right: 15px;      padding: 4px;   float: right;"  OnSelectedIndexChanged="ddlyear_SelectedIndexChanged">
        <asp:ListItem Value="">-- Select Year --</asp:ListItem>
       
    </asp:DropDownList>
    <asp:DropDownList ID="ddlmonth" runat="server" style="     width: 190px;   margin-right: 15px; padding: 4px;   float: right;"  OnSelectedIndexChanged="ddlmonth_SelectedIndexChanged">
        <asp:ListItem Value="">-- Select Month --</asp:ListItem>
        <asp:ListItem Value="1">January</asp:ListItem>
        <asp:ListItem Value="2">February</asp:ListItem>
        <asp:ListItem Value="3">March</asp:ListItem>
        <asp:ListItem Value="4">April</asp:ListItem>
        <asp:ListItem Value="5">May</asp:ListItem>
        <asp:ListItem Value="5">June</asp:ListItem>
        <asp:ListItem Value="7">July</asp:ListItem>
        <asp:ListItem Value="8">August</asp:ListItem>
        <asp:ListItem Value="9">September</asp:ListItem>
        <asp:ListItem Value="10">Ocotber</asp:ListItem>
        <asp:ListItem Value="11">November</asp:ListItem>
        <asp:ListItem Value="12">December</asp:ListItem>
    </asp:DropDownList>
        
     <%--<asp:TextBox ID="txtActive" placeholder="Active ..." runat="server" style="    margin-right: 15px;      padding: 4px;   float: right;"></asp:TextBox>
     <asp:TextBox ID="txtAssigned" placeholder="Assigned To ..." runat="server" style="   width: 237px; margin-right: 15px;      padding: 4px;   float: right;"></asp:TextBox>
    <asp:TextBox ID="txtSearch" placeholder="Task Title ..." runat="server" style=" width: 237px;   margin-right: 15px;      padding: 4px;   float: right;"></asp:TextBox>--%>
   
</div>
 <div class="box" style="width:90%; margin-left:8%; margin-top:2%; margin-bottom:5%">
                          
                  <asp:GridView ID="Gdv_Attendance"  style="width: 95%;margin-left: 2%;" 
                AutoGenerateColumns="False" DataKeyNames="id" runat="server" 
                       OnRowCommand="GridView1_RowCommand" AllowPaging="True" 
                AllowSorting="True" onpageindexchanging="GridView1_PageIndexChanging"
                CellPadding="4" ForeColor="#333333" GridLines="None" >
                  <PagerStyle HorizontalAlign = "Right" Width="100%" CssClass = "box yagya" /> 
                 <Columns>
                  <asp:TemplateField HeaderText = "S.No." ItemStyle-Width="8%">
                    <ItemTemplate>
                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1+"." %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="id" HeaderText="ID" Visible="false" />                
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <%# Eval("Fname")%> <%# Eval("Mname")%> <%# Eval("Lname")%>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="In Time">
                    <ItemTemplate>
                        <%# Eval("Intime")%> 
                    </ItemTemplate>
                </asp:TemplateField>     
                     <asp:TemplateField HeaderText="Out Time">
                    <ItemTemplate>
                        <%# Eval("Outtime")%> 
                    </ItemTemplate>
                </asp:TemplateField>     
                      <asp:TemplateField HeaderText="Date">
                    <ItemTemplate>
                        <%# Eval("Adate")%> 
                    </ItemTemplate>
                </asp:TemplateField>  
                     <asp:TemplateField HeaderText="Hours">
                    <ItemTemplate>
                        <%# Eval("aHours")%> 
                    </ItemTemplate>
                </asp:TemplateField> 
               		  
                <%--<asp:TemplateField HeaderText="Action" ItemStyle-Width="10%">
                    <ItemTemplate>
                        <a href='NotificationAdd.aspx?ID=<%# Eval("id") %>'>
                            <img src="images/edit.ico" style="height: 20px;     margin-right: 20px; width: 20px;" title="Edit" />
                        </a>
                        <asp:LinkButton ToolTip="Delete" ID="R1" runat="server" CommandArgument='<%# Eval("id") %>' OnClientClick="return confirm('Are you sure to remove this Notification?');" CommandName="Deletes"><img src="images/Delete_icon.png" style="height: 20px;width: 20px;" /> </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                </Columns>
                </asp:GridView> 
          </div>
               </ContentTemplate>
              <Triggers>
           <%-- <asp:AsyncPostBackTrigger controlid="ddlmonth" eventname="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger controlid="ddlyear" eventname="SelectedIndexChanged" />
             <asp:AsyncPostBackTrigger controlid="btnSearch" eventname="Click" />--%>
           </Triggers>
          </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

