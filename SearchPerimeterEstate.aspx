<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchPerimeterEstate.aspx.cs" Inherits="SearchPerimeterEstate" MasterPageFile="~/MasterPage.master" %>
<asp:Content ContentPlaceHolderID="head" runat="server">
    <style>
        .center_text
        {
            text-align:center;
        }
        .button
        {
            background-color:royalblue;
            color:white;
            cursor:pointer;
            border:none;
            border-radius:2px;
            height:25px;
            font-size:15px;
        }
        .button:hover
        {
            opacity:0.8;
        }
        .backbtn
        {
            background-color:royalblue;
            color:white;
            cursor:pointer;
            border:none;
            border-radius:2px;
            height:25px;
            width:80px;
            font-size:15px;
            display:block;
            line-height:25px;
            text-align:center;
        }

        .backbtn:hover
        {
            opacity:0.8;
        }

        .mapImage
        {
            padding-left: 35px;

        }
        .gridview
        {
            padding-top: 0px;
            margin-top: 0px;
        }
        .hide
        {
            display: none;
        }

    </style>
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="StyleSheet.css" />
    <div style="margin-top:2%;">
        <center>
            <h2>PERIMETER SURVEY MAP</h2>
            <table>
                <tr>
                    <td>Estate</td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="estate" runat="server" Width="182px"></asp:TextBox>
                    </td>
                    <td></td>
                    <td>
                        <asp:Button CssClass="button" ID="search_estate" runat="server" Text="SEARCH" OnClick="search_estate_Click" />
                    </td>
                </tr>
            </table>
            <br />
            
            <asp:Label ID="estateName" runat="server" Visible="false"></asp:Label>
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
            
            
            <div id="displayMap" runat="server">
                <h3 runat="server" id="lblEst"></h3>
                <h3 runat ="server" id="landtitlemaptxt"></h3>
                <table>
                    <tr>
                        <td>
                            <asp:ImageButton ID="plan_url" runat="server" OnClientClick="DisplayPlanNo()" width="850px" Height="600px" />
                        </td>
                    </tr>
                </table>
                
            <script type="text/javascript">
                function DisplayPlanNo()
                {
                    window.open('DisplayLandTitleMap.aspx', 'open_window', 'width=1500, height=1000, left = 0, top = 0, center=yes, scrollbars=1');
                }
            </script>
            </div>
            <h3 id="plannolabel" runat="server"></h3>
            <asp:GridView ID="GridView1" runat="server" CellPadding="3" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                <Columns>
                    <asp:TemplateField HeaderText="View Plan">
                        <ItemTemplate>
                            <!--<a href='#' onclick='DisplayDIV();' style='text-align: center; padding: 5px; margin: 0; '></a>
                            <asp:LinkButton Text="View" runat="server" OnClientClick="DisplayDIV()" CommandName="View" CommandArgument="<%# Container.DataItemIndex %>"/>-->
                            <a href='<%#Eval("planNo_image","DisplayPlanNoPerimeterByEstate.aspx?planNo={0}") %>' target="_blank">View</a>
                        </ItemTemplate>
                        <ItemStyle Width="150px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="planNo_image" HeaderText="Plan No Image" ItemStyle-Width="150px" >
                    <HeaderStyle CssClass="hide" />
                    <ItemStyle Width="150px" CssClass="hide" ></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="planNo" HeaderText="Plan No" ItemStyle-Width="150px" >
                    <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="district" HeaderText="District" ItemStyle-Width="150px" >
                    <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="estate" HeaderText="Estate" ItemStyle-Width="150px" >
                    <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="tv" HeaderText="Traverse Volume" ItemStyle-Width="150px" >
                    <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="page" HeaderText="Page" ItemStyle-Width="150px" >
                    <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>

            <asp:PlaceHolder ID="PlaceHolder2" runat="server" Visible="false"></asp:PlaceHolder>
            <asp:Label ID="placeholder2empty" runat="server"></asp:Label>
            <asp:PlaceHolder ID="PlaceHolder3" runat="server"></asp:PlaceHolder>
            <asp:Label ID="placeholder3empty" runat="server"></asp:Label>
            </center>
         
            <center>
       <asp:Label ID="labelEmpty" runat="server"></asp:Label>
                <br />
             </center>
           <script type="text/javascript">
               function setTarget() {
                   document.forms[0].target = "_blank";
                   return false;
               }
    </script>
                </div>
                <center>
            <div>
                <table>
                    <tr>
                        <td>
                            <asp:Button CssClass="button" ID="deletebtn" runat="server" OnClick="deletebtn_Click" Text="DELETE" />
                        </td>
                        <td>
                            <a href="SearchPerimeterSelection.aspx" class="backbtn" runat="server">BACK</a>
                        </td>
                    </tr>
                </table>
            </div>
                    </center>
    </div>
</asp:Content>
    