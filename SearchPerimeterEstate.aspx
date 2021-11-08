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
                        <asp:TextBox ID="estate" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button CssClass="button" ID="search_estate" runat="server" Text="SEARCH" OnClick="search_estate_Click" />
                    </td>
                </tr>
            </table>
            <br />
            <div id="result" runat="server">
                <!-- search result will be displayed here -->
                <asp:DataList ID="DataList" runat="server" RepeatColumns="4" CellPadding="8" OnItemDataBound="DataList_ItemDataBound">
            <ItemTemplate>
                <table>
                    <tr>
                        <td>
                            <asp:ImageButton ID="imageUrl" runat="server" OnClick="imageUrl_Click" Width="250px" Height="150px" ImageUrl='<%#Eval("planNo_image") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td class="center_text">
                            <asp:Label runat="server" Text='<%#Eval("district")%>'></asp:Label>
                            <br />
                            <asp:Label runat="server" Text='<%#Eval("estate")%>'></asp:Label>
                            <br />
                            <asp:Label runat="server" Text='<%#Eval("planNo_image")%>' Visible="false" ID="map_url"></asp:Label>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
       <asp:Label ID="labelEmpty" runat="server" Visible="false"></asp:Label>
           <script type="text/javascript">
               function setTarget() {
                   document.forms[0].target = "_blank";
                   return false;
               }
    </script>
                </div>
            <br />
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
    